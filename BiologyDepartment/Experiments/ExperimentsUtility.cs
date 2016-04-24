using System.Windows.Forms;
using System.Data;

namespace BiologyDepartment
{
    public class ExperimentsUtility
    {
        private Experiments theExperiment = new Experiments();

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
                theComboBox.ValueMember = "";
                theComboBox.DisplayMember = "";
                theComboBox.DataSource = "";
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
    }
}
