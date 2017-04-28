#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace BiologyDepartment.Admin
{
    public partial class frmRScript : Syncfusion.Windows.Forms.MetroForm
    {
        #region private variables
        private string theApiCall = Properties.Settings.Default.MyApi;
        private string rConnection = @"###Libraries to install
                                if (!require(""jsonlite"", character.only=T, quietly=T)){
                                  install.packages(""jsonlite"", dependencies=TRUE)
                                  library(""jsonlite"", character.only= T)}

                                if (!require(""dplyr"" character.only= T, quietly= T)){
                                  install.packages(""dplyr"", dependencies=TRUE)
                                  library(""dplyr"", character.only= T)}

                                if (!require(""ggplot2"", character.only= T, quietly= T)){
                                  install.packages(""ggplot2"")
                                  library(""ggplot2"", character.only= T)}

                                ###Get the data.
                                theData<- bind_rows(fromJSON(""";
        #endregion

        #region public methods
        public frmRScript()
        {
            InitializeComponent();
        }

        public void Initialize(string filter)
        {
            theApiCall += GlobalVariables.ExperimentNode.ExperimentNode.ID;
            theApiCall += "?filter=" + filter;
            rConnection += theApiCall.Replace(" ", "") + @"""))";
            richTextBox1.Text = rConnection;
        }
        #endregion
    }
}
