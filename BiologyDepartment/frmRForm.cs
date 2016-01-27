using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RDotNet;
using System.Collections.Specialized;
using System.Collections;
using System.IO;
using System.Diagnostics;

namespace BiologyDepartment
{
    public partial class frmRForm : Form
    {
        private daoChart _daoChart = new daoChart();
        private static frmRForm inst;
        private int exID = 0;

        public frmRForm()
        {
            InitializeComponent();
        }

        public frmRForm(int id)
        {
            InitializeComponent();
            exID = id;
        }

        public static frmRForm CreateInstance()
        {
            if (inst == null || inst.IsDisposed)
            {
                inst = new frmRForm();
            }
            else
            {
                MessageBox.Show("An Instance of the R Form is already open.", "Form Open", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return inst;
        }

        public static frmRForm CreateInstance(int id)
        {
            if (inst == null || inst.IsDisposed)
            {
                inst = new frmRForm(id);
            }
            else
            {
                MessageBox.Show("An Instance of the R Form is already open.", "Form Open", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return inst;
        }

        private void frmRForm_Load(object sender, EventArgs e)
        {
           
        }

        private void doTTest()
        {
            REngine engine = REngine.GetInstance();
            daoChart _daoChart = new daoChart();

            DataSet dsRec = new DataSet();
            DataTable dtRec = new DataTable();
            ListDictionary Diets = new ListDictionary();

            dsRec = _daoChart.getRData(1);
            dtRec = dsRec.Tables[0];

            int k = 0;
            for (int j = 0; j < dtRec.Rows.Count; j++)
            {
                if (!Diets.Contains(dtRec.Rows[j]["C"].ToString()))
                {
                    Diets.Add(dtRec.Rows[j]["C"].ToString(), k);
                    k++;
                }
            }
            List<double>[] dData = new List<double>[Diets.Count];

            foreach (DictionaryEntry de in Diets)
            {
                dData[Convert.ToInt32(de.Value.ToString())] = new List<double>();
            }

            for (int i = 0; i < dtRec.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(dtRec.Rows[i]["WEIGHT"].ToString()))
                    continue;

                foreach (DictionaryEntry entry in Diets)
                {
                    if (entry.Key.ToString().Equals(dtRec.Rows[i]["C"].ToString()))
                    {
                        dData[Convert.ToInt32(entry.Value.ToString())].Add(Convert.ToDouble(dtRec.Rows[i]["WEIGHT"].ToString()));
                        break;
                    }

                }
            }

            foreach (DictionaryEntry deVector in Diets)
            {
                NumericVector Vgroup1 = engine.CreateNumericVector(dData[Convert.ToInt32(deVector.Value)].ToArray());
                engine.SetSymbol(deVector.Key.ToString(), Vgroup1);
                foreach (DictionaryEntry compareVector in Diets)
                {
                    NumericVector Vgroup2 = engine.CreateNumericVector(dData[Convert.ToInt32(compareVector.Value)].ToArray());
                    if (!deVector.Key.ToString().Equals(compareVector.Key.ToString()))
                    {
                        engine.SetSymbol(compareVector.Key.ToString(), Vgroup2);
                        GenericVector testResult1 = engine.Evaluate("t.test(" + deVector.Key.ToString() + "," +
                        compareVector.Key.ToString() + ")").AsList();
                        double p1 = testResult1["p.value"].AsNumeric().First();
                        tbREngine.Text += deVector.Key.ToString() + "\\" + compareVector.Key.ToString();
                        tbREngine.Text += "\nP1-value = {0:0.000}" + p1 + "\n\n";
                        //engine.ClearGlobalEnvironment();
                    }
                }
            }

        }

        private void doAnova()
        {
            REngine engine = REngine.GetInstance();
            daoChart _daoChart = new daoChart();

            DataSet dsRec = new DataSet();
            DataTable dtRec = new DataTable();
            ListDictionary Diets = new ListDictionary();
            List<double> dMeasure = new List<double>();
            List<string> sDiet = new List<string>();
 
            dsRec = _daoChart.getRData(1);
            dtRec = dsRec.Tables[0];
            int k = 0;
            for (int j = 0; j < dtRec.Rows.Count; j++)
            {
                if (!Diets.Contains(dtRec.Rows[j]["C"].ToString()))
                {
                    Diets.Add(dtRec.Rows[j]["C"].ToString(), k);
                    sDiet.Add(dtRec.Rows[j]["C"].ToString());
                    k++;
                }
            }
            List<double>[] dDataAll = new List<double>[Diets.Count];
            List<double>[] dDataFemale = new List<double>[Diets.Count];
            List<double>[] dDataMale = new List<double>[Diets.Count];


            foreach (DictionaryEntry de in Diets)
            {
                dDataAll[Convert.ToInt32(de.Value.ToString())] = new List<double>();
                dDataMale[Convert.ToInt32(de.Value.ToString())] = new List<double>();
                dDataFemale[Convert.ToInt32(de.Value.ToString())] = new List<double>();
            }

            for (int i = 0; i < dtRec.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(dtRec.Rows[i]["WEIGHT"].ToString()))
                    continue;

                foreach (DictionaryEntry entry in Diets)
                {
                    if (entry.Key.ToString().Equals(dtRec.Rows[i]["C"].ToString()))
                    {
                        dDataAll[Convert.ToInt32(entry.Value.ToString())].Add(Convert.ToDouble(dtRec.Rows[i]["WEIGHT"].ToString()));

                        if (dtRec.Rows[i]["SEX"].ToString().Equals("M"))
                            dDataMale[Convert.ToInt32(entry.Value.ToString())].Add(Convert.ToDouble(dtRec.Rows[i]["WEIGHT"].ToString()));
                        else
                            dDataFemale[Convert.ToInt32(entry.Value.ToString())].Add(Convert.ToDouble(dtRec.Rows[i]["WEIGHT"].ToString()));

                        break;
                    }

                }
            }

            /*double[] test = new double[Diets.Count];

            for (int j = 0; j < test.Length; j++)
            {
                test[j] = doMeans(dDataMale[j].ToArray());

            }*/

            List<string> testString = new List<string>();
            List<double> testDouble = new List<double>();
            for (int j = 0; j < dtRec.Rows.Count; j++)
            {
                if (dtRec.Rows[j]["SEX"].ToString().Equals("M"))
                {
                    testString.Add(dtRec.Rows[j]["C"].ToString());
                    testDouble.Add(Convert.ToDouble(dtRec.Rows[j]["WEIGHT"].ToString()));
                }
            }

            engine.SetSymbol("measure", engine.CreateNumericVector(testDouble.ToArray()));
            engine.SetSymbol("diet", engine.CreateCharacterVector(testString.ToArray()));

           /* var res = engine.Evaluate("anova(y ~ a, data = data.frame(y = measure, a = diet))").AsList()["Pr(>F)"].AsNumeric();

            for (int loop = 0; loop < res.Length; loop++)
                tbREngine.Text += res[loop] + "\n\n";*/

            engine.Evaluate("bob <- aov(y~a, data.frame(y = measure, a = diet)");
            var resName = engine.Evaluate("names(bob)").AsList().AsCharacter();
            int loop = 0;
            for (loop = 0; loop < resName.Length; loop++)
                tbREngine.Text += resName[loop].ToString() + "\n";

            var resSum = engine.Evaluate("summary(bob)").AsList().AsCharacter();

            string newsummary = resSum[0].ToString();
            newsummary = newsummary.Replace("list(", string.Empty);
            newsummary = newsummary.Replace("'", string.Empty);
            newsummary = newsummary.Replace("c", string.Empty);
            string[] sumArray = newsummary.Split('=');

            for (loop = 0; loop < sumArray.Length; loop++ )
                tbREngine.Text += sumArray[loop].ToString() + "\n";

           // var res = engine.Evaluate("anova1)").AsList()["Pr(>F)"].AsNumeric();
            /*List<string> test = new List<string>();
            foreach (var loop in res)
                test.Add(loop.ToString());*/

            var res1 = engine.Evaluate("tapply(measure, diet, mean)").AsNumeric();
            var res2 = engine.Evaluate("tapply(measure, diet, var)").AsNumeric();
            var res3 = engine.Evaluate("tapply(measure, diet, length)").AsNumeric();
            var res4 = engine.Evaluate("tapply(measure, diet, sd, na.rm=T)").AsNumeric();
            var res5 = engine.Evaluate("tapply(measure, diet, min, na.rm=T)").AsNumeric();
            var res6 = engine.Evaluate("tapply(measure, diet, max, na.rm=T)").AsNumeric();


            for (int j = 0; j < sDiet.Count; j++)
            {
                tbREngine.Text += sDiet[j].ToString() + "\n";
                tbREngine.Text += "Mean: " + res1[j].ToString() + "\n";
                tbREngine.Text += "Variance: " +res2[j].ToString() + "\n";
                tbREngine.Text += "Length: " + res3[j].ToString() + "\n";
                tbREngine.Text += "Standard Dev: " + res4[j].ToString() + "\n";
                tbREngine.Text += "Minimum: " + res5[j].ToString() + "\n";
                tbREngine.Text += "Maximum: " + res6[j].ToString() + "\n";
                tbREngine.Text += "Standard Error of the Means: " + (Math.Sqrt(Convert.ToDouble(res4[j].ToString()))/(Convert.ToDouble(res3[j].ToString()))).ToString() + "\n\n";
            }

        }

        private void doMeans()
        {
            REngine engine = REngine.GetInstance();
            daoChart _daoChart = new daoChart();

            DataSet dsRec = new DataSet();
            DataTable dtRec = new DataTable();
            ListDictionary Diets = new ListDictionary();

            dsRec = _daoChart.getRData(1);
            dtRec = dsRec.Tables[0];

            int k = 0;
            for (int j = 0; j < dtRec.Rows.Count; j++)
            {
                if (!Diets.Contains(dtRec.Rows[j]["C"].ToString()))
                {
                    Diets.Add(dtRec.Rows[j]["C"].ToString(), k);
                    k++;
                }
            }
            List<double>[] dDataAll = new List<double>[Diets.Count];
            List<double>[] dDataFemale = new List<double>[Diets.Count];
            List<double>[] dDataMale = new List<double>[Diets.Count];


            foreach (DictionaryEntry de in Diets)
            {
                dDataAll[Convert.ToInt32(de.Value.ToString())] = new List<double>();
                dDataMale[Convert.ToInt32(de.Value.ToString())] = new List<double>(); 
                dDataFemale[Convert.ToInt32(de.Value.ToString())] = new List<double>();
            }

            for (int i = 0; i < dtRec.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(dtRec.Rows[i]["WEIGHT"].ToString()))
                    continue;

                foreach (DictionaryEntry entry in Diets)
                {
                    if (entry.Key.ToString().Equals(dtRec.Rows[i]["C"].ToString()))
                    {
                        dDataAll[Convert.ToInt32(entry.Value.ToString())].Add(Convert.ToDouble(dtRec.Rows[i]["WEIGHT"].ToString()));

                        if (dtRec.Rows[i]["SEX"].ToString().Equals("M"))
                            dDataMale[Convert.ToInt32(entry.Value.ToString())].Add(Convert.ToDouble(dtRec.Rows[i]["WEIGHT"].ToString()));
                        else
                            dDataFemale[Convert.ToInt32(entry.Value.ToString())].Add(Convert.ToDouble(dtRec.Rows[i]["WEIGHT"].ToString()));

                        break;
                    }

                }
            }

            int meanLoop = 0;
            foreach(DictionaryEntry de in Diets)
            {
                engine.SetSymbol("ALL", engine.CreateNumericVector(dDataAll[meanLoop].ToArray()));
                var testResult = engine.Evaluate("mean(ALL)").AsNumeric();
                tbREngine.Text += de.Key.ToString() + " All = " + testResult[0].ToString() + "\n";
                engine.SetSymbol("MALE", engine.CreateNumericVector(dDataMale[meanLoop].ToArray()));
                testResult = engine.Evaluate("mean(MALE)").AsNumeric();
                tbREngine.Text += de.Key.ToString() + " Male = " + testResult[0].ToString() + "\n";
                engine.SetSymbol("FEMALE", engine.CreateNumericVector(dDataFemale[meanLoop].ToArray()));
                testResult = engine.Evaluate("mean(FEMALE)").AsNumeric();
                tbREngine.Text += de.Key.ToString() + " Female = " + testResult[0].ToString() + "\n\n";
                meanLoop++;
            }

        }

        private double doMeans(double[] mean)
        {
            REngine engine = REngine.GetInstance();

            engine.SetSymbol("ALL", engine.CreateNumericVector(mean));
            var testResult = engine.Evaluate("mean(ALL)").AsNumeric();

            return testResult[0];

        }
        
        private void doMedian()
        {
            REngine engine = REngine.GetInstance();
            daoChart _daoChart = new daoChart();

            DataSet dsRec = new DataSet();
            DataTable dtRec = new DataTable();
            ListDictionary Diets = new ListDictionary();

            dsRec = _daoChart.getRData(1);
            dtRec = dsRec.Tables[0];

            int k = 0;
            for (int j = 0; j < dtRec.Rows.Count; j++)
            {
                if (!Diets.Contains(dtRec.Rows[j]["C"].ToString()))
                {
                    Diets.Add(dtRec.Rows[j]["C"].ToString(), k);
                    k++;
                }
            }
            List<double>[] dDataAll = new List<double>[Diets.Count];
            List<double>[] dDataFemale = new List<double>[Diets.Count];
            List<double>[] dDataMale = new List<double>[Diets.Count];


            foreach (DictionaryEntry de in Diets)
            {
                dDataAll[Convert.ToInt32(de.Value.ToString())] = new List<double>();
                dDataMale[Convert.ToInt32(de.Value.ToString())] = new List<double>(); 
                dDataFemale[Convert.ToInt32(de.Value.ToString())] = new List<double>();
            }

            for (int i = 0; i < dtRec.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(dtRec.Rows[i]["WEIGHT"].ToString()))
                    continue;

                foreach (DictionaryEntry entry in Diets)
                {
                    if (entry.Key.ToString().Equals(dtRec.Rows[i]["C"].ToString()))
                    {
                        dDataAll[Convert.ToInt32(entry.Value.ToString())].Add(Convert.ToDouble(dtRec.Rows[i]["WEIGHT"].ToString()));

                        if (dtRec.Rows[i]["SEX"].ToString().Equals("M"))
                            dDataMale[Convert.ToInt32(entry.Value.ToString())].Add(Convert.ToDouble(dtRec.Rows[i]["WEIGHT"].ToString()));
                        else
                            dDataFemale[Convert.ToInt32(entry.Value.ToString())].Add(Convert.ToDouble(dtRec.Rows[i]["WEIGHT"].ToString()));

                        break;
                    }

                }
            }

            int meanLoop = 0;
            foreach(DictionaryEntry de in Diets)
            {
                engine.SetSymbol("ALL", engine.CreateNumericVector(dDataAll[meanLoop].ToArray()));
                var testResult = engine.Evaluate("median(ALL)").AsNumeric();
                tbREngine.Text += de.Key.ToString() + " All = " + testResult[0].ToString() + "\n";
                engine.SetSymbol("MALE", engine.CreateNumericVector(dDataMale[meanLoop].ToArray()));
                testResult = engine.Evaluate("median(MALE)").AsNumeric();
                tbREngine.Text += de.Key.ToString() + " Male = " + testResult[0].ToString() + "\n";
                engine.SetSymbol("FEMALE", engine.CreateNumericVector(dDataFemale[meanLoop].ToArray()));
                testResult = engine.Evaluate("median(FEMALE)").AsNumeric();
                tbREngine.Text += de.Key.ToString() + " Female = " + testResult[0].ToString() + "\n\n";
                meanLoop++;
            }

        }

