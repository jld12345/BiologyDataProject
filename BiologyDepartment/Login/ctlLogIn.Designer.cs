namespace BiologyDepartment
{
    partial class ctlLogIn
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
            this.pnlLogin = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.btnExit = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnCancel2 = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnLogin2 = new Syncfusion.Windows.Forms.ButtonAdv();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName2 = new System.Windows.Forms.Label();
            this.txtPWord = new System.Windows.Forms.TextBox();
            this.txtUserName2 = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLogin)).BeginInit();
            this.pnlLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLogin
            // 
            this.pnlLogin.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlLogin.Controls.Add(this.linkLabel1);
            this.pnlLogin.Controls.Add(this.btnExit);
            this.pnlLogin.Controls.Add(this.btnCancel2);
            this.pnlLogin.Controls.Add(this.btnLogin2);
            this.pnlLogin.Controls.Add(this.lblPassword);
            this.pnlLogin.Controls.Add(this.lblUserName2);
            this.pnlLogin.Controls.Add(this.txtPWord);
            this.pnlLogin.Controls.Add(this.txtUserName2);
            this.pnlLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogin.Location = new System.Drawing.Point(0, 0);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(368, 280);
            this.pnlLogin.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.btnExit.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.btnExit.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.Raised;
            this.btnExit.IsBackStageButton = false;
            this.btnExit.Location = new System.Drawing.Point(230, 164);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 20;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCancel2
            // 
            this.btnCancel2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.btnCancel2.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.btnCancel2.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.Raised;
            this.btnCancel2.IsBackStageButton = false;
            this.btnCancel2.Location = new System.Drawing.Point(149, 164);
            this.btnCancel2.Name = "btnCancel2";
            this.btnCancel2.Size = new System.Drawing.Size(75, 23);
            this.btnCancel2.TabIndex = 19;
            this.btnCancel2.Text = "Reset";
            this.btnCancel2.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnLogin2
            // 
            this.btnLogin2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.btnLogin2.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.btnLogin2.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.Raised;
            this.btnLogin2.IsBackStageButton = false;
            this.btnLogin2.Location = new System.Drawing.Point(68, 164);
            this.btnLogin2.Name = "btnLogin2";
            this.btnLogin2.Size = new System.Drawing.Size(75, 23);
            this.btnLogin2.TabIndex = 18;
            this.btnLogin2.Text = "Login";
            this.btnLogin2.Click += new System.EventHandler(this.btnLogin_Click);
            this.btnLogin2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ctlLogIn_KeyPress);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(90, 112);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 17;
            this.lblPassword.Text = "Password";
            // 
            // lblUserName2
            // 
            this.lblUserName2.AutoSize = true;
            this.lblUserName2.Location = new System.Drawing.Point(90, 47);
            this.lblUserName2.Name = "lblUserName2";
            this.lblUserName2.Size = new System.Drawing.Size(60, 13);
            this.lblUserName2.TabIndex = 15;
            this.lblUserName2.Text = "User Name";
            // 
            // txtPWord
            // 
            this.txtPWord.Location = new System.Drawing.Point(90, 128);
            this.txtPWord.Name = "txtPWord";
            this.txtPWord.PasswordChar = '*';
            this.txtPWord.Size = new System.Drawing.Size(185, 20);
            this.txtPWord.TabIndex = 13;
            // 
            // txtUserName2
            // 
            this.txtUserName2.Location = new System.Drawing.Point(90, 66);
            this.txtUserName2.Name = "txtUserName2";
            this.txtUserName2.Size = new System.Drawing.Size(185, 20);
            this.txtUserName2.TabIndex = 12;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(68, 194);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(152, 13);
            this.linkLabel1.TabIndex = 21;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "I don\'t remember my password.";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // ctlLogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.pnlLogin);
            this.Name = "ctlLogIn";
            this.Size = new System.Drawing.Size(368, 280);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ctlLogIn_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pnlLogin)).EndInit();
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.GradientPanel pnlLogin;
        private Syncfusion.Windows.Forms.ButtonAdv btnCancel2;
        private Syncfusion.Windows.Forms.ButtonAdv btnLogin2;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName2;
        private System.Windows.Forms.TextBox txtPWord;
        private System.Windows.Forms.TextBox txtUserName2;
        private Syncfusion.Windows.Forms.ButtonAdv btnExit;
        private System.Windows.Forms.LinkLabel linkLabel1;

    }
}
