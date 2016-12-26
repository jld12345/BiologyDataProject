using System;
using System.Linq;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

namespace BiologyDepartment.R_Scripts
{
    public class RDao
    {
        #region Private Variables
        private DataSet ds = new DataSet();
        private NpgsqlCommand NpgsqlCMD;
        private NpgsqlDataAdapter adapter;
        private int rowCountValue = -1;
        #endregion

        #region Constructor
        public RDao() { }
        #endregion

        #region public Methods

        public DataSet GetRScripts()
        {
            NpgsqlCMD = new NpgsqlCommand();
            NpgsqlCMD.CommandText = @"select r_scripts_id, r_scripts_title, r_scripts_body, '' info_btn, '' execute_btn
                                       from r_scripts
                                       where is_active = 'Y'";
            ds = new DataSet();
            ds = GlobalVariables.GlobalConnection.ReadData(NpgsqlCMD);
            if (ds != null)
            {
                return ds;
            }
            else
                return null;
        }
        #endregion
    }
}
