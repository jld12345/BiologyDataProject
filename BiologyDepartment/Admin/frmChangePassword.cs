using System.Windows.Forms;
using Syncfusion.Windows.Forms.HTMLUI;

namespace BiologyDepartment.Admin
{
    public partial class frmChangePassword : Form
    {
        #region Private Variables
        #endregion
        public frmChangePassword()
        {
            InitializeComponent();
            var browser = new WebBrowser();//new CefSharp.WinForms.ChromiumWebBrowser("http://dwbtechnologies.ddns.net:8888");
            browser.Navigate(GlobalVariables.PasswordConnection);
            panel1.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
        }

    }
}
