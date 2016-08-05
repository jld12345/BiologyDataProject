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
            [ToolTip("Select DLLs to load if the rCLR package is selected.  The defaualt is to select all.")]
            [Description("Include .NET DLLs")]
            DLLs,
            [ToolTip("If checked get the data as it is currently filtered, otherwise the raw data will be loaded.")]
            [Description("Get Filtered Data")]
            FilteredData,
            [ToolTip("Saves the XML document if created.  The document will be saved to My Documents.")]
            [Description("Save XML Document")]
            XML,
            [ToolTip("Select basic tests to run.  Checking Include Base Tests will run all supported basic tests.")]
            [Description("Include Base Tests")]
            Tests,
            [ToolTip("Checking Basic Plot will run basic plots.")]
            [Description("Basic Plot")]
            Plot

        }

        private enum BaseLibrary
        {
            [ToolTip("Package for loading DLL's.")]
            [Description("rCLR")]
            rCLr,
            [ToolTip("Package for reading and loading XML.")]
            [Description("XML")]
            XML,
            [ToolTip("Package for graphics.")]
            [Description("ggPlot")]
            ggPlot2
        }

        private enum BaseDLL
        {
            [ToolTip("Allows querying the ActiveDirectory.")]
            [Description("ActiveDirectory")]
            ActiveDirectoryClass,
            [ToolTip("Allows for querying the database to get the data frame.")]
            [Description("RClass")]
            RClass,
            [ToolTip("Required DLL if querying the database.")]
            [Description("Npgsql")]
            Npgsql
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
                TreeNode node = new TreeNode();
                node.Name = item.ToString();
                var list = GetNodeDescription(item.ToString(), "BaseRItems");
                node.Text = list[0];
                node.ToolTipText = list[1];
                switch(node.Name)
                {
                    case "Libraries":
                        var baseLibs = Enum.GetValues(typeof(BaseLibrary));
                        foreach(var lib in baseLibs)
                        {
                            TreeNode child = new TreeNode();
                            child.Name = lib.ToString();
                            var childList = GetNodeDescription(lib.ToString(), "BaseLibrary");
                            child.Text = childList[0];
                            child.ToolTipText = childList[1];
                            node.Nodes.Add(child);
                        }
                        break;
                    case "DLLs":
                        var baseDLLs = Enum.GetValues(typeof(BaseDLL));
                        foreach(var dll in baseDLLs)
                        {
                            TreeNode child = new TreeNode();
                            child.Name = dll.ToString();
                            var childList = GetNodeDescription(dll.ToString(), "BaseDLL");
                            child.Text = childList[0];
                            child.ToolTipText = childList[1];
                            node.Nodes.Add(child);
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
            else if (theEnum.Equals("BaseDLL"))
            {
                var value = (BaseDLL)System.Enum.Parse(typeof(BaseDLL), theNode);
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
                    case "DLLs":
                        sb.AppendLine("###DLL references to install");
                        foreach(TreeNode sibling in node.Nodes)
                        {
                            if (!sibling.Checked)
                                continue;
                            sb.AppendLine();
                            sb.AppendLine(@"clrLoadAssembly('C:\\BiologyDataProject.git\\trunk\\BiologyDepartment\\DLL Files\\" + sibling.Name + ".dll')");
                            if (sibling.Name.Equals("ActiveDirectoryClass"))
                            {
                                sb.AppendLine("###Validates the ActiveDirectory user and gets the postgres database username and password");
                                sb.AppendLine("activeDirectory <- clrNew('ActiveDirectory.daoActiveDirectory')");                            
                                sb.AppendLine("clrCall(activeDirectory, 'ValidateCredentials', '" + GlobalVariables.ADUserName + "', '" + GlobalVariables.ADPass + "')");
                                sb.AppendLine("dbUser <- clrGet(activeDirectory, 'DBUser')");
                                sb.AppendLine("dbPass <- clrGet(activeDirectory, 'DBPass')");
                            }
                            else if(sibling.Name.Equals("RClass"))
                            {
                                sb.AppendLine("###Gets the Data for the dataframe");
                                sb.AppendLine("rUtil <- clrNew('RClass.RClassUtil')");
                                sb.AppendLine("clrSet(rUtil, 'DBPass', clrGet(activeDirectory, 'DBPass'))");
                                sb.AppendLine("clrSet(rUtil, 'DBUser', clrGet(activeDirectory, 'DBUser'))");
                                sb.AppendLine("clrSet(rUtil, 'ADUserName', clrGet(activeDirectory, 'ADUserName'))");
                                sb.AppendLine("clrSet(rUtil, 'ADPass', clrGet(activeDirectory, 'ADPass'))");
                                sb.AppendLine("clrSet(rUtil, 'ADUserGroup', clrGet(activeDirectory, 'ADUserGroup'))");
                                sb.AppendLine("clrCall(rUtil, 'SetDao')");
                            }

                        }

                        break;
                    case "XML":
                        sb.AppendLine("###XML file location");
                        break;
                    case "Tests":
                        sb.AppendLine("###Tests to run");
                        break;
                    case "Plot":
                        sb.AppendLine("###Basic plots to run");
                        break;
                    case "FilteredData":
                        sb.AppendLine("###Get the data.");
                        sb.AppendLine("dtExperiments <- clrCall(rUtil, 'GetExperiments', clrGet(activeDirectory, 'ADUserName'))");
                        sb.AppendLine("xmlDoc <- clrCall(rUtil, 'GetXMLDoc', dtExperiments)");
                        sb.AppendLine("df <- clrGet(xmlDoc, 'OuterXml')");
                        sb.AppendLine("doc = xmlToDataFrame(xmlParseString(df))");
                        sb.AppendLine("exID <- as.integer('1')");
                        sb.AppendLine("sFilter <- ''");
                        sb.AppendLine("dtData <- clrCall(rUtil, 'GetData', exID, '')");
                        sb.AppendLine("rowCount <- clrCall(rUtil, 'RowCount', dtData )");
                        sb.AppendLine("xmlDoc <- clrCall(rUtil, 'GetXMLDoc', dtData)");
                        sb.AppendLine("df <- clrGet(xmlDoc, 'OuterXml')");
                        sb.AppendLine("theData <- xmlToDataFrame(xmlParseString(df))");
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
