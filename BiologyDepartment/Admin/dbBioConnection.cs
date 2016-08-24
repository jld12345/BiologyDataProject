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
using BiologyDepartment.ExperimentDocuments;

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
            PostgresDB = "Server=192.168.0.9;Port=5432;User Id=biologyprojectadmin;Password=ImWay2c@@l;Database=BiologyProject;";//sDSource + sUserName + sPWord;
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
                    if (GlobalVariables.Connection != null)
                        GlobalVariables.Connection.Close();
                    NpgsqlConnection con = GlobalVariables.Connection;
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                    {
                        adapter.SelectCommand.Connection = con;
                        adapter.SelectCommand.CommandText = cmd.CommandText;
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
                if (GlobalVariables.Connection != null)
                    GlobalVariables.Connection.Close();
                NpgsqlConnection con = GlobalVariables.Connection;
                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                {
                    adapter.SelectCommand.Connection = con;
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
                    if (GlobalVariables.Connection != null)
                        GlobalVariables.Connection.Close();
                    NpgsqlConnection con = GlobalVariables.Connection;
                    cmd.Connection = con;
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
                    if (GlobalVariables.Connection != null)
                        GlobalVariables.Connection.Close();
                    NpgsqlConnection con = GlobalVariables.Connection;
                    cmd.Connection = con;
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
                    if (GlobalVariables.Connection != null)
                        GlobalVariables.Connection.Close();
                    NpgsqlConnection con = GlobalVariables.Connection;
                    cmd.Connection = con;
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
            if (GlobalVariables.Connection != null)
                GlobalVariables.Connection.Close();
            NpgsqlConnection con = GlobalVariables.Connection;
            using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(sSelect, con))
            {
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
                    if (GlobalVariables.Connection != null)
                        GlobalVariables.Connection.Close();
                    NpgsqlConnection con = GlobalVariables.Connection;
                    cmd.Connection = con;
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
            if (GlobalVariables.Connection != null)
                GlobalVariables.Connection.Close();
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

        public void BulkInsertJSON(string sJson, string theXML)
        {
            if (GlobalVariables.Connection != null)
                GlobalVariables.Connection.Close();
            NpgsqlConnection con = GlobalVariables.Connection;
            using (var writer = con.BeginBinaryImport
                (@"COPY JSON_EXPERIMENTS
                    (EX_ID, JSON_DATA, JSONB_DATA, EX_XML, EX_DATA) 
                     FROM STDIN (FORMAT BINARY)"))
            {
                    writer.StartRow();
                    writer.Write(GlobalVariables.Experiment.ID, NpgsqlDbType.Integer);
                    writer.Write(sJson, NpgsqlDbType.Json);
                    writer.Write(sJson, NpgsqlDbType.Jsonb);
                    writer.Write(theXML, NpgsqlDbType.Xml);
                    writer.Write(theXML, NpgsqlDbType.Text);
            }

        }

        public List<AnimalData> BulkExportData()
        {
            AnimalData animal;
            List<AnimalData> animalAgg = new List<AnimalData>();

            if(GlobalVariables.Connection != null)
                GlobalVariables.Connection.Close();
            NpgsqlConnection con = GlobalVariables.Connection;
            using (var reader = con.BeginBinaryExport
                (@"COPY (SELECT ED.EXPERIMENT_DATA_ID, ED.EXCLUDE_ROW, ED.DATA_AGG, 
                        (SELECT DP.DATA_PICTURE FROM DATA_PICTURES DP
                         WHERE DP.TABLE_NAME = 'EXPERIMENT_DATA'
                         AND DP.TABLE_PRIMARY_KEY = ED.EXPERIMENT_DATA_ID) DATA_PICTURE
                         FROM EXPERIMENT_DATA ED 
                         WHERE ED.EX_ID = " + GlobalVariables.Experiment.ID + @"
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
                    if (!reader.IsNull)
                        animal.Picture = reader.Read<byte[]>(NpgsqlDbType.Bytea);
                    else
                        reader.Skip();
                    animalAgg.Add(animal);

                }
            }
            return animalAgg;
        }

        public List<CustomColumns> GetColumns()
        {
            CustomColumns col;
            List<CustomColumns> colAgg = new List<CustomColumns>();
            if (GlobalVariables.Connection != null)
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
                col = new CustomColumns();
                col.ColID = 1;
                col.ColName = "Data Picture";
                col.ColDataType = "Byte[]";
                col.EX_ID = GlobalVariables.Experiment.ID;
                colAgg.Add(col);
            }
            return colAgg;
        }

        public string BulkExportJSON()
        {
            string sJson = "";
            if (GlobalVariables.Connection != null)
                GlobalVariables.Connection.Close();
            NpgsqlConnection con = GlobalVariables.Connection;
            using (var reader = con.BeginBinaryExport
                (@"COPY (SELECT je.json_data
                         FROM json_experiments je
                         WHERE je.EX_ID = " + GlobalVariables.Experiment.ID + @"
                        order by json_id desc
                        limit 1) 
                        TO STDOUT (FORMAT BINARY)"))
            {
                while (reader.StartRow() != -1)
                {
                    sJson = reader.Read<string>(NpgsqlDbType.Json);
                }
            }
            return sJson;
        }

        public List<PDFClass> BulkExportPDF()
        {
            PDFClass thePDF;
            List<PDFClass> lstPDF = new List<PDFClass>();

            if (GlobalVariables.Connection != null)
                GlobalVariables.Connection.Close();
            NpgsqlConnection con = GlobalVariables.Connection;

            using (var reader = con.BeginBinaryExport
                (@"COPY (SELECT PDF.EXPERIMENT_PDF_ID, PDF.EXPERIMENT_PDF_TITLE, PDF.EXPERIMENT_PDF_DESCRIPTION,
                         PDF.EXPERIMENT_PDF 
                         FROM EXPERIMENT_PDF PDF
                         WHERE PDF.EXPERIMENT_ID = " + GlobalVariables.Experiment.ID + @"
                        order by PDF.EXPERIMENT_PDF_ID asc) 
                        TO STDOUT (FORMAT BINARY)"))
            {
                while (reader.StartRow() != -1)
                {
                    thePDF = new PDFClass();
                    thePDF.EXPERIMENT_PDF_ID = reader.Read<int>(NpgsqlDbType.Integer);
                    thePDF.EXPERIMENT_PDF_TITLE = reader.Read<string>(NpgsqlDbType.Varchar);
                    thePDF.EXPERIMENT_PDF_DESCRIPTION = reader.Read<string>(NpgsqlDbType.Text);
                    thePDF.EXPERIMENT_ID = GlobalVariables.Experiment.ID;
                    if (!reader.IsNull)
                        thePDF.EXPERIMENT_PDF = reader.Read<byte[]>(NpgsqlDbType.Bytea);
                    else
                        reader.Skip();
                    lstPDF.Add(thePDF);

                }
            }
            return lstPDF;
        }
    }
}
