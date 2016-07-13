using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BiologyDepartment
{
    public partial class ctlRScripts : UserControl
    {
        private string sPostgresSQL = "";
        private string sErrorMsg = "Data string is empty.  Please use the Data tab to set data.";
        private string sDataFrame = "dframe < -dbGetQuery(con, sql)";
        private string sXData = "";
        private string sYData = "";
        private string sFactor = "";
        string sPlot = "";
        private bool bLoad = true;
        private Data.DataUtil _dataUtil = new Data.DataUtil();

        private enum GGPlot2
        {
            [Description("geom_abline()")]
            Slope,
            [Description("geom_area()")]
            Area,
            [Description("geom_bar()")]
            Bar,
            [Description("geom_boxplot()")]
            BoxPlot,
            [Description("geom_contour")]
            Contour,
            [Description("geom_crossbar()")]
            Crossbar,
            [Description("geom_density()")]
            Density,
            [Description("geom_density2d()")]
            Density2d,
            [Description("geom_dotplot()")]
            DotPlot,
            [Description("geom_errorbar()")]
            ErrorBar,
            [Description("geom_errorbarh()")]
            ErrorBarH,
            [Description("geom_freqpoly()")]
            FrequencyPolygon,
            [Description("geom_histogram()")]
            Histogram,
            [Description("geom_hline()")]
            HorizontalLine,
            [Description("geom_linerange()")]
            LineRange,
            [Description("geom_path()")]
            Path,
            [Description("geom_points()")]
            ScatterPlot,
            [Description("geom_quantile()")]
            Quantile,
            [Description("geom_vline()")]
            VerticalLine,
        }

        private enum GGStat
        {
            StatBin,
            StatBin2d,
            StatBindot,
            StatBinhex,
            StatBoxplot,
            StatContour,
            StatDensity,
            StatDensity2d,
            StatECDF,
            StatFunction,
            StatIdenity,
            StatQQ,
            StatQuantile,
            StatSmooth,
            StatSpoke,
            StatSum,
            StatSummary,
            StatSummaryHex,
            StatSumary2d,
            StatUnique,
            StatYDensity
        }

        public ctlRScripts()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            if (bLoad || GlobalVariables.RDataIsDirty)
            {
                _dataUtil.ExportToExcel(GlobalVariables.FilteredGrid, true);
                btnSetScript.PerformClick();
                
                PopulateForGGPlot();
                PopulateForLatticeExtra();
                PopulateComboBoxes();
                bLoad = false;
                GlobalVariables.RDataIsDirty = false;
            }
        }

        private void PopulateComboBoxes()
        {
            cmbXAxisData.Items.Clear();
            cmbYAxisData.Items.Clear();
            cmbGroupData.Items.Clear();

            foreach (string s in GlobalVariables.GetSQLColumns)
            {
                cmbXAxisData.Items.Add(s);
                cmbYAxisData.Items.Add(s);
                cmbGroupData.Items.Add(s);
            }   
        }

        private void btnClipBoard_Click(object sender, EventArgs e)
        {
            if (rtbRScript.Text != "")
                Clipboard.SetDataObject(rtbRScript.Text);
        }

        private void btnSetScript_Click(object sender, EventArgs e)
        {
            rtbRScript.Text = "";
            rtbRScript.Text += "library(ggplot2) \n";
            rtbRScript.Text += "sql <- \"" + GlobalVariables.StatsQuery + "\" \n";

            if (cmbXAxisData.Text != null)
                sXData = cmbXAxisData.Text;
            if (cmbYAxisData.Text != null)
                sYData = cmbYAxisData.Text;
            if (cmbGroupData.Text != null)
                sFactor = ", \"" + cmbGroupData.Text + "\"";

            rtbRScript.Text += "dframe <- postgressConnect(sql) \n";
            rtbRScript.Text += "theSummary <- summarySE(dframe, measurevar = \"" + sYData + "\", groupvars = c(\"" + sXData + "\"" +
                                sFactor + "), TRUE)" + Environment.NewLine;

            if (txtGraphOrder.Text != "")
            {
                rtbRScript.Text += "theSummary$" + sXData + " <- factor(theSummary$" + sXData + ", levels = c(" + txtGraphOrder + "))";
            }
            rtbRScript.Text += "theSummary \n";

            foreach(TreeNode node in tvGGPlot2.Nodes)
            {
                if(node.Checked)
                    SetGGPlot(node.Text, node.Index);
            }
            
        }

        private void PopulateForLatticeExtra()
        {

        }

        private void PopulateForGGPlot()
        {
            tvGGPlot2.Nodes.Clear();
            var enums = Enum.GetValues(typeof(GGPlot2));
            foreach (GGPlot2 plot in enums)
            {
                TreeNode treeNode = new TreeNode(plot.ToString());
                tvGGPlot2.Nodes.Add(treeNode);

                switch(plot.ToString())
                {
                    case "Bar":
                        treeNode.ToolTipText = "Bars, rectangles with bases on x-axis";
                        treeNode.Nodes.Add(new TreeNode("Summarize Data"));
                        treeNode.Nodes[0].ToolTipText = "Choose how to summarize the data. The default is by mean.";
                        treeNode.Nodes.Add(new TreeNode("Chart Options"));
                        treeNode.Nodes[1].ToolTipText = "Chart options.  Error bars are selected by default.";
                        treeNode.Nodes.Add(new TreeNode("Color Options"));
                        treeNode.Nodes[2].ToolTipText = "Color options.  By default the color is set by R.";
                        treeNode.Nodes.Add(new TreeNode("Text Options"));
                        treeNode.Nodes[3].ToolTipText = "Text label options for the bars";

                        foreach (TreeNode subNode in treeNode.Nodes)
                        {
                            switch(subNode.Text)
                            {
                                case "Summarize Data":
                                    subNode.Nodes.Add(new TreeNode("Count"));
                                    subNode.Nodes.Add(new TreeNode("Sum"));
                                    subNode.Nodes.Add(new TreeNode("Mean"));
                                    subNode.Nodes.Add(new TreeNode("Median"));
                                    subNode.Nodes[2].Checked = true;
                                    break;
                                case "Chart Options":
                                    subNode.Nodes.Add(new TreeNode("Dodge"));
                                    subNode.Nodes.Add(new TreeNode("Error Bar"));
                                    subNode.Nodes.Add(new TreeNode("Flip"));
                                    subNode.Nodes.Add(new TreeNode("Panels"));
                                    subNode.Nodes.Add(new TreeNode("Slope"));
                                    subNode.Nodes.Add(new TreeNode("Smooth"));
                                    subNode.Nodes[0].Checked = true;
                                    break;
                                case "Color Options":
                                    subNode.Nodes.Add(new TreeNode("Default"));
                                    subNode.Nodes.Add(new TreeNode("Manual"));
                                    subNode.Nodes.Add(new TreeNode("Brewer"));
                                    break;
                                case "Text Options":
                                    subNode.Nodes.Add(new TreeNode("Confidence Interval"));
                                    subNode.Nodes.Add(new TreeNode("Standard Error"));
                                    subNode.Nodes.Add(new TreeNode("Mean"));
                                    subNode.Nodes.Add(new TreeNode("Median"));
                                    break;
                            }
                            
                        }
                        break;
                    case "BoxPlot":
                        treeNode.ToolTipText = "BoxPlot, aka Box and Whiskers";

                        treeNode.Nodes.Add(new TreeNode("Chart Options"));
                        treeNode.Nodes[0].ToolTipText = "Chart options.  Error bars are selected by default.";
                        treeNode.Nodes.Add(new TreeNode("Color Options"));
                        treeNode.Nodes[1].ToolTipText = "Color options.  By default the color is set by R.";
                        treeNode.Nodes.Add(new TreeNode("Text Options"));
                        treeNode.Nodes[2].ToolTipText = "Text label options for the bars";

                        foreach (TreeNode subNode in treeNode.Nodes)
                        {
                            switch (subNode.Text)
                            {
                                case "Chart Options":
                                    subNode.Nodes.Add(new TreeNode("Dodge"));
                                    subNode.Nodes.Add(new TreeNode("Flip"));
                                    subNode.Nodes.Add(new TreeNode("Panels"));
                                    subNode.Nodes[0].Checked = true;
                                    break;
                                case "Color Options":
                                    subNode.Nodes.Add(new TreeNode("Default"));
                                    subNode.Nodes.Add(new TreeNode("Manual"));
                                    subNode.Nodes.Add(new TreeNode("Brewer"));
                                    subNode.Nodes[0].Checked = true;
                                    break;
                                case "Text Options":
                                    subNode.Nodes.Add(new TreeNode("Confidence Interval"));
                                    subNode.Nodes.Add(new TreeNode("Standard Error"));
                                    subNode.Nodes.Add(new TreeNode("Mean"));
                                    subNode.Nodes.Add(new TreeNode("Median"));
                                    break;
                            }

                        }
                        break;
                    }
                }
            }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Initialize();
        }

        private string GetGGPlotDescription(string thePlot)
        {
            GGPlot2 value = (GGPlot2)System.Enum.Parse(typeof(GGPlot2), thePlot);;
            DescriptionAttribute attribute;
            string result;

            var field = value.GetType().GetField(value.ToString());
            attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
            result = attribute != null ? attribute.Description : string.Empty;

            return result;
        }

        private void SetGGPlot(string sName, int nIndex)
        {
            sPlot = "";
            sPlot = @"p1 <- ggplot(aes(y = " + sYData + ", x = factor(" + sXData + ")" + sFactor + @"
                            ymin = errMin, ymax = errMax), data = dframe) +\n";
            
            TreeNode node = tvGGPlot2.Nodes[nIndex];
            switch (sName)
            {
                case "Bar":
                    SetBarChartOptions(node);
                    SetPlotScript(sPlot);
                    break;
                case "BoxPlot":
                    SetBoxPlotOptions(node);
                    SetPlotScript(sPlot);
                    break;
                default:
                    break;
            }
        }

        private void SetPlotScript(string sPlotInfo)
        {
            sPlot += "p1 <- p1 + ggtitle(" + "\"" + txtMainTitle.Text + "\"" + ")\n";
            sPlot += "p1 <- p1 + xlab(" + "\"" + txtBoxXAxis.Text + "\"" + ")\n";
            sPlot += "p1 <- p1 + ylab(" + "\"" + txtBoxYAxis.Text + "\"" + ")";
            sPlot += "\n\np1\n\n";
            rtbRScript.Text += sPlot;
        }

        private void SetBarChartOptions(TreeNode node)
        {
            string sGeom = "";
            string sPosition = "";
            string sError = "";
            string sFill = "";
            string sSmooth = "";
            string sColor = "";
            string sText = "";
            int nSpacer = 1;
            double dSpacer = -1.5;

            TreeNode tcChart = node.Nodes[1];
            TreeNode tcColor = node.Nodes[2];
            TreeNode tcText = node.Nodes[3];

            foreach (TreeNode grandChild in tcChart.Nodes)
            {
                if (grandChild.Checked && grandChild.Text.Equals("Dodge"))
                    sPosition = ", position = position_dodge()";
                else if (grandChild.Checked && grandChild.Text.Equals("Error Bar"))
                    sError += "p1 <- p1 + geom_errorbar(width = .9" + sPosition + ") \n";
                else if (grandChild.Checked && grandChild.Text.Equals("Flip"))
                    sError += "p1 <- p1 + coord_flip() \n ";
                else if (grandChild.Checked && grandChild.Text.Equals("Panels")
                    && !(string.IsNullOrEmpty(cmbPanels.Text)))
                    sError += "p1 <- p1 + facet_grid(. ~ " + cmbPanels.Text + ") \n";
                else if (grandChild.Checked && grandChild.Text.Equals("Slope"))
                    sSmooth = "p1 <- p1 + stat_smooth(method = \"lm\", se = FALSE) \n";
                else if (grandChild.Checked && grandChild.Text.Equals("Smooth"))
                    sSmooth = "p1 <- p1 + stat_smooth(method = \"lm\", aes(group = 1)) \n";
            }

            foreach (TreeNode grandChild in tcColor.Nodes)
            {
                if (grandChild.Checked && grandChild.Text.Equals("Default"))
                    sColor = "";
                else if (grandChild.Checked && grandChild.Text.Equals("Manual")
                    && !(string.IsNullOrEmpty(txtColor.Text)))
                    sColor += "p1 <- p1 + scale_fill_manual(values = c(" + txtColor.Text + ")) \n";
                else if (grandChild.Checked && grandChild.Text.Equals("Brewer"))
                    sColor += "p1 <- p1 + scale_fill_brewer() \n ";
            }

            foreach (TreeNode grandChild in tcText.Nodes)
            {
                if (grandChild.Checked && grandChild.Text.Equals("Confidence Interval"))
                {
                    sText += "p1 <- p1 + geom_text(aes(label = round(ci, 3), vjust=(" + (dSpacer * nSpacer).ToString() + "))) \n";
                    nSpacer++;
                }
                else if (grandChild.Checked && grandChild.Text.Equals("Standard Error"))
                {
                    sText += "p1 <- p1 + geom_text(aes(label = round(se, 3), vjust=(" + (dSpacer * nSpacer).ToString() + "))) \n";
                    nSpacer++;
                }
                else if (grandChild.Checked && grandChild.Text.Equals("Mean"))
                {
                    sText += "p1 <- p1 + geom_text(aes(label = round(mean, 3), vjust=(" + (dSpacer * nSpacer).ToString() + "))) \n";
                    nSpacer++;
                }
                if (grandChild.Checked && grandChild.Text.Equals("Median"))
                {
                    sText += "p1 <- p1 + geom_text(aes(label = round(median, 3), vjust=(-1.5 * " + nSpacer.ToString() + "))) \n";
                    nSpacer++;
                }
            }

            if (cmbGroupData.Text != null)
                sFill = ",fill=" + cmbGroupData.Text;

            sGeom = @"p1 <- p1 + geom_bar(stat = ""identity""" + sPosition + ") " + Environment.NewLine + sError + sSmooth + sColor + sText;

            TreeNode tcSummary = node.Nodes[0];
            foreach (TreeNode grandChild in tcSummary.Nodes)
            {
                if (grandChild.Checked)
                {
                    switch (grandChild.Text)
                    {
                        case "Count":
                            sPlot = @"p1 <- ggplot(aes(y = N, x = factor(" + sXData + "), ymin = errMin, ymax = errMax" + sFill + "), data = theSummary) \n ";
                            sPlot += sGeom;
                            break;
                        case "Sum":
                            sPlot = @"p1 <- ggplot(aes(y = sum, x = factor(" + sXData + "), ymin = errMin, ymax = errMax" + sFill + "), data = theSummary) \n ";
                            sPlot += sGeom;
                            break;
                        case "Mean":
                            sPlot = @"p1 <- ggplot(aes(y = mean, x = factor(" + sXData + "), ymin = errMin, ymax = errMax" + sFill + "), data = theSummary) \n ";
                            sPlot += sGeom;
                            break;
                        case "Median":
                            sPlot = @"p1 <- ggplot(aes(y = median, x = factor(" + sXData + "), ymin = errMin, ymax = errMax" + sFill + "), data = theSummary) \n ";
                            sPlot += sGeom;
                            break;
                    }
                }
            }
        }

        private void SetBoxPlotOptions(TreeNode node)
        {
            string sGeom = "";
            string sPosition = "";
            string sError = "";
            string sFill = "";
            string sSmooth = "";
            string sColor = "";
            string sText = "";
            int nSpacer = 1;
            double dSpacer = -1.5;

            TreeNode tcChart = node.Nodes[0];
            TreeNode tcColor = node.Nodes[1];
            TreeNode tcText = node.Nodes[2];

            foreach (TreeNode grandChild in tcChart.Nodes)
            {
                if (grandChild.Checked && grandChild.Text.Equals("Dodge"))
                    sPosition = ", position = position_dodge()";
                else if (grandChild.Checked && grandChild.Text.Equals("Error Bar"))
                    sError += "p1 <- p1 + geom_errorbar(width = .9" + sPosition + ") \n";
                else if (grandChild.Checked && grandChild.Text.Equals("Flip"))
                    sError += "p1 <- p1 + coord_flip() \n ";
                else if (grandChild.Checked && grandChild.Text.Equals("Panels")
                    && !(string.IsNullOrEmpty(cmbPanels.Text)))
                    sError += "p1 <- p1 + facet_grid(. ~ " + cmbPanels.Text + ") \n";
                else if (grandChild.Checked && grandChild.Text.Equals("Slope"))
                    sSmooth = "p1 <- p1 + stat_smooth(method = \"lm\", se = FALSE) \n";
                else if (grandChild.Checked && grandChild.Text.Equals("Smooth"))
                    sSmooth = "p1 <- p1 + stat_smooth(method = \"lm\", aes(group = 1)) \n";
            }

            foreach (TreeNode grandChild in tcColor.Nodes)
            {
                if (grandChild.Checked && grandChild.Text.Equals("Default"))
                    sColor = "";
                else if (grandChild.Checked && grandChild.Text.Equals("Manual")
                    && !(string.IsNullOrEmpty(txtColor.Text)))
                    sColor += "p1 <- p1 + scale_fill_manual(values = c(" + txtColor.Text + ")) \n";
                else if (grandChild.Checked && grandChild.Text.Equals("Brewer"))
                    sColor += "p1 <- p1 + scale_fill_brewer() \n ";
            }

            foreach (TreeNode grandChild in tcText.Nodes)
            {
                if (grandChild.Checked && grandChild.Text.Equals("Confidence Interval"))
                {
                    sText += "p1 <- p1 + geom_text(aes(label = round(ci, 3), vjust=(" + (dSpacer * nSpacer).ToString() + "))) \n";
                    nSpacer++;
                }
                else if (grandChild.Checked && grandChild.Text.Equals("Standard Error"))
                {
                    sText += "p1 <- p1 + geom_text(aes(label = round(se, 3), vjust=(" + (dSpacer * nSpacer).ToString() + "))) \n";
                    nSpacer++;
                }
                else if (grandChild.Checked && grandChild.Text.Equals("Mean"))
                {
                    sText += "p1 <- p1 + geom_text(aes(label = round(mean, 3), vjust=(" + (dSpacer * nSpacer).ToString() + "))) \n";
                    nSpacer++;
                }
                if (grandChild.Checked && grandChild.Text.Equals("Median"))
                {
                    sText += "p1 <- p1 + geom_text(aes(label = round(median, 3), vjust=(-1.5 * " + nSpacer.ToString() + "))) \n";
                    nSpacer++;
                }
            }

            if (cmbGroupData.Text != null)
                sFill = ",fill=" + cmbGroupData.Text;

            sGeom = @"p1 <- p1 + geom_boxplot(stat = ""identity""" + sPosition + ") " + Environment.NewLine + sError + sSmooth + sColor + sText;
            sPlot = @"p1 <- ggplot(aes(x = factor(" + sXData + "), ymin = Q0, lower = Q25, middle = Q50, upper = Q75, ymax = Q100" + sFill + "), data = theSummary) \n ";
            sPlot += sGeom;
        }
    }
}
