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
            "IMAGE", 
            "FORMULA"
        });

        public ctlSetup()
        {
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            _daoSetup = new daoSetup();
            bInitialize = true;
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
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

        

        private void CmbWorksheets_SelectedIndexChanged(object sender, EventArgs e)
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
            dtColumns = _daoSetup.GetExperimentColumns(GlobalVariables.ExperimentNode.ExperimentNode.ID);
            if(sMapColumns.Count > 0)
            {
                foreach(string map in sMapColumns)
                {
                    foreach(DataRow dr in dtColumns.Rows)
                    {
                        if (dr["custom_column_name"].ToString().Equals(map))
                            dr["map_column"] = map;
                    }
                }
            }

            if (!dtColumns.Columns.Contains("custom_column_name"))
                dtColumns.Columns.Add("custom_column_name", typeof(string));
            if (!dtColumns.Columns.Contains("custom_column_data_type"))
                dtColumns.Columns.Add("custom_column_data_type", typeof(string));
            if (!dtColumns.Columns.Contains("custom_columns_id"))
                dtColumns.Columns.Add("custom_columns_id", typeof(string));
            if (!dtColumns.Columns.Contains("map_column"))
                dtColumns.Columns.Add("map_column", typeof(string));
            if (!dtColumns.Columns.Contains("custom_column_comments"))
                dtColumns.Columns.Add("custom_column_comments", typeof(string));
            if(!dtColumns.Columns.Contains("custom_column_formula"))
                dtColumns.Columns.Add("custom_column_formula", typeof(string));
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {    
            if(dgColAdmin.SelectedRows.Count == 0)
            {
                MessageBox.Show("No rows have been selected to add/update.  Please select a row or rows to add/update",
                    "NO ROWS SELECTED", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (DataGridViewRow row in dgColAdmin.SelectedRows)
            {
                string sName = Convert.ToString(row.Cells["custom_column_name"].Value);
                string sType = Convert.ToString(row.Cells["custom_column_data_type"].Value);
                string sDesc = "";
                string sFormula = "";
                if(row.Cells["custom_column_comments"].Value != DBNull.Value)
                    sDesc = Convert.ToString(row.Cells["custom_column_comments"].Value);
                if(row.Cells["custom_column_formula"].Value != DBNull.Value)
                    sFormula = Convert.ToString(row.Cells["custom_column_formula"].Value);
                if (string.IsNullOrEmpty(sName) || string.IsNullOrEmpty(sType))
                    return;
                int.TryParse(Convert.ToString(row.Cells["custom_columns_id"].Value), out int nColID);


                if (nColID > 0)
                    _daoSetup.UpdateColumn(nColID, sName, sType, sDesc, sFormula);
                else
                {
                    nColID = _daoSetup.InsertColumn(GlobalVariables.Experiment.ID, sName, sType, sDesc, sFormula);
                    if (nColID > 0)
                        dgColAdmin.Rows[row.Index].Cells["custom_columns_id"].Value = nColID;
                }
            }

            MapColumns(true);
            dgColAdmin.DataSource = null;
            LoadData();
            LoadGrid();
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgExcelData.DataSource;
            DataTable dtColumns = (DataTable)dgColAdmin.DataSource;
            List<string> lstColRemove = new List<string>();
            List<string> lstCol = new List<string>();


            foreach(DataRow dr in dtColumns.Rows)
            {
                if(dt.Columns.Contains(Convert.ToString(dr["map_column"])))
                { 
                    foreach (DataColumn col in dt.Columns)
                    {
                        if (col.ColumnName.Equals(Convert.ToString(dr["map_column"])))
                        {
                            col.ColumnName = Convert.ToString(dr["custom_column_name"]);
                            continue;
                        }
                    }
                }
            }
            DataTable dtCopy = dt.Copy();
            foreach(DataColumn col in dt.Columns)
            {
                bool bExists = false;
                foreach(DataRow dr in dtColumns.Rows)
                {
                    if (col.ColumnName.Equals(Convert.ToString(dr["custom_column_name"])))
                    {
                        bExists = true;
                        if(col.DataType.ToString().Equals("Object"))
                        {
                            dtCopy.Columns.Remove(col.ColumnName);
                            dtCopy.Columns.Add(col.ColumnName, typeof(string));
                            lstColRemove.Add(col.ColumnName);
                        }
                    }
                }
                if (!bExists)
                {
                    dtCopy.Columns.Remove(col.ColumnName);
                    dtCopy.AcceptChanges();
                }
            }
            if (lstColRemove.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    foreach (string col in lstColRemove)
                        dtCopy.Rows[i][col] = dt.Rows[i][col];
                }
            }

            _commonUtil.SerializeTableToJson(dtCopy, dtColumns);
            GlobalVariables.ExperimentGrid.Initialize(GlobalVariables.Experiment.ID);
            //dgExcelData.DataSource = _commonUtil.ValidateData((DataTable)dgExcelData.DataSource, dgColAdmin, true, false);
            //sMapColumns.Clear();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            dgExcelData.DataSource = "";
            sMapColumns.Clear();
        }

        private void BtnImportCol_Click(object sender, EventArgs e)
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
                    dtColumns.AcceptChanges();
                }
            }

            MapColumns(true);

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
            if (!dgColAdmin.Columns.Contains("custom_column_comments"))
                dgColAdmin.Columns.Add(dgColumnType.AddTextColumn("custom_column_comments", "comments", true, 2));
            if (!dgColAdmin.Columns.Contains("custom_column_formula"))
                dgColAdmin.Columns.Add(dgColumnType.AddTextColumn("custom_column_formula", "formula", true, 3));
            if (!dgColAdmin.Columns.Contains("custom_column_data_type"))
                dgColAdmin.Columns.Add(dgColumnType.AddComboBoxColumns("custom_column_data_type", "TYPE", true, 4, theTypes));
            if (!dgColAdmin.Columns.Contains("map_column"))
                dgColAdmin.Columns.Add(dgColumnType.AddComboBoxColumns("map_column", "MAP COLUMN", true, 5, sMapColumns));
            if(!dgColAdmin.Columns.Contains("custom_columns_id"))
                dgColAdmin.Columns.Add(dgColumnType.AddTextColumn("custom_columns_id", "ex_id", false, 6));
            
            dgColAdmin.DataSource = dtColumns;

            dgColAdmin.Columns["custom_columns_id"].Visible = false;
            dgColAdmin.Columns["custom_column_name"].MinimumWidth = 250;
            dgColAdmin.Columns["custom_column_formula"].MinimumWidth = 250;
            dgColAdmin.Columns["custom_column_comments"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void CtlSetup_KeyPress(object sender, KeyPressEventArgs e)
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

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> lstRows = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dgColAdmin.SelectedRows)
            {
                int.TryParse(Convert.ToString(row.Cells["custom_columns_id"].Value), out int nColID);
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

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
            sMapColumns.Clear();
        }

        private void BtnMapData_Click(object sender, EventArgs e)
        {
            MapColumns(false);
        }

        private void MapColumns(bool bIsImport)
        {
            foreach (DataGridViewColumn dgCol in dgExcelData.Columns)
            {
                if (cbHasHeaders.Checked && !sMapColumns.Contains(dgCol.HeaderText))
                    sMapColumns.Add(dgCol.HeaderText);
                else if (!sMapColumns.Contains(dgCol.Index.ToString()) && !cbHasHeaders.Checked)
                    sMapColumns.Add(dgCol.Index.ToString());
            }

            if(!bIsImport)
                Refresh();
        }

        private void CbHasHeaders_CheckedChanged(object sender, EventArgs e)
        {
            sMapColumns.Clear();
        }

        private void DgColAdmin_Layout(object sender, LayoutEventArgs e)
        {

        }

    }
}

