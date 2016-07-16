namespace BiologyDepartment
{
    partial class ctlRScripts
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabLatticeExtra = new System.Windows.Forms.TabPage();
            this.cblLatticeExtra = new System.Windows.Forms.CheckedListBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClipBoard = new System.Windows.Forms.Button();
            this.btnSetScript = new System.Windows.Forms.Button();
            this.rtbRScript = new System.Windows.Forms.RichTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabGGPlot = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabLatticeExtra.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel1.Controls.Add(this.btnRefresh);
            this.splitContainer1.Panel1.Controls.Add(this.btnClipBoard);
            this.splitContainer1.Panel1.Controls.Add(this.btnSetScript);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rtbRScript);
            this.splitContainer1.Size = new System.Drawing.Size(1230, 608);
            this.splitContainer1.SplitterDistance = 593;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGGPlot);
            this.tabControl1.Controls.Add(this.tabLatticeExtra);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(15, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(573, 545);
            this.tabControl1.TabIndex = 23;
            // 
            // tabLatticeExtra
            // 
            this.tabLatticeExtra.Controls.Add(this.cblLatticeExtra);
            this.tabLatticeExtra.Location = new System.Drawing.Point(4, 22);
            this.tabLatticeExtra.Name = "tabLatticeExtra";
            this.tabLatticeExtra.Padding = new System.Windows.Forms.Padding(3);
            this.tabLatticeExtra.Size = new System.Drawing.Size(411, 209);
            this.tabLatticeExtra.TabIndex = 1;
            this.tabLatticeExtra.Text = "LatticeExtra";
            this.tabLatticeExtra.UseVisualStyleBackColor = true;
            // 
            // cblLatticeExtra
            // 
            this.cblLatticeExtra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cblLatticeExtra.FormattingEnabled = true;
            this.cblLatticeExtra.Location = new System.Drawing.Point(3, 3);
            this.cblLatticeExtra.Name = "cblLatticeExtra";
            this.cblLatticeExtra.Size = new System.Drawing.Size(405, 203);
            this.cblLatticeExtra.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(411, 209);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Basic Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(128, 555);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(98, 40);
            this.btnRefresh.TabIndex = 22;
            this.btnRefresh.Text = "REFRESH FORM";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnClipBoard
            // 
            this.btnClipBoard.Location = new System.Drawing.Point(232, 555);
            this.btnClipBoard.Name = "btnClipBoard";
            this.btnClipBoard.Size = new System.Drawing.Size(98, 40);
            this.btnClipBoard.TabIndex = 11;
            this.btnClipBoard.Text = "COPY TO CLIPBOARD";
            this.btnClipBoard.UseVisualStyleBackColor = true;
            this.btnClipBoard.Click += new System.EventHandler(this.btnClipBoard_Click);
            // 
            // btnSetScript
            // 
            this.btnSetScript.Location = new System.Drawing.Point(336, 555);
            this.btnSetScript.Name = "btnSetScript";
            this.btnSetScript.Size = new System.Drawing.Size(98, 40);
            this.btnSetScript.TabIndex = 10;
            this.btnSetScript.Text = "SET SCRIPT";
            this.btnSetScript.UseVisualStyleBackColor = true;
            this.btnSetScript.Click += new System.EventHandler(this.btnSetScript_Click);
            // 
            // rtbRScript
            // 
            this.rtbRScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbRScript.Location = new System.Drawing.Point(0, 0);
            this.rtbRScript.Name = "rtbRScript";
            this.rtbRScript.Size = new System.Drawing.Size(633, 608);
            this.rtbRScript.TabIndex = 0;
            this.rtbRScript.Text = "";
            // 
            // tabGGPlot
            // 
            this.tabGGPlot.Location = new System.Drawing.Point(4, 22);
            this.tabGGPlot.Name = "tabGGPlot";
            this.tabGGPlot.Padding = new System.Windows.Forms.Padding(3);
            this.tabGGPlot.Size = new System.Drawing.Size(565, 519);
            this.tabGGPlot.TabIndex = 0;
            this.tabGGPlot.Text = "GGPLOT2";
            this.tabGGPlot.UseVisualStyleBackColor = true;
            // 
            // ctlRScripts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ctlRScripts";
            this.Size = new System.Drawing.Size(1230, 608);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabLatticeExtra.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox rtbRScript;
        private System.Windows.Forms.Button btnClipBoard;
        private System.Windows.Forms.Button btnSetScript;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabLatticeExtra;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckedListBox cblLatticeExtra;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabGGPlot;
    }
}
