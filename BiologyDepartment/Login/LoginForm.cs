using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiologyDepartment.Login
{
    public partial class LoginForm : Form
    {
        private ctlLogIn login = new ctlLogIn();
        public LoginForm()
        {
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            login.Dock = DockStyle.Fill;
            this.Controls.Add(login);
            login.Show();
        }
    }
}
