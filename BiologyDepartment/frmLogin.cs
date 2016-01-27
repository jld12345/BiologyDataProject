using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BiologyDepartment
{
    public partial class frmLogin : Form
    {
        private static frmLogin inst;
        private DataSet dataset = new DataSet();
        private DataTable table = new DataTable();
        daoActiveDirectory _daoActiveDirectory = new daoActiveDirectory();
        
        protected frmLogin()
        {
            InitializeComponent();
        }

        public static frmLogin CreateInstance()
        {

            {
                if (inst == null || inst.IsDisposed)
                {
                    inst = new frmLogin();
                }
                return inst;
            }


        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (_daoActiveDirectory.ValidateCredentials(txtUserName2.Text, txtPWord.Text))
            {
                this.Close();
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

        /// <summary>
        /// Open Experiments form on closing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void frmLogin_Close(object sender, EventArgs e)
        {
            /*if (string.IsNullOrEmpty(txtPWord.Text) || string.IsNullOrEmpty(txtUserName2.Text))
                Application.Exit();
            else
            {
                ((MainForm)this.MdiParent).openExper(txtUserName2.Text, txtPWord.Text);
            }*/
        }
        
        /// <summary>
        /// Perform click if enter is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnLogin.PerformClick();
            }
        }

    }
}
