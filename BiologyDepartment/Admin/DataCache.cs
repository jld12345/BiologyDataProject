using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using Npgsql;
using NpgsqlTypes;
using System.Windows.Forms;

namespace BiologyDepartment
{
    class DataCache
    {
        private static int RowsPerPage;
        private DataPage[] cachePages;
        private IDataPageRetriever dataSupply;

        // Represents one page of data.   
        public struct DataPage
        {
            public DataTable table;
            private int lowestIndexValue;
            private int highestIndexValue;

            public DataPage(DataTable table, int rowIndex)
            {
                this.table = table;
                lowestIndexValue = MapToLowerBoundary(rowIndex);
                highestIndexValue = MapToUpperBoundary(rowIndex);
                System.Diagnostics.Debug.Assert(lowestIndexValue >= 0);
                System.Diagnostics.Debug.Assert(highestIndexValue >= 0);
            }

            public int LowestIndex
            {
                get
                {
                    return lowestIndexValue;
                }
            }

            public int HighestIndex
            {
                get
                {
                    return highestIndexValue;
                }
            }

            public static int MapToLowerBoundary(int rowIndex)
            {
                // Return the lowest index of a page containing the given index. 
                return (rowIndex / RowsPerPage) * RowsPerPage;
            }

            private static int MapToUpperBoundary(int rowIndex)
            {
                // Return the highest index of a page containing the given index. 
                return MapToLowerBoundary(rowIndex) + RowsPerPage - 1;
            }
        }

        public DataCache(IDataPageRetriever dataSupplier, int rowsPerPage)
        {
            dataSupply = dataSupplier;
            DataCache.RowsPerPage = rowsPerPage;
            LoadFirstPage();
        }

        // Sets the value of the element parameter if the value is in the cache. 
        private bool IfPageCached_ThenSetElement(int rowIndex,
            int columnIndex, ref string element)
        {
            if (IsRowCachedInPage(0, rowIndex))
            {
                element = cachePages[0].table
                    .Rows[rowIndex % RowsPerPage][columnIndex].ToString();
                return true;
            }
            else if (IsRowCachedInPage(1, rowIndex))
            {
                element = cachePages[1].table
                    .Rows[rowIndex % RowsPerPage][columnIndex].ToString();
                return true;
            }

            return false;
        }

