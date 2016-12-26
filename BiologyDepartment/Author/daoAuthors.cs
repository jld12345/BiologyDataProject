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
    class daoAuthors
    {
        private DataSet dsAuthor = new DataSet();
        private NpgsqlCommand NpgsqlCMD;
   
        public daoAuthors()
        {
        }

        public DataSet getAuthors()
        {
            NpgsqlCMD = new NpgsqlCommand();
            NpgsqlCMD.CommandText = @"Select AU.* from AUTHORS AU";
            DataSet ds = new DataSet();
            ds = GlobalVariables.GlobalConnection.ReadData(NpgsqlCMD);
            if (ds != null)
            {
                return ds;
            }
            else
                return null;
        }
        
        public DataSet getAuthors(int EX_ID)
        {
            NpgsqlCMD = new NpgsqlCommand();
            NpgsqlCMD.CommandText = @"Select AU.AUTHOR_LNAME, AU.AUTHOR_FNAME, AU.AUTHOR_MNAME,
                                      AU.AUTHOR_EMAIL, AU.AUTHOR_ASSOC, AU.AUTHOR_DEPT,
                                      AU.AUTHOR_ID, (SELECT AP.AUTHOR_PICTURE
                                                     FROM AUTHOR_PICTURES AP
                                                     WHERE AP.TABLE_NAME = 'AUTHORS'
                                                     AND AP.TABLE_PRIMARY_KEY = AU.AUTHOR_ID)
                                      FROM AUTHORS AU
                                      Where Exists(Select AE.Author_ID
	                                               From author_experiments AE
	                                               Where AE.Author_ID = AU.Author_ID
	                                               and AE.EX_ID = :exID)";

            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("exID", EX_ID));

            DataSet ds= new DataSet();
            ds = GlobalVariables.GlobalConnection.ReadData(NpgsqlCMD);
            if (ds != null)
            {
                return ds;
            }
            else
                return null;
        }

        public DataSet getRecord(int rec)
        {
            NpgsqlCMD = new NpgsqlCommand();
            NpgsqlCMD.CommandText = "Select * from AUTHORS Where AUTHOR_ID = :rec";

            NpgsqlCMD.Parameters.Add(new NpgsqlParameter(":rec", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters[0].Value = rec;

            DataSet ds = new DataSet();
            ds = GlobalVariables.GlobalConnection.ReadData(NpgsqlCMD);
            if (ds != null)
            {
                return ds;
            }
            else
                return null;
        }

        public void insertRecord(Author a)
        {
            NpgsqlCMD = new NpgsqlCommand();
            NpgsqlCMD.CommandText = @"Insert into AUTHORS (AUTHOR_ID, AUTHOR_LNAME, AUTHOR_FNAME, AUTHOR_MNAME, AUTHOR_EMAIL,                                      AUTHOR_ASSOC, AUTHOR_DEPT) 
                             VALUES (nextval('authors_author_id_seq'), :lname, :fname, :mi, :email, :association, :dept)";

            NpgsqlCMD.Parameters.Add(new NpgsqlParameter(":lname", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter(":fname", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("mi", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("email", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("association", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("dept", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters[0].Value = a.LastName;
            NpgsqlCMD.Parameters[1].Value = a.FirstName;
            NpgsqlCMD.Parameters[2].Value = a.MI;
            NpgsqlCMD.Parameters[3].Value = a.Email;
            NpgsqlCMD.Parameters[4].Value = a.Association;
            NpgsqlCMD.Parameters[5].Value = a.Department;

            if(GlobalVariables.GlobalConnection.InsertData(NpgsqlCMD))
                MessageBox.Show("Author record has been inserted.", "Author Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Author record has not been inserted.", "Author Not Inserted", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void updateRecord(Author a)
        {
            NpgsqlCMD = new NpgsqlCommand();
            NpgsqlCMD.CommandText = @"Update AUTHORS 
                              Set AUTHOR_LNAME = :lname, 
                              AUTHOR_FNAME  = :fname,
                              AUTHOR_MNAME  = :mi,
                              AUTHOR_EMAIL  = :email,
                              AUTHOR_ASSOC  = :association,
                              AUTHOR_DEPT = :dept
                              Where AUTHOR_ID = :authID";

            NpgsqlCMD.Parameters.Add(new NpgsqlParameter(":lname", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter(":fname", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("mi", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("email", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("association", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("dept", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("authID", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters[0].Value = a.LastName;
            NpgsqlCMD.Parameters[1].Value = a.FirstName;
            NpgsqlCMD.Parameters[2].Value = a.MI;
            NpgsqlCMD.Parameters[3].Value = a.Email;
            NpgsqlCMD.Parameters[4].Value = a.Association;
            NpgsqlCMD.Parameters[5].Value = a.Department;
            NpgsqlCMD.Parameters[6].Value = a.ID;

            if(GlobalVariables.GlobalConnection.UpdateData(NpgsqlCMD))
                MessageBox.Show("Author record has been updated.", "Author Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Author record has not been inserted.", "Author Not Updated", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void deleteRecord(int id)
        {
            NpgsqlCMD = new NpgsqlCommand();
            DialogResult mResult =MessageBox.Show("Are you sure you wish to permantely delete this record?", "Delete Record Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (mResult == DialogResult.Yes)
            {
                NpgsqlCMD.CommandText = "Delete from AUTHORS where AUTHOR_ID = :authID";
                NpgsqlCMD.Parameters.Add(new NpgsqlParameter("authID", NpgsqlDbType.Integer));
                NpgsqlCMD.Parameters[0].Value = id;
                if(GlobalVariables.GlobalConnection.DeleteData(NpgsqlCMD))
                    MessageBox.Show("Author record has been deleted.", "Author Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Author record has not been deleted.", "Author Not Deleted", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Delete process has been cancelled.", "Delete Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void InsertPic(string TableName, int AuthorID, byte[] pic)
        {
            NpgsqlCMD = new NpgsqlCommand();
      
            NpgsqlCMD.CommandText = @"DELETE FROM author_pictures
                                      where table_name = :tName
                                      and table_primary_key = :tPK;
                                      INSERT INTO author_pictures 
                                      (table_name, table_primary_key, author_picture)
                                      VALUES(:tName, :tPK, :pic)";

            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("tName", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("tPK", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("pic", NpgsqlDbType.Bytea));
            NpgsqlCMD.Parameters[0].Value = TableName;
            NpgsqlCMD.Parameters[1].Value = AuthorID;
            NpgsqlCMD.Parameters[2].Value = pic;


            if(GlobalVariables.GlobalConnection.InsertData(NpgsqlCMD))
                MessageBox.Show("Picture successfully inserted.", "Picture Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error inserting picture.", "Insert Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void UpdatePic(string TableName, int AuthorID, byte[] pic)
        {
            NpgsqlCMD = new NpgsqlCommand();

            NpgsqlCMD.CommandText = @"UPDATE author_pictures
                                      set author_picture = :pic
                                      where table_name = :tName
                                      and table_primary_key = :tPK";
                                      

            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("tName", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("tPK", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("pic", NpgsqlDbType.Bytea));
            NpgsqlCMD.Parameters[0].Value = TableName;
            NpgsqlCMD.Parameters[1].Value = AuthorID;
            NpgsqlCMD.Parameters[2].Value = pic;


            if (GlobalVariables.GlobalConnection.UpdateData(NpgsqlCMD))
                MessageBox.Show("Picture successfully inserted.", "Picture Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error inserting picture.", "Insert Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
    }
}
