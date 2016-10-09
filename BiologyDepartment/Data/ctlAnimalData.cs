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
        
        private List<AnimalData> animalAgg = new List<AnimalData>();
        private List<CustomColumns> animalCols = new List<CustomColumns>();
        private DataTable dtAnimals = new DataTable();
        private bool bIsInitialize = false;
        private CommonUtil _commonUtil = new CommonUtil();
        public bool bDataDirty = false;
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
            intID = id;
            dtAnimals = null;
            _bindingSource.DataSource = null;
            dgExData.DataSource = null;
            dgExData.DataBindings.Clear();
            dgExData.Columns.Clear();
            dtAnimals = _dataUtil.GetData();
            if (_bindingSource.DataSource == null)
            {
                if (dtAnimals == null || dtAnimals.Rows.Count == 0)
                    return;
                _bindingSource.DataSource = dtAnimals;
                dgExData.DataSource = _bindingSource;
            }
            if (dtAnimals == null || dtAnimals.Rows.Count == 0)
            {
                if (dgExData.RowCount > 0)
                {
                    _bindingSource.DataSource = null;
                    dgExData.DataSource = null;
                    dgExData.DataBindings.Clear();
                    dgExData.Columns.Clear();
                }
                return;
            }
            SetGrid();
            bIsInitialize = true;

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

            if (!dgExData.Columns.Contains("EXCLUDE"))
            {
                DataGridViewCheckBoxColumn chkExclude = new DataGridViewCheckBoxColumn();
                chkExclude.HeaderText = "EXCLUDE";
                chkExclude.Name = "EXCLUDE";
                chkExclude.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                chkExclude.FlatStyle = FlatStyle.Standard;
                chkExclude.ThreeState = false;
                chkExclude.DataPropertyName = "EXCLUDE";
                dgExData.Columns.Insert(2, chkExclude);
                dgExData.Columns["EXCLUDE"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgExData.DisableFilter(dgExData.Columns["EXCLUDE"]);  
            }

            dgExData.Columns["EXCLUDE"].Visible = true;

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
            string selectedrowindex = Convert.ToString(dgExData.SelectedRows[0].Cells["ROW_ID"].Value);
            var dtRow = dtAnimals.Rows
                              .Cast<DataRow>()
                              .Where(x => x["ROW_ID"].ToString().Equals(selectedrowindex)).ToList();
            DataRow row = dtAnimals.Rows.Find(dtRow[0]["ROW_ID"]);
            DataRow newRow = dtAnimals.NewRow();
            int rowindex = dtAnimals.Rows.IndexOf(row);
            foreach (DataColumn col in dtAnimals.Columns)
            {
                newRow[col.ColumnName] = dtRow[0][col.ColumnName];
            }
            using (frmExDataEntry _frmFishData = frmExDataEntry.CreateInstance(ref newRow))
            {
                _frmFishData.StartPosition = FormStartPosition.WindowsDefaultLocation;
                _frmFishData.ShowDialog();
                DataTable dtReturn = _frmFishData.dtReturn;
                if (dtReturn == null)
                    return;

                foreach(DataRow dr in dtReturn.Rows)
                {
                    foreach (DataColumn col in dtAnimals.Columns)
                    {
                        dtAnimals.Rows[rowindex][col.ColumnName] = dr[col.ColumnName];
                    }
                }
                bDataDirty = true;
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
            var dg = (DataGridView)sender;

            switch(dg.Columns[e.ColumnIndex].Name)
            {
                case "DELETE":
                    dtAnimals.Rows.RemoveAt(e.RowIndex);
                    bDataDirty = true;
                    dtAnimals.AcceptChanges();
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
            SaveData();
        }

        public void SaveData()
        {
            if(bDataDirty)
            {
                DataSet ds = new DataSet();
                ds.Tables.Add(dtAnimals.Copy());
                ds.AcceptChanges();
                _commonUtil.SerializeJson(ds);
            }
            dtAnimals.AcceptChanges();
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
