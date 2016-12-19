using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using Npgsql;
using NpgsqlTypes;
using PostgresAPI.Models;
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
        public Experiment BulkExportData(int ExperimentID)
        {
            Experiment data = new Experiment();

            if (Connection != null)
                Connection.Close();
            VerifyConnection();

            using (var reader = Connection.BeginBinaryExport
                (@"COPY (select ex.ex_alias ShortName, ex.ex_title FullName, to_char(ex.ex_sdate, 'MM-DD-YYYY') StartDate,
                            to_char(ex.ex_edate, 'MM-DD-YYYY') EndDate, ex.ex_hypothesis Notes, 
                            case  
                                when ex.ex_parent_id is null then ex.ex_id
                                when ex.ex_parent_id = 0 then ex.ex_id
                                else ex.ex_parent_id
                            end as ParentExperiment, 
                            to_jsonb((select json_agg(experiments_jsonb) 
                                    from experiments_jsonb
                                    where experiments_id = " + Convert.ToInt32(ExperimentID) + @"
                                    and deleted_date is null)) JSON
                            from experiments ex
                            where ex.ex_id = " + Convert.ToInt32(ExperimentID) + @"
                            ) 
                        TO STDOUT (FORMAT BINARY)"))
            {
                while (reader.StartRow() != -1)
                {
                    data.ShortName = reader.Read<string>(NpgsqlDbType.Text);
                    data.FullName = reader.Read<string>(NpgsqlDbType.Text);
                    data.StartDate = reader.Read<string>(NpgsqlDbType.Text);
                    data.EndDate = reader.Read<string>(NpgsqlDbType.Text);
                    data.Notes = reader.Read<string>(NpgsqlDbType.Text);
                    data.ParentExperiment = reader.Read<int>(NpgsqlDbType.Integer);
                    data.JSON = reader.Read<string>(NpgsqlDbType.Jsonb);
                }
            }
            if (data != null)
                data.DeSerializeJsonToDataTable();

            return data;
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