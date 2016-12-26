using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms.Tools;

namespace BiologyDepartment.R_Scripts
{
    public partial class CtlApiCalls2 : UserControl
    {
        #region Private Variables
        private DataSet dsRScripts;
        private RDao rDAO = new RDao();
        private List<string> lstApiCalls;
        private List<string> lstApiRespone;
        private bool bIsInitialized = false;
        private bool bLoadingData = false;
        private HttpClient httpClient;
        #endregion

        #region Public Variables
        public Task taskLoad;
        #endregion

        public CtlApiCalls2()
        {
            InitializeComponent();
            httpClient = new HttpClient();
        }

        public void Initialize()
        {
            LoadData();
            LoadGui();
            bIsInitialized = true;
        }

        private void LoadData()
        {
            dsRScripts = rDAO.GetRScripts();
            dgRScripts.DataSource = dsRScripts.Tables[0];
            dgRScripts.EnableAddNew = false;
            if (bIsInitialized)
                return;
            GridBoundColumn temp;
            GridBoundColumnsCollection cols = dgRScripts.GridBoundColumns;
            if(!cols.Contains("r_scripts_id"))
            {
                temp = new GridBoundColumn()
                {
                    MappingName = "r_scripts_id",
                    Hidden = true
                };
                dgRScripts.GridBoundColumns.Add(temp);
            }
            if (!cols.Contains("r_scripts_title"))
            {
                temp = new GridBoundColumn()
                {
                    MappingName = "r_scripts_title",
                    HeaderText = "R Script"
                };
                dgRScripts.GridBoundColumns.Add(temp);
            }
            if (!cols.Contains("r_scripts_body"))
            {
                temp = new GridBoundColumn()
                {
                    MappingName = "r_scripts_body"
                };
                dgRScripts.GridBoundColumns.Add(temp);
            }
            if (!cols.Contains("info_btn"))
            {
                temp = new GridBoundColumn()
                {
                    MappingName = "info_btn",
                    HeaderText = "Info"
                };
                temp.StyleInfo.CellType = "PushButton";
                temp.StyleInfo.ImageList = GlobalVariables.Images;
                temp.StyleInfo.ImageIndex =1;
                temp.Width = 50;
                dgRScripts.GridBoundColumns.Add(temp);
            }
            if (!cols.Contains("execute_btn"))
            {
                temp = new GridBoundColumn()
                {
                    MappingName = "execute_btn",
                    HeaderText = "Execute"
                };
                temp.StyleInfo.CellType = "PushButton";
                temp.StyleInfo.ImageList = GlobalVariables.Images;
                temp.StyleInfo.ImageIndex =3;
                temp.Width = 50;
                dgRScripts.GridBoundColumns.Add(temp);
            }
            dgRScripts.Model.Cols.MoveRange(4, 2, 1);
            dgRScripts.Model.Cols.MoveRange(4, 1, 3);
            dgRScripts.Model.Cols.Hidden.SetRange(4, 5, true);
            dgRScripts.Binder.InitializeColumns();
            dgRScripts.Model.ColWidths[3] = 300;
        }

        public async Task InitializePageAsync()
        {
            string uri = "http://192.168.0.19/ocpu/user/james/library/ApiCalls/R/";
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                lstApiCalls = result.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }

            bIsInitialized = true;
        }

        public async Task PostRScriptAsync(string jsonData)
        {
            string rCall = "";
            string uri = "http://192.168.0.19/ocpu/user/james/library/ApiCalls/R/" + rCall;
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(uri, jsonData);
            response.EnsureSuccessStatusCode();
            var temp = response.Headers.Location;
        }


        public void LoadGui()
        {
            cmbDependent.Items.Clear();
            clbIndependent.Items.Clear();
            clbFactor.Items.Clear();
            if(GlobalVariables.CustomColumns == null)
                GlobalVariables.CustomColumns = GlobalVariables.GlobalConnection.GetColumns();

            foreach(CustomColumns c in GlobalVariables.CustomColumns)
            {
                cmbDependent.Items.Add(c.ColName);
                clbIndependent.Items.Add(c.ColName);
                clbFactor.Items.Add(c.ColName);
            }
        }

