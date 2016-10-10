namespace BiologyDepartment
{
    partial class ctlRBaseFunctions
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
            this.tvRBaseFunctions = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // tvRBaseFunctions
            // 
            this.tvRBaseFunctions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvRBaseFunctions.CheckBoxes = true;
            this.tvRBaseFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvRBaseFunctions.Location = new System.Drawing.Point(0, 0);
            this.tvRBaseFunctions.Name = "tvRBaseFunctions";
            this.tvRBaseFunctions.ShowNodeToolTips = true;
            this.tvRBaseFunctions.Size = new System.Drawing.Size(514, 489);
            this.tvRBaseFunctions.TabIndex = 1;
            this.tvRBaseFunctions.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvRBaseFunctions_AfterCheck);
            // 
            // ctlRBaseFunctions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tvRBaseFunctions);
            this.Name = "ctlRBaseFunctions";
            this.Size = new System.Drawing.Size(514, 489);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvRBaseFunctions;

    }
}
