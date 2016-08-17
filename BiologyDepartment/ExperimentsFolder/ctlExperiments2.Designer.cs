namespace BiologyDepartment.ExperimentsFolder
{
    partial class ctlExperiments2
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
            this.gpPanel = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.splitContainerAdv1 = new Syncfusion.Windows.Forms.Tools.SplitContainerAdv();
            this.lblExperimentID = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.lblEndDt = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.txtCodeName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.dtpEnd = new Syncfusion.Windows.Forms.Tools.DateTimePickerAdv();
            this.lblCodeName = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.lblStartDt = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.txtProjectName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.dtpStart = new Syncfusion.Windows.Forms.Tools.DateTimePickerAdv();
            this.lblProjectName = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.lblParent = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbParent = new Syncfusion.Windows.Forms.Tools.ComboBoxAutoComplete();
            this.txtScript = new ScintillaNET.Scintilla();
            this.ggcExperiments = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            ((System.ComponentModel.ISupportInitialize)(this.gpPanel)).BeginInit();
            this.gpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAdv1)).BeginInit();
            this.splitContainerAdv1.Panel1.SuspendLayout();
            this.splitContainerAdv1.Panel2.SuspendLayout();
            this.splitContainerAdv1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbParent.AutoCompleteControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ggcExperiments)).BeginInit();
            this.SuspendLayout();
            // 
            // gpPanel
            // 
            this.gpPanel.Controls.Add(this.splitContainerAdv1);
            this.gpPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.gpPanel.Location = new System.Drawing.Point(0, 0);
            this.gpPanel.Name = "gpPanel";
            this.gpPanel.Size = new System.Drawing.Size(547, 495);
            this.gpPanel.TabIndex = 0;
            // 
            // splitContainerAdv1
            // 
            this.splitContainerAdv1.BeforeTouchSize = 7;
            this.splitContainerAdv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerAdv1.FixedPanel = Syncfusion.Windows.Forms.Tools.Enums.FixedPanel.Panel1;
            this.splitContainerAdv1.IsSplitterFixed = true;
            this.splitContainerAdv1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerAdv1.Name = "splitContainerAdv1";
            this.splitContainerAdv1.Orientation = System.Windows.Forms.Orientation.Vertical;
            // 
            // splitContainerAdv1.Panel1
            // 
            this.splitContainerAdv1.Panel1.Controls.Add(this.lblExperimentID);
            this.splitContainerAdv1.Panel1.Controls.Add(this.lblEndDt);
            this.splitContainerAdv1.Panel1.Controls.Add(this.txtCodeName);
            this.splitContainerAdv1.Panel1.Controls.Add(this.dtpEnd);
            this.splitContainerAdv1.Panel1.Controls.Add(this.lblCodeName);
            this.splitContainerAdv1.Panel1.Controls.Add(this.lblStartDt);
            this.splitContainerAdv1.Panel1.Controls.Add(this.txtProjectName);
            this.splitContainerAdv1.Panel1.Controls.Add(this.dtpStart);
            this.splitContainerAdv1.Panel1.Controls.Add(this.lblProjectName);
            this.splitContainerAdv1.Panel1.Controls.Add(this.lblParent);
            this.splitContainerAdv1.Panel1.Controls.Add(this.cmbParent);
            // 
            // splitContainerAdv1.Panel2
            // 
            this.splitContainerAdv1.Panel2.Controls.Add(this.txtScript);
            this.splitContainerAdv1.Size = new System.Drawing.Size(543, 491);
            this.splitContainerAdv1.SplitterDistance = 239;
            this.splitContainerAdv1.TabIndex = 13;
            this.splitContainerAdv1.Text = "splitContainerAdv1";
            this.splitContainerAdv1.ThemesEnabled = true;
            // 
            // lblExperimentID
            // 
            this.lblExperimentID.Location = new System.Drawing.Point(10, 6);
            this.lblExperimentID.Name = "lblExperimentID";
            this.lblExperimentID.Size = new System.Drawing.Size(82, 13);
            this.lblExperimentID.TabIndex = 26;
            this.lblExperimentID.Text = "Experiment ID:  ";
            // 
            // lblEndDt
            // 
            this.lblEndDt.Location = new System.Drawing.Point(10, 199);
            this.lblEndDt.Name = "lblEndDt";
            this.lblEndDt.Size = new System.Drawing.Size(52, 13);
            this.lblEndDt.TabIndex = 32;
            this.lblEndDt.Text = "End Date";
            // 
            // txtCodeName
            // 
            this.txtCodeName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.txtCodeName.BeforeTouchSize = new System.Drawing.Size(291, 20);
            this.txtCodeName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(208)))), ((int)(((byte)(229)))));
            this.txtCodeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodeName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCodeName.Enabled = false;
            this.txtCodeName.Location = new System.Drawing.Point(10, 52);
            this.txtCodeName.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtCodeName.Name = "txtCodeName";
            this.txtCodeName.Size = new System.Drawing.Size(291, 20);
            this.txtCodeName.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2007;
            this.txtCodeName.TabIndex = 22;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.dtpEnd.BorderColor = System.Drawing.Color.Empty;
            this.dtpEnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dtpEnd.CalendarSize = new System.Drawing.Size(189, 176);
            this.dtpEnd.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(209)))), ((int)(((byte)(252)))));
            this.dtpEnd.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpEnd.DropDownImage = null;
            this.dtpEnd.DropDownNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(203)))), ((int)(((byte)(232)))));
            this.dtpEnd.Enabled = false;
            this.dtpEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(10, 215);
            this.dtpEnd.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.dtpEnd.MinValue = new System.DateTime(((long)(0)));
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(232, 20);
            this.dtpEnd.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.dtpEnd.TabIndex = 31;
            this.dtpEnd.Value = new System.DateTime(2016, 8, 14, 23, 54, 21, 663);
            // 
            // lblCodeName
            // 
            this.lblCodeName.Location = new System.Drawing.Point(10, 33);
            this.lblCodeName.Name = "lblCodeName";
            this.lblCodeName.Size = new System.Drawing.Size(63, 13);
            this.lblCodeName.TabIndex = 23;
            this.lblCodeName.Text = "Code Name";
            // 
            // lblStartDt
            // 
            this.lblStartDt.Location = new System.Drawing.Point(10, 157);
            this.lblStartDt.Name = "lblStartDt";
            this.lblStartDt.Size = new System.Drawing.Size(55, 13);
            this.lblStartDt.TabIndex = 30;
            this.lblStartDt.Text = "Start Date";
            // 
            // txtProjectName
            // 
            this.txtProjectName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.txtProjectName.BeforeTouchSize = new System.Drawing.Size(291, 20);
            this.txtProjectName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(208)))), ((int)(((byte)(229)))));
            this.txtProjectName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProjectName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProjectName.Enabled = false;
            this.txtProjectName.Location = new System.Drawing.Point(10, 94);
            this.txtProjectName.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(291, 20);
            this.txtProjectName.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2007;
            this.txtProjectName.TabIndex = 24;
            // 
            // dtpStart
            // 
            this.dtpStart.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.dtpStart.BorderColor = System.Drawing.Color.Empty;
            this.dtpStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dtpStart.CalendarSize = new System.Drawing.Size(189, 176);
            this.dtpStart.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(209)))), ((int)(((byte)(252)))));
            this.dtpStart.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpStart.DropDownImage = null;
            this.dtpStart.DropDownNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(203)))), ((int)(((byte)(232)))));
            this.dtpStart.Enabled = false;
            this.dtpStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(10, 173);
            this.dtpStart.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.dtpStart.MinValue = new System.DateTime(((long)(0)));
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(232, 20);
            this.dtpStart.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.dtpStart.TabIndex = 29;
            this.dtpStart.Value = new System.DateTime(2016, 8, 14, 23, 54, 21, 663);
            // 
            // lblProjectName
            // 
            this.lblProjectName.Location = new System.Drawing.Point(10, 75);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(71, 13);
            this.lblProjectName.TabIndex = 25;
            this.lblProjectName.Text = "Project Name";
            // 
            // lblParent
            // 
            this.lblParent.Location = new System.Drawing.Point(10, 117);
            this.lblParent.Name = "lblParent";
            this.lblParent.Size = new System.Drawing.Size(93, 13);
            this.lblParent.TabIndex = 28;
            this.lblParent.Text = "Parent Experiment";
            // 
            // cmbParent
            // 
            // 
            // 
            // 
            this.cmbParent.AutoCompleteControl.ChangeDataManagerPosition = true;
            this.cmbParent.AutoCompleteControl.HeaderFont = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.cmbParent.AutoCompleteControl.ItemFont = new System.Drawing.Font("Segoe UI", 8.25F);
            this.cmbParent.AutoCompleteControl.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(158)))), ((int)(((byte)(218)))));
            this.cmbParent.AutoCompleteControl.OverrideCombo = true;
            this.cmbParent.AutoCompleteControl.ParentForm = this.splitContainerAdv1.Panel1;
            this.cmbParent.AutoCompleteControl.Style = Syncfusion.Windows.Forms.Tools.AutoCompleteStyle.Default;
            this.cmbParent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParent.DropDownWidth = 121;
            this.cmbParent.Enabled = false;
            this.cmbParent.Location = new System.Drawing.Point(10, 133);
            this.cmbParent.Name = "cmbParent";
            this.cmbParent.ParentForm = this.splitContainerAdv1.Panel1;
            this.cmbParent.ReadOnly = true;
            this.cmbParent.Size = new System.Drawing.Size(291, 21);
            this.cmbParent.TabIndex = 27;
            this.cmbParent.VisualStyle = Syncfusion.Windows.Forms.Tools.ThemedComboBoxStyles.Office2007;
            // 
            // txtScript
            // 
            this.txtScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScript.Enabled = false;
            this.txtScript.Lexer = ScintillaNET.Lexer.Null;
            this.txtScript.Location = new System.Drawing.Point(0, 0);
            this.txtScript.Name = "txtScript";
            this.txtScript.Size = new System.Drawing.Size(543, 245);
            this.txtScript.TabIndex = 13;
            // 
            // ggcExperiments
            // 
            this.ggcExperiments.BackColor = System.Drawing.SystemColors.Window;
            this.ggcExperiments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ggcExperiments.Location = new System.Drawing.Point(547, 0);
            this.ggcExperiments.Name = "ggcExperiments";
            this.ggcExperiments.ShowRelationFields = Syncfusion.Grouping.ShowRelationFields.Hide;
            this.ggcExperiments.Size = new System.Drawing.Size(312, 495);
            this.ggcExperiments.TabIndex = 1;
            this.ggcExperiments.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
            this.ggcExperiments.Text = "gridGroupingControl1";
            this.ggcExperiments.VersionInfo = "14.2450.0.28";
            this.ggcExperiments.SelectedRecordsChanged += new Syncfusion.Grouping.SelectedRecordsChangedEventHandler(this.ggcExperiments_SelectedRecordsChanged);
            // 
            // ctlExperiments2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ggcExperiments);
            this.Controls.Add(this.gpPanel);
            this.Name = "ctlExperiments2";
            this.Size = new System.Drawing.Size(859, 495);
            ((System.ComponentModel.ISupportInitialize)(this.gpPanel)).EndInit();
            this.gpPanel.ResumeLayout(false);
            this.splitContainerAdv1.Panel1.ResumeLayout(false);
            this.splitContainerAdv1.Panel1.PerformLayout();
            this.splitContainerAdv1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAdv1)).EndInit();
            this.splitContainerAdv1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCodeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbParent.AutoCompleteControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ggcExperiments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.GradientPanel gpPanel;
        private Syncfusion.Windows.Forms.Tools.SplitContainerAdv splitContainerAdv1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblExperimentID;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblEndDt;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtCodeName;
        private Syncfusion.Windows.Forms.Tools.DateTimePickerAdv dtpEnd;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblCodeName;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblStartDt;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtProjectName;
        private Syncfusion.Windows.Forms.Tools.DateTimePickerAdv dtpStart;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblProjectName;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblParent;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAutoComplete cmbParent;
        private ScintillaNET.Scintilla txtScript;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl ggcExperiments;
    }
}
