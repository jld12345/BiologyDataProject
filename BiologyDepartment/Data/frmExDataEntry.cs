using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging.Filters;
using System.Drawing.Imaging;
using System.IO;
using NpgsqlTypes;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;
using BiologyDepartment.Common;

namespace BiologyDepartment
{
    public partial class FrmExDataEntry : Form
    {
        #region Private Variables
        private AnimalData theAnimal;
        private DaoData _daoData = new DaoData();
        private VideoCaptureDevice videoSource;
        private FilterInfoCollection captureDevice;
        private double dLineLength = 0;
        private double dCalLength = 0;
        private Point oldPoint = new Point(0, 0);
        private Point newPoint = new Point(0, 0);
        private Point mouseDownPosition = Point.Empty;
        private Point mouseMovePosition = Point.Empty;
        private Dictionary<Point, Point> Circles = new Dictionary<Point, Point>();
        private List<Point> pointLine = new List<Point>();
        private List<Point> pointCalibrate = new List<Point>();
        private Bitmap bmpOriginal;
        private Bitmap bmpCanvas;
        private bool bSavePic = false;
        private byte[] originalPic;
        private bool bIsAdd = false;
        private CommonUtil util = new CommonUtil();
        #endregion

        #region Public Variables
        public static FrmExDataEntry inst;
        public DataTable dtReturn = new DataTable();
        #endregion

        #region Public Methods
        public FrmExDataEntry()
        {
            DoubleBuffered = true;
            InitializeComponent();
            theAnimal = new AnimalData();
            SetMeasurements();
            SetLineWidthCombo();
        }

        public FrmExDataEntry(int id)
        {
            DoubleBuffered = true;
            InitializeComponent();
            theAnimal = new AnimalData();
            SetMeasurements();
            SetLineWidthCombo();
        }

        public FrmExDataEntry(bool IsAdd, ref DataRow row)
        {
            DoubleBuffered = true;
            InitializeComponent();
            theAnimal = new AnimalData();
            SetMeasurements();
            SetLineWidthCombo();
            SetFields(ref row);
            SetButtons(IsAdd);
            bIsAdd = IsAdd;
        }

