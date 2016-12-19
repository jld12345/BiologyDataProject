﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADGV;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections.Specialized;
using System.Collections;
using System.Security.Permissions;
using Microsoft.Win32;
using System.IO;
using System.Linq.Expressions;
using System.Data.Common;
using System.Globalization;
using System.Threading;
using DgvFilterPopup;
using System.Reflection;
using ClosedXML.Excel;
using BiologyDepartment.Misc_Files;
using System.Diagnostics;
using BiologyDepartment.Data;
using BiologyDepartment.Common;

namespace BiologyDepartment
{
    public partial class ctlAnimalData : UserControl
    {
        #region Private Variables
        private DataTable dtExperiments = new DataTable();
        private daoData _daoData = new daoData();
        private DataUtil _dataUtil = new DataUtil();
        private int intID= 0;
        
        private List<AnimalData> animalAgg = new List<AnimalData>();
        private List<CustomColumns> animalCols = new List<CustomColumns>();
        private DataTable dtAnimals = new DataTable();
        private bool bIsInitialize = false;
        private CommonUtil _commonUtil = new CommonUtil();
        public bool bDataDirty = false;
        private DataColumn[] keys = new DataColumn[1];
        #endregion

        #region Public Variables
        public BindingSource _bindingSource = new BindingSource();
        #endregion

        public event EventHandler<CloseCtlAnimalData> CloseFormEvent;

        public ctlAnimalData()
        {
            InitializeComponent();
            _bindingSource.ListChanged += new ListChangedEventHandler(bindingSource_ListChanged);
        }

        public void Initialize(int id)
        {
            this.SuspendLayout();
            intID = id;
            dtAnimals = null;
            _bindingSource.DataSource = null;
            _bindingSource.Clear();
            dgExData.DataSource = null;
            dgExData.DataBindings.Clear();
            dgExData.Columns.Clear();
            dtAnimals = new DataTable();
            dtAnimals = _dataUtil.GetData();
            if (_bindingSource.DataSource == null)
            {
                if (dtAnimals == null)
                    return;

                _bindingSource.DataSource = null;
                dgExData.DataSource = null;
                dgExData.DataBindings.Clear();
                dgExData.Columns.Clear();
                dgExData.Rows.Clear();

                keys[0] = dtAnimals.Columns["EXPERIMENTS_JSONB_ID"];
                dtAnimals.PrimaryKey = keys;
                dtAnimals.AcceptChanges();

                _bindingSource.DataSource = dtAnimals;
                _bindingSource.Filter = GlobalVariables.ExperimentData.TableFilter;
                dgExData.DataSource = _bindingSource;

            }

            SetGrid();
            bIsInitialize = true;
            this.ResumeLayout();
        }

        private void SetGrid()
        {

            if (!dgExData.Columns.Contains("EDIT"))
            {
                DataGridViewImageColumn btnEdit = new DataGridViewImageColumn();
                btnEdit.HeaderText = "EDIT";
                btnEdit.Name = "EDIT";
                btnEdit.Width = 50;
                btnEdit.DefaultCellStyle.ForeColor = Color.Red;
                btnEdit.Image = GlobalVariables.Images.Images["Expand"];
                btnEdit.DataPropertyName = "EDIT";
                dgExData.Columns.Insert(0, btnEdit);
                dgExData.Columns["EDIT"].SortMode = DataGridViewColumnSortMode.Automatic;
                dgExData.DisableFilter(dgExData.Columns["EDIT"]);
            }

            if (!dgExData.Columns.Contains("DELETE"))
            {
                DataGridViewImageColumn btnDel = new DataGridViewImageColumn();
                btnDel.HeaderText = "DELETE";
                btnDel.Name = "DELETE";
                btnDel.Width = 50;
                btnDel.DefaultCellStyle.ForeColor = Color.Red;
                btnDel.Image = GlobalVariables.Images.Images["Toggle"];
                btnDel.DataPropertyName = "DELETE";
                dgExData.Columns.Insert(1, btnDel);
                dgExData.Columns["DELETE"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgExData.DisableFilter(dgExData.Columns["DELETE"]);
            }


            if(dgExData.Columns.Contains("DATA PICTURE"))
                dgExData.Columns["DATA PICTURE"].Visible = false;

            int nDisplay = 2;
            foreach(DataColumn col in dtAnimals.Columns)
            {
                dgExData.Columns[col.ColumnName].HeaderText = col.Caption;
                dgExData.Columns[col.ColumnName].DisplayIndex = nDisplay; 

                nDisplay++;
            }

            this.searchToolBar.SetColumns(dgExData.Columns);

            dgExData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtAnimals.AcceptChanges();
            dgExData.Refresh();
            dgExData.Rows[GlobalVariables.ExperimentData.TableRow].Selected = true;
        }     

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataRow newRow = dtAnimals.NewRow();
            using (frmExDataEntry _frmFishData = frmExDataEntry.CreateInstance(true, ref newRow))
            {
                _frmFishData.StartPosition = FormStartPosition.WindowsDefaultLocation;
                _frmFishData.ShowDialog();

                DataTable dtReturn = _frmFishData.dtReturn;
                if (dtReturn == null)
                    return;

                foreach (DataRow row in dtReturn.Rows)
                {
                    newRow = dtAnimals.NewRow();
                    foreach (DataColumn col in dtAnimals.Columns)
                    {
                        newRow[col.ColumnName] = row[col.ColumnName];
                    }
                    dtAnimals.Rows.Add(newRow);
                }
            }
            SaveData(0);
        }

