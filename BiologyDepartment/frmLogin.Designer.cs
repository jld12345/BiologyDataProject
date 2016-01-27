namespace BiologyDepartment
{
    partial class frmLogin
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
            this.txtUserName2 = new System.Windows.Forms.TextBox();
            this.txtPWord = new System.Windows.Forms.TextBox();
            this.lblUserName2 = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // txtUserName2
            // 
            this.txtUserName2.Location = new System.Drawing.Point(92, 74);
            this.txtUserName2.Name = "txtUserName2";
            this.txtUserName2.Size = new System.Drawing.Size(185, 20);
            this.txtUserName2.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtUserName2, "Please enter User Name.");
            // 
            // txtPWord
            // 
            this.txtPWord.Location = new System.Drawing.Point(92, 136);
            this.txtPWord.Name = "txtPWord";
            this.txtPWord.Size = new System.Drawing.Size(185, 20);
            this.txtPWord.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtPWord, "Please Enter Password.");
            this.txtPWord.PasswordChar = '*';
            // 
            // lblUserName2
            // 
            this.lblUserName2.AutoSize = true;
            this.lblUserName2.Location = new System.Drawing.Point(92, 55);
            this.lblUserName2.Name = "lblUserName2";
            this.lblUserName2.Size = new System.Drawing.Size(60, 13);
            this.lblUserName2.TabIndex = 2;
            this.lblUserName2.Text = "User Name";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(92, 120);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(92, 184);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "LOGIN";
            this.toolTip1.SetToolTip(this.btnLogin, "Click to login to Database.");
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(202, 184);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "CANCEL";
            this.toolTip1.SetToolTip(this.btnCancel, "Click to clear User Name and Password.");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmLogin
            // 
            this.ClientSize = new System.Drawing.Size(387, 273);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName2);
            this.Controls.Add(this.txtPWord);
            this.Controls.Add(this.txtUserName2);
            this.Name = "frmLogin";
            this.Text = "Biology Department Login";

            //event handlers
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmLogin_Close);
            this.btnLogin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckEnter);
            this.txtPWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckEnter);

            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserName2;
        private System.Windows.Forms.TextBox txtPWord;
        private System.Windows.Forms.Label lblUserName2;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolTip toolTip1;

    }
    
}

