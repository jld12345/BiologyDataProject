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
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn()
            {
                HeaderText = sHeader,
                Name = sColumnName,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                DisplayIndex = nPosition,
                DataPropertyName = sColumnName
            };
            return column;

        }

        public DataGridViewComboBoxColumn AddComboBoxColumns(string sColumnName, string sHeader, bool bIsVisible, int nPosition,  List<string> theTypes)
        {
            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn()
            {
                HeaderText = sHeader,
                Name = sColumnName,
                Visible = bIsVisible,
                DisplayIndex = nPosition,
                DataPropertyName = sColumnName,
                DataSource = theTypes,
                DisplayMember = "",
                ValueMember = null
            };
            return column;
        }

        public DataGridViewLinkColumn AddLinkColumn(string sColumnName, string sHeader, bool bIsVisible, int nPosition)
        {
            DataGridViewLinkColumn column = new DataGridViewLinkColumn()
            {
                UseColumnTextForLinkValue = true,
                HeaderText = sHeader,
                Name = sColumnName,
                ActiveLinkColor = System.Drawing.Color.White,
                LinkBehavior = LinkBehavior.SystemDefault,
                LinkColor = System.Drawing.Color.Blue,
                TrackVisitedState = true,
                VisitedLinkColor = System.Drawing.Color.YellowGreen,
                Visible = bIsVisible,
                DisplayIndex = nPosition,
                DataPropertyName = sColumnName
            };
            return column;
        }

        public DataGridViewButtonColumn AddButtonColumn(string sColumnName, string sHeader, bool bIsVisible, int nPosition)
        {
            DataGridViewButtonColumn column = new DataGridViewButtonColumn()
            {
                HeaderText = sHeader,
                Name = sColumnName,
                UseColumnTextForButtonValue = false,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                FlatStyle = FlatStyle.Standard
            };
            column.CellTemplate.Style.BackColor = System.Drawing.Color.Honeydew;
            column.DisplayIndex = nPosition;
            column.DataPropertyName = sColumnName;
            
            return column;

        }
        
        public DataGridViewAddButtonColumn AddButtonColumnAddIcon(string sColumnName, string sHeader, bool bIsVisible, int nPosition)
        {
            DataGridViewAddButtonColumn column = new DataGridViewAddButtonColumn()
            {
                HeaderText = sHeader,
                Name = sColumnName,
                UseColumnTextForButtonValue = false,
                FlatStyle = FlatStyle.Standard
            };
            column.CellTemplate.Style.BackColor = System.Drawing.Color.Honeydew;
            column.DisplayIndex = nPosition;
            column.DataPropertyName = sColumnName;

            return column;
        }

        public DataGridViewEditButtonColumn AddButtonColumnEditIcon(string sColumnName, string sHeader, bool bIsVisible, int nPosition)
        {
            DataGridViewEditButtonColumn column = new DataGridViewEditButtonColumn()
            {
                HeaderText = sHeader,
                Name = sColumnName,
                UseColumnTextForButtonValue = false,
                FlatStyle = FlatStyle.Standard
            };
            column.CellTemplate.Style.BackColor = System.Drawing.Color.Honeydew;
            column.DisplayIndex = nPosition;
            column.DataPropertyName = sColumnName;

            return column;
        }

        public DataGridViewDeleteButtonColumn AddButtonColumnDeleteIcon(string sColumnName, string sHeader, bool bIsVisible, int nPosition)
        {
            DataGridViewDeleteButtonColumn column = new DataGridViewDeleteButtonColumn()
            {
                HeaderText = sHeader,
                Name = sColumnName,
                UseColumnTextForButtonValue = false,
                FlatStyle = FlatStyle.Standard
            };
            column.CellTemplate.Style.BackColor = System.Drawing.Color.Honeydew;
            column.DisplayIndex = nPosition;
            column.DataPropertyName = sColumnName;

            return column;
        }

        public DataGridViewCheckBoxColumn AddCheckBoxColumn(string sColumnName, string sHeader, bool bIsVisible, int nPosition)
        {
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn()
            {
                HeaderText = sHeader,
                Name = sColumnName,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                FlatStyle = FlatStyle.Standard,
                ThreeState = false,
                CellTemplate = new DataGridViewCheckBoxCell()
            };
            column.CellTemplate.Style.BackColor = System.Drawing.Color.Beige;
            column.DataPropertyName = sColumnName;

            return column;
        }

    }
}
