using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ActiveDirectory;

namespace BiologyDepartment
{
    public partial class UserPermissions : Form
    {
        private static UserPermissions inst;
        private int exID = 0;
        private daoEXPermissions _permissions = new daoEXPermissions();
        private DataTable dtUser;
        private ActiveDirectory.daoActiveDirectory _daoAD = new ActiveDirectory.daoActiveDirectory();
        private bool isAdding = false;

        public UserPermissions()
        {
            InitializeComponent();
        }

        public UserPermissions(int id)
        {
            InitializeComponent();
            exID = id;
            LoadUsers(id);
            _daoAD.SetPrincipalContext(GlobalVariables.ADUserName, GlobalVariables.ADPass, GlobalVariables.ActiveDirectoryConnection);
        }

        public static UserPermissions CreateInstance()
        {
            if (inst == null || inst.IsDisposed)
            {
                inst = new UserPermissions();
            }
            else
            {
                MessageBox.Show("An Instance of the Permissions Form is already open.", "Form Open", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return inst;
        }

        public static UserPermissions CreateInstance(int id)
        {
            if (inst == null || inst.IsDisposed)
            {
                inst = new UserPermissions(id);
            }
            else
            {
                MessageBox.Show("An Instance of the Permissions Form is already open.", "Form Open", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return inst;
        }

        private void LoadUsers(int id)
        {
            DataSet ds = _permissions.GetPermissions(id);

            if (ds.Tables.Count > 0)
                dtUser = ds.Tables[0];
            else
                return;

            dgUsers.DataSource = dtUser;
            
        }

        private void dgUsers_SelectionChanged(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dgUsers.SelectedRows)
            {
                txtUserName.Text = row.Cells["USER_NAME"].Value.ToString();
                cmbPermissions.SelectedItem = row.Cells["ACCESS_TYPE"].Value;
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            cmbPermissions.SelectedItem = 0;
            isAdding = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            _permissions.DeletePermission(exID, txtUserName.Text);
            LoadUsers(exID);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_daoAD.IsUserExisiting(txtUserName.Text))
            {
                if (!isAdding)
                    _permissions.UpdatePermissions(exID, txtUserName.Text, cmbPermissions.SelectedItem.ToString());
                else
                    _permissions.insertPermissions(exID, txtUserName.Text, cmbPermissions.SelectedItem.ToString());

                LoadUsers(exID);
            }
            else
            {
                MessageBox.Show(txtUserName.Text + " does not exist in Active Directory", "Invalid User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Text = "";
                cmbPermissions.SelectedItem = 0;
            }
            isAdding = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadUsers(exID);
            isAdding = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
