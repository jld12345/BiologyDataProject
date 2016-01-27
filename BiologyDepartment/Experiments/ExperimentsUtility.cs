using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void SetComboBox(ref ComboBox theComboBox, ref DataTable theDataTable)
        {
            theComboBox.ValueMember = "EX_ID";
            theComboBox.DisplayMember = "EX_ALIAS";
            theComboBox.DataSource = theDataTable;
        }

        public void SetExperiment()
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