        private void CallFunction(string rCall)
        {
            tcRScripts.TabPages.Clear();
            string url = "http://192.168.0.19/ocpu/user/james/library/ApiCalls/R/" + rCall;
            string jsonData = "";
            string postData = "";
            DataTable theData = new DataTable();
            DataSet ds = new DataSet();
            if (GlobalVariables.ExperimentData.JSONTable != null)
            {
                DataTable dtCopy = GlobalVariables.ExperimentData.JSONTable.Copy();
                //dtCopy.Columns.Add("dependentVariable");
                //dtCopy.Columns.Add("independentVariables");
                dtCopy.DefaultView.RowFilter = GlobalVariables.ExperimentGrid._bindingSource.Filter;
                theData = dtCopy.DefaultView.ToTable();
                theData.TableName = "jsonDataset";
                foreach (DataColumn col in theData.Columns)
                    theData.Columns[col.ColumnName].ColumnName = col.ColumnName.Replace(' ', '.');
                theData.AcceptChanges();
                ds.Tables.Add(theData);
       
                jsonData = JsonConvert.SerializeObject(ds, Formatting.Indented);
            }

            switch (rCall)
            {
                case "drawResidualPlotJSON":
                    postData = "jsonDataset=" + jsonData + "&dependentVariable='" + cmbDependent.SelectedItem.ToString().ToUpper().Replace(' ', '.') + "'";
                    string temp = "";
                    foreach(var item in clbIndependent.CheckedItems)
                    {
                        temp += item.ToString() + ",";
                    }
                    postData += "&independentVariables='" + temp.ToUpper().Replace(' ', '.').TrimEnd(',') + "'";
                    break;
                case "DTKTest":
                    postData = "dataset=" + jsonData + "&dependentVariable='wt_weight'&independentVariable='Fat'";
                    break;
            }
            var content = new StringContent(
                    postData,
                    Encoding.UTF8,
                    "application/x-www-form-urlencoded");
            using (var response = httpClient.PostAsync(url, content).Result)
            {
                using (HttpContent responseContent = response.Content)
                {
                    var result = responseContent.ReadAsStringAsync();
                    lstApiRespone = result.Result.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                }
            }

            foreach (string s in lstApiRespone)
            {
                int count = 0;
                if (s.Contains("console"))
                {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
                    TabPageAdv page = new TabPageAdv();
                    WebBrowser browser = new WebBrowser()
                    {
                        Dock = DockStyle.Fill
                    };
                    page.Controls.Add(browser);
                    page.Dock = DockStyle.Fill;
                    page.Text = "Console Output";
                    browser.Navigate("http://192.168.0.19" + s);
                    tcRScripts.TabPages.Insert(0, page);
                }
                if (s.Contains("graphics"))
                {
                    TabPageAdv page = new TabPageAdv();
                    WebBrowser browser = new WebBrowser()
                    {
                        Dock = DockStyle.Fill
                    };
                    page.Controls.Add(browser);
                    page.Dock = DockStyle.Fill;
                    page.Text = "Graphic " + count.ToString();
                    string width = (splitContainer1.Panel2.Width - 100).ToString();
                    string height = (splitContainer1.Panel2.Height - 100).ToString();
                    browser.Navigate("http://192.168.0.19" + s + "//png?width=" + width + "&height=" + height);
                    tcRScripts.TabPages.Add(page);
                    count++;
                }

            }
            tcRScripts.Refresh();
        }

        private void GetApiCallResults(string sApiCall)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string uri = "http://192.168.0.19" + sApiCall;
                var response = httpClient.GetAsync(uri);
                var result = response.Result;
                var content = result.Content.ReadAsStreamAsync();
                content.Result.Position = 0;
                var sr = new StreamReader(content.Result);
                var myStr = sr.ReadToEnd();
                Console.WriteLine(myStr);

                /*using (HttpContent responseContent = response.Content)
                {
                    var result = responseContent.ReadAsStringAsync();
                    lstApiCalls = result.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                }*/

            }
        }

        private void DgRScripts_Layout(object sender, LayoutEventArgs e)
        {
        }

        private void DgRScripts_CellButtonClicked(object sender, GridCellButtonClickedEventArgs e)
        {
            CurrencyManager cm = (CurrencyManager)BindingContext[dgRScripts.DataSource, dgRScripts.DataMember];
            DataView dv = (DataView)cm.List;
            DataRow row = dv[e.RowIndex - 1].Row;
            if(e.ColIndex == 1)
            {
                MessageBox.Show(Convert.ToString(row["r_scripts_body"]), "Script Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(e.ColIndex == 2)
            {
                string call = Convert.ToString(row["r_scripts_title"]);
                CallFunction(call);
            }
        }
    }
}
