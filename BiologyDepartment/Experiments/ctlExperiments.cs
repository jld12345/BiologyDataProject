using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BiologyDepartment
{

    public partial class ctlExperiments : UserControl
    {
        //private static frmExperiments inst;
        private daoExperiments _daoExperiments = new daoExperiments();
        private ExperimentsUtility exUtil = new ExperimentsUtility();

        private DataSet dsExperiments = new DataSet();
        private DataTable dtExperiments = new DataTable();
        private DataTable dtSQL = new DataTable();
        private List<string> txtBoxList = new List<string>();
        private bool bEnableButtons = false;
        private bool bEdit = false;
        private bool bDelete = false;
        private Experiments exp = new Experiments();
        public bool bLoad = true;


        public event EventHandler<ExperimentHasChanged> ChangeExperimentEvent;

        public ctlExperiments()
        {
            InitializeComponent();
        }

        public void Intialize()
        {
            GlobalVariables.DataLoading.Shown += new System.EventHandler(this.DataLoading_Shown);
            GlobalVariables.DataLoading.ShowDialog();
        }

        private void DataLoading_Shown(object sender, EventArgs e)
        {
            GlobalVariables.DataLoading.ProgressBarStep(15);
            this.dgExperiments.SelectionChanged -= this.dgExperiments_SelectionChanged;
            this.SuspendLayout();
            bLoad = true;
            GlobalVariables.DataLoading.ProgressBarStep(50);
            GlobalVariables.GlobalConnection = new dbBioConnection();
            dsExperiments = _daoExperiments.getExperiments();
            dtExperiments = dsExperiments.Tables[0];
            SetComboBox();
            SetExperiment();
            setGrid();
            GlobalVariables.DataLoading.ProgressBarStep(75);
            this.dgExperiments.SelectionChanged += new System.EventHandler(this.dgExperiments_SelectionChanged);
            dgExperiments.ReadOnly = true;
            dgExperiments.Rows[0].Selected = true;
            this.ResumeLayout();
            GlobalVariables.DataLoading.ProgressBarStep(100);
            GlobalVariables.DataLoading.Hide();
            GlobalVariables.DataLoading.Shown -= this.DataLoading_Shown;
        }

        private void SetExperiment()
        {
            if (cbExperiments == null || cbExperiments.Items.Count <= 0)
                return;
            exUtil.Experiment.Alias = txtSName.Text;
            exUtil.Experiment.Title = txtOfficialName.Text;
            exUtil.Experiment.SDate = sDatePicker.Text;
            exUtil.Experiment.EDate = eDatePicker.Text;
            exUtil.Experiment.Hypo = rtxtHypo.Text;
            exUtil.Experiment.ID = Convert.ToInt32(cbExperiments.SelectedValue.ToString());
            exUtil.SetExperiment();
        }

        private void enableListBox()
        {
            txtBoxList.Clear();
            txtBoxList.Add(exUtil.Experiment.SDate);
            txtBoxList.Add(exUtil.Experiment.EDate);
            txtBoxList.Add(exUtil.Experiment.Title);
            txtBoxList.Add(exUtil.Experiment.Alias);

        }

        private void SetComboBox()
        {
            exUtil.SetComboBox(ref cbExperiments, ref dtExperiments);
        }

        private void SetRecord()
        {
            if(cbExperiments.SelectedValue != null || cbExperiments.Text != "")
            {  
                foreach(DataGridViewRow row in dgExperiments.SelectedRows)
                {
                    txtSName.Text = row.Cells[1].Value.ToString();
                    txtOfficialName.Text = row.Cells[2].Value.ToString();
                    if (String.IsNullOrEmpty(row.Cells[3].Value.ToString())
                        || String.IsNullOrEmpty(row.Cells[4].Value.ToString()))
                        break;
                    sDatePicker.Value = (Convert.ToDateTime(row.Cells[3].Value.ToString()));
                    eDatePicker.Value = (Convert.ToDateTime(row.Cells[4].Value.ToString()));
                    rtxtHypo.Text = row.Cells[5].Value.ToString();
                    txtSName.Enabled = false;
                    txtOfficialName.Enabled = false;
                    sDatePicker.Enabled = false;
                    eDatePicker.Enabled = false;
                    rtxtHypo.Enabled = false;

                    bEnableButtons = exUtil.EnableDisableButtons(row.Cells[6].Value.ToString());

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
            else
                return;

            SetExperiment();
        }

        private void setGrid()
        {
            dgExperiments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgExperiments.DataSource = dtExperiments;
            dgExperiments.ReadOnly = true;
            bLoad = false;
        }

        private void enableControls(bool b)
        {
            sDatePicker.Enabled = b;
            txtOfficialName.Enabled = b;
            txtSName.Enabled = b;
            eDatePicker.Enabled = b;
            rtxtHypo.Enabled = b;
            btnSave.Enabled = b;
            dgExperiments.ReadOnly = b;
            if (b == true)
            {
                cbExperiments.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnView.Enabled = false;
                btnRefresh.Enabled = false;
            }
            else
            {
                cbExperiments.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnView.Enabled = true;
                btnRefresh.Enabled = true;
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
                cbExperiments.Text = "Adding New Row";
            }
            else
            {
                frmRefresh();
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            enableListBox();

            foreach(string txtBox in txtBoxList)
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

            if(bEdit)
            {
                _daoExperiments.updateRecord(exp);
                bEdit = false;
            }
            else if(bDelete)
            {
                _daoExperiments.deleteRecord(cbExperiments.SelectedValue.ToString());
                bDelete = false;
            }
            else
            {
                _daoExperiments.insertRecord(exp);
            }

            frmRefresh();

        }

        public void frmRefresh()
        {
            dsExperiments = _daoExperiments.getExperiments();
            dtExperiments = dsExperiments.Tables[0];
            btnNew.Text = "New Experiment";
            btnDelete.Text = "Delete";
            SetComboBox();
            SetRecord();
            setGrid();
            enableControls(false);
            enableListBox();
            bEdit = false;
            bDelete = false;
            SetExperiment();
    
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
            _daoExperiments.deleteRecord(cbExperiments.SelectedValue.ToString());
            frmRefresh();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            frmRefresh();
        }

        /*private void btnView_Click(object sender, EventArgs e)
        {
            OnRaiseFormEvent(new OpenCtlAnimalData(Convert.ToInt32(cbExperiments.SelectedValue.ToString())));
        }*/

        private void dgExperiments_SelectionChanged(object sender, EventArgs e)
        {
            if (bLoad)
                return;
            SetRecord();
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

        private void cbExperiments_SelectionChangeCommitted(object sender, EventArgs e)
        {
            

        }

        private void cbExperiments_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbExperiments.SelectedValue == null)
                return;
            OnExperimentChangedEvent(new ExperimentHasChanged(Convert.ToInt32(cbExperiments.SelectedValue.ToString()), bLoad));
        }

        /*private void btnPermissions_Click(object sender, EventArgs e)
        {
            UserPermissions _UserPermissions = UserPermissions.CreateInstance(Convert.ToInt32(cbExperiments.SelectedValue.ToString()));
            _UserPermissions.StartPosition = FormStartPosition.CenterParent;
            _UserPermissions.Show();
            _UserPermissions.BringToFront();   
        }*/
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
