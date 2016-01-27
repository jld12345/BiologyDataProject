using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections.Specialized;
using System.Collections;

namespace BiologyDepartment
{
    public partial class BarChart : Form
    {
        private static BarChart inst;
        daoChart _daoChart = new daoChart();
        RStatistics _rStats = new RStatistics();
        private DataSet dsExperiments = new DataSet();
        private DataTable dtExperiments = new DataTable();
        private int EX_ID = 0;
        private double devMin= 0;
        private double devMax = 0;
        private double devAvg = 0;
        private string sSexFilters = "";
        private string sWeekFilter = "";
        private string sColorFilter = "";
        private bool bLoad = true;
        private Font fTitle = new Font("Times New Roman", 20, FontStyle.Bold);
        private Font fAxis = new Font("Times New Roman", 20, FontStyle.Bold);
        private Font fXLabel = new Font("Times New Roman", 20, FontStyle.Bold);
        private ListDictionary seriesFont = new ListDictionary();
        List<string> xAxis = new List<string>();
        List<double> yAxis = new List<double>();
        List<string> titles = new List<string>();
        List<Font> fonts = new List<Font>();

        public BarChart()
        {
            InitializeComponent();
        }

        public BarChart(int id)
        {
            InitializeComponent();
            EX_ID = id;
            dsExperiments = _daoChart.getRData(id);
            if (dsExperiments == null)
            {
                MessageBox.Show("Dataset is empty.", "Null Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        public static BarChart CreateInstance()
        {
            if (inst == null || inst.IsDisposed)
            {
                inst = new BarChart();
            }
            else
            {
                MessageBox.Show("An Instance of the Experiments Form is already open.", "Form Open", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return inst;
        }

        public static BarChart CreateInstance(int id)
        {
            if (inst == null || inst.IsDisposed)
            {
                inst = new BarChart(id);
            }
            else
            {
                MessageBox.Show("An Instance of the Experiments Form is already open.", "Form Open", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return inst;
        }

        private void BarChart_Load(object sender, EventArgs e)
        {
            bLoad = true;
            SetChartComboBox();
            LoadColor(EX_ID);
            LoadWeek(EX_ID);
            SetSex();
            SetYAxisChoice();
            SetXAxisChoice();
            bLoad = false;
        }

        private void SetYAxisChoice()
        {
            cmbYAxis.Items.Clear();
            cmbYAxis.Items.Add("Fish Weight");
            cmbYAxis.Items.Add("Fish Length");
            cmbYAxis.SelectedIndex = 0;
        }

        private void SetXAxisChoice()
        {
            cmbXAxis.Items.Clear();
            cmbXAxis.Items.Add("Diet");
            cmbXAxis.Items.Add("Color");
            cmbXAxis.Items.Add("Tank");
            cmbXAxis.Items.Add("Sex");
            cmbXAxis.Items.Add("Week");
            cmbXAxis.SelectedIndex = 0;
        }

        private void SetChart()
        {
            string sChartFilters = sSexFilters + sWeekFilter + sColorFilter;
            IEnumerable<DataRow> query;

            this.dtExperiments = this.dsExperiments.Tables[0];
            if (dtExperiments.Rows.Count == 0)
                return;

            titles.Add(txtChartTitle.Text);
            titles.Add(txtXAxisTitle.Text);
            titles.Add(txtYAxisTitle.Text);
            fonts.Add(fTitle);
            fonts.Add(fAxis);
            fonts.Add(fXLabel);

            if (sSexFilters.Equals("M"))
            {
                query = from dt in dtExperiments.AsEnumerable()
                        where dt.Field<String>("SEX") == "M"
                        select dt;
            }
            else if(sSexFilters.Equals("F"))
            {
                query = from dt in dtExperiments.AsEnumerable()
                        where dt.Field<String>("SEX") == "F"
                        select dt;
            }

           // this.dtExperiments = this.query.CopyToDataTable<DataRow>();

            foreach(DataRow row in this.dtExperiments.Rows)
            {
                yAxis.Add(Convert.ToDouble(row["WEIGHT"]));
                xAxis.Add(row["C"].ToString());
            }

            //_rStats.BarPlot(xAxis, yAxis, titles, fonts);

            Series sDiet = new Series();
            Title tChart = new Title(txtChartTitle.Text, Docking.Top);
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Titles.Clear();
            chart1.ChartAreas.Add("chartarea1");
            
            chart1.ChartAreas[0].Area3DStyle.Enable3D = false;
            chart1.Series.Add("MALE");
            chart1.Series["MALE"].Color = System.Drawing.Color.Gray;
            chart1.Series.Add("FEMALE");
            chart1.Series["FEMALE"].Color = System.Drawing.Color.ForestGreen;
            chart1.Series.Add("ErrorBar");
            chart1.Series["ErrorBar"].Color = System.Drawing.Color.Black;
            chart1.Series.Add("UNKNOWN");
            chart1.Series["UNKNOWN"].Color = System.Drawing.Color.Red;
            chart1.Legends[0].Docking = Docking.Right;

            if (fXLabel != null)
            {
                chart1.Legends[0].Font = fXLabel;
            }

            switch(cmbSex.SelectedItem.ToString())
            {
                case "M":
                    chart1.Series["MALE"].IsVisibleInLegend = true;
                    chart1.Series["FEMALE"].IsVisibleInLegend = false;
                    chart1.Series["UNKNOWN"].IsVisibleInLegend = false;
                    break;

                case "F":
                    chart1.Series["MALE"].IsVisibleInLegend = false;
                    chart1.Series["FEMALE"].IsVisibleInLegend = true;
                    chart1.Series["UNKNOWN"].IsVisibleInLegend = false;
                    break;

                case "U":
                    chart1.Series["MALE"].IsVisibleInLegend = false;
                    chart1.Series["FEMALE"].IsVisibleInLegend = false;
                    chart1.Series["UNKNOWN"].IsVisibleInLegend = true;
                    break;

                case "M and F":
                    chart1.Series["MALE"].IsVisibleInLegend = true;
                    chart1.Series["FEMALE"].IsVisibleInLegend = true;
                    chart1.Series["UNKNOWN"].IsVisibleInLegend = false;
                    break;

                default:
                    chart1.Series["MALE"].IsVisibleInLegend = true;
                    chart1.Series["FEMALE"].IsVisibleInLegend = true;
                    chart1.Series["UNKNOWN"].IsVisibleInLegend = true;
                    break;
            }
           

            chart1.Series[0].ChartType = SeriesChartType.Column;
            chart1.Series["ErrorBar"].ChartType = SeriesChartType.ErrorBar;

           /* for (int i = 0; i < dtExperiments.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(dtExperiments.Rows[i]["WEIGHT"].ToString()) ||
                    string.IsNullOrEmpty(dtExperiments.Rows[i]["FLENGTH"].ToString()))
                    break;

                if (cmbYAxis.SelectedIndex == 0)
                {
                    devAvg = Convert.ToDouble(dtExperiments.Rows[i]["WEIGHT"].ToString());
                    devMin = devAvg - Convert.ToDouble(dtExperiments.Rows[i]["ERR_MEAN_WEIGHT"].ToString());
                    devMax = devAvg + Convert.ToDouble(dtExperiments.Rows[i]["ERR_MEAN_WEIGHT"].ToString());
                }
                else
                {
                    devAvg = Convert.ToDouble(dtExperiments.Rows[i]["FLENGTH"].ToString());
                    devMin = devAvg - Convert.ToDouble(dtExperiments.Rows[i]["ERR_MEAN_LENGTH"].ToString());
                    devMax = devAvg + Convert.ToDouble(dtExperiments.Rows[i]["ERR_MEAN_LENGTH"].ToString());
                }

                chart1.Series[0].Points.AddXY(dtExperiments.Rows[i]["FAT"].ToString(), devAvg);
                chart1.Series["ErrorBar"].Points.AddXY(dtExperiments.Rows[i]["FAT"].ToString(), devAvg, devMin, devMax);
                chart1.Series["ErrorBar"].IsVisibleInLegend = false;

                if (dtExperiments.Rows[i]["SEX"].ToString().Equals("M"))
                    chart1.Series[0].Points[i].Color = System.Drawing.Color.Gray;
                else if (dtExperiments.Rows[i]["SEX"].ToString().Equals("F"))
                    chart1.Series[0].Points[i].Color = System.Drawing.Color.ForestGreen;
                else
                    chart1.Series[0].Points[i].Color = System.Drawing.Color.Red;

                chart1.Series["ErrorBar"].Points[i].Color = System.Drawing.Color.Black;
                chart1.Series[0].Points[i].AxisLabel = dtExperiments.Rows[i]["FAT"].ToString() + "%\n" + dtExperiments.Rows[i]["RATIO"].ToString();

            }*/
            
            if (fTitle != null)
                tChart.Font = fTitle;

            chart1.Series[0].XValueType = ChartValueType.String;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.IntervalOffset = 1;
            chart1.Series[0].XValueType = ChartValueType.String;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            tChart.DockedToChartArea = chart1.ChartAreas[0].Name;
            chart1.Titles.Add(tChart);
            chart1.Titles[0].IsDockedInsideChartArea = false;
            chart1.ChartAreas[0].AxisX.Title = txtXAxisTitle.Text;
            chart1.ChartAreas[0].AxisY.Title = txtYAxisTitle.Text;
            chart1.Series["ErrorBar"].IsVisibleInLegend = false;

            if (fAxis != null)
            {
                chart1.ChartAreas[0].AxisX.TitleFont = fAxis;
                chart1.ChartAreas[0].AxisY.TitleFont = fAxis;
            }

            txtIncline.Enabled = false;
            txtPerspective.Enabled = false;
            txtRotation.Enabled = false;
            txtPointWidth.Enabled = false;
        }

        private void Set3DChart()
        {
            string sChartFilters = sSexFilters + sWeekFilter + sColorFilter;
            DataSet dsRec = new DataSet();
            DataTable dtRec = new DataTable();
            Title tChart = new Title(txtChartTitle.Text, Docking.Top);
            dsRec = _daoChart.getBarChartData(EX_ID, sChartFilters);
            dtRec = dsRec.Tables[0];
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Titles.Clear();
            cmbSeriesColor.Items.Clear();
            chart1.ChartAreas.Add("chartarea1");
            chart1.ChartAreas[0].Area3DStyle.Enable3D = true;

            if (cmbYAxis.SelectedIndex == 0)
            {
                for (int i = 0; i < dtRec.Rows.Count; i++)
                {
                    //if(Diet.)
                    if (chart1.Series.IndexOf(dtRec.Rows[i]["FAT"].ToString()) != -1)
                    {
                        if (string.IsNullOrEmpty(dtRec.Rows[i]["WEIGHT"].ToString()))
                            continue;
                        chart1.Series[dtRec.Rows[i]["FAT"].ToString()].Points.AddXY(dtRec.Rows[i]["Ratio"].ToString(), Convert.ToDouble(dtRec.Rows[i]["WEIGHT"].ToString()));
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(dtRec.Rows[i]["WEIGHT"].ToString()))
                            continue;
                        chart1.Series.Add(dtRec.Rows[i]["FAT"].ToString());
                        chart1.Series[dtRec.Rows[i]["FAT"].ToString()].ChartType = SeriesChartType.Column;
                        chart1.Series[dtRec.Rows[i]["FAT"].ToString()].Points.AddXY(dtRec.Rows[i]["Ratio"].ToString(), Convert.ToDouble(dtRec.Rows[i]["WEIGHT"].ToString()));
                        cmbSeriesColor.Items.Add(dtRec.Rows[i]["FAT"].ToString());
                        
                    }
                }
            }
            else
            {
                for (int i = 0; i < dtRec.Rows.Count; i++)
                {
                    if (chart1.Series.IndexOf(dtRec.Rows[i]["FAT"].ToString()) != -1)
                    {
                        if (string.IsNullOrEmpty(dtRec.Rows[i]["FLENGTH"].ToString()))
                            continue;
                        chart1.Series[dtRec.Rows[i]["FAT"].ToString()].Points.AddXY(dtRec.Rows[i]["Ratio"].ToString(), Convert.ToDouble(dtRec.Rows[i]["FLENGTH"].ToString()));
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(dtRec.Rows[i]["FLENGTH"].ToString()))
                            continue;
                        chart1.Series.Add(dtRec.Rows[i]["FAT"].ToString());
                        chart1.Series[dtRec.Rows[i]["FAT"].ToString()].ChartType = SeriesChartType.Column;
                        chart1.Series[dtRec.Rows[i]["FAT"].ToString()].Points.AddXY(dtRec.Rows[i]["Ratio"].ToString(), Convert.ToDouble(dtRec.Rows[i]["FLENGTH"].ToString()));
                        cmbSeriesColor.Items.Add(dtRec.Rows[i]["FAT"].ToString());
                    }
                }
            }

            // Set Rotation angles
            chart1.ChartAreas[0].Area3DStyle.Rotation = Convert.ToInt32(txtRotation.Text);
            chart1.ChartAreas[0].Area3DStyle.Perspective = Convert.ToInt32(txtPerspective.Text);
            chart1.ChartAreas[0].Area3DStyle.Inclination = Convert.ToInt32(txtIncline.Text);
            chart1.Titles.Add(tChart);
            chart1.Titles[0].IsDockedInsideChartArea = false;
            chart1.ChartAreas[0].AxisX.Title = txtXAxisTitle.Text;
            chart1.ChartAreas[0].AxisY.Title = txtYAxisTitle.Text;

            if (fAxis != null)
            {
                chart1.ChartAreas[0].AxisX.TitleFont = fAxis;
                chart1.ChartAreas[0].AxisY.TitleFont = fAxis;
            }

            if (fTitle != null)
                tChart.Font = fTitle;

            if(seriesFont.Count >0)
            {
                foreach(DictionaryEntry de in seriesFont)
                {
                    string sColor = de.Value.ToString().Replace("Color [A=", "");
                    sColor = sColor.Replace("R=", "");
                    sColor = sColor.Replace("G=", "");
                    sColor = sColor.Replace("B=", "");
                    sColor = sColor.Replace("]", "");
                    sColor = sColor.Replace("[", "");
                    sColor = sColor.Replace("Color ", "");
                    string[] arrColor = sColor.Split(',');
                    int[] intColor = new int[4];
                    
                    if (arrColor.Length > 1)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            intColor[i] = Convert.ToInt32(arrColor[i]);
                        }
                        chart1.Series[de.Key.ToString()].Color = Color.FromArgb(intColor[0], intColor[1], intColor[2], intColor[3]);
                    }
                    else
                        chart1.Series[de.Key.ToString()].Color = Color.FromName(arrColor[0].ToString());
                    
                }
            }

            txtIncline.Enabled = true;
            txtPerspective.Enabled = true;
            txtRotation.Enabled = true;
            txtPointWidth.Enabled = true;
        }

        private void cmbXAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bLoad)
                return;

            btnSetChart_Click(sender, e);
        }

        private void SetChartComboBox()
        {
            cmbChartType.Items.Clear();
            cmbChartType.Items.Add("Scatter Plot");
            cmbChartType.Items.Add("2D Bar Chart");
            cmbChartType.Items.Add("3D Bar Chart");
            cmbChartType.Items.Add("Box and Whiskers");
            cmbChartType.Items.Add("Histogram");
            cmbChartType.Items.Add("Anova");
            cmbChartType.SelectedIndex = 1;
        }

        private void cmbChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bLoad)
                return;
            btnSetChart_Click(sender, e);
        }

