using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BiologyDepartment.Misc_Files;
using System.Linq;
using System.Collections.ObjectModel;
using System.Drawing;

namespace BiologyDepartment
{

    public partial class ctlExperiments : UserControl
    {
        //private static frmExperiments inst;
        private daoExperiments _daoExperiments = new daoExperiments();
        private ExperimentsUtility exUtil = new ExperimentsUtility();
        private DataSet dsExperiments = new DataSet();
        private DataTable dtExperiments = new DataTable();
        private DataTable dtParentExperiments = new DataTable();
        private DataTable dtSQL = new DataTable();
        private List<string> txtBoxList = new List<string>();
        private bool bEnableButtons = false;
        private bool bEdit = false;
        private bool bDelete = false;
        private bool bIsNew = false;
        private Experiments exp = new Experiments();
        private Experiments oldExp = new Experiments();
        private List<DataGridView> lstDGV = new List<DataGridView>();
        private List<BindingSource> lstBindSource = new List<BindingSource>();
        public bool bLoad = true;
        string[] colors = Enum.GetNames(typeof(KnownColor));

        enum GridBackGround
        {
            
        };

        public event EventHandler<ExperimentHasChanged> ChangeExperimentEvent;

        public ctlExperiments()
        {
            InitializeComponent();
        }

        public void Intialize()
        {
            bLoad = true;
            GlobalVariables.GlobalConnection = new dbBioConnection();
            LoadImages();
            frmRefresh();
        }

        private void LoadImages()
        {
            if (GlobalVariables.Images.Images.Count == 0)
            {
                System.Reflection.Assembly thisExe = System.Reflection.Assembly.GetExecutingAssembly();
                System.IO.Stream file;
                file = thisExe.GetManifestResourceStream("BiologyDepartment.Misc_Files.images.addicon.png");
                GlobalVariables.AddImage("AddIcon", Image.FromStream(file));
                file = thisExe.GetManifestResourceStream("BiologyDepartment.Misc_Files.images.addicon16.png");
                GlobalVariables.AddImage("AddIcon16", Image.FromStream(file));
                file = thisExe.GetManifestResourceStream("BiologyDepartment.Misc_Files.images.deleteicon.png");
                GlobalVariables.AddImage("DeleteIcon", Image.FromStream(file));
                file = thisExe.GetManifestResourceStream("BiologyDepartment.Misc_Files.images.deleteicon16.png");
                GlobalVariables.AddImage("DeleteIcon16", Image.FromStream(file));
                file = thisExe.GetManifestResourceStream("BiologyDepartment.Misc_Files.images.editicon.png");
                GlobalVariables.AddImage("EditIcon", Image.FromStream(file));
                file = thisExe.GetManifestResourceStream("BiologyDepartment.Misc_Files.images.editicon16.png");
                GlobalVariables.AddImage("EditIcon16", Image.FromStream(file));
                file = thisExe.GetManifestResourceStream("BiologyDepartment.Misc_Files.images.expand.png");
                GlobalVariables.AddImage("Expand", Image.FromStream(file));
                file = thisExe.GetManifestResourceStream("BiologyDepartment.Misc_Files.images.toggle.png");
                GlobalVariables.AddImage("Toggle", Image.FromStream(file));
            }
        }

        private void DataLoading_Shown(object sender, EventArgs e)
        {
            GlobalVariables.DataLoading.ProgressBarStep(15);
            this.dgExperiments.SelectionChanged -= this.dgExperiments_SelectionChanged;
            bLoad = true;
            GlobalVariables.DataLoading.ProgressBarStep(50);
            GlobalVariables.GlobalConnection = new dbBioConnection();
            dsExperiments = exUtil.GetExperimentsDataSet();
            dtExperiments = dsExperiments.Tables[0];
            SetComboBox();
            SetExperiment();
            setGrid();
            GlobalVariables.DataLoading.ProgressBarStep(75);
            this.dgExperiments.SelectionChanged += new System.EventHandler(this.dgExperiments_SelectionChanged);

            GlobalVariables.DataLoading.ProgressBarStep(100);
            GlobalVariables.DataLoading.Hide();
            GlobalVariables.DataLoading.Shown -= this.DataLoading_Shown;
        }

