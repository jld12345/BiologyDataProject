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
        private CtlAnimalData _ctlAnimalData = new CtlAnimalData();
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
            LoadGui();
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
