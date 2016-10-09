﻿namespace BiologyDepartment
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
            this.button1 = new System.Windows.Forms.Button();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabRBase = new System.Windows.Forms.TabPage();
            this.tabGGPlot = new System.Windows.Forms.TabPage();
            this.tabLatticeExtra = new System.Windows.Forms.TabPage();
            this.cblLatticeExtra = new System.Windows.Forms.CheckedListBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClipBoard = new System.Windows.Forms.Button();
            this.btnSetScript = new System.Windows.Forms.Button();
            this.txtScript = new ScintillaNET.Scintilla();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tcMain.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.tcMain);
            this.splitContainer1.Panel1.Controls.Add(this.btnRefresh);
            this.splitContainer1.Panel1.Controls.Add(this.btnClipBoard);
            this.splitContainer1.Panel1.Controls.Add(this.btnSetScript);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtScript);
            this.splitContainer1.Size = new System.Drawing.Size(1230, 608);
            this.splitContainer1.SplitterDistance = 593;
            this.splitContainer1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(440, 555);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 40);
            this.button1.TabIndex = 24;
            this.button1.Text = "test post";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tabRBase);
            this.tcMain.Controls.Add(this.tabGGPlot);
            this.tcMain.Controls.Add(this.tabLatticeExtra);
            this.tcMain.Location = new System.Drawing.Point(15, 4);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(573, 545);
            this.tcMain.TabIndex = 23;
            // 
            // tabRBase
            // 
            this.tabRBase.Location = new System.Drawing.Point(4, 22);
            this.tabRBase.Name = "tabRBase";
            this.tabRBase.Padding = new System.Windows.Forms.Padding(3);
            this.tabRBase.Size = new System.Drawing.Size(565, 519);
            this.tabRBase.TabIndex = 2;
            this.tabRBase.Text = "R Base";
            this.tabRBase.UseVisualStyleBackColor = true;
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
            // tabLatticeExtra
            // 
            this.tabLatticeExtra.Controls.Add(this.cblLatticeExtra);
            this.tabLatticeExtra.Location = new System.Drawing.Point(4, 22);
            this.tabLatticeExtra.Name = "tabLatticeExtra";
            this.tabLatticeExtra.Padding = new System.Windows.Forms.Padding(3);
            this.tabLatticeExtra.Size = new System.Drawing.Size(565, 519);
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
            this.cblLatticeExtra.Size = new System.Drawing.Size(559, 513);
            this.cblLatticeExtra.TabIndex = 0;
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
            // txtScript
            // 
            this.txtScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScript.Location = new System.Drawing.Point(0, 0);
            this.txtScript.Name = "txtScript";
            this.txtScript.Size = new System.Drawing.Size(633, 608);
            this.txtScript.TabIndex = 1;
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
            this.tcMain.ResumeLayout(false);
            this.tabLatticeExtra.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnClipBoard;
        private System.Windows.Forms.Button btnSetScript;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabLatticeExtra;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckedListBox cblLatticeExtra;
        private System.Windows.Forms.TabPage tabGGPlot;
        private System.Windows.Forms.TabPage tabRBase;
        private ScintillaNET.Scintilla txtScript;
        private System.Windows.Forms.Button button1;
    }
}