        private void SetExperiment()
        {
            if (lstDGV.Count == 0)
                return;
            SetOldExperiment(false);
            exp.Alias = txtSName.Text;
            exp.Title = txtOfficialName.Text;
            exp.SDate = sDatePicker.Text;
            exp.EDate = eDatePicker.Text;
            exp.Hypo = rtxtHypo.Text;
            if (cmbParentEx.SelectedValue != null)
                exp.ParentEx = Convert.ToInt32(cmbParentEx.SelectedValue.ToString());
            if (bIsNew)
                exp.ID = 0;
            else if(!string.IsNullOrEmpty(txtExID.Text))
                exp.ID = Convert.ToInt32(txtExID.Text);
            
            exUtil.SetExperiment(exp);
        }

        private void enableListBox()
        {
            txtBoxList.Clear();
            txtBoxList.Add(txtSName.Text);
            txtBoxList.Add(txtOfficialName.Text);
            txtBoxList.Add(sDatePicker.Value.ToShortDateString());
            txtBoxList.Add(eDatePicker.Value.ToShortDateString());
            if (cmbParentEx == null || cmbParentEx.SelectedValue == null)
                txtBoxList.Add("");
            else
                txtBoxList.Add(cmbParentEx.SelectedValue.ToString());
            txtBoxList.Add(rtxtHypo.Text);
        }

        private void SetComboBox()
        {
            dtExperiments.Clear();
            dtExperiments = dsExperiments.Tables[0].Clone();
            foreach(DataTable dt in dsExperiments.Tables)
            {
                foreach (DataRow dr in dt.Rows)
                    dtExperiments.Rows.Add(dr.ItemArray);
            }
            exUtil.SetComboBox(ref cmbParentEx, ref dtExperiments);
        }

        private void SetRecord(int nGridIndex)
        {
            if (lstDGV.Count > 0 && lstDGV.Count > nGridIndex && lstDGV[nGridIndex].SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in lstDGV[nGridIndex].SelectedRows)
                {
                    txtExID.Text = row.Cells["ex_id"].Value.ToString();
                    txtSName.Text = row.Cells["ex_alias"].Value.ToString();
                    txtOfficialName.Text = row.Cells["ex_title"].Value.ToString();
                    if (String.IsNullOrEmpty(row.Cells["ex_sdate"].Value.ToString())
                        || String.IsNullOrEmpty(row.Cells["ex_edate"].Value.ToString()))
                        break;
                    sDatePicker.Value = (Convert.ToDateTime(row.Cells["ex_sdate"].Value.ToString()));
                    eDatePicker.Value = (Convert.ToDateTime(row.Cells["ex_edate"].Value.ToString()));
                    rtxtHypo.Text = row.Cells["ex_hypothesis"].Value.ToString();
                    txtSName.Enabled = false;
                    txtOfficialName.Enabled = false;
                    sDatePicker.Enabled = false;
                    eDatePicker.Enabled = false;
                    rtxtHypo.Enabled = false;
                    cmbParentEx.SelectedValue = Convert.ToInt32(row.Cells["ex_parent_id"].Value.ToString());
                    bEnableButtons = exUtil.EnableDisableButtons(row.Cells["permissions"].Value.ToString());

                    btnDelete.Enabled = bEnableButtons;
                    btnEdit.Enabled = bEnableButtons;
                    btnPermissions.Enabled = bEnableButtons;
                    btnSave.Enabled = bEnableButtons;
                    sDatePicker.Enabled = bEnableButtons;
                    eDatePicker.Enabled = bEnableButtons;
                    txtOfficialName.Enabled = bEnableButtons;
                    txtSName.Enabled = bEnableButtons;
                    rtxtHypo.Enabled = bEnableButtons;
                }
            }
            SetExperiment();
        }

        private void setGrid()
        {
            bLoad = true;
            lstBindSource.Clear();
            lstDGV.Clear();
            for (int i = 0; i < dsExperiments.Tables.Count; i++)
            {
                DataGridView dgv = new DataGridView();
                BindingSource theBind = new BindingSource();
                theBind.DataSource = dsExperiments.Tables[i];
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (!dgv.Columns.Contains("showChild"))
                {
                    DataGridViewImageColumn btnChild = new DataGridViewImageColumn();
                    btnChild.Name = "showChild";
                    btnChild.HeaderText = "";
                    btnChild.ReadOnly = false;
                    btnChild.Tag = "Expand";
                    btnChild.Image = GlobalVariables.Images.Images["Expand"];
                    dgv.Columns.Insert(0, btnChild);
                }

                dgv.ReadOnly = true;
                dgv.Name = i.ToString();

                lstBindSource.Add(theBind);

                lstDGV.Add(dgv);
                lstDGV[i].DataSource = "";
                lstDGV[i].DataSource = lstBindSource[i];
                lstDGV[i].AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                lstDGV[i].ScrollBars = ScrollBars.Both;
                lstDGV[i].ClearSelection();
                lstDGV[i].SelectionChanged += new System.EventHandler(this.dgExperiments_SelectionChanged);
                splitContainer1.Panel2.Controls.Add(lstDGV[i]);
                lstDGV[i].Visible = false;

            }
            lstDGV[0].CellClick += new DataGridViewCellEventHandler(DGVNested_CellContentClick_Event);
            lstDGV[0].Dock = DockStyle.Fill;
            dgExperiments.Visible = false;
        }

