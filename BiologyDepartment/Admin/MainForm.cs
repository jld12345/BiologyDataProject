using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Permissions;
using Microsoft.Win32;
using CefSharp;
using CefSharp.WinForms;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
using RDotNet;

namespace BiologyDepartment
{

    public partial class MainForm : Form
    {
        ctlLogIn _ctlLogin = new ctlLogIn();
        ctlExperiments _ctlExperiments;
        ctlAnimalData _ctlAnimalData;
        ctlAuthors _ctlAuthors;
        ctlRScripts _ctlRScripts;
        ctlSetup _ctlSetup;
        private int EX_ID = 0;
        private bool bDataControlDirty = true;
        private bool bAuthorControlDirty = true;
        private bool bSetupControlDirty = true;

        public delegate void MyDelegate();
        [DllImport("user32.dll")]
        private static extern long SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        public MainForm()
        {
            try
            {
                GlobalVariables.GlobalConnection = new dbBioConnection();
                this.Controls.Add(_ctlLogin);
                this._ctlLogin.Parent = this;
                InitializeComponent();
                _ctlLogin.RaiseLoginEvent += LoginEventHandler;
                _ctlLogin.Location = new System.Drawing.Point(this.Width / 2 - _ctlLogin.Width / 2, this.Height / 2 - _ctlLogin.Height / 2);
                this.Controls.Add(tabControlMain);
                AddTabControls();
                this.tabControlMain.Hide();
                this._ctlLogin.BringToFront();

            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                return;
            }

        }

        private void LoginEventHandler(object sender, ValidLoginEventArgs e)
        {
            this.Controls.Remove(_ctlLogin);
            _ctlExperiments.ChangeExperimentEvent += ExperimentChangesTabsEvents;
            _ctlExperiments.Intialize();
            this.tabControlMain.Show();
            _ctlLogin.RaiseLoginEvent -= LoginEventHandler;
        }

        private void AddTabControls()
        {
            foreach(TabPage page in tabControlMain.TabPages)
            {
                switch(page.Name)
                {
                    case "tabExperiments":
                        _ctlExperiments = new ctlExperiments();
                        _ctlExperiments.Parent = tabExperiments;
                        pnlTabExperiment.Controls.Add(_ctlExperiments);
                        _ctlExperiments.Dock = DockStyle.Fill;
                        break;
                    case "tabData":
                        _ctlAnimalData = new ctlAnimalData();
                        tabData.Controls.Add(_ctlAnimalData);
                        _ctlAnimalData.Dock = DockStyle.Fill;
                        //_ctlAnimalData.CloseFormEvent += CloseAnimalDataEventHandler;
                        break;
                    case "tabR":
                        var browser = new CefSharp.WinForms.ChromiumWebBrowser(BiologyDepartment.Properties.Settings.Default.MyRStudio);   
                    //var browser = new CefSharp.WinForms.ChromiumWebBrowser("http:71.45.10.32:1521")
                        {
                            Dock = DockStyle.Fill;
                        };
                        
                        pnlBrowser.Controls.Add(browser);
                        break;
                    case "tabAuthors":
                        _ctlAuthors = new ctlAuthors();
                        tabAuthors.Controls.Add(_ctlAuthors);
                        //_ctlAuthors.Dock = DockStyle.Fill;
                        break;
                    case "tabRScripts":
                        _ctlRScripts = new ctlRScripts();
                        tabRScripts.Controls.Add(_ctlRScripts);
                        //_ctlRScripts.Dock = DockStyle.Fill;
                        break;
                    case "tabSetup":
                        _ctlSetup = new ctlSetup();
                        tabSetup.Controls.Add(_ctlSetup);
                        //_ctlSetup.Dock = DockStyle.Fill;
                        break;
                }
                
            }
        }

        private void ExperimentChangesTabsEvents(object sender, ExperimentHasChanged e)
        {
            if (EX_ID != e.ID)
            {
                EX_ID = e.ID;
                bDataControlDirty = true;
                bAuthorControlDirty = true;
            }
        }

        private void tabControlMain_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;
 
            // Get the item from the collection.
            TabPage _tabPage = tabControlMain.TabPages[e.Index];
            
            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabControlMain.GetTabRect(e.Index);
            if (e.State == DrawItemState.Selected)
            {
 
                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Red);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }
 
            // Use our own font.
            Font _tabFont = new Font("Arial", (float)16.0, FontStyle.Bold, GraphicsUnit.Pixel);
 
            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControlMain.SelectedTab.Name)
            {
                case "tabData":
                    if (bDataControlDirty)
                    {
                        this.BeginInvoke(new MyDelegate(LoadData));
                        bDataControlDirty = false;
                    }
                    break;
                case "tabAuthors":
                    if (bAuthorControlDirty)
                    {
                        this.BeginInvoke(new MyDelegate(LoadAuthors));
                        bAuthorControlDirty = false;
                    }
                    break;
                case "tabRScripts":
                    _ctlRScripts.Initialize();
                    break;
                case "tabSetup":
                    if (bDataControlDirty)
                    {
                        this.BeginInvoke(new MyDelegate(LoadSetup));
                        bSetupControlDirty = false;
                    }
                    break;
            }
        }

            public void LoadData()
            {
                tabControlMain.TabPages["tabData"].Controls.Remove(_ctlAnimalData);
                _ctlAnimalData.Initialize(EX_ID);
                tabControlMain.TabPages["tabData"].Controls.Add(_ctlAnimalData);
            }

            public void LoadAuthors()
            {
                tabControlMain.TabPages["tabAuthors"].Controls.Remove(_ctlAuthors);
                _ctlAuthors.frmRefresh(GlobalVariables.Experiment.ID);
                tabControlMain.TabPages["tabAuthors"].Controls.Add(_ctlAuthors);
            }

        public void LoadSetup()
        {
            _ctlSetup.LoadData();
            _ctlSetup.LoadGrid();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (tabControlMain.SelectedTab.Name)
            {
                case "tabData":

                    break;
                case "tabAuthors":

                    break;
                case "tabRScripts":
                    
                    break;
                case "tabSetup":
                    if (e.KeyCode == Keys.F5)
                    {
                        LoadSetup();
                    }
                    break;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName.ToUpper().Contains("RSTUDIO"))
                {
                    p.Kill();
                }
            } 
        }

    }
    
}
