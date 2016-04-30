using System;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using System.Windows.Forms;

namespace BiologyDepartment
{
    public class daoExperiments
    {
        private daoEXPermissions daoPermissions;
        private DataSet dsExper = new DataSet();
        private NpgsqlCommand NpgsqlCMD;
   
        public daoExperiments()
        {
            daoPermissions = new daoEXPermissions();
        }

        public DataSet getExperiments()
        {
            NpgsqlCMD = new NpgsqlCommand();
            NpgsqlCMD.CommandText = @"Select ex.*, ea.access_type as Permissions 
                                   from experiments ex, experiment_access ea
                                   where upper(ea.user_name) = :user_name
                                   and ex.ex_id = ea.ex_id
                                   and ex.ex_parent_id is null
                                   order by ex.ex_id";

            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("user_name", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters[0].Value = GlobalVariables.ADUserName.ToUpper();
            DataSet ds = new DataSet();
            ds = GlobalVariables.GlobalConnection.readData(NpgsqlCMD);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
                return null;
        }

        public DataTable getChildExpirements(string sExperimentIds)
        {
            DataTable dt = new DataTable();
            NpgsqlCMD = new NpgsqlCommand();
            NpgsqlCMD.CommandText = @"Select ex.*, ea.access_type as Permissions 
                                   from experiments ex, experiment_access ea
                                   where upper(ea.user_name) = :user_name
                                   and ex.ex_id = ea.ex_id
                                   and ex.ex_parent_id is not null
                                   and ex.ex_parent_id in :experiments
                                   order by ex.ex_id";
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("user_name", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters[0].Value = GlobalVariables.ADUserName.ToUpper();
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("experiments", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters[1].Value = "(" + sExperimentIds + ")";

            dt = GlobalVariables.GlobalConnection.readDataTable(NpgsqlCMD);
            return dt;
        }

        public DataSet getRecord(int rec)
        {
            NpgsqlCMD = new NpgsqlCommand();
            NpgsqlCMD.CommandText = "Select * from experiments Where EX_ID = :rec";
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("rec", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters[0].Value = rec;

            DataSet ds = new DataSet();
            ds = GlobalVariables.GlobalConnection.readData(NpgsqlCMD);
            if (ds != null)
            {
                return ds;
            }
            else
                return null;
        }

        public int insertRecord(Experiments e, bool bIsUnitTest)
        {
            int id = 0;
            NpgsqlCMD = new NpgsqlCommand();
            NpgsqlCMD.CommandText = @"
                                   Insert into experiments (EX_ID, EX_ALIAS, EX_TITLE, EX_SDATE, EX_EDATE, EX_HYPOTHESIS) 
                                   VALUES (nextval('experiments_id_seq'), :alias, :title, :sdate, :edate,:hypo,:parent)
                                   returning ex_id
                                   ";

            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("alias", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("title", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("sdate", NpgsqlDbType.Date));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("edate", NpgsqlDbType.Date));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("hypo", NpgsqlDbType.Text));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("parent", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters[0].Value = e.Alias;
            NpgsqlCMD.Parameters[1].Value = e.Title;
            NpgsqlCMD.Parameters[2].Value = Convert.ToDateTime(e.SDate);
            NpgsqlCMD.Parameters[3].Value = Convert.ToDateTime(e.EDate);
            NpgsqlCMD.Parameters[4].Value = e.Hypo;
            if (e.ParentEx > 0)
                NpgsqlCMD.Parameters[5].Value = e.ParentEx;
            else
                NpgsqlCMD.Parameters[5].Value = null;

            NpgsqlParameter ExIDOutput = new NpgsqlParameter("id", NpgsqlDbType.Integer);
            ExIDOutput.Direction = ParameterDirection.Output;
            NpgsqlCMD.Parameters.Add(ExIDOutput);

            id = GlobalVariables.GlobalConnection.InsertDataAndGetID(NpgsqlCMD);

            if (id <= 0)
            {
                if(!bIsUnitTest)
                    MessageBox.Show("Error inserting experiment.", "Insert Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            else if(!bIsUnitTest)
                MessageBox.Show("Experiment successfully inserted.", "Picture Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);


            if (!bIsUnitTest)
            {
                if (GlobalVariables.ADUserName.Equals("James"))
                    daoPermissions.insertPermissions(id, GlobalVariables.ADUserName, "Owner");
                else
                {
                    daoPermissions.insertPermissions(id, GlobalVariables.ADUserName, "Owner");
                    daoPermissions.insertPermissions(id, "James", "Admin");
                }
            }
            return id;
        }

        public void updateRecord(Experiments e, bool bIsUnitTest)
        { 
            NpgsqlCMD = new NpgsqlCommand();
            NpgsqlCMD.CommandText = @"Update experiments 
                              Set EX_ALIAS = :alias, 
                              EX_TITLE  = :title,
                              EX_SDATE  = :sdate,
                              EX_EDATE  = :edate,
                              EX_HYPOTHESIS  = :hypo
                              Where EX_ID = :exID";

            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("alias", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("title", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("sdate", NpgsqlDbType.Date));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("edate", NpgsqlDbType.Date));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("hypo", NpgsqlDbType.Text));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("exID", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters[0].Value = e.Alias;
            NpgsqlCMD.Parameters[1].Value = e.Title;
            NpgsqlCMD.Parameters[2].Value = Convert.ToDateTime(e.SDate);
            NpgsqlCMD.Parameters[3].Value = Convert.ToDateTime(e.EDate);
            NpgsqlCMD.Parameters[4].Value = e.Hypo;
            NpgsqlCMD.Parameters[5].Value = e.ID;

            if(GlobalVariables.GlobalConnection.updateData(NpgsqlCMD) && !bIsUnitTest)
                MessageBox.Show("Experiment successfully updated.", "Data Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if(!bIsUnitTest)
                MessageBox.Show("Error updating experiment.", "Update Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void deleteRecord(string id, bool bIsUnitTest)
        {
            NpgsqlCMD = new NpgsqlCommand();
            DialogResult mResult;
            if (!bIsUnitTest)
                mResult = MessageBox.Show("Are you sure you wish to permantely delete this record?", "Delete Record Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            else
                mResult = DialogResult.Yes;

            if (mResult == DialogResult.Yes)
            {
                NpgsqlCMD.CommandText = "Delete from experiments where EX_ID = :exID";
                NpgsqlCMD.Parameters.Add(new NpgsqlParameter("exID", NpgsqlDbType.Integer));
                NpgsqlCMD.Parameters[0].Value = Convert.ToInt32(id);
                if(GlobalVariables.GlobalConnection.deleteData(NpgsqlCMD) && !bIsUnitTest)
                    MessageBox.Show("Data successfully deleted.", "Data Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if(!bIsUnitTest)
                    MessageBox.Show("Error deleting data.", "Delete Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(!bIsUnitTest)
                MessageBox.Show("Delete process has been cancelled.", "Delete Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