        public static FrmExDataEntry CreateInstance()
        {
            if (inst == null || inst.IsDisposed)
            {
                inst = new FrmExDataEntry();
            }
            else
            {
                MessageBox.Show("An Instance of the Experiments Form is already open.", "Form Open", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return inst;
        }

        public static FrmExDataEntry CreateInstance(int id)
        {
            if (inst == null || inst.IsDisposed)
            {
                inst = new FrmExDataEntry(id);
            }
            else
            {
                MessageBox.Show("An Instance of the Experiments Form is already open.", "Form Open", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return inst;
        }

        public static FrmExDataEntry CreateInstance(bool IsAdd, ref DataRow row)
        {
            if (inst == null || inst.IsDisposed)
            {
                inst = new FrmExDataEntry(IsAdd, ref row);
            }
            else
            {
                MessageBox.Show("An Instance of the Experiments Form is already open.", "Form Open", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return inst;
        }
        #endregion

        #region Private Methods
        private void SetFields(ref DataRow row)
        {
            dtReturn = row.Table.Clone();

            int i = 0;
            if (row["EXPERIMENTS_JSONB_ID"] != DBNull.Value)
            {
                originalPic = _daoData.GetDataPicture("EXPERIMENTS_JSONB", Convert.ToInt32(row["EXPERIMENTS_JSONB_ID"]));
                SetPicBox(originalPic);
            }
            foreach (DataColumn col in row.Table.Columns)
            {
                Label lblTitle = new Label()
                {
                    Name = col.ColumnName,
                    Text = col.Caption,
                    Location = new Point(0, i),
                    Visible = true,
                    BorderStyle = BorderStyle.FixedSingle,
                    Width = 150,
                    Height = 20
                };
                pnlInput.Controls.Add(lblTitle);

                TextBox txtValue = new TextBox()
                {
                    Name = col.ColumnName,
                    Location = new Point(lblTitle.Width + 5, i),
                    Text = Convert.ToString(row[col.ColumnName]),
                    Visible = true,
                    BorderStyle = BorderStyle.FixedSingle,
                    Width = 195,
                    Height = 15
                };
                if (col.ColumnName.ToUpper().Equals("ROW_ID") || col.ColumnName.ToUpper().Equals("CREATED_DATE")
                    || col.ColumnName.ToUpper().Equals("CREATED_USER") || col.ColumnName.ToUpper().Equals("MODIFIED_DATE")
                    || col.ColumnName.ToUpper().Equals("MODIFIED_USER") || col.ColumnName.ToUpper().Equals("DELETED_DATE")
                    || col.ColumnName.ToUpper().Equals("DELETED_USER") || col.ColumnName.ToUpper().Equals("EXPERIMENTS_JSONB_ID")
                    || col.ColumnName.ToUpper().Equals("DATA PICTURE"))
                    txtValue.Enabled = false;
                foreach(CustomColumns column in GlobalVariables.CustomColumns)
                {
                    if(column.ColName.ToUpper().Equals(col.ColumnName.ToUpper()))
                    {
                        if(column.ColDataType.Equals("FORMULA"))
                            txtValue.Enabled = false;
                    }
                }
                pnlInput.Controls.Add(txtValue);
                i = i + 25;
            }
        }

        private void SetButtons(bool IsAdd)
        {
            btnAdd.Visible = IsAdd;
            btnExit.Visible = false;
        }

        private void FrmFishData_Load(object sender, EventArgs e)
        {
            this.pbImage.BackgroundImageLayout = ImageLayout.Center;
            //List all available video sources. (That can be webcams as well as tv cards, etc)
            captureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            //Check if atleast one video source is available

            //For example use first video device. You may check if this is your webcam.
            cbCaptureDevice.Items.Clear();

            if (captureDevice.Count > 0)
            {
                cbCaptureDevice.Items.Clear();

                foreach (FilterInfo device in captureDevice)
                {
                    if (!(cbCaptureDevice.Items.Contains(device.Name)))
                        cbCaptureDevice.Items.Add(device.Name);
                }

                cbCaptureDevice.SelectedItem = 0;
            }

        }

        private void VideoSource_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            try
            {
                    pbVideo.Image = (Bitmap)eventArgs.Frame.Clone();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed saving the snapshot.\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Cast the frame as Bitmap object and don't forget to use ".Clone()" otherwise
            //you'll probably get access violation exceptions
        }

        private void SetPicBox(byte[] imageBytes)
        {
            if (imageBytes == null)
            {
                udZoom.Enabled = false;
                return;
            }
            MemoryStream mStream = new MemoryStream(imageBytes)
            {
                Position = 0
            };
            Image img = Image.FromStream(mStream);

            mStream.Close();
            mStream.Dispose();

            //pbImage.Image = img;
            pbImage.BackgroundImage = new Bitmap(img);
            bmpCanvas = new Bitmap(img);
            bmpOriginal = new Bitmap(img);
            udZoom.Enabled = true;
        }

        private void BtnPic_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pbVideo.Image != null)
                {
                    udRotatePhoto.Value = 0;
                    RotateBicubic filter;
                    Bitmap img;
                    filter = new RotateBicubic(0, true);
                    // apply the filter
                    img = filter.Apply((Bitmap)pbVideo.Image.Clone());
                    pbImage.BackgroundImage = new Bitmap(img);
                    bmpOriginal = new Bitmap(pbImage.BackgroundImage);
                    bmpCanvas = new Bitmap(pbImage.BackgroundImage);
                    udZoom.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed saving the snapshot.\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CbCaptureDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(videoSource != null)
            {
                videoSource.SignalToStop();
                videoSource.Stop();
            }
            videoSource = new VideoCaptureDevice(captureDevice[cbCaptureDevice.SelectedIndex].MonikerString);

            //Check if the video device provides a list of supported resolutions
            if (videoSource.VideoCapabilities.Length > 0)
            {
                cbResolution.Items.Clear();

                for (int i = 0; i < videoSource.VideoCapabilities.Length; i++)
                {
                    if (!(cbResolution.Items.Contains(videoSource.VideoCapabilities[i].FrameSize.Width.ToString())))
                        cbResolution.Items.Add(videoSource.VideoCapabilities[i].FrameSize.Width.ToString());
                }
                cbResolution.SelectedIndex = 0;
            }
            videoSource.SetCameraProperty(CameraControlProperty.Focus, 25, CameraControlFlags.None);
            videoSource.NewFrame += new AForge.Video.NewFrameEventHandler(VideoSource_NewFrame);
        }

        private void CbResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Stop cam, change resolution, restart cam.
                videoSource.SignalToStop();
                videoSource.Stop();

                videoSource.VideoResolution = videoSource.VideoCapabilities[cbResolution.SelectedIndex];

                videoSource.NewFrame -= VideoSource_NewFrame;
                videoSource.NewFrame += new AForge.Video.NewFrameEventHandler(VideoSource_NewFrame);

                videoSource.Start();
            }
            catch (System.Threading.ThreadAbortException te)
            {
                MessageBox.Show(te.ToString(), "warning", MessageBoxButtons.OK);
            }
        }

        private void FrmFishData_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void AddRowToReturnTable()
        {
            DataRow row = dtReturn.NewRow();
            foreach (Control con in pnlInput.Controls)
            {
                if (con.GetType() == typeof(TextBox))
                {
                    if (string.IsNullOrEmpty(con.Text))
                        row[con.Name] = DBNull.Value;
                    else
                        row[con.Name] = con.Text;
                }
            }

            if (row["EXPERIMENTS_JSONB_ID"] == DBNull.Value)
                row["EXPERIMENTS_JSONB_ID"] = _daoData.GetBulkIDs(1).Rows[0][0];

            if (pbImage.BackgroundImage != null)
            {
                MemoryStream ms = new MemoryStream();
                pbImage.BackgroundImage.Save(ms, ImageFormat.Jpeg);
                byte[] photo_array = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(photo_array, 0, photo_array.Length);
                _daoData.InsertPic("EXPERIMENTS_JSONB", Convert.ToInt32(row["EXPERIMENTS_JSONB_ID"]), photo_array);
            }
            else if (originalPic != null)
                _daoData.InsertPic("EXPERIMENTs_JSONB", Convert.ToInt32(row["EXPERIMENTS_JSONB_ID"]), originalPic);

            if (row["EXPERIMENTS_JSONB_ID"] != DBNull.Value)
                util.SerializeJson(row, Convert.ToInt32(row["EXPERIMENTS_JSONB_ID"]), bIsAdd == true ? "ADDED":"MODIFIED");
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            fdUploadPic.Title = "Open Image";
            DialogResult result = fdUploadPic.ShowDialog();
            if (result == DialogResult.OK)
            {
                pbImage.BackgroundImage = new Bitmap(fdUploadPic.FileName);
                bmpOriginal = new Bitmap(pbImage.BackgroundImage);
            }

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            bSavePic = true;
        }

        private void PbImage_Paint(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(btnLineColor.BackColor, Convert.ToInt32(cbLineWidth.SelectedItem)))
            {

                var g = e.Graphics;

                if (pointLine.Count > 1 && !string.IsNullOrEmpty(txtCalibration.Text.ToString()))
                {
                    dLineLength = 0;

                    for (int i = 0; i < pointLine.Count - 1; i++)
                    {
                        g.DrawLine(p, pointLine[i], pointLine[i + 1]);

                        dLineLength += Math.Sqrt(Math.Pow((pointLine[i + 1].Y - pointLine[i].Y), 2) +
                            Math.Pow((pointLine[i + 1].X - pointLine[i].X), 2));
                    }
                }

                if (pointCalibrate.Count > 1)
                {
                    g.DrawLine(p, pointCalibrate[0], pointCalibrate[1]);
                    dCalLength = Math.Round(Math.Sqrt(Math.Pow((pointCalibrate[1].Y - pointCalibrate[0].Y), 2) +
                        Math.Pow((pointCalibrate[1].X - pointCalibrate[0].X), 2)), 2);
                }
            }

            if (!string.IsNullOrEmpty(txtCalibration.Text.ToString()))
                txtMeasure.Text = (Math.Round((dLineLength / Convert.ToDouble(txtCalibration.Text)), 2).ToString());

            if (pbImage.BackgroundImage != null)
                this.pbImage.AutoScrollMinSize = this.pbImage.BackgroundImage.Size;
        }

        private void PbImage_MouseMove(object sender, MouseEventArgs e)
        {
            // this.SuspendLayout();
            //using (Graphics g = pbImage.CreateGraphics())
            //{
            //    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //    using (Pen p = new Pen(btnLineColor.BackColor, Convert.ToInt32(cbLineWidth.SelectedItem)))
            //    {
            //        if (string.IsNullOrEmpty(txtCalibration.Text.ToString()) && pointCalibrate.Count == 1)
            //        {
            //            pbImage.BackgroundImage = bmpCanvas;
            //            g.DrawLine(p, pointCalibrate[0], e.Location);
            //        }
            //        else if (pointLine.Count >= 1)
            //            g.DrawLine(p, pointLine[pointLine.Count - 1], e.Location);

            //        pbImage.Invalidate();
            //        Thread.Sleep(100);
            //    }
            //}
            //g.Dispose();
            //this.ResumeLayout();
        }
        private void PbImage_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (string.IsNullOrEmpty(txtCalibration.Text.ToString()))
                    pointCalibrate.Add(e.Location);
                else
                    pointLine.Add(e.Location);

                pbImage.Invalidate();
            }
            else if (e.Button == MouseButtons.Middle)
                btnCaptureImage.PerformClick();
            else if (e.Button == MouseButtons.Right)
            {
                if (string.IsNullOrWhiteSpace(txtCalibration.Text))
                {
                    if (pointCalibrate.Count > 0)
                    {
                        pointCalibrate.RemoveAt(pointCalibrate.Count - 1);
                        pbImage.Invalidate();
                    }
                }
                else if (pointLine.Count > 0)
                {
                    pointLine.RemoveAt(pointLine.Count - 1);
                    pbImage.Invalidate();
                }
            }

        }

