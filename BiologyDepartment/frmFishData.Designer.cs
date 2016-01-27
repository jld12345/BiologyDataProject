namespace BiologyDepartment
{
    partial class frmFishData
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
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.cbSex = new System.Windows.Forms.ComboBox();
            this.lblSex = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblLength = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.txtFish = new System.Windows.Forms.TextBox();
            this.lblFish = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.cbColor = new System.Windows.Forms.ComboBox();
            this.lblTank = new System.Windows.Forms.Label();
            this.txtTank = new System.Windows.Forms.TextBox();
            this.cbCaptureDevice = new System.Windows.Forms.ComboBox();
            this.cbResolution = new System.Windows.Forms.ComboBox();
            this.lblVideo = new System.Windows.Forms.Label();
            this.lblRes = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.dtpFishData = new System.Windows.Forms.DateTimePicker();
            this.btnUpload = new System.Windows.Forms.Button();
            this.fdUploadPic = new System.Windows.Forms.OpenFileDialog();
            this.txtWeek = new System.Windows.Forms.TextBox();
            this.lblWeek = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.pbVideo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // pbVideo
            // 
            this.pbVideo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbVideo.Location = new System.Drawing.Point(15, 443);
            this.pbVideo.Name = "pbVideo";
            this.pbVideo.Size = new System.Drawing.Size(291, 226);
            this.pbVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbVideo.TabIndex = 0;
            this.pbVideo.TabStop = false;
            // 
            // btnPic
            // 
            this.btnPic.Location = new System.Drawing.Point(313, 678);
            this.btnPic.Name = "btnPic";
            this.btnPic.Size = new System.Drawing.Size(115, 50);
            this.btnPic.TabIndex = 19;
            this.btnPic.Text = "TAKE PICTURE";
            this.btnPic.UseVisualStyleBackColor = true;
            this.btnPic.Click += new System.EventHandler(this.btnPic_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(579, 678);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(116, 50);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(715, 678);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(116, 50);
            this.btnClear.TabIndex = 21;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // rtbNotes
            // 
            this.rtbNotes.Location = new System.Drawing.Point(12, 92);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(294, 263);
            this.rtbNotes.TabIndex = 37;
            this.rtbNotes.Text = "";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(12, 76);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(35, 13);
            this.lblNotes.TabIndex = 36;
            this.lblNotes.Text = "Notes";
            // 
            // cbSex
            // 
            this.cbSex.FormattingEnabled = true;
            this.cbSex.Location = new System.Drawing.Point(672, 46);
            this.cbSex.Name = "cbSex";
            this.cbSex.Size = new System.Drawing.Size(68, 21);
            this.cbSex.TabIndex = 35;
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(669, 28);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(25, 13);
            this.lblSex.TabIndex = 34;
            this.lblSex.Text = "Sex";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(563, 28);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 33;
            this.lblDate.Text = "Date";
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(462, 28);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(40, 13);
            this.lblLength.TabIndex = 31;
            this.lblLength.Text = "Length";
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(361, 28);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(41, 13);
            this.lblWeight.TabIndex = 30;
            this.lblWeight.Text = "Weight";
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(465, 47);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(95, 20);
            this.txtLength.TabIndex = 29;
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(364, 47);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(95, 20);
            this.txtWeight.TabIndex = 28;
            // 
            // txtFish
            // 
            this.txtFish.Location = new System.Drawing.Point(263, 47);
            this.txtFish.Name = "txtFish";
            this.txtFish.Size = new System.Drawing.Size(95, 20);
            this.txtFish.TabIndex = 27;
            // 
            // lblFish
            // 
            this.lblFish.AutoSize = true;
            this.lblFish.Location = new System.Drawing.Point(260, 28);
            this.lblFish.Name = "lblFish";
            this.lblFish.Size = new System.Drawing.Size(66, 13);
            this.lblFish.TabIndex = 26;
            this.lblFish.Text = "Fish Number";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(111, 28);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(31, 13);
            this.lblColor.TabIndex = 25;
            this.lblColor.Text = "Color";
            // 
            // cbColor
            // 
            this.cbColor.FormattingEnabled = true;
            this.cbColor.Location = new System.Drawing.Point(114, 47);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(143, 21);
            this.cbColor.TabIndex = 24;
            // 
            // lblTank
            // 
            this.lblTank.AutoSize = true;
            this.lblTank.Location = new System.Drawing.Point(12, 28);
            this.lblTank.Name = "lblTank";
            this.lblTank.Size = new System.Drawing.Size(72, 13);
            this.lblTank.TabIndex = 23;
            this.lblTank.Text = "Tank Number";
            // 
            // txtTank
            // 
            this.txtTank.Location = new System.Drawing.Point(12, 47);
            this.txtTank.Name = "txtTank";
            this.txtTank.Size = new System.Drawing.Size(95, 20);
            this.txtTank.TabIndex = 22;
            // 
            // cbCaptureDevice
            // 
            this.cbCaptureDevice.FormattingEnabled = true;
            this.cbCaptureDevice.Location = new System.Drawing.Point(12, 699);
            this.cbCaptureDevice.Name = "cbCaptureDevice";
            this.cbCaptureDevice.Size = new System.Drawing.Size(159, 21);
            this.cbCaptureDevice.TabIndex = 38;
            this.cbCaptureDevice.SelectedIndexChanged += new System.EventHandler(this.cbCaptureDevice_SelectedIndexChanged);
            // 
            // cbResolution
            // 
            this.cbResolution.FormattingEnabled = true;
            this.cbResolution.Location = new System.Drawing.Point(177, 699);
            this.cbResolution.Name = "cbResolution";
            this.cbResolution.Size = new System.Drawing.Size(96, 21);
            this.cbResolution.TabIndex = 39;
            this.cbResolution.SelectedIndexChanged += new System.EventHandler(this.cbResolution_SelectedIndexChanged);
            // 
            // lblVideo
            // 
            this.lblVideo.AutoSize = true;
            this.lblVideo.Location = new System.Drawing.Point(12, 683);
            this.lblVideo.Name = "lblVideo";
            this.lblVideo.Size = new System.Drawing.Size(71, 13);
            this.lblVideo.TabIndex = 40;
            this.lblVideo.Text = "Video Source";
            // 
            // lblRes
            // 
            this.lblRes.AutoSize = true;
            this.lblRes.Location = new System.Drawing.Point(174, 683);
            this.lblRes.Name = "lblRes";
            this.lblRes.Size = new System.Drawing.Size(57, 13);
            this.lblRes.TabIndex = 41;
            this.lblRes.Text = "Resolution";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(851, 678);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(116, 50);
            this.btnExit.TabIndex = 42;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dtpFishData
            // 
            this.dtpFishData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFishData.Location = new System.Drawing.Point(566, 47);
            this.dtpFishData.Name = "dtpFishData";
            this.dtpFishData.Size = new System.Drawing.Size(100, 20);
            this.dtpFishData.TabIndex = 43;
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(447, 678);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(116, 50);
            this.btnUpload.TabIndex = 44;
            this.btnUpload.Text = "UPLOAD PIC";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // txtWeek
            // 
            this.txtWeek.Location = new System.Drawing.Point(746, 46);
            this.txtWeek.Name = "txtWeek";
            this.txtWeek.Size = new System.Drawing.Size(95, 20);
            this.txtWeek.TabIndex = 45;
            // 
            // lblWeek
            // 
            this.lblWeek.AutoSize = true;
            this.lblWeek.Location = new System.Drawing.Point(743, 28);
            this.lblWeek.Name = "lblWeek";
            this.lblWeek.Size = new System.Drawing.Size(36, 13);
            this.lblWeek.TabIndex = 46;
            this.lblWeek.Text = "Week";
            // 
            // pbImage
            // 
            this.pbImage.AutoScroll = true;
            this.pbImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage.Location = new System.Drawing.Point(313, 92);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(654, 577);
            this.pbImage.TabIndex = 47;
            this.pbImage.Paint += new System.Windows.Forms.PaintEventHandler(this.pbImage_Paint);
            this.pbImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbImage_MouseClick);
            this.pbImage.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pbImage_MouseDoubleClick);
            this.pbImage.MouseEnter += new System.EventHandler(this.pbImage_MouseEnter);
            this.pbImage.MouseLeave += new System.EventHandler(this.pbImage_MouseLeave);
            // 
            // txtCalibration
            // 
            this.txtCalibration.Location = new System.Drawing.Point(15, 374);
            this.txtCalibration.Name = "txtCalibration";
            this.txtCalibration.Size = new System.Drawing.Size(68, 20);
            this.txtCalibration.TabIndex = 48;
            // 
            // txtMeasure
            // 
            this.txtMeasure.Location = new System.Drawing.Point(15, 417);
            this.txtMeasure.Name = "txtMeasure";
            this.txtMeasure.Size = new System.Drawing.Size(68, 20);
            this.txtMeasure.TabIndex = 49;
            // 
            // lblCalibration
            // 
            this.lblCalibration.AutoSize = true;
            this.lblCalibration.Location = new System.Drawing.Point(12, 358);
            this.lblCalibration.Name = "lblCalibration";
            this.lblCalibration.Size = new System.Drawing.Size(56, 13);
            this.lblCalibration.TabIndex = 50;
            this.lblCalibration.Text = "Calibration";
            // 
            // lblMeasure
            // 
            this.lblMeasure.AutoSize = true;
            this.lblMeasure.Location = new System.Drawing.Point(12, 401);
            this.lblMeasure.Name = "lblMeasure";
            this.lblMeasure.Size = new System.Drawing.Size(74, 13);
            this.lblMeasure.TabIndex = 51;
            this.lblMeasure.Text = " Measurement";
            // 
            // cmbMeasurement
            // 
            this.cmbMeasurement.FormattingEnabled = true;
            this.cmbMeasurement.Location = new System.Drawing.Point(146, 373);
            this.cmbMeasurement.Name = "cmbMeasurement";
            this.cmbMeasurement.Size = new System.Drawing.Size(62, 21);
            this.cmbMeasurement.TabIndex = 52;
            // 
            // lblPer
            // 
            this.lblPer.AutoSize = true;
            this.lblPer.Location = new System.Drawing.Point(89, 377);
            this.lblPer.Name = "lblPer";
            this.lblPer.Size = new System.Drawing.Size(51, 13);
            this.lblPer.TabIndex = 53;
            this.lblPer.Text = "pixels per";
            // 
            // btnCalibrate
            // 
            this.btnCalibrate.Location = new System.Drawing.Point(231, 358);
            this.btnCalibrate.Name = "btnCalibrate";
            this.btnCalibrate.Size = new System.Drawing.Size(75, 24);
            this.btnCalibrate.TabIndex = 54;
            this.btnCalibrate.Text = "Calibrate";
            this.btnCalibrate.UseVisualStyleBackColor = true;
            this.btnCalibrate.Click += new System.EventHandler(this.btnCalibrate_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(231, 386);
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
            this.btnLineColor.Location = new System.Drawing.Point(177, 417);
            this.btnLineColor.Name = "btnLineColor";
            this.btnLineColor.Size = new System.Drawing.Size(25, 20);
            this.btnLineColor.TabIndex = 56;
            this.btnLineColor.UseVisualStyleBackColor = false;
            this.btnLineColor.Click += new System.EventHandler(this.btnLineColor_Click);
            // 
            // cbLineWidth
            // 
            this.cbLineWidth.FormattingEnabled = true;
            this.cbLineWidth.Location = new System.Drawing.Point(92, 417);
            this.cbLineWidth.Name = "cbLineWidth";
            this.cbLineWidth.Size = new System.Drawing.Size(79, 21);
            this.cbLineWidth.TabIndex = 57;
            // 
            // lblLineSize
            // 
            this.lblLineSize.AutoSize = true;
            this.lblLineSize.Location = new System.Drawing.Point(93, 401);
            this.lblLineSize.Name = "lblLineSize";
            this.lblLineSize.Size = new System.Drawing.Size(58, 13);
            this.lblLineSize.TabIndex = 58;
            this.lblLineSize.Text = "Line Width";
            // 
            // btnResetLine
            // 
            this.btnResetLine.Location = new System.Drawing.Point(231, 417);
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
            this.udZoom.Location = new System.Drawing.Point(918, 68);
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
            this.lblZoom.Location = new System.Drawing.Point(918, 52);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(34, 13);
            this.lblZoom.TabIndex = 61;
            this.lblZoom.Text = "Zoom";
            // 
            // frmFishData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(983, 768);
            this.Controls.Add(this.lblZoom);
            this.Controls.Add(this.udZoom);
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
            this.Controls.Add(this.lblWeek);
            this.Controls.Add(this.txtWeek);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.dtpFishData);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblRes);
            this.Controls.Add(this.lblVideo);
            this.Controls.Add(this.cbResolution);
            this.Controls.Add(this.cbCaptureDevice);
            this.Controls.Add(this.rtbNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.cbSex);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblLength);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.txtLength);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.txtFish);
            this.Controls.Add(this.lblFish);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.cbColor);
            this.Controls.Add(this.lblTank);
            this.Controls.Add(this.txtTank);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnPic);
            this.Controls.Add(this.pbVideo);
            this.Name = "frmFishData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enter Data";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFishData_FormClosing);
            this.Load += new System.EventHandler(this.frmFishData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbVideo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udZoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbVideo;
        private System.Windows.Forms.Button btnPic;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RichTextBox rtbNotes;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.ComboBox cbSex;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.TextBox txtFish;
        private System.Windows.Forms.Label lblFish;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.ComboBox cbColor;
        private System.Windows.Forms.Label lblTank;
        private System.Windows.Forms.TextBox txtTank;
        private System.Windows.Forms.ComboBox cbCaptureDevice;
        private System.Windows.Forms.ComboBox cbResolution;
        private System.Windows.Forms.Label lblVideo;
        private System.Windows.Forms.Label lblRes;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DateTimePicker dtpFishData;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.OpenFileDialog fdUploadPic;
        private System.Windows.Forms.TextBox txtWeek;
        private System.Windows.Forms.Label lblWeek;
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
    }
}