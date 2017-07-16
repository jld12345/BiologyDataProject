using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using AForge.Imaging.Filters;
using System.Drawing.Imaging;
using System.IO;
using BiologyDepartment.Common;
using System.Diagnostics;

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
        private List<DataRow> lstRowId = new List<DataRow>();
        private int nPreviousCount = 0;
        private int nRowIndex = 0;
        private string jsonPath = "C:\\BiologyProjectFiles\\";
        private string jsonFile =  GlobalVariables.ExperimentNode.ExperimentNode.ID.ToString();
        private string jsonPics = "Images";
        #endregion

        #region Public Variables
        public static FrmExDataEntry inst;
        public DataTable dtReturn = new DataTable();
        public bool bHasConnectionError = false;
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

        public FrmExDataEntry(bool IsAdd, DataTable dtAnimals, int RowIndex)
        {
            DoubleBuffered = true;
            InitializeComponent();
            dtReturn = dtAnimals.Copy();
            nRowIndex = RowIndex;
            theAnimal = new AnimalData();
            SetMeasurements();
            SetLineWidthCombo();
            if(IsAdd)
                SetFields(dtReturn.NewRow());
            else
                SetFields(dtReturn.Rows[nRowIndex]);
            SetButtons(IsAdd);
            bIsAdd = IsAdd;
            CheckDirectory();
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

        public static FrmExDataEntry CreateInstance(bool IsAdd, DataTable dtAnimals, int RowIndex)
        {
            if (inst == null || inst.IsDisposed)
            {
                inst = new FrmExDataEntry(IsAdd, dtAnimals, RowIndex);
            }
            else
            {
                MessageBox.Show("An Instance of the Experiments Form is already open.", "Form Open", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return inst;
        }
        
        private void CheckDirectory()
        {
            if (!Directory.Exists(jsonPath))
                Directory.CreateDirectory(jsonPath);
            jsonPics = jsonPath + "\\" + jsonFile + "_" + jsonPics;
            if (!File.Exists(jsonPics))
                Directory.CreateDirectory(jsonPics);

        }

        #endregion

        #region Private Methods
        private void SetFields(DataRow row)
        {

            TextBox txtValue;
            CheckBox cb;
            Label lblTitle;
            int i = 25;
            if (row["EXPERIMENTS_JSONB_ID"] != DBNull.Value)
            {
                originalPic = _daoData.GetDataPicture("EXPERIMENTS_JSONB", Convert.ToInt32(row["EXPERIMENTS_JSONB_ID"]));
                SetPicBox(originalPic);
            }

            foreach (CustomColumns column in GlobalVariables.CustomColumns)
            {
                cb = new CheckBox()
                {
                    Checked = false,
                    Name = column.ColName.ToUpper(),
                    Text = "",
                    Visible = true,
                    Location = new Point(10, i),
                    Width = 15
                };
                pnlInput.Controls.Add(cb);

                lblTitle = new Label()
                {
                    Name = column.ColName.ToUpper(),
                    Text = column.ColName,
                    Location = new Point(cb.Width + 10, i),
                    Visible = true,
                    BorderStyle = BorderStyle.FixedSingle,
                    Width = 145,
                    Height = 20
                    
                };
                pnlInput.Controls.Add(lblTitle);
                ComboboxItem item = new ComboboxItem()
                {
                    Text = column.ColName,
                    Value = column.ColName.ToUpper()
                };
                cmbMeasurementParent.Items.Add(item);


                if (column.ColDataType.Equals("DROPDOWN"))
                    continue;
                else
                {
                    txtValue = new TextBox()
                    {
                        Name = column.ColName.ToUpper(),
                        Location = new Point(cb.Width + 10 + lblTitle.Width + 5, i),
                        Text = Convert.ToString(row[column.ColName]),
                        Visible = true,
                        BorderStyle = BorderStyle.FixedSingle,
                        Width = 185,
                        Height = 15,
                        TabIndex = i,
                        WordWrap = true
                    };
                    if (column.ColDataType.Equals("FORMULA")
                        || column.ColName.ToUpper().Equals("ROW_ID")
                        || column.ColName.ToUpper().Equals("CREATED_DATE")
                        || column.ColName.ToUpper().Equals("CREATED_USER")
                        || column.ColName.ToUpper().Equals("MODIFIED_DATE")
                        || column.ColName.ToUpper().Equals("MODIFIED_USER")
                        || column.ColName.ToUpper().Equals("DELETED_DATE")
                        || column.ColName.ToUpper().Equals("DELETED_USER")
                        || column.ColName.ToUpper().Equals("EXPERIMENTS_JSONB_ID")
                        || column.ColName.ToUpper().Equals("DATA PICTURE"))
                        txtValue.Enabled = false;
                    pnlInput.Controls.Add(txtValue);
                }
                i = i + 25;
            }
            cb = new CheckBox()
            {
                Checked = false,
                Name = "EXPERIMENTS_JSONB_ID",
                Text = "",
                Visible = true,
                Location = new Point(10, i),
                Width = 15,
            };
            pnlInput.Controls.Add(cb);

            lblTitle = new Label()
            {
                Name = "EXPERIMENTS_JSONB_ID",
                Text = "EXPERIMENTS_JSONB_ID",
                Location = new Point(cb.Width + 10, i),
                Visible = true,
                BorderStyle = BorderStyle.FixedSingle,
                Width = 145,
                Height = 20
            };
            pnlInput.Controls.Add(lblTitle);
            txtValue = new TextBox()
            {
                Name = "EXPERIMENTS_JSONB_ID",
                Location = new Point(cb.Width + 10 + lblTitle.Width + 5, i),
                Text = Convert.ToString(row["EXPERIMENTS_JSONB_ID"]),
                Visible = true,
                BorderStyle = BorderStyle.FixedSingle,
                Width = 185,
                Height = 15,
                TabIndex = i,
                Enabled = false
            };
            pnlInput.Controls.Add(txtValue);
        }

        private void SetPreviousFields(DataRow row)
        {
            int i = 0;
            if (row["EXPERIMENTS_JSONB_ID"] != DBNull.Value)
            {
                originalPic = _daoData.GetDataPicture("EXPERIMENTS_JSONB", Convert.ToInt32(row["EXPERIMENTS_JSONB_ID"]));
                SetPicBox(originalPic);
                pbImage.Invalidate();
            }
            foreach (var c in pnlInput.Controls.OfType<TextBox>())
            {
                if (c is TextBox)
                    c.Text = Convert.ToString(row[c.Name]);
            }
      
        }

        private void SetButtons(bool IsAdd)
        {
            btnAdd.Visible = IsAdd;
            btnExit.Visible = false;
        }

        private void FrmFishData_Load(object sender, EventArgs e)
        {
            BtnPrevious.Enabled = !bIsAdd;
            BtnPrevious.Visible = !bIsAdd;
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
                    RotateBicubic filter;
                    Bitmap img;
                    filter = new RotateBicubic(Convert.ToInt32(udRotatePhoto.Value), true);
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
            if (cbCaptureDevice.SelectedIndex == -1)
                cbCaptureDevice.SelectedIndex = 0;
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
                if (videoSource == null)
                    return;
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
            AddRowToReturnTable();
            if (videoSource == null)
                return;
            //Stop cam, change resolution, restart cam.
            videoSource.SignalToStop();
            videoSource.Stop();
        }

        private void AddRowToReturnTable(bool PreviousButton = false)
        {
            DateTime dtStamp = DateTime.Now;
            bool bConnectionError = false;
            DataRow row = dtReturn.NewRow();
            foreach (var con in pnlInput.Controls.OfType<TextBox>())
            {
                if (bIsAdd)
                {
                    if (string.IsNullOrEmpty(con.Text))
                        row[con.Name] = DBNull.Value;
                    else
                        row[con.Name] = con.Text;

                    if (con.Name.Equals("EXPERIMENTS_JSONB_ID"))
                    {
                        try
                        {
                            if (row["EXPERIMENTS_JSONB_ID"] == DBNull.Value)
                                row["EXPERIMENTS_JSONB_ID"] = _daoData.GetBulkIDs(1).Rows[0][0];
                        }
                        catch (Exception e)
                        {
                            Trace.WriteLine("Error getting jsonb_id.  " + Environment.NewLine + e.Message + Environment.NewLine + e.StackTrace);
                            row["EXPERIMENTS_JSONB_ID"] = 0;
                            bConnectionError = true;
                            bHasConnectionError = true;
                        }
                    }
                }
                else if (!dtReturn.Columns[con.Name].ReadOnly)
                {
                    if (string.IsNullOrEmpty(con.Text))
                    {
                        if (nRowIndex < 0)
                            dtReturn.Rows[0][con.Name] = DBNull.Value;
                        else
                            dtReturn.Rows[nRowIndex][con.Name] = DBNull.Value;
                    }
                    else
                    {
                        if (nRowIndex < 0)
                            dtReturn.Rows[0][con.Name] = con.Text;
                        else
                        {
                            if (!dtReturn.Columns[con.Name].ReadOnly)
                                dtReturn.Rows[nRowIndex][con.Name] = con.Text.Clone();
                        }
                    }
                }
            }
            if (!bIsAdd || nRowIndex > 0)
            {
                if (nRowIndex < 0)
                    row = dtReturn.Rows[0];
                else
                    row = dtReturn.Rows[nRowIndex];
            }
            //else     
            //dtReturn.Rows.Add(row);


            if (pbImage.BackgroundImage != null)
            {
                MemoryStream ms = new MemoryStream();
                pbImage.BackgroundImage.Save(ms, ImageFormat.Jpeg);
                byte[] photo_array = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(photo_array, 0, photo_array.Length);
                if (!bConnectionError)
                    try
                    {
                        _daoData.InsertPic("EXPERIMENTS_JSONB", Convert.ToInt32(row["EXPERIMENTS_JSONB_ID"]), photo_array);
                    }
                    catch (Exception e)
                    {
                        Trace.WriteLine("Error saving new pic.  " + Environment.NewLine + e.Message + Environment.NewLine + e.StackTrace);
                        bConnectionError = true;
                        bHasConnectionError = true;
                    }
                string temp = dtStamp.ToBinary().ToString();
                bmpOriginal.Save(jsonPics + "\\" + dtStamp.ToBinary().ToString() + ".bmp");
            }
            else if (originalPic != null && !bConnectionError)
                try
                {
                    _daoData.InsertPic("EXPERIMENTs_JSONB", Convert.ToInt32(row["EXPERIMENTS_JSONB_ID"]), originalPic);
                }
                catch (Exception e)
                {
                    Trace.WriteLine("Error saving original pic.  " + Environment.NewLine + e.Message + Environment.NewLine + e.StackTrace);
                    bConnectionError = true;
                    bHasConnectionError = true;
                }
            if (row["EXPERIMENTS_JSONB_ID"] != DBNull.Value && !bConnectionError)
            {
                try
                {
                    string sJson = util.SerializeJson(row, Convert.ToInt32(row["EXPERIMENTS_JSONB_ID"]), (bIsAdd) ? "ADDED" : "MODIFIED", bConnectionError);
                    File.AppendAllText(jsonPath + jsonFile, "Timestamp " + dtStamp.ToBinary().ToString() + Environment.NewLine + "Date:  " + dtStamp.ToUniversalTime().ToString() + Environment.NewLine + "JSON:  " + sJson + Environment.NewLine);
                }
                catch (Exception e)
                {
                    Trace.WriteLine($"Error serializing row.  {Environment.NewLine}{e.Message}{Environment.NewLine}{e.StackTrace}");
                    bConnectionError = true;
                    bHasConnectionError = true;
                }
            }
            else
            { 
                string sJson = util.SerializeJson(row, 0, (bIsAdd) ? "ADDED" : "MODIFIED", bConnectionError);
                File.AppendAllText(jsonPath + jsonFile, "Timestamp " + dtStamp.ToBinary().ToString() + Environment.NewLine + "Date:  " + dtStamp.ToUniversalTime().ToString() + Environment.NewLine + "JSON:  " + sJson + Environment.NewLine);
            }

            udZoom.Enabled = false;
            pbImage.BackgroundImage = null;
            bmpOriginal = null;
            pointLine.Clear();
            pointCalibrate.Clear();
            txtMeasure.Text = "";
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
                        g.DrawEllipse(p, pointLine[i].X-2, pointLine[i].Y-2, 4, 4);
                        dLineLength += Math.Sqrt(Math.Pow((pointLine[i + 1].Y - pointLine[i].Y), 2) +
                            Math.Pow((pointLine[i + 1].X - pointLine[i].X), 2));
                    }
                }
                else if(pointLine.Count == 1)
                    g.DrawEllipse(p, pointLine[0].X-2, pointLine[0].Y-2, 4, 4);

                if (pointCalibrate.Count > 1)
                {
                    g.DrawLine(p, pointCalibrate[0], pointCalibrate[1]);
                    g.DrawEllipse(p, pointCalibrate[0].X - 2, pointCalibrate[0].Y - 2, 4, 4);
                    g.DrawEllipse(p, pointCalibrate[1].X - 2, pointCalibrate[1].Y - 2, 4, 4);
                }
                else if (pointCalibrate.Count == 1)
                    g.DrawEllipse(p, pointCalibrate[0].X - 2, pointCalibrate[0].Y - 2, 4, 4);
                else if (pointCalibrate.Count == 0)
                    pbImage.BackgroundImage = bmpOriginal;
            }

            if (!string.IsNullOrEmpty(txtCalibration.Text.ToString()))
                txtMeasure.Text = (Math.Round((dLineLength / Convert.ToDouble(txtCalibration.Text)), 2).ToString());
            if (cmbMeasurementParent.SelectedItem != null)
            {
                foreach (var c in pnlInput.Controls.Find(cmbMeasurementParent.SelectedItem.ToString(), true))
                {
                    if (c is TextBox && !string.IsNullOrEmpty(txtCalibration.Text.ToString()))
                        c.Text = (Math.Round((dLineLength / Convert.ToDouble(txtCalibration.Text)), 2).ToString());
                }
            }

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
                if (string.IsNullOrEmpty(txtPixelCount.Text.ToString()))
                    pointCalibrate.Add(e.Location);
                if (pointCalibrate.Count > 1 && string.IsNullOrEmpty(txtPixelCount.Text.ToString()))
                {
                    dCalLength = Math.Round(Math.Sqrt(Math.Pow((pointCalibrate[1].Y - pointCalibrate[0].Y), 2) +
                        Math.Pow((pointCalibrate[1].X - pointCalibrate[0].X), 2)), 2);
                    txtPixelCount.Text = dCalLength.ToString();
                }
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
                    else if (pointCalibrate.Count == 0)
                        btnClearAll.PerformClick();
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
            if (e.Button == MouseButtons.Middle)
            {
                if (string.IsNullOrEmpty(txtCalibration.Text.ToString()))
                {
                    double.TryParse(txtUnitsMeasured.Text, out double units);
                    txtCalibration.Text = (dCalLength / units).ToString();
                }
                else
                {
                    if (pointLine.Count > 0)
                    {
                        pointLine.RemoveAt(pointLine.Count - 1);
                        pbImage.Invalidate();
                    }
                }
            }
            else if (e.Button == MouseButtons.Left)
                BtnPrevious.PerformClick();
            else if (e.Button == MouseButtons.Right)
                BtnNext.PerformClick();
        }

        private void BtnCalibrate_Click(object sender, EventArgs e)
        {
            double.TryParse(txtUnitsMeasured.Text, out double units);
            txtCalibration.Text = (dCalLength/units).ToString();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            txtPixelCount.Text = "";
            txtUnitsMeasured.Text = "";
            txtCalibration.Text = "";
            txtMeasure.Text = "";
            pointCalibrate.Clear();
            pointLine.Clear();
            pbImage.Invalidate();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtPixelCount.Text = "";
            txtUnitsMeasured.Text = "";
            txtCalibration.Text = "";
            txtMeasure.Text = "";

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

            cbLineWidth.SelectedIndex = 3;
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
            pbImage.Cursor = GlobalVariables.CircleCrossHairCursor;
            //pbImage.Cursor = Cursors.Cross;
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
            AddNewRow();
        }

        private void AddNewRow()
        {
            foreach (CheckBox cb in pnlInput.Controls.OfType<CheckBox>())
            {
                foreach (var c in pnlInput.Controls.Find(cb.Name, true))
                {
                    if (c is TextBox && !cb.Checked)
                        c.Text = "";
                }
            }
            btnClearImage.PerformClick();
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

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            if (bIsAdd)
                return;
            AddRowToReturnTable(true);
            if (nRowIndex - 1 >= 0)
            {
                SetPreviousFields(dtReturn.Rows[nRowIndex - 1]);
                nRowIndex--;
            }
            else
            {
                SetPreviousFields(dtReturn.Rows[dtReturn.Rows.Count - 1]);
                nRowIndex = dtReturn.Rows.Count - 1;
            }
        }

        private void TxtMeasure_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!string.IsNullOrEmpty(cmbMeasurementParent.Text))
            {
                foreach (var c in pnlInput.Controls.Find(cmbMeasurementParent.SelectedItem.ToString(), true))
                {
                    if (c is TextBox)
                        c.Text = txtMeasure.Text;
                }
            }

        }

        private void TxtMeasure_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbMeasurement.Text))
            {
                foreach (var c in pnlInput.Controls.Find(cmbMeasurement.SelectedItem.ToString(), true))
                {
                    if (c is TextBox)
                        c.Text = txtMeasure.Text;
                }
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            AddRowToReturnTable();

            if (bIsAdd)
                AddNewRow();
            else if (nRowIndex + 1 < dtReturn.Rows.Count && nRowIndex + 1 >= 0)
            {
                SetPreviousFields(dtReturn.Rows[nRowIndex + 1]);
                nRowIndex++;
            }
            else
            {
                SetPreviousFields(dtReturn.Rows[0]);
                nRowIndex = 0;
            }
        }

        private void btnClearImage_Click(object sender, EventArgs e)
        {
            btnClearAll.PerformClick();
            pbImage.BackgroundImage = null;
            bmpOriginal = null;
            bmpCanvas = null;
            pbImage.Invalidate();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Convert.ToString(Value);
        }
    }
}
﻿
