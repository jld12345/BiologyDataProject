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
using Syncfusion.Windows.Forms.CellGrid;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms.Grid.Formulas;

namespace BiologyDepartment
{
    public partial class CtlAnimalData : UserControl
    {
        #region Private Variables
        private DataTable dtExperiments = new DataTable();
        private DaoData _daoData = new DaoData();
        private DataUtil _dataUtil = new DataUtil();
        private int intID= 0;
        
        private List<AnimalData> animalAgg = new List<AnimalData>();
        private List<CustomColumns> animalCols = new List<CustomColumns>();
        private bool bIsInitialize = false;
        private CommonUtil _commonUtil = new CommonUtil();
        public bool bDataDirty = false;
        private DataColumn[] keys = new DataColumn[1];
        #endregion

        #region Public Variables
        public DataTable dtAnimals = new DataTable();
        public GridFilterBar filterBar;
        #endregion

        public event EventHandler<CloseCtlAnimalData> CloseFormEvent;

        public CtlAnimalData()
        {
            InitializeComponent();
            dgExData.CellButtonClicked += new GridCellButtonClickedEventHandler(DgExData_CellContentClick);
            filterBar = new Syncfusion.Windows.Forms.Grid.GridFilterBar();
        }

        public void Initialize(int id)
        {
            intID = id;
            if (filterBar.Wired)
                filterBar.UnwireGrid();
            dtAnimals = _dataUtil.GetData();
            dgExData.CellButtonClicked -= new GridCellButtonClickedEventHandler(DgExData_CellContentClick);
            dgExData.PrepareViewStyleInfo -= new GridPrepareViewStyleInfoEventHandler(grid_PrepareViewStyleInfo);
            this.Controls.Remove(dgExData);
            dgExData = new GridDataBoundGrid();
            dgExData.BaseStylesMap["Row Header"].StyleInfo.CellType = "Header";
            dgExData.CellButtonClicked += new GridCellButtonClickedEventHandler(DgExData_CellContentClick);
            dgExData.PrepareViewStyleInfo += new GridPrepareViewStyleInfoEventHandler(grid_PrepareViewStyleInfo);
            this.Controls.Add(dgExData);
            dgExData.Dock = DockStyle.Fill;
            dgExData.DataSource = dtAnimals;
            
            dtAnimals.Columns.Add("EDIT");
            dtAnimals.Columns.Add("DELETE");
            bool temp = dgExData.IsFilterBarWired;

            SetGrid();
            dgExData.Model.ColWidths.ResizeToFit(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Row(0), GridResizeToFitOptions.NoShrinkSize);
            dgExData.Invalidate();
            bIsInitialize = true;
        }

        private void grid_PrepareViewStyleInfo(object sender, GridPrepareViewStyleInfoEventArgs e)

        {

            if (e.ColIndex == 0 && e.RowIndex > 0)

            {

                e.Style.Text = e.RowIndex.ToString();

                e.Style.Font.Bold = false;

            }
        }

            private void SetGrid()
        {
            for (int i = 1; i <= dgExData.Model.ColCount; i++)
            {
                dgExData.Model.ColStyles[i].TextColor = Color.Black;
                dgExData.Model.ColStyles[i].WrapText = true;
            }
            if (dgExData.Model.NameToColIndex("EDIT") >1)
                dgExData.Model.ColStyles["EDIT"].CellType = "PushButton";
            if (dgExData.Model.NameToColIndex("DELETE") > 1)
                dgExData.Model.ColStyles["DELETE"].CellType = "PushButton";
            if (dgExData.Model.NameToColIndex("EXPERIMENTS_JSONB_ID") > 1)
            {
                dgExData.Model.ColStyles["EXPERIMENTS_JSONB_ID"].Enabled = false;
                dgExData.Model.ColStyles["EXPERIMENTS_JSONB_ID"].BackColor = Color.LightGray;
            }

            dgExData.Model.Cols.MoveRange(dgExData.Model.ColCount - 1, 2, 1);
            //dgExData.Model.Cols.MoveRange(dgExData.Model.ColCount - 1, 1, 1);

            filterBar.WireGrid(dgExData);
        }

        //    if (!dgExData.Columns.Contains("DELETE"))
        //    {
        //        DataGridViewImageColumn btnDel = new DataGridViewImageColumn()
        //        {
        //            HeaderText = "DELETE",
        //            Name = "DELETE",
        //            Width = 50
        //        };
        //        btnDel.DefaultCellStyle.ForeColor = Color.Red;
        //        btnDel.Image = GlobalVariables.Images.Images["Toggle"];
        //        btnDel.DataPropertyName = "DELETE";
        //        dgExData.Columns.Insert(1, btnDel);
        //        dgExData.Columns["DELETE"].SortMode = DataGridViewColumnSortMode.NotSortable;
        //        dgExData.DisableFilter(dgExData.Columns["DELETE"]);
        //    }


        //    if(dgExData.Columns.Contains("DATA PICTURE"))
        //        dgExData.Columns["DATA PICTURE"].Visible = false;

