using System;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using BiologyDepartment.Admin;

namespace BiologyDepartment
{
    public partial class ctlLogIn : UserControl
    {
        private DataSet dataset = new DataSet();
        private DataTable table = new DataTable();
        private ActiveDirectory _daoAD = new ActiveDirectory();

        public bool bExitProgram = false;

        public event EventHandler<ValidLoginEventArgs> RaiseLoginEvent;

        public ctlLogIn()
        {
            InitializeComponent();
            this.Anchor = AnchorStyles.None;
            GlobalVariables.GlobalConnection = new DbBioConnection();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string sReturn = _daoAD.ValidateCredentials(txtUserName2.Text, txtPWord.Text);
            if(sReturn.Equals("Null Principal Context") || sReturn.Equals("Stupid Connection"))
            {
                MessageBox.Show("There was an error connecting to verification source.  If this problem persists, please contact your System Administrator.", "Connection Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(sReturn.Equals("true"))
            {
                this.Parent.Hide();
                GlobalVariables.ADUserName = _daoAD.ADUserName;
                GlobalVariables.ADPass = _daoAD.ADPass;
                GlobalVariables.dbPass = _daoAD.DBPass;
                GlobalVariables.dbUser = _daoAD.DBUser;
                GlobalVariables.ADUserGroup = _daoAD.ADUserGroup;

            }
            else
                MessageBox.Show("Username or Password incorrect.", "Username/Password Error", MessageBoxButtons.OK);
            sw.Stop();
            Trace.WriteLine("Login time:  " + sw.Elapsed.TotalSeconds.ToString());
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
                btnLogin2.PerformClick();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            bExitProgram = true;
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using(frmChangePassword frm = new frmChangePassword())
            {
                frm.ShowDialog();
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