        private bool IfPageCached_ThenSetRow(int rowIndex, ref DataRow row)
        {
            try
            {
                if (IsRowCachedInPage(0, rowIndex))
                {
                    row = cachePages[0].table
                        .Rows[rowIndex % RowsPerPage];
                    return true;
                }
                else if (IsRowCachedInPage(1, rowIndex))
                {
                    row = cachePages[1].table
                        .Rows[rowIndex % RowsPerPage];
                    return true;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "Data Retrieval Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return false;
        }

        public string RetrieveElement(int rowIndex, int columnIndex)
        {
            string element = null;

            if (IfPageCached_ThenSetElement(rowIndex, columnIndex, ref element))
            {
                return element;
            }
            else
            {
                return RetrieveData_CacheIt_ThenReturnElement(
                    rowIndex, columnIndex);
            }
        }

        public DataRow RetrieveRow(int rowIndex)
        {
            DataRow row= null;

            if (IfPageCached_ThenSetRow(rowIndex, ref row))
            {
                return row;
            }
            else
            {
                return RetrieveData_CacheIt_ThenReturnRow(
                    rowIndex);
            }
        }

        private void LoadFirstPage()
        {
            cachePages = new DataPage[]{new DataPage(dataSupply.SupplyPageOfData(
            DataPage.MapToLowerBoundary(0), RowsPerPage), 0),
            new DataPage(dataSupply.SupplyPageOfData(
            DataPage.MapToLowerBoundary(0), RowsPerPage), 1)};
        }

        private string RetrieveData_CacheIt_ThenReturnElement(
            int rowIndex, int columnIndex)
        {
            // Retrieve a page worth of data containing the requested value.
            DataTable table = dataSupply.SupplyPageOfData(
                DataPage.MapToLowerBoundary(rowIndex), RowsPerPage);

            // Replace the cached page furthest from the requested cell 
            // with a new page containing the newly retrieved data.
            cachePages[GetIndexToUnusedPage(rowIndex)] = new DataPage(table, rowIndex);

            return RetrieveElement(rowIndex, columnIndex);
        }

        private DataRow RetrieveData_CacheIt_ThenReturnRow (int rowIndex)
        {
            // Retrieve a page worth of data containing the requested value.
            DataTable table = dataSupply.SupplyPageOfData(
                DataPage.MapToLowerBoundary(rowIndex), RowsPerPage);

            // Replace the cached page furthest from the requested cell 
            // with a new page containing the newly retrieved data.
            cachePages[GetIndexToUnusedPage(rowIndex)] = new DataPage(table, rowIndex);

            return RetrieveRow(rowIndex);
        }

        // Returns the index of the cached page most distant from the given index 
        // and therefore least likely to be reused. 
        private int GetIndexToUnusedPage(int rowIndex)
        {
            if (rowIndex > cachePages[0].HighestIndex &&
                rowIndex > cachePages[1].HighestIndex)
            {
                int offsetFromPage0 = rowIndex - cachePages[0].HighestIndex;
                int offsetFromPage1 = rowIndex - cachePages[1].HighestIndex;
                if (offsetFromPage0 < offsetFromPage1)
                {
                    return 1;
                }
                return 0;
            }
            else
            {
                int offsetFromPage0 = cachePages[0].LowestIndex - rowIndex;
                int offsetFromPage1 = cachePages[1].LowestIndex - rowIndex;
                if (offsetFromPage0 < offsetFromPage1)
                {
                    return 1;
                }
                return 0;
            }

        }

        // Returns a value indicating whether the given row index is contained 
        // in the given DataPage.  
        private bool IsRowCachedInPage(int pageNumber, int rowIndex)
        {
            return rowIndex <= cachePages[pageNumber].HighestIndex &&
                rowIndex >= cachePages[pageNumber].LowestIndex;
        }

    }

    public interface IDataPageRetriever
    {
        DataTable SupplyPageOfData(int lowerPageBoundary, int rowsPerPage);
    }

    public class DataRetriever : IDataPageRetriever
    {
        private string tableName;
        private NpgsqlCommand NpgsqlCMD;
        private string columnToSortBy;
        private NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
        private int rowCountValue = -1;
        private int ex_id = 0;
        private DataColumnCollection columnsValue;
        private string commaSeparatedListOfColumnNamesValue = null;
        private string selectWhere = "";

        public DataRetriever(string tableName, int Ex_ID)
        {
            using (NpgsqlCMD = new NpgsqlCommand())
            {
                NpgsqlCMD = GlobalVariables.Connection.CreateCommand();
                this.tableName = tableName;
                this.ex_id = Ex_ID;
            }
        }

        public string sWhere
        {
            get
            {
                return selectWhere;
            }

            set
            {
                selectWhere = value;
            }
        }

        public int RowCount
        {
            get
            {
                using (NpgsqlCMD = new NpgsqlCommand())
                {
                    if (GlobalVariables.GlobalConnection.checkForSQLInjection(selectWhere))
                        selectWhere = "";

                    // Retrieve the row count from the database.
                    NpgsqlCMD.CommandText = @"SELECT COUNT(1) 
                                          FROM fish_weight_length
                                          where ex_id = :id " +
                                              selectWhere;
                    NpgsqlCMD.Parameters.Clear();
                    NpgsqlCMD.Parameters.Add(new NpgsqlParameter("id", NpgsqlDbType.Integer));
                    NpgsqlCMD.Parameters[0].Value = ex_id;
                    rowCountValue = GlobalVariables.GlobalConnection.IntScalar(NpgsqlCMD);
                }
                return rowCountValue;
            }
        }

        public DataColumnCollection Columns
        {
            get
            {
                // Return the existing value if it has already been determined. 
                if (columnsValue != null)
                {
                    return columnsValue;
                }
                using (NpgsqlCMD = new NpgsqlCommand())
                {
                    // Retrieve the column information from the database.
                    NpgsqlCMD.CommandText = @"SELECT * 
                                          FROM fish_weight_length
                                          where ex_id = :id
                                          limit 1";
                    NpgsqlCMD.Parameters.Clear();
                    NpgsqlCMD.Parameters.Add(new NpgsqlParameter("id", NpgsqlDbType.Integer));
                    NpgsqlCMD.Parameters[0].Value = ex_id;
                    NpgsqlCMD.Connection = GlobalVariables.Connection;
                    adapter.SelectCommand = NpgsqlCMD;
                    DataTable table = new DataTable();
                    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    adapter.FillSchema(table, SchemaType.Source);
                    columnsValue = table.Columns;
                }
                return columnsValue;
            }
        }

        private string CommaSeparatedListOfColumnNames
        {
            get
            {
                // Return the existing value if it has already been determined. 
                if (commaSeparatedListOfColumnNamesValue != null)
                {
                    return commaSeparatedListOfColumnNamesValue;
                }

                // Store a list of column names for use in the 
                // SupplyPageOfData method.
                System.Text.StringBuilder commaSeparatedColumnNames =
                    new System.Text.StringBuilder();
                bool firstColumn = true;
                foreach (DataColumn column in Columns)
                {
                    if (!firstColumn)
                    {
                        commaSeparatedColumnNames.Append(", ");
                    }
                    commaSeparatedColumnNames.Append(column.ColumnName);
                    firstColumn = false;
                }

                commaSeparatedListOfColumnNamesValue =
                    commaSeparatedColumnNames.ToString();
                return commaSeparatedListOfColumnNamesValue;
            }
        }



        public DataTable SupplyPageOfData(int lowerPageBoundary, int rowsPerPage)
        {
            // Store the name of the ID column. This column must contain unique  
            // values so the SQL below will work properly. 
            if (columnToSortBy == null)
            {
                columnToSortBy = this.Columns[0].ColumnName;
            }

            if (!this.Columns[columnToSortBy].Unique)
            {
                throw new InvalidOperationException(String.Format(
                    "Column {0} must contain unique values.", columnToSortBy));
            }

            if (GlobalVariables.GlobalConnection.checkForSQLInjection(selectWhere))
                selectWhere = "";

            // Retrieve the specified number of rows from the database, starting 
            // with the row specified by the lowerPageBoundary parameter.
            DataTable table = new DataTable();
            NpgsqlCMD = new NpgsqlCommand();
                NpgsqlCMD.CommandText = @"Select t1.fi_id, t1.ex_id, t1.color, t1.tank_num, t1.fish_num, t1.wt_weight, t1.fish_length, 
                                      t1.week, to_char(info_date, 'MM/DD/YYYY') as info_date, t1.sex, t1.exclude_row, t1.identifier 
                                      From fish_weight_length t1
                                      WHERE t1.ex_id = :id "
                                          + selectWhere +
                                          @" Order By t1.fi_id
                                      Limit :rowsPage offset :lowerBoundary";
                NpgsqlCMD.Parameters.Clear();
                NpgsqlCMD.Parameters.Add(new NpgsqlParameter("rowsPage", NpgsqlDbType.Integer));
                NpgsqlCMD.Parameters[0].Value = rowsPerPage;
                NpgsqlCMD.Parameters.Add(new NpgsqlParameter("lowerBoundary", NpgsqlDbType.Integer));
                NpgsqlCMD.Parameters[1].Value = lowerPageBoundary;
                NpgsqlCMD.Parameters.Add(new NpgsqlParameter("id", NpgsqlDbType.Integer));
                NpgsqlCMD.Parameters[2].Value = ex_id;
                adapter.SelectCommand = NpgsqlCMD;
                string theQuery = NpgsqlCMD.CommandText.ToString();
                theQuery = theQuery.Replace(":id", NpgsqlCMD.Parameters[2].Value.ToString());
                theQuery = theQuery.Replace("Limit :rowsPage offset :lowerBoundary", "");
                theQuery = theQuery.Replace("Order By t1.fi_id", "Order By t1.color");
                
                DataTable testTable = new DataTable();
                table = GlobalVariables.GlobalConnection.readDataTable(NpgsqlCMD);
                GlobalVariables.StatsQuery = theQuery;
            
            return table;
        }
    }
 }
