namespace BiologyDepartment
{
    partial class ctlAnimalData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlAnimalData));
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.dgExData = new ADGV.AdvancedDataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.searchToolBar = new ADGV.SearchToolBar();
            this.tsButtonStrip = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.btnClearFilter = new System.Windows.Forms.ToolStripButton();
            this.btnClearSort = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgExData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tsButtonStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgExData
            // 
            this.dgExData.AllowUserToOrderColumns = true;
            this.dgExData.AutoGenerateContextFilters = true;
            this.dgExData.CausesValidation = false;
            this.dgExData.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgExData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgExData.DateWithTime = false;
            this.dgExData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgExData.Location = new System.Drawing.Point(0, 0);
            this.dgExData.Name = "dgExData";
            this.dgExData.ReadOnly = true;
            this.dgExData.Size = new System.Drawing.Size(1394, 598);
            this.dgExData.TabIndex = 26;
            this.dgExData.TimeFilter = false;
            this.dgExData.SortStringChanged += new System.EventHandler(this.dataGridView_SortStringChanged);
            this.dgExData.FilterStringChanged += new System.EventHandler(this.dataGridView_FilterStringChanged);
            this.dgExData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgExData_CellClick);
            this.dgExData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgExData_CellContentClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.searchToolBar);
            this.splitContainer1.Panel1.Controls.Add(this.tsButtonStrip);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.dgExData);
            this.splitContainer1.Size = new System.Drawing.Size(1394, 674);
            this.splitContainer1.SplitterDistance = 72;
            this.splitContainer1.TabIndex = 39;
            // 
            // searchToolBar
            // 
            this.searchToolBar.AllowMerge = false;
            this.searchToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.searchToolBar.Location = new System.Drawing.Point(0, 27);
            this.searchToolBar.MaximumSize = new System.Drawing.Size(0, 27);
            this.searchToolBar.MinimumSize = new System.Drawing.Size(0, 27);
            this.searchToolBar.Name = "searchToolBar";
            this.searchToolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.searchToolBar.Size = new System.Drawing.Size(1394, 27);
            this.searchToolBar.TabIndex = 1;
            this.searchToolBar.Search += new ADGV.SearchToolBarSearchEventHandler(this.searchToolBar_Search);
            // 
            // tsButtonStrip
            // 
            this.tsButtonStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnExport,
            this.btnSearch,
            this.btnClearFilter,
            this.btnClearSort,
            this.btnSave});
            this.tsButtonStrip.Location = new System.Drawing.Point(0, 0);
            this.tsButtonStrip.Name = "tsButtonStrip";
            this.tsButtonStrip.Padding = new System.Windows.Forms.Padding(0, 0, 1, 5);
            this.tsButtonStrip.Size = new System.Drawing.Size(1394, 27);
            this.tsButtonStrip.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(59, 19);
            this.btnAdd.Text = "Add Row";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnExport
            // 
            this.btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(44, 19);
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click_1);
            // 
            // btnSearch
            // 
            this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(46, 19);
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnClearFilter.Image = ((System.Drawing.Image)(resources.GetObject("btnClearFilter.Image")));
            this.btnClearFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(72, 19);
            this.btnClearFilter.Text = "Clear Filters";
            this.btnClearFilter.Click += new System.EventHandler(this.clearFilterButton_Click);
            // 
            // btnClearSort
            // 
            this.btnClearSort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnClearSort.Image = ((System.Drawing.Image)(resources.GetObject("btnClearSort.Image")));
            this.btnClearSort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClearSort.Name = "btnClearSort";
            this.btnClearSort.Size = new System.Drawing.Size(62, 19);
            this.btnClearSort.Text = "Clear Sort";
            this.btnClearSort.Click += new System.EventHandler(this.clearSortButton_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 19);
            this.btnSave.Text = "Save Changes";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Column Name";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Start Value";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 125;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "End Value";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 125;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // ctlAnimalData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CausesValidation = false;
            this.Controls.Add(this.splitContainer1);
            this.MaximumSize = new System.Drawing.Size(1500, 680);
            this.MinimumSize = new System.Drawing.Size(1400, 680);
            this.Name = "ctlAnimalData";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(1400, 680);
            ((System.ComponentModel.ISupportInitialize)(this.dgExData)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tsButtonStrip.ResumeLayout(false);
            this.tsButtonStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private ADGV.AdvancedDataGridView dgExData;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ADGV.SearchToolBar searchToolBar;
        private System.Windows.Forms.ToolStrip tsButtonStrip;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripButton btnClearFilter;
        private System.Windows.Forms.ToolStripButton btnClearSort;
        private System.Windows.Forms.ToolStripButton btnSave;
    }
}
