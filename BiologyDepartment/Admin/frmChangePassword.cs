using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using BiologyDepartment.Active_Directory;

namespace BiologyDepartment.Admin
{
    public partial class frmChangePassword : Form
    {
        #region Private Variables
        private DaoActiveDirectory _daoAD = new DaoActiveDirectory();
        #endregion
        public frmChangePassword()
        {
            InitializeComponent();
            var browser = new CefSharp.WinForms.ChromiumWebBrowser("http://dwbtechnologies.ddns.net:8888");
            {
                Dock = DockStyle.Fill;
            };
            panel1.Controls.Add(browser);
        }

    }
}
