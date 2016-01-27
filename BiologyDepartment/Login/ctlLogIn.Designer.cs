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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName2 = new System.Windows.Forms.Label();
            this.txtPWord = new System.Windows.Forms.TextBox();
            this.txtUserName2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCancel.Location = new System.Drawing.Point(204, 195);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnLogin.Location = new System.Drawing.Point(94, 195);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(94, 131);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 9;
            this.lblPassword.Text = "Password";
            // 
            // lblUserName2
            // 
            this.lblUserName2.AutoSize = true;
            this.lblUserName2.Location = new System.Drawing.Point(94, 66);
            this.lblUserName2.Name = "lblUserName2";
            this.lblUserName2.Size = new System.Drawing.Size(60, 13);
            this.lblUserName2.TabIndex = 7;
            this.lblUserName2.Text = "User Name";
            // 
            // txtPWord
            // 
            this.txtPWord.Location = new System.Drawing.Point(94, 147);
            this.txtPWord.Name = "txtPWord";
            this.txtPWord.PasswordChar = '*';
            this.txtPWord.Size = new System.Drawing.Size(185, 20);
            this.txtPWord.TabIndex = 5;
            this.txtPWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ctlLogIn_KeyPress);
            // 
            // txtUserName2
            // 
            this.txtUserName2.Location = new System.Drawing.Point(94, 85);
            this.txtUserName2.Name = "txtUserName2";
            this.txtUserName2.Size = new System.Drawing.Size(185, 20);
            this.txtUserName2.TabIndex = 4;
            this.txtUserName2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ctlLogIn_KeyPress);
            // 
            // ctlLogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName2);
            this.Controls.Add(this.txtPWord);
            this.Controls.Add(this.txtUserName2);
            this.Name = "ctlLogIn";
            this.Size = new System.Drawing.Size(368, 280);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ctlLogIn_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName2;
        private System.Windows.Forms.TextBox txtPWord;
        private System.Windows.Forms.TextBox txtUserName2;
    }
}
