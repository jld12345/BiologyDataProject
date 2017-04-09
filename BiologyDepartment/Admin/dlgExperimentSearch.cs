using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace BiologyDepartment.Admin
{
    public partial class dlgExperimentSearch : Form
    {
        #region Private Variables
        private DataSet dsExperiments;
        private DataTable dtParents;
        private daoExperiments daoEx = new daoExperiments();
        private ExperimentsUtility utilExperiment = new ExperimentsUtility();
        private string sCriteria = "";
        #endregion

        #region Public Variables
        public ExperimentTreeNode exNode;
        public bool ExperimentLoaded = false;
        #endregion

        #region Public Methods
        public dlgExperimentSearch()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            LoadData();
            LoadGui();
        }
        #endregion

        #region Private Methods

        private void LoadGui()
        {
            LoadParentCombo();
            LoadFirstNode();
        }

        private void LoadParentCombo()
        {
            dtParents = daoEx.GetRecordsForComboBox();
            if (dtParents == null || dtParents.Rows.Count == 0)
            {
                cmbParents = ComboBoxAdv();
            }
            else
            {
                if (cmbParents.DataSource != null)
                {
                    cmbParents = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
                }

                DataRow emptyRow = dtParents.NewRow();
                cmbParents.ValueMember = "EX_ID";
                cmbParents.DisplayMember = "EX_ALIAS";
                cmbParents.DataSource = dtParents;
                dtParents.Rows.InsertAt(emptyRow, 0);
            }
        }

        private ComboBoxAdv ComboBoxAdv()
        {
            throw new NotImplementedException();
        }

        private void SetFields()
        {
            if (exNode == null)
                return;
            txtShortName.Text = exNode.ExperimentNode.Alias;
            rtbNotes.Text = exNode.ExperimentNode.Hypo;
            rtbOfficialName.Text = exNode.ExperimentNode.Title;
            dteStart.Value = Convert.ToDateTime(exNode.ExperimentNode.SDate);
            dteEnd.Value = Convert.ToDateTime(exNode.ExperimentNode.EDate);
            if (exNode.ExperimentNode.ParentEx > 0)
                cmbParents.SelectedValue = exNode.ExperimentNode.ParentEx;
        }

        private void LoadData()
        {
            tvExperiments.Nodes[0].Nodes.Clear();
            tvExperiments.Nodes[1].Nodes.Clear();
            tvExperiments.Nodes[2].Nodes.Clear();
            tvExperiments.Nodes[3].Nodes.Clear();

            dsExperiments = utilExperiment.GetExperimentsDataSet(sCriteria);

            if (dsExperiments == null)
                return;

            foreach (DataRow row in dsExperiments.Tables[0].Rows)
            {
                ExperimentTreeNode node = new ExperimentTreeNode();
                node.ExperimentNode.ID = Convert.ToInt32(row["ex_id"]);
                node.ExperimentNode.Alias = Convert.ToString(row["ex_alias"]);
                node.ExperimentNode.Title = Convert.ToString(row["ex_title"]);
                node.ExperimentNode.SDate = Convert.ToString(row["ex_sdate"]);
                node.ExperimentNode.EDate = Convert.ToString(row["ex_edate"]);
                node.ExperimentNode.Hypo = Convert.ToString(row["ex_hypothesis"]);
                node.ExperimentNode.UserAccess = Convert.ToString(row["Permissions"]);
                node.Text = node.ExperimentNode.Title;
                node.MultiLine = true;
                if (dsExperiments.Tables.Count > 1 && dsExperiments.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow childRow in dsExperiments.Tables[1].Rows)
                    {
                        if (Convert.ToInt32(childRow["ex_parent_id"]) == node.ExperimentNode.ID)
                        {
                            ExperimentTreeNode childNode = new ExperimentTreeNode();
                            childNode.ExperimentNode.ID = Convert.ToInt32(childRow["ex_id"]);
                            childNode.ExperimentNode.Alias = Convert.ToString(childRow["ex_alias"]);
                            childNode.ExperimentNode.Title = Convert.ToString(childRow["ex_title"]);
                            childNode.ExperimentNode.SDate = Convert.ToString(childRow["ex_sdate"]);
                            childNode.ExperimentNode.EDate = Convert.ToString(childRow["ex_edate"]);
                            childNode.ExperimentNode.Hypo = Convert.ToString(childRow["ex_hypothesis"]);
                            childNode.ExperimentNode.ParentEx = Convert.ToInt32(childRow["ex_parent_id"]);
                            childNode.Text = childNode.ExperimentNode.Title;
                            childNode.MultiLine = true;
                            if (dsExperiments.Tables.Count > 2 && dsExperiments.Tables[2].Rows.Count > 0)
                            {
                                foreach (DataRow grandChildRow in dsExperiments.Tables[2].Rows)
                                {
                                    if (Convert.ToInt32(grandChildRow["ex_parent_id"]) == childNode.ExperimentNode.ID)
                                    {
                                        ExperimentTreeNode grandChildNode = new ExperimentTreeNode();
                                        grandChildNode.ExperimentNode.ID = Convert.ToInt32(grandChildRow["ex_id"]);
                                        grandChildNode.ExperimentNode.Alias = Convert.ToString(grandChildRow["ex_alias"]);
                                        grandChildNode.ExperimentNode.Title = Convert.ToString(grandChildRow["ex_title"]);
                                        grandChildNode.ExperimentNode.SDate = Convert.ToString(grandChildRow["ex_sdate"]);
                                        grandChildNode.ExperimentNode.EDate = Convert.ToString(grandChildRow["ex_edate"]);
                                        grandChildNode.ExperimentNode.Hypo = Convert.ToString(grandChildRow["ex_hypothesis"]);
                                        grandChildNode.ExperimentNode.ParentEx = Convert.ToInt32(grandChildRow["ex_parent_id"]);
                                        grandChildNode.Text = grandChildNode.ExperimentNode.Title;
                                        grandChildNode.MultiLine = true;
                                        childNode.Nodes.Add(grandChildNode);
                                    }
                                }
                            }
                            node.Nodes.Add(childNode);
                        }
                    }
                }
                switch (Convert.ToString(row["Permissions"]))
                {
                    case "Owner":
                        tvExperiments.Nodes[0].Nodes.Add(node);
                        break;
                    case "Admin":
                        tvExperiments.Nodes[1].Nodes.Add(node);
                        break;
                    case "Add/Edit":
                        tvExperiments.Nodes[2].Nodes.Add(node);
                        break;
                    case "View":
                        tvExperiments.Nodes[3].Nodes.Add(node);
                        break;
                }

            }

        }

        private void LoadFirstNode()
        {
            if (tvExperiments.Nodes[0].Nodes.Count > 0)
                tvExperiments.SelectedNode = tvExperiments.Nodes[0].Nodes[0];
            else if (tvExperiments.Nodes[1].Nodes.Count > 0)
                tvExperiments.SelectedNode = tvExperiments.Nodes[1].Nodes[0];
            else if (tvExperiments.Nodes[2].Nodes.Count > 0)
                tvExperiments.SelectedNode = tvExperiments.Nodes[2].Nodes[0];
            else if (tvExperiments.Nodes[3].Nodes.Count > 0)
                tvExperiments.SelectedNode = tvExperiments.Nodes[3].Nodes[0];

        }

        private void tvExperiments_AfterSelect(object sender, EventArgs e)
        {
            if (tvExperiments.SelectedNode == null)
                return;

            if (tvExperiments.SelectedNode.HasChildren)
            {
                if (tvExperiments.SelectedNode.Expanded)
                    tvExperiments.SelectedNode.CollapseAll();
                else
                    tvExperiments.SelectedNode.Expand();

                if (tvExperiments.SelectedNode.Parent == null)
                    return;
            }
            var nodeType = tvExperiments.SelectedNode.GetType();
            if (nodeType.Name.Equals("TreeNodeAdv"))
                return;
            if (GlobalVariables.ExperimentGrid.bDataDirty)
            {
                string sMessage = "There are unsaved edits or additions to this experiment.  To save these edits/additions, please click yes. \n";
                sMessage += "Clicking No will cause all edits/additions to be removed. ";
                DialogResult result = MessageBox.Show(sMessage, "Unsaved Edits/Additions", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    //GlobalVariables.ExperimentGrid.SaveData(0);
                }
            }
            exNode = (ExperimentTreeNode)tvExperiments.SelectedNode;
            SetFields();
        }
        #endregion

        private void btnLoad_Click(object sender, EventArgs e)
        {
            GlobalVariables.ExperimentNode = exNode;
            GlobalVariables.ExperimentGrid.Initialize(GlobalVariables.ExperimentNode.ExperimentNode.ID);
            GlobalVariables.Experiment = exNode.ExperimentNode;
            ExperimentLoaded = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(rbAuthor.Checked)
            {
                sCriteria = @" and ex.ex_id in 
                                (select ae.ex_id from authors a, author_experiments ae
                                 where (a.author_id = ae.author_id 
                                        and upper(a.author_lname || ', ' || a.author_fname || ' '  || a.author_mname) = '" + txtSearchBox.Text.ToUpper() + @"')
                                    or (a.author_id = ae.author_id 
                                        and upper(a.author_fname || ' ' || a.author_mname || ' ' || a.author_lname) = '" + txtSearchBox.Text.ToUpper() + @"')
                                    or (a.author_id = ae.author_id 
                                        and upper(a.author_fname || ' ' || a.author_lname) = '" + txtSearchBox.Text.ToUpper() + @"')
                                    or (a.author_id = ae.author_id 
                                        and upper(a.author_lname || ', ' || a.author_fname) = '" + txtSearchBox.Text.ToUpper() + "')) ";
                                      
            }
            else if(rbKeyWord.Checked)
            {
                sCriteria = @" and ex.ex_id in 
                                (select ex2.ex_id from experiments ex2
                                 where upper(ex2.ex_hypothesis) ~* '" + txtSearchBox.Text.Replace(',','|').ToUpper() + "') ";
            }
            else if(rbShortName.Checked)
            {
                sCriteria = @" and ex.ex_id in 
                                (select ex2.ex_id from experiments ex2
                                 where upper(ex2.ex_alias) = '" + txtSearchBox.Text.ToUpper() + "') ";
            }
            else if(rbTitle.Checked)
            {
                sCriteria = @" and ex.ex_id in 
                                (select ex2.ex_id from experiments ex2
                                 where upper(ex2.ex_title) = '" + txtSearchBox.Text.ToUpper() + "') ";

            }

            Initialize();
            sCriteria = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearchBox.Clear();
            sCriteria = "";
            Initialize();
        }

    }
}
