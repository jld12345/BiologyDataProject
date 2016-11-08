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
    public partial class ctlApiCalls : UserControl
    {
        #region Private Variables
        private DataSet dsRScripts;
        private RDao rDAO = new RDao();
        private List<string> lstApiCalls;
        private List<string> lstApiRespone;
        private bool bIsInitialzied = false;
        HttpClient httpClient;
        #endregion
        private SplitContainer spMainLayout;
        private SplitContainer spLeftLayout;
        private GridControl dgRScripts;

        #region Public Variables
        public Task taskLoad;
        #endregion

        public ctlApiCalls()
        {
            InitializeComponent();
            httpClient = new HttpClient();
        }
        
        public void Initialize()
        {
            InitializePage().Wait();
        }

        public async Task InitializePage()
        {
            string uri = "http://192.168.0.19/ocpu/user/james/library/ApiCalls/R/";
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            if(response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                lstApiCalls = result.Split(new string[]{"\n"}, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            
            bIsInitialzied = true;
        }

        public async Task PostRScript(string jsonData)
        {
            /*string uri = "http://192.168.0.19/ocpu/user/james/library/ApiCalls/R/" + lstBoxApiCalls.SelectedItem.ToString();
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(uri, jsonData);
            response.EnsureSuccessStatusCode();
            var temp = response.Headers.Location;*/
        }


        public void LoadGui()
        {
            /*if(lstBoxApiCalls.Items.Count == 0 && lstApiCalls != null && lstApiCalls.Count > 0)
                lstBoxApiCalls.DataSource = lstApiCalls;

            lstBoxApiCalls.Refresh();*/
        }

        private void btnCallFunction_Click(object sender, EventArgs e)
        {
            /*tabControlAdv1.TabPages.Clear();
            string url = "http://192.168.0.19/ocpu/user/james/library/ApiCalls/R/" + lstBoxApiCalls.SelectedItem.ToString();
            string jsonData = "";
            string postData = "";
            DataTable theData= new DataTable();
            DataSet ds = new DataSet();
            if (GlobalVariables.ExperimentData.JSONTable != null)
            {
                DataTable dtCopy = GlobalVariables.ExperimentData.JSONTable.Copy();
                //dtCopy.Columns.Add("dependentVariable");
                //dtCopy.Columns.Add("independentVariables");
                dtCopy.DefaultView.RowFilter = GlobalVariables.ExperimentGrid._bindingSource.Filter;
                theData = dtCopy.DefaultView.ToTable();
                theData.TableName = "jsonDataset";
                theData.AcceptChanges();
                ds.Tables.Add(theData);
                jsonData = JsonConvert.SerializeObject(ds, Formatting.Indented);
            }
            //theData.Rows[0]["dependentVariable"] = "wt_weight";
            //theData.Rows[0]["independentVariables"] = "Fat,Ratio"; 
            switch(lstBoxApiCalls.SelectedItem.ToString())
            {
                case "drawResidualPlotJSON":
                    postData = "jsonDataset="+jsonData+"&dependentVariable='wt_weight'&independentVariables='Fat,Ratio'";
                    break;
                case "DTKTest":
                    postData = "dataset="+jsonData+"&dependentVariable='wt_weight'&independentVariable='Fat'";
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
            
            foreach(string s in lstApiRespone)
            {
                int count = 0;
                if (s.Contains("console"))
                {
                    TabPageAdv page = new TabPageAdv();
                    WebBrowser browser = new WebBrowser();
                    browser.Dock = DockStyle.Fill;
                    page.Controls.Add(browser);
                    page.Dock = DockStyle.Fill;
                    page.Text = "Console Output";
                    browser.Navigate("http://192.168.0.19" + s);
                    tabControlAdv1.TabPages.Insert(0,page);
                }
                if (s.Contains("graphics"))
                {
                    TabPageAdv page = new TabPageAdv();
                    WebBrowser browser = new WebBrowser();
                    browser.Dock = DockStyle.Fill;
                    page.Controls.Add(browser);
                    page.Dock = DockStyle.Fill;
                    page.Text = "Graphic " + count.ToString();
                    string width = (spMainLayout.Panel2.Width - 100).ToString();
                    string height = (spMainLayout.Panel2.Height - 100).ToString();
                    browser.Navigate("http://192.168.0.19" + s + "//png?width="+width + "&height=" +height);
                    tabControlAdv1.TabPages.Add(page);
                    count++;
                }

            }
            tabControlAdv1.Refresh();*/
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

        private void dgRScripts_Layout(object sender, LayoutEventArgs e)
        {

        }
    }
}
