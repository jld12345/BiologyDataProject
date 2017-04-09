﻿namespace BiologyDepartment
{
    partial class FrmExDataEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExDataEntry));
            this.fdUploadPic = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolStripEx1 = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.btnSaveExit = new System.Windows.Forms.ToolStripButton();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCaptureImage = new System.Windows.Forms.ToolStripButton();
            this.btnUploadImage = new System.Windows.Forms.ToolStripButton();
            this.btnClearImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCalibrateLine = new System.Windows.Forms.ToolStripButton();
            this.btnClearLine = new System.Windows.Forms.ToolStripButton();
            this.btnClearAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnPrevious = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUnitsMeasured = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPixelCount = new System.Windows.Forms.TextBox();
            this.cmbMeasurementParent = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.udRotatePhoto = new System.Windows.Forms.NumericUpDown();
            this.lblZoom = new System.Windows.Forms.Label();
            this.udZoom = new System.Windows.Forms.NumericUpDown();
            this.pbVideo = new System.Windows.Forms.PictureBox();
            this.lblRes = new System.Windows.Forms.Label();
            this.btnLineColor = new System.Windows.Forms.Button();
            this.cbLineWidth = new System.Windows.Forms.ComboBox();
            this.lblLineSize = new System.Windows.Forms.Label();
            this.cbCaptureDevice = new System.Windows.Forms.ComboBox();
            this.cbResolution = new System.Windows.Forms.ComboBox();
            this.txtMeasure = new System.Windows.Forms.TextBox();
            this.lblMeasure = new System.Windows.Forms.Label();
            this.lblPer = new System.Windows.Forms.Label();
            this.lblVideo = new System.Windows.Forms.Label();
            this.cmbMeasurement = new System.Windows.Forms.ComboBox();
            this.lblCalibration = new System.Windows.Forms.Label();
            this.txtCalibration = new System.Windows.Forms.TextBox();
            this.pbImage = new System.Windows.Forms.Panel();
            this.toolStripEx1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udRotatePhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripEx1
            // 
            this.toolStripEx1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.toolStripEx1.Image = null;
            this.toolStripEx1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSaveExit,
            this.btnExit,
            this.btnAdd,
            this.toolStripSeparator1,
            this.btnCaptureImage,
            this.btnUploadImage,
            this.btnClearImage,
            this.toolStripSeparator2,
            this.btnCalibrateLine,
            this.btnClearLine,
            this.btnClearAll,
            this.toolStripSeparator3,
            this.BtnPrevious});
            this.toolStripEx1.Location = new System.Drawing.Point(0, 0);
            this.toolStripEx1.Name = "toolStripEx1";
            this.toolStripEx1.Size = new System.Drawing.Size(1330, 48);
            this.toolStripEx1.TabIndex = 63;
            this.toolStripEx1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolStripEx1_ItemClicked);
            // 
            // btnSaveExit
            // 
            this.btnSaveExit.AutoSize = false;
            this.btnSaveExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSaveExit.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveExit.Image")));
            this.btnSaveExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(75, 30);
            this.btnSaveExit.Text = "Save and Exit";
            this.btnSaveExit.Click += new System.EventHandler(this.BtnSaveExit_Click);
            // 
            // btnExit
            // 
            this.btnExit.AutoSize = false;
            this.btnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = false;
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 30);
            this.btnAdd.Text = "Add New";
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // btnCaptureImage
            // 
            this.btnCaptureImage.AutoSize = false;
            this.btnCaptureImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCaptureImage.Image = ((System.Drawing.Image)(resources.GetObject("btnCaptureImage.Image")));
            this.btnCaptureImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCaptureImage.Name = "btnCaptureImage";
            this.btnCaptureImage.Size = new System.Drawing.Size(90, 30);
            this.btnCaptureImage.Text = "Capture Image";
            this.btnCaptureImage.Click += new System.EventHandler(this.BtnPic_Click);
            // 
            // btnUploadImage
            // 
            this.btnUploadImage.AutoSize = false;
            this.btnUploadImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnUploadImage.Image = ((System.Drawing.Image)(resources.GetObject("btnUploadImage.Image")));
            this.btnUploadImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(90, 30);
            this.btnUploadImage.Text = "Upload Image";
            this.btnUploadImage.Click += new System.EventHandler(this.BtnUpload_Click);
            // 
            // btnClearImage
            // 
            this.btnClearImage.AutoSize = false;
            this.btnClearImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnClearImage.Image = ((System.Drawing.Image)(resources.GetObject("btnClearImage.Image")));
            this.btnClearImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClearImage.Name = "btnClearImage";
            this.btnClearImage.Size = new System.Drawing.Size(90, 30);
            this.btnClearImage.Text = "Clear Image";
            this.btnClearImage.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 33);
            // 
            // btnCalibrateLine
            // 
            this.btnCalibrateLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCalibrateLine.Image = ((System.Drawing.Image)(resources.GetObject("btnCalibrateLine.Image")));
            this.btnCalibrateLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCalibrateLine.Name = "btnCalibrateLine";
            this.btnCalibrateLine.Size = new System.Drawing.Size(58, 30);
            this.btnCalibrateLine.Text = "Calibrate";
            this.btnCalibrateLine.Click += new System.EventHandler(this.BtnCalibrate_Click);
            // 
            // btnClearLine
            // 
            this.btnClearLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnClearLine.Image = ((System.Drawing.Image)(resources.GetObject("btnClearLine.Image")));
            this.btnClearLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClearLine.Name = "btnClearLine";
            this.btnClearLine.Size = new System.Drawing.Size(63, 30);
            this.btnClearLine.Text = "Clear Line";
            this.btnClearLine.Click += new System.EventHandler(this.BtnResetLine_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnClearAll.Image = ((System.Drawing.Image)(resources.GetObject("btnClearAll.Image")));
            this.btnClearAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(55, 30);
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 33);
            // 
            // BtnPrevious
            // 
            this.BtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BtnPrevious.Image = ((System.Drawing.Image)(resources.GetObject("BtnPrevious.Image")));
            this.BtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnPrevious.Name = "BtnPrevious";
            this.BtnPrevious.Size = new System.Drawing.Size(56, 30);
            this.BtnPrevious.Text = "Previous";
            this.BtnPrevious.Click += new System.EventHandler(this.BtnPrevious_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.pbImage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1330, 777);
            this.panel1.TabIndex = 64;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.pnlInput);
            this.groupBox2.Location = new System.Drawing.Point(9, -10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(458, 741);
            this.groupBox2.TabIndex = 65;
            this.groupBox2.TabStop = false;
            // 
            // pnlInput
            // 
            this.pnlInput.AutoScroll = true;
            this.pnlInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInput.Location = new System.Drawing.Point(3, 16);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(452, 722);
            this.pnlInput.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtUnitsMeasured);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPixelCount);
            this.groupBox1.Controls.Add(this.cmbMeasurementParent);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.udRotatePhoto);
            this.groupBox1.Controls.Add(this.lblZoom);
            this.groupBox1.Controls.Add(this.udZoom);
            this.groupBox1.Controls.Add(this.pbVideo);
            this.groupBox1.Controls.Add(this.lblRes);
            this.groupBox1.Controls.Add(this.btnLineColor);
            this.groupBox1.Controls.Add(this.cbLineWidth);
            this.groupBox1.Controls.Add(this.lblLineSize);
            this.groupBox1.Controls.Add(this.cbCaptureDevice);
            this.groupBox1.Controls.Add(this.cbResolution);
            this.groupBox1.Controls.Add(this.txtMeasure);
            this.groupBox1.Controls.Add(this.lblMeasure);
            this.groupBox1.Controls.Add(this.lblPer);
            this.groupBox1.Controls.Add(this.lblVideo);
            this.groupBox1.Controls.Add(this.cmbMeasurement);
            this.groupBox1.Controls.Add(this.lblCalibration);
            this.groupBox1.Controls.Add(this.txtCalibration);
            this.groupBox1.Location = new System.Drawing.Point(473, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(845, 278);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(588, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 71;
            this.label4.Text = "Auto Fill Field";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(585, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 70;
            this.label3.Text = "Units Measured";
            // 
            // txtUnitsMeasured
            // 
            this.txtUnitsMeasured.Location = new System.Drawing.Point(588, 32);
            this.txtUnitsMeasured.Name = "txtUnitsMeasured";
            this.txtUnitsMeasured.Size = new System.Drawing.Size(78, 20);
            this.txtUnitsMeasured.TabIndex = 69;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(514, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 68;
            this.label1.Text = "Pixels";
            // 
            // txtPixelCount
            // 
            this.txtPixelCount.Enabled = false;
            this.txtPixelCount.Location = new System.Drawing.Point(517, 32);
            this.txtPixelCount.Name = "txtPixelCount";
            this.txtPixelCount.Size = new System.Drawing.Size(65, 20);
            this.txtPixelCount.TabIndex = 67;
            // 
            // cmbMeasurementParent
            // 
            this.cmbMeasurementParent.FormattingEnabled = true;
            this.cmbMeasurementParent.Location = new System.Drawing.Point(588, 72);
            this.cmbMeasurementParent.Name = "cmbMeasurementParent";
            this.cmbMeasurementParent.Size = new System.Drawing.Size(162, 21);
            this.cmbMeasurementParent.TabIndex = 66;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(395, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 65;
            this.label2.Text = "Rotate Photo";
            // 
            // udRotatePhoto
            // 
            this.udRotatePhoto.Increment = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.udRotatePhoto.Location = new System.Drawing.Point(395, 156);
            this.udRotatePhoto.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.udRotatePhoto.Name = "udRotatePhoto";
            this.udRotatePhoto.Size = new System.Drawing.Size(48, 20);
            this.udRotatePhoto.TabIndex = 64;
            this.udRotatePhoto.ValueChanged += new System.EventHandler(this.UdRotatePhoto_ValueChanged);
            // 
            // lblZoom
            // 
            this.lblZoom.AutoSize = true;
            this.lblZoom.Location = new System.Drawing.Point(324, 140);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(65, 13);
            this.lblZoom.TabIndex = 61;
            this.lblZoom.Text = "Zoom Photo";
            // 
            // udZoom
            // 
            this.udZoom.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.udZoom.Location = new System.Drawing.Point(324, 156);
            this.udZoom.Maximum = new decimal(new int[] {
            325,
            0,
            0,
            0});
            this.udZoom.Name = "udZoom";
            this.udZoom.Size = new System.Drawing.Size(48, 20);
            this.udZoom.TabIndex = 60;
            this.udZoom.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udZoom.ValueChanged += new System.EventHandler(this.UdZoom_ValueChanged);
            // 
            // pbVideo
            // 
            this.pbVideo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbVideo.Location = new System.Drawing.Point(6, 15);
            this.pbVideo.Name = "pbVideo";
            this.pbVideo.Size = new System.Drawing.Size(302, 257);
            this.pbVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbVideo.TabIndex = 0;
            this.pbVideo.TabStop = false;
            // 
            // lblRes
            // 
            this.lblRes.AutoSize = true;
            this.lblRes.Location = new System.Drawing.Point(324, 56);
            this.lblRes.Name = "lblRes";
            this.lblRes.Size = new System.Drawing.Size(57, 13);
            this.lblRes.TabIndex = 41;
            this.lblRes.Text = "Resolution";
            // 
            // btnLineColor
            // 
            this.btnLineColor.BackColor = System.Drawing.Color.Yellow;
            this.btnLineColor.Location = new System.Drawing.Point(663, 99);
            this.btnLineColor.Name = "btnLineColor";
            this.btnLineColor.Size = new System.Drawing.Size(25, 20);
            this.btnLineColor.TabIndex = 56;
            this.btnLineColor.UseVisualStyleBackColor = false;
            this.btnLineColor.Click += new System.EventHandler(this.BtnLineColor_Click);
            // 
            // cbLineWidth
            // 
            this.cbLineWidth.FormattingEnabled = true;
            this.cbLineWidth.Location = new System.Drawing.Point(583, 99);
            this.cbLineWidth.Name = "cbLineWidth";
            this.cbLineWidth.Size = new System.Drawing.Size(74, 21);
            this.cbLineWidth.TabIndex = 57;
            // 
            // lblLineSize
            // 
            this.lblLineSize.AutoSize = true;
            this.lblLineSize.Location = new System.Drawing.Point(516, 102);
            this.lblLineSize.Name = "lblLineSize";
            this.lblLineSize.Size = new System.Drawing.Size(58, 13);
            this.lblLineSize.TabIndex = 58;
            this.lblLineSize.Text = "Line Width";
            // 
            // cbCaptureDevice
            // 
            this.cbCaptureDevice.FormattingEnabled = true;
            this.cbCaptureDevice.Location = new System.Drawing.Point(324, 32);
            this.cbCaptureDevice.Name = "cbCaptureDevice";
            this.cbCaptureDevice.Size = new System.Drawing.Size(159, 21);
            this.cbCaptureDevice.TabIndex = 38;
            this.cbCaptureDevice.SelectedIndexChanged += new System.EventHandler(this.CbCaptureDevice_SelectedIndexChanged);
            // 
            // cbResolution
            // 
            this.cbResolution.FormattingEnabled = true;
            this.cbResolution.Location = new System.Drawing.Point(324, 72);
            this.cbResolution.Name = "cbResolution";
            this.cbResolution.Size = new System.Drawing.Size(65, 21);
            this.cbResolution.TabIndex = 39;
            this.cbResolution.SelectedIndexChanged += new System.EventHandler(this.CbResolution_SelectedIndexChanged);
            // 
            // txtMeasure
            // 
            this.txtMeasure.Location = new System.Drawing.Point(514, 72);
            this.txtMeasure.Name = "txtMeasure";
            this.txtMeasure.Size = new System.Drawing.Size(68, 20);
            this.txtMeasure.TabIndex = 49;
            this.txtMeasure.TextChanged += new System.EventHandler(this.TxtMeasure_TextChanged);
            // 
            // lblMeasure
            // 
            this.lblMeasure.AutoSize = true;
            this.lblMeasure.Location = new System.Drawing.Point(508, 54);
            this.lblMeasure.Name = "lblMeasure";
            this.lblMeasure.Size = new System.Drawing.Size(74, 13);
            this.lblMeasure.TabIndex = 51;
            this.lblMeasure.Text = " Measurement";
            // 
            // lblPer
            // 
            this.lblPer.AutoSize = true;
            this.lblPer.Location = new System.Drawing.Point(740, 15);
            this.lblPer.Name = "lblPer";
            this.lblPer.Size = new System.Drawing.Size(51, 13);
            this.lblPer.TabIndex = 53;
            this.lblPer.Text = "pixels per";
            // 
            // lblVideo
            // 
            this.lblVideo.AutoSize = true;
            this.lblVideo.Location = new System.Drawing.Point(324, 16);
            this.lblVideo.Name = "lblVideo";
            this.lblVideo.Size = new System.Drawing.Size(71, 13);
            this.lblVideo.TabIndex = 40;
            this.lblVideo.Text = "Video Source";
            // 
            // cmbMeasurement
            // 
            this.cmbMeasurement.FormattingEnabled = true;
            this.cmbMeasurement.Location = new System.Drawing.Point(743, 31);
            this.cmbMeasurement.Name = "cmbMeasurement";
            this.cmbMeasurement.Size = new System.Drawing.Size(68, 21);
            this.cmbMeasurement.TabIndex = 52;
            // 
            // lblCalibration
            // 
            this.lblCalibration.AutoSize = true;
            this.lblCalibration.Location = new System.Drawing.Point(672, 16);
            this.lblCalibration.Name = "lblCalibration";
            this.lblCalibration.Size = new System.Drawing.Size(56, 13);
            this.lblCalibration.TabIndex = 50;
            this.lblCalibration.Text = "Calibration";
            // 
            // txtCalibration
            // 
            this.txtCalibration.Enabled = false;
            this.txtCalibration.Location = new System.Drawing.Point(672, 32);
            this.txtCalibration.Name = "txtCalibration";
            this.txtCalibration.Size = new System.Drawing.Size(65, 20);
            this.txtCalibration.TabIndex = 48;
            // 
            // pbImage
            // 
            this.pbImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbImage.AutoScroll = true;
            this.pbImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage.Location = new System.Drawing.Point(473, 284);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(845, 447);
            this.pbImage.TabIndex = 63;
            this.pbImage.Paint += new System.Windows.Forms.PaintEventHandler(this.PbImage_Paint);
            this.pbImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PbImage_MouseClick);
            this.pbImage.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PbImage_MouseDoubleClick);
            this.pbImage.MouseEnter += new System.EventHandler(this.PbImage_MouseEnter);
            this.pbImage.MouseLeave += new System.EventHandler(this.PbImage_MouseLeave);
            this.pbImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PbImage_MouseMove);
            // 
            // FrmExDataEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1330, 825);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStripEx1);
            this.DoubleBuffered = true;
            this.Name = "FrmExDataEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enter Data";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmFishData_FormClosing);
            this.Load += new System.EventHandler(this.FrmFishData_Load);
            this.toolStripEx1.ResumeLayout(false);
            this.toolStripEx1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udRotatePhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVideo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog fdUploadPic;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx toolStripEx1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnCaptureImage;
        private System.Windows.Forms.ToolStripButton btnUploadImage;
        private System.Windows.Forms.ToolStripButton btnClearImage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnCalibrateLine;
        private System.Windows.Forms.ToolStripButton btnClearLine;
        private System.Windows.Forms.ToolStripButton btnClearAll;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pbVideo;
        private System.Windows.Forms.Label lblRes;
        private System.Windows.Forms.Button btnLineColor;
        private System.Windows.Forms.ComboBox cbLineWidth;
        private System.Windows.Forms.Label lblLineSize;
        private System.Windows.Forms.ComboBox cbCaptureDevice;
        private System.Windows.Forms.ComboBox cbResolution;
        private System.Windows.Forms.TextBox txtMeasure;
        private System.Windows.Forms.Label lblMeasure;
        private System.Windows.Forms.Label lblPer;
        private System.Windows.Forms.Label lblVideo;
        private System.Windows.Forms.ComboBox cmbMeasurement;
        private System.Windows.Forms.Label lblCalibration;
        private System.Windows.Forms.TextBox txtCalibration;
        private System.Windows.Forms.Panel pbImage;
        private System.Windows.Forms.Label lblZoom;
        private System.Windows.Forms.NumericUpDown udZoom;
        private System.Windows.Forms.ToolStripButton btnSaveExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown udRotatePhoto;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton BtnPrevious;
        private System.Windows.Forms.ComboBox cmbMeasurementParent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPixelCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUnitsMeasured;
    }
}