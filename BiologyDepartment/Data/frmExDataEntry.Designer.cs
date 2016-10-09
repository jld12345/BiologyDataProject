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
            this.pbVideo = new System.Windows.Forms.PictureBox();
            this.btnPic = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.cbCaptureDevice = new System.Windows.Forms.ComboBox();
            this.cbResolution = new System.Windows.Forms.ComboBox();
            this.lblVideo = new System.Windows.Forms.Label();
            this.lblRes = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.fdUploadPic = new System.Windows.Forms.OpenFileDialog();
            this.pbImage = new System.Windows.Forms.Panel();
            this.lblZoom = new System.Windows.Forms.Label();
            this.udZoom = new System.Windows.Forms.NumericUpDown();
            this.txtCalibration = new System.Windows.Forms.TextBox();
            this.txtMeasure = new System.Windows.Forms.TextBox();
            this.lblCalibration = new System.Windows.Forms.Label();
            this.lblMeasure = new System.Windows.Forms.Label();
            this.cmbMeasurement = new System.Windows.Forms.ComboBox();
            this.lblPer = new System.Windows.Forms.Label();
            this.btnCalibrate = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnLineColor = new System.Windows.Forms.Button();
            this.cbLineWidth = new System.Windows.Forms.ComboBox();
            this.lblLineSize = new System.Windows.Forms.Label();
            this.btnResetLine = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnlInput = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbVideo)).BeginInit();
            this.pbImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udZoom)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbVideo
            // 
            this.pbVideo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbVideo.Location = new System.Drawing.Point(6, 15);
            this.pbVideo.Name = "pbVideo";
            this.pbVideo.Size = new System.Drawing.Size(230, 182);
            this.pbVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbVideo.TabIndex = 0;
            this.pbVideo.TabStop = false;
            // 
            // btnPic
            // 
            this.btnPic.Location = new System.Drawing.Point(252, 114);
            this.btnPic.Name = "btnPic";
            this.btnPic.Size = new System.Drawing.Size(71, 37);
            this.btnPic.TabIndex = 19;
            this.btnPic.Text = "TAKE PICTURE";
            this.btnPic.UseVisualStyleBackColor = true;
            this.btnPic.Click += new System.EventHandler(this.btnPic_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(252, 157);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(71, 36);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(329, 155);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(74, 38);
            this.btnClear.TabIndex = 21;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
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
            // lblVideo
            // 
            this.lblVideo.AutoSize = true;
            this.lblVideo.Location = new System.Drawing.Point(252, 17);
            this.lblVideo.Name = "lblVideo";
            this.lblVideo.Size = new System.Drawing.Size(71, 13);
            this.lblVideo.TabIndex = 40;
            this.lblVideo.Text = "Video Source";
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
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(329, 114);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(74, 37);
            this.btnUpload.TabIndex = 44;
            this.btnUpload.Text = "UPLOAD PIC";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // pbImage
            // 
            this.pbImage.AutoScroll = true;
            this.pbImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage.Controls.Add(this.lblZoom);
            this.pbImage.Controls.Add(this.udZoom);
            this.pbImage.Location = new System.Drawing.Point(313, 223);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(654, 530);
            this.pbImage.TabIndex = 47;
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
            // txtCalibration
            // 
            this.txtCalibration.Location = new System.Drawing.Point(445, 32);
            this.txtCalibration.Name = "txtCalibration";
            this.txtCalibration.Size = new System.Drawing.Size(65, 20);
            this.txtCalibration.TabIndex = 48;
            // 
            // txtMeasure
            // 
            this.txtMeasure.Location = new System.Drawing.Point(448, 112);
            this.txtMeasure.Name = "txtMeasure";
            this.txtMeasure.Size = new System.Drawing.Size(199, 20);
            this.txtMeasure.TabIndex = 49;
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
            // lblMeasure
            // 
            this.lblMeasure.AutoSize = true;
            this.lblMeasure.Location = new System.Drawing.Point(442, 94);
            this.lblMeasure.Name = "lblMeasure";
            this.lblMeasure.Size = new System.Drawing.Size(74, 13);
            this.lblMeasure.TabIndex = 51;
            this.lblMeasure.Text = " Measurement";
            // 
            // cmbMeasurement
            // 
            this.cmbMeasurement.FormattingEnabled = true;
            this.cmbMeasurement.Location = new System.Drawing.Point(448, 71);
            this.cmbMeasurement.Name = "cmbMeasurement";
            this.cmbMeasurement.Size = new System.Drawing.Size(68, 21);
            this.cmbMeasurement.TabIndex = 52;
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
            // btnCalibrate
            // 
            this.btnCalibrate.Location = new System.Drawing.Point(551, 29);
            this.btnCalibrate.Name = "btnCalibrate";
            this.btnCalibrate.Size = new System.Drawing.Size(74, 24);
            this.btnCalibrate.TabIndex = 54;
            this.btnCalibrate.Text = "Calibrate";
            this.btnCalibrate.UseVisualStyleBackColor = true;
            this.btnCalibrate.Click += new System.EventHandler(this.btnCalibrate_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(448, 168);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(74, 25);
            this.btnReset.TabIndex = 55;
            this.btnReset.Text = "Reset All";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
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
            // btnResetLine
            // 
            this.btnResetLine.Location = new System.Drawing.Point(528, 168);
            this.btnResetLine.Name = "btnResetLine";
            this.btnResetLine.Size = new System.Drawing.Size(74, 25);
            this.btnResetLine.TabIndex = 59;
            this.btnResetLine.Text = "Reset Line";
            this.btnResetLine.UseVisualStyleBackColor = true;
            this.btnResetLine.Click += new System.EventHandler(this.btnResetLine_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbVideo);
            this.groupBox1.Controls.Add(this.lblRes);
            this.groupBox1.Controls.Add(this.btnLineColor);
            this.groupBox1.Controls.Add(this.btnUpload);
            this.groupBox1.Controls.Add(this.cbLineWidth);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.lblLineSize);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnResetLine);
            this.groupBox1.Controls.Add(this.btnPic);
            this.groupBox1.Controls.Add(this.cbCaptureDevice);
            this.groupBox1.Controls.Add(this.cbResolution);
            this.groupBox1.Controls.Add(this.txtMeasure);
            this.groupBox1.Controls.Add(this.lblMeasure);
            this.groupBox1.Controls.Add(this.lblPer);
            this.groupBox1.Controls.Add(this.lblVideo);
            this.groupBox1.Controls.Add(this.cmbMeasurement);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnCalibrate);
            this.groupBox1.Controls.Add(this.lblCalibration);
            this.groupBox1.Controls.Add(this.txtCalibration);
            this.groupBox1.Location = new System.Drawing.Point(314, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(653, 204);
            this.groupBox1.TabIndex = 61;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.pnlInput);
            this.groupBox2.Location = new System.Drawing.Point(2, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(306, 741);
            this.groupBox2.TabIndex = 62;
            this.groupBox2.TabStop = false;
            // 
            // pnlInput
            // 
            this.pnlInput.AutoScroll = true;
            this.pnlInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInput.Location = new System.Drawing.Point(3, 16);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(300, 722);
            this.pnlInput.TabIndex = 0;
            // 
            // frmExDataEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(983, 768);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pbImage);
            this.DoubleBuffered = true;
            this.Name = "frmExDataEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enter Data";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFishData_FormClosing);
            this.Load += new System.EventHandler(this.frmFishData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbVideo)).EndInit();
            this.pbImage.ResumeLayout(false);
            this.pbImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udZoom)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbVideo;
        private System.Windows.Forms.Button btnPic;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox cbCaptureDevice;
        private System.Windows.Forms.ComboBox cbResolution;
        private System.Windows.Forms.Label lblVideo;
        private System.Windows.Forms.Label lblRes;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.OpenFileDialog fdUploadPic;
        private System.Windows.Forms.Panel pbImage;
        private System.Windows.Forms.TextBox txtCalibration;
        private System.Windows.Forms.TextBox txtMeasure;
        private System.Windows.Forms.Label lblCalibration;
        private System.Windows.Forms.Label lblMeasure;
        private System.Windows.Forms.ComboBox cmbMeasurement;
        private System.Windows.Forms.Label lblPer;
        private System.Windows.Forms.Button btnCalibrate;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnLineColor;
        private System.Windows.Forms.ComboBox cbLineWidth;
        private System.Windows.Forms.Label lblLineSize;
        private System.Windows.Forms.Button btnResetLine;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.NumericUpDown udZoom;
        private System.Windows.Forms.Label lblZoom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel pnlInput;
    }
}