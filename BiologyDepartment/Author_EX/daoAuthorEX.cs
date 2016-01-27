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
    class daoAuthorEX
    {
        private DataSet ds = new DataSet();
        private NpgsqlCommand NpgsqlCMD;

        public daoAuthorEX()
        {
        }

        public DataSet getAuthorEX(int ex)
        {
            NpgsqlCMD = new NpgsqlCommand();
            NpgsqlCMD.CommandText = @"select * from author_table a
                                    where exists (select ae.author_id 
                                                  from author_experiments ae 
                                                  where ae.author_id = a.author_id
                                                  and ae.EX_ID = :exID)";

            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("exID", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters[0].Value = ex;

            DataSet ds = new DataSet();
            ds = GlobalVariables.GlobalConnection.readData(NpgsqlCMD);
            if (ds != null)
            {
                return ds;
            }
            else
                return null;
        }

        public DataSet getRecord(Author_Ex a)
        {
            NpgsqlCMD = new NpgsqlCommand();
            NpgsqlCMD.CommandText = "Select * from author_experiments Where EX_ID = :exID and AUTHOR_ID = :authID";
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("exID", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("authID", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters[0].Value = a.EX_ID;
            NpgsqlCMD.Parameters[1].Value = a.Author_ID;

            DataSet ds = new DataSet();
            ds = GlobalVariables.GlobalConnection.readData(NpgsqlCMD);
            if (ds != null)
            {
                return ds;
            }
            else
                return null;
        }

        public void insertRecord(Author_Ex a )
        {
            NpgsqlCMD = new NpgsqlCommand();
            NpgsqlCMD.CommandText = @"Insert into author_experiments (AUTHOR_ID, EX_ID, AUTHOR_RANK)
                                   VALUES (:authorID,  :exID, :rank)";

            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("authorID", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("exID", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("rank", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters[0].Value = a.Author_ID;
            NpgsqlCMD.Parameters[1].Value = a.EX_ID;
            NpgsqlCMD.Parameters[2].Value = a.Rank;

            if(GlobalVariables.GlobalConnection.insertData(NpgsqlCMD))
                MessageBox.Show("Author has been added to this experiment.", "Author Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Access has not been added to this experiment.", "Author Not Added", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void updateRecord(Author_Ex a)
        {
            NpgsqlCMD = new NpgsqlCommand();
            NpgsqlCMD.CommandText = @"Update author_experiments
                                 Set AUTHOR_ID = :authID,
                                 EX_ID  = :exID
                                 AUTHOR_RANK  = :rank";

            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("authID", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("exID", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("rank", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters[0].Value = a.Author_ID;
            NpgsqlCMD.Parameters[1].Value = a.EX_ID;
            NpgsqlCMD.Parameters[2].Value = a.Rank;

            if(GlobalVariables.GlobalConnection.updateData(NpgsqlCMD))
                MessageBox.Show("Author has been updated for this experiment.", "Author Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Access has not been updated for this experiment.", "Author Not Updated", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void deleteRecord(Author_Ex A)
        {
            NpgsqlCMD = new NpgsqlCommand();

            DialogResult mResult = MessageBox.Show("Are you sure you wish to permantely delete this record?", "Delete Record Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (mResult == DialogResult.Yes)
            {
                NpgsqlCMD.CommandText = "Delete from author_experiments where AUTHOR_ID = :authID and  EX_ID = :exID";
                NpgsqlCMD.Parameters.Add(new NpgsqlParameter("authID", NpgsqlDbType.Integer));
                NpgsqlCMD.Parameters.Add(new NpgsqlParameter("exID", NpgsqlDbType.Integer));
                NpgsqlCMD.Parameters[0].Value = A.Author_ID;
                NpgsqlCMD.Parameters[1].Value = A.EX_ID;

                if(GlobalVariables.GlobalConnection.deleteData(NpgsqlCMD))
                    MessageBox.Show("Author has been deleted from experiment.", "Author Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Access has not been deleted from experiment .", "Author Not Deleted", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Delete process has been cancelled.", "Delete Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public void deleteAllRecords(int exID)
        {
            NpgsqlCMD = new NpgsqlCommand();

            DialogResult mResult = MessageBox.Show("Are you sure you wish to permantely delete the authors associated with this experiment!", "Delete Record Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (mResult == DialogResult.Yes)
            {
                NpgsqlCMD.CommandText = "Delete from author_experiments where EX_ID = :exID";
                NpgsqlCMD.Parameters.Add(new NpgsqlParameter("exID", NpgsqlDbType.Integer));
                NpgsqlCMD.Parameters[0].Value = exID;

                if(GlobalVariables.GlobalConnection.deleteData(NpgsqlCMD))
                    MessageBox.Show("All Authors have been deleted from this experiment.", "Authors Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("All Authors have not been deleted from this experiment.", "Authors Not Deleted", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Delete process has been cancelled.", "Delete Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
