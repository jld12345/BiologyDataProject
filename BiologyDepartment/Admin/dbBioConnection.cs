using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BiologyDepartment
{
    public class dbBioConnection
    {

        private string sUserName = "";
        private string sPWord = "";
        private string sDSource = "";
        private string sDBVar = "";
        private string sSQL = "";
        public string PostgresDB = "";//"Server=127.0.0.1;Port=5432;User Id=biologyprojectadmin;Password=ImWay2c@@l;Database=BiologyProject;";
        private string sMessage = "";
        private string[] sqlCheckList = { "--", ";--", ";", "/*", "*/", "@@", "@", "char", "nchar",
                                          "varchar", "nvarchar", "alter", "begin", "cast", "create",
                                          "cursor","declare", "delete", "drop", "end", "exec", "execute",
                                          "fetch", "insert", "kill", "select", "sys", "sysobjects",
                                          "syscolumns", "table", "update"
                                        };
        public dbBioConnection()
        {
            dbUser = GlobalVariables.dbUser;
            dbpword = GlobalVariables.dbPass;
            dbDataSource = GlobalVariables.DataSource;
            PostgresDB = sDSource + sUserName + sPWord;
        }

        public string dbUser
        {
           set {sUserName = "User Id=" + value + ";";}
        }
        public string dbpword
        {
            set { sPWord = "Password=" + value + ";"; }
        }
        public string dbDataSource
        {
            set { sDSource = value; }
        }
        public string dbSetSQL
        {
            set { sSQL = value; }
        }

        public int IntScalar(NpgsqlCommand cmd)
        {
            try
            {
                int dataset = 0;
                using (cmd)
                {
                    cmd.Connection = GlobalVariables.Connection;
                    dataset = Convert.ToInt32(cmd.ExecuteScalar());
                }
                return dataset;
            }
            catch (NpgsqlException e)
            {
                sMessage = e.ToString();
                MessageBox.Show(sMessage.ToString());
                return 0;
            }
            catch (Exception e)
            {
                sMessage = e.ToString();
                MessageBox.Show(sMessage.ToString());
                return 0;
            }
        }

        public DataSet readData(NpgsqlCommand cmd)
        {
            try
            {
                DataSet ds = new DataSet();
                using (cmd)
                {
                    cmd.Connection = GlobalVariables.Connection;
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                    {
                        adapter.Fill(ds);
                    }
                }
                return ds;
            }
            catch (NpgsqlException e)
            {
                sMessage = e.ToString();
                MessageBox.Show(sMessage.ToString());
                return null;
            }
            catch (Exception e)
            {
                sMessage = e.ToString();
                MessageBox.Show(sMessage.ToString());
                return null;
            }
        }

        public DataTable readDataTable(NpgsqlCommand cmd)
        {
            try
            {
                DataSet ds = new DataSet();
                GlobalVariables.Connection.Close();
                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                {
                    adapter.SelectCommand.Connection = GlobalVariables.Connection;
                    adapter.SelectCommand.CommandText = cmd.CommandText;
                    adapter.Fill(ds);
                }
                
                return ds.Tables[0];
            }
            catch (NpgsqlException e)
            {
                sMessage = e.ToString();
                MessageBox.Show(sMessage.ToString());
                return null;
            }
            catch (Exception e)
            {
                sMessage = e.ToString();
                MessageBox.Show(sMessage.ToString());
                return null;
            }
        }

        public bool insertData(NpgsqlCommand cmd)
        {
            try
            {
                using (cmd)
                {
                    cmd.Connection = GlobalVariables.Connection;
                    cmd.ExecuteNonQuery();
                }
                return true;

            }
            catch(Exception)
            {
                return false;
            }
        }

        public int InsertDataAndGetID(NpgsqlCommand cmd)
        {
            try
            {
                int nReturn = 0;
                using (cmd)
                {
                    cmd.Connection = GlobalVariables.Connection;
                    nReturn = Convert.ToInt32(cmd.ExecuteScalar());
                }
                return nReturn;

            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool updateData(NpgsqlCommand cmd)
        {
            try
            {
                using (cmd)
                {
                    cmd.Connection = GlobalVariables.Connection;
                    cmd.ExecuteNonQuery();
                }
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public void UpdateFromDataGridView(DataTable dataSource, string sSelect)
        {
            DataTable dt = new DataTable();
            using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(sSelect, GlobalVariables.Connection))
            {
                GlobalVariables.Connection.Open();
                adapter.Fill(dt);
                dt = dataSource.Copy();
                adapter.Update(dt);
            }
        }

        public bool deleteData(NpgsqlCommand cmd)
        {
            try
            {
                using (cmd)
                {
                    cmd.Connection = GlobalVariables.Connection;
                    cmd.ExecuteNonQuery();
                }
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool checkForSQLInjection(string userInput)
        {
            if (string.IsNullOrEmpty(userInput))
                return false;

            string CheckString = userInput.Replace("'", "''");

            for (int i = 0; i <= sqlCheckList.Length - 1; i++)
            {
                if ((CheckString.IndexOf(sqlCheckList[i], StringComparison.OrdinalIgnoreCase) >= 0))
                    return true;
            }

            return false;
        }

        public void BulkInsertData(List<string> ImportRows)
        {
            NpgsqlConnection con = GlobalVariables.Connection;
            using (var writer = con.BeginBinaryImport
                (@"COPY EXPERIMENT_DATA 
                    (EX_ID, MODIFIED_DATE, MODIFIED_USER, DATA_AGG) 
                     FROM STDIN (FORMAT BINARY)"))
            {
                foreach (string row in ImportRows)
                {
                    writer.StartRow();
                    writer.Write(GlobalVariables.Experiment.ID, NpgsqlDbType.Integer);
                    writer.Write(DateTime.Now.ToLongDateString(), NpgsqlDbType.Timestamp);
                    writer.Write(GlobalVariables.ADUserName, NpgsqlDbType.Varchar);
                    writer.Write(row, NpgsqlDbType.Varchar);
                }
            }
            
        }

        public List<AnimalData> BulkExportData()
        {
            AnimalData animal;
            List<AnimalData> animalAgg = new List<AnimalData>();

            GlobalVariables.Connection.Close();
            NpgsqlConnection con = GlobalVariables.Connection;
            using (var reader = con.BeginBinaryExport
                (@"COPY (SELECT EXPERIMENT_DATA_ID, EXCLUDE_ROW, DATA_AGG
                        FROM EXPERIMENT_DATA WHERE EX_ID = " + GlobalVariables.Experiment.ID + @"
                        order by experiment_data_id asc) 
                        TO STDOUT (FORMAT BINARY)"))
            {
                while(reader.StartRow() != -1)
                {
                    animal = new AnimalData();
                    animal.DataID = reader.Read<int>(NpgsqlDbType.Integer);
                    animal.ExcludeRow = reader.Read<string>(NpgsqlDbType.Varchar);
                    animal.DataAgg = reader.Read<string>(NpgsqlDbType.Text);
                    animal.ExID = GlobalVariables.Experiment.ID;
                    animal.GetAggData();
                    animalAgg.Add(animal);

                }
            }
            return animalAgg;
        }

        public List<CustomColumns> GetColumns()
        {
            CustomColumns col;
            List<CustomColumns> colAgg = new List<CustomColumns>();
            GlobalVariables.Connection.Close();
            NpgsqlConnection con = GlobalVariables.Connection;
            using (var reader = con.BeginBinaryExport
                (@"COPY (SELECT CUSTOM_COLUMNS_ID, CUSTOM_COLUMN_NAME, CUSTOM_COLUMN_DATA_TYPE
                        FROM EXPERIMENT_CUSTOM_COLUMNS WHERE EX_ID = " + GlobalVariables.Experiment.ID + @") 
                        TO STDOUT (FORMAT BINARY)"))
            {
                while (reader.StartRow() != -1)
                {
                    col = new CustomColumns();
                    col.ColID = reader.Read<int>(NpgsqlDbType.Integer);
                    col.ColName = reader.Read<string>(NpgsqlDbType.Varchar);
                    col.ColDataType = reader.Read<string>(NpgsqlDbType.Varchar);
                    col.EX_ID = GlobalVariables.Experiment.ID;

                    colAgg.Add(col);
                }
            }
            return colAgg;
        }
    }
}
