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
            this.tabControlMain2 = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            this.tpExperiments = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.tpDocuments = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.spcDocuments = new Syncfusion.Windows.Forms.Tools.SplitContainerAdv();
            this.documentExplorer1 = new Syncfusion.Windows.Forms.Diagram.Controls.DocumentExplorer();
            this.docViewer = new Gnostice.Documents.Controls.WinForms.DocumentViewer();
            this.tpData = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.tpSetup = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.tpRScripts = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.tpRStudio = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.spcMainControl = new Syncfusion.Windows.Forms.Tools.SplitContainerAdv();
            this.btnExit = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnRefresh2 = new Syncfusion.Windows.Forms.ButtonAdv();
            this.toolStripTabItem2 = new Syncfusion.Windows.Forms.Tools.ToolStripTabItem();
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
            this.SuspendLayout();
            // 
            // tabControlMain2
            // 
            this.tabControlMain2.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.tabControlMain2.BeforeTouchSize = new System.Drawing.Size(971, 385);
            this.tabControlMain2.CloseButtonForeColor = System.Drawing.Color.Empty;
            this.tabControlMain2.CloseButtonHoverForeColor = System.Drawing.Color.Empty;
            this.tabControlMain2.CloseButtonPressedForeColor = System.Drawing.Color.Empty;
            this.tabControlMain2.Controls.Add(this.tpExperiments);
            this.tabControlMain2.Controls.Add(this.tpDocuments);
            this.tabControlMain2.Controls.Add(this.tpData);
            this.tabControlMain2.Controls.Add(this.tpSetup);
            this.tabControlMain2.Controls.Add(this.tpRScripts);
            this.tabControlMain2.Controls.Add(this.tpRStudio);
            this.tabControlMain2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain2.ItemSize = new System.Drawing.Size(150, 150);
            this.tabControlMain2.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain2.Multiline = true;
            this.tabControlMain2.MultilineText = true;
            this.tabControlMain2.Name = "tabControlMain2";
            this.tabControlMain2.RotateTextWhenVertical = true;
            this.tabControlMain2.Size = new System.Drawing.Size(971, 385);
            this.tabControlMain2.TabIndex = 0;
            this.tabControlMain2.TabStyle = typeof(Syncfusion.Windows.Forms.Tools.TabRendererIE7);
            this.tabControlMain2.ThemesEnabled = true;
            this.tabControlMain2.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // tpExperiments
            // 
            this.tpExperiments.Image = null;
            this.tpExperiments.ImageSize = new System.Drawing.Size(16, 16);
            this.tpExperiments.Location = new System.Drawing.Point(4, 3);
            this.tpExperiments.Name = "tpExperiments";
            this.tpExperiments.ShowCloseButton = true;
            this.tpExperiments.Size = new System.Drawing.Size(877, 378);
            this.tpExperiments.TabIndex = 1;
            this.tpExperiments.Text = "Experiments";
            this.tpExperiments.ThemesEnabled = true;
            // 
            // tpDocuments
            // 
            this.tpDocuments.Controls.Add(this.spcDocuments);
            this.tpDocuments.Image = null;
            this.tpDocuments.ImageSize = new System.Drawing.Size(16, 16);
            this.tpDocuments.Location = new System.Drawing.Point(4, 3);
            this.tpDocuments.Name = "tpDocuments";
            this.tpDocuments.ShowCloseButton = true;
            this.tpDocuments.Size = new System.Drawing.Size(877, 378);
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
            this.spcDocuments.Size = new System.Drawing.Size(877, 378);
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
            this.documentExplorer1.Size = new System.Drawing.Size(218, 378);
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
            this.docViewer.Size = new System.Drawing.Size(652, 378);
            this.docViewer.TabIndex = 0;
            this.docViewer.VScrollBar.LargeChange = 40;
            this.docViewer.VScrollBar.SmallChange = 20;
            this.docViewer.VScrollBar.Value = 0;
            this.docViewer.VScrollBar.Visibility = Gnostice.Documents.Controls.WinForms.ScrollBarVisibility.Always;
            this.docViewer.Zoom.ZoomMode = Gnostice.Documents.Controls.WinForms.ZoomMode.ActualSize;
            this.docViewer.Zoom.ZoomPercent = 100D;
            // 
            // tpData
            // 
            this.tpData.Image = null;
            this.tpData.ImageSize = new System.Drawing.Size(16, 16);
            this.tpData.Location = new System.Drawing.Point(4, 3);
            this.tpData.Name = "tpData";
            this.tpData.ShowCloseButton = true;
            this.tpData.Size = new System.Drawing.Size(877, 378);
            this.tpData.TabIndex = 2;
            this.tpData.Text = "Data";
            this.tpData.ThemesEnabled = true;
            // 
            // tpSetup
            // 
            this.tpSetup.Image = null;
            this.tpSetup.ImageSize = new System.Drawing.Size(16, 16);
            this.tpSetup.Location = new System.Drawing.Point(4, 3);
            this.tpSetup.Name = "tpSetup";
            this.tpSetup.ShowCloseButton = true;
            this.tpSetup.Size = new System.Drawing.Size(877, 378);
            this.tpSetup.TabIndex = 3;
            this.tpSetup.Text = "Setup";
            this.tpSetup.ThemesEnabled = true;
            // 
            // tpRScripts
            // 
            this.tpRScripts.Image = null;
            this.tpRScripts.ImageSize = new System.Drawing.Size(16, 16);
            this.tpRScripts.Location = new System.Drawing.Point(4, 3);
            this.tpRScripts.Name = "tpRScripts";
            this.tpRScripts.ShowCloseButton = true;
            this.tpRScripts.Size = new System.Drawing.Size(877, 378);
            this.tpRScripts.TabIndex = 4;
            this.tpRScripts.Text = "RScripts";
            this.tpRScripts.ThemesEnabled = true;
            // 
            // tpRStudio
            // 
            this.tpRStudio.Image = null;
            this.tpRStudio.ImageSize = new System.Drawing.Size(16, 16);
            this.tpRStudio.Location = new System.Drawing.Point(4, 3);
            this.tpRStudio.Name = "tpRStudio";
            this.tpRStudio.ShowCloseButton = true;
            this.tpRStudio.Size = new System.Drawing.Size(877, 378);
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
            this.btnExit.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.btnExit.BeforeTouchSize = new System.Drawing.Size(75, 93);
            this.btnExit.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.Raised;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
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
            this.btnRefresh2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.btnRefresh2.BeforeTouchSize = new System.Drawing.Size(75, 93);
            this.btnRefresh2.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.Raised;
            this.btnRefresh2.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRefresh2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
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
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControlMain2;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tpData;
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

    }
}