        //    int nDisplay = 2;
        //    foreach(DataColumn col in dtAnimals.Columns)
        //    {
        //        dgExData.Columns[col.ColumnName].HeaderText = col.Caption;
        //        dgExData.Columns[col.ColumnName].DisplayIndex = nDisplay; 

        //        nDisplay++;
        //    }

        //    this.searchToolBar.SetColumns(dgExData.Columns);

        //    dgExData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //    dtAnimals.AcceptChanges();
        //    dgExData.Refresh();
        //    dgExData.Rows[GlobalVariables.ExperimentData.TableRow].Selected = true;
        //}     

        public void BtnAdd_Click(object sender, EventArgs e)
        {
            DataRow newRow = dtAnimals.NewRow();
            using (FrmExDataEntry _frmFishData = FrmExDataEntry.CreateInstance(true, dtAnimals, -1))
            {
                _frmFishData.StartPosition = FormStartPosition.CenterScreen;
                _frmFishData.ShowDialog();
            }
            Initialize(GlobalVariables.ExperimentNode.ExperimentNode.ID);
            bDataDirty = false;
        }

        //private void SetButtons()
        //{
        //    try
        //    {
        //        switch (GlobalVariables.Access)
        //        {
        //            case "View":
        //            case "Add/Edit":
        //                btnAdd.Enabled = false;
        //                break;
        //            case "Admin":
        //            case "Owner":
        //                btnAdd.Enabled = true;
        //                break;
        //        }
        //    }
        //    catch(Exception e)
        //    {
        //        MessageBox.Show(e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }

        //}

        //private void DgExData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    EditRow();
        //}

        private void EditRow(int nGridRow, int nJSONB_Id)
        {
            GlobalVariables.ExperimentData.TableRow = nGridRow;
            GlobalVariables.ExperimentData.TableFilter = filterBar.RowFilter;
            dtAnimals.AcceptChanges();
            var dtRow = dtAnimals.Rows
                              .Cast<DataRow>()
                              .Where(x => x["EXPERIMENTS_JSONB_ID"].ToString().Equals(nJSONB_Id.ToString())).ToList();
            DataRow row = dtAnimals.Rows.Find(dtRow[0]["EXPERIMENTS_JSONB_ID"]);
            DataRow newRow = dtAnimals.NewRow();
            int rowindex = dtAnimals.Rows.IndexOf(row);
            foreach (DataColumn col in dtAnimals.Columns)
            {
                newRow[col.ColumnName] = dtRow[0][col.ColumnName];
            }
            using (FrmExDataEntry _frmFishData = FrmExDataEntry.CreateInstance(false, dtAnimals, rowindex))
            {
                _frmFishData.StartPosition = FormStartPosition.WindowsDefaultLocation;
                _frmFishData.ShowDialog();
                DataTable dtReturn = _frmFishData.dtReturn;
                    _commonUtil.DeleteDataLock(GlobalVariables.Experiment.ID, nJSONB_Id, "EXPERIMENTS_JSONB");
                    Initialize(GlobalVariables.ExperimentNode.ExperimentNode.ID);
                bDataDirty = false;
            }
            if (rowindex>= 0)
            {
                dgExData.Model.Selections.Add(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Row(rowindex));
                dgExData.SetTopRow(rowindex);
            }
        }

        //private void BtnClose_Click(object sender, EventArgs e)
        //{
        //    dgExData.DataSource = null;
        //    OnCloseFormEvent(new CloseCtlAnimalData());
        //}

        //protected virtual void OnCloseFormEvent(CloseCtlAnimalData e)
        //{
        //    CloseFormEvent?.Invoke(this, e);
        //}

        public void BtnExport_Click_1(object sender, EventArgs e)
        {
            //_dataUtil.ExportToExcel(dtAnimals, false);
        }

        //private void DataGridView_SortStringChanged(object sender, EventArgs e)
        //{
        //    _bindingSource.Sort = dgExData.SortString;
        //}

        //private void DataGridView_FilterStringChanged(object sender, EventArgs e)
        //{
        //    _bindingSource.Filter = dgExData.FilterString;
        //    GlobalVariables.FilteredGrid = dgExData;
        //    GlobalVariables.RDataIsDirty = true;
        //}

        //private void ClearFilterButton_Click(object sender, EventArgs e)
        //{
        //    dgExData.ClearFilter(true);
        //}

        //private void ClearSortButton_Click(object sender, EventArgs e)
        //{
        //    dgExData.ClearSort(true);
        //}

        //private void BindingSource_ListChanged(object sender, ListChangedEventArgs e)
        //{
        //    this.searchToolBar.SetColumns(dgExData.Columns);
        //}

        //private void SearchToolBar_Search(object sender, SearchToolBarSearchEventArgs e)
        //{
        //    int startColumn = 0;
        //    int startRow = 0;
        //    if (!e.FromBegin)
        //    {
        //        bool endcol = dgExData.CurrentCell.ColumnIndex + 1 >= dgExData.ColumnCount;
        //        bool endrow = dgExData.CurrentCell.RowIndex + 1 >= dgExData.RowCount;

