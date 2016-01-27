namespace BiologyDepartment
{
    partial class frmAuthor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.btnSavePic = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAddExp = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnTakePic = new System.Windows.Forms.Button();
            this.btnDelPic = new System.Windows.Forms.Button();
            this.pbCurPic = new System.Windows.Forms.PictureBox();
            this.lblLName = new System.Windows.Forms.Label();
            this.txtMI = new System.Windows.Forms.TextBox();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtAff = new System.Windows.Forms.TextBox();
            this.txtDept = new System.Windows.Forms.TextBox();
            this.lblMI = new System.Windows.Forms.Label();
            this.lblFName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblAff = new System.Windows.Forms.Label();
            this.lblDept = new System.Windows.Forms.Label();
            this.cbLName = new System.Windows.Forms.ComboBox();
            this.pbAuthor = new System.Windows.Forms.PictureBox();
            this.lblCurPic = new System.Windows.Forms.Label();
            this.lblNewPic = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.cbDevice = new System.Windows.Forms.ComboBox();
            this.lblCameras = new System.Windows.Forms.Label();
            this.cbRes = new System.Windows.Forms.ComboBox();
            this.lblRes = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCurPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAuthor)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCloseForm);
            this.groupBox1.Controls.Add(this.btnSavePic);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnDel);
            this.groupBox1.Controls.Add(this.btnAddExp);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Controls.Add(this.btnTakePic);
            this.groupBox1.Controls.Add(this.btnDelPic);
            this.groupBox1.Location = new System.Drawing.Point(348, 209);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 267);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.Location = new System.Drawing.Point(149, 215);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(127, 43);
            this.btnCloseForm.TabIndex = 22;
            this.btnCloseForm.Text = "Close Form";
            this.btnCloseForm.UseVisualStyleBackColor = true;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // btnSavePic
            // 
            this.btnSavePic.Location = new System.Drawing.Point(149, 166);
            this.btnSavePic.Name = "btnSavePic";
            this.btnSavePic.Size = new System.Drawing.Size(127, 43);
            this.btnSavePic.TabIndex = 17;
            this.btnSavePic.Text = "Save Picture";
            this.btnSavePic.UseVisualStyleBackColor = true;
            this.btnSavePic.Click += new System.EventHandler(this.btnSavePic_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(149, 117);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(127, 43);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(6, 117);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(127, 43);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save Author";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(149, 68);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(127, 43);
            this.btnDel.TabIndex = 19;
            this.btnDel.Text = "Delete Author";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAddExp
            // 
            this.btnAddExp.Location = new System.Drawing.Point(6, 68);
            this.btnAddExp.Name = "btnAddExp";
            this.btnAddExp.Size = new System.Drawing.Size(127, 43);
            this.btnAddExp.TabIndex = 18;
            this.btnAddExp.Text = "Add to Experiment";
            this.btnAddExp.UseVisualStyleBackColor = true;
            this.btnAddExp.Click += new System.EventHandler(this.btnAddExp_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(149, 19);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(127, 43);
            this.btnEdit.TabIndex = 17;
            this.btnEdit.Text = "Edit Author";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(6, 19);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(127, 43);
            this.btnNew.TabIndex = 16;
            this.btnNew.Text = "New Author";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnTakePic
            // 
            this.btnTakePic.Location = new System.Drawing.Point(6, 166);
            this.btnTakePic.Name = "btnTakePic";
            this.btnTakePic.Size = new System.Drawing.Size(127, 43);
            this.btnTakePic.TabIndex = 2;
            this.btnTakePic.Text = "Take Picture";
            this.btnTakePic.UseVisualStyleBackColor = true;
            this.btnTakePic.Click += new System.EventHandler(this.btnTakePic_Click);
            // 
            // btnDelPic
            // 
            this.btnDelPic.Location = new System.Drawing.Point(6, 216);
            this.btnDelPic.Name = "btnDelPic";
            this.btnDelPic.Size = new System.Drawing.Size(127, 43);
            this.btnDelPic.TabIndex = 3;
            this.btnDelPic.Text = "Delete Picture";
            this.btnDelPic.UseVisualStyleBackColor = true;
            this.btnDelPic.Click += new System.EventHandler(this.btnDelPic_Click);
            // 
            // pbCurPic
            // 
            this.pbCurPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCurPic.Location = new System.Drawing.Point(12, 71);
            this.pbCurPic.Name = "pbCurPic";
            this.pbCurPic.Size = new System.Drawing.Size(260, 189);
            this.pbCurPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCurPic.TabIndex = 1;
            this.pbCurPic.TabStop = false;
            // 
            // lblLName
            // 
            this.lblLName.AutoSize = true;
            this.lblLName.Location = new System.Drawing.Point(322, 9);
            this.lblLName.Name = "lblLName";
            this.lblLName.Size = new System.Drawing.Size(58, 13);
            this.lblLName.TabIndex = 4;
            this.lblLName.Text = "Last Name";
            // 
            // txtMI
            // 
            this.txtMI.Enabled = false;
            this.txtMI.Location = new System.Drawing.Point(386, 67);
            this.txtMI.Name = "txtMI";
            this.txtMI.Size = new System.Drawing.Size(67, 20);
            this.txtMI.TabIndex = 6;
            // 
            // txtFName
            // 
            this.txtFName.Enabled = false;
            this.txtFName.Location = new System.Drawing.Point(386, 37);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(196, 20);
            this.txtFName.TabIndex = 7;
            // 
            // txtEmail
            // 
            this.txtEmail.Enabled = false;
            this.txtEmail.Location = new System.Drawing.Point(386, 97);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(196, 20);
            this.txtEmail.TabIndex = 8;
            // 
            // txtAff
            // 
            this.txtAff.Enabled = false;
            this.txtAff.Location = new System.Drawing.Point(386, 127);
            this.txtAff.Name = "txtAff";
            this.txtAff.Size = new System.Drawing.Size(196, 20);
            this.txtAff.TabIndex = 9;
            // 
            // txtDept
            // 
            this.txtDept.Enabled = false;
            this.txtDept.Location = new System.Drawing.Point(386, 157);
            this.txtDept.Name = "txtDept";
            this.txtDept.Size = new System.Drawing.Size(196, 20);
            this.txtDept.TabIndex = 10;
            // 
            // lblMI
            // 
            this.lblMI.AutoSize = true;
            this.lblMI.Location = new System.Drawing.Point(361, 70);
            this.lblMI.Name = "lblMI";
            this.lblMI.Size = new System.Drawing.Size(19, 13);
            this.lblMI.TabIndex = 11;
            this.lblMI.Text = "MI";
            // 
            // lblFName
            // 
            this.lblFName.AutoSize = true;
            this.lblFName.Location = new System.Drawing.Point(323, 40);
            this.lblFName.Name = "lblFName";
            this.lblFName.Size = new System.Drawing.Size(57, 13);
            this.lblFName.TabIndex = 12;
            this.lblFName.Text = "First Name";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(348, 100);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 13;
            this.lblEmail.Text = "Email";
            // 
            // lblAff
            // 
            this.lblAff.AutoSize = true;
            this.lblAff.Location = new System.Drawing.Point(331, 130);
            this.lblAff.Name = "lblAff";
            this.lblAff.Size = new System.Drawing.Size(49, 13);
            this.lblAff.TabIndex = 14;
            this.lblAff.Text = "Affiliation";
            // 
            // lblDept
            // 
            this.lblDept.AutoSize = true;
            this.lblDept.Location = new System.Drawing.Point(318, 160);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(62, 13);
            this.lblDept.TabIndex = 15;
            this.lblDept.Text = "Department";
            // 
            // cbLName
            // 
            this.cbLName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLName.FormattingEnabled = true;
            this.cbLName.Location = new System.Drawing.Point(386, 6);
            this.cbLName.Name = "cbLName";
            this.cbLName.Size = new System.Drawing.Size(196, 21);
            this.cbLName.TabIndex = 16;
            this.cbLName.SelectedIndexChanged += new System.EventHandler(this.cbLName_SelectedIndexChanged);
            // 
            // pbAuthor
            // 
            this.pbAuthor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAuthor.Location = new System.Drawing.Point(12, 282);
            this.pbAuthor.Name = "pbAuthor";
            this.pbAuthor.Size = new System.Drawing.Size(260, 189);
            this.pbAuthor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAuthor.TabIndex = 17;
            this.pbAuthor.TabStop = false;
            // 
            // lblCurPic
            // 
            this.lblCurPic.AutoSize = true;
            this.lblCurPic.Location = new System.Drawing.Point(12, 266);
            this.lblCurPic.Name = "lblCurPic";
            this.lblCurPic.Size = new System.Drawing.Size(111, 13);
            this.lblCurPic.TabIndex = 18;
            this.lblCurPic.Text = "Current Author Picture";
            // 
            // lblNewPic
            // 
            this.lblNewPic.AutoSize = true;
            this.lblNewPic.Location = new System.Drawing.Point(12, 55);
            this.lblNewPic.Name = "lblNewPic";
            this.lblNewPic.Size = new System.Drawing.Size(121, 13);
            this.lblNewPic.TabIndex = 19;
            this.lblNewPic.Text = "WebCam Author Picture";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "JPEG images (*.jpg)|*.jpg|PNG images (*.png)|*.png|BMP images (*.bmp)|*.bmp";
            this.saveFileDialog.Title = "Save snapshot";
            // 
            // cbDevice
            // 
            this.cbDevice.FormattingEnabled = true;
            this.cbDevice.Location = new System.Drawing.Point(109, 3);
            this.cbDevice.Name = "cbDevice";
            this.cbDevice.Size = new System.Drawing.Size(163, 21);
            this.cbDevice.TabIndex = 20;
            this.cbDevice.SelectedIndexChanged += new System.EventHandler(this.cbDevice_SelectedIndexChanged);
            // 
            // lblCameras
            // 
            this.lblCameras.AutoSize = true;
            this.lblCameras.Location = new System.Drawing.Point(55, 6);
            this.lblCameras.Name = "lblCameras";
            this.lblCameras.Size = new System.Drawing.Size(48, 13);
            this.lblCameras.TabIndex = 21;
            this.lblCameras.Text = "Cameras";
            // 
            // cbRes
            // 
            this.cbRes.FormattingEnabled = true;
            this.cbRes.Location = new System.Drawing.Point(109, 30);
            this.cbRes.Name = "cbRes";
            this.cbRes.Size = new System.Drawing.Size(162, 21);
            this.cbRes.TabIndex = 22;
            this.cbRes.SelectedIndexChanged += new System.EventHandler(this.cbRes_SelectedIndexChanged);
            // 
            // lblRes
            // 
            this.lblRes.AutoSize = true;
            this.lblRes.Location = new System.Drawing.Point(46, 33);
            this.lblRes.Name = "lblRes";
            this.lblRes.Size = new System.Drawing.Size(57, 13);
            this.lblRes.TabIndex = 23;
            this.lblRes.Text = "Resolution";
            // 
            // frmAuthor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(642, 488);
            this.Controls.Add(this.lblRes);
            this.Controls.Add(this.cbRes);
            this.Controls.Add(this.lblCameras);
            this.Controls.Add(this.cbDevice);
            this.Controls.Add(this.lblNewPic);
            this.Controls.Add(this.lblCurPic);
            this.Controls.Add(this.pbAuthor);
            this.Controls.Add(this.cbLName);
            this.Controls.Add(this.lblDept);
            this.Controls.Add(this.lblAff);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblFName);
            this.Controls.Add(this.lblMI);
            this.Controls.Add(this.txtDept);
            this.Controls.Add(this.txtAff);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtFName);
            this.Controls.Add(this.txtMI);
            this.Controls.Add(this.lblLName);
            this.Controls.Add(this.pbCurPic);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmAuthor";
            this.Text = "Author Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAuthor_FormClosed);
            this.Load += new System.EventHandler(this.frmAuthor_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCurPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAuthor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pbCurPic;
        private System.Windows.Forms.Button btnTakePic;
        private System.Windows.Forms.Button btnDelPic;
        private System.Windows.Forms.Label lblLName;
        private System.Windows.Forms.TextBox txtMI;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtAff;
        private System.Windows.Forms.TextBox txtDept;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAddExp;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label lblMI;
        private System.Windows.Forms.Label lblFName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblAff;
        private System.Windows.Forms.Label lblDept;
        private System.Windows.Forms.ComboBox cbLName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSavePic;
        private System.Windows.Forms.PictureBox pbAuthor;
        private System.Windows.Forms.Label lblCurPic;
        private System.Windows.Forms.Label lblNewPic;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ComboBox cbDevice;
        private System.Windows.Forms.Label lblCameras;
        private System.Windows.Forms.ComboBox cbRes;
        private System.Windows.Forms.Label lblRes;
        private System.Windows.Forms.Button btnCloseForm;
    }
}