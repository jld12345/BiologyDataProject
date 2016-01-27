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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.fdUploadPic = new System.Windows.Forms.OpenFileDialog();
            this.pbImage = new System.Windows.Forms.Panel();
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
            this.udZoom = new System.Windows.Forms.NumericUpDown();
            this.lblZoom = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pbVideo)).BeginInit();
            this.pbImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pbVideo
            // 
            this.pbVideo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbVideo.Location = new System.Drawing.Point(16, 308);
            this.pbVideo.Name = "pbVideo";
            this.pbVideo.Size = new System.Drawing.Size(291, 226);
            this.pbVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbVideo.TabIndex = 0;
            this.pbVideo.TabStop = false;
            // 
            // btnPic
            // 
            this.btnPic.Location = new System.Drawing.Point(16, 591);
            this.btnPic.Name = "btnPic";
            this.btnPic.Size = new System.Drawing.Size(115, 50);
            this.btnPic.TabIndex = 19;
            this.btnPic.Text = "TAKE PICTURE";
            this.btnPic.UseVisualStyleBackColor = true;
            this.btnPic.Click += new System.EventHandler(this.btnPic_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(16, 647);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(116, 50);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(137, 647);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(116, 50);
            this.btnClear.TabIndex = 21;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cbCaptureDevice
            // 
            this.cbCaptureDevice.FormattingEnabled = true;
            this.cbCaptureDevice.Location = new System.Drawing.Point(13, 564);
            this.cbCaptureDevice.Name = "cbCaptureDevice";
            this.cbCaptureDevice.Size = new System.Drawing.Size(159, 21);
            this.cbCaptureDevice.TabIndex = 38;
            this.cbCaptureDevice.SelectedIndexChanged += new System.EventHandler(this.cbCaptureDevice_SelectedIndexChanged);
            // 
            // cbResolution
            // 
            this.cbResolution.FormattingEnabled = true;
            this.cbResolution.Location = new System.Drawing.Point(178, 564);
            this.cbResolution.Name = "cbResolution";
            this.cbResolution.Size = new System.Drawing.Size(96, 21);
            this.cbResolution.TabIndex = 39;
            this.cbResolution.SelectedIndexChanged += new System.EventHandler(this.cbResolution_SelectedIndexChanged);
            // 
            // lblVideo
            // 
            this.lblVideo.AutoSize = true;
            this.lblVideo.Location = new System.Drawing.Point(13, 548);
            this.lblVideo.Name = "lblVideo";
            this.lblVideo.Size = new System.Drawing.Size(71, 13);
            this.lblVideo.TabIndex = 40;
            this.lblVideo.Text = "Video Source";
            // 
            // lblRes
            // 
            this.lblRes.AutoSize = true;
            this.lblRes.Location = new System.Drawing.Point(175, 548);
            this.lblRes.Name = "lblRes";
            this.lblRes.Size = new System.Drawing.Size(57, 13);
            this.lblRes.TabIndex = 41;
            this.lblRes.Text = "Resolution";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(16, 703);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(116, 50);
            this.btnExit.TabIndex = 42;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(137, 591);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(116, 50);
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
            // txtCalibration
            // 
            this.txtCalibration.Location = new System.Drawing.Point(16, 239);
            this.txtCalibration.Name = "txtCalibration";
            this.txtCalibration.Size = new System.Drawing.Size(68, 20);
            this.txtCalibration.TabIndex = 48;
            // 
            // txtMeasure
            // 
            this.txtMeasure.Location = new System.Drawing.Point(16, 282);
            this.txtMeasure.Name = "txtMeasure";
            this.txtMeasure.Size = new System.Drawing.Size(68, 20);
            this.txtMeasure.TabIndex = 49;
            // 
            // lblCalibration
            // 
            this.lblCalibration.AutoSize = true;
            this.lblCalibration.Location = new System.Drawing.Point(13, 223);
            this.lblCalibration.Name = "lblCalibration";
            this.lblCalibration.Size = new System.Drawing.Size(56, 13);
            this.lblCalibration.TabIndex = 50;
            this.lblCalibration.Text = "Calibration";
            // 
            // lblMeasure
            // 
            this.lblMeasure.AutoSize = true;
            this.lblMeasure.Location = new System.Drawing.Point(13, 266);
            this.lblMeasure.Name = "lblMeasure";
            this.lblMeasure.Size = new System.Drawing.Size(74, 13);
            this.lblMeasure.TabIndex = 51;
            this.lblMeasure.Text = " Measurement";
            // 
            // cmbMeasurement
            // 
            this.cmbMeasurement.FormattingEnabled = true;
            this.cmbMeasurement.Location = new System.Drawing.Point(147, 238);
            this.cmbMeasurement.Name = "cmbMeasurement";
            this.cmbMeasurement.Size = new System.Drawing.Size(62, 21);
            this.cmbMeasurement.TabIndex = 52;
            // 
            // lblPer
            // 
            this.lblPer.AutoSize = true;
            this.lblPer.Location = new System.Drawing.Point(90, 242);
            this.lblPer.Name = "lblPer";
            this.lblPer.Size = new System.Drawing.Size(51, 13);
            this.lblPer.TabIndex = 53;
            this.lblPer.Text = "pixels per";
            // 
            // btnCalibrate
            // 
            this.btnCalibrate.Location = new System.Drawing.Point(232, 223);
            this.btnCalibrate.Name = "btnCalibrate";
            this.btnCalibrate.Size = new System.Drawing.Size(75, 24);
            this.btnCalibrate.TabIndex = 54;
            this.btnCalibrate.Text = "Calibrate";
            this.btnCalibrate.UseVisualStyleBackColor = true;
            this.btnCalibrate.Click += new System.EventHandler(this.btnCalibrate_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(232, 251);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 25);
            this.btnReset.TabIndex = 55;
            this.btnReset.Text = "Reset All";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnLineColor
            // 
            this.btnLineColor.BackColor = System.Drawing.Color.Yellow;
            this.btnLineColor.Location = new System.Drawing.Point(178, 282);
            this.btnLineColor.Name = "btnLineColor";
            this.btnLineColor.Size = new System.Drawing.Size(25, 20);
            this.btnLineColor.TabIndex = 56;
            this.btnLineColor.UseVisualStyleBackColor = false;
            this.btnLineColor.Click += new System.EventHandler(this.btnLineColor_Click);
            // 
            // cbLineWidth
            // 
            this.cbLineWidth.FormattingEnabled = true;
            this.cbLineWidth.Location = new System.Drawing.Point(93, 282);
            this.cbLineWidth.Name = "cbLineWidth";
            this.cbLineWidth.Size = new System.Drawing.Size(79, 21);
            this.cbLineWidth.TabIndex = 57;
            // 
            // lblLineSize
            // 
            this.lblLineSize.AutoSize = true;
            this.lblLineSize.Location = new System.Drawing.Point(94, 266);
            this.lblLineSize.Name = "lblLineSize";
            this.lblLineSize.Size = new System.Drawing.Size(58, 13);
            this.lblLineSize.TabIndex = 58;
            this.lblLineSize.Text = "Line Width";
            // 
            // btnResetLine
            // 
            this.btnResetLine.Location = new System.Drawing.Point(232, 282);
            this.btnResetLine.Name = "btnResetLine";
            this.btnResetLine.Size = new System.Drawing.Size(75, 25);
            this.btnResetLine.TabIndex = 59;
            this.btnResetLine.Text = "Reset Line";
            this.btnResetLine.UseVisualStyleBackColor = true;
            this.btnResetLine.Click += new System.EventHandler(this.btnResetLine_Click);
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
            // lblZoom
            // 
            this.lblZoom.AutoSize = true;
            this.lblZoom.Location = new System.Drawing.Point(13, 10);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(34, 13);
            this.lblZoom.TabIndex = 61;
            this.lblZoom.Text = "Zoom";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(951, 204);
            this.dataGridView1.TabIndex = 60;
            // 
            // frmExDataEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(983, 768);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnResetLine);
            this.Controls.Add(this.lblLineSize);
            this.Controls.Add(this.cbLineWidth);
            this.Controls.Add(this.btnLineColor);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCalibrate);
            this.Controls.Add(this.lblPer);
            this.Controls.Add(this.cmbMeasurement);
            this.Controls.Add(this.lblMeasure);
            this.Controls.Add(this.lblCalibration);
            this.Controls.Add(this.txtMeasure);
            this.Controls.Add(this.txtCalibration);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblRes);
            this.Controls.Add(this.lblVideo);
            this.Controls.Add(this.cbResolution);
            this.Controls.Add(this.cbCaptureDevice);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnPic);
            this.Controls.Add(this.pbVideo);
            this.Name = "frmExDataEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enter Data";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFishData_FormClosing);
            this.Load += new System.EventHandler(this.frmFishData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbVideo)).EndInit();
            this.pbImage.ResumeLayout(false);
            this.pbImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.Button btnExit;
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
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}