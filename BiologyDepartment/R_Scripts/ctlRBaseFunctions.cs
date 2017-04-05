using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiologyDepartment
{
    public partial class ctlRBaseFunctions : UserControl
    {
        #region private variables

        private bool bSetParent = true;

        #endregion

        #region public variables

        public StringBuilder sbBase { get; set; }

        #endregion

        #region enum

        private enum BaseRItems
        {
            [ToolTip("Install selected libraries if not already installed.")]
            [Description("Install Libraries if required")]
            InstallLibraries,
            [ToolTip("Select Libraries to load.  Checking Include Base Libraries will load all supported libraries.")]
            [Description("Include Base Libraries")]
            Libraries,
            [ToolTip("If checked get the data as it is currently filtered, otherwise the raw data will be loaded.")]
            [Description("Get Filtered Data")]
            FilteredData,
            [ToolTip("Select basic tests to run.  Checking Include Base Tests will run all supported basic tests.")]
            [Description("Include Base Tests")]
            Tests,
            [ToolTip("Checking Basic Plot will run basic plots.")]
            [Description("Basic Plot")]
            Plot

        }

        private enum BaseLibrary
        {
            [ToolTip("Package for graphics.")]
            [Description("ggplot")]
            ggplot2
        }

        private enum BaseTests
        {
            [ToolTip("Basic tests to run")]
            [Description("summary")]
            summary
        }

        #endregion 
        public ctlRBaseFunctions()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            LoadBaseTreeView();
        }

        private void LoadBaseTreeView()
        {
            var baseItems = Enum.GetValues(typeof(BaseRItems));
            
            foreach(var item in baseItems)
            {
                TreeNode node = new TreeNode()
                {
                    Name = item.ToString()
                };
                var list = GetNodeDescription(item.ToString(), "BaseRItems");
                node.Text = list[0];
                node.ToolTipText = list[1];
                switch(node.Name)
                {
                    case "Libraries":
                        var baseLibs = Enum.GetValues(typeof(BaseLibrary));
                        foreach(var lib in baseLibs)
                        {
                            TreeNode child = new TreeNode()
                            {
                                Name = lib.ToString()
                            };
                            var childList = GetNodeDescription(lib.ToString(), "BaseLibrary");
                            child.Text = childList[0];
                            child.ToolTipText = childList[1];
                            node.Nodes.Add(child);
                        }
                        break;
                    case "Tests":
                        var baseTests = Enum.GetValues(typeof(BaseTests));
                        foreach(var lib in baseTests)
                        {
                            TreeNode child = new TreeNode()
                            {
                                Name = lib.ToString()
                            };
                            var childList = GetNodeDescription(lib.ToString(), "BaseTest");
                            if (childList.Count > 0)
                            {
                                child.Text = childList[0];
                                child.ToolTipText = childList[1];
                                node.Nodes.Add(child);
                            }
                        }
                        break;
                }
                tvRBaseFunctions.Nodes.Add(node);
            }
        }

        private List<string> GetNodeDescription(string theNode, string theEnum)
        {
            DescriptionAttribute descAttribute;
            ToolTipAttribute toolTipAttribute;
            List<string> result = new List<string>();
            if (theEnum.Equals("BaseRItems"))
            {
                var value = (BaseRItems)System.Enum.Parse(typeof(BaseRItems), theNode);
                var field = value.GetType().GetField(value.ToString());
                descAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
                toolTipAttribute = (ToolTipAttribute)Attribute.GetCustomAttribute(field, typeof(ToolTipAttribute));
                result.Add(descAttribute != null ? descAttribute.Description : string.Empty);
                result.Add(toolTipAttribute != null ? toolTipAttribute.DescriptionValue : string.Empty);
            }
            else if (theEnum.Equals("BaseLibrary"))
            {
                var value = (BaseLibrary)System.Enum.Parse(typeof(BaseLibrary), theNode);
                var field = value.GetType().GetField(value.ToString());
                descAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
                toolTipAttribute = (ToolTipAttribute)Attribute.GetCustomAttribute(field, typeof(ToolTipAttribute));
                result.Add(descAttribute != null ? descAttribute.Description : string.Empty);
                result.Add(toolTipAttribute != null ? toolTipAttribute.DescriptionValue : string.Empty);
            }
            else if (theEnum.Equals("BaseTest"))
            {
                var value = (BaseTests)System.Enum.Parse(typeof(BaseTests), theNode);
                var field = value.GetType().GetField(value.ToString());
                descAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
                toolTipAttribute = (ToolTipAttribute)Attribute.GetCustomAttribute(field, typeof(ToolTipAttribute));
                result.Add(descAttribute != null ? descAttribute.Description : string.Empty);
                result.Add(toolTipAttribute != null ? toolTipAttribute.DescriptionValue : string.Empty);
            }
            return result;
        }

        private void tvRBaseFunctions_AfterCheck(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Name)
            {
                case "Libraries":
                case "DLLs":
                case "Tests":
                    if (bSetParent)
                    {
                        bool bChildChecked = e.Node.Checked;
                        foreach (TreeNode child in e.Node.Nodes)
                        {
                            child.Checked = bChildChecked;
                        }
                    }
                    break;
                default:
                    if (e.Node.Parent == null)
                        return;
                    bool bIsChecked = false;
                    bSetParent = false;
                    foreach(TreeNode sibling in e.Node.Parent.Nodes)
                    {                        
                        if(sibling.Checked)
                        {
                            bIsChecked = true;
                        }
                    }
                    e.Node.Parent.Checked = bIsChecked;
                    bSetParent = true;
                    break;
            }
        }

        public void BuildStringSection()
        {
            bool bInstallLibraries = false;
            StringBuilder sb = new StringBuilder();

            foreach(TreeNode node in tvRBaseFunctions.Nodes)
            {
                if (!node.Checked)
                    continue;
                switch(node.Name)
                {
                    case "InstallLibraries":
                        bInstallLibraries = true;
                        break;
                    case "Libraries":
                        sb.AppendLine("###Libraries to install");
                        sb.AppendLine(@"if (!require(""jsonlite"", character.only=T, quietly=T)){");
                        sb.AppendLine(@"install.packages(""jsonlite"", dependencies=TRUE)");
                        sb.AppendLine(@"library(""jsonlite"", character.only=T)}");
                        sb.AppendLine();
                        sb.AppendLine(@"if (!require(""dplyr"", character.only=T, quietly=T)){");
                        sb.AppendLine(@"install.packages(""dplyr"", dependencies=TRUE)");
                        sb.AppendLine(@"library(""dplyr"", character.only=T)}");
                        sb.AppendLine();
                        foreach(TreeNode child in node.Nodes)
                        {
                            if (!child.Checked)
                                continue;
                            if (bInstallLibraries)
                            {
                                sb.AppendLine(@"if (!require(""" + child.Name + @""", character.only=T, quietly=T)){");
                                sb.AppendLine(@"install.packages(""" + child.Name + @""")");
                                sb.AppendLine(@"library(""" + child.Name + @""", character.only=T)}");
                                sb.AppendLine();
                            }
                            else
                                sb.AppendLine(@"library(""" + child.Name + @""", character.only = T)");
                        }
                        break;
                    case "Tests":
                        sb.AppendLine("###Tests to run");
                        foreach (TreeNode child in node.Nodes)
                        {
                            if (!child.Checked)
                                continue;
                            switch(child.Name)
                            { 
                                case "summary":
                                    sb.AppendLine("@theSummary <- summary(theData)");
                                    sb.AppendLine("theSummary");
                                    break;
                            }
                        }
                        break;
                    case "Plot":
                        sb.AppendLine("###Basic plots to run");
                        break;
                    case "FilteredData":
                        sb.AppendLine("###Get the data.");
                        sb.AppendLine(@"theData <- rbind_all(fromJSON(""http://dwbtechnologies.ddns.net/api/experiment/1""))");

                        break;
                }

            }
            if (!string.IsNullOrEmpty(sb.ToString()))
            {
                if (sbBase == null)
                    sbBase = new StringBuilder();
                else
                    sbBase.Clear();
                sbBase.Append(sb.ToString());
                sb.Clear();
            }
        }

    }

    [AttributeUsage(AttributeTargets.All)]
    public class ToolTipAttribute : Attribute
    {
        // Summary:
        //     Specifies the default value for the System.ComponentModel.DescriptionAttribute,
        //     which is an empty string (""). This static field is read-only.
        public static readonly ToolTipAttribute Default;
        private string sDescription = "";

        public ToolTipAttribute(){}

        public ToolTipAttribute(string description) 
        {
            sDescription = description;
        }

        public string DescriptionValue { get {return sDescription; } }

    }
}
