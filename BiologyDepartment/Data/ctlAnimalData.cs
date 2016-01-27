using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
using System.IO;
using System.Reflection;
using ClosedXML.Excel;
using BiologyDepartment.Misc_Files;

namespace BiologyDepartment
{
    public partial class ctlAnimalData : UserControl
    {
        private DataTable dtExperiments = new DataTable();
        private daoData _daoData = new daoData();
        private int intID= 0;
        private System.Collections.ArrayList fishList = new System.Collections.ArrayList();
        private DataTable sexList = new DataTable();
        private DgvFilterManager filterManager;
        private BindingSource _bindingSource = new BindingSource();
        private Npgsql.NpgsqlDataAdapter adapterCore;
        private Npgsql.NpgsqlDataAdapter adapterCustom;
        private Npgsql.NpgsqlDataAdapter adapterData;
        private DgvComboBoxColumnFilter ExcludeFilter;

        public event EventHandler<CloseCtlAnimalData> CloseFormEvent;

        public ctlAnimalData()
        {
            InitializeComponent();
        }

        public void Initialize(int id)
        {
            intID = id;
            filterManager = new DgvFilterManager();
            filterManager.ColumnFilterAdding += new ColumnFilterEventHandler(fm_ColumnFilterAdding);
            GetData();
            dgExData.DataSource = _bindingSource;
            AddGridButtons();
            filterManager.DataGridView = dgExData;
        }

        private void AddGridButtons()
        {
            if (!dgExData.Columns.Contains("EDIT"))
            {
                DataGridViewEditButtonColumn btnEdit = new DataGridViewEditButtonColumn();
                dgExData.Columns.Insert(0, btnEdit);
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
            }

            dgExData.Columns["EXCLUDE"].Visible = false;
            //dgExData.Columns["ADD"].DefaultCellStyle.Font = new Font("Arial", 22F, GraphicsUnit.Pixel);
            //dgExData.Columns["DELETE"].DefaultCellStyle.Font = new Font("Arial", 22F, GraphicsUnit.Pixel);

            /*foreach(DataGridViewRow row in dgExData.Rows)
            {
                row.Cells["ADD"].Value = "+";
                row.Cells["DELETE"].Value = "X";
                if (Convert.ToString(row.Cells["EXCLUDE_ROW"].Value).Equals("Y"))
                    row.Cells["EXCLUDE"].Value = 1;
                else
                    row.Cells["EXCLUDE"].Value = 0;
            }*/

        }

        private void GetData()
        {
            DataTable dtCore = new DataTable();
            DataTable dtCustom= new DataTable();
            DataTable dtData = new DataTable();
            DataSet dsBind = new DataSet();
            DataColumn dcParent;
            DataColumn dcChild;

            adapterCore = new Npgsql.NpgsqlDataAdapter();
            adapterCustom = new Npgsql.NpgsqlDataAdapter();
            adapterData = new Npgsql.NpgsqlDataAdapter();

            adapterCore = _daoData.DataAdapterCore(intID);
            adapterCustom = _daoData.DataAdapterCustom(intID);
            adapterData = _daoData.DataAdapterData(intID);

            adapterCore.Fill(dtCore);
            adapterCustom.Fill(dtCustom);
            adapterData.Fill(dtData);

            if(dtCore.Rows.Count > 0 && dtCustom.Rows.Count > 0)
            {
                if(!dsBind.Tables.Contains("dtCore"))
                    dsBind.Tables.Add(dtCore);
                if(!dsBind.Tables.Contains("dtCustom"))
                    dsBind.Tables.Add(dtCustom);

                dcParent = dsBind.Tables["dtCore"].Columns["EX_ID"];
                dcChild = dsBind.Tables["dtCustom"].Columns["EX_ID"];
                dsBind.Relations.Add("drCoreCustom", dcParent, dcChild);
            }

            if (dtCore.Rows.Count > 0 && dtData.Rows.Count > 0)
            {
                if(!dsBind.Tables.Contains("dtCore"))
                    dsBind.Tables.Add(dtCore);
                if(!dsBind.Tables.Contains("dtData"))
                    dsBind.Tables.Add(dtData);

                dcParent = dsBind.Tables["dtCore"].Columns["EX_CORE_COL_ID"];
                dcChild = dsBind.Tables["dtData"].Columns["EX_CORE_COL_ID"];
                dsBind.Relations.Add("drCoreData", dcParent, dcChild);
            }

            if (dtCustom.Rows.Count > 0 && dtData.Rows.Count > 0)
            {
                if (!dsBind.Tables.Contains("dtCustom"))
                    dsBind.Tables.Add(dtCustom);
                if (!dsBind.Tables.Contains("dtData"))
                    dsBind.Tables.Add(dtData);

                dcParent = dsBind.Tables["dtCore"].Columns["CUSTOM_COLUMNS_ID"];
                dcChild = dsBind.Tables["dtData"].Columns["CUSTOM_COLUMNS_ID"];
                dsBind.Relations.Add("drCustomData", dcParent, dcChild);
            }
            
            _bindingSource.DataSource = dsBind;
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
                        btnDelete.Enabled = false;
                        btnEdit.Enabled = false;
                        btnAdd.Enabled = false;
                        break;
                    case "Admin":
                    case "Owner":
                        btnDelete.Enabled = true;
                        btnEdit.Enabled = true;
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

        private void btnExclude_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow dgr in dgExData.SelectedRows)
            {
                if (dgr.Cells["EXCLUDE_ROW"].Value.ToString().Equals("N"))
                    dgr.Cells["EXCLUDE_ROW"].Value = 'Y';
                else
                    dgr.Cells["EXCLUDE_ROW"].Value = 'N';

                _daoData.UpdateCore(intID, Convert.ToInt32(dgr.Cells["FI_ID"].Value.ToString()), dgr.Cells["EXCLUDE_ROW"].Value.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgr in dgExData.SelectedRows)
                _daoData.UpdateDeleteRow(intID);

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

        private void dgExData_BindingContextChanged(object sender, EventArgs e)
        {
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
    }

    public class CloseCtlAnimalData : EventArgs
    {
        public CloseCtlAnimalData()
        {
            return;
        }
    }
}
