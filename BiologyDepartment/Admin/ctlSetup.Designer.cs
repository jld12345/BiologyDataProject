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
            this.lblExperiment = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlShow1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pbShow = new System.Windows.Forms.PictureBox();
            this.pnlShow2 = new System.Windows.Forms.Panel();
            this.gbShowColumns = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dgColAdmin = new System.Windows.Forms.DataGridView();
            this.pnlImport1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pbImport = new System.Windows.Forms.PictureBox();
            this.pnlImport2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnImportCol = new System.Windows.Forms.Button();
            this.btnMapData = new System.Windows.Forms.Button();
            this.lblWorksheet = new System.Windows.Forms.Label();
            this.cmbWorksheets = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.dgExcelData = new System.Windows.Forms.DataGridView();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtExcelPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlShow1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbShow)).BeginInit();
            this.pnlShow2.SuspendLayout();
            this.gbShowColumns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgColAdmin)).BeginInit();
            this.pnlImport1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImport)).BeginInit();
            this.pnlImport2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            // lblExperiment
            // 
            this.lblExperiment.AutoSize = true;
            this.lblExperiment.Location = new System.Drawing.Point(5, 9);
            this.lblExperiment.Name = "lblExperiment";
            this.lblExperiment.Size = new System.Drawing.Size(68, 13);
            this.lblExperiment.TabIndex = 0;
            this.lblExperiment.Text = "Experiment:  ";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.pnlShow1);
            this.flowLayoutPanel1.Controls.Add(this.pnlShow2);
            this.flowLayoutPanel1.Controls.Add(this.pnlImport1);
            this.flowLayoutPanel1.Controls.Add(this.pnlImport2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(893, 606);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblExperiment);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(883, 26);
            this.panel1.TabIndex = 0;
            // 
            // pnlShow1
            // 
            this.pnlShow1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlShow1.Controls.Add(this.label1);
            this.pnlShow1.Controls.Add(this.pbShow);
            this.pnlShow1.Location = new System.Drawing.Point(3, 35);
            this.pnlShow1.Name = "pnlShow1";
            this.pnlShow1.Size = new System.Drawing.Size(883, 34);
            this.pnlShow1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Column Admin";
            // 
            // pbShow
            // 
            this.pbShow.Location = new System.Drawing.Point(8, 4);
            this.pbShow.Name = "pbShow";
            this.pbShow.Size = new System.Drawing.Size(34, 27);
            this.pbShow.TabIndex = 0;
            this.pbShow.TabStop = false;
            this.pbShow.Tag = "pbShow";
            this.pbShow.Click += new System.EventHandler(this.pbShow_Click);
            // 
            // pnlShow2
            // 
            this.pnlShow2.Controls.Add(this.gbShowColumns);
            this.pnlShow2.Location = new System.Drawing.Point(3, 75);
            this.pnlShow2.Name = "pnlShow2";
            this.pnlShow2.Size = new System.Drawing.Size(883, 297);
            this.pnlShow2.TabIndex = 2;
            // 
            // gbShowColumns
            // 
            this.gbShowColumns.Controls.Add(this.btnUpdate);
            this.gbShowColumns.Controls.Add(this.dgColAdmin);
            this.gbShowColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbShowColumns.Location = new System.Drawing.Point(0, 0);
            this.gbShowColumns.MaximumSize = new System.Drawing.Size(0, 495);
            this.gbShowColumns.Name = "gbShowColumns";
            this.gbShowColumns.Size = new System.Drawing.Size(883, 297);
            this.gbShowColumns.TabIndex = 5;
            this.gbShowColumns.TabStop = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(733, 20);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 39);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update Columns";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dgColAdmin
            // 
            this.dgColAdmin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgColAdmin.Location = new System.Drawing.Point(11, 20);
            this.dgColAdmin.Name = "dgColAdmin";
            this.dgColAdmin.Size = new System.Drawing.Size(704, 271);
            this.dgColAdmin.TabIndex = 0;
            this.dgColAdmin.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgColAdmin_CellClick);
            this.dgColAdmin.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgColAdmin_CellContentClick);
            this.dgColAdmin.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgColAdmin_RowsAdded);
            this.dgColAdmin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ctlSetup_KeyPress);
            // 
            // pnlImport1
            // 
            this.pnlImport1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlImport1.Controls.Add(this.label2);
            this.pnlImport1.Controls.Add(this.pbImport);
            this.pnlImport1.Location = new System.Drawing.Point(3, 378);
            this.pnlImport1.Name = "pnlImport1";
            this.pnlImport1.Size = new System.Drawing.Size(883, 34);
            this.pnlImport1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Import Data";
            // 
            // pbImport
            // 
            this.pbImport.Location = new System.Drawing.Point(8, 4);
            this.pbImport.Name = "pbImport";
            this.pbImport.Size = new System.Drawing.Size(34, 27);
            this.pbImport.TabIndex = 0;
            this.pbImport.TabStop = false;
            this.pbImport.Tag = "pbImport";
            this.pbImport.Click += new System.EventHandler(this.pbImport_Click);
            // 
            // pnlImport2
            // 
            this.pnlImport2.AutoScroll = true;
            this.pnlImport2.Controls.Add(this.groupBox1);
            this.pnlImport2.Location = new System.Drawing.Point(3, 418);
            this.pnlImport2.Name = "pnlImport2";
            this.pnlImport2.Size = new System.Drawing.Size(883, 403);
            this.pnlImport2.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnImportCol);
            this.groupBox1.Controls.Add(this.btnMapData);
            this.groupBox1.Controls.Add(this.lblWorksheet);
            this.groupBox1.Controls.Add(this.cmbWorksheets);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btnImport);
            this.groupBox1.Controls.Add(this.dgExcelData);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.txtExcelPath);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(883, 403);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnImportCol
            // 
            this.btnImportCol.Location = new System.Drawing.Point(535, 16);
            this.btnImportCol.Name = "btnImportCol";
            this.btnImportCol.Size = new System.Drawing.Size(75, 36);
            this.btnImportCol.TabIndex = 2;
            this.btnImportCol.Text = "Import Columns";
            this.btnImportCol.UseVisualStyleBackColor = true;
            this.btnImportCol.Click += new System.EventHandler(this.btnImportCol_Click);
            // 
            // btnMapData
            // 
            this.btnMapData.Location = new System.Drawing.Point(616, 16);
            this.btnMapData.Name = "btnMapData";
            this.btnMapData.Size = new System.Drawing.Size(75, 36);
            this.btnMapData.TabIndex = 16;
            this.btnMapData.Text = "Map Data";
            this.btnMapData.UseVisualStyleBackColor = true;
            // 
            // lblWorksheet
            // 
            this.lblWorksheet.AutoSize = true;
            this.lblWorksheet.Location = new System.Drawing.Point(8, 42);
            this.lblWorksheet.Name = "lblWorksheet";
            this.lblWorksheet.Size = new System.Drawing.Size(59, 13);
            this.lblWorksheet.TabIndex = 15;
            this.lblWorksheet.Text = "Worksheet";
            // 
            // cmbWorksheets
            // 
            this.cmbWorksheets.FormattingEnabled = true;
            this.cmbWorksheets.Location = new System.Drawing.Point(74, 39);
            this.cmbWorksheets.Name = "cmbWorksheets";
            this.cmbWorksheets.Size = new System.Drawing.Size(201, 21);
            this.cmbWorksheets.TabIndex = 14;
            this.cmbWorksheets.SelectedIndexChanged += new System.EventHandler(this.cmbWorksheets_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(779, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 36);
            this.button2.TabIndex = 13;
            this.button2.Text = "Clear Data";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(697, 16);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 36);
            this.btnImport.TabIndex = 12;
            this.btnImport.Text = "Import Data";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // dgExcelData
            // 
            this.dgExcelData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgExcelData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgExcelData.Location = new System.Drawing.Point(7, 68);
            this.dgExcelData.Name = "dgExcelData";
            this.dgExcelData.Size = new System.Drawing.Size(869, 371);
            this.dgExcelData.TabIndex = 11;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(282, 42);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(157, 17);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "First Row Contains Headers";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(282, 17);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(52, 20);
            this.btnBrowse.TabIndex = 9;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtExcelPath
            // 
            this.txtExcelPath.Location = new System.Drawing.Point(74, 17);
            this.txtExcelPath.Name = "txtExcelPath";
            this.txtExcelPath.Size = new System.Drawing.Size(201, 20);
            this.txtExcelPath.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Import File";
            // 
            // ctlSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ctlSetup";
            this.Size = new System.Drawing.Size(893, 606);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ctlSetup_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ctlSetup_KeyPress);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlShow1.ResumeLayout(false);
            this.pnlShow1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbShow)).EndInit();
            this.pnlShow2.ResumeLayout(false);
            this.gbShowColumns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgColAdmin)).EndInit();
            this.pnlImport1.ResumeLayout(false);
            this.pnlImport1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImport)).EndInit();
            this.pnlImport2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgExcelData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblExperiment;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlShow1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbShow;
        private System.Windows.Forms.Panel pnlShow2;
        private System.Windows.Forms.GroupBox gbShowColumns;
        private System.Windows.Forms.Panel pnlImport1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbImport;
        private System.Windows.Forms.Panel pnlImport2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.DataGridView dgExcelData;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtExcelPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblWorksheet;
        private System.Windows.Forms.ComboBox cmbWorksheets;
        private System.Windows.Forms.DataGridView dgColAdmin;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cbVisible;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnImportCol;
        private System.Windows.Forms.Button btnMapData;
    }
}