        private void btnSetChart_Click(object sender, EventArgs e)
        {
            switch (cmbChartType.SelectedItem.ToString())
            {
                case "2D Bar Chart":
                    SetChart();
                    break;

                case "3D Bar Chart":
                    Set3DChart();
                    break;

                case "Anova":
                    SetAnova();
                    break;
            }
        }

        private void SetSex()
        {
            cmbSex.Items.Clear();

            cmbSex.Items.Add("ALL");
            cmbSex.Items.Add("M");
            cmbSex.Items.Add("F");
            cmbSex.Items.Add("U");
            cmbSex.Items.Add("M and F");

            cmbSex.SelectedIndex = 0;
        }

        private void cmbSex_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bLoad)
                return;

            if (cmbSex.SelectedItem.ToString().Equals("ALL"))
            {
                sSexFilters = "";
            }
            else if (cmbSex.SelectedItem.ToString().Equals("M and F"))
            {
                sSexFilters = " SEX IS NOT NULL";
            }
            else if (cmbSex.SelectedItem.ToString().Equals("U"))
            {
                sSexFilters = " and SEX IS NULL";
            }
            else
            {
                sSexFilters = " SEX = '" + cmbSex.SelectedItem.ToString() + "'";
            }

            btnSetChart_Click(sender, e);
        }

        private void cmbYAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bLoad)
                return;

            if (cmbXAxis.Items.Count > 0)
                btnSetChart_Click(sender, e);
        }

        private void txtPointWidth_TextChanged(object sender, EventArgs e)
        {
            if (bLoad)
                return;

            btnSetChart_Click(sender, e);
        }

        private void btnTitleFont_Click(object sender, EventArgs e)
        {
            if (bLoad)
                return;
            fontDialog1.ShowColor = true;

            DialogResult result = fontDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Get Font.
                fTitle = fontDialog1.Font;
            }
            btnSetChart_Click(sender, e);
        }

        private void btnAxisFont_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;

            DialogResult result = fontDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Get Font.
                fAxis = fontDialog1.Font;
            }
            btnSetChart_Click(sender, e);
        }

        private void btnAxisLabel_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;

            DialogResult result = fontDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Get Font.
                fXLabel = fontDialog1.Font;
            }
            btnSetChart_Click(sender, e);
        }

        private void btnSeriesColor_Click(object sender, EventArgs e)
        {
            DialogResult result =colorDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (seriesFont.Contains(cmbSeriesColor.Text.ToString()))
                    seriesFont.Remove(cmbSeriesColor.Text.ToString());
                seriesFont.Add(cmbSeriesColor.Text.ToString(), colorDialog1.Color.ToString());
            }
            btnSetChart_Click(sender, e);
        }

        private void btnClearSerColor_Click(object sender, EventArgs e)
        {
            seriesFont.Clear();
            btnSetChart_Click(sender, e);
        }

        private void LoadWeek(int id)
        {
            DataSet dsWeek = new DataSet();
            DataTable dtWeek = new DataTable();

            dsWeek = _daoChart.getWeek(id);
            dtWeek = dsWeek.Tables[0];

            cmbWeek.Items.Add("ALL");

            foreach (DataRow row in dtWeek.Rows)
            {
                cmbWeek.Items.Add(row["WEEK"].ToString());
            }

            cmbWeek.DisplayMember = "WEEK";
            cmbWeek.ValueMember = "WEEK";
            cmbWeek.SelectedItem = 0;
        }

        private void LoadColor(int id)
        {
            DataSet dsColor = new DataSet();
            DataTable dtColor = new DataTable();

            dsColor = _daoChart.getColor(id);
            dtColor = dsColor.Tables[0];

            cmbColor.Items.Add("ALL");

            foreach (DataRow row in dtColor.Rows)
            {
                foreach (DataColumn col in dtColor.Columns)
                {
                    cmbColor.Items.Add(row[col.ColumnName].ToString());
                }
            }
            cmbColor.SelectedItem = 0;
        }

        private void cmbWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bLoad)
                return;

            if (cmbWeek.SelectedItem.ToString().Equals("ALL"))
                sWeekFilter = "";
            else
                sWeekFilter = " and FISH_WEIGHT_LENGTH.WEEK = '" + cmbWeek.SelectedItem.ToString() + "'";
            btnSetChart_Click(sender, e);
        }

        private void cmbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bLoad)
                return;

            if (cmbColor.SelectedItem.ToString().Equals("ALL"))
                sColorFilter = "";
            else
                sColorFilter = " and FISH_WEIGHT_LENGTH.COLOR = '" + cmbColor.SelectedItem.ToString() + "'";

            btnSetChart_Click(sender, e);
        }

        private void btnSaveChart_Click(object sender, EventArgs e)
        {
            saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "PNG Image|*.png";
            saveFileDialog1.Title = "Save Chart As Image File";

            DialogResult result = saveFileDialog1.ShowDialog();
            saveFileDialog1.RestoreDirectory = true;

            if (result == DialogResult.OK && saveFileDialog1.FileName != "")
            {
                chart1.SaveImage(saveFileDialog1.FileName, ChartImageFormat.Jpeg);
            }
        }

        private void SetAnova()
        {
            string sChartFilters = sSexFilters + sWeekFilter + sColorFilter;
            DataSet dsRec = new DataSet();
            DataTable dtRec = new DataTable();
            Title tChart = new Title(txtChartTitle.Text, Docking.Top);
            dsRec = _daoChart.getBarChartData(EX_ID, sChartFilters);
            dtRec = dsRec.Tables[0];
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Titles.Clear();
            cmbSeriesColor.Items.Clear();
            chart1.ChartAreas.Add("chartarea1");
            chart1.ChartAreas[0].Area3DStyle.Enable3D = false;

            if (cmbYAxis.SelectedIndex == 0)
            {
                for (int i = 0; i < dtRec.Rows.Count; i++)
                {

                    if (chart1.Series.IndexOf(dtRec.Rows[i]["FAT"].ToString()) != -1)
                    {
                        if (string.IsNullOrEmpty(dtRec.Rows[i]["WEIGHT"].ToString()))
                            continue;
                       chart1.Series[dtRec.Rows[i]["FAT"].ToString()].Points.AddXY(dtRec.Rows[i]["RATIO"].ToString(), Convert.ToDouble(dtRec.Rows[i]["WEIGHT"].ToString()));
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(dtRec.Rows[i]["WEIGHT"].ToString()))
                            continue;
                        chart1.Series.Add(dtRec.Rows[i]["FAT"].ToString());
                        //chart1.Series[dtRec.Rows[i]["FAT"].ToString()].ChartType = SeriesChartType.Column;
                        chart1.Series[dtRec.Rows[i]["FAT"].ToString()].Points.AddXY(dtRec.Rows[i]["RATIO"].ToString(), Convert.ToDouble(dtRec.Rows[i]["WEIGHT"].ToString()));
                        cmbSeriesColor.Items.Add(dtRec.Rows[i]["FAT"].ToString());

                    }
                }
            }
            else
            {
                for (int i = 0; i < dtRec.Rows.Count; i++)
                {
                    if (chart1.Series.IndexOf(dtRec.Rows[i]["DIET"].ToString()) != -1)
                    {
                        if (string.IsNullOrEmpty(dtRec.Rows[i]["FLENGTH"].ToString()))
                            continue;
                        chart1.Series[dtRec.Rows[i]["DIET"].ToString()].Points.AddXY(dtRec.Rows[i]["DIET"].ToString(), Convert.ToDouble(dtRec.Rows[i]["FLENGTH"].ToString()));
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(dtRec.Rows[i]["FLENGTH"].ToString()))
                            continue;
                        chart1.Series.Add(dtRec.Rows[i]["DIET"].ToString());
                        chart1.Series[dtRec.Rows[i]["DIET"].ToString()].ChartType = SeriesChartType.Column;
                        chart1.Series[dtRec.Rows[i]["DIET"].ToString()].Points.AddXY(dtRec.Rows[i]["DIET"].ToString(), Convert.ToDouble(dtRec.Rows[i]["FLENGTH"].ToString()));
                        cmbSeriesColor.Items.Add(dtRec.Rows[i]["DIET"].ToString());
                    }
                }
            }

            chart1.Titles.Add(tChart);
            chart1.Titles[0].IsDockedInsideChartArea = false;
            chart1.ChartAreas[0].AxisX.Title = txtXAxisTitle.Text;
            chart1.ChartAreas[0].AxisY.Title = txtYAxisTitle.Text;

            if (fAxis != null)
            {
                chart1.ChartAreas[0].AxisX.TitleFont = fAxis;
                chart1.ChartAreas[0].AxisY.TitleFont = fAxis;
            }

            if (fTitle != null)
                tChart.Font = fTitle;

            if (seriesFont.Count > 0)
            {
                foreach (DictionaryEntry de in seriesFont)
                {
                    string sColor = de.Value.ToString().Replace("Color [A=", "");
                    sColor = sColor.Replace("R=", "");
                    sColor = sColor.Replace("G=", "");
                    sColor = sColor.Replace("B=", "");
                    sColor = sColor.Replace("]", "");
                    sColor = sColor.Replace("[", "");
                    sColor = sColor.Replace("Color ", "");
                    string[] arrColor = sColor.Split(',');
                    int[] intColor = new int[4];

                    if (arrColor.Length > 1)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            intColor[i] = Convert.ToInt32(arrColor[i]);
                        }
                        chart1.Series[de.Key.ToString()].Color = Color.FromArgb(intColor[0], intColor[1], intColor[2], intColor[3]);
                    }
                    else
                        chart1.Series[de.Key.ToString()].Color = Color.FromName(arrColor[0].ToString());

                }
            }

            txtIncline.Enabled = false;
            txtPerspective.Enabled = false;
            txtRotation.Enabled = false;
            txtPointWidth.Enabled = false;

            string test = "";
            for (int i = 0; i < chart1.Series.Count; i++)
                test += chart1.Series[i].Name.ToString() + ",";

            test = test.TrimEnd(',');

            AnovaResult result = chart1.DataManipulator.Statistics.Anova(.05, test);
            MessageBox.Show(result.DegreeOfFreedomBetweenGroups.ToString());
        }

        private void lblSeriesColor_Click(object sender, EventArgs e)
        {

        }

        private void cmbSeriesColor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtYAxisTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtXAxisTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblXAxix_Click(object sender, EventArgs e)
        {

        }

        private void txtChartTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblChartTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblChartType_Click(object sender, EventArgs e)
        {

        }

        private void gbFilter_Enter(object sender, EventArgs e)
        {

        }

        private void lblXAxis_Click(object sender, EventArgs e)
        {

        }

        private void lblYAxis_Click(object sender, EventArgs e)
        {

        }

    }
}
