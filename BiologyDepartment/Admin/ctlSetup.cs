using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Excel;
using System.IO;
using BiologyDepartment.Misc_Files;
namespace BiologyDepartment
{
    public partial class ctlSetup : UserControl
    {
        private string sExcelPath = "";
        private DataSet dsExcelData;
        private DataTable dtColumns = new DataTable();
        private bool bInitialize = false;
        private daoSetup _daoSetup;
        private DataGridViewColumnType dgColumnType = new DataGridViewColumnType();

        List<string> theTypes = new List<string>(new string [] {
            "CHARACTER", 
            "DECIMAL", 
            "INTEGER", 
            "DATE_TIME",
            "IMAGE" 
        });

        public ctlSetup()
        {
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            this.SuspendLayout();
            _daoSetup = new daoSetup();
            pbImport.Image = imageList1.Images[0];
            pbImport.Image.Tag = "down";
            pnlImport2.Width = flowLayoutPanel1.Width;
            pnlImport2.Height = 500;
            pnlImport2.Hide();
            pbShow.Image = imageList1.Images[0];
            pbShow.Image.Tag = "down";
            pnlShow2.Width = flowLayoutPanel1.Width;
            pnlShow2.Height = 500;
            pnlShow2.Hide();
            this.ResumeLayout();
            bInitialize = true;
        }

        private void CollapsePanel(string sName)
        {
            switch (sName)
            {
                case "pnlImport":
                    if (pbImport.Image.Tag.ToString().Equals("down"))
                    {
                        pbImport.Image = imageList1.Images[1];
                        pbImport.Image.Tag = "up";
                        pnlImport2.Show();
                        pnlShow2.Hide();
                        pbShow.Image = imageList1.Images[0];
                        pbShow.Image.Tag = "down";
                    }
                    else
                    {
                        pbImport.Image = imageList1.Images[0];
                        pbImport.Image.Tag = "down";
                        pnlImport2.Hide();
                    }
                    break;
                case "pnlShow":
                    if (pbShow.Image.Tag.ToString().Equals("down"))
                    {
                        pbShow.Image = imageList1.Images[1];
                        pbShow.Image.Tag = "up";
                        pnlShow2.Show();
                        pnlImport2.Hide();
                        pbImport.Image = imageList1.Images[0];
                        pbImport.Image.Tag = "down";
                    }
                    else
                    {
                        pbShow.Image = imageList1.Images[0];
                        pbShow.Image.Tag = "down";
                        pnlShow2.Hide();
                    }
                    break;

            }
        }

        private void pbShow_Click(object sender, EventArgs e)
        {
            CollapsePanel("pnlShow");
        }

        private void pbImport_Click(object sender, EventArgs e)
        {
            CollapsePanel("pnlImport");
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                dsExcelData = new DataSet();
                //Set filter dialog for excel
                openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx;";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.Title = "Select file";
                openFileDialog1.InitialDirectory = @"c:\";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog1.FileName != "")
                    {
                        sExcelPath = openFileDialog1.FileName;
                        txtExcelPath.Text = sExcelPath;
                        dsExcelData = GetExcelReader(sExcelPath);
                        SetWorksheetComboBox();
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

        private void SetWorksheetComboBox()
        {
            cmbWorksheets.Items.Clear();
            if(dsExcelData != null)
            {
                foreach(DataTable dt in dsExcelData.Tables)
                {
                    cmbWorksheets.Items.Add(dt.TableName);
                }
                cmbWorksheets.SelectedItem = 0;
            }
        }

        private DataSet GetExcelReader(string sFilePath)
        {
            // ExcelDataReader works with the binary Excel file, so it needs a FileStream
            // to get started. This is how we avoid dependencies on ACE or Interop:
            FileStream stream = File.Open(sFilePath, FileMode.Open, FileAccess.Read);

            // We return the interface, so that 
            IExcelDataReader reader = null;
            try
            {
                if (sFilePath.EndsWith(".xls"))
                {
                    reader = ExcelReaderFactory.CreateBinaryReader(stream);
                }
                if (sFilePath.EndsWith(".xlsx"))
                {
                    reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                }

                reader.IsFirstRowAsColumnNames = true;
                DataSet result = reader.AsDataSet();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cmbWorksheets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!bInitialize)
                return;

            if(cmbWorksheets.Items.Count > 0)
            {
                dgExcelData.DataSource = dsExcelData.Tables[cmbWorksheets.SelectedItem.ToString()];
            }
        }

        private void dgColAdmin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch(e.ToString())
            {
                case "Del":
                    break;
            }
        }

        public void LoadData()
        {
            dtColumns = _daoSetup.GetExperimentColumns(GlobalVariables.Experiment.ID);

            if (!dtColumns.Columns.Contains("Add"))
                dtColumns.Columns.Add("Add", typeof(string));
            if (!dtColumns.Columns.Contains("Delete"))
                dtColumns.Columns.Add("Delete", typeof(string));
            if (!dtColumns.Columns.Contains("custom_column_name"))
                dtColumns.Columns.Add("custom_column_name", typeof(string));
            if (!dtColumns.Columns.Contains("custom_column_data_type"))
                dtColumns.Columns.Add("custom_column_data_type", typeof(string));
            if (!dtColumns.Columns.Contains("custom_columns_id"))
                dtColumns.Columns.Add("custom_columns_id", typeof(string));        
        }

        private void dgColAdmin_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //dtColumns = _daoSetup.UpdateColumn(dgColAdmin.DataSource as DataTable);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgExcelData.DataSource = null;
        }

