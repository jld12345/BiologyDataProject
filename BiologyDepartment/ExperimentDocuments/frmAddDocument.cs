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

namespace BiologyDepartment.ExperimentDocuments
{
    public partial class frmAddDocument : Form
    {
        //PDFClass should work to load anything as a byte.
        private DocumentClass thePDF = new DocumentClass();
        private List<string> sFilePath = new List<string>();
        private List<string> sFileName = new List<string>();
        private DocumentDAO daoDoc = new DocumentDAO();
        private bool bIsEdit = false;

        public frmAddDocument(bool bAllowMulti)
        {
            InitializeComponent();
            openFileDialog1.Multiselect = bAllowMulti;
            cmbDocType.SelectedIndex = 0;
            rtbTitle.Enabled = true;
        }

        public frmAddDocument(bool bAllowMulti, DocumentClass docEdit)
        {
            InitializeComponent();
            thePDF = docEdit;
            openFileDialog1.Multiselect = bAllowMulti;
            cmbDocType.SelectedText = thePDF.DOCUMENT_TYPE;
            rtbDescription.Text = thePDF.DOCUMENT_DESCRIPTION;
            rtbTitle.Text = thePDF.DOCUMENT_TITLE;
            rtbTitle.Enabled = true;
            btnBrowse.Enabled = true;
            bIsEdit = true;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Title = "Select file";
                openFileDialog1.InitialDirectory = @"c:\";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    int nCount = 0;
                    foreach(string sName in openFileDialog1.FileNames)
                    {
                        sFilePath.Add(sName);
                        sFileName.Add(openFileDialog1.SafeFileName[nCount].ToString());
                        txtDocPath.Text += sName + ",";
                        rtbTitle.Text += openFileDialog1.SafeFileName[nCount].ToString();
                        nCount++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(rtbTitle.Text))
            {
                MessageBox.Show("Please enter title information.", "Title Null", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int nCount = 0;
            if (!bIsEdit)
            {
                foreach (string sPath in sFilePath)
                {
                    thePDF.DOCUMENT_TITLE = sFileName[nCount];
                    thePDF.DOCUMENT_DESCRIPTION = string.IsNullOrWhiteSpace(rtbDescription.Text) ? "Description not available." : rtbDescription.Text;
                    thePDF.EXPERIMENT_ID = GlobalVariables.ExperimentNode.ExperimentNode.ID;
                    thePDF.DOCUMENT_TYPE = cmbDocType.SelectedItem.ToString();

                    using (FileStream fileStream = new FileStream(sPath, FileMode.Open, FileAccess.Read))
                    {
                        byte[] byteData = new byte[fileStream.Length];
                        fileStream.Read(byteData, 0, System.Convert.ToInt32(fileStream.Length));
                        thePDF.DOCUMENT = byteData;
                    }

                    daoDoc.InsertPDF(thePDF);
                    nCount++;
                }
                rtbDescription.Clear();
                rtbTitle.Clear();
                txtDocPath.Clear();
                cmbDocType.SelectedIndex = 0;
            }
            else
            {
                thePDF.DOCUMENT_TITLE = rtbTitle.Text;
                thePDF.DOCUMENT_DESCRIPTION = rtbDescription.Text;
                if(cmbDocType.SelectedItem != null)
                    thePDF.DOCUMENT_TYPE = cmbDocType.SelectedItem.ToString();
                daoDoc.UpdatePDF(thePDF);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(bIsEdit)
            {
                Close();
            }
            txtDocPath.Clear();
            rtbDescription.Clear();
            rtbTitle.Clear();
        }
    }
}
