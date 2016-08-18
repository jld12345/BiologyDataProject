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
            this.tvExperiments = new Syncfusion.Windows.Forms.Tools.TreeViewAdv();
            this.txtScript = new ScintillaNET.Scintilla();
            this.gpDataPanel = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            ((System.ComponentModel.ISupportInitialize)(this.gpPanel)).BeginInit();
            this.gpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAdv1)).BeginInit();
            this.splitContainerAdv1.Panel1.SuspendLayout();
            this.splitContainerAdv1.Panel2.SuspendLayout();
            this.splitContainerAdv1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tvExperiments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpDataPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // gpPanel
            // 
            this.gpPanel.Controls.Add(this.splitContainerAdv1);
            this.gpPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.gpPanel.Location = new System.Drawing.Point(0, 0);
            this.gpPanel.Name = "gpPanel";
            this.gpPanel.Size = new System.Drawing.Size(341, 705);
            this.gpPanel.TabIndex = 0;
            // 
            // splitContainerAdv1
            // 
            this.splitContainerAdv1.BeforeTouchSize = 7;
            this.splitContainerAdv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerAdv1.IsSplitterFixed = true;
            this.splitContainerAdv1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerAdv1.Name = "splitContainerAdv1";
            this.splitContainerAdv1.Orientation = System.Windows.Forms.Orientation.Vertical;
            // 
            // splitContainerAdv1.Panel1
            // 
            this.splitContainerAdv1.Panel1.Controls.Add(this.tvExperiments);
            // 
            // splitContainerAdv1.Panel2
            // 
            this.splitContainerAdv1.Panel2.Controls.Add(this.txtScript);
            this.splitContainerAdv1.Size = new System.Drawing.Size(337, 701);
            this.splitContainerAdv1.SplitterDistance = 436;
            this.splitContainerAdv1.TabIndex = 13;
            this.splitContainerAdv1.Text = "splitContainerAdv1";
            this.splitContainerAdv1.ThemesEnabled = true;
            // 
            // tvExperiments
            // 
            this.tvExperiments.BeforeTouchSize = new System.Drawing.Size(337, 436);
            this.tvExperiments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvExperiments.FullRowSelect = true;
            // 
            // 
            // 
            this.tvExperiments.HelpTextControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvExperiments.HelpTextControl.Location = new System.Drawing.Point(0, 0);
            this.tvExperiments.HelpTextControl.Name = "helpText";
            this.tvExperiments.HelpTextControl.Size = new System.Drawing.Size(49, 15);
            this.tvExperiments.HelpTextControl.TabIndex = 0;
            this.tvExperiments.HelpTextControl.Text = "help text";
            this.tvExperiments.HideSelection = false;
            this.tvExperiments.HotTracking = true;
            this.tvExperiments.InactiveSelectedNodeForeColor = System.Drawing.SystemColors.ControlText;
            this.tvExperiments.Location = new System.Drawing.Point(0, 0);
            this.tvExperiments.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.tvExperiments.Name = "tvExperiments";
            this.tvExperiments.SelectedNodeForeColor = System.Drawing.SystemColors.HighlightText;
            this.tvExperiments.Size = new System.Drawing.Size(337, 436);
            this.tvExperiments.TabIndex = 34;
            this.tvExperiments.Text = "treeViewAdv1";
            // 
            // 
            // 
            this.tvExperiments.ToolTipControl.BackColor = System.Drawing.SystemColors.Info;
            this.tvExperiments.ToolTipControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvExperiments.ToolTipControl.Location = new System.Drawing.Point(0, 0);
            this.tvExperiments.ToolTipControl.Name = "toolTip";
            this.tvExperiments.ToolTipControl.Size = new System.Drawing.Size(41, 15);
            this.tvExperiments.ToolTipControl.TabIndex = 1;
            this.tvExperiments.ToolTipControl.Text = "toolTip";
            this.tvExperiments.AfterSelect += new System.EventHandler(this.tvExperiments_AfterSelect);
            // 
            // txtScript
            // 
            this.txtScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScript.Enabled = false;
            this.txtScript.Lexer = ScintillaNET.Lexer.Null;
            this.txtScript.Location = new System.Drawing.Point(0, 0);
            this.txtScript.Name = "txtScript";
            this.txtScript.Size = new System.Drawing.Size(337, 258);
            this.txtScript.TabIndex = 13;
            // 
            // gpDataPanel
            // 
            this.gpDataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpDataPanel.Location = new System.Drawing.Point(341, 0);
            this.gpDataPanel.Name = "gpDataPanel";
            this.gpDataPanel.Size = new System.Drawing.Size(518, 705);
            this.gpDataPanel.TabIndex = 1;
            // 
            // ctlExperiments2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gpDataPanel);
            this.Controls.Add(this.gpPanel);
            this.Name = "ctlExperiments2";
            this.Size = new System.Drawing.Size(859, 705);
            ((System.ComponentModel.ISupportInitialize)(this.gpPanel)).EndInit();
            this.gpPanel.ResumeLayout(false);
            this.splitContainerAdv1.Panel1.ResumeLayout(false);
            this.splitContainerAdv1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAdv1)).EndInit();
            this.splitContainerAdv1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tvExperiments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpDataPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.GradientPanel gpPanel;
        private Syncfusion.Windows.Forms.Tools.SplitContainerAdv splitContainerAdv1;
        private ScintillaNET.Scintilla txtScript;
        private Syncfusion.Windows.Forms.Tools.TreeViewAdv tvExperiments;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gpDataPanel;
    }
}
