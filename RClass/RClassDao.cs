using System;
using System.Linq;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

namespace RClass
{
    class RClassDao
    {
        private DataSet ds = new DataSet();
        private NpgsqlCommand NpgsqlCMD;
        private NpgsqlDataAdapter adapter;
        private int rowCountValue = -1;
        public static string dbUser = "";
        public static string dbPass = "";
        static NpgsqlConnection con;

        public static NpgsqlConnection Connection
        {
            get { return conn(); }
        }

        public RClassDao()
        {
        }

        public RClassDao(string DBUser, string DBPass)
        {
            // TODO: Complete member initialization
            dbUser = DBUser;
            dbPass = DBPass;
        }

        public List<AnimalData> BulkExportData(int exID)
        {
            AnimalData animal;
            List<AnimalData> animalAgg = new List<AnimalData>();

            if (Connection != null)
                Connection.Close();
            NpgsqlConnection con = Connection;
            using (var reader = con.BeginBinaryExport
                (@"COPY (SELECT ED.EXPERIMENT_DATA_ID, ED.EXCLUDE_ROW, ED.DATA_AGG
                         FROM EXPERIMENT_DATA ED 
                         WHERE ED.EX_ID = " + exID + @"
                        order by experiment_data_id asc) 
                        TO STDOUT (FORMAT BINARY)"))
            {
                while (reader.StartRow() != -1)
                {
                    animal = new AnimalData();
                    animal.DataID = reader.Read<int>(NpgsqlDbType.Integer);
                    animal.ExcludeRow = reader.Read<string>(NpgsqlDbType.Varchar);
                    animal.DataAgg = reader.Read<string>(NpgsqlDbType.Text);
                    animal.ExID = exID;
                    animal.GetAggData();
                    animalAgg.Add(animal);

                }
            }
            return animalAgg;
        }

        public List<CustomColumns> GetColumns(int exID)
        {
            CustomColumns col;
            List<CustomColumns> colAgg = new List<CustomColumns>();
            Connection.Close();
            NpgsqlConnection con = Connection;
            using (var reader = con.BeginBinaryExport
                (@"COPY (SELECT CUSTOM_COLUMNS_ID, CUSTOM_COLUMN_NAME, CUSTOM_COLUMN_DATA_TYPE
                        FROM EXPERIMENT_CUSTOM_COLUMNS WHERE EX_ID = " + exID + @") 
                        TO STDOUT (FORMAT BINARY)"))
            {
                while (reader.StartRow() != -1)
                {
                    col = new CustomColumns();
                    col.ColID = reader.Read<int>(NpgsqlDbType.Integer);
                    col.ColName = reader.Read<string>(NpgsqlDbType.Varchar);
                    col.ColDataType = reader.Read<string>(NpgsqlDbType.Varchar);
                    col.EX_ID = exID;

                    colAgg.Add(col);
                }
            }
            return colAgg;
        }

        public DataSet getExperiments(string sUserName)
        {
            try
            {
                NpgsqlCMD = new NpgsqlCommand();
                NpgsqlCMD.CommandText = @"Select ex.ex_id, ex.ex_alias, ex.ex_title, ex.ex_sdate,
                                      ex.ex_edate, ex.ex_hypothesis, 
                                      ea.access_type as Permissions 
                                      from experiments ex, experiment_access ea
                                      where upper(ea.user_name) = :user_name
                                      and ex.ex_id = ea.ex_id
                                      order by ex.ex_id";

                NpgsqlCMD.Parameters.Add(new NpgsqlParameter("user_name", NpgsqlDbType.Varchar));
                NpgsqlCMD.Parameters[0].Value = sUserName.ToUpper();
                DataSet ds = new DataSet();
                ds = readData(NpgsqlCMD);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                    return null;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "Stupid Error", MessageBoxButtons.OK);
                return null;
            }
        }

        private static NpgsqlConnection conn()
        {
            if (con == null)
            {
                con = new NpgsqlConnection(RClass.Properties.Settings.Default.MyPostgress +
                                          @";Port=5432;
                                        User Id=" + dbUser + @";
                                        Password=" + dbPass + @";
                                        Database=BiologyProject;
                                        Pooling=false;
                                        CommandTimeout=300;
                                        Connection Lifetime=0");
            }
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            return con;
        }

        public DataSet readData(NpgsqlCommand cmd)
        {
            string sMessage = "";
            try
            {
                DataSet ds = new DataSet();
                using (cmd)
                {
                    Connection.Close();
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                    {
                        adapter.SelectCommand.Connection = Connection;
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

        public void SetUserPass(string DBUser, string DBPass)
        {
            dbUser = DBUser;
            dbPass = DBPass;
        }
    }
}
