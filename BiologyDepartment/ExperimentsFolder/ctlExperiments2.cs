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
using Syncfusion.Windows.Forms.Tools;
using System.Xml;
using BiologyDepartment.Data;

namespace BiologyDepartment.ExperimentsFolder
{
    public partial class ctlExperiments2 : UserControl
    {
        #region private variables
        private daoExperiments _daoExperiments = new daoExperiments();
        private ExperimentsUtility utilExperiment = new ExperimentsUtility();
        private DataUtil _dataUtil = new DataUtil();
        private DataSet dsExperiments;
        private Experiments exp = new Experiments();
        private Experiments oldExp = new Experiments();
        private bool bLoad = true;
        private bool bEnable = false;
        private ctlAnimalData _ctlAnimalData = new ctlAnimalData();
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
            /*if(dsExperiments != null)
                dsExperiments.Clear();
            if (ggcExperiments != null)
            {
                ggcExperiments.TableDescriptor.Relations.Clear();
                ggcExperiments.Engine.SourceListSet.Clear();
            }*/
            dsExperiments = utilExperiment.GetExperimentsDataSet();
            // Manually specify relations in grouping engine. The DataSet does not need to have any DataRelations.
            // This is the same approach that should be used if you want to set up relation ships
            // between independent IList.
            //GridRelationDescriptor parentToChildRelationDescriptor = new GridRelationDescriptor();
            //parentToChildRelationDescriptor.ChildTableName = "ChildTable";    // same as SourceListSetEntry.Name for childTable (see below)
            //parentToChildRelationDescriptor.RelationKind = RelationKind.RelatedMasterDetails;
            //parentToChildRelationDescriptor.RelationKeys.Add("ex_id", "ex_parent_id");

            //// Add relation to ParentTable 
            //ggcExperiments.TableDescriptor.Relations.Add(parentToChildRelationDescriptor);

            //GridRelationDescriptor childToGrandChildRelationDescriptor = new GridRelationDescriptor();
            //childToGrandChildRelationDescriptor.ChildTableName = "GrandChildTable";  // same as SourceListSetEntry.Name for grandChhildTable (see below)
            //childToGrandChildRelationDescriptor.RelationKind = RelationKind.RelatedMasterDetails;
            //childToGrandChildRelationDescriptor.RelationKeys.Add("ex_id", "ex_parent_id");

            //// Add relation to ChildTable 
            //parentToChildRelationDescriptor.ChildTableDescriptor.Relations.Add(childToGrandChildRelationDescriptor);

            //// Register any DataTable/IList with SourceListSet, so that RelationDescriptor can resolve the name
            //this.ggcExperiments.Engine.SourceListSet.Add("Parent", dsExperiments.Tables[0]);
            //this.ggcExperiments.Engine.SourceListSet.Add("ChildTable", dsExperiments.Tables[1]);
            //this.ggcExperiments.Engine.SourceListSet.Add("GrandChildTable", dsExperiments.Tables[2]);
            ////Addin DataSource to the gridgroupingcontrol.
            //this.ggcExperiments.DataSource = dsExperiments.Tables[0];
            
            foreach(DataRow row in dsExperiments.Tables[0].Rows)
            {
                ExperimentTreeNode node = new ExperimentTreeNode();
                node.ExperimentNode.ID = Convert.ToInt32(row["ex_id"]);
                node.ExperimentNode.Alias = Convert.ToString(row["ex_alias"]);
                node.ExperimentNode.Title = Convert.ToString(row["ex_title"]);
                node.ExperimentNode.SDate = Convert.ToString(row["ex_sdate"]);
                node.ExperimentNode.EDate = Convert.ToString(row["ex_edate"]);
                node.ExperimentNode.Hypo = Convert.ToString(row["ex_hypothesis"]);
                node.Text = node.ExperimentNode.Title;
                if(dsExperiments.Tables.Count > 1 && dsExperiments.Tables[1].Rows.Count > 0)
                {
                    foreach(DataRow childRow in dsExperiments.Tables[1].Rows)
                    {
                        if(Convert.ToInt32(childRow["ex_parent_id"]) == node.ExperimentNode.ID)
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
                                        childNode.Nodes.Add(grandChildNode);
                                    }
                                }
                            }
                            node.Nodes.Add(childNode);
                        }
                    }
                }
                tvExperiments.Nodes.Add(node);
            }
            
        }

        private void AddNode(XmlNode inXmlNode, TreeNodeAdv inTreeNode)
        {
            XmlNode xNode;
            TreeNodeAdv tNode;
            XmlNodeList nodeList;
            int i = 0;
            if (inXmlNode.HasChildNodes)
            {
                nodeList = inXmlNode.ChildNodes;
                for (i = 0; i <= nodeList.Count - 1; i++)
                {
                    xNode = inXmlNode.ChildNodes[i];
                    inTreeNode.Nodes.Add(new TreeNodeAdv(xNode.Name));
                    tNode = inTreeNode.Nodes[i];
                    AddNode(xNode, tNode);
                }
            }
            else
            {
                inTreeNode.Text = inXmlNode.InnerText.ToString();
            }
        }

        private void LoadGui()
        {
            gpDataPanel.Controls.Add(_ctlAnimalData);
            _ctlAnimalData.Dock = DockStyle.Fill;
            tvExperiments.SelectedNode = tvExperiments.Nodes[0];
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

        private void tvExperiments_AfterSelect(object sender, EventArgs e)
        {
            ExperimentTreeNode node = (ExperimentTreeNode)tvExperiments.SelectedNode;
            GlobalVariables.Experiment = node.ExperimentNode;
            OnExperimentChangedEvent(new ExperimentHasChanged(GlobalVariables.Experiment.ID, bLoad));
            txtScript.Text = GlobalVariables.Experiment.Hypo;
            _ctlAnimalData.Initialize(GlobalVariables.Experiment.ID);
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

    public class ExperimentTreeNode : TreeNodeAdv
    {
        private Experiments nodeExperiment = new Experiments();

        public Experiments ExperimentNode
        {
            get { return nodeExperiment; }
            set { nodeExperiment = value; }
        }
    }
}
