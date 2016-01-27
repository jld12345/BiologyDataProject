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
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabExperiments = new System.Windows.Forms.TabPage();
            this.tabData = new System.Windows.Forms.TabPage();
            this.tabAuthors = new System.Windows.Forms.TabPage();
            this.tabR = new System.Windows.Forms.TabPage();
            this.pnlBrowser = new System.Windows.Forms.Panel();
            this.tabSetup = new System.Windows.Forms.TabPage();
            this.tabRScripts = new System.Windows.Forms.TabPage();
            this.tabControlMain.SuspendLayout();
            this.tabR.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.tabControlMain.Controls.Add(this.tabExperiments);
            this.tabControlMain.Controls.Add(this.tabData);
            this.tabControlMain.Controls.Add(this.tabAuthors);
            this.tabControlMain.Controls.Add(this.tabR);
            this.tabControlMain.Controls.Add(this.tabSetup);
            this.tabControlMain.Controls.Add(this.tabRScripts);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControlMain.ItemSize = new System.Drawing.Size(50, 125);
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Multiline = true;
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControlMain.RightToLeftLayout = true;
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(971, 474);
            this.tabControlMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlMain.TabIndex = 0;
            this.tabControlMain.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControlMain_DrawItem);
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // tabExperiments
            // 
            this.tabExperiments.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabExperiments.Location = new System.Drawing.Point(4, 4);
            this.tabExperiments.Name = "tabExperiments";
            this.tabExperiments.Padding = new System.Windows.Forms.Padding(3);
            this.tabExperiments.Size = new System.Drawing.Size(838, 466);
            this.tabExperiments.TabIndex = 0;
            this.tabExperiments.Text = "Experiments";
            // 
            // tabData
            // 
            this.tabData.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabData.Location = new System.Drawing.Point(4, 4);
            this.tabData.Name = "tabData";
            this.tabData.Padding = new System.Windows.Forms.Padding(3);
            this.tabData.Size = new System.Drawing.Size(838, 466);
            this.tabData.TabIndex = 1;
            this.tabData.Text = "Data";
            // 
            // tabAuthors
            // 
            this.tabAuthors.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabAuthors.Location = new System.Drawing.Point(4, 4);
            this.tabAuthors.Name = "tabAuthors";
            this.tabAuthors.Padding = new System.Windows.Forms.Padding(3);
            this.tabAuthors.Size = new System.Drawing.Size(838, 466);
            this.tabAuthors.TabIndex = 2;
            this.tabAuthors.Text = "Authors";
            // 
            // tabR
            // 
            this.tabR.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabR.Controls.Add(this.pnlBrowser);
            this.tabR.Location = new System.Drawing.Point(4, 4);
            this.tabR.Name = "tabR";
            this.tabR.Padding = new System.Windows.Forms.Padding(3);
            this.tabR.Size = new System.Drawing.Size(838, 466);
            this.tabR.TabIndex = 3;
            this.tabR.Text = "R Studio";
            // 
            // pnlBrowser
            // 
            this.pnlBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBrowser.Location = new System.Drawing.Point(3, 3);
            this.pnlBrowser.Name = "pnlBrowser";
            this.pnlBrowser.Size = new System.Drawing.Size(832, 460);
            this.pnlBrowser.TabIndex = 2;
            // 
            // tabSetup
            // 
            this.tabSetup.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabSetup.Location = new System.Drawing.Point(4, 4);
            this.tabSetup.Name = "tabSetup";
            this.tabSetup.Padding = new System.Windows.Forms.Padding(3);
            this.tabSetup.Size = new System.Drawing.Size(838, 466);
            this.tabSetup.TabIndex = 4;
            this.tabSetup.Text = "Setup";
            // 
            // tabRScripts
            // 
            this.tabRScripts.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabRScripts.Location = new System.Drawing.Point(4, 4);
            this.tabRScripts.Name = "tabRScripts";
            this.tabRScripts.Size = new System.Drawing.Size(838, 466);
            this.tabRScripts.TabIndex = 5;
            this.tabRScripts.Text = "R Scripts";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(971, 474);
            this.Controls.Add(this.tabControlMain);
            this.MinimumSize = new System.Drawing.Size(979, 501);
            this.Name = "MainForm";
            this.Text = "Biology Project Database";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControlMain.ResumeLayout(false);
            this.tabR.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabExperiments;
        private System.Windows.Forms.TabPage tabData;
        private System.Windows.Forms.TabPage tabAuthors;
        private System.Windows.Forms.TabPage tabR;
        private System.Windows.Forms.TabPage tabSetup;
        private System.Windows.Forms.Panel pnlBrowser;
        private System.Windows.Forms.TabPage tabRScripts;

    }
}