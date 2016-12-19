namespace BiologyDepartment
{
    partial class frmExDataEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExDataEntry));
            this.fdUploadPic = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolStripEx1 = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.btnSaveExit = new System.Windows.Forms.ToolStripButton();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCaptureImage = new System.Windows.Forms.ToolStripButton();
            this.btnSaveImage = new System.Windows.Forms.ToolStripButton();
            this.btnUploadImage = new System.Windows.Forms.ToolStripButton();
            this.btnClearImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCalibrateLine = new System.Windows.Forms.ToolStripButton();
            this.btnClearLine = new System.Windows.Forms.ToolStripButton();
            this.btnClearAll = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.lblZoom = new System.Windows.Forms.Label();
            this.udZoom = new System.Windows.Forms.NumericUpDown();
            this.toolStripEx1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVideo)).BeginInit();
            this.pbImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udZoom)).BeginInit();
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
            this.btnSaveImage,
            this.btnUploadImage,
            this.btnClearImage,
            this.toolStripSeparator2,
            this.btnCalibrateLine,
            this.btnClearLine,
            this.btnClearAll});
            this.toolStripEx1.Location = new System.Drawing.Point(0, 0);
            this.toolStripEx1.Name = "toolStripEx1";
            this.toolStripEx1.Size = new System.Drawing.Size(1051, 48);
            this.toolStripEx1.TabIndex = 63;
            this.toolStripEx1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripEx1_ItemClicked);
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
            this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
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
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
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
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.btnCaptureImage.Click += new System.EventHandler(this.btnPic_Click);
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.AutoSize = false;
            this.btnSaveImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSaveImage.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveImage.Image")));
            this.btnSaveImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(90, 30);
            this.btnSaveImage.Text = "Save Image";
            this.btnSaveImage.Click += new System.EventHandler(this.btnSave_Click);
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
            this.btnUploadImage.Click += new System.EventHandler(this.btnUpload_Click);
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
            this.btnClearImage.Click += new System.EventHandler(this.btnClear_Click);
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
            this.btnCalibrateLine.Click += new System.EventHandler(this.btnCalibrate_Click);
            // 
            // btnClearLine
            // 
            this.btnClearLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnClearLine.Image = ((System.Drawing.Image)(resources.GetObject("btnClearLine.Image")));
            this.btnClearLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClearLine.Name = "btnClearLine";
            this.btnClearLine.Size = new System.Drawing.Size(63, 30);
            this.btnClearLine.Text = "Clear Line";
            this.btnClearLine.Click += new System.EventHandler(this.btnResetLine_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnClearAll.Image = ((System.Drawing.Image)(resources.GetObject("btnClearAll.Image")));
            this.btnClearAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(55, 30);
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.pbImage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1051, 720);
            this.panel1.TabIndex = 64;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.pnlInput);
            this.groupBox2.Location = new System.Drawing.Point(9, -10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(370, 741);
            this.groupBox2.TabIndex = 65;
            this.groupBox2.TabStop = false;
            // 
            // pnlInput
            // 
            this.pnlInput.AutoScroll = true;
            this.pnlInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInput.Location = new System.Drawing.Point(3, 16);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(364, 722);
            this.pnlInput.TabIndex = 0;
            // 
            // groupBox1
            // 
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
            this.groupBox1.Location = new System.Drawing.Point(386, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(653, 195);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            // 
            // pbVideo
            // 
            this.pbVideo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbVideo.Location = new System.Drawing.Point(6, 15);
            this.pbVideo.Name = "pbVideo";
            this.pbVideo.Size = new System.Drawing.Size(230, 174);
            this.pbVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbVideo.TabIndex = 0;
            this.pbVideo.TabStop = false;
            // 
            // lblRes
            // 
            this.lblRes.AutoSize = true;
            this.lblRes.Location = new System.Drawing.Point(252, 57);
            this.lblRes.Name = "lblRes";
            this.lblRes.Size = new System.Drawing.Size(57, 13);
            this.lblRes.TabIndex = 41;
            this.lblRes.Text = "Resolution";
            // 
            // btnLineColor
            // 
            this.btnLineColor.BackColor = System.Drawing.Color.Yellow;
            this.btnLineColor.Location = new System.Drawing.Point(520, 32);
            this.btnLineColor.Name = "btnLineColor";
            this.btnLineColor.Size = new System.Drawing.Size(25, 20);
            this.btnLineColor.TabIndex = 56;
            this.btnLineColor.UseVisualStyleBackColor = false;
            this.btnLineColor.Click += new System.EventHandler(this.btnLineColor_Click);
            // 
            // cbLineWidth
            // 
            this.cbLineWidth.FormattingEnabled = true;
            this.cbLineWidth.Location = new System.Drawing.Point(528, 71);
            this.cbLineWidth.Name = "cbLineWidth";
            this.cbLineWidth.Size = new System.Drawing.Size(74, 21);
            this.cbLineWidth.TabIndex = 57;
            // 
            // lblLineSize
            // 
            this.lblLineSize.AutoSize = true;
            this.lblLineSize.Location = new System.Drawing.Point(525, 55);
            this.lblLineSize.Name = "lblLineSize";
            this.lblLineSize.Size = new System.Drawing.Size(58, 13);
            this.lblLineSize.TabIndex = 58;
            this.lblLineSize.Text = "Line Width";
            // 
            // cbCaptureDevice
            // 
            this.cbCaptureDevice.FormattingEnabled = true;
            this.cbCaptureDevice.Location = new System.Drawing.Point(252, 33);
            this.cbCaptureDevice.Name = "cbCaptureDevice";
            this.cbCaptureDevice.Size = new System.Drawing.Size(159, 21);
            this.cbCaptureDevice.TabIndex = 38;
            this.cbCaptureDevice.SelectedIndexChanged += new System.EventHandler(this.cbCaptureDevice_SelectedIndexChanged);
            // 
            // cbResolution
            // 
            this.cbResolution.FormattingEnabled = true;
            this.cbResolution.Location = new System.Drawing.Point(252, 73);
            this.cbResolution.Name = "cbResolution";
            this.cbResolution.Size = new System.Drawing.Size(65, 21);
            this.cbResolution.TabIndex = 39;
            this.cbResolution.SelectedIndexChanged += new System.EventHandler(this.cbResolution_SelectedIndexChanged);
            // 
            // txtMeasure
            // 
            this.txtMeasure.Location = new System.Drawing.Point(448, 112);
            this.txtMeasure.Name = "txtMeasure";
            this.txtMeasure.Size = new System.Drawing.Size(199, 20);
            this.txtMeasure.TabIndex = 49;
            // 
            // lblMeasure
            // 
            this.lblMeasure.AutoSize = true;
            this.lblMeasure.Location = new System.Drawing.Point(442, 94);
            this.lblMeasure.Name = "lblMeasure";
            this.lblMeasure.Size = new System.Drawing.Size(74, 13);
            this.lblMeasure.TabIndex = 51;
            this.lblMeasure.Text = " Measurement";
            // 
            // lblPer
            // 
            this.lblPer.AutoSize = true;
            this.lblPer.Location = new System.Drawing.Point(445, 55);
            this.lblPer.Name = "lblPer";
            this.lblPer.Size = new System.Drawing.Size(51, 13);
            this.lblPer.TabIndex = 53;
            this.lblPer.Text = "pixels per";
            // 
            // lblVideo
            // 
            this.lblVideo.AutoSize = true;
            this.lblVideo.Location = new System.Drawing.Point(252, 17);
            this.lblVideo.Name = "lblVideo";
            this.lblVideo.Size = new System.Drawing.Size(71, 13);
            this.lblVideo.TabIndex = 40;
            this.lblVideo.Text = "Video Source";
            // 
            // cmbMeasurement
            // 
            this.cmbMeasurement.FormattingEnabled = true;
            this.cmbMeasurement.Location = new System.Drawing.Point(448, 71);
            this.cmbMeasurement.Name = "cmbMeasurement";
            this.cmbMeasurement.Size = new System.Drawing.Size(68, 21);
            this.cmbMeasurement.TabIndex = 52;
            // 
            // lblCalibration
            // 
            this.lblCalibration.AutoSize = true;
            this.lblCalibration.Location = new System.Drawing.Point(442, 16);
            this.lblCalibration.Name = "lblCalibration";
            this.lblCalibration.Size = new System.Drawing.Size(56, 13);
            this.lblCalibration.TabIndex = 50;
            this.lblCalibration.Text = "Calibration";
            // 
            // txtCalibration
            // 
            this.txtCalibration.Location = new System.Drawing.Point(445, 32);
            this.txtCalibration.Name = "txtCalibration";
            this.txtCalibration.Size = new System.Drawing.Size(65, 20);
            this.txtCalibration.TabIndex = 48;
            // 
            // pbImage
            // 
            this.pbImage.AutoScroll = true;
            this.pbImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage.Controls.Add(this.lblZoom);
            this.pbImage.Controls.Add(this.udZoom);
            this.pbImage.Location = new System.Drawing.Point(385, 201);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(654, 530);
            this.pbImage.TabIndex = 63;
            this.pbImage.Paint += new System.Windows.Forms.PaintEventHandler(this.pbImage_Paint);
            this.pbImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbImage_MouseClick);
            this.pbImage.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pbImage_MouseDoubleClick);
            this.pbImage.MouseEnter += new System.EventHandler(this.pbImage_MouseEnter);
            this.pbImage.MouseLeave += new System.EventHandler(this.pbImage_MouseLeave);
            // 
            // lblZoom
            // 
            this.lblZoom.AutoSize = true;
            this.lblZoom.Location = new System.Drawing.Point(13, 10);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(34, 13);
            this.lblZoom.TabIndex = 61;
            this.lblZoom.Text = "Zoom";
            // 
            // udZoom
            // 
            this.udZoom.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.udZoom.Location = new System.Drawing.Point(13, 26);
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
            this.udZoom.ValueChanged += new System.EventHandler(this.udZoom_ValueChanged);
            // 
            // frmExDataEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1051, 768);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStripEx1);
            this.DoubleBuffered = true;
            this.Name = "frmExDataEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enter Data";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFishData_FormClosing);
            this.Load += new System.EventHandler(this.frmFishData_Load);
            this.toolStripEx1.ResumeLayout(false);
            this.toolStripEx1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVideo)).EndInit();
            this.pbImage.ResumeLayout(false);
            this.pbImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udZoom)).EndInit();
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
        private System.Windows.Forms.ToolStripButton btnSaveImage;
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
    }
}