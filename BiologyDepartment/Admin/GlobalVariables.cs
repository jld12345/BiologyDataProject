using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;

namespace BiologyDepartment
{
    public static class GlobalVariables
    {

        /// <summary>
        /// Static value protected by access routine.
        /// </summary>
        static string theUser;
        static string thePassword;
        static string DBConnection = "Server=54.187.120.10;Port=5432;Database=BiologyProject;";
        static string ADConnection = @"54.187.120.10";
        static string ADUser;
        static string ADGroup;
        static string ADPassword;
        static string UserAccess;
        static string StaticsQuery;
        static List<string> QueryColumns = new List<string>();
        static frmDataLoading dl = new frmDataLoading();
        static Experiments _experiments = new Experiments();
        static NpgsqlConnection con;

        static dbBioConnection BioConnection;

        /// <summary>
        /// Access routine for global variable.
        /// </summary>
        public static string dbUser
        {
            get
            {
                return theUser;
            }
            set
            {
                theUser = value;
            }
        }

        public static string dbPass
        {
            get
            {
                return thePassword;
            }
            set
            {
                thePassword = value;
            }
        }

        public static NpgsqlConnection Connection
        {
            get { return conn(); }
        }

        private static NpgsqlConnection conn()
        {
            if (con == null)
            {
              con =  new NpgsqlConnection(@"Server=54.187.120.10;
                                        Port=5432;
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

        public static string DataSource
        {
            get
            {
                return DBConnection;
            }
            set
            {
                DBConnection = value;
            }
        }

        public static string ActiveDirectoryConnection
        {
            get
            {
                return ADConnection;
            }
            set
            {
                ADConnection = value;
            }
        }

        public static string ADUserName
        {
            get
            {
                return ADUser;
            }
            set
            {
                ADUser = value;
            }
        }

        public static string ADUserGroup
        {
            get
            {
                return ADGroup;
            }
            set
            {
                ADGroup = value;
            }
        }

        public static string ADPass
        {
            get
            {
                return ADPassword;
            }
            set
            {
                ADPassword = value;
            }
        }

        public static dbBioConnection GlobalConnection
        {
            get
            {
                return BioConnection;
            }
            set
            {
                BioConnection = value;
            }
        }

        public static string Access
        {
            get
            {
                return UserAccess;
            }
            set
            {
                UserAccess = value;
            }
        }

        public static string StatsQuery
        {
            get
            {
                return StaticsQuery;
            }
            set
            {
                StaticsQuery = value;
            }
        }

        public static Experiments Experiment
        {
            get
            {
                return _experiments;
            }
            set
            {
                _experiments = value;
            }
        }

        public static frmDataLoading DataLoading
        {
            get
            {
                dl.SetProgressBar();
                return dl;
            }
        }

        public static List<string> GetSQLColumns
        {
            get
            {
                return QueryColumns;
            }
        }

        internal static void ClearQueryColumn()
        {
            QueryColumns.Clear();
        }


        internal static void AddQueryValue(string p)
        {
            QueryColumns.Add(p);
        }
    }
}
