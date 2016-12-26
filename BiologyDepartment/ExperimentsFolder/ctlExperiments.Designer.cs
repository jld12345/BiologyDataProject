namespace BiologyDepartment
{
    partial class ctlExperiments
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gbExperiment = new System.Windows.Forms.GroupBox();
            this.btnPermissions = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.txtExID = new System.Windows.Forms.TextBox();
            this.cmbParentEx = new System.Windows.Forms.ComboBox();
            this.lblParentEx = new System.Windows.Forms.Label();
            this.eDatePicker = new System.Windows.Forms.DateTimePicker();
            this.sDatePicker = new System.Windows.Forms.DateTimePicker();
            this.txtSName = new System.Windows.Forms.TextBox();
            this.lblHypo = new System.Windows.Forms.Label();
            this.rtxtHypo = new System.Windows.Forms.RichTextBox();
            this.lblEDate = new System.Windows.Forms.Label();
            this.txtOfficialName = new System.Windows.Forms.TextBox();
            this.lblSDate = new System.Windows.Forms.Label();
            this.lblSName = new System.Windows.Forms.Label();
            this.lblOfficalName = new System.Windows.Forms.Label();
            this.dgExperiments = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.gbExperiment.SuspendLayout();
            this.gbInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgExperiments)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.dgExperiments);
            this.splitContainer1.Panel2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.splitContainer1.Size = new System.Drawing.Size(1457, 632);
            this.splitContainer1.SplitterDistance = 445;
            this.splitContainer1.TabIndex = 29;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gbExperiment);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gbInfo);
            this.splitContainer2.Size = new System.Drawing.Size(445, 632);
            this.splitContainer2.SplitterDistance = 202;
            this.splitContainer2.TabIndex = 0;
            // 
            // gbExperiment
            // 
            this.gbExperiment.Controls.Add(this.btnCancel);
            this.gbExperiment.Controls.Add(this.btnPermissions);
            this.gbExperiment.Controls.Add(this.btnDelete);
            this.gbExperiment.Controls.Add(this.btnEdit);
            this.gbExperiment.Controls.Add(this.btnSave);
            this.gbExperiment.Controls.Add(this.btnNew);
            this.gbExperiment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbExperiment.Location = new System.Drawing.Point(0, 0);
            this.gbExperiment.Name = "gbExperiment";
            this.gbExperiment.Size = new System.Drawing.Size(445, 202);
            this.gbExperiment.TabIndex = 29;
            this.gbExperiment.TabStop = false;
            // 
            // btnPermissions
            // 
            this.btnPermissions.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnPermissions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPermissions.Location = new System.Drawing.Point(6, 76);
            this.btnPermissions.Name = "btnPermissions";
            this.btnPermissions.Size = new System.Drawing.Size(148, 44);
            this.btnPermissions.TabIndex = 15;
            this.btnPermissions.Text = "Permissions";
            this.btnPermissions.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(186, 75);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(148, 44);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(186, 26);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(148, 44);
            this.btnEdit.TabIndex = 12;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(187, 125);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(148, 44);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(6, 26);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(148, 44);
            this.btnNew.TabIndex = 9;
            this.btnNew.Text = "New Experiment";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.BtnNew_Click_1);
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.txtExID);
            this.gbInfo.Controls.Add(this.cmbParentEx);
            this.gbInfo.Controls.Add(this.lblParentEx);
            this.gbInfo.Controls.Add(this.eDatePicker);
            this.gbInfo.Controls.Add(this.sDatePicker);
            this.gbInfo.Controls.Add(this.txtSName);
            this.gbInfo.Controls.Add(this.lblHypo);
            this.gbInfo.Controls.Add(this.rtxtHypo);
            this.gbInfo.Controls.Add(this.lblEDate);
            this.gbInfo.Controls.Add(this.txtOfficialName);
            this.gbInfo.Controls.Add(this.lblSDate);
            this.gbInfo.Controls.Add(this.lblSName);
            this.gbInfo.Controls.Add(this.lblOfficalName);
            this.gbInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbInfo.Location = new System.Drawing.Point(0, 0);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(445, 426);
            this.gbInfo.TabIndex = 31;
            this.gbInfo.TabStop = false;
            // 
            // txtExID
            // 
            this.txtExID.Enabled = false;
            this.txtExID.Location = new System.Drawing.Point(364, 8);
            this.txtExID.Name = "txtExID";
            this.txtExID.Size = new System.Drawing.Size(75, 20);
            this.txtExID.TabIndex = 29;
            // 
            // cmbParentEx
            // 
            this.cmbParentEx.FormattingEnabled = true;
            this.cmbParentEx.Location = new System.Drawing.Point(87, 75);
            this.cmbParentEx.Name = "cmbParentEx";
            this.cmbParentEx.Size = new System.Drawing.Size(270, 21);
            this.cmbParentEx.TabIndex = 28;
            // 
            // lblParentEx
            // 
            this.lblParentEx.AutoSize = true;
            this.lblParentEx.Location = new System.Drawing.Point(40, 78);
            this.lblParentEx.Name = "lblParentEx";
            this.lblParentEx.Size = new System.Drawing.Size(38, 13);
            this.lblParentEx.TabIndex = 27;
            this.lblParentEx.Text = "Parent";
            // 
            // eDatePicker
            // 
            this.eDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.eDatePicker.Location = new System.Drawing.Point(87, 141);
            this.eDatePicker.Name = "eDatePicker";
            this.eDatePicker.Size = new System.Drawing.Size(103, 20);
            this.eDatePicker.TabIndex = 1;
            // 
            // sDatePicker
            // 
            this.sDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.sDatePicker.Location = new System.Drawing.Point(86, 108);
            this.sDatePicker.Name = "sDatePicker";
            this.sDatePicker.Size = new System.Drawing.Size(104, 20);
            this.sDatePicker.TabIndex = 0;
            // 
            // txtSName
            // 
            this.txtSName.Location = new System.Drawing.Point(84, 9);
            this.txtSName.Name = "txtSName";
            this.txtSName.Size = new System.Drawing.Size(273, 20);
            this.txtSName.TabIndex = 24;
            // 
            // lblHypo
            // 
            this.lblHypo.AutoSize = true;
            this.lblHypo.Location = new System.Drawing.Point(19, 171);
            this.lblHypo.Name = "lblHypo";
            this.lblHypo.Size = new System.Drawing.Size(108, 13);
            this.lblHypo.TabIndex = 23;
            this.lblHypo.Text = "Additional Information";
            // 
            // rtxtHypo
            // 
            this.rtxtHypo.Location = new System.Drawing.Point(6, 187);
            this.rtxtHypo.Name = "rtxtHypo";
            this.rtxtHypo.Size = new System.Drawing.Size(432, 210);
            this.rtxtHypo.TabIndex = 26;
            this.rtxtHypo.Text = "";
            // 
            // lblEDate
            // 
            this.lblEDate.AutoSize = true;
            this.lblEDate.Location = new System.Drawing.Point(26, 147);
            this.lblEDate.Name = "lblEDate";
            this.lblEDate.Size = new System.Drawing.Size(52, 13);
            this.lblEDate.TabIndex = 22;
            this.lblEDate.Text = "End Date";
            // 
            // txtOfficialName
            // 
            this.txtOfficialName.Location = new System.Drawing.Point(84, 42);
            this.txtOfficialName.Name = "txtOfficialName";
            this.txtOfficialName.Size = new System.Drawing.Size(328, 20);
            this.txtOfficialName.TabIndex = 25;
            // 
            // lblSDate
            // 
            this.lblSDate.AutoSize = true;
            this.lblSDate.Location = new System.Drawing.Point(23, 114);
            this.lblSDate.Name = "lblSDate";
            this.lblSDate.Size = new System.Drawing.Size(55, 13);
            this.lblSDate.TabIndex = 21;
            this.lblSDate.Text = "Start Date";
            // 
            // lblSName
            // 
            this.lblSName.AutoSize = true;
            this.lblSName.Location = new System.Drawing.Point(15, 12);
            this.lblSName.Name = "lblSName";
            this.lblSName.Size = new System.Drawing.Size(63, 13);
            this.lblSName.TabIndex = 19;
            this.lblSName.Text = "Code Name";
            // 
            // lblOfficalName
            // 
            this.lblOfficalName.AutoSize = true;
            this.lblOfficalName.Location = new System.Drawing.Point(7, 45);
            this.lblOfficalName.Name = "lblOfficalName";
            this.lblOfficalName.Size = new System.Drawing.Size(71, 13);
            this.lblOfficalName.TabIndex = 20;
            this.lblOfficalName.Text = "Project Name";
            // 
            // dgExperiments
            // 
            this.dgExperiments.AllowUserToAddRows = false;
            this.dgExperiments.AllowUserToDeleteRows = false;
            this.dgExperiments.AllowUserToOrderColumns = true;
            this.dgExperiments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgExperiments.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgExperiments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgExperiments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgExperiments.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgExperiments.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgExperiments.Location = new System.Drawing.Point(2, 6);
            this.dgExperiments.MultiSelect = false;
            this.dgExperiments.Name = "dgExperiments";
            this.dgExperiments.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgExperiments.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgExperiments.Size = new System.Drawing.Size(1002, 199);
            this.dgExperiments.TabIndex = 18;
            this.dgExperiments.Visible = false;
            this.dgExperiments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgExperiments_CellContentClick);
            this.dgExperiments.SelectionChanged += new System.EventHandler(this.DgExperiments_SelectionChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(6, 126);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(148, 44);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // ctlExperiments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ctlExperiments";
            this.Size = new System.Drawing.Size(1460, 635);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.gbExperiment.ResumeLayout(false);
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgExperiments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox gbExperiment;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.DateTimePicker eDatePicker;
        private System.Windows.Forms.DateTimePicker sDatePicker;
        private System.Windows.Forms.TextBox txtSName;
        private System.Windows.Forms.Label lblHypo;
        private System.Windows.Forms.RichTextBox rtxtHypo;
        private System.Windows.Forms.Label lblEDate;
        private System.Windows.Forms.TextBox txtOfficialName;
        private System.Windows.Forms.Label lblSDate;
        private System.Windows.Forms.Label lblSName;
        private System.Windows.Forms.Label lblOfficalName;
        private System.Windows.Forms.Button btnPermissions;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ComboBox cmbParentEx;
        private System.Windows.Forms.Label lblParentEx;
        private System.Windows.Forms.TextBox txtExID;
        private System.Windows.Forms.DataGridView dgExperiments;
        private System.Windows.Forms.Button btnCancel;
    }
}
