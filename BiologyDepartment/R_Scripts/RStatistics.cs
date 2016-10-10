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
using System.Reflection;
using System.Deployment.Application;
using System.Security.AccessControl;
using System.Management;
using System.Management.Instrumentation;
using RDotNet.NativeLibrary;
using System.Security.Permissions;
using Microsoft.Win32;

namespace BiologyDepartment
{
    class RStatistics
    {
        private REngine engine = REngine.GetInstance();
        private string sReturn = "";
        List<string> lsReturn = new List<string>();
        bool devOn = false;
        DataTable aovTable;
        

        public RStatistics()
        {
            engine.Evaluate("library(graphics)");
            engine.Evaluate("library(ggplot2)");
            engine.Evaluate("library(latticeExtra)");
           
        }

        public string doTTest(DataSet ds)
        {
            if (ds.Tables[0].Rows.Count == 0)
                return null;

            DataTable dtRec = new DataTable();
            ListDictionary Diets = new ListDictionary();

            dtRec = ds.Tables[0];

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
                        sReturn += deVector.Key.ToString() + "\\" + compareVector.Key.ToString();
                        sReturn+= "\nP1-value = {0:0.000}" + p1 + "\n\n";
                        engine.ClearGlobalEnvironment();
                    }
                }
            }

            return sReturn;
        }

        public DataTable doAnova(List<string> x, List<double>y, bool chart)
        {
            if (devOn)
                return aovTable;

            CharacterVector cVector = engine.CreateCharacterVector(x.ToArray());
            NumericVector nVector = engine.CreateNumericVector(y.ToArray());
            aovTable = new DataTable();
            List<string> aovReturn = new List<string>();

            engine.SetSymbol("x", cVector);
            engine.SetSymbol("y", nVector);
            engine.Evaluate("df <-data.frame(xAxis = factor(c(x)), yAxis=c(y))");
            engine.Evaluate("theAOV <- aov(yAxis ~ xAxis, data = df)");
            engine.Evaluate("theSummary <- summary(theAOV)");
            var resName = engine.Evaluate("theSummary").AsList().AsCharacter();
            var resTukey = engine.Evaluate("TukeyHSD(theAOV)").AsList();
            if (chart)
            {
                try
                {
                    engine.Evaluate("graphics.off()");
                    engine.Evaluate("plot(theAOV)");
                    devOn = true;
                }
                catch
                {
                    MessageBox.Show("The AOV Plot has caused an error, please make sure to shut down the tables screen before settinga  new chart.", "AOV Plot Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            var test = resTukey[0].AsNumeric();
            foreach (var item in test)
                aovReturn.Add(item.ToString());

            if (aovReturn.Contains("RDotNet.NumericVector"))
                aovReturn.Remove("RDotNet.NumericVector");

            aovTable.Clear();

            aovTable.Columns.Add("Comparison");
            aovTable.Columns.Add("Difference");
            aovTable.Columns.Add("Lower");
            aovTable.Columns.Add("Upper");
            aovTable.Columns.Add("P Adjustment");

            int j = 0;
            List<string> colors = new List<string>();

            foreach(string s in x)
            {
                foreach(string t in x)
                {
                    if(!s.Equals(t) && (!colors.Contains(s + "//" + t)) && (!colors.Contains(t + "//" + s)))
                    {
                        colors.Add(s + "//" + t);
                        DataRow newRow = aovTable.NewRow();
                        newRow["Comparison"] = s + "//" + t;
                        newRow["Difference"] = aovReturn[j].ToString();
                        newRow["Lower"] = aovReturn[j+1].ToString();
                        newRow["Upper"] = aovReturn[j+2].ToString();
                        newRow["P Adjustment"] = aovReturn[j + 3].ToString();
                        aovTable.Rows.Add(newRow);
                        j = j + 4;
                    }
                }
            }

            return aovTable;
            
        }


        public string  doMeans(DataTable dt)
        {
            if (dt.Rows.Count == 0)
                return null;

            ListDictionary Diets = new ListDictionary();

            int k = 0;
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                if (!Diets.Contains(dt.Rows[j]["COLOR"].ToString()))
                {
                    Diets.Add(dt.Rows[j]["COLOR"].ToString(), k);
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

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(dt.Rows[i]["WEIGHT"].ToString()))
                    continue;

                foreach (DictionaryEntry entry in Diets)
                {
                    if (entry.Key.ToString().Equals(dt.Rows[i]["COLOR"].ToString()))
                    {
                        dDataAll[Convert.ToInt32(entry.Value.ToString())].Add(Convert.ToDouble(dt.Rows[i]["WEIGHT"].ToString()));

                        if (dt.Rows[i]["SEX"].ToString().Equals("M"))
                            dDataMale[Convert.ToInt32(entry.Value.ToString())].Add(Convert.ToDouble(dt.Rows[i]["WEIGHT"].ToString()));
                        else
                            dDataFemale[Convert.ToInt32(entry.Value.ToString())].Add(Convert.ToDouble(dt.Rows[i]["WEIGHT"].ToString()));

                        break;
                    }

                }
            }

            int meanLoop = 0;
            foreach (DictionaryEntry de in Diets)
            {
                engine.SetSymbol("ALL", engine.CreateNumericVector(dDataAll[meanLoop].ToArray()));
                var testResult = engine.Evaluate("mean(ALL)").AsNumeric();
                sReturn += de.Key.ToString() + " All = " + testResult[0].ToString() + "\n";
                engine.SetSymbol("MALE", engine.CreateNumericVector(dDataMale[meanLoop].ToArray()));
                testResult = engine.Evaluate("mean(MALE)").AsNumeric();
                sReturn += de.Key.ToString() + " Male = " + testResult[0].ToString() + "\n";
                engine.SetSymbol("FEMALE", engine.CreateNumericVector(dDataFemale[meanLoop].ToArray()));
                testResult = engine.Evaluate("mean(FEMALE)").AsNumeric();
                sReturn += de.Key.ToString() + " Female = " + testResult[0].ToString() + "\n\n";
                meanLoop++;
            }

            return sReturn;
        }

        public double doMeans(double[] mean)
        {
            if (string.IsNullOrEmpty(mean.ToString()))
                return 0;

            engine.SetSymbol("ALL", engine.CreateNumericVector(mean));
            var testResult = engine.Evaluate("mean(ALL)").AsNumeric();

            return testResult[0];

        }

        public string doMedian(DataSet ds)
        {
            if (ds.Tables[0].Rows.Count == 0)
                return null;

            DataTable dtRec = new DataTable();
            ListDictionary Diets = new ListDictionary();

            dtRec = ds.Tables[0];

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
                var testResult = engine.Evaluate("median(ALL)").AsNumeric();
                sReturn += de.Key.ToString() + " All = " + testResult[0].ToString() + "\n";
                engine.SetSymbol("MALE", engine.CreateNumericVector(dDataMale[meanLoop].ToArray()));
                testResult = engine.Evaluate("median(MALE)").AsNumeric();
                sReturn += de.Key.ToString() + " Male = " + testResult[0].ToString() + "\n";
                engine.SetSymbol("FEMALE", engine.CreateNumericVector(dDataFemale[meanLoop].ToArray()));
                testResult = engine.Evaluate("median(FEMALE)").AsNumeric();
                sReturn += de.Key.ToString() + " Female = " + testResult[0].ToString() + "\n\n";
                meanLoop++;
            }

            return sReturn;
        }

        public string doQuantile(DataSet ds)
        {
            if (ds.Tables[0].Rows.Count == 0)
                return null;

            DataTable dtRec = new DataTable();
            ListDictionary Diets = new ListDictionary();

            dtRec = ds.Tables[0];

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
                sReturn += de.Key.ToString() + " All \n";
                for (int qloop = 0; qloop < 4; qloop++)
                    sReturn += testResult[qloop].ToString() + "\n";
                sReturn += "\n";
                engine.SetSymbol("MALE", engine.CreateNumericVector(dDataMale[meanLoop].ToArray()));
                testResult = engine.Evaluate("quantile(MALE)").AsNumeric();
                sReturn += de.Key.ToString() + " Male \n";
                for (int qloop = 0; qloop < 4; qloop++)
                    sReturn += testResult[qloop].ToString() + "\n";
                sReturn += "\n";
                engine.SetSymbol("FEMALE", engine.CreateNumericVector(dDataFemale[meanLoop].ToArray()));
                testResult = engine.Evaluate("boxplot(FEMALE, vertical=true)").AsNumeric();
                sReturn += de.Key.ToString() + " Female \n";
                for (int qloop = 0; qloop < 4; qloop++)
                    sReturn += testResult[qloop].ToString() + "\n";
                sReturn += "\n";
                meanLoop++;
            }

            return sReturn;

        }

        public List<string> BarPlot(List<string> x, List<double>y, List<string> titles, List<Font>fonts, List<string>Rotation, List<string>Colors)
        {
            ListDictionary ldBarPlot = new ListDictionary();
            List<string> xAxis = new List<string>();
            List<double> yAxis = new List<double>();
            List<double> StandardErr = new List<double>();
            List<double> dValues = new List<double>();

            lsReturn.Clear();

            string old = "";

            for (int i = 0; i < x.Count; i++ )
            {
                if (!(old.Equals(x[i])))
                {
                    if (!(String.IsNullOrEmpty(old)))
                    {
                        engine.SetSymbol("ALL", engine.CreateNumericVector(dValues.ToArray()));
                        var testResult = engine.Evaluate("mean(ALL)").AsNumeric();
                        xAxis.Add(old);
                        yAxis.Add(Math.Round(Convert.ToDouble(testResult[0].ToString()),2));
                        lsReturn.Add(old);
                        testResult = engine.Evaluate("quantile(ALL)").AsNumeric();
                        for (int j = 0; j < testResult.Length; j++ )
                            lsReturn.Add(testResult[j].ToString());
                        testResult = engine.Evaluate("sd(ALL)").AsNumeric();
                        lsReturn.Add(testResult[0].ToString());
                        testResult = engine.Evaluate("sd(ALL)/sqrt(length(ALL))").AsNumeric();
                        lsReturn.Add(testResult[0].ToString());
                        StandardErr.Add(Convert.ToDouble(testResult[0].ToString()));
                    }
                    old = x[i];
                    dValues.Clear();
                }

                dValues.Add(y[i]);

            }

            if (!(String.IsNullOrEmpty(old)))
            {
                engine.SetSymbol("ALL", engine.CreateNumericVector(dValues.ToArray()));
                var testResult = engine.Evaluate("mean(ALL)").AsNumeric();
                xAxis.Add(old);
                yAxis.Add(Math.Round(Convert.ToDouble(testResult[0].ToString()),2));
                lsReturn.Add(old);
                testResult = engine.Evaluate("quantile(ALL)").AsNumeric();
                for (int j = 0; j < testResult.Length; j++)
                    lsReturn.Add(testResult[j].ToString());
                testResult = engine.Evaluate("sd(ALL)").AsNumeric();
                lsReturn.Add(testResult[0].ToString());
                testResult = engine.Evaluate("sd(ALL)/sqrt(length(ALL))").AsNumeric();
                lsReturn.Add(testResult[0].ToString());
                StandardErr.Add(Convert.ToDouble(testResult[0].ToString()));
            }

            CharacterVector cVector = engine.CreateCharacterVector(xAxis.ToArray());
            NumericVector nVector = engine.CreateNumericVector(yAxis.ToArray());
            NumericVector seVector = engine.CreateNumericVector(StandardErr.ToArray());

            engine.Evaluate("setwd('c:/RStat/Pic''");
            engine.SetSymbol("a", cVector);
            engine.SetSymbol("b", nVector);
            engine.SetSymbol("c", seVector);
            engine.Evaluate("df <-data.frame(xAxis = factor(c(a)), yAxis=c(b), se=c(c))");        
            engine.Evaluate("dodge <- position_dodge(width=0.9)");
            engine.Evaluate("limits <- aes(ymax = yAxis + se, ymin=yAxis - se)");

                engine.Evaluate(@"thePlot <- ggplot(df,aes(x=xAxis, y=yAxis)) + geom_bar(stat = 'identity', fill='#FFFFFF', colour='black', position=dodge) +
                            geom_errorbar( aes(ymax = yAxis + se, ymin=yAxis - se), position=dodge, width=0.25)");
            
            //The title with settings
            engine.Evaluate(@"thePlot <- thePlot + ggtitle('" + titles[0].ToString() + @"') +
                            theme(plot.title = element_text(size = " + fonts[0].Size.ToString() + @", colour='" + Colors[0] + "'))");

            engine.Evaluate(@"thePlot <- thePlot + theme(axis.title.x = element_text(face='bold', colour='" + Colors[1] + "', size= " + fonts[1].Size.ToString() + @"),
                                axis.text.x  = element_text(angle=" + Rotation[0].ToString() + @", vjust=0.5, size=" + fonts[2].Size.ToString() + ",colour ='" + Colors[2] + "'))");

            engine.Evaluate(@"thePlot <- thePlot + theme(axis.title.y = element_text(face='bold', colour='" + Colors[1] + "', size=" + fonts[1].Size.ToString() + @"),
                                axis.text.y  = element_text(angle=" + Rotation[1].ToString() + @", size=" + fonts[2].Size.ToString() + ",colour ='" + Colors[2] + "'))");

            //The X/Y Axis with settings
            engine.Evaluate(@"thePlot <- thePlot + labs(x='" + titles[1].ToString() +"', y='" + titles[2].ToString() +"')");

            engine.Evaluate("thePlot");
            var result = engine.Evaluate("summary(thePlot)");

            return lsReturn;

        }

        public List<string> BoxPlot(List<string> x, List<double> y, List<string> titles, List<Font> fonts, List<string> Rotation, List<string> Colors)
        {
            ListDictionary ldBarPlot = new ListDictionary();
            List<string> xAxis = new List<string>();
            List<double> yAxis = new List<double>();
            List<double> StandardErr = new List<double>();
            List<double> dValues = new List<double>();
            List<double> yMinimum = new List<double>();
            List<double> yMaximum = new List<double>();
            List<double> yMean = new List<double>();
            List<double> yQuarter = new List<double>();
            List<double> ySeventyfive = new List<double>();

            lsReturn.Clear();

            string old = "";

            for (int i = 0; i < x.Count; i++)
            {
                if (!(old.Equals(x[i])))
                {
                    if (!(String.IsNullOrEmpty(old)))
                    {
                        engine.SetSymbol("ALL", engine.CreateNumericVector(dValues.ToArray()));
                        var testResult = engine.Evaluate("mean(ALL)").AsNumeric();
                        xAxis.Add(old);
                        lsReturn.Add(old);
                        testResult = engine.Evaluate("quantile(ALL)").AsNumeric();
                        for (int j = 0; j < testResult.Length; j++)
                        {
                            lsReturn.Add(testResult[j].ToString());
                            switch (j)
                            {
                                case 0:
                                    yMinimum.Add(testResult[j]);
                                    break;
                                case 1:
                                    yQuarter.Add(testResult[j]);
                                    break;
                                case 2:
                                    yMean.Add(testResult[j]);
                                    break;
                                case 3:
                                    ySeventyfive.Add(testResult[j]);
                                    break;
                                case 4:
                                    yMaximum.Add(testResult[j]);
                                    break;
                            }
                        }
                        testResult = engine.Evaluate("sd(ALL)").AsNumeric();
                        lsReturn.Add(testResult[0].ToString());
                        testResult = engine.Evaluate("sd(ALL)/sqrt(length(ALL))").AsNumeric();
                        lsReturn.Add(testResult[0].ToString());
                        StandardErr.Add(Convert.ToDouble(testResult[0].ToString()));
                    }
                    old = x[i];
                    dValues.Clear();
                }

                dValues.Add(y[i]);

            }

            if (!(String.IsNullOrEmpty(old)))
            {
                engine.SetSymbol("ALL", engine.CreateNumericVector(dValues.ToArray()));
                var testResult = engine.Evaluate("mean(ALL)").AsNumeric();
                xAxis.Add(old);
                yAxis.Add(Math.Round(Convert.ToDouble(testResult[0].ToString()), 2));
                lsReturn.Add(old);
                testResult = engine.Evaluate("quantile(ALL)").AsNumeric();
                for (int j = 0; j < testResult.Length; j++)
                {
                    lsReturn.Add(testResult[j].ToString());
                    switch (j)
                    {
                        case 0:
                            yMinimum.Add(testResult[j]);
                            break;
                        case 1:
                            yQuarter.Add(testResult[j]);
                            break;
                        case 2:
                            yMean.Add(testResult[j]);
                            break;
                        case 3:
                            ySeventyfive.Add(testResult[j]);
                            break;
                        case 4:
                            yMaximum.Add(testResult[j]);
                            break;
                    }
                }
                testResult = engine.Evaluate("sd(ALL)").AsNumeric();
                lsReturn.Add(testResult[0].ToString());
                testResult = engine.Evaluate("sd(ALL)/sqrt(length(ALL))").AsNumeric();
                lsReturn.Add(testResult[0].ToString());
                StandardErr.Add(Convert.ToDouble(testResult[0].ToString()));
            }

            CharacterVector cVector = engine.CreateCharacterVector(xAxis.ToArray());
            NumericVector yMin = engine.CreateNumericVector(yMinimum.ToArray());
            NumericVector y25 = engine.CreateNumericVector(yQuarter.ToArray());
            NumericVector y50 = engine.CreateNumericVector(yMean.ToArray());
            NumericVector y75 = engine.CreateNumericVector(ySeventyfive.ToArray());
            NumericVector yMax = engine.CreateNumericVector(yMaximum.ToArray());

            engine.Evaluate("setwd('c:/RStat/Pic''");
            engine.SetSymbol("a", cVector);
            engine.SetSymbol("b", yMin);
            engine.SetSymbol("c", y25);
            engine.SetSymbol("d", y50);
            engine.SetSymbol("e", y75);
            engine.SetSymbol("f", yMax);
            engine.Evaluate("df <-data.frame(xAxis = factor(c(a)), yMin=c(b), lower=c(c), middle=c(d), upper=c(e), ymax=c(f))");

            engine.Evaluate(@"thePlot <- ggplot(df,aes(x=xAxis, ymin = yMin, lower = lower, middle = middle, upper = upper, ymax = ymax)) + geom_boxplot(stat = 'identity', fill='#FFFFFF', colour='black')");

            //The title with settings
            engine.Evaluate(@"thePlot <- thePlot + ggtitle('" + titles[0].ToString() + @"') +
                            theme(plot.title = element_text(size = " + fonts[0].Size.ToString() + @", colour='" + Colors[0] + "'))");

            engine.Evaluate(@"thePlot <- thePlot + theme(axis.title.x = element_text(face='bold', colour='" + Colors[1] + "', size= " + fonts[1].Size.ToString() + @"),
                                axis.text.x  = element_text(angle=" + Rotation[0].ToString() + @", vjust=0.5, size=" + fonts[2].Size.ToString() + ",colour ='" + Colors[2] + "'))");

            engine.Evaluate(@"thePlot <- thePlot + theme(axis.title.y = element_text(face='bold', colour='" + Colors[1] + "', size=" + fonts[1].Size.ToString() + @"),
                                axis.text.y  = element_text(angle=" + Rotation[1].ToString() + @", size=" + fonts[2].Size.ToString() + ",colour ='" + Colors[2] + "'))");

            //The X/Y Axis with settings
            engine.Evaluate(@"thePlot <- thePlot + labs(x='" + titles[1].ToString() + "', y='" + titles[2].ToString() + "')");

            engine.Evaluate("thePlot");
            var result = engine.Evaluate("summary(thePlot)");

            return lsReturn;

        }

        public void do3dBar()
        {
            engine.Evaluate(@"d <- read.table(text=' x   y     z
                            t1   5   high
                            t1   2   low
                            t1   4   med
                            t2   8   high
                            t2   1   low
                            t2   3   med
                            t3  50   high
                            t3  12   med
                            t3  35   low', header=TRUE)");

            engine.Evaluate(@"cloud(y~x+z, d, panel.3d.cloud=panel.3dbars, col.facet='grey', 
            xbase=0.4, ybase=0.4, scales=list(arrows=FALSE, col=1), 
            par.settings = list(axis.line = list(col = 'transparent')))");
        }

        public void doScatterPlot()
        {
            engine.Evaluate(@"
            set.seed(955)
            # Make some noisily increasing data
            dat <- data.frame(cond = rep(c('A', 'B'), each=10),
                  xvar = 1:20 + rnorm(20,sd=3),
                  yvar = 1:20 + rnorm(20,sd=3))
            head(dat)
            #>   cond      xvar         yvar
            #> 1    A -4.252354  3.473157275
            #> 2    A  1.702318  0.005939612
            #> 3    A  4.323054 -0.094252427
            #> 4    A  1.780628  2.072808278
            #> 5    A 11.537348  1.215440358
            #> 6    A  6.672130  3.608111411

            ggplot(dat, aes(x=xvar, y=yvar)) +
            geom_point(shape=1) +    # Use hollow circles
            geom_smooth(method=lm)   # Add linear regression line 
                             #  (by default includes 95% confidence region)");
        }

        public void doHistogram()
        {
            engine.Evaluate(@"set.seed(1234)
            dat <- data.frame(cond = factor(rep(c('A','B'), each=200)), 
                   rating = c(rnorm(200),rnorm(200, mean=.8)))
                   # View first few rows
            head(dat)
            #>   cond     rating
            #> 1    A -1.2070657
            #> 2    A  0.2774292
            #> 3    A  1.0844412
            #> 4    A -2.3456977
            #> 5    A  0.4291247
            #> 6    A  0.5060559

            # Histogram overlaid with kernel density curve
            ggplot(dat, aes(x=rating)) + 
            geom_histogram(aes(y=..density..),      # Histogram with density instead of count on y-axis
                   binwidth=.5,
                   colour='black', fill='white') +
            geom_density(alpha=.2, fill='#FF6666')  # Overlay with transparent density plot");
        }

        public void doWireFrame()
        {
            engine.Evaluate(@"## volcano  ## 87 x 61 matrix
                                wireframe(volcano, shade = TRUE,
                                aspect = c(61/87, 0.4),
                                light.source = c(10,0,10))");

                                /*g <- expand.grid(x = 1:10, y = 5:15, gr = 1:2)
                                g$z <- log((g$x^g$gr + g$y^2) * g$gr)
                                wireframe(z ~ x * y, data = g, groups = gr,
                                scales = list(arrows = FALSE),
                                drape = TRUE, colorkey = TRUE,
                                screen = list(z = 30, x = -60))

                                cloud(Sepal.Length ~ Petal.Length * Petal.Width | Species, data = iris,
                                screen = list(x = -90, y = 70), distance = .4, zoom = .6)");*/
        }

        public void doWireFrame2(List<string> x, List<double> y)
        {
            List<string> xAxis = new List<string>();
            List<double> yAxis = new List<double>();

            lsReturn.Clear();

            CharacterVector cVector = engine.CreateCharacterVector(x.ToArray());
            NumericVector nVector = engine.CreateNumericVector(y.ToArray());

            engine.SetSymbol("a", cVector);
            engine.SetSymbol("b", nVector);

            engine.Evaluate(@"d <- read.table(text=' x   y     z
                            t1   5   high
                            t1   2   low
                            t1   4   med
                            t2   8   high
                            t2   1   low
                            t2   3   med
                            t3  50   high
                            t3  12   med
                            t3  35   low', header=TRUE)");

            engine.Evaluate(@"## volcano  ## 87 x 61 matrix
                                wireframe(d, shade = TRUE,
                                aspect = c(61/87, 0.4),
                                light.source = c(10,0,10))");


        }

        public void devOff()
        {
            engine.Evaluate("graphics.off()");
            devOn = false;
        }
    }
}
