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

namespace BiologyDepartment
{
    public partial class ctlAnimalData : UserControl
    {
        private DataTable dtExperiments = new DataTable();
        private daoData _daoData = new daoData();
        private int intID= 0;
        private System.Collections.ArrayList fishList = new System.Collections.ArrayList();
        private DataTable sexList = new DataTable();
        private BindingSource _bindingSource = new BindingSource();
        private List<AnimalData> animalAgg = new List<AnimalData>();
        private List<CustomColumns> animalCols = new List<CustomColumns>();
        private DataTable dtAnimals = new DataTable();

        public event EventHandler<CloseCtlAnimalData> CloseFormEvent;

        public ctlAnimalData()
        {
            InitializeComponent();
        }

        public void Initialize(int id)
        {
            intID = id;
            GetData();
            SetGrid();
        }

        private void SetGrid()
        {
            _bindingSource.ListChanged -= new ListChangedEventHandler(bindingSource_ListChanged);
            _bindingSource.ListChanged += new ListChangedEventHandler(bindingSource_ListChanged);

            if (!dgExData.Columns.Contains("EDIT"))
            {
                DataGridViewEditButtonColumn btnEdit = new DataGridViewEditButtonColumn();
                dgExData.Columns.Insert(0, btnEdit);
                dgExData.Columns["EDIT"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgExData.DisableFilter(dgExData.Columns["EDIT"]);
            }

            if (!dgExData.Columns.Contains("DELETE"))
            {
                DataGridViewButtonColumn btnDel = new DataGridViewButtonColumn();
                btnDel.HeaderText = "DELETE";
                btnDel.Name = "DELETE";
                btnDel.Text = "-";
                btnDel.Width = 50;
                btnDel.FlatStyle = FlatStyle.Popup;
                btnDel.DefaultCellStyle.ForeColor = Color.Red;
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
            dgExData.Columns["Exclude_Row"].Visible = false;

            _bindingSource.DataSource = dtAnimals;
            dgExData.DataSource = _bindingSource;

            foreach(DataColumn col in dtAnimals.Columns)
            {
                dgExData.Columns[col.ColumnName].HeaderText = col.Caption;
            }

            this.searchToolBar.SetColumns(dgExData.Columns);

            foreach(DataGridViewRow dgvr in dgExData.Rows)
            {
                CheckExcludeState(dgvr.Index);
            }
        }

        private void GetData()
        {
            Stopwatch sw = new Stopwatch();
            Trace.WriteLine("GetData start stopwatch");
            sw.Start();
            animalAgg = _daoData.BulkExport();
            animalCols = _daoData.GetColumns();
            int colPosition = 0;
            foreach(CustomColumns col in animalCols)
            {
                DataColumn newCol = new DataColumn();
                if(!dtAnimals.Columns.Contains(Convert.ToString(col.ColID)))
                {
                    newCol.ColumnName = Convert.ToString(col.ColID);
                    switch(col.ColDataType)
                    {
                        case "INTEGER":
                            newCol.DataType = System.Type.GetType("System.Int32");
                            break;
                        case "DECIMAL":
                            newCol.DataType = System.Type.GetType("System.Decimal");
                            break;
                        case "CHARACTER":
                            newCol.DataType = System.Type.GetType("System.String");
                            break;
                        case "DATE/TIME":
                            newCol.DataType = System.Type.GetType("System.DateTime");
                            break;
                        case "IMAGE":
                            newCol.DataType = System.Type.GetType("System.Byte");
                            break;
                    }
                    newCol.Caption = col.ColName;
                    dtAnimals.Columns.Add(newCol);
                    dtAnimals.Columns[newCol.ColumnName].SetOrdinal(colPosition);
                    colPosition++;
                }
            }
            if(!dtAnimals.Columns.Contains("DataID"))
            {
                DataColumn newCol = new DataColumn();
                newCol.ColumnName = "DataID";
                newCol.DataType = System.Type.GetType("System.Int32");
                newCol.Caption = "Row ID";
                dtAnimals.Columns.Add(newCol);
                dtAnimals.Columns[newCol.ColumnName].SetOrdinal(colPosition);
                colPosition++;
            }

            if(!dtAnimals.Columns.Contains("ExcludeRow"))
            {
                DataColumn newCol = new DataColumn();
                newCol.ColumnName = "ExcludeRow";
                newCol.DataType = System.Type.GetType("System.String");
                newCol.Caption = "Exclude Row";
                dtAnimals.Columns.Add(newCol);
                dtAnimals.Columns[newCol.ColumnName].SetOrdinal(colPosition);
                colPosition++;
            }

            foreach(AnimalData animal in animalAgg)
            {
                DataRow row = dtAnimals.NewRow();
                row["DataID"] = animal.DataID;
                row["ExcludeRow"] = animal.ExcludeRow;

                foreach(KeyValuePair<int, string> entry in animal.AggDictionary)
                {
                    string sType = Convert.ToString(dtAnimals.Columns[Convert.ToString(entry.Key)].DataType);
                    if (string.IsNullOrEmpty(entry.Value))
                        row[Convert.ToString(entry.Key)] = DBNull.Value;
                    else
                    {
                        switch (sType)
                        {
                            case "System.String":
                                row[Convert.ToString(entry.Key)] = Convert.ToString(entry.Value);
                                break;
                            case "System.Int32":
                                row[Convert.ToString(entry.Key)] = Convert.ToInt32(entry.Value);
                                break;
                            case "System.Decimal":
                                row[Convert.ToString(entry.Key)] = Convert.ToDecimal(entry.Value);
                                break;
                            case "System.DateTime":
                                row[Convert.ToString(entry.Key)] = Convert.ToDateTime(entry.Value);
                                break;
                        }
                    }
                }

                dtAnimals.Rows.Add(row);
            }

            sw.Stop();
            Trace.WriteLine("Elapsed:  " + sw.Elapsed);
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmExDataEntry _frmFishData = frmExDataEntry.CreateInstance(intID);
            _frmFishData.StartPosition = FormStartPosition.WindowsDefaultLocation;
            _frmFishData.Show();
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
            int row = Convert.ToInt32(dgExData.Rows[e.RowIndex].Cells["FI_ID"].Value);
            using (frmExDataEntry _frmFishData = frmExDataEntry.CreateInstance(intID, row))
            {
                _frmFishData.StartPosition = FormStartPosition.WindowsDefaultLocation;
                _frmFishData.ShowDialog();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int selectedrowindex = dgExData.SelectedCells[0].RowIndex;
            int row = Convert.ToInt32(dgExData.Rows[selectedrowindex].Cells["FI_ID"].Value);
            using (frmExDataEntry _frmFishData = frmExDataEntry.CreateInstance(intID, row))
            {
                _frmFishData.StartPosition = FormStartPosition.WindowsDefaultLocation;
                _frmFishData.ShowDialog();
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
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Creating DataTable
                DataTable dt = new DataTable();

                //Adding the Columns
                foreach (DataGridViewColumn column in dgExData.Columns)
                {
                    dt.Columns.Add(column.HeaderText, column.ValueType);
                }

                //Adding the Rows
                foreach (DataGridViewRow row in dgExData.Rows)
                {
                    dt.Rows.Add();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != DBNull.Value && cell.Value != null)
                            dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value;
                        else
                            dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = DBNull.Value;
                    }
                }
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt, "Customers");
                    if(!string.IsNullOrEmpty(saveFileDialog1.FileName))
                        wb.SaveAs(saveFileDialog1.FileName);
                }
            }
        }

