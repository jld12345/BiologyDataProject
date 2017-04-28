namespace BiologyDepartment.Admin
{
    partial class dlgExperimentSearch
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Syncfusion.Windows.Forms.Tools.TreeNodeAdvStyleInfo treeNodeAdvStyleInfo1 = new Syncfusion.Windows.Forms.Tools.TreeNodeAdvStyleInfo();
            Syncfusion.Windows.Forms.Tools.TreeNodeAdv treeNodeAdv1 = new Syncfusion.Windows.Forms.Tools.TreeNodeAdv();
            Syncfusion.Windows.Forms.Tools.TreeNodeAdv treeNodeAdv2 = new Syncfusion.Windows.Forms.Tools.TreeNodeAdv();
            Syncfusion.Windows.Forms.Tools.TreeNodeAdv treeNodeAdv3 = new Syncfusion.Windows.Forms.Tools.TreeNodeAdv();
            Syncfusion.Windows.Forms.Tools.TreeNodeAdv treeNodeAdv4 = new Syncfusion.Windows.Forms.Tools.TreeNodeAdv();
            this.spcExperimentDocs = new System.Windows.Forms.SplitContainer();
            this.tvExperiments = new Syncfusion.Windows.Forms.Tools.TreeViewAdv();
            this.gbData = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cmbParents = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtShortName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.rtbOfficialName = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbFilters = new System.Windows.Forms.GroupBox();
            this.btnClear = new Syncfusion.Windows.Forms.ButtonAdv();
            this.txtSearchBox = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.gbSearchBy = new System.Windows.Forms.GroupBox();
            this.rbShortName = new Syncfusion.Windows.Forms.Tools.RadioButtonAdv();
            this.rbTitle = new Syncfusion.Windows.Forms.Tools.RadioButtonAdv();
            this.rbKeyWord = new Syncfusion.Windows.Forms.Tools.RadioButtonAdv();
            this.rbAuthor = new Syncfusion.Windows.Forms.Tools.RadioButtonAdv();
            this.btnCancel = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnLoad = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnSearch = new Syncfusion.Windows.Forms.ButtonAdv();
            this.dteStart = new System.Windows.Forms.DateTimePicker();
            this.dteEnd = new System.Windows.Forms.DateTimePicker();
            this.rtbNotes = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            ((System.ComponentModel.ISupportInitialize)(this.spcExperimentDocs)).BeginInit();
            this.spcExperimentDocs.Panel1.SuspendLayout();
            this.spcExperimentDocs.Panel2.SuspendLayout();
            this.spcExperimentDocs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tvExperiments)).BeginInit();
            this.gbData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbParents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShortName)).BeginInit();
            this.gbFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchBox)).BeginInit();
            this.gbSearchBy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbShortName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbKeyWord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbAuthor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtbNotes)).BeginInit();
            this.SuspendLayout();
            // 
            // spcExperimentDocs
            // 
            this.spcExperimentDocs.BackColor = System.Drawing.Color.WhiteSmoke;
            this.spcExperimentDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcExperimentDocs.IsSplitterFixed = true;
            this.spcExperimentDocs.Location = new System.Drawing.Point(0, 0);
            this.spcExperimentDocs.Name = "spcExperimentDocs";
            // 
            // spcExperimentDocs.Panel1
            // 
            this.spcExperimentDocs.Panel1.Controls.Add(this.tvExperiments);
            // 
            // spcExperimentDocs.Panel2
            // 
            this.spcExperimentDocs.Panel2.Controls.Add(this.gbData);
            this.spcExperimentDocs.Panel2.Controls.Add(this.gbFilters);
            this.spcExperimentDocs.Size = new System.Drawing.Size(1120, 613);
            this.spcExperimentDocs.SplitterDistance = 260;
            this.spcExperimentDocs.TabIndex = 39;
            // 
            // tvExperiments
            // 
            this.tvExperiments.AccelerateScrolling = Syncfusion.Windows.Forms.AccelerateScrollingBehavior.Immediate;
            treeNodeAdvStyleInfo1.ClosedImgIndex = 19;
            treeNodeAdvStyleInfo1.EnsureDefaultOptionedChild = true;
            treeNodeAdvStyleInfo1.NoChildrenImgIndex = 19;
            treeNodeAdvStyleInfo1.OpenImgIndex = 19;
            treeNodeAdvStyleInfo1.ShowPlusMinus = true;
            this.tvExperiments.BaseStylePairs.AddRange(new Syncfusion.Windows.Forms.Tools.StyleNamePair[] {
            new Syncfusion.Windows.Forms.Tools.StyleNamePair("Standard", treeNodeAdvStyleInfo1)});
            this.tvExperiments.BeforeTouchSize = new System.Drawing.Size(260, 613);
            this.tvExperiments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvExperiments.ClosedImgIndex = 19;
            this.tvExperiments.DefaultCollapseImageIndex = 19;
            this.tvExperiments.DefaultExpandImageIndex = 19;
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
            this.tvExperiments.LineColor = System.Drawing.Color.Transparent;
            this.tvExperiments.LineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.tvExperiments.Location = new System.Drawing.Point(0, 0);
            this.tvExperiments.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.tvExperiments.Name = "tvExperiments";
            this.tvExperiments.NoChildrenImgIndex = 19;
            treeNodeAdv1.Background = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Teal);
            treeNodeAdv1.ChildStyle.EnsureDefaultOptionedChild = true;
            treeNodeAdv1.ClosedImgIndex = 19;
            treeNodeAdv1.CollapseImageIndex = 19;
            treeNodeAdv1.EnsureDefaultOptionedChild = true;
            treeNodeAdv1.ExpandImageIndex = 19;
            treeNodeAdv1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNodeAdv1.Height = 20;
            treeNodeAdv1.IntermediateCheckColor = System.Drawing.Color.WhiteSmoke;
            treeNodeAdv1.LeftImageIndices = new int[] {
        19};
            treeNodeAdv1.MultiLine = true;
            treeNodeAdv1.OpenImgIndex = 19;
            treeNodeAdv1.PlusMinusSize = new System.Drawing.Size(9, 9);
            treeNodeAdv1.ShowLine = true;
            treeNodeAdv1.Text = "OWNER                         ";
            treeNodeAdv1.TextColor = System.Drawing.Color.WhiteSmoke;
            treeNodeAdv2.Background = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Teal);
            treeNodeAdv2.ChildStyle.EnsureDefaultOptionedChild = true;
            treeNodeAdv2.ClosedImgIndex = 19;
            treeNodeAdv2.CollapseImageIndex = 19;
            treeNodeAdv2.EnsureDefaultOptionedChild = true;
            treeNodeAdv2.ExpandImageIndex = 19;
            treeNodeAdv2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNodeAdv2.Height = 20;
            treeNodeAdv2.IntermediateCheckColor = System.Drawing.Color.WhiteSmoke;
            treeNodeAdv2.LeftImageIndices = new int[] {
        19};
            treeNodeAdv2.MultiLine = true;
            treeNodeAdv2.OpenImgIndex = 19;
            treeNodeAdv2.PlusMinusSize = new System.Drawing.Size(9, 9);
            treeNodeAdv2.RightImageIndices = new int[0];
            treeNodeAdv2.ShowLine = true;
            treeNodeAdv2.Text = "ADMIN                           ";
            treeNodeAdv2.TextColor = System.Drawing.Color.WhiteSmoke;
            treeNodeAdv3.Background = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Teal);
            treeNodeAdv3.ChildStyle.EnsureDefaultOptionedChild = true;
            treeNodeAdv3.ClosedImgIndex = 19;
            treeNodeAdv3.CollapseImageIndex = 19;
            treeNodeAdv3.EnsureDefaultOptionedChild = true;
            treeNodeAdv3.ExpandImageIndex = 19;
            treeNodeAdv3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNodeAdv3.Height = 20;
            treeNodeAdv3.IntermediateCheckColor = System.Drawing.Color.WhiteSmoke;
            treeNodeAdv3.LeftImageIndices = new int[] {
        19};
            treeNodeAdv3.MultiLine = true;
            treeNodeAdv3.OpenImgIndex = 19;
            treeNodeAdv3.PlusMinusSize = new System.Drawing.Size(9, 9);
            treeNodeAdv3.RightImageIndices = new int[0];
            treeNodeAdv3.ShowLine = true;
            treeNodeAdv3.Text = "ADD-EDIT                      ";
            treeNodeAdv3.TextColor = System.Drawing.Color.WhiteSmoke;
            treeNodeAdv4.Background = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Teal);
            treeNodeAdv4.ChildStyle.EnsureDefaultOptionedChild = true;
            treeNodeAdv4.ClosedImgIndex = 19;
            treeNodeAdv4.CollapseImageIndex = 19;
            treeNodeAdv4.EnsureDefaultOptionedChild = true;
            treeNodeAdv4.ExpandImageIndex = 19;
            treeNodeAdv4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNodeAdv4.Height = 20;
            treeNodeAdv4.IntermediateCheckColor = System.Drawing.Color.WhiteSmoke;
            treeNodeAdv4.LeftImageIndices = new int[] {
        19};
            treeNodeAdv4.MultiLine = true;
            treeNodeAdv4.OpenImgIndex = 19;
            treeNodeAdv4.PlusMinusSize = new System.Drawing.Size(9, 9);
            treeNodeAdv4.RightImageIndices = new int[0];
            treeNodeAdv4.ShowLine = true;
            treeNodeAdv4.Text = "VIEW                             ";
            treeNodeAdv4.TextColor = System.Drawing.Color.WhiteSmoke;
            this.tvExperiments.Nodes.AddRange(new Syncfusion.Windows.Forms.Tools.TreeNodeAdv[] {
            treeNodeAdv1,
            treeNodeAdv2,
            treeNodeAdv3,
            treeNodeAdv4});
            this.tvExperiments.OpenImgIndex = 19;
            this.tvExperiments.OwnerDrawNodes = true;
            this.tvExperiments.SelectedNodeBackground = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220))))));
            this.tvExperiments.SelectedNodeForeColor = System.Drawing.SystemColors.HighlightText;
            this.tvExperiments.ShowLines = false;
            this.tvExperiments.ShowRootLines = false;
            this.tvExperiments.Size = new System.Drawing.Size(260, 613);
            this.tvExperiments.TabIndex = 38;
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
            this.tvExperiments.DoubleClick += new System.EventHandler(this.tvExperiments_DoubleClick);
            // 
            // gbData
            // 
            this.gbData.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbData.Controls.Add(this.splitContainer1);
            this.gbData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbData.Location = new System.Drawing.Point(0, 108);
            this.gbData.Name = "gbData";
            this.gbData.Size = new System.Drawing.Size(856, 505);
            this.gbData.TabIndex = 1;
            this.gbData.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dteEnd);
            this.splitContainer1.Panel1.Controls.Add(this.dteStart);
            this.splitContainer1.Panel1.Controls.Add(this.cmbParents);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.txtShortName);
            this.splitContainer1.Panel1.Controls.Add(this.rtbOfficialName);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rtbNotes);
            this.splitContainer1.Size = new System.Drawing.Size(850, 486);
            this.splitContainer1.SplitterDistance = 204;
            this.splitContainer1.TabIndex = 4;
            // 
            // cmbParents
            // 
            this.cmbParents.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbParents.BeforeTouchSize = new System.Drawing.Size(350, 21);
            this.cmbParents.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.cmbParents.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbParents.Location = new System.Drawing.Point(308, 155);
            this.cmbParents.Name = "cmbParents";
            this.cmbParents.ReadOnly = true;
            this.cmbParents.Size = new System.Drawing.Size(350, 21);
            this.cmbParents.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(305, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Parent Experiment";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(13, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Additional Information";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(158, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "End Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(13, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Start Date";
            // 
            // txtShortName
            // 
            this.txtShortName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtShortName.BeforeTouchSize = new System.Drawing.Size(850, 278);
            this.txtShortName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtShortName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtShortName.Enabled = false;
            this.txtShortName.Location = new System.Drawing.Point(13, 30);
            this.txtShortName.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.ReadOnly = true;
            this.txtShortName.Size = new System.Drawing.Size(645, 13);
            this.txtShortName.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtShortName.TabIndex = 4;
            // 
            // rtbOfficialName
            // 
            this.rtbOfficialName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rtbOfficialName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbOfficialName.Location = new System.Drawing.Point(16, 71);
            this.rtbOfficialName.Name = "rtbOfficialName";
            this.rtbOfficialName.ReadOnly = true;
            this.rtbOfficialName.Size = new System.Drawing.Size(642, 57);
            this.rtbOfficialName.TabIndex = 3;
            this.rtbOfficialName.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(13, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Official Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Short Name";
            // 
            // gbFilters
            // 
            this.gbFilters.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbFilters.Controls.Add(this.btnClear);
            this.gbFilters.Controls.Add(this.txtSearchBox);
            this.gbFilters.Controls.Add(this.gbSearchBy);
            this.gbFilters.Controls.Add(this.btnCancel);
            this.gbFilters.Controls.Add(this.btnLoad);
            this.gbFilters.Controls.Add(this.btnSearch);
            this.gbFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbFilters.Location = new System.Drawing.Point(0, 0);
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.Size = new System.Drawing.Size(856, 108);
            this.gbFilters.TabIndex = 0;
            this.gbFilters.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.LightGray;
            this.btnClear.BeforeTouchSize = new System.Drawing.Size(75, 40);
            this.btnClear.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.None;
            this.btnClear.IsBackStageButton = false;
            this.btnClear.Location = new System.Drawing.Point(415, 31);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 40);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear Search";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtSearchBox
            // 
            this.txtSearchBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSearchBox.BeforeTouchSize = new System.Drawing.Size(850, 278);
            this.txtSearchBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchBox.Location = new System.Drawing.Point(7, 80);
            this.txtSearchBox.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.Size = new System.Drawing.Size(654, 20);
            this.txtSearchBox.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtSearchBox.TabIndex = 4;
            // 
            // gbSearchBy
            // 
            this.gbSearchBy.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbSearchBy.Controls.Add(this.rbShortName);
            this.gbSearchBy.Controls.Add(this.rbTitle);
            this.gbSearchBy.Controls.Add(this.rbKeyWord);
            this.gbSearchBy.Controls.Add(this.rbAuthor);
            this.gbSearchBy.Location = new System.Drawing.Point(7, 19);
            this.gbSearchBy.Name = "gbSearchBy";
            this.gbSearchBy.Size = new System.Drawing.Size(321, 52);
            this.gbSearchBy.TabIndex = 3;
            this.gbSearchBy.TabStop = false;
            this.gbSearchBy.Text = "Search By";
            // 
            // rbShortName
            // 
            this.rbShortName.BeforeTouchSize = new System.Drawing.Size(84, 21);
            this.rbShortName.Location = new System.Drawing.Point(223, 20);
            this.rbShortName.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.rbShortName.Name = "rbShortName";
            this.rbShortName.Size = new System.Drawing.Size(84, 21);
            this.rbShortName.TabIndex = 3;
            this.rbShortName.Text = "Short Name";
            this.rbShortName.ThemesEnabled = false;
            // 
            // rbTitle
            // 
            this.rbTitle.BeforeTouchSize = new System.Drawing.Size(53, 21);
            this.rbTitle.Location = new System.Drawing.Point(164, 20);
            this.rbTitle.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.rbTitle.Name = "rbTitle";
            this.rbTitle.Size = new System.Drawing.Size(53, 21);
            this.rbTitle.TabIndex = 2;
            this.rbTitle.Text = "Title";
            this.rbTitle.ThemesEnabled = false;
            // 
            // rbKeyWord
            // 
            this.rbKeyWord.BeforeTouchSize = new System.Drawing.Size(80, 21);
            this.rbKeyWord.Location = new System.Drawing.Point(78, 20);
            this.rbKeyWord.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.rbKeyWord.Name = "rbKeyWord";
            this.rbKeyWord.Size = new System.Drawing.Size(80, 21);
            this.rbKeyWord.TabIndex = 1;
            this.rbKeyWord.Text = "Key Word";
            this.rbKeyWord.ThemesEnabled = false;
            // 
            // rbAuthor
            // 
            this.rbAuthor.BeforeTouchSize = new System.Drawing.Size(63, 21);
            this.rbAuthor.Location = new System.Drawing.Point(9, 20);
            this.rbAuthor.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.rbAuthor.Name = "rbAuthor";
            this.rbAuthor.Size = new System.Drawing.Size(63, 21);
            this.rbAuthor.TabIndex = 0;
            this.rbAuthor.Text = "Author";
            this.rbAuthor.ThemesEnabled = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightGray;
            this.btnCancel.BeforeTouchSize = new System.Drawing.Size(75, 41);
            this.btnCancel.IsBackStageButton = false;
            this.btnCancel.Location = new System.Drawing.Point(775, 59);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 41);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.LightGray;
            this.btnLoad.BeforeTouchSize = new System.Drawing.Size(75, 41);
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoad.IsBackStageButton = false;
            this.btnLoad.Location = new System.Drawing.Point(775, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 41);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.LightGray;
            this.btnSearch.BeforeTouchSize = new System.Drawing.Size(75, 40);
            this.btnSearch.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.None;
            this.btnSearch.IsBackStageButton = false;
            this.btnSearch.Location = new System.Drawing.Point(334, 31);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 40);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dteStart
            // 
            this.dteStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteStart.Location = new System.Drawing.Point(16, 158);
            this.dteStart.Name = "dteStart";
            this.dteStart.Size = new System.Drawing.Size(105, 20);
            this.dteStart.TabIndex = 15;
            // 
            // dteEnd
            // 
            this.dteEnd.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.dteEnd.CalendarTitleBackColor = System.Drawing.Color.WhiteSmoke;
            this.dteEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteEnd.Location = new System.Drawing.Point(161, 158);
            this.dteEnd.Name = "dteEnd";
            this.dteEnd.Size = new System.Drawing.Size(106, 20);
            this.dteEnd.TabIndex = 16;
            // 
            // rtbNotes
            // 
            this.rtbNotes.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rtbNotes.BeforeTouchSize = new System.Drawing.Size(850, 278);
            this.rtbNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbNotes.Enabled = false;
            this.rtbNotes.Location = new System.Drawing.Point(0, 0);
            this.rtbNotes.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.rtbNotes.Multiline = true;
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(850, 278);
            this.rtbNotes.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.rtbNotes.TabIndex = 1;
            this.rtbNotes.Text = "textBoxExt1";
            // 
            // dlgExperimentSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 613);
            this.Controls.Add(this.spcExperimentDocs);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "dlgExperimentSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Experiments";
            this.spcExperimentDocs.Panel1.ResumeLayout(false);
            this.spcExperimentDocs.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcExperimentDocs)).EndInit();
            this.spcExperimentDocs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tvExperiments)).EndInit();
            this.gbData.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbParents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShortName)).EndInit();
            this.gbFilters.ResumeLayout(false);
            this.gbFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchBox)).EndInit();
            this.gbSearchBy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rbShortName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbKeyWord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbAuthor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtbNotes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcExperimentDocs;
        private Syncfusion.Windows.Forms.Tools.TreeViewAdv tvExperiments;
        private System.Windows.Forms.GroupBox gbData;
        private System.Windows.Forms.GroupBox gbFilters;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbParents;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtShortName;
        private System.Windows.Forms.RichTextBox rtbOfficialName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Syncfusion.Windows.Forms.ButtonAdv btnCancel;
        private Syncfusion.Windows.Forms.ButtonAdv btnLoad;
        private Syncfusion.Windows.Forms.ButtonAdv btnSearch;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtSearchBox;
        private System.Windows.Forms.GroupBox gbSearchBy;
        private Syncfusion.Windows.Forms.Tools.RadioButtonAdv rbShortName;
        private Syncfusion.Windows.Forms.Tools.RadioButtonAdv rbTitle;
        private Syncfusion.Windows.Forms.Tools.RadioButtonAdv rbKeyWord;
        private Syncfusion.Windows.Forms.Tools.RadioButtonAdv rbAuthor;
        private Syncfusion.Windows.Forms.ButtonAdv btnClear;
        private System.Windows.Forms.DateTimePicker dteEnd;
        private System.Windows.Forms.DateTimePicker dteStart;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt rtbNotes;
    }
}