namespace BiologyDepartment
{
    partial class ctlAuthors
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gbAuthors = new System.Windows.Forms.GroupBox();
            this.btnEditAuthor = new System.Windows.Forms.Button();
            this.btnAddAuthor = new System.Windows.Forms.Button();
            this.lblDept = new System.Windows.Forms.Label();
            this.lblAff = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblMI = new System.Windows.Forms.Label();
            this.lblFName = new System.Windows.Forms.Label();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.lblLName = new System.Windows.Forms.Label();
            this.txtAffliation = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtMI = new System.Windows.Forms.TextBox();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.picAuthors = new System.Windows.Forms.PictureBox();
            this.dgAuthorEx = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.gbAuthors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAuthors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAuthorEx)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgAuthorEx);
            this.splitContainer1.Size = new System.Drawing.Size(1180, 697);
            this.splitContainer1.SplitterDistance = 520;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gbAuthors);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.picAuthors);
            this.splitContainer2.Size = new System.Drawing.Size(520, 697);
            this.splitContainer2.SplitterDistance = 329;
            this.splitContainer2.TabIndex = 31;
            // 
            // gbAuthors
            // 
            this.gbAuthors.Controls.Add(this.btnEditAuthor);
            this.gbAuthors.Controls.Add(this.btnAddAuthor);
            this.gbAuthors.Controls.Add(this.lblDept);
            this.gbAuthors.Controls.Add(this.lblAff);
            this.gbAuthors.Controls.Add(this.lblEmail);
            this.gbAuthors.Controls.Add(this.lblMI);
            this.gbAuthors.Controls.Add(this.lblFName);
            this.gbAuthors.Controls.Add(this.txtDepartment);
            this.gbAuthors.Controls.Add(this.lblLName);
            this.gbAuthors.Controls.Add(this.txtAffliation);
            this.gbAuthors.Controls.Add(this.txtEmail);
            this.gbAuthors.Controls.Add(this.txtMI);
            this.gbAuthors.Controls.Add(this.txtFName);
            this.gbAuthors.Controls.Add(this.txtLName);
            this.gbAuthors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAuthors.Location = new System.Drawing.Point(0, 0);
            this.gbAuthors.Name = "gbAuthors";
            this.gbAuthors.Size = new System.Drawing.Size(520, 329);
            this.gbAuthors.TabIndex = 31;
            this.gbAuthors.TabStop = false;
            // 
            // btnEditAuthor
            // 
            this.btnEditAuthor.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnEditAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditAuthor.Location = new System.Drawing.Point(117, 14);
            this.btnEditAuthor.Name = "btnEditAuthor";
            this.btnEditAuthor.Size = new System.Drawing.Size(105, 55);
            this.btnEditAuthor.TabIndex = 19;
            this.btnEditAuthor.Text = "Edit Author";
            this.btnEditAuthor.UseVisualStyleBackColor = false;
            this.btnEditAuthor.Click += new System.EventHandler(this.btnEditAuthor_Click);
            // 
            // btnAddAuthor
            // 
            this.btnAddAuthor.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnAddAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAuthor.Location = new System.Drawing.Point(6, 14);
            this.btnAddAuthor.Name = "btnAddAuthor";
            this.btnAddAuthor.Size = new System.Drawing.Size(105, 55);
            this.btnAddAuthor.TabIndex = 14;
            this.btnAddAuthor.Text = "Add Author";
            this.btnAddAuthor.UseVisualStyleBackColor = false;
            this.btnAddAuthor.Click += new System.EventHandler(this.btnAddAuthor_Click);
            // 
            // lblDept
            // 
            this.lblDept.AutoSize = true;
            this.lblDept.Location = new System.Drawing.Point(4, 243);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(62, 13);
            this.lblDept.TabIndex = 12;
            this.lblDept.Text = "Department";
            this.lblDept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAff
            // 
            this.lblAff.AutoSize = true;
            this.lblAff.Location = new System.Drawing.Point(17, 210);
            this.lblAff.Name = "lblAff";
            this.lblAff.Size = new System.Drawing.Size(49, 13);
            this.lblAff.TabIndex = 11;
            this.lblAff.Text = "Affiliation";
            this.lblAff.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(34, 177);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "Email";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMI
            // 
            this.lblMI.AutoSize = true;
            this.lblMI.Location = new System.Drawing.Point(47, 144);
            this.lblMI.Name = "lblMI";
            this.lblMI.Size = new System.Drawing.Size(19, 13);
            this.lblMI.TabIndex = 9;
            this.lblMI.Text = "MI";
            this.lblMI.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFName
            // 
            this.lblFName.AutoSize = true;
            this.lblFName.Location = new System.Drawing.Point(9, 111);
            this.lblFName.Name = "lblFName";
            this.lblFName.Size = new System.Drawing.Size(57, 13);
            this.lblFName.TabIndex = 8;
            this.lblFName.Text = "First Name";
            this.lblFName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDepartment
            // 
            this.txtDepartment.Enabled = false;
            this.txtDepartment.Location = new System.Drawing.Point(72, 240);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(210, 20);
            this.txtDepartment.TabIndex = 7;
            // 
            // lblLName
            // 
            this.lblLName.AutoSize = true;
            this.lblLName.Location = new System.Drawing.Point(8, 78);
            this.lblLName.Name = "lblLName";
            this.lblLName.Size = new System.Drawing.Size(58, 13);
            this.lblLName.TabIndex = 6;
            this.lblLName.Text = "Last Name";
            this.lblLName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAffliation
            // 
            this.txtAffliation.Enabled = false;
            this.txtAffliation.Location = new System.Drawing.Point(72, 207);
            this.txtAffliation.Name = "txtAffliation";
            this.txtAffliation.Size = new System.Drawing.Size(210, 20);
            this.txtAffliation.TabIndex = 5;
            // 
            // txtEmail
            // 
            this.txtEmail.Enabled = false;
            this.txtEmail.Location = new System.Drawing.Point(72, 174);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(210, 20);
            this.txtEmail.TabIndex = 4;
            // 
            // txtMI
            // 
            this.txtMI.Enabled = false;
            this.txtMI.Location = new System.Drawing.Point(72, 141);
            this.txtMI.Name = "txtMI";
            this.txtMI.Size = new System.Drawing.Size(56, 20);
            this.txtMI.TabIndex = 3;
            // 
            // txtFName
            // 
            this.txtFName.Enabled = false;
            this.txtFName.Location = new System.Drawing.Point(72, 108);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(176, 20);
            this.txtFName.TabIndex = 2;
            // 
            // txtLName
            // 
            this.txtLName.Enabled = false;
            this.txtLName.Location = new System.Drawing.Point(72, 75);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(176, 20);
            this.txtLName.TabIndex = 1;
            // 
            // picAuthors
            // 
            this.picAuthors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAuthors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picAuthors.Location = new System.Drawing.Point(0, 0);
            this.picAuthors.Name = "picAuthors";
            this.picAuthors.Size = new System.Drawing.Size(520, 364);
            this.picAuthors.TabIndex = 1;
            this.picAuthors.TabStop = false;
            // 
            // dgAuthorEx
            // 
            this.dgAuthorEx.AllowUserToAddRows = false;
            this.dgAuthorEx.AllowUserToDeleteRows = false;
            this.dgAuthorEx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAuthorEx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgAuthorEx.Location = new System.Drawing.Point(0, 0);
            this.dgAuthorEx.MultiSelect = false;
            this.dgAuthorEx.Name = "dgAuthorEx";
            this.dgAuthorEx.ReadOnly = true;
            this.dgAuthorEx.Size = new System.Drawing.Size(656, 697);
            this.dgAuthorEx.TabIndex = 31;
            // 
            // ctlAuthors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ctlAuthors";
            this.Size = new System.Drawing.Size(1180, 697);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.gbAuthors.ResumeLayout(false);
            this.gbAuthors.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAuthors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAuthorEx)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgAuthorEx;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox gbAuthors;
        private System.Windows.Forms.Button btnEditAuthor;
        private System.Windows.Forms.Button btnAddAuthor;
        private System.Windows.Forms.Label lblDept;
        private System.Windows.Forms.Label lblAff;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblMI;
        private System.Windows.Forms.Label lblFName;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.Label lblLName;
        private System.Windows.Forms.TextBox txtAffliation;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtMI;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.PictureBox picAuthors;
    }
}
