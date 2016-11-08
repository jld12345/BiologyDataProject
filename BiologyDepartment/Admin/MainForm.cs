using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
using BiologyDepartment.R_Scripts;
using BiologyDepartment.Admin;
using Gnostice;
using Gnostice.Documents;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.OfficeChart;
using Syncfusion.Compression;
using Syncfusion.Presentation;
using Syncfusion.PresentationToPdfConverter;
using Syncfusion.OfficeChartToImageConverter;
using Syncfusion.Pdf;
using MimeDetective;

namespace BiologyDepartment
{

    public partial class MainForm : Form
    {
        #region Private Variables
        ctlLogIn _ctlLogin = new ctlLogIn();
        ctlAuthors _ctlAuthors = new ctlAuthors();
        ctlApiCalls2 _ctlApiCalls = new ctlApiCalls2();
        ctlSetup _ctlSetup = new ctlSetup();
        private bool bAuthorControlDirty = true;
        private DataSet dsExperiments;
        private ExperimentsUtility utilExperiment = new ExperimentsUtility();
        private DocumentDAO daoDoc = new DocumentDAO();
        private IPresentation presentation;
        private PdfDocument PDFdocument;
        private bool bExitProgram = false;
        private MemoryStream mStream;
        #endregion
        #region Public Variables
        #endregion
        #region Delegates
        public delegate void MyDelegate();
        #endregion
        #region DLLImports
        [DllImport("user32.dll")]
        private static extern long SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        #endregion

        #region Public Methods
        public MainForm()
        {
            InitializeComponent();
            GlobalVariables.GlobalConnection = new dbBioConnection();
            using(LoginForm login = new LoginForm())
            {
                login.ShowDialog();
                bExitProgram = login.bExitProgram;
            }
            if (!bExitProgram)
            {
                Initialize();
                Gnostice.Documents.Framework.ActivateLicense("0A76-10E9-8F21-0CDD-2BC2-884A-BE40-989D-10F0-F5D2-EDF5-671D");
            }
        }
        public void Initialize()
        {
            this.WindowState = FormWindowState.Maximized;
            AddTabControls();
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

        #endregion
        #region Private Methods

        private void AddTabControls()
        {
            foreach(TabPageAdv page in tabControlMain2.TabPages)
            {
                switch(page.Name)
                {
                    case "tpExperiments":                        
                        GlobalVariables.ExperimentGrid.Dock = DockStyle.Fill;
                        tpExperiments.Controls.Add(GlobalVariables.ExperimentGrid);                        
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
                        tpRScripts.Controls.Add(_ctlApiCalls);
                        _ctlApiCalls.Dock = DockStyle.Fill;
                        _ctlApiCalls.Initialize();
                        break;
                    case "tpSetup":
                        tpSetup.Controls.Add(_ctlSetup);
                        _ctlSetup.Dock = DockStyle.Fill;
                        break;
                }
                
            }
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControlMain2.SelectedTab.Name)
            {
                case "tpExperiments":
                    break;
                case "tpAuthors":
                    if (bAuthorControlDirty)
                    {
                        this.BeginInvoke(new MyDelegate(LoadAuthors));
                        bAuthorControlDirty = false;
                    }
                    break;
                case "tpRScripts":
                    _ctlApiCalls.LoadGui();
                    break;
                case "tpSetup":
                    break;
                case "tpDocuments":
                    break;
            }
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
            Initialize();
        }


        private void btnAddDocs_Click(object sender, EventArgs e)
        {
            using(frmAddDocument frm = new frmAddDocument(true))
            {
                frm.ShowDialog();
            }
            bgwDocuments.RunWorkerAsync();
        }

        private void tvDocuments_AfterSelect(object sender, EventArgs e)
        {
            if(tvDocuments.SelectedNode.HasChildren)
            {
                if (tvDocuments.SelectedNode.Expanded)
                    tvDocuments.SelectedNode.CollapseAll();
                else
                    tvDocuments.SelectedNode.Expand();

                if (tvDocuments.SelectedNode.Parent == null)
                    return;
            }
            var nodeType = tvDocuments.SelectedNode.GetType();
            if (nodeType.Name.Equals("TreeNodeAdv"))
                return;
            DocumentTreeNode node = (DocumentTreeNode)tvDocuments.SelectedNode;
            if(mStream != null)
                mStream.Close();
            mStream = new MemoryStream(node.DocumentNode.DOCUMENT);
            FileType fileType = node.DocumentNode.DOCUMENT.GetFileType();

            if (fileType != null && (node.DocumentNode.DOCUMENT_TYPE.Equals("Spreadsheet") ||
                fileType.Extension.Equals("xlsx") || fileType.Extension.Equals("xls")))
            {
                docViewer.Visible = false;
                spreadsheetViewer.Visible = true;
                if (spreadsheetViewer == null)
                {
                    spreadsheetViewer = new Syncfusion.Windows.Forms.Spreadsheet.Spreadsheet();
                    tpDocuments.Controls.Add(spreadsheetViewer);
                }
                spreadsheetViewer.Refresh();
                spreadsheetViewer.Open(mStream);
            } 
            else if (node.DocumentNode.DOCUMENT_TYPE.Equals("Presentation"))
            {
                docViewer.Visible = true;
                spreadsheetViewer.Visible = false;
                presentation = Presentation.Open(mStream);
                mStream.Close();
                PDFdocument = PresentationToPdfConverter.Convert(presentation);
                mStream = new MemoryStream();
                PDFdocument.Save(mStream);
                docViewer.LoadDocument(mStream);
            }
            else
            {
                spreadsheetViewer.Visible = false;
                docViewer.Visible = true;
                docViewer.LoadDocument(mStream);
            }
        }

