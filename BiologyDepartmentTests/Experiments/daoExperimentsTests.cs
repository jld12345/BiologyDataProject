using NUnit.Framework;
using BiologyDepartment;
using System;
using System.Windows.Forms;
using System.Data;

namespace BiologyDepartment.Tests
{
    [TestFixture()]
    public class daoExperimentsTests
    {
        [Test()]
        public void daoExperimentsTest()
        {
            daoExperiments dao = new daoExperiments();
            if (dao == null)
                Assert.Fail("DAO is null");
        }

        [Test()]
        public void getExperimentsTest()
        {
            daoExperiments dao = new daoExperiments();
            GlobalVariables.ADUserName = "James";
            GlobalVariables.dbUser = "biologyprojectadmin";
            GlobalVariables.dbPass = "ImWay2c@@l";
            GlobalVariables.GlobalConnection = new dbBioConnection();
            GlobalVariables.Experiment.ID = 1;
            DataSet ds = dao.getExperiments();
            int nRows = 0;

            if (ds == null)
                Assert.Fail("Dataset is null");
            else if (ds.Tables.Count == 0)
                Assert.Fail("Dataset has no tables");
            else if (ds.Tables[0].Rows.Count == 0)
                Assert.Fail("Datable 0 has no rows");
            else
                Assert.Pass("Should be able to get experiments");
        }

        [Test()]
        public void CrudTest()
        {
            daoExperiments dao = new daoExperiments();
            Experiments exp = new Experiments();
            int nID = 0;
            int nRows = 0;
            ExperimentsUtility util = new ExperimentsUtility();
            GlobalVariables.ADUserName = "James";
            GlobalVariables.dbUser = "biologyprojectadmin";
            GlobalVariables.dbPass = "ImWay2c@@l";
            GlobalVariables.GlobalConnection = new dbBioConnection();

            exp.ID = 0;
            exp.Alias = "UnitTest";
            exp.Title = "UnitTest";
            exp.SDate = DateTime.Now.ToShortDateString();
            exp.EDate = DateTime.Now.ToShortDateString();
            exp.Hypo = "UnitTest";

            nID = dao.insertRecord(exp, true);
            if (nID <= 0)
                Assert.Fail("Record was not inserted");

            exp.ID = nID;
            exp.Alias = "UnitTestUpdate";
            dao.updateRecord(exp, true);
            DataSet ds = dao.getRecord(nID);
            if (ds == null)
                Assert.Fail("Dataset is null");
            else if (ds.Tables.Count == 0)
                Assert.Fail("Dataset has no tables");
            else if (ds.Tables[0].Rows.Count == 0)
                Assert.Fail("Datable 0 has no rows");
            else if (!Convert.ToString(ds.Tables[0].Rows[0]["EX_ALIAS"]).Equals("UnitTestUpdate"))
                Assert.Fail("Record did not update");

            dao.deleteRecord(Convert.ToString(nID), true);
            ds = dao.getRecord(nID);
            if (ds.Tables[0].Rows.Count != 0)
                Assert.Fail("Experiment did not delete");
            else
                Assert.Pass("CRUD should work");

        }

        [Test()]
        public void getChildExpirementsTest()
        {

        }
    }
}