        private void doQuantile()
        {
            REngine engine = REngine.GetInstance();
            daoChart _daoChart = new daoChart();

            DataSet dsRec = new DataSet();
            DataTable dtRec = new DataTable();
            ListDictionary Diets = new ListDictionary();

            dsRec = _daoChart.getRData(1);
            dtRec = dsRec.Tables[0];

            int k = 0;
            for (int j = 0; j < dtRec.Rows.Count; j++)
            {
                if (!Diets.Contains(dtRec.Rows[j]["C"].ToString()))
                {
                    Diets.Add(dtRec.Rows[j]["C"].ToString(), k);
                    k++;
                }
            }
            List<double>[] dDataAll = new List<double>[Diets.Count];
            List<double>[] dDataFemale = new List<double>[Diets.Count];
            List<double>[] dDataMale = new List<double>[Diets.Count];


            foreach (DictionaryEntry de in Diets)
            {
                dDataAll[Convert.ToInt32(de.Value.ToString())] = new List<double>();
                dDataMale[Convert.ToInt32(de.Value.ToString())] = new List<double>();
                dDataFemale[Convert.ToInt32(de.Value.ToString())] = new List<double>();
            }

            for (int i = 0; i < dtRec.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(dtRec.Rows[i]["WEIGHT"].ToString()))
                    continue;

                foreach (DictionaryEntry entry in Diets)
                {
                    if (entry.Key.ToString().Equals(dtRec.Rows[i]["C"].ToString()))
                    {
                        dDataAll[Convert.ToInt32(entry.Value.ToString())].Add(Convert.ToDouble(dtRec.Rows[i]["WEIGHT"].ToString()));

                        if (dtRec.Rows[i]["SEX"].ToString().Equals("M"))
                            dDataMale[Convert.ToInt32(entry.Value.ToString())].Add(Convert.ToDouble(dtRec.Rows[i]["WEIGHT"].ToString()));
                        else
                            dDataFemale[Convert.ToInt32(entry.Value.ToString())].Add(Convert.ToDouble(dtRec.Rows[i]["WEIGHT"].ToString()));

                        break;
                    }

                }
            }

