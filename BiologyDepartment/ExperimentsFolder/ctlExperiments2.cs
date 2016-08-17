using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScintillaNET;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms.Grid.Grouping;
using Syncfusion.Grouping;

namespace BiologyDepartment.ExperimentsFolder
{
    public partial class ctlExperiments2 : UserControl
    {
        #region private variables
        private daoExperiments _daoExperiments = new daoExperiments();
        private ExperimentsUtility utilExperiment = new ExperimentsUtility();
        private DataSet dsExperiments;
        private Experiments exp = new Experiments();
        private Experiments oldExp = new Experiments();
        private bool bLoad = true;
        private bool bEnable = false;
        #endregion

        #region Event handlers
        public event EventHandler<ExperimentHasChanged> ChangeExperimentEvent;
        #endregion

        public ctlExperiments2()
        {
            InitializeComponent();
        }
        public void Initialize()
        {
            LoadData();
            LoadGui();
        }

        private void LoadData()
        {
            if(dsExperiments != null)
                dsExperiments.Clear();
            if (ggcExperiments != null)
            {
                ggcExperiments.TableDescriptor.Relations.Clear();
                ggcExperiments.Engine.SourceListSet.Clear();
            }
            dsExperiments = utilExperiment.GetExperimentsDataSet();
            // Manually specify relations in grouping engine. The DataSet does not need to have any DataRelations.
            // This is the same approach that should be used if you want to set up relation ships
            // between independent IList.
            GridRelationDescriptor parentToChildRelationDescriptor = new GridRelationDescriptor();
            parentToChildRelationDescriptor.ChildTableName = "ChildTable";    // same as SourceListSetEntry.Name for childTable (see below)
            parentToChildRelationDescriptor.RelationKind = RelationKind.RelatedMasterDetails;
            parentToChildRelationDescriptor.RelationKeys.Add("ex_id", "ex_parent_id");

            // Add relation to ParentTable 
            ggcExperiments.TableDescriptor.Relations.Add(parentToChildRelationDescriptor);

            GridRelationDescriptor childToGrandChildRelationDescriptor = new GridRelationDescriptor();
            childToGrandChildRelationDescriptor.ChildTableName = "GrandChildTable";  // same as SourceListSetEntry.Name for grandChhildTable (see below)
            childToGrandChildRelationDescriptor.RelationKind = RelationKind.RelatedMasterDetails;
            childToGrandChildRelationDescriptor.RelationKeys.Add("ex_id", "ex_parent_id");

            // Add relation to ChildTable 
            parentToChildRelationDescriptor.ChildTableDescriptor.Relations.Add(childToGrandChildRelationDescriptor);

            // Register any DataTable/IList with SourceListSet, so that RelationDescriptor can resolve the name
            this.ggcExperiments.Engine.SourceListSet.Add("Parent", dsExperiments.Tables[0]);
            this.ggcExperiments.Engine.SourceListSet.Add("ChildTable", dsExperiments.Tables[1]);
            this.ggcExperiments.Engine.SourceListSet.Add("GrandChildTable", dsExperiments.Tables[2]);
            //Addin DataSource to the gridgroupingcontrol.
            this.ggcExperiments.DataSource = dsExperiments.Tables[0];
        }

        private void GridSettings()
        {
            //Setting Style for Grid and ScrollBar.
            ggcExperiments.GridVisualStyles = GridVisualStyles.Office2007Blue;
            ggcExperiments.GridOfficeScrollBars = OfficeScrollBars.Office2007;

            //used for disabling ShowAddNewRecord and ShowCaption.
            ggcExperiments.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            ggcExperiments.TopLevelGroupOptions.ShowCaption = false;

            //used to set multiextended selection mode in gridgrouping control. 
            ggcExperiments.TableOptions.ListBoxSelectionMode = SelectionMode.One;

            //used to set GridCaptionRowHeight.
            ggcExperiments.Table.DefaultCaptionRowHeight = 25;
            ggcExperiments.Table.DefaultColumnHeaderRowHeight = 30;
            ggcExperiments.Table.DefaultRecordRowHeight = 22;
            ggcExperiments.AllowProportionalColumnSizing = true;

            /*ggcExperiments.TableDescriptor.Columns["ParentName"].HeaderText = "Parent Name";
            ggcExperiments.TableDescriptor.Columns["ParentDec"].HeaderText = "Parent Dec";
            ggcExperiments.TableDescriptor.Columns["parentID"].HeaderText = "Parent ID";*/


            ggcExperiments.GetTable("ChildTable").DefaultRecordRowHeight = 22;
            ggcExperiments.GetTable("GrandChildTable").DefaultRecordRowHeight = 22;

            foreach(GridColumnDescriptor col in ggcExperiments.TableDescriptor.Columns)
            {
                col.Appearance.AnyCell.CellValueType = typeof(String);
            }

        }

