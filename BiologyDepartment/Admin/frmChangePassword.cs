using System.Windows.Forms;

namespace BiologyDepartment.Admin
{
    public partial class frmChangePassword : Form
    {
        #region Private Variables
        private ActiveDirectory _daoAD = new ActiveDirectory();
        #endregion
        public frmChangePassword()
        {
            InitializeComponent();
            var browser = new CefSharp.WinForms.ChromiumWebBrowser(GlobalVariables.PasswordConnection);
            {
                Dock = DockStyle.Fill;
            };
            panel1.Controls.Add(browser);
        }

    }
}
