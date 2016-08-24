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
using BiologyDepartment.ExperimentDocuments;
using BiologyDepartment.Login;
using Gnostice;
using Gnostice.Documents;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms.Tools;

namespace BiologyDepartment
{

    public partial class MainForm : Form
    {
        ctlLogIn _ctlLogin = new ctlLogIn();
        ctlExperiments2 _ctlExperiments = new ctlExperiments2();
        private ctlAnimalData _ctlAnimalData = new ctlAnimalData();
        ctlAuthors _ctlAuthors = new ctlAuthors();
        ctlRScripts _ctlRScripts;
        ctlSetup _ctlSetup;
        private bool bDataControlDirty = true;
        private bool bAuthorControlDirty = true;
        private bool bSetupControlDirty = true;
        private DataSet dsExperiments;
        private ExperimentsUtility utilExperiment = new ExperimentsUtility();
        private DockingManager dockingManager1 = new DockingManager();

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
            this.WindowState = FormWindowState.Maximized;
            LoadData();
            AddTabControls();
            LoadFirstNode();
        }

        private void LoadFirstNode()
        {
            if (tvExperiments.Nodes[0].Nodes.Count > 0)
                tvExperiments.SelectedNode = tvExperiments.Nodes[0].Nodes[0];
            else if (tvExperiments.Nodes[1].Nodes.Count > 0)
                tvExperiments.SelectedNode = tvExperiments.Nodes[1].Nodes[0];
            else if (tvExperiments.Nodes[2].Nodes.Count > 0)
                tvExperiments.SelectedNode = tvExperiments.Nodes[2].Nodes[0];
            else if (tvExperiments.Nodes[3].Nodes.Count > 0)
                tvExperiments.SelectedNode = tvExperiments.Nodes[3].Nodes[0];

        }