            int meanLoop = 0;
            foreach (DictionaryEntry de in Diets)
            {
                engine.SetSymbol("ALL", engine.CreateNumericVector(dDataAll[meanLoop].ToArray()));
                var testResult = engine.Evaluate("quantile(ALL)").AsNumeric();
                tbREngine.Text += de.Key.ToString() + " All \n";
                for (int qloop = 0; qloop < 4; qloop++ )
                    tbREngine.Text += testResult[qloop].ToString() + "\n";
                tbREngine.Text += "\n";
                engine.SetSymbol("MALE", engine.CreateNumericVector(dDataMale[meanLoop].ToArray()));
                testResult = engine.Evaluate("quantile(MALE)").AsNumeric();
                tbREngine.Text += de.Key.ToString() + " Male \n";
                for (int qloop = 0; qloop < 4; qloop++)
                    tbREngine.Text += testResult[qloop].ToString() + "\n";
                tbREngine.Text += "\n";
                engine.SetSymbol("FEMALE", engine.CreateNumericVector(dDataFemale[meanLoop].ToArray()));
                testResult = engine.Evaluate("boxplot(FEMALE, vertical=true)").AsNumeric();
                tbREngine.Text += de.Key.ToString() + " Female \n";
                for (int qloop = 0; qloop < 4; qloop++)
                    tbREngine.Text += testResult[qloop].ToString() + "\n";
                tbREngine.Text += "\n";
                meanLoop++;
            }

        }
        private void BarPlot()
        {
            REngine engine = REngine.GetInstance();
            DataSet ds = new DataSet();
            ds = _daoChart.getBarChartData(exID, "");
            engine.Evaluate("cars <- c(1, 3, 6, 4, 9)");
            engine.Evaluate("barplot(cars)");

        }

        private void PlotGraph()
        {
            REngine engine = REngine.GetInstance();
            DataSet ds = new DataSet();
            ds = _daoChart.getBarChartData(exID, "");
            engine.Evaluate("cars <- c(1, 3, 6, 4, 9)");
            engine.Evaluate("plot(cars)");
        }

        private void BoxPlot()
        {
            REngine engine = REngine.GetInstance();
            DataSet ds = new DataSet();
            ds = _daoChart.getBarChartData(exID, "");
            engine.Evaluate("cars <- c(1, 3, 6, 4, 9)");
            engine.Evaluate("par(mfrow = c(4,2))");
            for (int i = 0; i < 8; i++)
            {
                engine.Evaluate("boxplot(cars)");
            }
            //engine.Evaluate("par(mfrow = c(6,1))");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlotGraph();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BarPlot();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BoxPlot();
        }

    }
}