        private void dataGridView_SortStringChanged(object sender, EventArgs e)
        {
            _bindingSource.Sort = dgExData.SortString;
        }

        private void dataGridView_FilterStringChanged(object sender, EventArgs e)
        {
            _bindingSource.Filter = dgExData.FilterString;
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
            switch(e.ColumnIndex.ToString())
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
                
            }
        }


        public void fm_ColumnFilterAdding(object sender, ColumnFilterEventArgs e)
        {
            switch (e.Column.Name)
            {
                case "EXCLUDE":
                    //e.ColumnFilter = new DgvComboBoxColumnFilter();
                    break;
                default:
                    e.ColumnFilter = new DgvBaseColumnFilter();
                    break;
            }
        }

        private void dgExData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dg = (DataGridView)sender;

            switch(dg.Columns[e.ColumnIndex].Name)
            {
                case "DELETE":
                    dgExData.Rows.RemoveAt(e.RowIndex);
                    break;
                case "EDIT":
                    break;
                case "EXCLUDE":
                    CheckExcludeState(e.RowIndex);
                    break;
            }
        }

        private void CheckExcludeState(int nRowIndex)
        {
            if (dgExData.Rows[nRowIndex].Cells["EXCLUDE_ROW"].Value.ToString().Equals("N"))
            {
                dgExData.Rows[nRowIndex].Cells["EXCLUDE_ROW"].Value = 'Y';
                dgExData.Rows[nRowIndex].Cells["EXCLUDE"].Value = true;
            }
            else
            {
                dgExData.Rows[nRowIndex].Cells["EXCLUDE_ROW"].Value = 'N';
                dgExData.Rows[nRowIndex].Cells["EXCLUDE"].Value = false;
            }
        }

        private void dgExData_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

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