        private void setButtons()
        {
            try
            {
                switch (GlobalVariables.Access)
                {
                    case "View":
                    case "Add/Edit":
                        btnAdd.Enabled = false;
                        break;
                    case "Admin":
                    case "Owner":
                        btnAdd.Enabled = true;
                        break;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void dgExData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditRow();
        }

        private void EditRow()
        {
            string selectedrowindex = Convert.ToString(dgExData.SelectedRows[0].Cells["EXPERIMENTS_JSONB_ID"].Value);
            GlobalVariables.ExperimentData.TableRow = dgExData.SelectedRows[0].Index;
            GlobalVariables.ExperimentData.TableFilter = _bindingSource.Filter;
            var dtRow = dtAnimals.Rows
                              .Cast<DataRow>()
                              .Where(x => x["EXPERIMENTS_JSONB_ID"].ToString().Equals(selectedrowindex)).ToList();
            DataRow row = dtAnimals.Rows.Find(dtRow[0]["EXPERIMENTS_JSONB_ID"]);
            DataRow newRow = dtAnimals.NewRow();
            int rowindex = dtAnimals.Rows.IndexOf(row);
            foreach (DataColumn col in dtAnimals.Columns)
            {
                newRow[col.ColumnName] = dtRow[0][col.ColumnName];
            }
            using (frmExDataEntry _frmFishData = frmExDataEntry.CreateInstance(false, ref newRow))
            {
                _frmFishData.StartPosition = FormStartPosition.WindowsDefaultLocation;
                _frmFishData.ShowDialog();
                DataTable dtReturn = _frmFishData.dtReturn;
                if (dtReturn == null)
                {
                    _commonUtil.DeleteDataLock(GlobalVariables.Experiment.ID, Convert.ToInt32(selectedrowindex), "EXPERIMENTS_JSONB");
                    return;
                }

                foreach(DataRow dr in dtReturn.Rows)
                {
                    foreach (DataColumn col in dtAnimals.Columns)
                    {
                        if(!dtAnimals.Columns[col.ColumnName].ReadOnly)
                            dtAnimals.Rows[rowindex][col.ColumnName] = dr[col.ColumnName];
                    }
                }
                btnSave.PerformClick();
                bDataDirty = true;
                _commonUtil.DeleteDataLock(GlobalVariables.Experiment.ID, Convert.ToInt32(selectedrowindex), "EXPERIMENTS_JSONB");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            dgExData.DataSource = null;
            OnCloseFormEvent(new CloseCtlAnimalData());
        }

        protected virtual void OnCloseFormEvent(CloseCtlAnimalData e)
        {
            EventHandler<CloseCtlAnimalData> handler = CloseFormEvent;

            // Event will be null if there are no subscribers 
            if (handler != null)
            {
                // Use the () operator to raise the event.
                handler(this, e);
            }
        }

        private void btnExport_Click_1(object sender, EventArgs e)
        {
            _dataUtil.ExportToExcel(dgExData, false);
        }

        private void dataGridView_SortStringChanged(object sender, EventArgs e)
        {
            _bindingSource.Sort = dgExData.SortString;
        }

        private void dataGridView_FilterStringChanged(object sender, EventArgs e)
        {
            _bindingSource.Filter = dgExData.FilterString;
            GlobalVariables.FilteredGrid = dgExData;
            GlobalVariables.RDataIsDirty = true;
        }

        private void clearFilterButton_Click(object sender, EventArgs e)
        {
            dgExData.ClearFilter(true);
        }

        private void clearSortButton_Click(object sender, EventArgs e)
        {
            dgExData.ClearSort(true);
        }

        private void bindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            this.searchToolBar.SetColumns(dgExData.Columns);
        }

        private void searchToolBar_Search(object sender, SearchToolBarSearchEventArgs e)
        {
            int startColumn = 0;
            int startRow = 0;
            if (!e.FromBegin)
            {
                bool endcol = dgExData.CurrentCell.ColumnIndex + 1 >= dgExData.ColumnCount;
                bool endrow = dgExData.CurrentCell.RowIndex + 1 >= dgExData.RowCount;

                if (endcol && endrow)
                {
                    startColumn = dgExData.CurrentCell.ColumnIndex;
                    startRow = dgExData.CurrentCell.RowIndex;
                }
                else
                {
                    startColumn = endcol ? 0 : dgExData.CurrentCell.ColumnIndex + 1;
                    startRow = dgExData.CurrentCell.RowIndex + (endcol ? 1 : 0);
                }
            }
            DataGridViewCell c = dgExData.FindCell(
                e.ValueToSearch,
                e.ColumnToSearch != null ? e.ColumnToSearch.Name : null,
                startRow,
                startColumn,
                e.WholeWord,
                e.CaseSensitive);

            if (c != null)
                dgExData.CurrentCell = c;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (this.btnSearch.Checked)
            {
                this.searchToolBar.Show();
                btnSearch.CheckState = CheckState.Unchecked;
            }
            else
            {
                this.searchToolBar.Hide();
                btnSearch.CheckState = CheckState.Checked;
            }
        }

        private void searchToolBar_VisibleChanged(object sender, EventArgs e)
        {
            this.btnSearch.Checked = this.searchToolBar.Visible;
        }

        private void dgExData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            var dg = (DataGridView)sender;
            int nRow = Convert.ToInt32(dtAnimals.Rows[e.RowIndex]["EXPERIMENTS_JSONB_ID"]);
            switch(dg.Columns[e.ColumnIndex].Name)
            {
                case "DELETE":
                    if (!_commonUtil.DataLockExists(GlobalVariables.ExperimentNode.ExperimentNode.ID, nRow, "EXPERIMENTS_JSONB"))
                    {
                        dtAnimals.Rows[e.RowIndex].Delete();
                        SaveData(nRow);
                    }
                    else
                    {
                        MessageBox.Show("The row you are trying to delete is currently locked by another user and cannot be edited at this time.", "Row Locked",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    break;
                case "EDIT":
                    
                    if(!_commonUtil.DataLockExists(GlobalVariables.ExperimentNode.ExperimentNode.ID, nRow, "EXPERIMENTS_JSONB"))
                    {
                        _commonUtil.CreateDataLock(GlobalVariables.ExperimentNode.ExperimentNode.ID, nRow, "EXPERIMENTS_JSONB", "EDIT");
                        EditRow();
                    }
                    else
                    {
                        MessageBox.Show("The row you are trying to edit is currently locked by another user and cannot be edited at this time.", "Row Locked",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case "EXCLUDE":
                    _dataUtil.CheckExcludeState(e.RowIndex, bIsInitialize, ref dgExData);
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData(0);
        }

        public void SaveData(int nJsonID)
        {
            DataTable dt = dtAnimals.GetChanges();
            if (dt == null)
                return;
            foreach(DataRow dr in dt.Rows)
            {
                if(nJsonID >= 0)
                    nJsonID = Convert.ToInt32(dr["EXPERIMENTS_JSONB_ID"]);
                string action = "";
                if (dr.RowState == DataRowState.Modified)
                    action = "MODIFIED";
                else if(dr.RowState == DataRowState.Added)
                    action = "ADDED";
                else if(dr.RowState == DataRowState.Deleted)
                    action = "DELETED";

                _commonUtil.SerializeJson(dr, nJsonID, action);
            }
            Initialize(GlobalVariables.ExperimentNode.ExperimentNode.ID);
            bDataDirty = false;
        }

        private void btnJSON_Click(object sender, EventArgs e)
        {
            DataTable dt = (_bindingSource.DataSource as DataTable).Copy();
            foreach(DataColumn col in dtAnimals.Columns)
            {
                dt.Columns[col.ColumnName].ColumnName = col.Caption;
            }
        }

    }

    public class CloseCtlAnimalData : EventArgs
    {
        public CloseCtlAnimalData()
        {
            return;
        }
    }
}
