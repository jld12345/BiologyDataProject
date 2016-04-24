using NUnit.Framework;
using BiologyDepartment;
using System;
using System.Windows.Forms;
using System.Data;

namespace BiologyDepartment.Tests
{
    [TestFixture()]
    public class ExperimentsUtilityTests
    {

        [Test()]
        public void ExperimentsUtilityTest()
        {
            ExperimentsUtility util = new ExperimentsUtility();
            daoExperiments dao = new daoExperiments();
            Experiments exp = new Experiments();
            exp.ID = 999999;
            exp.Alias = "UnitTest";
            exp.Title = "UnitTest";
            exp.SDate = DateTime.Now.ToShortDateString();
            exp.EDate = DateTime.Now.ToShortDateString();
            exp.Hypo = "UnitTest";
            util.SetExperiment(exp);
            exp = null;
            exp = util.Experiment;
            if (exp == null)
                Assert.Fail("Experiment was not set");
            else
            {
                exp.ID = 999999;
                exp.Alias = "UnitTest";
                exp.Title = "UnitTest";
                exp.SDate = DateTime.Now.ToShortDateString();
                exp.EDate = DateTime.Now.ToShortDateString();
                exp.Hypo = "UnitTest";
                util.SetExperiment(exp);
                if (util.Experiment.ID != 999999)
                    Assert.Fail("Experiment ID is incorrect.  ID = " + exp.ID.ToString());
                else if (!util.Experiment.Alias.Equals("UnitTest"))
                    Assert.Fail("Experiment Alias is incorrect");
                else if (!util.Experiment.Title.Equals("UnitTest"))
                    Assert.Fail("Experiment Title is incorrect");
                else if (!util.Experiment.SDate.Equals(DateTime.Now.ToShortDateString()))
                    Assert.Fail("Experiment start date is incorrect");
                else if (!util.Experiment.EDate.Equals(DateTime.Now.ToShortDateString()))
                    Assert.Fail("Experiment end date is incorrect");
                else if (!util.Experiment.Hypo.Equals("UnitTest"))
                    Assert.Fail("Experiment hypothesis is incorrect");
                else
                    Assert.Pass("Experiment should set");
            }
        }

        [Test()]
        public void SetComboBoxTest()
        {
            ExperimentsUtility util = new ExperimentsUtility();
            daoExperiments dao = new daoExperiments();
            GlobalVariables.ADUserName = "James";
            GlobalVariables.dbUser = "biologyprojectadmin";
            GlobalVariables.dbPass = "ImWay2c@@l";
            GlobalVariables.GlobalConnection = new dbBioConnection();
            Experiments exp = new Experiments();
            ComboBox cbTest = new ComboBox();

            exp.ID = 999999;
            exp.Alias = "UnitTest";
            exp.Title = "UnitTest";
            exp.SDate = DateTime.Now.ToShortDateString();
            exp.EDate = DateTime.Now.ToShortDateString();
            exp.Hypo = "UnitTest";
            util.SetExperiment(exp);
            
            DataSet dsExperiments = dao.getExperiments();
            DataTable dtTest = dsExperiments.Tables[0];
            bool bPassed = false;
            
            cbTest = null;

            if (!util.SetComboBox(ref cbTest, ref dtTest))
            {
                cbTest = new ComboBox();
                bPassed = true;
            }
            else
                Assert.Fail("Combo box was not null");
            if (util.SetComboBox(ref cbTest, ref dtTest))
                bPassed = true;
            else
            {
                bPassed = false;
                Assert.Fail("Should return true, empty combobox, datatable with results");
            }
            if (bPassed)
                Assert.Pass("Combobox should set");

            dtTest = null;
            if (!util.SetComboBox(ref cbTest, ref dtTest))
                bPassed = true;
            else
            {
                bPassed = false;
                Assert.Fail("Should return false, empty combobox and datatable");
            }
        }

        [Test()]
        public void EnableDisableButtonsTest()
        {
            ExperimentsUtility util = new ExperimentsUtility();

            if(util.EnableDisableButtons("View"))
                Assert.Fail("View should return false");
            if (util.EnableDisableButtons("Add/Edit"))
                Assert.Fail("Add/Edit should return false");
            if (!util.EnableDisableButtons("Admin"))
                Assert.Fail("Admin should return true");
            if (!util.EnableDisableButtons("Owner"))
                Assert.Fail("Owner should return true");
            else
                Assert.Pass("Enable/Disable buttons should work");
        }
    }
}