namespace BiologyDepartment
{
    partial class frmDataLoading
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
            this.pBarDataLoading = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // pBarDataLoading
            // 
            this.pBarDataLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBarDataLoading.Location = new System.Drawing.Point(0, 0);
            this.pBarDataLoading.Minimum = 1;
            this.pBarDataLoading.Name = "pBarDataLoading";
            this.pBarDataLoading.Size = new System.Drawing.Size(459, 37);
            this.pBarDataLoading.TabIndex = 1;
            this.pBarDataLoading.Value = 1;
            // 
            // frmDataLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 37);
            this.Controls.Add(this.pBarDataLoading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDataLoading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDataLoading";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pBarDataLoading;
    }
}