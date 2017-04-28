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
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
using BiologyDepartment.ExperimentsFolder;
using BiologyDepartment.ExperimentDocuments;
using BiologyDepartment.Login;
using BiologyDepartment.R_Scripts;
using BiologyDepartment.Admin;
using Gnostice;
using Gnostice.Documents;
using HeyRed.Mime;
using Syncfusion.Presentation;
using Syncfusion.Pdf;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.PresentationToPdfConverter;
using BiologyDepartment.Data;

namespace BiologyDepartment
{

    public partial class MainForm : Form
    {
        #region Private Variables
        ctlLogIn _ctlLogin = new ctlLogIn();
        ctlAuthors _ctlAuthors = new ctlAuthors();
        CtlApiCalls2 _ctlApiCalls = new CtlApiCalls2();
        ctlSetup _ctlSetup = new ctlSetup();
        private bool bAuthorControlDirty = true;
        private DataSet dsExperiments;
        private ExperimentsUtility utilExperiment = new ExperimentsUtility();
        private DocumentDAO daoDoc = new DocumentDAO();
        private IPresentation presentation;
        private PdfDocument PDFdocument;
        private bool bExitProgram = false;
        private MemoryStream mStream;
        private ToolStripDropDown dropDown;
        private ToolStripButton btnChangePassword;
        private ToolStripPanelItem dropDownPanel;
        private DataUtil util = new DataUtil();

