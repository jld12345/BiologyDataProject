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
        private PDFClass thePDF = new PDFClass();
        private string sFilePath = "";
        private DocumentDAO daoDoc = new DocumentDAO();
        public frmAddDocument()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Title = "Select file";
                openFileDialog1.InitialDirectory = @"c:\";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog1.FileName != "")
                    {
                        sFilePath = openFileDialog1.FileName;
                        txtDocPath.Text = sFilePath;
                    }
                    else
                    {
                        MessageBox.Show("Chose Excel sheet path..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            thePDF.EXPERIMENT_PDF_TITLE = rtbTitle.Text;
            thePDF.EXPERIMENT_PDF_DESCRIPTION = string.IsNullOrWhiteSpace(rtbDescription.Text) ? "Description not available." : rtbDescription.Text;
            thePDF.EXPERIMENT_ID = GlobalVariables.Experiment.ID;

            using (FileStream fileStream = new FileStream(sFilePath, FileMode.Open, FileAccess.Read))
            {
                byte[] byteData = new byte[fileStream.Length];
                fileStream.Read(byteData, 0, System.Convert.ToInt32(fileStream.Length));
                thePDF.EXPERIMENT_PDF = byteData;
            }
            daoDoc.InsertPDF(thePDF);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtDocPath.Clear();
            rtbDescription.Clear();
            rtbTitle.Clear();
        }
    }
}