        private void SetMeasurements()
        {
            cmbMeasurement.Items.Add("INCH");
            cmbMeasurement.Items.Add("MM");
            cmbMeasurement.Items.Add("CM");
            cmbMeasurement.SelectedIndex = 0;
        }

        private void PbImage_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCalibration.Text.ToString()))
                txtCalibration.Text = dCalLength.ToString();
            else
            {
                if (pointLine.Count > 0)
                {
                    pointLine.RemoveAt(pointLine.Count - 1);
                    pbImage.Invalidate();
                }
            }
        }

        private void BtnCalibrate_Click(object sender, EventArgs e)
        {
            txtCalibration.Text = dCalLength.ToString();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            txtCalibration.Text = "";
            txtMeasure.Text = "";
            pointCalibrate.Clear();
            pointLine.Clear();
            pbImage.Invalidate();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtCalibration.Text = "";
        }

        private void BtnLineColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnLineColor.BackColor = colorDialog1.Color;
            }
            pbImage.Invalidate();
        }

        private void SetLineWidthCombo()
        {
            for (int i = 0; i <= 10; i++)
                cbLineWidth.Items.Add(i);

            cbLineWidth.SelectedIndex = 1;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.Stop();
                videoSource = null;
            }
            this.Close();
        }

        private void BtnResetLine_Click(object sender, EventArgs e)
        {
            pointLine.Clear();
            dLineLength = 0;
            pbImage.Invalidate();
            txtMeasure.Text = "";
        }

        private void PbImage_MouseEnter(object sender, EventArgs e)
        {
            pbImage.Cursor = Cursors.Cross;
        }

        private void PbImage_MouseLeave(object sender, EventArgs e)
        {
            pbImage.Cursor = Cursors.Arrow;
        }

        private void UdZoom_ValueChanged(object sender, EventArgs e)
        {
            if (udZoom.Value < 25 || udZoom.Value > 300)
            {
                if (udZoom.Value < 25)
                    udZoom.Value = 25;
                else
                    udZoom.Value = 300;

                MessageBox.Show("Image zoom cannot be less than 25% or greater than 300%.", "Limits Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Size newSize = new Size((int)(bmpOriginal.Width * udZoom.Value / 100), (int)(bmpOriginal.Height * udZoom.Value / 100));
            pbImage.BackgroundImage = new Bitmap(bmpOriginal, newSize);

        }

        private void BtnSaveExit_Click(object sender, EventArgs e)
        {
            //Stop and free the webcam object if application is closing
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.Stop();
                videoSource = null;
            }
            AddRowToReturnTable();
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddRowToReturnTable();
            foreach (Control c in pnlInput.Controls)
            {
                if (c is TextBox)
                    c.Text = "";
            }
            udZoom.Enabled = false;
            pbImage.BackgroundImage = null;
            pointLine.Clear();
            pointCalibrate.Clear();
        }
        #endregion

        private void ToolStripEx1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void PbImage_Paint(object sender, MouseEventArgs e)
        {

        }

        private void UdRotatePhoto_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (udRotatePhoto.Value < 0)
                    udRotatePhoto.Value = 315;
                else if (udRotatePhoto.Value > 315)
                    udRotatePhoto.Value = 0;

                if (this.pbImage.BackgroundImage != null)
                {
                    RotateBicubic filter;
                    Bitmap img;
                    filter = new RotateBicubic(Convert.ToInt32(udRotatePhoto.Value), true);
                    // apply the filter
                    
                    img = filter.Apply(AForge.Imaging.Image.Clone(bmpOriginal, PixelFormat.Format24bppRgb));
                    pbImage.BackgroundImage = img;

                    udZoom.Enabled = true;
                    pbImage.Invalidate();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed saving the snapshot.\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UdRotateVideo_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            /*videoSource.SignalToStop();
            videoSource.Stop();
            //videoSource.SetCameraProperty(CameraControlProperty.Zoom, Convert.ToInt32(numericUpDown1.Value), CameraControlFlags.Auto);
            videoSource.GetCameraProperty(CameraControlProperty.Zoom, out int temp, out CameraControlFlags flags);
            videoSource.Start();*/
        }
    }
}
﻿