        public CtlApiCalls2 CtlApiCalls { get { return _ctlApiCalls; } set { _ctlApiCalls = value; } }
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
            GlobalVariables.GlobalConnection = new DbBioConnection();
            using(LoginForm login = new LoginForm())
            {
                login.ShowDialog();
                bExitProgram = login.bExitProgram;
            }
            if (!bExitProgram)
            {
                SuspendLayout();
                Initialize();
                Gnostice.Documents.Framework.ActivateLicense("0A76-10E9-8F21-0CDD-2BC2-884A-BE40-989D-10F0-F5D2-EDF5-671D");
                ResumeLayout();
            }
        }
        public void Initialize()
        {
            this.WindowState = FormWindowState.Maximized;
            AddDropDownRibbonItems();
            AddTabControls();
            btnNewRow.Click += new EventHandler(GlobalVariables.ExperimentGrid.BtnAdd_Click);
            //btnExportDoc2.Click += new EventHandler(GlobalVariables.ExperimentGrid.BtnExport_Click_1);
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
                        var browser = new WebBrowser();//new CefSharp.WinForms.ChromiumWebBrowser(BiologyDepartment.Properties.Settings.Default.MyRStudio);   
                        browser.Navigate(BiologyDepartment.Properties.Settings.Default.MyRStudio);
                        tpRStudio.Controls.Add(browser);
                        browser.Dock = DockStyle.Fill;
                        break;
                    case "tpAuthors":
                        /*
                        tabAuthors.Controls.Add(_ctlAuthors);
                        _ctlAuthors.Dock = DockStyle.Fill;*/
                        break;
                    case "tpRScripts":
                        tpRScripts.Controls.Add(CtlApiCalls);
                        CtlApiCalls.Dock = DockStyle.Fill;
                        CtlApiCalls.Initialize();
                        break;
                    case "tpSetup":
                        tpSetup.Controls.Add(_ctlSetup);
                        _ctlSetup.Dock = DockStyle.Fill;
                        break;
                }
                
            }
        }

        private void TabControlMain_SelectedIndexChanged(object sender, EventArgs e)
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
                    CtlApiCalls.LoadGui();
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

        private void TspExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnRefresh2_Click(object sender, EventArgs e)
        {
            GlobalVariables.Experiment = null;
            Initialize();
        }


        private void BtnAddDocs_Click(object sender, EventArgs e)
        {
            using(frmAddDocument frm = new frmAddDocument(true))
            {
                frm.ShowDialog();
            }
            bgwDocuments.RunWorkerAsync();
        }

        private void TvDocuments_AfterSelect(object sender, EventArgs e)
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
            FileType fileType = MimeGuesser.GuessFileType(node.DocumentNode.DOCUMENT);

            if (fileType.MimeType != null && (node.DocumentNode.DOCUMENT_TYPE.Equals("Spreadsheet") ||
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

        private void BgwDocuments_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
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

        private void BgwDocuments_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
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

        private void BgwDocuments_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (mStream != null)
                mStream.Close();
            docViewer.Visible = false;
            spreadsheetViewer.Visible = false;
            tvDocuments.Nodes[0].CollapseImageIndex = 16;
            tvDocuments.Nodes[0].ExpandImageIndex = 16;
            btnRefresh.Enabled = true;
        }

        private void BtnAddDoc_Click(object sender, EventArgs e)
        {
            using (frmAddDocument frm = new frmAddDocument(false))
            {
                frm.ShowDialog();
            }
        }

        private void BtnEditDoc_Click(object sender, EventArgs e)
        {
            DocumentTreeNode node = (DocumentTreeNode)tvDocuments.ActiveNode;
            using (frmAddDocument frm = new frmAddDocument(false, node.DocumentNode))
            {
                frm.ShowDialog();
            }
        }

        private void BtnDelDoc_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(@"Verify you would like to delete this document.  Deleting the document will remove it from the database.  
                                                    This action is not recoverable", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DocumentTreeNode node = (DocumentTreeNode)tvDocuments.ActiveNode;
                daoDoc.DeletePDF(node.DocumentNode);
            }
        }

        private void BtnExportDoc_Click(object sender, EventArgs e)
        {

        }

        private void BtnAddExperiment_Click(object sender, EventArgs e)
        {
            using(FrmAddEditExperiment frm = new FrmAddEditExperiment())
            {
                frm.Initialize(null);
                frm.ShowDialog();
                if (frm.ExperimentNode.ExperimentNode.ID > 0)
                {
                    frm.ExperimentNode.Text = frm.ExperimentNode.ExperimentNode.Alias;
                }
            }
        }

        private void BtnEditExperiment_Click(object sender, EventArgs e)
        {
            ExperimentTreeNode node = GlobalVariables.ExperimentNode;
            using (FrmAddEditExperiment frm = new FrmAddEditExperiment())
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

        private void BtnDelExperiment_Click(object sender, EventArgs e)
        {
            utilExperiment.DeleteExperiment(GlobalVariables.Experiment.ID);
            btnRefresh.PerformClick();
        }

        private void BtnPermissions_Click(object sender, EventArgs e)
        {
            using (UserPermissions frm = new UserPermissions(GlobalVariables.Experiment.ID))
            {
                frm.ShowDialog();
            }
        }

        private void BtnSearchEx_Click(object sender, EventArgs e)
        {
            using(dlgExperimentSearch dlg = new dlgExperimentSearch())
            {
                dlg.SuspendLayout();
                dlg.Initialize();
                dlg.ResumeLayout();
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
                tabControlMain2.TabPages[3].TabVisible = (GlobalVariables.Experiment.UserAccess.ToUpper().Equals("OWNER")
                    || GlobalVariables.Experiment.UserAccess.ToUpper().Equals("ADMIN")) ? true:false;

        }
        #endregion

        private void RibbonControlAdv1_OfficeMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void AddDropDownRibbonItems()
        {
            dropDown = new ToolStripDropDown();
            dropDownPanel = new ToolStripPanelItem();

            btnChangePassword = new ToolStripButton("C&hange Password");
            btnChangePassword.Click += BtnChangePassword_Click;
            
            dropDownPanel.Items.Add(btnChangePassword);

            foreach (ToolStripButton btn in dropDownPanel.Items)
            {
                btn.AutoSize = false;
                btn.Size = new Size(170, 35);
                btn.ImageAlign = ContentAlignment.MiddleLeft;
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.ImageScaling = ToolStripItemImageScaling.None;

            }

            dropDown.Items.Add(dropDownPanel);
            this.ribbonControlAdv1.MenuButtonDropDown = dropDown;
        }

        void BtnChangePassword_Click(object sender, EventArgs e)
        {
            using(frmChangePassword frm = new frmChangePassword())
            {
                frm.ShowDialog();
            }
        }

        private void ribbonControlAdv1_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.Refresh();
            btnSearchEx.PerformClick();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            util.ExportToExcel(GlobalVariables.ExperimentGrid.dtAnimals, "EXCEL");
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            util.ExportToExcel(GlobalVariables.ExperimentGrid.dtAnimals, "IMAGE");
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            util.ExportToExcel(GlobalVariables.ExperimentGrid.dtAnimals, "ALL");
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
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

    public class ExperimentTreeMenuItem : TreeMenuItem
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
