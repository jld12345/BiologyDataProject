using System.Windows.Forms;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

        public DataSet GetExperimentsDataSet(string sCriteria)
        {
            DataSet ds = new DataSet();
            DataTable dtChild = new DataTable();
            DataTable dtGrandChild = new DataTable();
            ds = _daoExperiments.getExperiments(sCriteria);
            if (ds == null)
                return null;
            DataTable dtParent = ds.Tables[0];
            string sSearch = "";
            dtParent.TableName = "Parent";
            var sParent = (from dr in dtParent.AsEnumerable()
                           select dr["ex_id"]).Distinct();

            foreach(var id in sParent)
            {
                sSearch += id+ ",";
            }
            dtChild = GetDataTableList(sSearch.TrimEnd(','));
            //ds.Tables.Add(dtParent.Copy());
            if (dtChild != null && dtChild.Rows.Count > 0)
            {
                dtChild.TableName = "Child";
                ds.Tables.Add(dtChild.Copy());
                ds.Relations.Add("ParentChild", ds.Tables[0].Columns["ex_id"], ds.Tables[1].Columns["ex_parent_id"]);

                var sChild = (from dr in dtChild.AsEnumerable()
                              select dr["ex_id"]).Distinct();
                sSearch = "";
                foreach (var id in sChild.ToList())
                {
                    sSearch += id + ",";
                }
                dtGrandChild = GetDataTableList(sSearch.TrimEnd(','));
                if (dtGrandChild != null && dtGrandChild.Rows.Count > 0)
                {
                    dtGrandChild.TableName = "GrandChild";
                    ds.Tables.Add(dtGrandChild.Copy());
                    ds.Relations.Add("ChildGrandChild", ds.Tables[1].Columns["ex_id"], ds.Tables[2].Columns["ex_parent_id"]);
                }
            }
            return ds;
        }

        private DataTable GetDataTableList(string sSearch)
        {
            return _daoExperiments.getChildExpirements(sSearch);
        }

        public bool DeleteExperiment(int ID)
        {
            return _daoExperiments.deleteRecord(ID, false);
        }
    }
}
