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
using ScintillaNET;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BiologyDepartment
{
    public partial class ctlRScripts : UserControl
    {
        private string sPostgresSQL = "";
        private string sErrorMsg = "Data string is empty.  Please use the Data tab to set data.";
        private string sDataFrame = "dframe < -dbGetQuery(con, sql)";
        private string sXData = "";
        private string sYData = "";
        private string sFactor = "";
        string sPlot = "";
        private bool bLoad = true;
        private Data.DataUtil _dataUtil = new Data.DataUtil();
        private ctlGGPlot ggPlot = new ctlGGPlot();
        private ctlRBaseFunctions rBaseItems = new ctlRBaseFunctions();
        private List<string> Keywords1 = null;
        private List<string> Keywords2 = null;
        private string AutoCompleteKeywords = null;

        public ctlRScripts()
        {
            InitializeComponent();
            PrepareKeywords();
            ConfigureRScriptSyntaxHighlight();
            ConfigureRScriptAutoFolding();
            ConifugreRScriptAutoComplete();
            
        }

        public void Initialize()
        {
            if (bLoad || GlobalVariables.RDataIsDirty)
            {
                ggPlot.Initialize();
                tabGGPlot.Controls.Add(ggPlot);
                rBaseItems.Initialize();
                tabRBase.Controls.Add(rBaseItems);
                //btnSetScript.PerformClick();
                PopulateForLatticeExtra();
                bLoad = false;
                GlobalVariables.RDataIsDirty = false;
            }
        }

        private void PrepareKeywords()
        {
            Keywords1 = @"commandArgs detach length dev.off stop lm library predict lmer 
           plot print display anova read.table read.csv complete.cases dim attach as.numeric seq max 
           min data.frame lines curve as.integer levels nlevels ceiling sqrt ranef order
           AIC summary str head png tryCatch par mfrow interaction.plot qqnorm qqline rbind_all 
           install fromJSON".Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            Keywords2 = @"TRUE FALSE if else for while in break continue function".Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            List<string> keywords = Keywords1.ToList();
            keywords.AddRange(Keywords2);
            keywords.Sort();

            AutoCompleteKeywords = string.Join(" ", keywords);
        }

        private void ConfigureRScriptSyntaxHighlight()
        {

            txtScript.StyleResetDefault();
            txtScript.Styles[Style.Default].Font = "Consolas";
            txtScript.Styles[Style.Default].Size = 10;
            txtScript.StyleClearAll();

            txtScript.Styles[Style.R.Default].ForeColor = Color.Brown;
            txtScript.Styles[Style.R.Comment].ForeColor = Color.FromArgb(0, 128, 0); // Green
            txtScript.Styles[Style.R.Number].ForeColor = Color.Olive;
            txtScript.Styles[Style.R.BaseKWord].ForeColor = Color.Purple;
            txtScript.Styles[Style.R.Identifier].ForeColor = Color.Black;
            txtScript.Styles[Style.R.String].ForeColor = Color.FromArgb(163, 21, 21); // Red
            txtScript.Styles[Style.R.KWord].ForeColor = Color.Blue;
            txtScript.Styles[Style.R.OtherKWord].ForeColor = Color.Blue;
            txtScript.Styles[Style.R.String2].ForeColor = Color.OrangeRed;
            txtScript.Styles[Style.R.Operator].ForeColor = Color.Purple;


            txtScript.Lexer = Lexer.R;

            if(Keywords1 != null)
                txtScript.SetKeywords(0, string.Join(" ", Keywords1));
            if(Keywords2 != null)
                txtScript.SetKeywords(1, string.Join(" ", Keywords2));
        }

        private void ConifugreRScriptAutoComplete()
        {
            txtScript.CharAdded += scintilla_CharAdded;
        }

        private void scintilla_CharAdded(object sender, CharAddedEventArgs e)
        {
            Scintilla scintilla = txtScript;

            // Find the word start
            var currentPos = scintilla.CurrentPosition;
            var wordStartPos = scintilla.WordStartPosition(currentPos, true);

            // Display the autocompletion list
            var lenEntered = currentPos - wordStartPos;
            if (lenEntered > 0)
            {
                scintilla.AutoCShow(lenEntered, AutoCompleteKeywords);
            }
        }

        private void ConfigureRScriptAutoFolding()
        {
            Scintilla scintilla = txtScript;

            // Instruct the lexer to calculate folding
            scintilla.SetProperty("fold", "1");
            scintilla.SetProperty("fold.compact", "1");

            // Configure a margin to display folding symbols
            scintilla.Margins[2].Type = MarginType.Symbol;
            scintilla.Margins[2].Mask = Marker.MaskFolders;
            scintilla.Margins[2].Sensitive = true;
            scintilla.Margins[2].Width = 20;

            // Set colors for all folding markers
            for (int i = 25; i <= 31; i++)
            {
                scintilla.Markers[i].SetForeColor(SystemColors.ControlLightLight);
                scintilla.Markers[i].SetBackColor(SystemColors.ControlDark);
            }

            // Configure folding markers with respective symbols
            scintilla.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
            scintilla.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
            scintilla.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
            scintilla.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            scintilla.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
            scintilla.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            scintilla.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            // Enable automatic folding
            scintilla.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);
        }

        private void btnClipBoard_Click(object sender, EventArgs e)
        {
            if (txtScript.Text != "")
                Clipboard.SetDataObject(txtScript.Text);
        }

        private void btnSetScript_Click(object sender, EventArgs e)
        {
            rBaseItems.BuildStringSection();
            
            if(rBaseItems.sbBase != null)
                txtScript.Text = rBaseItems.sbBase.ToString();
            txtScript.Text += ggPlot.GetRScript();
        }

        private void PopulateForLatticeExtra()
        {

        }

        


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Initialize();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           /* DataTable dtCopy = GlobalVariables.ExperimentData.JSONTable.Copy();
            dtCopy.Columns.Add("dependentVariable");
            dtCopy.Columns.Add("independentVariables");
            dtCopy.DefaultView.RowFilter = GlobalVariables.ExperimentGrid._bindingSource.Filter;
            DataTable theData = dtCopy.DefaultView.ToTable();
            theData.Rows[0]["dependentVariable"] = "wt_weight";
            theData.Rows[0]["independentVariables"] = "Fat,Ratio";
            theData.TableName = "jsonDataset";
            using (HttpClient httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(theData);
                string url = "http://192.168.0.19/ocpu/user/james/library/ApiCalls/R/drawResidualPlotJSON";
                var content = new StringContent(
                        json,
                        Encoding.UTF8,
                        "application/x-www-form-urlencoded");
                using (var response = httpClient.PostAsJsonAsync(url, json)); //PostAsync(url, content).Result)
                {
                    /*using (HttpContent responseContent = response.Content)
                    {
                        // ... Read the string.
                        string result = responseContent.ToString();
                    }
                }
            }

            /*string sJson = JsonConvert.SerializeObject(theData);
            // Create a request using a URL that can receive a post. 
            WebRequest request = WebRequest.Create("http://192.168.0.19/ocpu/library/R/ApiCalls/drawResidualPlotJSON");
            // Set the Method property of the request to POST.
            request.Method = "POST";
            // Create POST data and convert it to a byte array.
            string postData = "jsonDataset=" + sJson;
            byte[] byteArray = Encoding.UTF8.GetBytes(sJson);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "text/plain";
            //request.ContentType = "application/json";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();*/

}



    }
}
