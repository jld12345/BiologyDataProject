using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;
using BiologyDepartment.Data;
using System.IO;

namespace BiologyDepartment
{
    public static class GlobalVariables
    {

        /// <summary>
        /// Static value protected by access routine.
        /// </summary>
        static string theUser;
        static string thePassword;
        //Test Connections
        /*static string DBConnection = BiologyDepartment.Properties.Settings.Default.MyPostgresTest +
                             ";Port=5432;Database=BiologyProject;";
        static string ADConnection = BiologyDepartment.Properties.Settings.Default.MyActiveDirectoryTest;
        static string PasswordReset = BiologyDepartment.Properties.Settings.Default.PasswordTest;*/
        //Live Connections
        static string DBConnection = BiologyDepartment.Properties.Settings.Default.MyPostgress +
                                     ";Port=5432;Database=BiologyProject;";
        static string ADConnection = BiologyDepartment.Properties.Settings.Default.MyActiveDirectory;
        static string PasswordReset = BiologyDepartment.Properties.Settings.Default.PasswordActive;
        static string ADUser;
        static string ADGroup;
        static string ADPassword;
        static string UserAccess;
        static string StaticsQuery;
        static List<string> QueryColumns = new List<string>();
        static frmDataLoading dl = new frmDataLoading();
        static Experiments _experiments = new Experiments();
        static ImageList imageList = new ImageList();
        static NpgsqlConnection con;
        static NpgsqlConnection bgwCon;
        static ExperimentData theData;
        static CtlAnimalData _ctlAnimalData = new CtlAnimalData();
        static ExperimentTreeNode SelectedExperiment = new ExperimentTreeNode();
        static Cursor CrossHair;

        static DbBioConnection BioConnection;

        static string jsonPath = "C:\\BiologyProjectFiles\\";

        /// <summary>
        /// Access routine for global variable.
        /// </summary>
        public static string DbUser
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

        public static string DbPass
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
            get { return Conn(); }
        }
        public static NpgsqlConnection BackgroundConnection
        {
            get { return BgwConnection(); }
        }

        private static NpgsqlConnection Conn()
        {
            try
            {
                if (con == null)
                {
                    con = new NpgsqlConnection(BiologyDepartment.Properties.Settings.Default.MyPostgress +
                                              @";Port=5432;
                                        User Id=" + DbUser + @";
                                        Password=" + DbPass + @";
                                        Database=BiologyProject;
                                        Pooling=false;
                                        CommandTimeout=300;
                                        Connection Idle Lifetime=0");
                }
                if (con.State == System.Data.ConnectionState.Connecting
                    || con.State == System.Data.ConnectionState.Executing
                    || con.State == System.Data.ConnectionState.Fetching)
                {
                    return BgwConnection();
                }
                if (con.State != System.Data.ConnectionState.Open)
                    con.Open();
                return con;
            }
            catch (Exception e)
            {
                try
                {
                    if (con.State != System.Data.ConnectionState.Open)
                    {
                        con.Open();
                        return con;
                    }
                    return null;
                }
                catch(Exception ex)
                {
                    if (!Directory.Exists(jsonPath))
                        Directory.CreateDirectory(jsonPath);
                    string msg = "Error with connection.  " + ex.Message + Environment.NewLine + ex.StackTrace;
                    File.AppendAllText(jsonPath + ExperimentNode.ExperimentNode.ID + "_log.txt", msg);
                    return null;
                }
            }
        }

        private static NpgsqlConnection BgwConnection()
        {
            try
            {
                if (bgwCon == null)
                {
                    bgwCon = new NpgsqlConnection(BiologyDepartment.Properties.Settings.Default.MyPostgress +
                                              @";Port=5432;
                                        User Id=" + DbUser + @";
                                        Password=" + DbPass + @";
                                        Database=BiologyProject;
                                        Pooling=false;
                                        CommandTimeout=300;
                                        Connection Idle Lifetime=0");
                }
                if (bgwCon.State != System.Data.ConnectionState.Open)
                    bgwCon.Open();
                return bgwCon;
            }
            catch (Exception e)
            {
                try
                {
                    if (bgwCon.State != System.Data.ConnectionState.Open)
                    {
                        bgwCon.Open();
                        return bgwCon;
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    if (!Directory.Exists(jsonPath))
                        Directory.CreateDirectory(jsonPath);
                    string msg = "Error with background connection.  " + ex.Message + Environment.NewLine + ex.StackTrace;
                    File.AppendAllText(jsonPath + ExperimentNode.ExperimentNode.ID + "_log.txt", msg);
                    return null;
                }
            }
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

        public static string PasswordConnection
        {
            get
            {
                return PasswordReset;
            }
            set
            {
                PasswordReset = value;
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

        public static DbBioConnection GlobalConnection
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

        public static ImageList Images
        {
            get { return imageList; }
        }

        public static void AddImage(string sImageName, Image theImage)
        {
            imageList.Images.Add(sImageName, theImage);
        }

        internal static void ClearQueryColumn()
        {
            QueryColumns.Clear();
        }


        internal static void AddQueryValue(string p)
        {
            QueryColumns.Add(p);
        }

        public static bool RDataIsDirty { get; set; }

        public static ADGV.AdvancedDataGridView FilteredGrid { get; set; }


        public static List<CustomColumns> CustomColumns { get; set; }

        public static ExperimentData ExperimentData
        {
            get 
            {
                if (theData != null)
                    return theData;
                else
                    return null;
            }
            set { theData = value; }
        }

        public static CtlAnimalData ExperimentGrid
        {
            get { return _ctlAnimalData; }
        }

        public static ExperimentTreeNode ExperimentNode
        {
            get { return SelectedExperiment; }
            set { SelectedExperiment = value; }
        }

        public static Cursor CircleCrossHairCursor
        {
            get
            {
                if (CrossHair == null)
                {
                    System.IO.MemoryStream cursorMemoryStream = new System.IO.MemoryStream(BiologyDepartment.Properties.Resources.CircleCrossHair);
                    CrossHair = new Cursor(cursorMemoryStream);
                }
                return CrossHair;
            }
        }
    }
}
