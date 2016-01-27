using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;


namespace BiologyDepartment.Misc_Files
{
    public class DataGridViewColumnType
    {

        public DataGridViewColumnType()
        {

        }

        public DataGridViewTextBoxColumn AddTextColumn(string sColumnName, string sHeader, bool bIsVisible, int nPosition)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();

            column.HeaderText = sHeader;
            column.Name = sColumnName;
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            column.DisplayIndex = nPosition;
            column.DataPropertyName = sColumnName;

            return column;

        }

        public DataGridViewComboBoxColumn AddComboBoxColumns(string sColumnName, string sHeader, bool bIsVisible, int nPosition,  List<string> theTypes)
        {
            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
            column.HeaderText = sHeader;
            column.Name = sColumnName;
            column.Visible = bIsVisible;
            column.DisplayIndex = nPosition;
            column.DataPropertyName = sColumnName;
            column.DataSource = theTypes;
            column.DisplayMember = "";
            column.ValueMember = null;
            return column;
        }

        public DataGridViewLinkColumn AddLinkColumn(string sColumnName, string sHeader, bool bIsVisible, int nPosition)
        {
            DataGridViewLinkColumn column = new DataGridViewLinkColumn();

            column.UseColumnTextForLinkValue = true;
            column.HeaderText = sHeader;
            column.Name = sColumnName;
            column.ActiveLinkColor = System.Drawing.Color.White;
            column.LinkBehavior = LinkBehavior.SystemDefault;
            column.LinkColor = System.Drawing.Color.Blue;
            column.TrackVisitedState = true;
            column.VisitedLinkColor = System.Drawing.Color.YellowGreen;
            column.Visible = bIsVisible;
            column.DisplayIndex = nPosition;
            column.DataPropertyName = sColumnName;

            return column;
        }

        public DataGridViewButtonColumn AddButtonColumn(string sColumnName, string sHeader, bool bIsVisible, int nPosition)
        {
            DataGridViewButtonColumn column = new DataGridViewButtonColumn();
            
            column.HeaderText = sHeader;
            column.Name = sColumnName;
            column.UseColumnTextForButtonValue = false;
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            column.FlatStyle = FlatStyle.Standard;
            column.CellTemplate.Style.BackColor = System.Drawing.Color.Honeydew;
            column.DisplayIndex = nPosition;
            column.DataPropertyName = sColumnName;
            
            return column;

        }
        
        public DataGridViewAddButtonColumn AddButtonColumnAddIcon(string sColumnName, string sHeader, bool bIsVisible, int nPosition)
        {
            DataGridViewAddButtonColumn column = new DataGridViewAddButtonColumn();

            column.HeaderText = sHeader;
            column.Name = sColumnName;
            column.UseColumnTextForButtonValue = false;
            column.FlatStyle = FlatStyle.Standard;
            column.CellTemplate.Style.BackColor = System.Drawing.Color.Honeydew;
            column.DisplayIndex = nPosition;
            column.DataPropertyName = sColumnName;

            return column;
        }

        public DataGridViewEditButtonColumn AddButtonColumnEditIcon(string sColumnName, string sHeader, bool bIsVisible, int nPosition)
        {
            DataGridViewEditButtonColumn column = new DataGridViewEditButtonColumn();

            column.HeaderText = sHeader;
            column.Name = sColumnName;
            column.UseColumnTextForButtonValue = false;
            column.FlatStyle = FlatStyle.Standard;
            column.CellTemplate.Style.BackColor = System.Drawing.Color.Honeydew;
            column.DisplayIndex = nPosition;
            column.DataPropertyName = sColumnName;

            return column;
        }

        public DataGridViewDeleteButtonColumn AddButtonColumnDeleteIcon(string sColumnName, string sHeader, bool bIsVisible, int nPosition)
        {
            DataGridViewDeleteButtonColumn column = new DataGridViewDeleteButtonColumn();

            column.HeaderText = sHeader;
            column.Name = sColumnName;
            column.UseColumnTextForButtonValue = false;
            column.FlatStyle = FlatStyle.Standard;
            column.CellTemplate.Style.BackColor = System.Drawing.Color.Honeydew;
            column.DisplayIndex = nPosition;
            column.DataPropertyName = sColumnName;

            return column;
        }

        public DataGridViewCheckBoxColumn AddCheckBoxColumn(string sColumnName, string sHeader, bool bIsVisible, int nPosition)
        {
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
  
            column.HeaderText = sHeader;
            column.Name = sColumnName;
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            column.FlatStyle = FlatStyle.Standard;
            column.ThreeState = false;
            column.CellTemplate = new DataGridViewCheckBoxCell();
            column.CellTemplate.Style.BackColor = System.Drawing.Color.Beige;
            column.DataPropertyName = sColumnName;

            return column;
        }

    }
}
