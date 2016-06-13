using System.Windows.Forms;
using System.Data;
using System.Collections;
using System.Collections.Generic;

namespace BiologyDepartment
{
    public class ExperimentsUtility
    {
        private Experiments theExperiment = new Experiments();
        private daoExperiments _daoExperiments = new daoExperiments();

        public Experiments Experiment { get; set; }

        public ExperimentsUtility()
        {
            Experiment = new Experiments();
        }

        public bool SetComboBox(ref ComboBox theComboBox, ref DataTable theDataTable)
        {
            if (theComboBox == null)
                return false;
            if (theDataTable == null || theDataTable.Rows.Count == 0)
            {
                theComboBox = new ComboBox();
                return false;
            }
            else
            {
                theComboBox.ValueMember = "EX_ID";
                theComboBox.DisplayMember = "EX_ALIAS";
                theComboBox.DataSource = theDataTable;
            }
            return true;
        }

        public void SetExperiment(Experiments Experiment)
        {
            GlobalVariables.Experiment = Experiment;
        }

        public bool EnableDisableButtons(string Access)
        {
            bool bReturn = false;
            switch (Access)
            {
                case "View":
                case "Add/Edit":
                    bReturn = false;
                    break;
                case "Admin":
                case "Owner":
                    bReturn = true;
                    break;
            }
            return bReturn;
        }

        public DataSet GetExperimentsDataSet()
        {
            DataSet ds = new DataSet();
            DataTable dtChild = new DataTable();
            DataTable dtParent = _daoExperiments.getExperiments().Tables[0];
            dtParent.TableName = "Parent";
            List<DataTable> dtList = new List<DataTable>();
            int nTableCount = 0;

            string sSearch = "";
            foreach(DataRow dr in dtParent.Rows)
            {
                sSearch = sSearch + dr["ex_id"].ToString() + ",";
            }
            sSearch = sSearch.TrimEnd(',');
            dtChild = _daoExperiments.getChildExpirements(sSearch);
            if (dtChild != null && dtChild.Rows.Count > 0)
            {
                dtChild.TableName = "Child" + nTableCount.ToString();
                dtList.Add(dtChild);
 
                while (dtChild.Rows.Count > 0)
                {
                    nTableCount++;
                    sSearch = "";
                    foreach (DataRow dr in dtChild.Rows)
                    {
                        sSearch = sSearch + dr["ex_id"].ToString() + ",";
                    }
                    sSearch = sSearch.TrimEnd(',');
                    dtChild = _daoExperiments.getChildExpirements(sSearch);
                    if (dtChild != null && dtChild.Rows.Count > 0)
                    {
                        dtChild.TableName = "Child" + nTableCount.ToString();
                        dtList.Add(dtChild);
                    }
                }
            }

            ds.Tables.Add(dtParent.Copy());
            for (int i = 0; i < dtList.Count; i++ )
            {
                string sRelation = "Relation";
                ds.Tables.Add(dtList[i].Copy());
                
                ds.Relations.Add(sRelation + i.ToString(), ds.Tables[i].Columns["ex_id"], ds.Tables[i+1].Columns["ex_parent_id"]);

            }

            return ds;
        }
    }
}