        private void LoadGui()
        {
            GridSettings();
        }

        private void ggcExperiments_SelectedRecordsChanged(object sender, SelectedRecordsChangedEventArgs e)
        {
            if (e.Table.SelectedRecords.Count == 0)
                return;
            SetRecord(e.Table.CurrentRecord);
            OnExperimentChangedEvent(new ExperimentHasChanged(GlobalVariables.Experiment.ID, bLoad));
        }

        private void SetRecord(Record record)
        {
            DataRowView recData = (DataRowView)record.GetData();
            DataRow row = recData.Row;
            lblExperimentID.Text += Convert.ToString(row["ex_id"]);
            txtCodeName.Text = Convert.ToString(row["ex_alias"]);
            txtProjectName.Text = Convert.ToString(row["ex_title"]);
            if (String.IsNullOrEmpty(Convert.ToString(row["ex_sdate"])) 
                || String.IsNullOrEmpty(Convert.ToString(row["ex_edate"])))
                return;
            dtpStart.Value = Convert.ToDateTime(row["ex_sdate"]);
            dtpEnd.Value = Convert.ToDateTime(row["ex_edate"]);
            txtScript.Text = Convert.ToString(row["ex_hypothesis"]);
            cmbParent.SelectedValue = Convert.ToInt32(row["ex_parent_id"]);
            bEnable = utilExperiment.EnableDisableButtons(Convert.ToString(row["permissions"]));
            EnableDisableRecordControls(bEnable);

            SetExperiment(Convert.ToInt32(row["ex_id"]));
        }

        private void EnableDisableRecordControls(bool bEnable)
        {
            txtCodeName.Enabled = bEnable;
            lblProjectName.Enabled = bEnable;
            cmbParent.Enabled = bEnable;
            dtpStart.Enabled = bEnable;
            dtpEnd.Enabled = bEnable;
            txtScript.Enabled = bEnable;
        }

        private void SetExperiment(int exID)
        {
            SetOldExperiment(false);
            exp.Alias = txtCodeName.Text;
            exp.Title = txtProjectName.Text;
            exp.SDate = dtpStart.Text;
            exp.EDate = dtpEnd.Text;
            exp.Hypo = txtScript.Text;
            if (cmbParent.SelectedValue != null && !string.IsNullOrEmpty(Convert.ToString(cmbParent.SelectedValue)))
                exp.ParentEx = Convert.ToInt32(cmbParent.SelectedValue.ToString());
            exp.ID = exID;
            GlobalVariables.Experiment = exp;
        }

        private void SetOldExperiment(bool bResetExperiment)
        {
            if (!bResetExperiment)
            {
                int nID= exp.ID;
                string sAlias = exp.Alias;
                string sTitle = exp.Title;
                string sStart = exp.SDate;
                string sEnd = exp.EDate;
                string sData = exp.Hypo;
                oldExp.ID = nID;
                oldExp.Alias = sAlias;
                oldExp.Title = sTitle;
                oldExp.SDate = sStart;
                oldExp.EDate = sEnd;
                oldExp.Hypo = sData;
            }
            else
            {
                int nID = oldExp.ID;
                string sAlias = oldExp.Alias;
                string sTitle = oldExp.Title;
                string sStart = oldExp.SDate;
                string sEnd = oldExp.EDate;
                string sData = oldExp.Hypo;
                exp.ID = nID;
                exp.Alias = sAlias;
                exp.Title = sTitle;
                exp.SDate = sStart;
                exp.EDate = sStart;
                exp.Hypo = sData;
            }
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
