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
            this.gbButtons = new System.Windows.Forms.GroupBox();
            this.btnPermissions = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.gbExperiment = new System.Windows.Forms.GroupBox();
            this.cbExperiments = new System.Windows.Forms.ComboBox();
            this.gbInfo = new System.Windows.Forms.GroupBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.gbButtons.SuspendLayout();
            this.gbExperiment.SuspendLayout();
            this.gbInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgExperiments)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
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
            this.splitContainer1.Size = new System.Drawing.Size(1457, 683);
            this.splitContainer1.SplitterDistance = 625;
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
            this.splitContainer2.Panel1.Controls.Add(this.gbButtons);
            this.splitContainer2.Panel1.Controls.Add(this.gbExperiment);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gbInfo);
            this.splitContainer2.Size = new System.Drawing.Size(625, 683);
            this.splitContainer2.SplitterDistance = 286;
            this.splitContainer2.TabIndex = 0;
            // 
            // gbButtons
            // 
            this.gbButtons.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gbButtons.Controls.Add(this.btnPermissions);
            this.gbButtons.Controls.Add(this.btnRefresh);
            this.gbButtons.Controls.Add(this.btnDelete);
            this.gbButtons.Controls.Add(this.btnEdit);
            this.gbButtons.Controls.Add(this.btnSave);
            this.gbButtons.Controls.Add(this.btnView);
            this.gbButtons.Controls.Add(this.btnNew);
            this.gbButtons.Location = new System.Drawing.Point(7, 51);
            this.gbButtons.Name = "gbButtons";
            this.gbButtons.Size = new System.Drawing.Size(341, 225);
            this.gbButtons.TabIndex = 30;
            this.gbButtons.TabStop = false;
            // 
            // btnPermissions
            // 
            this.btnPermissions.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnPermissions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPermissions.Location = new System.Drawing.Point(7, 170);
            this.btnPermissions.Name = "btnPermissions";
            this.btnPermissions.Size = new System.Drawing.Size(148, 44);
            this.btnPermissions.TabIndex = 8;
            this.btnPermissions.Text = "Permissions";
            this.btnPermissions.UseVisualStyleBackColor = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(7, 119);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(148, 44);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Refresh Data";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(187, 69);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(148, 44);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(187, 20);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(148, 44);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(187, 119);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(148, 44);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Location = new System.Drawing.Point(7, 69);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(148, 44);
            this.btnView.TabIndex = 1;
            this.btnView.Text = "View Data";
            this.btnView.UseVisualStyleBackColor = false;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(7, 20);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(148, 44);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "New Experiment";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // gbExperiment
            // 
            this.gbExperiment.Controls.Add(this.cbExperiments);
            this.gbExperiment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbExperiment.Location = new System.Drawing.Point(0, 0);
            this.gbExperiment.Name = "gbExperiment";
            this.gbExperiment.Size = new System.Drawing.Size(625, 286);
            this.gbExperiment.TabIndex = 29;
            this.gbExperiment.TabStop = false;
            this.gbExperiment.Text = "Experiment";
            // 
            // cbExperiments
            // 
            this.cbExperiments.FormattingEnabled = true;
            this.cbExperiments.Location = new System.Drawing.Point(6, 19);
            this.cbExperiments.Name = "cbExperiments";
            this.cbExperiments.Size = new System.Drawing.Size(329, 21);
            this.cbExperiments.TabIndex = 1;
            this.cbExperiments.SelectionChangeCommitted += new System.EventHandler(this.cbExperiments_SelectionChangeCommitted);
            this.cbExperiments.SelectedValueChanged += new System.EventHandler(this.cbExperiments_SelectedValueChanged);
            // 
            // gbInfo
            // 
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
            this.gbInfo.Size = new System.Drawing.Size(625, 393);
            this.gbInfo.TabIndex = 31;
            this.gbInfo.TabStop = false;
            // 
            // eDatePicker
            // 
            this.eDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.eDatePicker.Location = new System.Drawing.Point(113, 107);
            this.eDatePicker.Name = "eDatePicker";
            this.eDatePicker.Size = new System.Drawing.Size(103, 20);
            this.eDatePicker.TabIndex = 1;
            // 
            // sDatePicker
            // 
            this.sDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.sDatePicker.Location = new System.Drawing.Point(112, 74);
            this.sDatePicker.Name = "sDatePicker";
            this.sDatePicker.Size = new System.Drawing.Size(104, 20);
            this.sDatePicker.TabIndex = 0;
            // 
            // txtSName
            // 
            this.txtSName.Location = new System.Drawing.Point(110, 9);
            this.txtSName.Name = "txtSName";
            this.txtSName.Size = new System.Drawing.Size(273, 20);
            this.txtSName.TabIndex = 24;
            // 
            // lblHypo
            // 
            this.lblHypo.AutoSize = true;
            this.lblHypo.Location = new System.Drawing.Point(45, 144);
            this.lblHypo.Name = "lblHypo";
            this.lblHypo.Size = new System.Drawing.Size(59, 13);
            this.lblHypo.TabIndex = 23;
            this.lblHypo.Text = "Hypothesis";
            // 
            // rtxtHypo
            // 
            this.rtxtHypo.Location = new System.Drawing.Point(112, 144);
            this.rtxtHypo.Name = "rtxtHypo";
            this.rtxtHypo.Size = new System.Drawing.Size(455, 120);
            this.rtxtHypo.TabIndex = 26;
            this.rtxtHypo.Text = "";
            // 
            // lblEDate
            // 
            this.lblEDate.AutoSize = true;
            this.lblEDate.Location = new System.Drawing.Point(52, 108);
            this.lblEDate.Name = "lblEDate";
            this.lblEDate.Size = new System.Drawing.Size(52, 13);
            this.lblEDate.TabIndex = 22;
            this.lblEDate.Text = "End Date";
            // 
            // txtOfficialName
            // 
            this.txtOfficialName.Location = new System.Drawing.Point(110, 41);
            this.txtOfficialName.Name = "txtOfficialName";
            this.txtOfficialName.Size = new System.Drawing.Size(455, 20);
            this.txtOfficialName.TabIndex = 25;
            // 
            // lblSDate
            // 
            this.lblSDate.AutoSize = true;
            this.lblSDate.Location = new System.Drawing.Point(49, 77);
            this.lblSDate.Name = "lblSDate";
            this.lblSDate.Size = new System.Drawing.Size(55, 13);
            this.lblSDate.TabIndex = 21;
            this.lblSDate.Text = "Start Date";
            // 
            // lblSName
            // 
            this.lblSName.AutoSize = true;
            this.lblSName.Location = new System.Drawing.Point(41, 12);
            this.lblSName.Name = "lblSName";
            this.lblSName.Size = new System.Drawing.Size(63, 13);
            this.lblSName.TabIndex = 19;
            this.lblSName.Text = "Code Name";
            // 
            // lblOfficalName
            // 
            this.lblOfficalName.AutoSize = true;
            this.lblOfficalName.Location = new System.Drawing.Point(34, 44);
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
            this.dgExperiments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgExperiments.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgExperiments.Location = new System.Drawing.Point(3, 3);
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
            this.dgExperiments.Size = new System.Drawing.Size(822, 670);
            this.dgExperiments.TabIndex = 18;
            this.dgExperiments.SelectionChanged += new System.EventHandler(this.dgExperiments_SelectionChanged);
            // 
            // ctlExperiments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(1538, 676);
            this.Name = "ctlExperiments";
            this.Size = new System.Drawing.Size(1538, 683);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.gbButtons.ResumeLayout(false);
            this.gbExperiment.ResumeLayout(false);
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgExperiments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox gbButtons;
        private System.Windows.Forms.Button btnPermissions;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.GroupBox gbExperiment;
        private System.Windows.Forms.ComboBox cbExperiments;
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
        private System.Windows.Forms.DataGridView dgExperiments;

    }
}
