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
using System.Collections;
using System.Collections.Specialized;
namespace BiologyDepartment
{
    class daoEXPermissions
    {
        private DataSet ds = new DataSet();
        private NpgsqlCommand NpgsqlCMD;

        public daoEXPermissions()
        {
        }

        public void insertPermissions(int id, string userName, string Permissions)
        {
            NpgsqlCMD = new NpgsqlCommand()
            {
                CommandText = @"insert into experiment_access
                                   (ex_id, user_name, access_type)
                                    values(:id, :user_name, :permissions)"
            };
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("id", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("user_name", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("permissions", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters[0].Value = id;
            NpgsqlCMD.Parameters[1].Value = userName;
            NpgsqlCMD.Parameters[2].Value = Permissions;

            if(GlobalVariables.GlobalConnection.InsertData(NpgsqlCMD))
                MessageBox.Show("Access has been granted for " + userName + ".", "Access Granted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Access has not been granted for " + userName + ".", "Access Not Granted", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public DataSet GetPermissions(int id)
        {
            NpgsqlCMD = new NpgsqlCommand()
            {
                CommandText = @"select * from experiment_access
                                   where ex_id = :id
                                   and access_type <> 'Owner'
                                   and user_name <> 'James'"
            };
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("id", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters[0].Value = id;
            DataSet ds = new DataSet();
            ds = GlobalVariables.GlobalConnection.ReadData(NpgsqlCMD);
            if (ds != null)
            {
                return ds;
            }
            else
                return null;
        }
        
        public void UpdatePermissions(int id, string names, string permission)
        {
            NpgsqlCMD = new NpgsqlCommand();
            NpgsqlCMD.Parameters.Clear();

            if (!(String.IsNullOrEmpty(permission)))
            {
                NpgsqlCMD.CommandText = @"Update experiment_access
                                       Set  access_type = :permission 
                                       where user_name  = :userName
                                       and ex_id  = :id";

                NpgsqlCMD.Parameters.Add(new NpgsqlParameter("permission", NpgsqlDbType.Varchar));
                NpgsqlCMD.Parameters.Add(new NpgsqlParameter("userName", NpgsqlDbType.Varchar));
                NpgsqlCMD.Parameters.Add(new NpgsqlParameter("id", NpgsqlDbType.Integer));
                NpgsqlCMD.Parameters[0].Value = permission;
                NpgsqlCMD.Parameters[1].Value = names;
                NpgsqlCMD.Parameters[2].Value = id;

                if(GlobalVariables.GlobalConnection.UpdateData(NpgsqlCMD))
                    MessageBox.Show("Access has been updated for " + names + ".", "Access Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Access has not been updated for " + names + ".", "Access Not Updated", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                DeletePermission(id, names);
        }        

        public void DeletePermission(int id, string UserName)
        {
            NpgsqlCMD = new NpgsqlCommand()
            {
                CommandText = @"delete from experiment_access
                                   where user_name  = :userName
                                   and ex_id  = :id"
            };
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("userName", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("id", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters[0].Value = UserName;
            NpgsqlCMD.Parameters[1].Value = id;

            if (GlobalVariables.GlobalConnection.UpdateData(NpgsqlCMD))
                MessageBox.Show("Access has been revoked for " + UserName + ".", "Access Revoked", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Unable to revoke access for " + UserName + ".", "Access Not Revoked", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
