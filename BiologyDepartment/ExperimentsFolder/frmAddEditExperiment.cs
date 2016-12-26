using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiologyDepartment.ExperimentsFolder
{
    public partial class FrmAddEditExperiment : Form
    {
        public ExperimentTreeNode ExperimentNode = new ExperimentTreeNode();
        private bool bIsEdit = false;
        private daoExperiments daoEx = new daoExperiments();
        private DataTable dtParents;

        public FrmAddEditExperiment()
        {
            InitializeComponent();
        }

        public void Initialize(ExperimentTreeNode node)
        {
            dtParents = daoEx.GetRecordsForComboBox();
            if (dtParents == null || dtParents.Rows.Count == 0)
            {
                cmbParents = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            }
            else
            {
                DataRow emptyRow = dtParents.NewRow();
                cmbParents.ValueMember = "EX_ID";
                cmbParents.DisplayMember = "EX_ALIAS";
                cmbParents.DataSource = dtParents;
                dtParents.Rows.InsertAt(emptyRow, 0);
            }
            if (node != null)
            {
                ExperimentNode = node;
                rtbOfficialName.Text = ExperimentNode.ExperimentNode.Title;
                txtShortName.Text = ExperimentNode.ExperimentNode.Alias;
                txtScript.Text = ExperimentNode.ExperimentNode.Hypo;
                dteStart.Value = Convert.ToDateTime(ExperimentNode.ExperimentNode.SDate);
                dteEnd.Value = Convert.ToDateTime(ExperimentNode.ExperimentNode.EDate);
                if(ExperimentNode.ExperimentNode.ParentEx > 0)
                    cmbParents.SelectedValue = ExperimentNode.ExperimentNode.ParentEx;
                bIsEdit = true;
            }            
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (cmbParents.SelectedValue != null && cmbParents.SelectedIndex > 0)
                ExperimentNode.ExperimentNode.ParentEx = Convert.ToInt32(cmbParents.SelectedValue.ToString());
            ExperimentNode.ExperimentNode.Alias = txtShortName.Text;
            ExperimentNode.ExperimentNode.Title = rtbOfficialName.Text;
            if(!bIsEdit)
                ExperimentNode.ExperimentNode.UserAccess = "OWNER";
            ExperimentNode.ExperimentNode.SDate = dteStart.Value.ToShortDateString();
            ExperimentNode.ExperimentNode.EDate = dteEnd.Value.ToShortDateString();
            ExperimentNode.ExperimentNode.Hypo = txtScript.Text.ToString();

            if (bIsEdit)
                daoEx.updateRecord(ExperimentNode.ExperimentNode, false);
            else
                ExperimentNode.ExperimentNode.ID = daoEx.insertRecord(ExperimentNode.ExperimentNode, false);
            
            this.Close();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

