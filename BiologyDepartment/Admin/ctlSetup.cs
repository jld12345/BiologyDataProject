using System;
using System.Collections;
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
using BiologyDepartment.Common;
using System.Diagnostics;
namespace BiologyDepartment
{
    public partial class ctlSetup : UserControl
    {
        #region Private Variables

        private string sExcelPath = "";
        private DataSet dsExcelData;
        private DataTable dtColumns = new DataTable();
        private bool bInitialize = false;
        private daoSetup _daoSetup;
        private DataGridViewColumnType dgColumnType = new DataGridViewColumnType();
        private List<string> sMapColumns = new List<string>();
        private DataTable dtNotInserted = new DataTable();
        private CommonUtil _commonUtil = new CommonUtil();

        #endregion

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
                        dsExcelData = _commonUtil.GetExcelReader(sExcelPath);
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

        

        private void cmbWorksheets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!bInitialize)
                return;

            if(cmbWorksheets.Items.Count > 0)
            {
                dgExcelData.DataSource = dsExcelData.Tables[cmbWorksheets.SelectedItem.ToString()];
            }
        }

        public void LoadData()
        {
            dtColumns = _daoSetup.GetExperimentColumns(GlobalVariables.Experiment.ID);

            if (!dtColumns.Columns.Contains("custom_column_name"))
                dtColumns.Columns.Add("custom_column_name", typeof(string));
            if (!dtColumns.Columns.Contains("custom_column_data_type"))
                dtColumns.Columns.Add("custom_column_data_type", typeof(string));
            if (!dtColumns.Columns.Contains("custom_columns_id"))
                dtColumns.Columns.Add("custom_columns_id", typeof(string));
            if (!dtColumns.Columns.Contains("map_column"))
                dtColumns.Columns.Add("map_column", typeof(string));
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {    
            if(dgColAdmin.SelectedRows.Count == 0)
            {
                MessageBox.Show("No rows have been selected to add/update.  Please select a row or rows to add/update",
                    "NO ROWS SELECTED", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (DataGridViewRow row in dgColAdmin.SelectedRows)
            {
                int nColID = 0;
                string sName = Convert.ToString(row.Cells["custom_column_name"].Value);
                string sType = Convert.ToString(row.Cells["custom_column_data_type"].Value);
                if (string.IsNullOrEmpty(sName) || string.IsNullOrEmpty(sType))
                    return;
                int.TryParse(Convert.ToString(row.Cells["custom_columns_id"].Value), out nColID);

                if (nColID > 0)
                    _daoSetup.UpdateColumn(nColID, sName, sType);
                else
                {
                    nColID = _daoSetup.InsertColumn(GlobalVariables.Experiment.ID, sName, sType);
                    if (nColID > 0)
                        dgColAdmin.Rows[row.Index].Cells["custom_columns_id"].Value = nColID;
                }
            }

            MapColumns();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {

            dgExcelData.DataSource = _commonUtil.ValidateData((DataTable)dgExcelData.DataSource, dgColAdmin, true, false);
            sMapColumns.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgExcelData.DataSource = "";
            sMapColumns.Clear();
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

            MapColumns();

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
            if (!dgColAdmin.Columns.Contains("custom_column_name"))
                dgColAdmin.Columns.Add(dgColumnType.AddTextColumn("custom_column_name", "NAME", true, 1));
            if (!dgColAdmin.Columns.Contains("custom_column_data_type"))
                dgColAdmin.Columns.Add(dgColumnType.AddComboBoxColumns("custom_column_data_type", "TYPE", true, 2, theTypes));
            if (!dgColAdmin.Columns.Contains("map_column"))
                dgColAdmin.Columns.Add(dgColumnType.AddComboBoxColumns("map_column", "MAP COLUMN", true, 3, sMapColumns));
            if(!dgColAdmin.Columns.Contains("custom_columns_id"))
                dgColAdmin.Columns.Add(dgColumnType.AddTextColumn("custom_columns_id", "ex_id", false, 4));
            
            dgColAdmin.DataSource = dtColumns;

            dgColAdmin.Columns["custom_columns_id"].Visible = false;
            dgColAdmin.Columns["custom_column_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            lblExperiment.Text = GlobalVariables.Experiment.Title;

        }

        private void ctlSetup_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.F5)
            {
                Refresh();
            }
        }

        private void Refresh()
        {
            LoadData();
            LoadGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> lstRows = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dgColAdmin.SelectedRows)
            {
                int nColID = 0;
                int.TryParse(Convert.ToString(row.Cells["custom_columns_id"].Value), out nColID);
                if (nColID > 0)
                {
                    _daoSetup.DeleteColumn(nColID);
                    DataRow drRemove = dtColumns.NewRow();
                    foreach (DataRow drRow in dtColumns.Rows)
                    {
                        if (Convert.ToInt32(drRow["custom_columns_id"]) == nColID)
                            drRemove = drRow;
                    }
                    dtColumns.Rows.Remove(drRemove);
                }
                else
                    lstRows.Add(row);
            }
            foreach (DataGridViewRow row in lstRows)
                dgColAdmin.Rows.Remove(row);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
            sMapColumns.Clear();
        }

        private void btnMapData_Click(object sender, EventArgs e)
        {
            MapColumns();
        }

        private void MapColumns()
        {
            foreach (DataGridViewColumn dgCol in dgExcelData.Columns)
            {
                if (cbHasHeaders.Checked && !sMapColumns.Contains(dgCol.HeaderText))
                    sMapColumns.Add(dgCol.HeaderText);
                else if (!sMapColumns.Contains(dgCol.Index.ToString()))
                    sMapColumns.Add(dgCol.Index.ToString());
            }

            Refresh();

            foreach(string sCol in sMapColumns)
            {
                foreach (DataGridViewRow row in dgColAdmin.Rows)
                {
                    if (row.Cells["custom_column_name"].Value != null &&
                        Convert.ToString(row.Cells["custom_column_name"].Value).ToUpper().Equals(sCol.ToUpper()))
                    {
                        row.Cells["map_column"].Value = sCol;
                        if (dgExcelData.Rows.Count > 0)
                        {
                            DataGridViewRow tempRow = dgExcelData.Rows[0];
                            if (row.Cells["custom_column_data_type"].Value == DBNull.Value)
                            {
                                string tempString = Convert.ToString(tempRow.Cells[sCol].Value);
                                DateTime tempDate;
                                double tempDouble = 0;
                                int tempInt = 0;

                                if (DateTime.TryParse(tempString, out tempDate))
                                    row.Cells["custom_column_data_type"].Value = "DATE_TIME";
                                else if (Int32.TryParse(tempString, out tempInt))
                                    row.Cells["custom_column_data_type"].Value = "INTEGER";
                                else if (Double.TryParse(tempString, out tempDouble))
                                    row.Cells["custom_column_data_type"].Value = "DECIMAL";
                                else
                                    row.Cells["custom_column_data_type"].Value = "CHARACTER";
                            }
                        }

                        break;
                    }
                }
            }
        }

        private void cbHasHeaders_CheckedChanged(object sender, EventArgs e)
        {
            sMapColumns.Clear();
        }

    }
}