        private void btnImportCol_Click(object sender, EventArgs e)
        {
            List<string> lstExistingCols = new List<string>();
            //Loop through Excel sheet columns and add to Column Admin
            foreach (DataGridViewColumn dgCol in dgExcelData.Columns)
            {
                bool isThere = false;
                foreach (DataGridViewRow row in dgColAdmin.Rows)
                {
                    if (row.Cells["custom_column_name"].Value != null && Convert.ToString(row.Cells["custom_column_name"].Value).ToUpper().Equals(dgCol.HeaderText.ToUpper()))
                    {
                        isThere = true;
                        lstExistingCols.Add(Convert.ToString(row.Cells["custom_column_name"].Value));
                    }
                }
                if (!isThere)
                {
                    DataRow dr = dtColumns.NewRow();
                    dr["custom_column_name"] = dgCol.HeaderText;
                    dr["custom_column_data_type"] = "CHARACTER";
                    dtColumns.Rows.Add(dr);
                }
            }

            if(lstExistingCols.Count > 0)
            {
                string sCol = "";
                string msg = "The following columns already exist and were not added." + Environment.NewLine;
                foreach(string s in lstExistingCols )
                    sCol += s + Environment.NewLine;

                MessageBox.Show(msg + sCol, "Columns Exist", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void LoadGrid()
        {
            //use column name as the property to bind it to the datatable.
            if (!dgColAdmin.Columns.Contains("Add"))
                dgColAdmin.Columns.Add(dgColumnType.AddButtonColumnAddIcon("Add", "", true, 1));
            if (!dgColAdmin.Columns.Contains("Delete"))
                dgColAdmin.Columns.Add(dgColumnType.AddButtonColumnDeleteIcon("Delete", "", true, 2));
            if (!dgColAdmin.Columns.Contains("custom_column_name"))
                dgColAdmin.Columns.Add(dgColumnType.AddTextColumn("custom_column_name", "NAME", true, 3));
            if (!dgColAdmin.Columns.Contains("custom_column_data_type"))
                dgColAdmin.Columns.Add(dgColumnType.AddComboBoxColumns("custom_column_data_type", "TYPE", true, 4, theTypes));
            if(!dgColAdmin.Columns.Contains("custom_columns_id"))
                dgColAdmin.Columns.Add(dgColumnType.AddTextColumn("custom_columns_id", "ex_id", false, 5));
            
            dgColAdmin.DataSource = dtColumns;

            dgColAdmin.Columns["custom_columns_id"].Visible = false;
            dgColAdmin.Columns["custom_column_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            lblExperiment.Text = GlobalVariables.Experiment.Title;

        }

        private void dgColAdmin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgColAdmin.Rows[e.RowIndex];
            string sName = Convert.ToString(row.Cells["custom_column_name"].Value);
            string sType = Convert.ToString(row.Cells["custom_column_data_type"].Value);
            if (!string.IsNullOrEmpty(sName) && !string.IsNullOrEmpty(sType))
                return;

            int nColID = 0;
            int.TryParse(Convert.ToString(row.Cells["Add"].Value), out nColID);

            switch(dgColAdmin.Columns[e.ColumnIndex].Name)
            {
                case "Add":
                    if (nColID > 0)
                        _daoSetup.UpdateColumn(nColID, sName, sType);
                    else
                        _daoSetup.InsertColumn(GlobalVariables.Experiment.ID, sName, sType);
                    break;
                case "Delete":
                    if (nColID > 0)
                        _daoSetup.DeleteColumn(nColID);
                    else
                        dgColAdmin.Rows.RemoveAt(e.RowIndex);

                    LoadData();
                    LoadGrid();
                    break;
                default:
                    break;
            }
        }
    }
}

