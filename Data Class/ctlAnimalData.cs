using System;
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
        private BindingSource _bindingSource = new BindingSource();
        private List<AnimalData> animalAgg = new List<AnimalData>();
        private List<CustomColumns> animalCols = new List<CustomColumns>();
        private DataTable dtAnimals = new DataTable();
        private bool bIsInitialize = false;
        private CommonUtil _commonUtil = new CommonUtil();
        #endregion

        public event EventHandler<CloseCtlAnimalData> CloseFormEvent;

        public ctlAnimalData()
        {
            InitializeComponent();
        }

        public void Initialize(int id)
        {
            intID = id;
            SetGrid();
            bIsInitialize = true;
        }

        private void SetGrid()
        {
            _bindingSource.ListChanged -= new ListChangedEventHandler(bindingSource_ListChanged);
            _bindingSource.ListChanged += new ListChangedEventHandler(bindingSource_ListChanged);
            dtAnimals = _dataUtil.GetData();
            _bindingSource.DataSource = dtAnimals;
            dgExData.DataSource = _bindingSource;

            if (!dgExData.Columns.Contains("EDIT"))
            {
                DataGridViewImageColumn btnEdit = new DataGridViewImageColumn();
                btnEdit.HeaderText = "EDIT";
                btnEdit.Name = "EDIT";
                btnEdit.Width = 50;
                btnEdit.DefaultCellStyle.ForeColor = Color.Red;
                btnEdit.Image = GlobalVariables.Images.Images["Expand"];
                dgExData.Columns.Insert(0, btnEdit);
                dgExData.Columns["EDIT"].SortMode = DataGridViewColumnSortMode.NotSortable;
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
                dgExData.Columns.Insert(1, btnDel);
                dgExData.Columns["DELETE"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgExData.DisableFilter(dgExData.Columns["DELETE"]);
            }

            if (!dgExData.Columns.Contains("EXCLUDE"))
            {
                DataGridViewCheckBoxColumn chkExclude = new DataGridViewCheckBoxColumn();
                chkExclude.HeaderText = "EXCLUDE";
                chkExclude.Name = "EXCLUDE";
                chkExclude.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                chkExclude.FlatStyle = FlatStyle.Standard;
                chkExclude.ThreeState = false;
                dgExData.Columns.Insert(2, chkExclude);
                dgExData.Columns["EXCLUDE"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgExData.DisableFilter(dgExData.Columns["EXCLUDE"]);  
            }

            dgExData.Columns["EXCLUDE"].Visible = true;
            dgExData.Columns["ExcludeRow"].Visible = false;

            foreach(DataColumn col in dtAnimals.Columns)
            {
                dgExData.Columns[col.ColumnName].HeaderText = col.Caption;
            }

            this.searchToolBar.SetColumns(dgExData.Columns);

            foreach(DataGridViewRow dgvr in dgExData.Rows)
            {
                _dataUtil.CheckExcludeState(dgvr.Index, bIsInitialize, ref dgExData);
            }

            dtAnimals.AcceptChanges();
        }     

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataRow newRow = dtAnimals.NewRow();
            using (frmExDataEntry _frmFishData = frmExDataEntry.CreateInstance(ref newRow))
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
            int selectedrowindex = dgExData.SelectedCells[0].RowIndex;
            DataRow newRow = dtAnimals.NewRow();
            foreach (DataColumn col in dtAnimals.Columns)
            {
                newRow[col.ColumnName] = dtAnimals.Rows[selectedrowindex][col.ColumnName];
            }
            using (frmExDataEntry _frmFishData = frmExDataEntry.CreateInstance(ref newRow))
            {
                _frmFishData.StartPosition = FormStartPosition.WindowsDefaultLocation;
                _frmFishData.ShowDialog();
                DataTable dtReturn = _frmFishData.dtReturn;
                if (dtReturn == null)
                    return;

                foreach(DataRow row in dtReturn.Rows)
                {
                    foreach (DataColumn col in dtAnimals.Columns)
                    {
                        dtAnimals.Rows[selectedrowindex][col.ColumnName] = row[col.ColumnName];
                    }
                }
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


        private void dgExData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*switch(e.ColumnIndex.ToString())
            {
                case "0":
                    int selectedrowindex = dgExData.SelectedCells[0].RowIndex;
                    int row = Convert.ToInt32(dgExData.Rows[selectedrowindex].Cells["FI_ID"].Value);
                    using (frmExDataEntry _frmFishData = frmExDataEntry.CreateInstance(intID, row))
                    {
                        _frmFishData.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        _frmFishData.ShowDialog();
                    }
                    break;
                case "1":
                    foreach (DataGridViewRow dgr in dgExData.SelectedRows)
                        _daoData.UpdateDeleteRow(intID);
                    break;
                case "2":
                    if (e.RowIndex == -1)
                        break;
                    if (dgExData.Rows[e.RowIndex].Cells["EXCLUDE_ROW"].Value.ToString().Equals("N"))
                    {
                        dgExData.Rows[e.RowIndex].Cells["EXCLUDE_ROW"].Value = 'Y';
                        dgExData.Rows[e.RowIndex].Cells["EXCLUDE"].Value = true;
                    }
                    else
                    {
                        dgExData.Rows[e.RowIndex].Cells["EXCLUDE_ROW"].Value = 'N';
                        dgExData.Rows[e.RowIndex].Cells["EXCLUDE"].Value = false;
                    }

                    _daoData.UpdateCore(intID, Convert.ToInt32(dgExData.Rows[e.RowIndex].Cells["FI_ID"].Value.ToString()), dgExData.Rows[e.RowIndex].Cells["EXCLUDE_ROW"].Value.ToString());
                    break;
                
            }*/
        }

        private void dgExData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dg = (DataGridView)sender;

            switch(dg.Columns[e.ColumnIndex].Name)
            {
                case "DELETE":
                    _daoData.UpdateDeleteRow(Convert.ToInt32(dtAnimals.Rows[e.RowIndex]["DataID"]));
                    dtAnimals.Rows.RemoveAt(e.RowIndex);
                    //_daoData.UpdateDeleteRow(Convert.ToInt32(row["DataID"]));
                    //dgExData.Rows.RemoveAt(e.RowIndex);
                    break;
                case "EDIT":
                    EditRow();
                    break;
                case "EXCLUDE":
                    _dataUtil.CheckExcludeState(e.RowIndex, bIsInitialize, ref dgExData);
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dtAdded = dtAnimals.Clone();
            DataTable dtModified = dtAnimals.Clone();
            foreach (DataRow row in dtAnimals.Rows)
            {
                string sState = Convert.ToString(row.RowState);
                switch (sState)
                {
                    case "Unchanged":
                        break;
                    case "Added":
                        DataRow addRow = dtAdded.NewRow();
                        foreach(DataColumn col in dtAnimals.Columns)
                        {
                            addRow[col.ColumnName] = row[col.ColumnName];
                        }
                        dtAdded.Rows.Add(addRow);
                        break;
                    case "Deleted":
                        break;
                    case "Modified":
                        DataRow modRow = dtModified.NewRow();
                        foreach(DataColumn col in dtAnimals.Columns)
                        {
                            modRow[col.ColumnName] = row[col.ColumnName];
                        }
                        dtModified.Rows.Add(modRow);
                        break;
                }
            }
            if(dtAdded.Rows.Count > 0)
                _commonUtil.ValidateData(dtAdded, null, true, false);
            if(dtModified.Rows.Count > 0)
                _commonUtil.ValidateData(dtModified, null, true, true);

            dtAnimals.AcceptChanges();
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