        private void enableControls(bool bEnable)
        {
            sDatePicker.Enabled = bEnable;
            txtOfficialName.Enabled = bEnable;
            txtSName.Enabled = bEnable;
            eDatePicker.Enabled = bEnable;
            rtxtHypo.Enabled = bEnable;
            btnSave.Enabled = bEnable;
            dgExperiments.ReadOnly = bEnable;
            if (bEnable == true)
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (btnNew.Text.Equals("New Experiment"))
            {
                enableControls(true);
                sDatePicker.Value = DateTime.Now;
                txtOfficialName.Text = "";
                txtSName.Text = "";
                eDatePicker.Value = DateTime.Now;
                rtxtHypo.Text = "";
                btnNew.Text = "Cancel";
                enableListBox();
            }
            else
            {
                frmRefresh();
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            enableListBox();

            foreach (string txtBox in txtBoxList)
            {
                switch (txtBox)
                {
                    case "":
                    case null:
                        {
                            MessageBox.Show("Please fill in all fields.", "Null Value Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;

                        }
                    default:
                        break;
                }
            }

            SetExperiment();

            if (bEdit || exp.ID > 0)
            {
                _daoExperiments.updateRecord(exp, false);
                bEdit = false;
            }
            else if (bDelete)
            {
                _daoExperiments.deleteRecord(txtExID.Text, false);
                bDelete = false;
            }
            else
            {
                exp.ID = _daoExperiments.insertRecord(exp, false);
                if (exp.ID > 0)
                    bIsNew = false;
                else
                    SetOldExperiment(true);
            }

            frmRefresh();

        }

        private void SetOldExperiment(bool bResetExperiment)
        {
            if (!bResetExperiment)
            {
                int id = exp.ID;
                string alias = exp.Alias;
                string title = exp.Title;
                string start = exp.SDate;
                string end = exp.EDate;
                string hypo = exp.Hypo;
                oldExp.ID = id;
                oldExp.Alias = alias;
                oldExp.Title = title;
                oldExp.SDate = start;
                oldExp.EDate = start;
                oldExp.Hypo = hypo;
            }
            else
            {
                int id = oldExp.ID;
                string alias = oldExp.Alias;
                string title = oldExp.Title;
                string start = oldExp.SDate;
                string end = oldExp.EDate;
                string hypo = oldExp.Hypo;
                exp.ID = id;
                exp.Alias = alias;
                exp.Title = title;
                exp.SDate = start;
                exp.EDate = start;
                exp.Hypo = hypo;
            }

        }

        public void frmRefresh()
        {
            bLoad = true;
            dsExperiments = exUtil.GetExperimentsDataSet();
            btnNew.Text = "New Experiment";
            btnDelete.Text = "Delete";
            SetComboBox();
            SetRecord(0);
            setGrid();
            enableControls(false);
            enableListBox();
            bEdit = false;
            bDelete = false;

            //SetExperiment();
            foreach (var grid in lstDGV)
                grid.ClearSelection();
            lstDGV[0].Visible = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            enableControls(true);
            btnNew.Text = "Cancel";
            bEdit = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //_daoAuthorEX.deleteAllRecords(Convert.ToInt32(cbExperiments.SelectedValue.ToString()));
            _daoExperiments.deleteRecord(txtExID.Text, false);
            frmRefresh();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            frmRefresh();
        }

        private void dgExperiments_SelectionChanged(object sender, EventArgs e)
        {
            if (bLoad)
                return;
            var grid = (DataGridView)sender;
            int nGridIndex = Convert.ToInt32(grid.Name);
            SetRecord(nGridIndex);
            OnExperimentChangedEvent(new ExperimentHasChanged(GlobalVariables.Experiment.ID, bLoad));
        }

        protected virtual void OnExperimentChangedEvent(ExperimentHasChanged e)
        {
            EventHandler<ExperimentHasChanged> handler = ChangeExperimentEvent;

            // Event will be null if there are no subscribers 
            if (handler != null)
            {
                // Use the () operator to raise the event.
                handler(this, e);
            }
        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            bIsNew = true;
            txtOfficialName.Clear();
            txtSName.Clear();
            rtxtHypo.Clear();
            sDatePicker.Value = DateTime.Now;
            eDatePicker.Value = DateTime.Now;
            btnSave.Enabled = true;
        }

        private void dgExperiments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewEditButtonCell buttonCell = (DataGridViewEditButtonCell)dgExperiments.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (buttonCell.Enabled)
            {
                buttonCell.Enabled = false;
                dgExperiments.InvalidateCell(dgExperiments.Rows[e.RowIndex].Cells[e.ColumnIndex]);
            }
            else
            { }
        }

        private void DGVNested_CellContentClick_Event(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            int nGrid = Convert.ToInt32(grid.Name) + 1;
            bLoad = false;
            lstDGV[0].ClearSelection();
            lstDGV[1].ClearSelection();
            lstDGV[2].ClearSelection();

            switch (grid.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name)
            {
                case "showChild":

                    if (nGrid >= lstDGV.Count)
                    {
                        MessageBox.Show("No Details Found");
                        lstDGV[Convert.ToInt32(grid.Name)].Rows[e.RowIndex].Selected = true;
                        return;
                    }

                    DataView detailView = new DataView((DataTable)lstBindSource[nGrid].DataSource);
                    String Filterexpression = grid.Rows[e.RowIndex].Cells["ex_id"].Value.ToString();
                    detailView.RowFilter = "ex_parent_id = '" + Filterexpression + "'";

                    if (detailView.Count <= 0)
                    {
                        MessageBox.Show("No Details Found");
                        lstDGV[Convert.ToInt32(grid.Name)].Rows[e.RowIndex].Selected = true;
                        return;
                    }

                    // cols.Image = Image.FromFile(ImageName);
                    if (string.IsNullOrEmpty(Convert.ToString(grid.Rows[e.RowIndex].Cells["showChild"].Tag)) ||
                        Convert.ToString(grid.Rows[e.RowIndex].Cells["showChild"].Tag).Equals("Expand"))
                    {
                        lstDGV[nGrid].Visible = true;
                        lstDGV[nGrid].CellClick += new DataGridViewCellEventHandler(DGVNested_CellContentClick_Event);
                        grid.Rows[e.RowIndex].Cells["showChild"].Value = GlobalVariables.Images.Images["Toggle"];
                        grid.Rows[e.RowIndex].Cells["showChild"].Tag = "Toggle";

                        grid.Controls.Add(lstDGV[nGrid]);

                        Rectangle dgvRectangle = grid.GetCellDisplayRectangle(1, e.RowIndex, true);

                        lstDGV[nGrid].Location = new Point(dgvRectangle.X - 150, dgvRectangle.Y + grid.Rows[e.RowIndex].Height);
                        lstDGV[nGrid].Size =
                            new Size(grid.Width, grid.Rows[e.RowIndex].Height + (grid.Rows[e.RowIndex].Height * (detailView.Count + 3)));
                        lstDGV[nGrid].BringToFront();
                        foreach (DataGridViewRow dgr in lstDGV[nGrid].Rows)
                        {
                            dgr.Selected = false;
                            foreach (DataGridViewCell dgc in dgr.Cells)
                            {
                                dgc.Style.BackColor = Color.FromName(colors[nGrid]);
                                dgc.Style.ForeColor = Color.Yellow;
                            }
                        }

                    }
                    else
                    {
                        grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = GlobalVariables.Images.Images["Expand"];
                        grid.Rows[e.RowIndex].Cells["showChild"].Tag = "Expand";
                        lstDGV[nGrid].Visible = false;
                        lstDGV[nGrid].CellClick -= new DataGridViewCellEventHandler(DGVNested_CellContentClick_Event);
                    }
                    break;
            }

            lstDGV[Convert.ToInt32(grid.Name)].Rows[e.RowIndex].Selected = true;
        }
    }
    

    public class ExperimentHasChanged : EventArgs
    {
        public ExperimentHasChanged(int ID, bool Loading)
        {
            EX_ID = ID;
            isLoading = Loading;
        }

        public ExperimentHasChanged()
        {
            // TODO: Complete member initialization
        }
        private int EX_ID;
        private bool isLoading = false;
        public int ID
        {
            get { return EX_ID; }
        }
        public bool Loading
        {
            get { return isLoading; }
        }

    }
}
