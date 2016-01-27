namespace BiologyDepartment
{
    partial class frmData
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
            this.Filters = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.lblEnd = new System.Windows.Forms.Label();
            this.cbEnd = new System.Windows.Forms.ComboBox();
            this.lblWeek = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.cbWeek = new System.Windows.Forms.ComboBox();
            this.cbSex = new System.Windows.Forms.ComboBox();
            this.cbColor = new System.Windows.Forms.ComboBox();
            this.cbStart = new System.Windows.Forms.ComboBox();
            this.dgExData = new System.Windows.Forms.DataGridView();
            this.gbChartControls = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtYRotation = new System.Windows.Forms.TextBox();
            this.txtXRotation = new System.Windows.Forms.TextBox();
            this.btnTickFont = new System.Windows.Forms.Button();
            this.btnTitleFont = new System.Windows.Forms.Button();
            this.btnAxisFont = new System.Windows.Forms.Button();
            this.btnLegendFont = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblChartType = new System.Windows.Forms.Label();
            this.cmbYAxis = new System.Windows.Forms.ComboBox();
            this.cmbXAxis = new System.Windows.Forms.ComboBox();
            this.lblYAxis = new System.Windows.Forms.Label();
            this.lblXAxis = new System.Windows.Forms.Label();
            this.cmbChartType = new System.Windows.Forms.ComboBox();
            this.btnSaveChart = new System.Windows.Forms.Button();
            this.btnClearSerColor = new System.Windows.Forms.Button();
            this.btnSetChart = new System.Windows.Forms.Button();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.lblPointWidth = new System.Windows.Forms.Label();
            this.txtPointWidth = new System.Windows.Forms.TextBox();
            this.lblRotation = new System.Windows.Forms.Label();
            this.lblPerspective = new System.Windows.Forms.Label();
            this.lblIncline = new System.Windows.Forms.Label();
            this.txtRotation = new System.Windows.Forms.TextBox();
            this.txtPerspective = new System.Windows.Forms.TextBox();
            this.txtIncline = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblChartTitle = new System.Windows.Forms.Label();
            this.txtChartTitle = new System.Windows.Forms.TextBox();
            this.lblXAxix = new System.Windows.Forms.Label();
            this.txtXAxisTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtYAxisTitle = new System.Windows.Forms.TextBox();
            this.pbChart = new System.Windows.Forms.PictureBox();
            this.tabChart = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rtbSummary = new System.Windows.Forms.RichTextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgAnova = new System.Windows.Forms.DataGridView();
            this.Filters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgExData)).BeginInit();
            this.gbChartControls.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbFilter.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbChart)).BeginInit();
            this.tabChart.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAnova)).BeginInit();
            this.SuspendLayout();
            // 
            // Filters
            // 
            this.Filters.Controls.Add(this.btnEdit);
            this.Filters.Controls.Add(this.btnExport);
            this.Filters.Controls.Add(this.btnClear);
            this.Filters.Controls.Add(this.btnAdd);
            this.Filters.Controls.Add(this.btnFilter);
            this.Filters.Controls.Add(this.lblEnd);
            this.Filters.Controls.Add(this.cbEnd);
            this.Filters.Controls.Add(this.lblWeek);
            this.Filters.Controls.Add(this.lblSex);
            this.Filters.Controls.Add(this.lblColor);
            this.Filters.Controls.Add(this.lblStart);
            this.Filters.Controls.Add(this.cbWeek);
            this.Filters.Controls.Add(this.cbSex);
            this.Filters.Controls.Add(this.cbColor);
            this.Filters.Controls.Add(this.cbStart);
            this.Filters.Location = new System.Drawing.Point(0, 13);
            this.Filters.Name = "Filters";
            this.Filters.Size = new System.Drawing.Size(558, 96);
            this.Filters.TabIndex = 0;
            this.Filters.TabStop = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(400, 63);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(69, 27);
            this.btnEdit.TabIndex = 13;
            this.btnEdit.Text = "EDIT";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(400, 11);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(69, 26);
            this.btnExport.TabIndex = 14;
            this.btnExport.Text = "EXPORT";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(400, 37);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(69, 26);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(475, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(69, 26);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(475, 37);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(69, 26);
            this.btnFilter.TabIndex = 10;
            this.btnFilter.Text = "FILTER";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(86, 16);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(54, 13);
            this.lblEnd.TabIndex = 9;
            this.lblEnd.Text = "End Tank";
            // 
            // cbEnd
            // 
            this.cbEnd.FormattingEnabled = true;
            this.cbEnd.Location = new System.Drawing.Point(89, 36);
            this.cbEnd.Name = "cbEnd";
            this.cbEnd.Size = new System.Drawing.Size(62, 21);
            this.cbEnd.TabIndex = 8;
            // 
            // lblWeek
            // 
            this.lblWeek.AutoSize = true;
            this.lblWeek.Location = new System.Drawing.Point(328, 16);
            this.lblWeek.Name = "lblWeek";
            this.lblWeek.Size = new System.Drawing.Size(36, 13);
            this.lblWeek.TabIndex = 7;
            this.lblWeek.Text = "Week";
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(255, 16);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(25, 13);
            this.lblSex.TabIndex = 6;
            this.lblSex.Text = "Sex";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(162, 16);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(31, 13);
            this.lblColor.TabIndex = 5;
            this.lblColor.Text = "Color";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(10, 16);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(57, 13);
            this.lblStart.TabIndex = 4;
            this.lblStart.Text = "Start Tank";
            // 
            // cbWeek
            // 
            this.cbWeek.FormattingEnabled = true;
            this.cbWeek.Location = new System.Drawing.Point(331, 36);
            this.cbWeek.Name = "cbWeek";
            this.cbWeek.Size = new System.Drawing.Size(63, 21);
            this.cbWeek.TabIndex = 3;
            // 
            // cbSex
            // 
            this.cbSex.FormattingEnabled = true;
            this.cbSex.Location = new System.Drawing.Point(258, 36);
            this.cbSex.Name = "cbSex";
            this.cbSex.Size = new System.Drawing.Size(59, 21);
            this.cbSex.TabIndex = 2;
            // 
            // cbColor
            // 
            this.cbColor.FormattingEnabled = true;
            this.cbColor.Location = new System.Drawing.Point(165, 36);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(77, 21);
            this.cbColor.TabIndex = 1;
            // 
            // cbStart
            // 
            this.cbStart.FormattingEnabled = true;
            this.cbStart.Location = new System.Drawing.Point(13, 36);
            this.cbStart.Name = "cbStart";
            this.cbStart.Size = new System.Drawing.Size(62, 21);
            this.cbStart.TabIndex = 0;
            // 
            // dgExData
            // 
            this.dgExData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgExData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgExData.Location = new System.Drawing.Point(0, 128);
            this.dgExData.Name = "dgExData";
            this.dgExData.ReadOnly = true;
            this.dgExData.Size = new System.Drawing.Size(647, 525);
            this.dgExData.TabIndex = 1;
            this.dgExData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgExData_CellDoubleClick);
            // 
            // gbChartControls
            // 
            this.gbChartControls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbChartControls.Controls.Add(this.groupBox3);
            this.gbChartControls.Controls.Add(this.groupBox1);
            this.gbChartControls.Controls.Add(this.btnSaveChart);
            this.gbChartControls.Controls.Add(this.btnClearSerColor);
            this.gbChartControls.Controls.Add(this.btnSetChart);
            this.gbChartControls.Controls.Add(this.gbFilter);
            this.gbChartControls.Controls.Add(this.groupBox2);
            this.gbChartControls.Location = new System.Drawing.Point(653, 12);
            this.gbChartControls.Name = "gbChartControls";
            this.gbChartControls.Size = new System.Drawing.Size(692, 253);
            this.gbChartControls.TabIndex = 15;
            this.gbChartControls.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtYRotation);
            this.groupBox3.Controls.Add(this.txtXRotation);
            this.groupBox3.Controls.Add(this.btnTickFont);
            this.groupBox3.Controls.Add(this.btnTitleFont);
            this.groupBox3.Controls.Add(this.btnAxisFont);
            this.groupBox3.Controls.Add(this.btnLegendFont);
            this.groupBox3.Location = new System.Drawing.Point(484, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(186, 135);
            this.groupBox3.TabIndex = 54;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Fonts";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(87, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 52;
            this.label4.Text = "Y Axis";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 51;
            this.label2.Text = "X Axis";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Text Rotation";
            // 
            // txtYRotation
            // 
            this.txtYRotation.Location = new System.Drawing.Point(128, 76);
            this.txtYRotation.Name = "txtYRotation";
            this.txtYRotation.Size = new System.Drawing.Size(52, 20);
            this.txtYRotation.TabIndex = 49;
            this.txtYRotation.Text = "0";
            // 
            // txtXRotation
            // 
            this.txtXRotation.Location = new System.Drawing.Point(127, 46);
            this.txtXRotation.Name = "txtXRotation";
            this.txtXRotation.Size = new System.Drawing.Size(53, 20);
            this.txtXRotation.TabIndex = 48;
            this.txtXRotation.Text = "0";
            // 
            // btnTickFont
            // 
            this.btnTickFont.Location = new System.Drawing.Point(6, 104);
            this.btnTickFont.Name = "btnTickFont";
            this.btnTickFont.Size = new System.Drawing.Size(75, 23);
            this.btnTickFont.TabIndex = 47;
            this.btnTickFont.Text = "Tick Marks";
            this.btnTickFont.UseVisualStyleBackColor = true;
            this.btnTickFont.Click += new System.EventHandler(this.btnTickFont_Click);
            // 
            // btnTitleFont
            // 
            this.btnTitleFont.Location = new System.Drawing.Point(6, 44);
            this.btnTitleFont.Name = "btnTitleFont";
            this.btnTitleFont.Size = new System.Drawing.Size(75, 23);
            this.btnTitleFont.TabIndex = 44;
            this.btnTitleFont.Text = "Title";
            this.btnTitleFont.UseVisualStyleBackColor = true;
            this.btnTitleFont.Click += new System.EventHandler(this.btnTitleFont_Click);
            // 
            // btnAxisFont
            // 
            this.btnAxisFont.Location = new System.Drawing.Point(6, 74);
            this.btnAxisFont.Name = "btnAxisFont";
            this.btnAxisFont.Size = new System.Drawing.Size(75, 23);
            this.btnAxisFont.TabIndex = 45;
            this.btnAxisFont.Text = "Axis Label";
            this.btnAxisFont.UseVisualStyleBackColor = true;
            this.btnAxisFont.Click += new System.EventHandler(this.btnAxisFont_Click);
            // 
            // btnLegendFont
            // 
            this.btnLegendFont.Location = new System.Drawing.Point(5, 14);
            this.btnLegendFont.Name = "btnLegendFont";
            this.btnLegendFont.Size = new System.Drawing.Size(75, 23);
            this.btnLegendFont.TabIndex = 46;
            this.btnLegendFont.Text = "Legend";
            this.btnLegendFont.UseVisualStyleBackColor = true;
            this.btnLegendFont.Click += new System.EventHandler(this.btnLegendFont_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblChartType);
            this.groupBox1.Controls.Add(this.cmbYAxis);
            this.groupBox1.Controls.Add(this.cmbXAxis);
            this.groupBox1.Controls.Add(this.lblYAxis);
            this.groupBox1.Controls.Add(this.lblXAxis);
            this.groupBox1.Controls.Add(this.cmbChartType);
            this.groupBox1.Location = new System.Drawing.Point(6, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(193, 135);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            // 
            // lblChartType
            // 
            this.lblChartType.AutoSize = true;
            this.lblChartType.Location = new System.Drawing.Point(6, 0);
            this.lblChartType.Name = "lblChartType";
            this.lblChartType.Size = new System.Drawing.Size(59, 13);
            this.lblChartType.TabIndex = 35;
            this.lblChartType.Text = "Chart Type";
            // 
            // cmbYAxis
            // 
            this.cmbYAxis.FormattingEnabled = true;
            this.cmbYAxis.Location = new System.Drawing.Point(5, 59);
            this.cmbYAxis.Name = "cmbYAxis";
            this.cmbYAxis.Size = new System.Drawing.Size(167, 21);
            this.cmbYAxis.TabIndex = 30;
            // 
            // cmbXAxis
            // 
            this.cmbXAxis.FormattingEnabled = true;
            this.cmbXAxis.Location = new System.Drawing.Point(5, 99);
            this.cmbXAxis.Name = "cmbXAxis";
            this.cmbXAxis.Size = new System.Drawing.Size(167, 21);
            this.cmbXAxis.TabIndex = 31;
            // 
            // lblYAxis
            // 
            this.lblYAxis.AutoSize = true;
            this.lblYAxis.Location = new System.Drawing.Point(5, 43);
            this.lblYAxis.Name = "lblYAxis";
            this.lblYAxis.Size = new System.Drawing.Size(36, 13);
            this.lblYAxis.TabIndex = 32;
            this.lblYAxis.Text = "Y Axis";
            // 
            // lblXAxis
            // 
            this.lblXAxis.AutoSize = true;
            this.lblXAxis.Location = new System.Drawing.Point(5, 83);
            this.lblXAxis.Name = "lblXAxis";
            this.lblXAxis.Size = new System.Drawing.Size(36, 13);
            this.lblXAxis.TabIndex = 33;
            this.lblXAxis.Text = "X Axis";
            // 
            // cmbChartType
            // 
            this.cmbChartType.FormattingEnabled = true;
            this.cmbChartType.Location = new System.Drawing.Point(5, 19);
            this.cmbChartType.Name = "cmbChartType";
            this.cmbChartType.Size = new System.Drawing.Size(169, 21);
            this.cmbChartType.TabIndex = 34;
            // 
            // btnSaveChart
            // 
            this.btnSaveChart.Location = new System.Drawing.Point(369, 165);
            this.btnSaveChart.Name = "btnSaveChart";
            this.btnSaveChart.Size = new System.Drawing.Size(88, 46);
            this.btnSaveChart.TabIndex = 51;
            this.btnSaveChart.Text = "Save Chart";
            this.btnSaveChart.UseVisualStyleBackColor = true;
            this.btnSaveChart.Click += new System.EventHandler(this.btnSaveChart_Click);
            // 
            // btnClearSerColor
            // 
            this.btnClearSerColor.Location = new System.Drawing.Point(463, 165);
            this.btnClearSerColor.Name = "btnClearSerColor";
            this.btnClearSerColor.Size = new System.Drawing.Size(89, 46);
            this.btnClearSerColor.TabIndex = 50;
            this.btnClearSerColor.Text = "Clear";
            this.btnClearSerColor.UseVisualStyleBackColor = true;
            // 
            // btnSetChart
            // 
            this.btnSetChart.Location = new System.Drawing.Point(275, 165);
            this.btnSetChart.Name = "btnSetChart";
            this.btnSetChart.Size = new System.Drawing.Size(88, 46);
            this.btnSetChart.TabIndex = 36;
            this.btnSetChart.Text = "Set Chart";
            this.btnSetChart.UseVisualStyleBackColor = true;
            this.btnSetChart.Click += new System.EventHandler(this.btnSetChart_Click);
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.lblPointWidth);
            this.gbFilter.Controls.Add(this.txtPointWidth);
            this.gbFilter.Controls.Add(this.lblRotation);
            this.gbFilter.Controls.Add(this.lblPerspective);
            this.gbFilter.Controls.Add(this.lblIncline);
            this.gbFilter.Controls.Add(this.txtRotation);
            this.gbFilter.Controls.Add(this.txtPerspective);
            this.gbFilter.Controls.Add(this.txtIncline);
            this.gbFilter.Location = new System.Drawing.Point(6, 158);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(263, 78);
            this.gbFilter.TabIndex = 37;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "3D Chart Settings";
            // 
            // lblPointWidth
            // 
            this.lblPointWidth.AutoSize = true;
            this.lblPointWidth.Location = new System.Drawing.Point(143, 53);
            this.lblPointWidth.Name = "lblPointWidth";
            this.lblPointWidth.Size = new System.Drawing.Size(62, 13);
            this.lblPointWidth.TabIndex = 23;
            this.lblPointWidth.Text = "Point Width";
            // 
            // txtPointWidth
            // 
            this.txtPointWidth.Location = new System.Drawing.Point(208, 50);
            this.txtPointWidth.Name = "txtPointWidth";
            this.txtPointWidth.Size = new System.Drawing.Size(47, 20);
            this.txtPointWidth.TabIndex = 22;
            this.txtPointWidth.Text = "5";
            // 
            // lblRotation
            // 
            this.lblRotation.AutoSize = true;
            this.lblRotation.Location = new System.Drawing.Point(158, 26);
            this.lblRotation.Name = "lblRotation";
            this.lblRotation.Size = new System.Drawing.Size(47, 13);
            this.lblRotation.TabIndex = 21;
            this.lblRotation.Text = "Rotation";
            // 
            // lblPerspective
            // 
            this.lblPerspective.AutoSize = true;
            this.lblPerspective.Location = new System.Drawing.Point(4, 48);
            this.lblPerspective.Name = "lblPerspective";
            this.lblPerspective.Size = new System.Drawing.Size(63, 13);
            this.lblPerspective.TabIndex = 20;
            this.lblPerspective.Text = "Perspective";
            // 
            // lblIncline
            // 
            this.lblIncline.AutoSize = true;
            this.lblIncline.Location = new System.Drawing.Point(29, 27);
            this.lblIncline.Name = "lblIncline";
            this.lblIncline.Size = new System.Drawing.Size(38, 13);
            this.lblIncline.TabIndex = 19;
            this.lblIncline.Text = "Incline";
            // 
            // txtRotation
            // 
            this.txtRotation.Location = new System.Drawing.Point(208, 23);
            this.txtRotation.Name = "txtRotation";
            this.txtRotation.Size = new System.Drawing.Size(48, 20);
            this.txtRotation.TabIndex = 18;
            this.txtRotation.Text = "45";
            // 
            // txtPerspective
            // 
            this.txtPerspective.Location = new System.Drawing.Point(72, 48);
            this.txtPerspective.Name = "txtPerspective";
            this.txtPerspective.Size = new System.Drawing.Size(48, 20);
            this.txtPerspective.TabIndex = 17;
            this.txtPerspective.Text = "5";
            // 
            // txtIncline
            // 
            this.txtIncline.Location = new System.Drawing.Point(72, 21);
            this.txtIncline.Name = "txtIncline";
            this.txtIncline.Size = new System.Drawing.Size(49, 20);
            this.txtIncline.TabIndex = 16;
            this.txtIncline.Text = "10";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblChartTitle);
            this.groupBox2.Controls.Add(this.txtChartTitle);
            this.groupBox2.Controls.Add(this.lblXAxix);
            this.groupBox2.Controls.Add(this.txtXAxisTitle);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtYAxisTitle);
            this.groupBox2.Location = new System.Drawing.Point(205, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(273, 135);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            // 
            // lblChartTitle
            // 
            this.lblChartTitle.AutoSize = true;
            this.lblChartTitle.Location = new System.Drawing.Point(6, 0);
            this.lblChartTitle.Name = "lblChartTitle";
            this.lblChartTitle.Size = new System.Drawing.Size(55, 13);
            this.lblChartTitle.TabIndex = 38;
            this.lblChartTitle.Text = "Chart Title";
            // 
            // txtChartTitle
            // 
            this.txtChartTitle.Location = new System.Drawing.Point(12, 19);
            this.txtChartTitle.Name = "txtChartTitle";
            this.txtChartTitle.Size = new System.Drawing.Size(254, 20);
            this.txtChartTitle.TabIndex = 39;
            this.txtChartTitle.Text = "ENTER CHART TITLE";
            // 
            // lblXAxix
            // 
            this.lblXAxix.AutoSize = true;
            this.lblXAxix.Location = new System.Drawing.Point(9, 43);
            this.lblXAxix.Name = "lblXAxix";
            this.lblXAxix.Size = new System.Drawing.Size(59, 13);
            this.lblXAxix.TabIndex = 40;
            this.lblXAxix.Text = "X Axis Title";
            // 
            // txtXAxisTitle
            // 
            this.txtXAxisTitle.Location = new System.Drawing.Point(9, 59);
            this.txtXAxisTitle.Name = "txtXAxisTitle";
            this.txtXAxisTitle.Size = new System.Drawing.Size(254, 20);
            this.txtXAxisTitle.TabIndex = 41;
            this.txtXAxisTitle.Text = "ENTER AXIS TITLE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Y Axis Title";
            // 
            // txtYAxisTitle
            // 
            this.txtYAxisTitle.Location = new System.Drawing.Point(9, 99);
            this.txtYAxisTitle.Name = "txtYAxisTitle";
            this.txtYAxisTitle.Size = new System.Drawing.Size(254, 20);
            this.txtYAxisTitle.TabIndex = 43;
            this.txtYAxisTitle.Text = "ENTER AXIS TITLE";
            // 
            // pbChart
            // 
            this.pbChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbChart.Location = new System.Drawing.Point(3, 3);
            this.pbChart.Name = "pbChart";
            this.pbChart.Size = new System.Drawing.Size(678, 350);
            this.pbChart.TabIndex = 16;
            this.pbChart.TabStop = false;
            // 
            // tabChart
            // 
            this.tabChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabChart.Controls.Add(this.tabPage2);
            this.tabChart.Controls.Add(this.tabPage1);
            this.tabChart.Controls.Add(this.tabPage3);
            this.tabChart.Location = new System.Drawing.Point(653, 271);
            this.tabChart.Name = "tabChart";
            this.tabChart.SelectedIndex = 0;
            this.tabChart.Size = new System.Drawing.Size(692, 382);
            this.tabChart.TabIndex = 17;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.rtbSummary);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(684, 356);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Summary";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // rtbSummary
            // 
            this.rtbSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSummary.Location = new System.Drawing.Point(3, 3);
            this.rtbSummary.Name = "rtbSummary";
            this.rtbSummary.Size = new System.Drawing.Size(678, 350);
            this.rtbSummary.TabIndex = 0;
            this.rtbSummary.Text = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pbChart);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(684, 356);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Chart";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgAnova);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(684, 356);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Anova";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgAnova
            // 
            this.dgAnova.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgAnova.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAnova.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgAnova.Location = new System.Drawing.Point(0, 0);
            this.dgAnova.Name = "dgAnova";
            this.dgAnova.Size = new System.Drawing.Size(684, 356);
            this.dgAnova.TabIndex = 0;
            this.dgAnova.DataSourceChanged += new System.EventHandler(this.dgAnova_DataSourceChanged);
            // 
            // frmData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1352, 659);
            this.Controls.Add(this.tabChart);
            this.Controls.Add(this.gbChartControls);
            this.Controls.Add(this.dgExData);
            this.Controls.Add(this.Filters);
            this.Name = "frmData";
            this.Text = "Experiment Data";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmData_FormClosing);
            this.Load += new System.EventHandler(this.frmData_Load);
            this.Filters.ResumeLayout(false);
            this.Filters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgExData)).EndInit();
            this.gbChartControls.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbChart)).EndInit();
            this.tabChart.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAnova)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Filters;
        private System.Windows.Forms.DataGridView dgExData;
        private System.Windows.Forms.Label lblWeek;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.ComboBox cbWeek;
        private System.Windows.Forms.ComboBox cbSex;
        private System.Windows.Forms.ComboBox cbColor;
        private System.Windows.Forms.ComboBox cbStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.ComboBox cbEnd;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.GroupBox gbChartControls;
        private System.Windows.Forms.Button btnSaveChart;
        private System.Windows.Forms.Button btnClearSerColor;
        private System.Windows.Forms.Button btnLegendFont;
        private System.Windows.Forms.Button btnAxisFont;
        private System.Windows.Forms.Button btnTitleFont;
        private System.Windows.Forms.TextBox txtYAxisTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtXAxisTitle;
        private System.Windows.Forms.Label lblXAxix;
        private System.Windows.Forms.TextBox txtChartTitle;
        private System.Windows.Forms.Label lblChartTitle;
        private System.Windows.Forms.Button btnSetChart;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Label lblPointWidth;
        private System.Windows.Forms.TextBox txtPointWidth;
        private System.Windows.Forms.Label lblRotation;
        private System.Windows.Forms.Label lblPerspective;
        private System.Windows.Forms.Label lblIncline;
        private System.Windows.Forms.TextBox txtRotation;
        private System.Windows.Forms.TextBox txtPerspective;
        private System.Windows.Forms.TextBox txtIncline;
        private System.Windows.Forms.Label lblChartType;
        private System.Windows.Forms.ComboBox cmbChartType;
        private System.Windows.Forms.Label lblXAxis;
        private System.Windows.Forms.Label lblYAxis;
        private System.Windows.Forms.ComboBox cmbXAxis;
        private System.Windows.Forms.ComboBox cmbYAxis;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pbChart;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TabControl tabChart;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox rtbSummary;
        private System.Windows.Forms.Button btnTickFont;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtYRotation;
        private System.Windows.Forms.TextBox txtXRotation;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgAnova;
    }
}