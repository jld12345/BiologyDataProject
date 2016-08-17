using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Permissions;
using Microsoft.Win32;
using CefSharp;
using CefSharp.WinForms;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
using Syncfusion.Windows.Forms.Tools;
using BiologyDepartment.ExperimentsFolder;
using BiologyDepartment.Login;
using Gnostice;
using Gnostice.Documents;

namespace BiologyDepartment
{

    public partial class MainForm : Form
    {
        ctlLogIn _ctlLogin = new ctlLogIn();
        ctlExperiments2 _ctlExperiments = new ctlExperiments2();
        ctlAnimalData _ctlAnimalData = new ctlAnimalData();
        ctlAuthors _ctlAuthors = new ctlAuthors();
        ctlRScripts _ctlRScripts;
        ctlSetup _ctlSetup;
        private bool bDataControlDirty = true;
        private bool bAuthorControlDirty = true;
        private bool bSetupControlDirty = true;

        public delegate void MyDelegate();
        [DllImport("user32.dll")]
        private static extern long SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        public MainForm()
        {
            InitializeComponent();
            GlobalVariables.GlobalConnection = new dbBioConnection();
            using(LoginForm login = new LoginForm())
            {
                login.ShowDialog();
            }
            Initialize();
            Gnostice.Documents.Framework.ActivateLicense("0A76-10E9-8F21-0CDD-2BC2-884A-BE40-989D-10F0-F5D2-EDF5-671D");

        }
        public void Initialize()
        {
            this.Show();
            this.BringToFront();
            AddTabControls();
        }

        private void AddTabControls()
        {
            this.Controls.Add(spcMainControl);
            foreach(TabPageAdv page in tabControlMain2.TabPages)
            {
                switch(page.Name)
                {
                    case "tpExperiments":
                        
                        _ctlExperiments.Dock = DockStyle.Fill;
                        _ctlExperiments.Initialize();
                        _ctlExperiments.ChangeExperimentEvent += _ctlExperiments_ChangeExperimentEvent;
                        tpExperiments.Controls.Add(_ctlExperiments);                        
                        break;
                    case "tpData":                        
                        tpData.Controls.Add(_ctlAnimalData);
                        _ctlAnimalData.Dock = DockStyle.Fill;
                        break;
                    case "tpRStudio":
                        var browser = new CefSharp.WinForms.ChromiumWebBrowser(BiologyDepartment.Properties.Settings.Default.MyRStudio);   
                        //var browser = new CefSharp.WinForms.ChromiumWebBrowser("http:71.45.10.32:1521")
                        {
                            Dock = DockStyle.Fill;
                        };
                        
                        tpRStudio.Controls.Add(browser);
                        break;
                    case "tpAuthors":
                        /*
                        tabAuthors.Controls.Add(_ctlAuthors);
                        _ctlAuthors.Dock = DockStyle.Fill;*/
                        break;
                    case "tpRScripts":
                        _ctlRScripts = new ctlRScripts();
                        tpRScripts.Controls.Add(_ctlRScripts);
                        _ctlRScripts.Dock = DockStyle.Fill;
                        break;
                    case "tpSetup":
                        _ctlSetup = new ctlSetup();
                        tpSetup.Controls.Add(_ctlSetup);
                        _ctlSetup.Dock = DockStyle.Fill;
                        break;
                }
                
            }
        }

        private void _ctlExperiments_ChangeExperimentEvent(object sender, ExperimentsFolder.ExperimentHasChanged e)
        {
            bDataControlDirty = true;
            bAuthorControlDirty = true;
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControlMain2.SelectedTab.Name)
            {
                case "tpData":
                    if (bDataControlDirty)
                    {
                        this.BeginInvoke(new MyDelegate(LoadData));
                        bDataControlDirty = false;
                    }
                    break;
                case "tpAuthors":
                    if (bAuthorControlDirty)
                    {
                        this.BeginInvoke(new MyDelegate(LoadAuthors));
                        bAuthorControlDirty = false;
                    }
                    break;
                case "tpRScripts":
                    _ctlRScripts.Initialize();
                    break;
                case "tpSetup":
                    if (bDataControlDirty)
                    {
                        this.BeginInvoke(new MyDelegate(LoadSetup));
                        bSetupControlDirty = false;
                    }
                    break;
                case "tpDocuments":
                    docViewer.LoadDocument(@"C:\Users\James\Google Drive\Documents\Getting started with OneDrive.docx");
                    break;
            }
        }

            public void LoadData()
            {
                _ctlAnimalData.Initialize(GlobalVariables.Experiment.ID);
                //tabControlMain.TabPages["tabData"].Controls.Add(_ctlAnimalData);
            }

            public void LoadAuthors()
            {
                /*tabControlMain2.TabPages["tabAuthors"].Controls.Remove(_ctlAuthors);
                _ctlAuthors.frmRefresh(GlobalVariables.Experiment.ID);
                tabControlMain2.TabPages["tabAuthors"].Controls.Add(_ctlAuthors);*/
            }

        public void LoadSetup()
        {
            _ctlSetup.LoadData();
            _ctlSetup.LoadGrid();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (tabControlMain2.SelectedTab.Name)
            {
                case "tpData":

                    break;
                case "tpAuthors":

                    break;
                case "tpRScripts":
                    
                    break;
                case "tpSetup":
                    if (e.KeyCode == Keys.F5)
                    {
                        LoadSetup();
                    }
                    break;
            }
        }

        private void tspExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRefresh2_Click(object sender, EventArgs e)
        {
            GlobalVariables.Experiment = null;
            _ctlExperiments.Initialize();
        }

    }
    
}
