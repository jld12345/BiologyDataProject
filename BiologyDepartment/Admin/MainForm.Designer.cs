namespace BiologyDepartment
{
    partial class MainForm
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
            Gnostice.Documents.FormatterSettings formatterSettings1 = new Gnostice.Documents.FormatterSettings();
            Gnostice.Documents.TXTFormatterSettings txtFormatterSettings1 = new Gnostice.Documents.TXTFormatterSettings();
            Gnostice.Documents.PageSettings pageSettings1 = new Gnostice.Documents.PageSettings();
            Gnostice.Documents.Margins margins1 = new Gnostice.Documents.Margins();
            Gnostice.Graphics.RenderingSettings renderingSettings1 = new Gnostice.Graphics.RenderingSettings();
            Gnostice.Graphics.ImageRenderingSettings imageRenderingSettings1 = new Gnostice.Graphics.ImageRenderingSettings();
            Gnostice.Graphics.LineArtRenderingSettings lineArtRenderingSettings1 = new Gnostice.Graphics.LineArtRenderingSettings();
            Gnostice.Graphics.ResolutionSettings resolutionSettings1 = new Gnostice.Graphics.ResolutionSettings();
            Gnostice.Graphics.TextRenderingSettings textRenderingSettings1 = new Gnostice.Graphics.TextRenderingSettings();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControlMain2 = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            this.tpExperiments = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.tpDocuments = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.spcDocuments = new Syncfusion.Windows.Forms.Tools.SplitContainerAdv();
            this.documentExplorer1 = new Syncfusion.Windows.Forms.Diagram.Controls.DocumentExplorer();
            this.docViewer = new Gnostice.Documents.Controls.WinForms.DocumentViewer();
            this.tpSetup = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.tpRScripts = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.tpRStudio = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.spcMainControl = new Syncfusion.Windows.Forms.Tools.SplitContainerAdv();
            this.btnExit = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnRefresh2 = new Syncfusion.Windows.Forms.ButtonAdv();
            this.toolStripTabItem2 = new Syncfusion.Windows.Forms.Tools.ToolStripTabItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpEnd = new Syncfusion.Windows.Forms.Tools.DateTimePickerAdv();
            this.lblEndDt = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.lblProjectName = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.dtpStart = new Syncfusion.Windows.Forms.Tools.DateTimePickerAdv();
            this.lblStartDt = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.txtProjectName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.lblCodeName = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.txtCodeName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlMain2)).BeginInit();
            this.tabControlMain2.SuspendLayout();
            this.tpDocuments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcDocuments)).BeginInit();
            this.spcDocuments.Panel1.SuspendLayout();
            this.spcDocuments.Panel2.SuspendLayout();
            this.spcDocuments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcMainControl)).BeginInit();
            this.spcMainControl.Panel1.SuspendLayout();
            this.spcMainControl.Panel2.SuspendLayout();
            this.spcMainControl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodeName)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlMain2
            // 
            this.tabControlMain2.ActiveTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tabControlMain2.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.tabControlMain2.BeforeTouchSize = new System.Drawing.Size(971, 385);
            this.tabControlMain2.BorderVisible = true;
            this.tabControlMain2.CloseButtonForeColor = System.Drawing.Color.Empty;
            this.tabControlMain2.CloseButtonHoverForeColor = System.Drawing.Color.Empty;
            this.tabControlMain2.CloseButtonPressedForeColor = System.Drawing.Color.Empty;
            this.tabControlMain2.Controls.Add(this.tpExperiments);
            this.tabControlMain2.Controls.Add(this.tpDocuments);
            this.tabControlMain2.Controls.Add(this.tpSetup);
            this.tabControlMain2.Controls.Add(this.tpRScripts);
            this.tabControlMain2.Controls.Add(this.tpRStudio);
            this.tabControlMain2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain2.FocusOnTabClick = false;
            this.tabControlMain2.ItemSize = new System.Drawing.Size(50, 120);
            this.tabControlMain2.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain2.MultilineText = true;
            this.tabControlMain2.Name = "tabControlMain2";
            this.tabControlMain2.RotateTextWhenVertical = true;
            this.tabControlMain2.Size = new System.Drawing.Size(971, 385);
            this.tabControlMain2.SizeMode = Syncfusion.Windows.Forms.Tools.TabSizeMode.Fixed;
            this.tabControlMain2.TabIndex = 0;
            this.tabControlMain2.TabPanelBackColor = System.Drawing.SystemColors.ControlLight;
            this.tabControlMain2.TabStyle = typeof(Syncfusion.Windows.Forms.Tools.TabRendererDockingWhidbey);
            this.tabControlMain2.ThemesEnabled = true;
            this.tabControlMain2.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // tpExperiments
            // 
            this.tpExperiments.Image = null;
            this.tpExperiments.ImageSize = new System.Drawing.Size(16, 16);
            this.tpExperiments.Location = new System.Drawing.Point(3, 2);
            this.tpExperiments.Name = "tpExperiments";
            this.tpExperiments.ShowCloseButton = true;
            this.tpExperiments.Size = new System.Drawing.Size(846, 381);
            this.tpExperiments.TabIndex = 1;
            this.tpExperiments.Text = "Experiments";
            this.tpExperiments.ThemesEnabled = true;
            // 
            // tpDocuments
            // 
            this.tpDocuments.Controls.Add(this.spcDocuments);
            this.tpDocuments.Image = null;
            this.tpDocuments.ImageSize = new System.Drawing.Size(16, 16);
            this.tpDocuments.Location = new System.Drawing.Point(3, 2);
            this.tpDocuments.Name = "tpDocuments";
            this.tpDocuments.ShowCloseButton = true;
            this.tpDocuments.Size = new System.Drawing.Size(846, 381);
            this.tpDocuments.TabIndex = 6;
            this.tpDocuments.Text = "Documents";
            this.tpDocuments.ThemesEnabled = true;
            // 
            // spcDocuments
            // 
            this.spcDocuments.BeforeTouchSize = 7;
            this.spcDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcDocuments.FixedPanel = Syncfusion.Windows.Forms.Tools.Enums.FixedPanel.Panel1;
            this.spcDocuments.IsSplitterFixed = true;
            this.spcDocuments.Location = new System.Drawing.Point(0, 0);
            this.spcDocuments.Name = "spcDocuments";
            // 
            // spcDocuments.Panel1
            // 
            this.spcDocuments.Panel1.Controls.Add(this.documentExplorer1);
            // 
            // spcDocuments.Panel2
            // 
            this.spcDocuments.Panel2.Controls.Add(this.docViewer);
            this.spcDocuments.Size = new System.Drawing.Size(846, 381);
            this.spcDocuments.SplitterDistance = 218;
            this.spcDocuments.TabIndex = 0;
            // 
            // documentExplorer1
            // 
            this.documentExplorer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentExplorer1.ImageIndex = 0;
            this.documentExplorer1.Location = new System.Drawing.Point(0, 0);
            this.documentExplorer1.Name = "documentExplorer1";
            this.documentExplorer1.SelectedImageIndex = 0;
            this.documentExplorer1.Size = new System.Drawing.Size(218, 381);
            this.documentExplorer1.TabIndex = 0;
            // 
            // docViewer
            // 
            this.docViewer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.docViewer.BorderWidth = 10;
            this.docViewer.CurrentPage = 0;
            this.docViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.docViewer.HScrollBar.LargeChange = 40;
            this.docViewer.HScrollBar.SmallChange = 20;
            this.docViewer.HScrollBar.Value = 0;
            this.docViewer.HScrollBar.Visibility = Gnostice.Documents.Controls.WinForms.ScrollBarVisibility.Always;
            this.docViewer.Location = new System.Drawing.Point(0, 0);
            this.docViewer.Name = "docViewer";
            // 
            // 
            // 
            this.docViewer.NavigationPane.ActivePage = null;
            this.docViewer.NavigationPane.Location = new System.Drawing.Point(0, 0);
            this.docViewer.NavigationPane.Name = "";
            this.docViewer.NavigationPane.TabIndex = 0;
            this.docViewer.NavigationPane.Visibility = Gnostice.Documents.Controls.WinForms.Visibility.Auto;
            this.docViewer.NavigationPane.WidthPercentage = 20;
            this.docViewer.PageLayout = null;
            this.docViewer.PageRotation = Gnostice.Documents.Controls.WinForms.RotationAngle.Zero;
            txtFormatterSettings1.Font = new System.Drawing.Font("Calibri", 12F);
            pageSettings1.Height = 11.6929F;
            margins1.Bottom = 1F;
            margins1.Footer = 0F;
            margins1.Header = 0F;
            margins1.Left = 1F;
            margins1.Right = 1F;
            margins1.Top = 1F;
            pageSettings1.Margin = margins1;
            pageSettings1.Orientation = Gnostice.Graphics.Orientation.Portrait;
            pageSettings1.PageSize = Gnostice.Documents.PageSize.A4;
            pageSettings1.Width = 8.2677F;
            txtFormatterSettings1.PageSettings = pageSettings1;
            formatterSettings1.TXT = txtFormatterSettings1;
            this.docViewer.Preferences.FormatterSettings = formatterSettings1;
            this.docViewer.Preferences.KeyNavigation = true;
            imageRenderingSettings1.CompositingMode = Gnostice.Graphics.CompositingMode.SourceOver;
            imageRenderingSettings1.CompositingQuality = Gnostice.Graphics.CompositingQuality.Default;
            imageRenderingSettings1.InterpolationMode = Gnostice.Graphics.InterpolationMode.Bilinear;
            imageRenderingSettings1.PixelOffsetMode = Gnostice.Graphics.PixelOffsetMode.Default;
            renderingSettings1.Image = imageRenderingSettings1;
            lineArtRenderingSettings1.SmoothingMode = Gnostice.Graphics.SmoothingMode.AntiAlias;
            renderingSettings1.LineArt = lineArtRenderingSettings1;
            resolutionSettings1.DpiX = 96F;
            resolutionSettings1.DpiY = 96F;
            resolutionSettings1.ResolutionMode = Gnostice.Graphics.ResolutionMode.UseSource;
            renderingSettings1.Resolution = resolutionSettings1;
            textRenderingSettings1.TextContrast = 3;
            textRenderingSettings1.TextRenderingHint = Gnostice.Graphics.TextRenderingHint.AntiAlias;
            renderingSettings1.Text = textRenderingSettings1;
            this.docViewer.Preferences.RenderingSettings = renderingSettings1;
            this.docViewer.Preferences.Units = Gnostice.Graphics.MeasurementUnit.Inches;
            this.docViewer.Size = new System.Drawing.Size(621, 381);
            this.docViewer.TabIndex = 0;
            this.docViewer.VScrollBar.LargeChange = 40;
            this.docViewer.VScrollBar.SmallChange = 20;
            this.docViewer.VScrollBar.Value = 0;
            this.docViewer.VScrollBar.Visibility = Gnostice.Documents.Controls.WinForms.ScrollBarVisibility.Always;
            this.docViewer.Zoom.ZoomMode = Gnostice.Documents.Controls.WinForms.ZoomMode.ActualSize;
            this.docViewer.Zoom.ZoomPercent = 100D;
            // 
            // tpSetup
            // 
            this.tpSetup.Image = null;
            this.tpSetup.ImageSize = new System.Drawing.Size(16, 16);
            this.tpSetup.Location = new System.Drawing.Point(3, 2);
            this.tpSetup.Name = "tpSetup";
            this.tpSetup.ShowCloseButton = true;
            this.tpSetup.Size = new System.Drawing.Size(846, 381);
            this.tpSetup.TabIndex = 3;
            this.tpSetup.Text = "Setup";
            this.tpSetup.ThemesEnabled = true;
            // 
            // tpRScripts
            // 
            this.tpRScripts.Image = null;
            this.tpRScripts.ImageSize = new System.Drawing.Size(16, 16);
            this.tpRScripts.Location = new System.Drawing.Point(3, 2);
            this.tpRScripts.Name = "tpRScripts";
            this.tpRScripts.ShowCloseButton = true;
            this.tpRScripts.Size = new System.Drawing.Size(846, 381);
            this.tpRScripts.TabIndex = 4;
            this.tpRScripts.Text = "RScripts";
            this.tpRScripts.ThemesEnabled = true;
            // 
            // tpRStudio
            // 
            this.tpRStudio.Image = null;
            this.tpRStudio.ImageSize = new System.Drawing.Size(16, 16);
            this.tpRStudio.Location = new System.Drawing.Point(3, 2);
            this.tpRStudio.Name = "tpRStudio";
            this.tpRStudio.ShowCloseButton = true;
            this.tpRStudio.Size = new System.Drawing.Size(846, 381);
            this.tpRStudio.TabIndex = 5;
            this.tpRStudio.Text = "RStudio";
            this.tpRStudio.ThemesEnabled = true;
            // 
            // spcMainControl
            // 
            this.spcMainControl.BeforeTouchSize = 7;
            this.spcMainControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMainControl.FixedPanel = Syncfusion.Windows.Forms.Tools.Enums.FixedPanel.Panel1;
            this.spcMainControl.Location = new System.Drawing.Point(0, 0);
            this.spcMainControl.Name = "spcMainControl";
            this.spcMainControl.Orientation = System.Windows.Forms.Orientation.Vertical;
            // 
            // spcMainControl.Panel1
            // 
            this.spcMainControl.Panel1.Controls.Add(this.groupBox1);
            this.spcMainControl.Panel1.Controls.Add(this.btnExit);
            this.spcMainControl.Panel1.Controls.Add(this.btnRefresh2);
            // 
            // spcMainControl.Panel2
            // 
            this.spcMainControl.Panel2.Controls.Add(this.tabControlMain2);
            this.spcMainControl.Size = new System.Drawing.Size(971, 485);
            this.spcMainControl.SplitterDistance = 93;
            this.spcMainControl.TabIndex = 1;
            this.spcMainControl.Text = "spcMainControl";
            // 
            // btnExit
            // 
            this.btnExit.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2010;
            this.btnExit.BeforeTouchSize = new System.Drawing.Size(75, 93);
            this.btnExit.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.Raised;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.IsBackStageButton = false;
            this.btnExit.Location = new System.Drawing.Point(75, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 93);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyle = true;
            this.btnExit.Click += new System.EventHandler(this.tspExit_Click);
            // 
            // btnRefresh2
            // 
            this.btnRefresh2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2010;
            this.btnRefresh2.BeforeTouchSize = new System.Drawing.Size(75, 93);
            this.btnRefresh2.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.Raised;
            this.btnRefresh2.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRefresh2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh2.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh2.Image")));
            this.btnRefresh2.IsBackStageButton = false;
            this.btnRefresh2.Location = new System.Drawing.Point(0, 0);
            this.btnRefresh2.Name = "btnRefresh2";
            this.btnRefresh2.Size = new System.Drawing.Size(75, 93);
            this.btnRefresh2.TabIndex = 0;
            this.btnRefresh2.Text = "Refresh";
            this.btnRefresh2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRefresh2.UseVisualStyle = true;
            this.btnRefresh2.Click += new System.EventHandler(this.btnRefresh2_Click);
            // 
            // toolStripTabItem2
            // 
            this.toolStripTabItem2.Name = "toolStripTabItem2";
            // 
            // 
            // 
            this.toolStripTabItem2.Panel.Name = "";
            this.toolStripTabItem2.Panel.ScrollPosition = 0;
            this.toolStripTabItem2.Panel.TabIndex = 3;
            this.toolStripTabItem2.Panel.Text = "toolStripTabItem2";
            this.toolStripTabItem2.Position = -1;
            this.toolStripTabItem2.Size = new System.Drawing.Size(103, 19);
            this.toolStripTabItem2.Text = "toolStripTabItem2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCodeName);
            this.groupBox1.Controls.Add(this.txtCodeName);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.lblEndDt);
            this.groupBox1.Controls.Add(this.lblProjectName);
            this.groupBox1.Controls.Add(this.dtpStart);
            this.groupBox1.Controls.Add(this.lblStartDt);
            this.groupBox1.Controls.Add(this.txtProjectName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(370, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(601, 93);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
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
            this.dtpEnd.Location = new System.Drawing.Point(244, 55);
            this.dtpEnd.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.dtpEnd.MinValue = new System.DateTime(((long)(0)));
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(104, 20);
            this.dtpEnd.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.dtpEnd.TabIndex = 31;
            this.dtpEnd.Value = new System.DateTime(2016, 8, 14, 23, 54, 21, 663);
            // 
            // lblEndDt
            // 
            this.lblEndDt.Location = new System.Drawing.Point(186, 58);
            this.lblEndDt.Name = "lblEndDt";
            this.lblEndDt.Size = new System.Drawing.Size(52, 13);
            this.lblEndDt.TabIndex = 32;
            this.lblEndDt.Text = "End Date";
            // 
            // lblProjectName
            // 
            this.lblProjectName.Location = new System.Drawing.Point(8, 16);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(71, 13);
            this.lblProjectName.TabIndex = 25;
            this.lblProjectName.Text = "Project Name";
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
            this.dtpStart.Location = new System.Drawing.Point(69, 55);
            this.dtpStart.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.dtpStart.MinValue = new System.DateTime(((long)(0)));
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(104, 20);
            this.dtpStart.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.dtpStart.TabIndex = 29;
            this.dtpStart.Value = new System.DateTime(2016, 8, 14, 23, 54, 21, 663);
            // 
            // lblStartDt
            // 
            this.lblStartDt.Location = new System.Drawing.Point(8, 55);
            this.lblStartDt.Name = "lblStartDt";
            this.lblStartDt.Size = new System.Drawing.Size(55, 13);
            this.lblStartDt.TabIndex = 30;
            this.lblStartDt.Text = "Start Date";
            // 
            // txtProjectName
            // 
            this.txtProjectName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.txtProjectName.BeforeTouchSize = new System.Drawing.Size(308, 20);
            this.txtProjectName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(208)))), ((int)(((byte)(229)))));
            this.txtProjectName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProjectName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProjectName.Enabled = false;
            this.txtProjectName.Location = new System.Drawing.Point(8, 32);
            this.txtProjectName.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(308, 20);
            this.txtProjectName.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2007;
            this.txtProjectName.TabIndex = 24;
            // 
            // lblCodeName
            // 
            this.lblCodeName.Location = new System.Drawing.Point(318, 16);
            this.lblCodeName.Name = "lblCodeName";
            this.lblCodeName.Size = new System.Drawing.Size(63, 13);
            this.lblCodeName.TabIndex = 34;
            this.lblCodeName.Text = "Code Name";
            // 
            // txtCodeName
            // 
            this.txtCodeName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.txtCodeName.BeforeTouchSize = new System.Drawing.Size(277, 20);
            this.txtCodeName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(208)))), ((int)(((byte)(229)))));
            this.txtCodeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodeName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCodeName.Enabled = false;
            this.txtCodeName.Location = new System.Drawing.Point(318, 32);
            this.txtCodeName.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtCodeName.Name = "txtCodeName";
            this.txtCodeName.Size = new System.Drawing.Size(277, 20);
            this.txtCodeName.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2007;
            this.txtCodeName.TabIndex = 33;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(971, 485);
            this.ControlBox = false;
            this.Controls.Add(this.spcMainControl);
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(979, 501);
            this.Name = "MainForm";
            this.Text = "Biology Project Database";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.tabControlMain2)).EndInit();
            this.tabControlMain2.ResumeLayout(false);
            this.tpDocuments.ResumeLayout(false);
            this.spcDocuments.Panel1.ResumeLayout(false);
            this.spcDocuments.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcDocuments)).EndInit();
            this.spcDocuments.ResumeLayout(false);
            this.spcMainControl.Panel1.ResumeLayout(false);
            this.spcMainControl.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMainControl)).EndInit();
            this.spcMainControl.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodeName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControlMain2;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tpSetup;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tpRScripts;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tpRStudio;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tpExperiments;
        private Syncfusion.Windows.Forms.Tools.SplitContainerAdv spcMainControl;
        private Syncfusion.Windows.Forms.Tools.ToolStripTabItem toolStripTabItem2;
        private Syncfusion.Windows.Forms.ButtonAdv btnRefresh2;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tpDocuments;
        private Syncfusion.Windows.Forms.Tools.SplitContainerAdv spcDocuments;
        private Syncfusion.Windows.Forms.Diagram.Controls.DocumentExplorer documentExplorer1;
        private Syncfusion.Windows.Forms.ButtonAdv btnExit;
        private Gnostice.Documents.Controls.WinForms.DocumentViewer docViewer;
        private System.Windows.Forms.GroupBox groupBox1;
        private Syncfusion.Windows.Forms.Tools.DateTimePickerAdv dtpEnd;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblEndDt;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblProjectName;
        private Syncfusion.Windows.Forms.Tools.DateTimePickerAdv dtpStart;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblStartDt;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtProjectName;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblCodeName;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtCodeName;

    }
}