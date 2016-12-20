namespace BiologyDepartment.R_Scripts
{
    partial class ctlApiCalls2
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgRScripts = new Syncfusion.Windows.Forms.Grid.GridDataBoundGrid();
            this.tcScriptInput = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            this.tpInput = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDependent = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label1 = new System.Windows.Forms.Label();
            this.tpAxisSetup = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.tpTitle = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.tpLegend = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.tpTheme = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.tcRScripts = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            this.tpConsole = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.clbIndependent = new System.Windows.Forms.CheckedListBox();
            this.clbFactor = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRScripts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcScriptInput)).BeginInit();
            this.tcScriptInput.SuspendLayout();
            this.tpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDependent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcRScripts)).BeginInit();
            this.tcRScripts.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tcRScripts);
            this.splitContainer1.Size = new System.Drawing.Size(987, 640);
            this.splitContainer1.SplitterDistance = 462;
            this.splitContainer1.TabIndex = 0;
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
            this.splitContainer2.Panel1.Controls.Add(this.dgRScripts);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tcScriptInput);
            this.splitContainer2.Size = new System.Drawing.Size(462, 640);
            this.splitContainer2.SplitterDistance = 296;
            this.splitContainer2.TabIndex = 0;
            // 
            // dgRScripts
            // 
            this.dgRScripts.AllowDragSelectedCols = true;
            this.dgRScripts.AllowResizeToFit = false;
            this.dgRScripts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgRScripts.EnableAddNew = false;
            this.dgRScripts.EnableEdit = false;
            this.dgRScripts.EnableRemove = false;
            this.dgRScripts.Location = new System.Drawing.Point(0, 0);
            this.dgRScripts.Name = "dgRScripts";
            this.dgRScripts.OptimizeInsertRemoveCells = true;
            this.dgRScripts.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.dgRScripts.Size = new System.Drawing.Size(462, 296);
            this.dgRScripts.SmartSizeBox = false;
            this.dgRScripts.SortBehavior = Syncfusion.Windows.Forms.Grid.GridSortBehavior.DoubleClick;
            this.dgRScripts.TabIndex = 0;
            this.dgRScripts.UnHideColsOnDblClick = false;
            this.dgRScripts.UseListChangedEvent = true;
            this.dgRScripts.UseRightToLeftCompatibleTextBox = true;
            this.dgRScripts.CellButtonClicked += new Syncfusion.Windows.Forms.Grid.GridCellButtonClickedEventHandler(this.dgRScripts_CellButtonClicked);
            this.dgRScripts.Layout += new System.Windows.Forms.LayoutEventHandler(this.dgRScripts_Layout);
            // 
            // tcScriptInput
            // 
            this.tcScriptInput.BeforeTouchSize = new System.Drawing.Size(462, 340);
            this.tcScriptInput.CloseButtonForeColor = System.Drawing.Color.Empty;
            this.tcScriptInput.CloseButtonHoverForeColor = System.Drawing.Color.Empty;
            this.tcScriptInput.CloseButtonPressedForeColor = System.Drawing.Color.Empty;
            this.tcScriptInput.Controls.Add(this.tpInput);
            this.tcScriptInput.Controls.Add(this.tpAxisSetup);
            this.tcScriptInput.Controls.Add(this.tpTitle);
            this.tcScriptInput.Controls.Add(this.tpLegend);
            this.tcScriptInput.Controls.Add(this.tpTheme);
            this.tcScriptInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcScriptInput.Location = new System.Drawing.Point(0, 0);
            this.tcScriptInput.Name = "tcScriptInput";
            this.tcScriptInput.Size = new System.Drawing.Size(462, 340);
            this.tcScriptInput.TabIndex = 0;
            // 
            // tpInput
            // 
            this.tpInput.Controls.Add(this.clbFactor);
            this.tpInput.Controls.Add(this.clbIndependent);
            this.tpInput.Controls.Add(this.label3);
            this.tpInput.Controls.Add(this.label2);
            this.tpInput.Controls.Add(this.cmbDependent);
            this.tpInput.Controls.Add(this.label1);
            this.tpInput.Image = null;
            this.tpInput.ImageSize = new System.Drawing.Size(16, 16);
            this.tpInput.Location = new System.Drawing.Point(1, 25);
            this.tpInput.Name = "tpInput";
            this.tpInput.ShowCloseButton = true;
            this.tpInput.Size = new System.Drawing.Size(459, 313);
            this.tpInput.TabIndex = 1;
            this.tpInput.Text = "Input Variables";
            this.tpInput.ThemesEnabled = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(256, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Factor Variables";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Independent Variables";
            // 
            // cmbDependent
            // 
            this.cmbDependent.BeforeTouchSize = new System.Drawing.Size(246, 21);
            this.cmbDependent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDependent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDependent.Location = new System.Drawing.Point(7, 20);
            this.cmbDependent.Name = "cmbDependent";
            this.cmbDependent.Size = new System.Drawing.Size(246, 21);
            this.cmbDependent.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dependent Variable";
            // 
            // tpAxisSetup
            // 
            this.tpAxisSetup.Image = null;
            this.tpAxisSetup.ImageSize = new System.Drawing.Size(16, 16);
            this.tpAxisSetup.Location = new System.Drawing.Point(1, 25);
            this.tpAxisSetup.Name = "tpAxisSetup";
            this.tpAxisSetup.ShowCloseButton = true;
            this.tpAxisSetup.Size = new System.Drawing.Size(459, 313);
            this.tpAxisSetup.TabIndex = 2;
            this.tpAxisSetup.Text = "Axis Setup";
            this.tpAxisSetup.ThemesEnabled = false;
            // 
            // tpTitle
            // 
            this.tpTitle.Image = null;
            this.tpTitle.ImageSize = new System.Drawing.Size(16, 16);
            this.tpTitle.Location = new System.Drawing.Point(1, 25);
            this.tpTitle.Name = "tpTitle";
            this.tpTitle.ShowCloseButton = true;
            this.tpTitle.Size = new System.Drawing.Size(459, 313);
            this.tpTitle.TabIndex = 3;
            this.tpTitle.Text = "Title Setup";
            this.tpTitle.ThemesEnabled = false;
            // 
            // tpLegend
            // 
            this.tpLegend.Image = null;
            this.tpLegend.ImageSize = new System.Drawing.Size(16, 16);
            this.tpLegend.Location = new System.Drawing.Point(1, 25);
            this.tpLegend.Name = "tpLegend";
            this.tpLegend.ShowCloseButton = true;
            this.tpLegend.Size = new System.Drawing.Size(459, 313);
            this.tpLegend.TabIndex = 4;
            this.tpLegend.Text = "Legend Setup";
            this.tpLegend.ThemesEnabled = false;
            // 
            // tpTheme
            // 
            this.tpTheme.Image = null;
            this.tpTheme.ImageSize = new System.Drawing.Size(16, 16);
            this.tpTheme.Location = new System.Drawing.Point(1, 25);
            this.tpTheme.Name = "tpTheme";
            this.tpTheme.ShowCloseButton = true;
            this.tpTheme.Size = new System.Drawing.Size(459, 313);
            this.tpTheme.TabIndex = 5;
            this.tpTheme.Text = "Theme Setup";
            this.tpTheme.ThemesEnabled = false;
            // 
            // tcRScripts
            // 
            this.tcRScripts.BeforeTouchSize = new System.Drawing.Size(521, 640);
            this.tcRScripts.CloseButtonForeColor = System.Drawing.Color.Empty;
            this.tcRScripts.CloseButtonHoverForeColor = System.Drawing.Color.Empty;
            this.tcRScripts.CloseButtonPressedForeColor = System.Drawing.Color.Empty;
            this.tcRScripts.Controls.Add(this.tpConsole);
            this.tcRScripts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcRScripts.Location = new System.Drawing.Point(0, 0);
            this.tcRScripts.Name = "tcRScripts";
            this.tcRScripts.Size = new System.Drawing.Size(521, 640);
            this.tcRScripts.TabIndex = 0;
            // 
            // tpConsole
            // 
            this.tpConsole.Image = null;
            this.tpConsole.ImageSize = new System.Drawing.Size(16, 16);
            this.tpConsole.Location = new System.Drawing.Point(1, 25);
            this.tpConsole.Name = "tpConsole";
            this.tpConsole.ShowCloseButton = true;
            this.tpConsole.Size = new System.Drawing.Size(518, 613);
            this.tpConsole.TabIndex = 1;
            this.tpConsole.Tag = "Console";
            this.tpConsole.Text = "Console Output";
            this.tpConsole.ThemesEnabled = false;
            // 
            // clbIndependent
            // 
            this.clbIndependent.FormattingEnabled = true;
            this.clbIndependent.Location = new System.Drawing.Point(7, 60);
            this.clbIndependent.Name = "clbIndependent";
            this.clbIndependent.Size = new System.Drawing.Size(246, 244);
            this.clbIndependent.TabIndex = 6;
            // 
            // clbFactor
            // 
            this.clbFactor.FormattingEnabled = true;
            this.clbFactor.Location = new System.Drawing.Point(259, 60);
            this.clbFactor.Name = "clbFactor";
            this.clbFactor.Size = new System.Drawing.Size(246, 244);
            this.clbFactor.TabIndex = 7;
            // 
            // ctlApiCalls2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ctlApiCalls2";
            this.Size = new System.Drawing.Size(987, 640);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRScripts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcScriptInput)).EndInit();
            this.tcScriptInput.ResumeLayout(false);
            this.tpInput.ResumeLayout(false);
            this.tpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDependent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcRScripts)).EndInit();
            this.tcRScripts.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Syncfusion.Windows.Forms.Tools.TabControlAdv tcScriptInput;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tpInput;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tpAxisSetup;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tpTitle;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tpLegend;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tpTheme;
        private Syncfusion.Windows.Forms.Tools.TabControlAdv tcRScripts;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tpConsole;
        private Syncfusion.Windows.Forms.Grid.GridDataBoundGrid dgRScripts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbDependent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox clbFactor;
        private System.Windows.Forms.CheckedListBox clbIndependent;
    }
}