        //        if (endcol && endrow)
        //        {
        //            startColumn = dgExData.CurrentCell.ColumnIndex;
        //            startRow = dgExData.CurrentCell.RowIndex;
        //        }
        //        else
        //        {
        //            startColumn = endcol ? 0 : dgExData.CurrentCell.ColumnIndex + 1;
        //            startRow = dgExData.CurrentCell.RowIndex + (endcol ? 1 : 0);
        //        }
        //    }
        //    DataGridViewCell c = dgExData.FindCell(
        //        e.ValueToSearch,
        //        e.ColumnToSearch?.Name,
        //        startRow,
        //        startColumn,
        //        e.WholeWord,
        //        e.CaseSensitive);

        //    if (c != null)
        //        dgExData.CurrentCell = c;
        //}

        //private void SearchButton_Click(object sender, EventArgs e)
        //{
        //    if (this.btnSearch.Checked)
        //    {
        //        this.searchToolBar.Show();
        //        btnSearch.CheckState = CheckState.Unchecked;
        //    }
        //    else
        //    {
        //        this.searchToolBar.Hide();
        //        btnSearch.CheckState = CheckState.Checked;
        //    }
        //}

        //private void SearchToolBar_VisibleChanged(object sender, EventArgs e)
        //{
        //    this.btnSearch.Checked = this.searchToolBar.Visible;
        //}

        private void DgExData_CellContentClick(object sender, GridCellButtonClickedEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            //var dg = (DataGridView)sender;
            Syncfusion.Windows.Forms.Grid.GridRangeInfoList ranges = dgExData.Selections.GetSelectedRows(true,false);
            int nColIndex = dgExData.Binder.NameToColIndex("EXPERIMENTS_JSONB_ID");
            Int32.TryParse(dgExData[e.RowIndex, nColIndex].CellValue.ToString(), out int nJsonId);
            switch (e.ColIndex == 2 ? "DELETE":(e.ColIndex == 1) ? "EDIT":"DEFAULT")
            {
                case "DELETE":
                    if (!_commonUtil.DataLockExists(GlobalVariables.ExperimentNode.ExperimentNode.ID, nJsonId, "EXPERIMENTS_JSONB"))
                    {
                        dgExData.DeleteRecordsAtRowIndex(e.RowIndex, e.RowIndex);
                        _commonUtil.SerializeJson(null, nJsonId, "DELETE");
                        if (e.RowIndex - 1 >= 0)
                        {
                            dgExData.Model.Selections.Add(Syncfusion.Windows.Forms.Grid.GridRangeInfo.Row(e.RowIndex));  
                            dgExData.SetTopRow(e.RowIndex-1);
                        }
                        //SaveData(nJsonId, "DELETE");
                    }
                    else
                    {
                        MessageBox.Show("The row you are trying to delete is currently locked by another user and cannot be edited at this time.", "Row Locked",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    break;
                case "EDIT":

                    try
                    {
                        if (!_commonUtil.DataLockExists(GlobalVariables.ExperimentNode.ExperimentNode.ID, nJsonId, "EXPERIMENTS_JSONB"))
                        {
                            _commonUtil.CreateDataLock(GlobalVariables.ExperimentNode.ExperimentNode.ID, nJsonId, "EXPERIMENTS_JSONB", "EDIT");
                            EditRow(e.RowIndex, nJsonId);
                        }
                        else
                        {
                            MessageBox.Show("The row you are trying to edit is currently locked by another user and cannot be edited at this time.", "Row Locked",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    finally
                    {
                        _commonUtil.DeleteDataLock(GlobalVariables.Experiment.ID, e.RowIndex, "EXPERIMENTS_JSONB");
                    }
                    break;
                default:
                    break;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveData(0);
        }

        public void SaveData(int nJsonID, string sAction = "")
        {
            DataTable dt = dtAnimals.GetChanges();
            if (dt == null && string.IsNullOrEmpty(sAction))
                return;
            if (sAction.Equals("DELETE"))
                _commonUtil.SerializeJson(null, nJsonID, sAction);
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    nJsonID = Convert.ToInt32(dr["EXPERIMENTS_JSONB_ID"]);
                    string action = "";
                    if (dr.RowState == DataRowState.Modified)
                        action = "MODIFIED";
                    else if (dr.RowState == DataRowState.Added)
                        action = "ADDED";
                    else if (dr.RowState == DataRowState.Deleted)
                        action = "DELETED";

                    _commonUtil.SerializeJson(dr, nJsonID, action);
                }
            }
            Initialize(GlobalVariables.ExperimentNode.ExperimentNode.ID);
            bDataDirty = false;
        }

        //private void BtnJSON_Click(object sender, EventArgs e)
        //{
        //    DataTable dt = (_bindingSource.DataSource as DataTable).Copy();
        //    foreach(DataColumn col in dtAnimals.Columns)
        //    {
        //        dt.Columns[col.ColumnName].ColumnName = col.Caption;
        //    }
        //}

    }

    public class CloseCtlAnimalData : EventArgs
    {
        public CloseCtlAnimalData()
        {
            return;
        }
    }
}