        private void bgwDocuments_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            int nCount = tvDocuments.Nodes.Count;
            for(int i = 0; i < nCount; i++)
            {
                tvDocuments.Nodes[i].Nodes.Clear();
            }
            List<DocumentTreeNode> lstDocuments = daoDoc.BulkExport();
            int nLoop = 1;
            foreach (DocumentTreeNode node in lstDocuments)
            {
                bgwDocuments.ReportProgress((nLoop / lstDocuments.Count) * 100, node);
               
            }
        }

        private void bgwDocuments_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            DocumentTreeNode node = (DocumentTreeNode)e.UserState;
            node.Text = node.DocumentNode.DOCUMENT_TITLE;
            switch (node.DocumentNode.DOCUMENT_TYPE.ToUpper())
            {
                case "PDF":
                    tvDocuments.Nodes[0].Nodes.Add(node);
                    break;
                case "DOCUMENT":
                    tvDocuments.Nodes[1].Nodes.Add(node);
                    break;
                case "SPREADSHEET":
                    tvDocuments.Nodes[2].Nodes.Add(node);
                    break;
                case "PRESENTATION":
                case "Presentation":
                    tvDocuments.Nodes[3].Nodes.Add(node);
                    break;
                case "IMAGE":
                    tvDocuments.Nodes[4].Nodes.Add(node);
                    break;
                default:
                    tvDocuments.Nodes[5].Nodes.Add(node);
                    break;
            }
        }

        private void bgwDocuments_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (mStream != null)
                mStream.Close();
            docViewer.Visible = false;
            spreadsheetViewer.Visible = false;
            tvDocuments.Nodes[0].CollapseImageIndex = 16;
            tvDocuments.Nodes[0].ExpandImageIndex = 16;
            btnRefresh.Enabled = true;
        }

        private void btnAddDoc_Click(object sender, EventArgs e)
        {
            using (frmAddDocument frm = new frmAddDocument(false))
            {
                frm.ShowDialog();
            }
        }

        private void btnEditDoc_Click(object sender, EventArgs e)
        {
            DocumentTreeNode node = (DocumentTreeNode)tvDocuments.ActiveNode;
            using (frmAddDocument frm = new frmAddDocument(false, node.DocumentNode))
            {
                frm.ShowDialog();
            }
        }

        private void btnDelDoc_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(@"Verify you would like to delete this document.  Deleting the document will remove it from the database.  
                                                    This action is not recoverable", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DocumentTreeNode node = (DocumentTreeNode)tvDocuments.ActiveNode;
                daoDoc.DeletePDF(node.DocumentNode);
            }
        }

        private void btnExportDoc_Click(object sender, EventArgs e)
        {
            DocumentTreeNode node = (DocumentTreeNode)tvDocuments.ActiveNode;
            DialogResult result = saveFileDialog1.ShowDialog();
            if(result == DialogResult.OK)
            {
                using(FileStream fStream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write))
                {
                    mStream.WriteTo(fStream);
                    fStream.Close();
                }
            }
        }

        private void btnAddExperiment_Click(object sender, EventArgs e)
        {
            using(frmAddEditExperiment frm = new frmAddEditExperiment())
            {
                frm.Initialize(null);
                frm.ShowDialog();
                if (frm.ExperimentNode.ExperimentNode.ID > 0)
                {
                    frm.ExperimentNode.Text = frm.ExperimentNode.ExperimentNode.Alias;
                }
            }
        }

        private void btnEditExperiment_Click(object sender, EventArgs e)
        {
            ExperimentTreeNode node = GlobalVariables.ExperimentNode;
            using (frmAddEditExperiment frm = new frmAddEditExperiment())
            {
                frm.Initialize(node);
                frm.ShowDialog();
                node.ExperimentNode.Title = frm.ExperimentNode.ExperimentNode.Title;
                node.ExperimentNode.Alias = frm.ExperimentNode.ExperimentNode.Alias;
                node.ExperimentNode.Hypo = frm.ExperimentNode.ExperimentNode.Hypo;
                node.ExperimentNode.SDate = frm.ExperimentNode.ExperimentNode.SDate;
                node.ExperimentNode.EDate = frm.ExperimentNode.ExperimentNode.EDate;
            }
            
        }

        private void btnDelExperiment_Click(object sender, EventArgs e)
        {
            utilExperiment.DeleteExperiment(GlobalVariables.Experiment.ID);
            btnRefresh.PerformClick();
        }

        private void btnPermissions_Click(object sender, EventArgs e)
        {
            using (UserPermissions frm = new UserPermissions(GlobalVariables.Experiment.ID))
            {
                frm.ShowDialog();
            }
        }

        private void btnSearchEx_Click(object sender, EventArgs e)
        {
            using(dlgExperimentSearch dlg = new dlgExperimentSearch())
            {
                dlg.Initialize();
                dlg.ShowDialog();
                if (dlg.ExperimentLoaded)
                {
                    if (!bgwDocuments.IsBusy)
                        bgwDocuments.RunWorkerAsync();
                    if (this.IsHandleCreated)
                    {
                        this.BeginInvoke(new MyDelegate(LoadSetup));
                    }
                }
            }
        }
        #endregion


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

    public class DocumentTreeNode : TreeNodeAdv
    {
        private DocumentClass nodeDocument = new DocumentClass();

        public DocumentClass DocumentNode
        {
            get { return nodeDocument; }
            set { nodeDocument = value; }
        }
    }

    public class LabelTreeNode : TreeNodeAdv
    {
        private TextBoxExt txtNode = new TextBoxExt();

        public TextBoxExt NodeText
        {
            get {return txtNode;}
            set { txtNode = value; }
        }

    }
}
