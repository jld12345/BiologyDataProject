namespace BiologyDepartment
{
    partial class BarChart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmbYAxis = new System.Windows.Forms.ComboBox();
            this.cmbXAxis = new System.Windows.Forms.ComboBox();
            this.lblYAxis = new System.Windows.Forms.Label();
            this.lblXAxis = new System.Windows.Forms.Label();
            this.cmbChartType = new System.Windows.Forms.ComboBox();
            this.lblChartType = new System.Windows.Forms.Label();
            this.btnSetChart = new System.Windows.Forms.Button();
            this.cmbSex = new System.Windows.Forms.ComboBox();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.cmbColor = new System.Windows.Forms.ComboBox();
            this.lbl3D = new System.Windows.Forms.Label();
            this.lblWeek = new System.Windows.Forms.Label();
            this.cmbWeek = new System.Windows.Forms.ComboBox();
            this.lblPointWidth = new System.Windows.Forms.Label();
            this.txtPointWidth = new System.Windows.Forms.TextBox();
            this.lblRotation = new System.Windows.Forms.Label();
            this.lblPerspective = new System.Windows.Forms.Label();
            this.lblIncline = new System.Windows.Forms.Label();
            this.txtRotation = new System.Windows.Forms.TextBox();
            this.txtPerspective = new System.Windows.Forms.TextBox();
            this.txtIncline = new System.Windows.Forms.TextBox();
            this.lblSex = new System.Windows.Forms.Label();
            this.lblChartTitle = new System.Windows.Forms.Label();
            this.txtChartTitle = new System.Windows.Forms.TextBox();
            this.txtXAxisTitle = new System.Windows.Forms.TextBox();
            this.lblXAxix = new System.Windows.Forms.Label();
            this.txtYAxisTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.btnTitleFont = new System.Windows.Forms.Button();
            this.btnAxisFont = new System.Windows.Forms.Button();
            this.btnAxisLabel = new System.Windows.Forms.Button();
            this.cmbSeriesColor = new System.Windows.Forms.ComboBox();
            this.lblSeriesColor = new System.Windows.Forms.Label();
            this.btnSeriesColor = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnClearSerColor = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnSaveChart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.gbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.Area3DStyle.Inclination = 50;
            chartArea1.Area3DStyle.IsRightAngleAxes = false;
            chartArea1.Area3DStyle.Perspective = 10;
            chartArea1.Area3DStyle.Rotation = 40;
            chartArea1.Area3DStyle.WallWidth = 10;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(281, 12);
            this.chart1.Name = "chart1";
            this.chart1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Grayscale;
            this.chart1.Size = new System.Drawing.Size(689, 671);
            this.chart1.TabIndex = 0;
            // 
            // cmbYAxis
            // 
            this.cmbYAxis.FormattingEnabled = true;
            this.cmbYAxis.Location = new System.Drawing.Point(12, 78);
            this.cmbYAxis.Name = "cmbYAxis";
            this.cmbYAxis.Size = new System.Drawing.Size(167, 21);
            this.cmbYAxis.TabIndex = 1;
            this.cmbYAxis.SelectedIndexChanged += new System.EventHandler(this.cmbYAxis_SelectedIndexChanged);
            // 
            // cmbXAxis
            // 
            this.cmbXAxis.FormattingEnabled = true;
            this.cmbXAxis.Location = new System.Drawing.Point(12, 118);
            this.cmbXAxis.Name = "cmbXAxis";
            this.cmbXAxis.Size = new System.Drawing.Size(167, 21);
            this.cmbXAxis.TabIndex = 2;
            this.cmbXAxis.SelectedIndexChanged += new System.EventHandler(this.cmbXAxis_SelectedIndexChanged);
            // 
            // lblYAxis
            // 
            this.lblYAxis.AutoSize = true;
            this.lblYAxis.Location = new System.Drawing.Point(12, 62);
            this.lblYAxis.Name = "lblYAxis";
            this.lblYAxis.Size = new System.Drawing.Size(36, 13);
            this.lblYAxis.TabIndex = 7;
            this.lblYAxis.Text = "Y Axis";
            this.lblYAxis.Click += new System.EventHandler(this.lblYAxis_Click);
            // 
            // lblXAxis
            // 
            this.lblXAxis.AutoSize = true;
            this.lblXAxis.Location = new System.Drawing.Point(12, 102);
            this.lblXAxis.Name = "lblXAxis";
            this.lblXAxis.Size = new System.Drawing.Size(36, 13);
            this.lblXAxis.TabIndex = 8;
            this.lblXAxis.Text = "X Axis";
            this.lblXAxis.Click += new System.EventHandler(this.lblXAxis_Click);
            // 
            // cmbChartType
            // 
            this.cmbChartType.FormattingEnabled = true;
            this.cmbChartType.Location = new System.Drawing.Point(12, 38);
            this.cmbChartType.Name = "cmbChartType";
            this.cmbChartType.Size = new System.Drawing.Size(169, 21);
            this.cmbChartType.TabIndex = 11;
            this.cmbChartType.SelectedIndexChanged += new System.EventHandler(this.cmbChartType_SelectedIndexChanged);
            // 
            // lblChartType
            // 
            this.lblChartType.AutoSize = true;
            this.lblChartType.Location = new System.Drawing.Point(13, 19);
            this.lblChartType.Name = "lblChartType";
            this.lblChartType.Size = new System.Drawing.Size(59, 13);
            this.lblChartType.TabIndex = 12;
            this.lblChartType.Text = "Chart Type";
            this.lblChartType.Click += new System.EventHandler(this.lblChartType_Click);
            // 
            // btnSetChart
            // 
            this.btnSetChart.Location = new System.Drawing.Point(187, 38);
            this.btnSetChart.Name = "btnSetChart";
            this.btnSetChart.Size = new System.Drawing.Size(88, 45);
            this.btnSetChart.TabIndex = 13;
            this.btnSetChart.Text = "Set Chart";
            this.btnSetChart.UseVisualStyleBackColor = true;
            this.btnSetChart.Click += new System.EventHandler(this.btnSetChart_Click);
            // 
            // cmbSex
            // 
            this.cmbSex.FormattingEnabled = true;
            this.cmbSex.Location = new System.Drawing.Point(6, 32);
            this.cmbSex.Name = "cmbSex";
            this.cmbSex.Size = new System.Drawing.Size(75, 21);
            this.cmbSex.TabIndex = 14;
            this.cmbSex.SelectedIndexChanged += new System.EventHandler(this.cmbSex_SelectedIndexChanged);
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.lblColor);
            this.gbFilter.Controls.Add(this.cmbColor);
            this.gbFilter.Controls.Add(this.lbl3D);
            this.gbFilter.Controls.Add(this.lblWeek);
            this.gbFilter.Controls.Add(this.cmbWeek);
            this.gbFilter.Controls.Add(this.lblPointWidth);
            this.gbFilter.Controls.Add(this.txtPointWidth);
            this.gbFilter.Controls.Add(this.lblRotation);
            this.gbFilter.Controls.Add(this.lblPerspective);
            this.gbFilter.Controls.Add(this.lblIncline);
            this.gbFilter.Controls.Add(this.txtRotation);
            this.gbFilter.Controls.Add(this.txtPerspective);
            this.gbFilter.Controls.Add(this.txtIncline);
            this.gbFilter.Controls.Add(this.lblSex);
            this.gbFilter.Controls.Add(this.cmbSex);
            this.gbFilter.Location = new System.Drawing.Point(12, 145);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(263, 151);
            this.gbFilter.TabIndex = 15;
            this.gbFilter.TabStop = false;
            this.gbFilter.Enter += new System.EventHandler(this.gbFilter_Enter);
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(7, 97);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(31, 13);
            this.lblColor.TabIndex = 28;
            this.lblColor.Text = "Color";
            // 
            // cmbColor
            // 
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Location = new System.Drawing.Point(6, 112);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(85, 21);
            this.cmbColor.TabIndex = 27;
            this.cmbColor.SelectedIndexChanged += new System.EventHandler(this.cmbColor_SelectedIndexChanged);
            // 
            // lbl3D
            // 
            this.lbl3D.AutoSize = true;
            this.lbl3D.Location = new System.Drawing.Point(157, 16);
            this.lbl3D.Name = "lbl3D";
            this.lbl3D.Size = new System.Drawing.Size(90, 13);
            this.lbl3D.TabIndex = 26;
            this.lbl3D.Text = "3D Chart Controls";
            // 
            // lblWeek
            // 
            this.lblWeek.AutoSize = true;
            this.lblWeek.Location = new System.Drawing.Point(7, 56);
            this.lblWeek.Name = "lblWeek";
            this.lblWeek.Size = new System.Drawing.Size(36, 13);
            this.lblWeek.TabIndex = 25;
            this.lblWeek.Text = "Week";
            // 
            // cmbWeek
            // 
            this.cmbWeek.FormattingEnabled = true;
            this.cmbWeek.Location = new System.Drawing.Point(6, 72);
            this.cmbWeek.Name = "cmbWeek";
            this.cmbWeek.Size = new System.Drawing.Size(75, 21);
            this.cmbWeek.TabIndex = 24;
            this.cmbWeek.SelectedIndexChanged += new System.EventHandler(this.cmbWeek_SelectedIndexChanged);
            // 
            // lblPointWidth
            // 
            this.lblPointWidth.AutoSize = true;
            this.lblPointWidth.Location = new System.Drawing.Point(134, 120);
            this.lblPointWidth.Name = "lblPointWidth";
            this.lblPointWidth.Size = new System.Drawing.Size(62, 13);
            this.lblPointWidth.TabIndex = 23;
            this.lblPointWidth.Text = "Point Width";
            // 
            // txtPointWidth
            // 
            this.txtPointWidth.Location = new System.Drawing.Point(199, 117);
            this.txtPointWidth.Name = "txtPointWidth";
            this.txtPointWidth.Size = new System.Drawing.Size(47, 20);
            this.txtPointWidth.TabIndex = 22;
            this.txtPointWidth.Text = "5";
            this.txtPointWidth.TextChanged += new System.EventHandler(this.txtPointWidth_TextChanged);
            // 
            // lblRotation
            // 
            this.lblRotation.AutoSize = true;
            this.lblRotation.Location = new System.Drawing.Point(149, 93);
            this.lblRotation.Name = "lblRotation";
            this.lblRotation.Size = new System.Drawing.Size(47, 13);
            this.lblRotation.TabIndex = 21;
            this.lblRotation.Text = "Rotation";
            // 
            // lblPerspective
            // 
            this.lblPerspective.AutoSize = true;
            this.lblPerspective.Location = new System.Drawing.Point(133, 63);
            this.lblPerspective.Name = "lblPerspective";
            this.lblPerspective.Size = new System.Drawing.Size(63, 13);
            this.lblPerspective.TabIndex = 20;
            this.lblPerspective.Text = "Perspective";
            // 
            // lblIncline
            // 
            this.lblIncline.AutoSize = true;
            this.lblIncline.Location = new System.Drawing.Point(158, 42);
            this.lblIncline.Name = "lblIncline";
            this.lblIncline.Size = new System.Drawing.Size(38, 13);
            this.lblIncline.TabIndex = 19;
            this.lblIncline.Text = "Incline";
            // 
            // txtRotation
            // 
            this.txtRotation.Location = new System.Drawing.Point(199, 90);
            this.txtRotation.Name = "txtRotation";
            this.txtRotation.Size = new System.Drawing.Size(48, 20);
            this.txtRotation.TabIndex = 18;
            this.txtRotation.Text = "45";
            // 
            // txtPerspective
            // 
            this.txtPerspective.Location = new System.Drawing.Point(199, 63);
            this.txtPerspective.Name = "txtPerspective";
            this.txtPerspective.Size = new System.Drawing.Size(48, 20);
            this.txtPerspective.TabIndex = 17;
            this.txtPerspective.Text = "5";
            // 
            // txtIncline
            // 
            this.txtIncline.Location = new System.Drawing.Point(199, 36);
            this.txtIncline.Name = "txtIncline";
            this.txtIncline.Size = new System.Drawing.Size(49, 20);
            this.txtIncline.TabIndex = 16;
            this.txtIncline.Text = "10";
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(7, 16);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(25, 13);
            this.lblSex.TabIndex = 15;
            this.lblSex.Text = "Sex";
            // 
            // lblChartTitle
            // 
            this.lblChartTitle.AutoSize = true;
            this.lblChartTitle.Location = new System.Drawing.Point(12, 299);
            this.lblChartTitle.Name = "lblChartTitle";
            this.lblChartTitle.Size = new System.Drawing.Size(55, 13);
            this.lblChartTitle.TabIndex = 16;
            this.lblChartTitle.Text = "Chart Title";
            this.lblChartTitle.Click += new System.EventHandler(this.lblChartTitle_Click);
            // 
            // txtChartTitle
            // 
            this.txtChartTitle.Location = new System.Drawing.Point(12, 316);
            this.txtChartTitle.Name = "txtChartTitle";
            this.txtChartTitle.Size = new System.Drawing.Size(254, 20);
            this.txtChartTitle.TabIndex = 17;
            this.txtChartTitle.Text = "ENTER CHART TITLE";
            this.txtChartTitle.TextChanged += new System.EventHandler(this.txtChartTitle_TextChanged);
            // 
            // txtXAxisTitle
            // 
            this.txtXAxisTitle.Location = new System.Drawing.Point(12, 356);
            this.txtXAxisTitle.Name = "txtXAxisTitle";
            this.txtXAxisTitle.Size = new System.Drawing.Size(254, 20);
            this.txtXAxisTitle.TabIndex = 19;
            this.txtXAxisTitle.Text = "ENTER AXIS TITLE";
            this.txtXAxisTitle.TextChanged += new System.EventHandler(this.txtXAxisTitle_TextChanged);
            // 
            // lblXAxix
            // 
            this.lblXAxix.AutoSize = true;
            this.lblXAxix.Location = new System.Drawing.Point(12, 339);
            this.lblXAxix.Name = "lblXAxix";
            this.lblXAxix.Size = new System.Drawing.Size(59, 13);
            this.lblXAxix.TabIndex = 18;
            this.lblXAxix.Text = "X Axis Title";
            this.lblXAxix.Click += new System.EventHandler(this.lblXAxix_Click);
            // 
            // txtYAxisTitle
            // 
            this.txtYAxisTitle.Location = new System.Drawing.Point(12, 396);
            this.txtYAxisTitle.Name = "txtYAxisTitle";
            this.txtYAxisTitle.Size = new System.Drawing.Size(254, 20);
            this.txtYAxisTitle.TabIndex = 21;
            this.txtYAxisTitle.Text = "ENTER AXIS TITLE";
            this.txtYAxisTitle.TextChanged += new System.EventHandler(this.txtYAxisTitle_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 379);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Y Axis Title";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnTitleFont
            // 
            this.btnTitleFont.Location = new System.Drawing.Point(12, 423);
            this.btnTitleFont.Name = "btnTitleFont";
            this.btnTitleFont.Size = new System.Drawing.Size(75, 23);
            this.btnTitleFont.TabIndex = 22;
            this.btnTitleFont.Text = "Title Font";
            this.btnTitleFont.UseVisualStyleBackColor = true;
            this.btnTitleFont.Click += new System.EventHandler(this.btnTitleFont_Click);
            // 
            // btnAxisFont
            // 
            this.btnAxisFont.Location = new System.Drawing.Point(101, 423);
            this.btnAxisFont.Name = "btnAxisFont";
            this.btnAxisFont.Size = new System.Drawing.Size(75, 23);
            this.btnAxisFont.TabIndex = 23;
            this.btnAxisFont.Text = "Axis Label";
            this.btnAxisFont.UseVisualStyleBackColor = true;
            this.btnAxisFont.Click += new System.EventHandler(this.btnAxisFont_Click);
            // 
            // btnAxisLabel
            // 
            this.btnAxisLabel.Location = new System.Drawing.Point(190, 423);
            this.btnAxisLabel.Name = "btnAxisLabel";
            this.btnAxisLabel.Size = new System.Drawing.Size(75, 23);
            this.btnAxisLabel.TabIndex = 24;
            this.btnAxisLabel.Text = "Legend Font";
            this.btnAxisLabel.UseVisualStyleBackColor = true;
            this.btnAxisLabel.Click += new System.EventHandler(this.btnAxisLabel_Click);
            // 
            // cmbSeriesColor
            // 
            this.cmbSeriesColor.FormattingEnabled = true;
            this.cmbSeriesColor.Location = new System.Drawing.Point(12, 469);
            this.cmbSeriesColor.Name = "cmbSeriesColor";
            this.cmbSeriesColor.Size = new System.Drawing.Size(121, 21);
            this.cmbSeriesColor.TabIndex = 25;
            this.cmbSeriesColor.SelectedIndexChanged += new System.EventHandler(this.cmbSeriesColor_SelectedIndexChanged);
            // 
            // lblSeriesColor
            // 
            this.lblSeriesColor.AutoSize = true;
            this.lblSeriesColor.Location = new System.Drawing.Point(12, 453);
            this.lblSeriesColor.Name = "lblSeriesColor";
            this.lblSeriesColor.Size = new System.Drawing.Size(63, 13);
            this.lblSeriesColor.TabIndex = 26;
            this.lblSeriesColor.Text = "Series Color";
            this.lblSeriesColor.Click += new System.EventHandler(this.lblSeriesColor_Click);
            // 
            // btnSeriesColor
            // 
            this.btnSeriesColor.Location = new System.Drawing.Point(139, 469);
            this.btnSeriesColor.Name = "btnSeriesColor";
            this.btnSeriesColor.Size = new System.Drawing.Size(61, 23);
            this.btnSeriesColor.TabIndex = 27;
            this.btnSeriesColor.Text = "Set Color";
            this.btnSeriesColor.UseVisualStyleBackColor = true;
            this.btnSeriesColor.Click += new System.EventHandler(this.btnSeriesColor_Click);
            // 
            // btnClearSerColor
            // 
            this.btnClearSerColor.Location = new System.Drawing.Point(206, 469);
            this.btnClearSerColor.Name = "btnClearSerColor";
            this.btnClearSerColor.Size = new System.Drawing.Size(60, 23);
            this.btnClearSerColor.TabIndex = 28;
            this.btnClearSerColor.Text = "Clear";
            this.btnClearSerColor.UseVisualStyleBackColor = true;
            this.btnClearSerColor.Click += new System.EventHandler(this.btnClearSerColor_Click);
            // 
            // btnSaveChart
            // 
            this.btnSaveChart.Location = new System.Drawing.Point(187, 89);
            this.btnSaveChart.Name = "btnSaveChart";
            this.btnSaveChart.Size = new System.Drawing.Size(88, 50);
            this.btnSaveChart.TabIndex = 29;
            this.btnSaveChart.Text = "Save Chart";
            this.btnSaveChart.UseVisualStyleBackColor = true;
            this.btnSaveChart.Click += new System.EventHandler(this.btnSaveChart_Click);
            // 
            // BarChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 695);
            this.Controls.Add(this.btnSaveChart);
            this.Controls.Add(this.btnClearSerColor);
            this.Controls.Add(this.btnSeriesColor);
            this.Controls.Add(this.lblSeriesColor);
            this.Controls.Add(this.cmbSeriesColor);
            this.Controls.Add(this.btnAxisLabel);
            this.Controls.Add(this.btnAxisFont);
            this.Controls.Add(this.btnTitleFont);
            this.Controls.Add(this.txtYAxisTitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtXAxisTitle);
            this.Controls.Add(this.lblXAxix);
            this.Controls.Add(this.txtChartTitle);
            this.Controls.Add(this.lblChartTitle);
            this.Controls.Add(this.btnSetChart);
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.lblChartType);
            this.Controls.Add(this.cmbChartType);
            this.Controls.Add(this.lblXAxis);
            this.Controls.Add(this.lblYAxis);
            this.Controls.Add(this.cmbXAxis);
            this.Controls.Add(this.cmbYAxis);
            this.Controls.Add(this.chart1);
            this.Name = "BarChart";
            this.Text = "BarChart";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BarChart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox cmbYAxis;
        private System.Windows.Forms.ComboBox cmbXAxis;
        private System.Windows.Forms.Label lblYAxis;
        private System.Windows.Forms.Label lblXAxis;
        private System.Windows.Forms.ComboBox cmbChartType;
        private System.Windows.Forms.Label lblChartType;
        private System.Windows.Forms.Button btnSetChart;
        private System.Windows.Forms.ComboBox cmbSex;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label lblRotation;
        private System.Windows.Forms.Label lblPerspective;
        private System.Windows.Forms.Label lblIncline;
        private System.Windows.Forms.TextBox txtRotation;
        private System.Windows.Forms.TextBox txtPerspective;
        private System.Windows.Forms.TextBox txtIncline;
        private System.Windows.Forms.Label lblPointWidth;
        private System.Windows.Forms.TextBox txtPointWidth;
        private System.Windows.Forms.Label lblChartTitle;
        private System.Windows.Forms.TextBox txtChartTitle;
        private System.Windows.Forms.TextBox txtXAxisTitle;
        private System.Windows.Forms.Label lblXAxix;
        private System.Windows.Forms.TextBox txtYAxisTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button btnTitleFont;
        private System.Windows.Forms.Button btnAxisFont;
        private System.Windows.Forms.Button btnAxisLabel;
        private System.Windows.Forms.ComboBox cmbSeriesColor;
        private System.Windows.Forms.Label lblSeriesColor;
        private System.Windows.Forms.Button btnSeriesColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnClearSerColor;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.ComboBox cmbColor;
        private System.Windows.Forms.Label lbl3D;
        private System.Windows.Forms.Label lblWeek;
        private System.Windows.Forms.ComboBox cmbWeek;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnSaveChart;
    }
}