using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Drawing;


namespace BiologyDepartment.Misc_Files
{
    public class DataGridViewEditButtonCell : DataGridViewButtonCell
    {

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            System.Reflection.Assembly thisExe = System.Reflection.Assembly.GetExecutingAssembly();
            System.IO.Stream file;
            file = thisExe.GetManifestResourceStream("BiologyDepartment.Misc_Files.images.editicon16.png");
            ImageList imgList = new ImageList();
            imgList.ImageSize = new System.Drawing.Size(16,16);
            imgList.Images.Add(Image.FromStream(file));
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            graphics.DrawImage(imgList.Images[0], cellBounds);
        }
    }

    public class DataGridViewEditButtonColumn : DataGridViewButtonColumn
    {
        public DataGridViewEditButtonColumn()
        {
            this.CellTemplate = new DataGridViewEditButtonCell();
            this.HeaderText = "EDIT";
            this.Name = "EDIT";
            this.Width = 50;
            this.FlatStyle = FlatStyle.Standard;
            this.DefaultCellStyle.ForeColor = Color.Green;
        }
    }

    public class DataGridViewAddButtonCell : DataGridViewButtonCell
    {

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            System.Reflection.Assembly thisExe = System.Reflection.Assembly.GetExecutingAssembly();
            System.IO.Stream file;
            file = thisExe.GetManifestResourceStream("BiologyDepartment.Misc_Files.images.addicon16.png");
            ImageList imgList = new ImageList();
            imgList.ImageSize = new System.Drawing.Size(16,16);
            imgList.Images.Add(Image.FromStream(file));
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            graphics.DrawImage(imgList.Images[0], cellBounds);
        }
    }

    public class DataGridViewAddButtonColumn : DataGridViewButtonColumn
    {
        public DataGridViewAddButtonColumn()
        {
            this.CellTemplate = new DataGridViewAddButtonCell();
            this.Width = 50;
            this.FlatStyle = FlatStyle.Standard;
            this.DefaultCellStyle.ForeColor = Color.White;
        }
    }

    public class DataGridViewDeleteButtonCell : DataGridViewButtonCell
    {

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            System.Reflection.Assembly thisExe = System.Reflection.Assembly.GetExecutingAssembly();
            System.IO.Stream file;
            file = thisExe.GetManifestResourceStream("BiologyDepartment.Misc_Files.images.deleteicon16.png");
            ImageList imgList = new ImageList();
            imgList.ImageSize = new System.Drawing.Size(16,16);
            imgList.Images.Add(Image.FromStream(file));
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            graphics.DrawImage(imgList.Images[0], cellBounds);
        }
    }

    public class DataGridViewDeleteButtonColumn : DataGridViewButtonColumn
    {
        public DataGridViewDeleteButtonColumn()
        {
            this.CellTemplate = new DataGridViewDeleteButtonCell();
            this.Width = 50;
            this.FlatStyle = FlatStyle.Standard;
            this.DefaultCellStyle.ForeColor = Color.White;
        }
    }
}
