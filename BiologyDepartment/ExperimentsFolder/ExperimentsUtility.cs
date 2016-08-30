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
        private int nTableCount = 0;

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
            nTableCount = 0;
            dtList = GetDataTableList(dtParent);
            ds.Tables.Add(dtParent.Copy());
            for (int i = 0; i < dtList.Count; i++ )
            {
                string sRelation = "Relation";
                ds.Tables.Add(dtList[i].Copy());
                
                ds.Relations.Add(sRelation + i.ToString(), ds.Tables[i].Columns["ex_id"], ds.Tables[i+1].Columns["ex_parent_id"]);

            }

            return ds;
        }

        private List<DataTable> GetDataTableList(DataTable dtSearch)
        {
            List<DataTable> dtList = new List<DataTable>();
            foreach (DataRow dr in dtSearch.Rows)
            {
                string sSearch = dr["ex_id"].ToString();
                DataTable dtChild = _daoExperiments.getChildExpirements(sSearch);

                if (dtChild != null && dtChild.Rows.Count > 0)
                {
                    if (nTableCount > 0)
                        nTableCount++;
                    dtChild.TableName = "Child" + nTableCount.ToString();
                    dtList.Add(dtChild.Copy());

                    foreach (DataRow child in dtChild.Rows)
                    {                        
                        sSearch = child["ex_id"].ToString();
                        DataTable dtSibling = _daoExperiments.getChildExpirements(sSearch);
                        if(dtSibling != null && dtSibling.Rows.Count > 0)
                        {
                            nTableCount++;
                            dtSibling.TableName = "Child" + nTableCount.ToString();
                            dtList.Add(dtSibling.Copy());
                        }
                    }
                }
            }
            return dtList;
        }

        public bool DeleteExperiment(int ID)
        {
            return _daoExperiments.deleteRecord(ID, false);
        }
    }
}
