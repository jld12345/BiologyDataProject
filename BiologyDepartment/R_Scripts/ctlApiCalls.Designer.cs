namespace BiologyDepartment.R_Scripts
{
    partial class ctlApiCalls
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
            this.spMainLayout = new System.Windows.Forms.SplitContainer();
            this.spLeftLayout = new System.Windows.Forms.SplitContainer();
            this.dgRScripts = new Syncfusion.Windows.Forms.Grid.GridControl();
            ((System.ComponentModel.ISupportInitialize)(this.spMainLayout)).BeginInit();
            this.spMainLayout.Panel1.SuspendLayout();
            this.spMainLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spLeftLayout)).BeginInit();
            this.spLeftLayout.Panel1.SuspendLayout();
            this.spLeftLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRScripts)).BeginInit();
            this.SuspendLayout();
            // 
            // spMainLayout
            // 
            this.spMainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spMainLayout.Location = new System.Drawing.Point(0, 0);
            this.spMainLayout.Name = "spMainLayout";
            // 
            // spMainLayout.Panel1
            // 
            this.spMainLayout.Panel1.Controls.Add(this.spLeftLayout);
            this.spMainLayout.Size = new System.Drawing.Size(1013, 646);
            this.spMainLayout.SplitterDistance = 446;
            this.spMainLayout.TabIndex = 0;
            // 
            // spLeftLayout
            // 
            this.spLeftLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spLeftLayout.Location = new System.Drawing.Point(0, 0);
            this.spLeftLayout.Name = "spLeftLayout";
            this.spLeftLayout.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spLeftLayout.Panel1
            // 
            this.spLeftLayout.Panel1.Controls.Add(this.dgRScripts);
            this.spLeftLayout.Size = new System.Drawing.Size(446, 646);
            this.spLeftLayout.SplitterDistance = 302;
            this.spLeftLayout.TabIndex = 0;
            // 
            // dgRScripts
            // 
            this.dgRScripts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgRScripts.Location = new System.Drawing.Point(0, 0);
            this.dgRScripts.Name = "dgRScripts";
            this.dgRScripts.SerializeCellsBehavior = Syncfusion.Windows.Forms.Grid.GridSerializeCellsBehavior.SerializeAsRangeStylesIntoCode;
            this.dgRScripts.Size = new System.Drawing.Size(446, 302);
            this.dgRScripts.SmartSizeBox = false;
            this.dgRScripts.TabIndex = 0;
            this.dgRScripts.Text = "gridControl1";
            this.dgRScripts.UseRightToLeftCompatibleTextBox = true;
            this.dgRScripts.Layout += new System.Windows.Forms.LayoutEventHandler(this.dgRScripts_Layout);
            // 
            // ctlApiCalls
            // 
            this.Controls.Add(this.spMainLayout);
            this.Name = "ctlApiCalls";
            this.Size = new System.Drawing.Size(1013, 646);
            this.spMainLayout.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spMainLayout)).EndInit();
            this.spMainLayout.ResumeLayout(false);
            this.spLeftLayout.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spLeftLayout)).EndInit();
            this.spLeftLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRScripts)).EndInit();
            this.ResumeLayout(false);
        #endregion
        }
    }
}
