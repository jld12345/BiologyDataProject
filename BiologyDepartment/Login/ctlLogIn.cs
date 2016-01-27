using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiologyDepartment
{
    public partial class ctlLogIn : UserControl
    {
        private DataSet dataset = new DataSet();
        private DataTable table = new DataTable();
        daoActiveDirectory _daoActiveDirectory = new daoActiveDirectory();

        public event EventHandler<ValidLoginEventArgs> RaiseLoginEvent;

        public ctlLogIn()
        {
            InitializeComponent();
            this.Anchor = AnchorStyles.None;
            GlobalVariables.GlobalConnection = new dbBioConnection();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (_daoActiveDirectory.ValidateCredentials(txtUserName2.Text, txtPWord.Text))
            {
                OnRaiseLoginEvent(new ValidLoginEventArgs(true));
                this.btnLogin.Click -= this.btnLogin_Click;
                this.btnCancel.Click -= this.btnCancel_Click;
            }
            else
                MessageBox.Show("Username or Password incorrect.", "Username/Password Error", MessageBoxButtons.OK);
        }

        /// <summary>
        /// Clear text boxes if username and password are incorrect.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUserName2.Clear();
            txtPWord.Clear();
            txtUserName2.Focus();
        }

        protected virtual void OnRaiseLoginEvent(ValidLoginEventArgs e)
        {
            EventHandler<ValidLoginEventArgs> handler = RaiseLoginEvent;

            // Event will be null if there are no subscribers 
            if (handler != null)
            {
                // Use the () operator to raise the event.
                handler(this, e);
            }
        }

        private void ctlLogIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnLogin.PerformClick();
            }
        }

    }

    public class ValidLoginEventArgs : EventArgs
    {
        public ValidLoginEventArgs(bool isValid)
        {
            ValidLogin = isValid;
        }
        private bool ValidLogin;
        public bool IsValid
        {
            get { return ValidLogin; }
        }
    }

}
