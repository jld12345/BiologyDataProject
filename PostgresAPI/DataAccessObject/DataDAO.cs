using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using Npgsql;
using NpgsqlTypes;
using BiologyDepartmentModels;
using Newtonsoft.Json;

namespace PostgresAPI.DataAccessObject
{
    public class DataDAO
    {
        public NpgsqlConnection Connection = new NpgsqlConnection("Host=dwbtechnologies.ddns.net;Port=5432;Username=biologyprojectadmin;Password=ImWay2c@@l;Database=BiologyProject;Pooling=False;Command Timeout=300;");

        private void VerifyConnection()
        {
            if (Connection == null)
            {
                Connection = new NpgsqlConnection(PostgresAPI.Properties.Settings.Default.ConnectionString);
            }
            if (Connection.State != System.Data.ConnectionState.Open)
                Connection.Open();
        }
        public Experiment BulkExportJSON(int Ex_ID)
        {
            try
            {
                Experiment exJSON = new Experiment();
                if (Connection != null)
                    Connection.Close();
                VerifyConnection();

                using (var reader = Connection.BeginBinaryExport
                    (@"COPY (SELECT je.EX_ID, je.JSON_ID, je.JSON_DATA, je.JSONB_DATA
                         FROM json_experiments je
                         WHERE je.EX_ID = " + Ex_ID + @"
                        order by json_id desc
                        limit 1) 
                        TO STDOUT (FORMAT BINARY)"))
                {
                    while (reader.StartRow() != -1)
                    {
                        exJSON.ExperimentID = reader.Read<int>(NpgsqlDbType.Integer);
                        exJSON.JSON_ID = reader.Read<int>(NpgsqlDbType.Integer);
                        exJSON.JSON = reader.Read<string>(NpgsqlDbType.Json);
                        exJSON.JSONB = reader.Read<string>(NpgsqlDbType.Jsonb);
                    }
                }
                exJSON.JsonDS = JsonConvert.DeserializeObject < DataSet >(exJSON.JSONB);
                return exJSON;
            }
            catch(Exception e)
            {
                Connection.Close();
                return null;
            }
        }

        public static string stripNonValidXMLCharacters(string textIn)
        {
            if (String.IsNullOrEmpty(textIn))
                return textIn;

            StringBuilder textOut = new StringBuilder(textIn.Length);

            foreach (Char current in textIn)
                if ((current == 0x9 || current == 0xA || current == 0xB || current == 0xD) ||
                   ((current >= 0x20) && (current <= 0xD7FF)) ||
                   ((current >= 0xE000) && (current <= 0xFFFD)) ||
                   ((current >= 0x10000) && (current <= 0x10FFFF)))
                    textOut.Append(current);

            return textOut.ToString();
        }
        
    }
}