using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace BiologyDepartment
{
    public partial class ctlRScripts : UserControl
    {
        private string sPostgresSQL = "";
        private string sErrorMsg = "Data string is empty.  Please use the Data tab to set data.";
        private string sDataFrame = "dframe < -dbGetQuery(con, sql)";
        private string sXData = "";
        private string sYData = "";
        private string sFactor = "";
        string sPlot = "";
        private bool bLoad = true;
        private Data.DataUtil _dataUtil = new Data.DataUtil();
        private ctlGGPlot ggPlot = new ctlGGPlot();



        public ctlRScripts()
        {
            InitializeComponent();
            
        }

        public void Initialize()
        {
            if (bLoad || GlobalVariables.RDataIsDirty)
            {
                ggPlot.Initialize();
                tabGGPlot.Controls.Add(ggPlot);
                //btnSetScript.PerformClick();
                PopulateForLatticeExtra();
                bLoad = false;
                GlobalVariables.RDataIsDirty = false;
            }
        }

        private void btnClipBoard_Click(object sender, EventArgs e)
        {
            if (rtbRScript.Text != "")
                Clipboard.SetDataObject(rtbRScript.Text);
        }

        private void btnSetScript_Click(object sender, EventArgs e)
        {
            Assembly thisExe = Assembly.GetExecutingAssembly();
            using (Stream stream = thisExe.GetManifestResourceStream("BiologyDepartment.R_Scripts.RBaseScript.txt"))
            {
                using (var reader = new StreamReader(stream))
                {
                    rtbRScript.Text = reader.ReadToEnd();
                }
            }
            rtbRScript.Text += ggPlot.GetRScript();
            
            
        }

        private void PopulateForLatticeExtra()
        {

        }

        


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Initialize();
        }





    }
}
