using System;
using System.Linq;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

namespace BiologyDepartment
{
    class daoData
    {
        private DataSet ds = new DataSet();
        private NpgsqlCommand NpgsqlCMD;
        private NpgsqlDataAdapter adapter;
        private int rowCountValue = -1;

        public daoData()
        {
        }

        public List<AnimalData> BulkExport()
        {
            List<AnimalData> theData = GlobalVariables.GlobalConnection.BulkExportData();
            return theData;
        }

        public List<CustomColumns> GetColumns()
        {
            List<CustomColumns> theData = GlobalVariables.GlobalConnection.GetColumns();
            return theData;
        }

        public DataSet getExData(int id)
        {
            NpgsqlCMD = new NpgsqlCommand();
            NpgsqlCMD.CommandText = @"select 
	                                    ecc.ex_core_col_id, 
	                                    ecc.ex_id, 
	                                    ecc.modified_date, 
	                                    ecc.exclude_row, 
	                                    ecc.modified_date,
	                                    (select string_agg(ed.data_agg, ';' order by ed.ex_core_col_id) from experiment_data ed
	                                    where ecc.ex_core_col_id = ed.ex_core_col_id)
                                    from experiment_core_columns ecc, experiment_data ed
                                    where ecc.ex_id = :id
                                    and ecc.deleted_date is null";
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("id", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters[0].Value = id;
            ds = new DataSet();
            ds = GlobalVariables.GlobalConnection.readData(NpgsqlCMD);
            if (ds != null)
            {
                return ds;
            }
            else
                return null;
        }

        public void UpdateCore(int nExID, int nCoreID, string sExcludeRow)
        {
            string sName = GlobalVariables.ADUserName;
            NpgsqlCMD = new NpgsqlCommand();

            NpgsqlCMD.CommandText = @"  update experiment_core_columns
                                        set ex_id = :ex,
	                                        modified_date = now(),
	                                        modified_user = :mod_user,
	                                        exclude_row = :exclude_row,
                                        where ex_core_col_id = :core_id";

            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("ex", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("mod_user", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("exclude_row", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("core_id", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters[0].Value = nExID;
            NpgsqlCMD.Parameters[1].Value = sName;
            NpgsqlCMD.Parameters[2].Value = sExcludeRow;
            NpgsqlCMD.Parameters[3].Value = nCoreID;

        }

        public void UpdateExperimentData(int nCustomID, int nCoreID, string sColumnData)
        {
            NpgsqlCMD = new NpgsqlCommand();

            NpgsqlCMD.CommandText = @"  update experiment_data
                                        set custom_column_data = :col_data,
	                                        data_agg = :data_agg
                                        where ex_core_id = :core_id
                                        and custom_columns_id = :custom_id";

            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("custom_id", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("col_data", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("data_agg", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("core_id", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters[0].Value = nCustomID;
            NpgsqlCMD.Parameters[1].Value = sColumnData;
            NpgsqlCMD.Parameters[2].Value = nCoreID.ToString() + "|" + nCustomID.ToString() + "|" + sColumnData;
            NpgsqlCMD.Parameters[3].Value = nCoreID;

        }


        public void InsertPic(string TableName, int FishID, byte[] pic)
        {
            NpgsqlCMD = new NpgsqlCommand();
      
            NpgsqlCMD.CommandText = @"DELETE FROM data_pictures
                                      where table_name = :tName
                                      and table_primary_key = :tPK;
                                      INSERT INTO data_pictures 
                                      (table_name, table_primary_key, data_picture)
                                      VALUES(:tName, :tPK, :pic)";

            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("tName", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("tPK", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("pic", NpgsqlDbType.Bytea));
            NpgsqlCMD.Parameters[0].Value = TableName;
            NpgsqlCMD.Parameters[1].Value = FishID;
            NpgsqlCMD.Parameters[2].Value = pic;


            if(GlobalVariables.GlobalConnection.insertData(NpgsqlCMD))
                MessageBox.Show("Picture successfully inserted.", "Picture Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error inserting picture.", "Insert Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void UpdatePic(string TableName, int FishID, byte[] pic)
        {
            NpgsqlCMD = new NpgsqlCommand();

            NpgsqlCMD.CommandText = @"UPDATE data_pictures
                                      set data_picture = :pic
                                      where table_name = :tName
                                      and table_primary_key = :tPK";
                                      

            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("tName", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("tPK", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("pic", NpgsqlDbType.Bytea));
            NpgsqlCMD.Parameters[0].Value = TableName;
            NpgsqlCMD.Parameters[1].Value = FishID;
            NpgsqlCMD.Parameters[2].Value = pic;


            if (GlobalVariables.GlobalConnection.updateData(NpgsqlCMD))
                MessageBox.Show("Picture successfully inserted.", "Picture Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error inserting picture.", "Insert Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void UpdateDeleteRow(int nCoreID)
        {
            NpgsqlCMD = new NpgsqlCommand();
            string sName = GlobalVariables.ADUserName;

            NpgsqlCMD.CommandText = @"Update experiment_data
                                    set deleted_user = :mUser,
                                    deleted_date = now()
                                    Where experiment_data_id = :therow";

            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("mUser", sName));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("therow", nCoreID));
            NpgsqlCMD.Parameters[0].Value = sName;
            NpgsqlCMD.Parameters[1].Value = nCoreID;
            GlobalVariables.GlobalConnection.updateData(NpgsqlCMD);

        }

        public void UpdateExperimentData(AnimalData theAnimal)
        {
            NpgsqlCMD = new NpgsqlCommand();

            NpgsqlCMD.CommandText = @"  update experiment_data
                                        set ex_id = :exid,
                                            modified_user = :mod_user,
                                            modified_date = :mod_date,
                                            exclude_row = :exclude,
	                                        data_agg = :data_agg
                                        where experiment_data_id = :rowID";

            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("exid", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("mod_user", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("data_agg", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("exclude", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("mod_date", NpgsqlDbType.Timestamp));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("rowID", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters[0].Value = GlobalVariables.Experiment.ID;
            NpgsqlCMD.Parameters[1].Value = theAnimal.ModUser;
            NpgsqlCMD.Parameters[3].Value = theAnimal.ExcludeRow;
            NpgsqlCMD.Parameters[2].Value = theAnimal.DataAgg;
            NpgsqlCMD.Parameters[4].Value = DateTime.Now.ToLongDateString();
            NpgsqlCMD.Parameters[5].Value = theAnimal.DataID;
            GlobalVariables.GlobalConnection.updateData(NpgsqlCMD);
        }

        public NpgsqlDataAdapter DataAdapterCustom(int intID)
        {
            string selectCommand = @"select 
	                                 ecc.custom_columns_id, 
	                                 ecc.custom_column_name,
                                     ecc.custom_column_data_type
                                    from experiment_custom_columns ecc
                                    where ecc.ex_id = :id";
            adapter = new Npgsql.NpgsqlDataAdapter(selectCommand, GlobalVariables.Connection);
            NpgsqlCommandBuilder commandBuilder = new NpgsqlCommandBuilder(adapter);
            adapter.SelectCommand.Parameters.Add(new NpgsqlParameter("id", NpgsqlDbType.Integer));
            adapter.SelectCommand.Parameters[0].Value = intID;
            return adapter;
        }

    }
}
