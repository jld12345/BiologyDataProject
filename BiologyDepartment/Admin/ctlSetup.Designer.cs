namespace BiologyDepartment
{
    partial class ctlSetup
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlSetup));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gbShowColumns = new System.Windows.Forms.GroupBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.btnAddCol = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnDelCol = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnRefresh2 = new Syncfusion.Windows.Forms.ButtonAdv();
            this.dgColAdmin = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnImportColumns = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnMapData2 = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnImportData = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnClearData = new Syncfusion.Windows.Forms.ButtonAdv();
            this.lblWorksheet = new System.Windows.Forms.Label();
            this.cmbWorksheets = new System.Windows.Forms.ComboBox();
            this.cbHasHeaders = new System.Windows.Forms.CheckBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtExcelPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgExcelData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.gbShowColumns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgColAdmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgExcelData)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "down.png");
            this.imageList1.Images.SetKeyName(1, "up.png");
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
            this.splitContainer2.Panel1.Controls.Add(this.gbShowColumns);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(1030, 606);
            this.splitContainer2.SplitterDistance = 303;
            this.splitContainer2.TabIndex = 6;
            // 
            // gbShowColumns
            // 
            this.gbShowColumns.Controls.Add(this.splitContainer3);
            this.gbShowColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbShowColumns.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbShowColumns.Location = new System.Drawing.Point(0, 0);
            this.gbShowColumns.MaximumSize = new System.Drawing.Size(0, 495);
            this.gbShowColumns.Name = "gbShowColumns";
            this.gbShowColumns.Size = new System.Drawing.Size(1030, 303);
            this.gbShowColumns.TabIndex = 6;
            this.gbShowColumns.TabStop = false;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 16);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.btnAddCol);
            this.splitContainer3.Panel1.Controls.Add(this.btnDelCol);
            this.splitContainer3.Panel1.Controls.Add(this.btnRefresh2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dgColAdmin);
            this.splitContainer3.Size = new System.Drawing.Size(1024, 284);
            this.splitContainer3.SplitterDistance = 47;
            this.splitContainer3.TabIndex = 4;
            // 
            // btnAddCol
            // 
            this.btnAddCol.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.btnAddCol.BeforeTouchSize = new System.Drawing.Size(100, 47);
            this.btnAddCol.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAddCol.IsBackStageButton = false;
            this.btnAddCol.Location = new System.Drawing.Point(724, 0);
            this.btnAddCol.Name = "btnAddCol";
            this.btnAddCol.Size = new System.Drawing.Size(100, 47);
            this.btnAddCol.TabIndex = 6;
            this.btnAddCol.Text = "Add/Update Column";
            this.btnAddCol.UseVisualStyle = true;
            this.btnAddCol.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelCol
            // 
            this.btnDelCol.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.btnDelCol.BeforeTouchSize = new System.Drawing.Size(100, 47);
            this.btnDelCol.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelCol.IsBackStageButton = false;
            this.btnDelCol.Location = new System.Drawing.Point(824, 0);
            this.btnDelCol.Name = "btnDelCol";
            this.btnDelCol.Size = new System.Drawing.Size(100, 47);
            this.btnDelCol.TabIndex = 5;
            this.btnDelCol.Text = "Delete Columns";
            this.btnDelCol.UseVisualStyle = true;
            this.btnDelCol.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh2
            // 
            this.btnRefresh2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.btnRefresh2.BeforeTouchSize = new System.Drawing.Size(100, 47);
            this.btnRefresh2.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRefresh2.IsBackStageButton = false;
            this.btnRefresh2.Location = new System.Drawing.Point(924, 0);
            this.btnRefresh2.Name = "btnRefresh2";
            this.btnRefresh2.Size = new System.Drawing.Size(100, 47);
            this.btnRefresh2.TabIndex = 4;
            this.btnRefresh2.Text = "Refresh Grid";
            this.btnRefresh2.UseVisualStyle = true;
            this.btnRefresh2.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgColAdmin
            // 
            this.dgColAdmin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgColAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgColAdmin.Location = new System.Drawing.Point(0, 0);
            this.dgColAdmin.Name = "dgColAdmin";
            this.dgColAdmin.Size = new System.Drawing.Size(1024, 233);
            this.dgColAdmin.TabIndex = 0;
            this.dgColAdmin.Layout += new System.Windows.Forms.LayoutEventHandler(this.dgColAdmin_Layout);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.dgExcelData);
            this.splitContainer1.Size = new System.Drawing.Size(1030, 299);
            this.splitContainer1.SplitterDistance = 64;
            this.splitContainer1.TabIndex = 19;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnImportColumns);
            this.groupBox2.Controls.Add(this.btnMapData2);
            this.groupBox2.Controls.Add(this.btnImportData);
            this.groupBox2.Controls.Add(this.btnClearData);
            this.groupBox2.Controls.Add(this.lblWorksheet);
            this.groupBox2.Controls.Add(this.cmbWorksheets);
            this.groupBox2.Controls.Add(this.cbHasHeaders);
            this.groupBox2.Controls.Add(this.btnBrowse);
            this.groupBox2.Controls.Add(this.txtExcelPath);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1030, 64);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            // 
            // btnImportColumns
            // 
            this.btnImportColumns.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.btnImportColumns.BeforeTouchSize = new System.Drawing.Size(100, 45);
            this.btnImportColumns.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnImportColumns.IsBackStageButton = false;
            this.btnImportColumns.Location = new System.Drawing.Point(627, 16);
            this.btnImportColumns.Name = "btnImportColumns";
            this.btnImportColumns.Size = new System.Drawing.Size(100, 45);
            this.btnImportColumns.TabIndex = 20;
            this.btnImportColumns.Text = "Import Columns";
            this.btnImportColumns.UseVisualStyle = true;
            this.btnImportColumns.Click += new System.EventHandler(this.btnImportCol_Click);
            // 
            // btnMapData2
            // 
            this.btnMapData2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.btnMapData2.BeforeTouchSize = new System.Drawing.Size(100, 45);
            this.btnMapData2.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMapData2.IsBackStageButton = false;
            this.btnMapData2.Location = new System.Drawing.Point(727, 16);
            this.btnMapData2.Name = "btnMapData2";
            this.btnMapData2.Size = new System.Drawing.Size(100, 45);
            this.btnMapData2.TabIndex = 19;
            this.btnMapData2.Text = "Map Data";
            this.btnMapData2.UseVisualStyle = true;
            this.btnMapData2.Click += new System.EventHandler(this.btnMapData_Click);
            // 
            // btnImportData
            // 
            this.btnImportData.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.btnImportData.BeforeTouchSize = new System.Drawing.Size(100, 45);
            this.btnImportData.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnImportData.IsBackStageButton = false;
            this.btnImportData.Location = new System.Drawing.Point(827, 16);
            this.btnImportData.Name = "btnImportData";
            this.btnImportData.Size = new System.Drawing.Size(100, 45);
            this.btnImportData.TabIndex = 18;
            this.btnImportData.Text = "Import Data";
            this.btnImportData.UseVisualStyle = true;
            this.btnImportData.Click += new System.EventHandler(this.btnImport_Click_1);
            // 
            // btnClearData
            // 
            this.btnClearData.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.btnClearData.BeforeTouchSize = new System.Drawing.Size(100, 45);
            this.btnClearData.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClearData.IsBackStageButton = false;
            this.btnClearData.Location = new System.Drawing.Point(927, 16);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(100, 45);
            this.btnClearData.TabIndex = 17;
            this.btnClearData.Text = "Clear Data";
            this.btnClearData.UseVisualStyle = true;
            this.btnClearData.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblWorksheet
            // 
            this.lblWorksheet.AutoSize = true;
            this.lblWorksheet.Location = new System.Drawing.Point(3, 38);
            this.lblWorksheet.Name = "lblWorksheet";
            this.lblWorksheet.Size = new System.Drawing.Size(59, 13);
            this.lblWorksheet.TabIndex = 15;
            this.lblWorksheet.Text = "Worksheet";
            // 
            // cmbWorksheets
            // 
            this.cmbWorksheets.FormattingEnabled = true;
            this.cmbWorksheets.Location = new System.Drawing.Point(69, 35);
            this.cmbWorksheets.Name = "cmbWorksheets";
            this.cmbWorksheets.Size = new System.Drawing.Size(201, 21);
            this.cmbWorksheets.TabIndex = 14;
            this.cmbWorksheets.SelectedIndexChanged += new System.EventHandler(this.cmbWorksheets_SelectedIndexChanged);
            // 
            // cbHasHeaders
            // 
            this.cbHasHeaders.AutoSize = true;
            this.cbHasHeaders.Checked = true;
            this.cbHasHeaders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHasHeaders.Location = new System.Drawing.Point(277, 37);
            this.cbHasHeaders.Name = "cbHasHeaders";
            this.cbHasHeaders.Size = new System.Drawing.Size(157, 17);
            this.cbHasHeaders.TabIndex = 10;
            this.cbHasHeaders.Text = "First Row Contains Headers";
            this.cbHasHeaders.UseVisualStyleBackColor = true;
            this.cbHasHeaders.CheckedChanged += new System.EventHandler(this.cbHasHeaders_CheckedChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(277, 13);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(52, 20);
            this.btnBrowse.TabIndex = 9;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtExcelPath
            // 
            this.txtExcelPath.Location = new System.Drawing.Point(69, 13);
            this.txtExcelPath.Name = "txtExcelPath";
            this.txtExcelPath.Size = new System.Drawing.Size(201, 20);
            this.txtExcelPath.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Import File";
            // 
            // dgExcelData
            // 
            this.dgExcelData.AllowUserToAddRows = false;
            this.dgExcelData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgExcelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgExcelData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgExcelData.Location = new System.Drawing.Point(0, 0);
            this.dgExcelData.Name = "dgExcelData";
            this.dgExcelData.Size = new System.Drawing.Size(1030, 231);
            this.dgExcelData.TabIndex = 12;
            // 
            // ctlSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer2);
            this.Name = "ctlSetup";
            this.Size = new System.Drawing.Size(1030, 606);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ctlSetup_KeyPress);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.gbShowColumns.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgColAdmin)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgExcelData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cbVisible;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox gbShowColumns;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private Syncfusion.Windows.Forms.ButtonAdv btnAddCol;
        private Syncfusion.Windows.Forms.ButtonAdv btnDelCol;
        private Syncfusion.Windows.Forms.ButtonAdv btnRefresh2;
        private System.Windows.Forms.DataGridView dgColAdmin;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Syncfusion.Windows.Forms.ButtonAdv btnImportColumns;
        private Syncfusion.Windows.Forms.ButtonAdv btnMapData2;
        private Syncfusion.Windows.Forms.ButtonAdv btnImportData;
        private Syncfusion.Windows.Forms.ButtonAdv btnClearData;
        private System.Windows.Forms.Label lblWorksheet;
        private System.Windows.Forms.ComboBox cmbWorksheets;
        private System.Windows.Forms.CheckBox cbHasHeaders;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtExcelPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgExcelData;
    }
}
