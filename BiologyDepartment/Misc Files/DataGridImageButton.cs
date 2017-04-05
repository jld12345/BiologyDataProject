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

        private bool enabledValue;
        public bool Enabled
        {
            get
            {
                return enabledValue;
            }
            set
            {
                enabledValue = value;
            }
        }

        public override object Clone()
        {
            DataGridViewEditButtonCell cell = (DataGridViewEditButtonCell)base.Clone();
            cell.Enabled = this.Enabled;
            return cell;
        }

        public DataGridViewEditButtonCell()
        {
            this.enabledValue = false;
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            if (!this.enabledValue)
            {
                // Draw the cell background, if specified.
                if ((paintParts & DataGridViewPaintParts.Background) ==
                    DataGridViewPaintParts.Background)
                {
                    SolidBrush cellBackground =
                        new SolidBrush(cellStyle.BackColor);
                    graphics.FillRectangle(cellBackground, cellBounds);
                    cellBackground.Dispose();
                }

                // Draw the cell borders, if specified.
                if ((paintParts & DataGridViewPaintParts.Border) ==
                    DataGridViewPaintParts.Border)
                {
                    PaintBorder(graphics, clipBounds, cellBounds, cellStyle,
                        advancedBorderStyle);
                }

                // Calculate the area in which to draw the button.
                Rectangle buttonArea = cellBounds;
                Rectangle buttonAdjustment =
                    this.BorderWidths(advancedBorderStyle);
                buttonArea.X += buttonAdjustment.X;
                buttonArea.Y += buttonAdjustment.Y;
                buttonArea.Height -= buttonAdjustment.Height;
                buttonArea.Width -= buttonAdjustment.Width;

                // Draw the disabled button.                
                ButtonRenderer.DrawButton(graphics, buttonArea,
                    PushButtonState.Disabled);

                // Draw the disabled button text. 
                if (this.FormattedValue != null && this.FormattedValue is String)
                {
                    TextRenderer.DrawText(graphics,
                        (string)this.FormattedValue,
                        this.DataGridView.Font,
                        buttonArea, SystemColors.GrayText);
                }
            }
            else
            {
                System.Reflection.Assembly thisExe = System.Reflection.Assembly.GetExecutingAssembly();
                System.IO.Stream file;
                file = thisExe.GetManifestResourceStream("BiologyDepartment.Misc_Files.images.editicon16.png");
                ImageList imgList = new ImageList()
                {
                    ImageSize = new System.Drawing.Size(16, 16)
                };
                imgList.Images.Add(Image.FromStream(file));
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
                graphics.DrawImage(imgList.Images[0], cellBounds);
            }
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
            ImageList imgList = new ImageList()
            {
                ImageSize = new System.Drawing.Size(16, 16)
            };
            imgList.Images.Add(Image.FromStream(file));
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            graphics.DrawImage(imgList.Images[0], cellBounds);
        }
    }

    public class DataGridViewAddButtonColumn : DataGridViewButtonColumn
    {
        public void EnableButton(bool bEnable)
        {
            this.Visible = bEnable;
        }
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
            ImageList imgList = new ImageList()
            {
                ImageSize = new System.Drawing.Size(16, 16)
            };
            imgList.Images.Add(Image.FromStream(file));
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            graphics.DrawImage(imgList.Images[0], cellBounds);
        }
    }

    public class DataGridViewDeleteButtonColumn : DataGridViewButtonColumn
    {
        public void EnableButton(bool bEnable)
        {
            this.Visible = bEnable;
        }
        public DataGridViewDeleteButtonColumn()
        {
            this.CellTemplate = new DataGridViewDeleteButtonCell();
            this.Width = 50;
            this.FlatStyle = FlatStyle.Standard;
            this.DefaultCellStyle.ForeColor = Color.White;
        }
    }
}