        private void LoadData()
        {
            dsExperiments = utilExperiment.GetExperimentsDataSet();

            foreach (DataRow row in dsExperiments.Tables[0].Rows)
            {
                ExperimentTreeNode node = new ExperimentTreeNode();
                node.ExperimentNode.ID = Convert.ToInt32(row["ex_id"]);
                node.ExperimentNode.Alias = Convert.ToString(row["ex_alias"]);
                node.ExperimentNode.Title = Convert.ToString(row["ex_title"]);
                node.ExperimentNode.SDate = Convert.ToString(row["ex_sdate"]);
                node.ExperimentNode.EDate = Convert.ToString(row["ex_edate"]);
                node.ExperimentNode.Hypo = Convert.ToString(row["ex_hypothesis"]);
                node.ExperimentNode.UserAccess = Convert.ToString(row["Permissions"]);
                node.Text = node.ExperimentNode.Title;
                if (dsExperiments.Tables.Count > 1 && dsExperiments.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow childRow in dsExperiments.Tables[1].Rows)
                    {
                        if (Convert.ToInt32(childRow["ex_parent_id"]) == node.ExperimentNode.ID)
                        {
                            ExperimentTreeNode childNode = new ExperimentTreeNode();
                            childNode.ExperimentNode.ID = Convert.ToInt32(childRow["ex_id"]);
                            childNode.ExperimentNode.Alias = Convert.ToString(childRow["ex_alias"]);
                            childNode.ExperimentNode.Title = Convert.ToString(childRow["ex_title"]);
                            childNode.ExperimentNode.SDate = Convert.ToString(childRow["ex_sdate"]);
                            childNode.ExperimentNode.EDate = Convert.ToString(childRow["ex_edate"]);
                            childNode.ExperimentNode.Hypo = Convert.ToString(childRow["ex_hypothesis"]);
                            childNode.ExperimentNode.ParentEx = Convert.ToInt32(childRow["ex_parent_id"]);
                            childNode.Text = childNode.ExperimentNode.Title;
                            if (dsExperiments.Tables.Count > 2 && dsExperiments.Tables[2].Rows.Count > 0)
                            {
                                foreach (DataRow grandChildRow in dsExperiments.Tables[2].Rows)
                                {
                                    if (Convert.ToInt32(grandChildRow["ex_parent_id"]) == childNode.ExperimentNode.ID)
                                    {
                                        ExperimentTreeNode grandChildNode = new ExperimentTreeNode();
                                        grandChildNode.ExperimentNode.ID = Convert.ToInt32(grandChildRow["ex_id"]);
                                        grandChildNode.ExperimentNode.Alias = Convert.ToString(grandChildRow["ex_alias"]);
                                        grandChildNode.ExperimentNode.Title = Convert.ToString(grandChildRow["ex_title"]);
                                        grandChildNode.ExperimentNode.SDate = Convert.ToString(grandChildRow["ex_sdate"]);
                                        grandChildNode.ExperimentNode.EDate = Convert.ToString(grandChildRow["ex_edate"]);
                                        grandChildNode.ExperimentNode.Hypo = Convert.ToString(grandChildRow["ex_hypothesis"]);
                                        grandChildNode.ExperimentNode.ParentEx = Convert.ToInt32(grandChildRow["ex_parent_id"]);
                                        grandChildNode.Text = grandChildNode.ExperimentNode.Title;
                                        childNode.Nodes.Add(grandChildNode);
                                    }
                                }
                            }
                            node.Nodes.Add(childNode);
                        }
                    }
                }
                switch(Convert.ToString(row["Permissions"]))
                {
                    case "Owner":
                        tvExperiments.Nodes[0].Nodes.Add(node);
                        break;
                    case "Admin":
                        tvExperiments.Nodes[1].Nodes.Add(node);
                        break;
                    case "Add/Edit":
                        tvExperiments.Nodes[2].Nodes.Add(node);
                        break;
                    case "View":
                        tvExperiments.Nodes[3].Nodes.Add(node);
                        break;
                }
                
            }

        }

        private void AddTabControls()
        {
            this.Controls.Add(spcMainControl);
            foreach(TabPageAdv page in tabControlMain2.TabPages)
            {
                switch(page.Name)
                {
                    case "tpExperiments":                        
                        _ctlAnimalData.Dock = DockStyle.Fill;
                        tpExperiments.Controls.Add(_ctlAnimalData);                        
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
            SetRecord();
        }

        private void SetRecord()
        {
            txtCodeName.Text = GlobalVariables.Experiment.Alias;
            txtProjectName.Text = GlobalVariables.Experiment.Title;
            dtpStart.Value = Convert.ToDateTime(GlobalVariables.Experiment.SDate);
            dtpEnd.Value = Convert.ToDateTime(GlobalVariables.Experiment.EDate);
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControlMain2.SelectedTab.Name)
            {
                case "tpExperiments":
                    spcExperimentDocs.Panel2Collapsed = true;
                    break;
                case "tpAuthors":
                    spcExperimentDocs.Panel2Collapsed = true;
                    if (bAuthorControlDirty)
                    {
                        this.BeginInvoke(new MyDelegate(LoadAuthors));
                        bAuthorControlDirty = false;
                    }
                    break;
                case "tpRScripts":
                    spcExperimentDocs.Panel2Collapsed = true;
                    _ctlRScripts.Initialize();
                    break;
                case "tpSetup":
                    spcExperimentDocs.Panel2Collapsed = true;

                    if (bDataControlDirty)
                    {
                        this.BeginInvoke(new MyDelegate(LoadSetup));
                        bSetupControlDirty = false;
                    }
                    break;
                case "tpDocuments":
                    spcExperimentDocs.Panel2Collapsed = false;
                    docViewer.LoadDocument(@"C:\Users\James\Google Drive\Documents\Getting started with OneDrive.docx");
                    break;
            }
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

        private void tvExperiments_AfterSelect(object sender, EventArgs e)
        {
            ExperimentTreeNode node = (ExperimentTreeNode)tvExperiments.SelectedNode;
            GlobalVariables.Experiment = node.ExperimentNode;
            bDataControlDirty = true;
            bAuthorControlDirty = true;
            SetRecord();
            _ctlAnimalData.Initialize(GlobalVariables.Experiment.ID);
        }

        private void btnAddDocs_Click(object sender, EventArgs e)
        {
            using(frmAddDocument frm = new frmAddDocument())
            {
                frm.ShowDialog();
            }
        }

    }

    public class ExperimentTreeNode : TreeNodeAdv
    {
        private Experiments nodeExperiment = new Experiments();

        public Experiments ExperimentNode
        {
            get { return nodeExperiment; }
            set { nodeExperiment = value; }
        }
    }
    
}
