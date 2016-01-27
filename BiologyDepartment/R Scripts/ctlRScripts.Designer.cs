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
            this.txtColor = new System.Windows.Forms.TextBox();
            this.lblAxisColor = new System.Windows.Forms.Label();
            this.txtGraphOrder = new System.Windows.Forms.TextBox();
            this.lblOrder = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGGPlot = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tvGGPlot2 = new System.Windows.Forms.TreeView();
            this.tvSummary = new System.Windows.Forms.TreeView();
            this.tabLatticeExtra = new System.Windows.Forms.TabPage();
            this.cblLatticeExtra = new System.Windows.Forms.CheckedListBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cmbGroupData = new System.Windows.Forms.ComboBox();
            this.lblColorFill = new System.Windows.Forms.Label();
            this.cmbYAxisData = new System.Windows.Forms.ComboBox();
            this.lblYAxisDAta = new System.Windows.Forms.Label();
            this.lblXAxisData = new System.Windows.Forms.Label();
            this.cmbXAxisData = new System.Windows.Forms.ComboBox();
            this.btnClipBoard = new System.Windows.Forms.Button();
            this.btnSetScript = new System.Windows.Forms.Button();
            this.txtBoxZAxisTitle = new System.Windows.Forms.TextBox();
            this.lblZAxis = new System.Windows.Forms.Label();
            this.txtBoxYAxis = new System.Windows.Forms.TextBox();
            this.txtBoxXAxis = new System.Windows.Forms.TextBox();
            this.txtMainTitle = new System.Windows.Forms.TextBox();
            this.lblYAxis = new System.Windows.Forms.Label();
            this.lblXAxis = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.rtbRScript = new System.Windows.Forms.RichTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmbPanels = new System.Windows.Forms.ComboBox();
            this.lblFacet = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabGGPlot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabLatticeExtra.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cmbPanels);
            this.splitContainer1.Panel1.Controls.Add(this.lblFacet);
            this.splitContainer1.Panel1.Controls.Add(this.txtColor);
            this.splitContainer1.Panel1.Controls.Add(this.lblAxisColor);
            this.splitContainer1.Panel1.Controls.Add(this.txtGraphOrder);
            this.splitContainer1.Panel1.Controls.Add(this.lblOrder);
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel1.Controls.Add(this.btnRefresh);
            this.splitContainer1.Panel1.Controls.Add(this.cmbGroupData);
            this.splitContainer1.Panel1.Controls.Add(this.lblColorFill);
            this.splitContainer1.Panel1.Controls.Add(this.cmbYAxisData);
            this.splitContainer1.Panel1.Controls.Add(this.lblYAxisDAta);
            this.splitContainer1.Panel1.Controls.Add(this.lblXAxisData);
            this.splitContainer1.Panel1.Controls.Add(this.cmbXAxisData);
            this.splitContainer1.Panel1.Controls.Add(this.btnClipBoard);
            this.splitContainer1.Panel1.Controls.Add(this.btnSetScript);
            this.splitContainer1.Panel1.Controls.Add(this.txtBoxZAxisTitle);
            this.splitContainer1.Panel1.Controls.Add(this.lblZAxis);
            this.splitContainer1.Panel1.Controls.Add(this.txtBoxYAxis);
            this.splitContainer1.Panel1.Controls.Add(this.txtBoxXAxis);
            this.splitContainer1.Panel1.Controls.Add(this.txtMainTitle);
            this.splitContainer1.Panel1.Controls.Add(this.lblYAxis);
            this.splitContainer1.Panel1.Controls.Add(this.lblXAxis);
            this.splitContainer1.Panel1.Controls.Add(this.lblTitle);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rtbRScript);
            this.splitContainer1.Size = new System.Drawing.Size(1025, 566);
            this.splitContainer1.SplitterDistance = 448;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(98, 328);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(337, 20);
            this.txtColor.TabIndex = 27;
            this.toolTip1.SetToolTip(this.txtColor, "Column colors for the X axis.  Names should be surrounded by \"\" and seperated by " +
        "a comma (\"Color1\", \"Color2\")");
            // 
            // lblAxisColor
            // 
            this.lblAxisColor.AutoSize = true;
            this.lblAxisColor.Location = new System.Drawing.Point(3, 331);
            this.lblAxisColor.Name = "lblAxisColor";
            this.lblAxisColor.Size = new System.Drawing.Size(68, 13);
            this.lblAxisColor.TabIndex = 26;
            this.lblAxisColor.Text = "X AXIS Color";
            this.lblAxisColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtGraphOrder
            // 
            this.txtGraphOrder.Location = new System.Drawing.Point(98, 302);
            this.txtGraphOrder.Name = "txtGraphOrder";
            this.txtGraphOrder.Size = new System.Drawing.Size(337, 20);
            this.txtGraphOrder.TabIndex = 25;
            this.toolTip1.SetToolTip(this.txtGraphOrder, "Column order for the X axis.  Names should be surrounded by \"\" and seperated by a" +
        " comma (\"Name1\", \"Name2\")");
            // 
            // lblOrder
            // 
            this.lblOrder.AutoSize = true;
            this.lblOrder.Location = new System.Drawing.Point(3, 305);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(83, 13);
            this.lblOrder.TabIndex = 24;
            this.lblOrder.Text = "X AXIS ORDER";
            this.lblOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGGPlot);
            this.tabControl1.Controls.Add(this.tabLatticeExtra);
            this.tabControl1.Location = new System.Drawing.Point(15, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(419, 235);
            this.tabControl1.TabIndex = 23;
            // 
            // tabGGPlot
            // 
            this.tabGGPlot.Controls.Add(this.splitContainer2);
            this.tabGGPlot.Location = new System.Drawing.Point(4, 22);
            this.tabGGPlot.Name = "tabGGPlot";
            this.tabGGPlot.Padding = new System.Windows.Forms.Padding(3);
            this.tabGGPlot.Size = new System.Drawing.Size(411, 209);
            this.tabGGPlot.TabIndex = 0;
            this.tabGGPlot.Text = "GGPLOT2";
            this.tabGGPlot.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tvGGPlot2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tvSummary);
            this.splitContainer2.Size = new System.Drawing.Size(405, 203);
            this.splitContainer2.SplitterDistance = 193;
            this.splitContainer2.TabIndex = 0;
            // 
            // tvGGPlot2
            // 
            this.tvGGPlot2.CheckBoxes = true;
            this.tvGGPlot2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvGGPlot2.Location = new System.Drawing.Point(0, 0);
            this.tvGGPlot2.Name = "tvGGPlot2";
            this.tvGGPlot2.ShowNodeToolTips = true;
            this.tvGGPlot2.Size = new System.Drawing.Size(193, 203);
            this.tvGGPlot2.TabIndex = 1;
            // 
            // tvSummary
            // 
            this.tvSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvSummary.Location = new System.Drawing.Point(0, 0);
            this.tvSummary.Name = "tvSummary";
            this.tvSummary.Size = new System.Drawing.Size(208, 203);
            this.tvSummary.TabIndex = 0;
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
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(128, 491);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(98, 40);
            this.btnRefresh.TabIndex = 22;
            this.btnRefresh.Text = "REFRESH FORM";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // cmbGroupData
            // 
            this.cmbGroupData.FormattingEnabled = true;
            this.cmbGroupData.Location = new System.Drawing.Point(69, 272);
            this.cmbGroupData.Name = "cmbGroupData";
            this.cmbGroupData.Size = new System.Drawing.Size(146, 21);
            this.cmbGroupData.TabIndex = 21;
            this.toolTip1.SetToolTip(this.cmbGroupData, "Select which factor is used to set the column color.");
            // 
            // lblColorFill
            // 
            this.lblColorFill.AutoSize = true;
            this.lblColorFill.Location = new System.Drawing.Point(22, 275);
            this.lblColorFill.Name = "lblColorFill";
            this.lblColorFill.Size = new System.Drawing.Size(46, 13);
            this.lblColorFill.TabIndex = 20;
            this.lblColorFill.Text = "Color Fill";
            this.lblColorFill.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbYAxisData
            // 
            this.cmbYAxisData.FormattingEnabled = true;
            this.cmbYAxisData.Location = new System.Drawing.Point(289, 245);
            this.cmbYAxisData.Name = "cmbYAxisData";
            this.cmbYAxisData.Size = new System.Drawing.Size(146, 21);
            this.cmbYAxisData.TabIndex = 19;
            this.toolTip1.SetToolTip(this.cmbYAxisData, "Used to set the Y Axis.");
            // 
            // lblYAxisDAta
            // 
            this.lblYAxisDAta.AutoSize = true;
            this.lblYAxisDAta.Location = new System.Drawing.Point(221, 248);
            this.lblYAxisDAta.Name = "lblYAxisDAta";
            this.lblYAxisDAta.Size = new System.Drawing.Size(62, 13);
            this.lblYAxisDAta.TabIndex = 18;
            this.lblYAxisDAta.Text = "Y Axis Data";
            this.lblYAxisDAta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblXAxisData
            // 
            this.lblXAxisData.AutoSize = true;
            this.lblXAxisData.Location = new System.Drawing.Point(6, 248);
            this.lblXAxisData.Name = "lblXAxisData";
            this.lblXAxisData.Size = new System.Drawing.Size(62, 13);
            this.lblXAxisData.TabIndex = 17;
            this.lblXAxisData.Text = "X Axis Data";
            this.lblXAxisData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbXAxisData
            // 
            this.cmbXAxisData.FormattingEnabled = true;
            this.cmbXAxisData.Location = new System.Drawing.Point(70, 245);
            this.cmbXAxisData.Name = "cmbXAxisData";
            this.cmbXAxisData.Size = new System.Drawing.Size(145, 21);
            this.cmbXAxisData.TabIndex = 16;
            this.toolTip1.SetToolTip(this.cmbXAxisData, "Used to set the X Axis.");
            // 
            // btnClipBoard
            // 
            this.btnClipBoard.Location = new System.Drawing.Point(232, 491);
            this.btnClipBoard.Name = "btnClipBoard";
            this.btnClipBoard.Size = new System.Drawing.Size(98, 40);
            this.btnClipBoard.TabIndex = 11;
            this.btnClipBoard.Text = "COPY TO CLIPBOARD";
            this.btnClipBoard.UseVisualStyleBackColor = true;
            this.btnClipBoard.Click += new System.EventHandler(this.btnClipBoard_Click);
            // 
            // btnSetScript
            // 
            this.btnSetScript.Location = new System.Drawing.Point(336, 491);
            this.btnSetScript.Name = "btnSetScript";
            this.btnSetScript.Size = new System.Drawing.Size(98, 40);
            this.btnSetScript.TabIndex = 10;
            this.btnSetScript.Text = "SET SCRIPT";
            this.btnSetScript.UseVisualStyleBackColor = true;
            this.btnSetScript.Click += new System.EventHandler(this.btnSetScript_Click);
            // 
            // txtBoxZAxisTitle
            // 
            this.txtBoxZAxisTitle.Location = new System.Drawing.Point(97, 433);
            this.txtBoxZAxisTitle.Name = "txtBoxZAxisTitle";
            this.txtBoxZAxisTitle.Size = new System.Drawing.Size(337, 20);
            this.txtBoxZAxisTitle.TabIndex = 7;
            this.toolTip1.SetToolTip(this.txtBoxZAxisTitle, "Not used at this time.");
            // 
            // lblZAxis
            // 
            this.lblZAxis.AutoSize = true;
            this.lblZAxis.Location = new System.Drawing.Point(12, 436);
            this.lblZAxis.Name = "lblZAxis";
            this.lblZAxis.Size = new System.Drawing.Size(74, 13);
            this.lblZAxis.TabIndex = 6;
            this.lblZAxis.Text = "Z AXIS TITLE";
            this.lblZAxis.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBoxYAxis
            // 
            this.txtBoxYAxis.Location = new System.Drawing.Point(97, 407);
            this.txtBoxYAxis.Name = "txtBoxYAxis";
            this.txtBoxYAxis.Size = new System.Drawing.Size(337, 20);
            this.txtBoxYAxis.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtBoxYAxis, "Y Axis title.");
            // 
            // txtBoxXAxis
            // 
            this.txtBoxXAxis.Location = new System.Drawing.Point(97, 381);
            this.txtBoxXAxis.Name = "txtBoxXAxis";
            this.txtBoxXAxis.Size = new System.Drawing.Size(337, 20);
            this.txtBoxXAxis.TabIndex = 4;
            this.toolTip1.SetToolTip(this.txtBoxXAxis, "X Axis title.");
            // 
            // txtMainTitle
            // 
            this.txtMainTitle.Location = new System.Drawing.Point(97, 355);
            this.txtMainTitle.Name = "txtMainTitle";
            this.txtMainTitle.Size = new System.Drawing.Size(337, 20);
            this.txtMainTitle.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtMainTitle, "Main title for the Graph");
            // 
            // lblYAxis
            // 
            this.lblYAxis.AutoSize = true;
            this.lblYAxis.Location = new System.Drawing.Point(12, 410);
            this.lblYAxis.Name = "lblYAxis";
            this.lblYAxis.Size = new System.Drawing.Size(74, 13);
            this.lblYAxis.TabIndex = 2;
            this.lblYAxis.Text = "Y AXIS TITLE";
            this.lblYAxis.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblXAxis
            // 
            this.lblXAxis.AutoSize = true;
            this.lblXAxis.Location = new System.Drawing.Point(12, 384);
            this.lblXAxis.Name = "lblXAxis";
            this.lblXAxis.Size = new System.Drawing.Size(74, 13);
            this.lblXAxis.TabIndex = 1;
            this.lblXAxis.Text = "X AXIS TITLE";
            this.lblXAxis.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(8, 358);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(78, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "GRAPH TITLE";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rtbRScript
            // 
            this.rtbRScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbRScript.Location = new System.Drawing.Point(0, 0);
            this.rtbRScript.Name = "rtbRScript";
            this.rtbRScript.Size = new System.Drawing.Size(573, 566);
            this.rtbRScript.TabIndex = 0;
            this.rtbRScript.Text = "";
            // 
            // cmbPanels
            // 
            this.cmbPanels.FormattingEnabled = true;
            this.cmbPanels.Location = new System.Drawing.Point(289, 272);
            this.cmbPanels.Name = "cmbPanels";
            this.cmbPanels.Size = new System.Drawing.Size(146, 21);
            this.cmbPanels.TabIndex = 29;
            this.toolTip1.SetToolTip(this.cmbPanels, "Select which factor is used to set the panels.  Leave blank for no panels.");
            // 
            // lblFacet
            // 
            this.lblFacet.AutoSize = true;
            this.lblFacet.Location = new System.Drawing.Point(244, 275);
            this.lblFacet.Name = "lblFacet";
            this.lblFacet.Size = new System.Drawing.Size(39, 13);
            this.lblFacet.TabIndex = 28;
            this.lblFacet.Text = "Panels";
            this.lblFacet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ctlRScripts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ctlRScripts";
            this.Size = new System.Drawing.Size(1025, 566);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabGGPlot.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabLatticeExtra.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblYAxis;
        private System.Windows.Forms.Label lblXAxis;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.RichTextBox rtbRScript;
        private System.Windows.Forms.TextBox txtBoxZAxisTitle;
        private System.Windows.Forms.Label lblZAxis;
        private System.Windows.Forms.TextBox txtBoxYAxis;
        private System.Windows.Forms.TextBox txtBoxXAxis;
        private System.Windows.Forms.TextBox txtMainTitle;
        private System.Windows.Forms.Button btnClipBoard;
        private System.Windows.Forms.Button btnSetScript;
        private System.Windows.Forms.ComboBox cmbYAxisData;
        private System.Windows.Forms.Label lblYAxisDAta;
        private System.Windows.Forms.Label lblXAxisData;
        private System.Windows.Forms.ComboBox cmbXAxisData;
        private System.Windows.Forms.ComboBox cmbGroupData;
        private System.Windows.Forms.Label lblColorFill;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGGPlot;
        private System.Windows.Forms.TabPage tabLatticeExtra;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckedListBox cblLatticeExtra;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView tvGGPlot2;
        private System.Windows.Forms.TreeView tvSummary;
        private System.Windows.Forms.TextBox txtGraphOrder;
        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label lblAxisColor;
        private System.Windows.Forms.ComboBox cmbPanels;
        private System.Windows.Forms.Label lblFacet;
    }
}
