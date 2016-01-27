using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using System.IO;
using NpgsqlTypes;

namespace BiologyDepartment
{
    public partial class frmAuthor : Form
    {
        private static frmAuthor inst;
        private daoAuthors _authors = new daoAuthors();
        private daoAuthorEX _authorsEX = new daoAuthorEX();
        private daoExperiments _experiment = new daoExperiments();
        private DataSet dsAuthor;
        private DataTable dtAuthor;
        private VideoCaptureDevice videoSource;
        private FilterInfoCollection captureDevice;
        private bool bIsEdit = false;
        private int intExID = 0;
        private int intAuthor = 0;
        private bool bHasChanged = false;

        public event EventHandler<frmAuthorClosedEventArgs> RaiseAuthorClosedEvent;

        public frmAuthor()
        {
            InitializeComponent();
            SetAuthors();
        }

        public frmAuthor(int id)
        {
            InitializeComponent();
            SetAuthors();
            intExID = id;
        }

        public frmAuthor(int id, int author)
        {
            InitializeComponent();
            intAuthor = author;
            SetAuthors();
            intExID = id;
            
        }

        public static frmAuthor CreateInstance()
        {
            if (inst == null || inst.IsDisposed)
            {
                inst = new frmAuthor();
            }
            else
            {
                MessageBox.Show("An Instance of the Experiments Form is already open.", "Form Open", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return inst;
        }

        public static frmAuthor CreateInstance(int id)
        {
            if (inst == null || inst.IsDisposed)
            {
                inst = new frmAuthor(id);
            }
            else
            {
                MessageBox.Show("An Instance of the Experiments Form is already open.", "Form Open", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return inst;
        }

        public static frmAuthor CreateInstance(int id, int author)
        {
            if (inst == null || inst.IsDisposed)
            {
                inst = new frmAuthor(id, author);
            }
            else
            {
                MessageBox.Show("An Instance of the Experiments Form is already open.", "Form Open", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return inst;
        }

        private void frmAuthor_Load(object sender, EventArgs e)
        {
            
        }

        public void Initialize()
        {
            //List all available video sources. (That can be webcams as well as tv cards, etc)
            captureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            //Check if atleast one video source is available
            if (captureDevice.Count > 0)
            {
                cbDevice.Items.Clear();

                foreach (FilterInfo device in captureDevice)
                {
                    if(!(cbDevice.Items.Contains(device.Name)))
                        cbDevice.Items.Add(device.Name);
                }

                cbDevice.SelectedItem = 0;
            }
            
        }

        void videoSource_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            //Cast the frame as Bitmap object and don't forget to use ".Clone()" otherwise
            //you'll probably get access violation exceptions
            pbCurPic.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void frmAuthor_FormClosed(object sender, EventArgs e)
        {
            //Stop and free the webcam object if application is closing
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
            }
            
        }

        private void btnTakePic_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pbCurPic.Image != null)
                {
                    pbAuthor.Image = (Bitmap)pbCurPic.Image.Clone();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed saving the snapshot.\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelPic_Click(object sender, EventArgs e)
        {
            pbAuthor.Image = null;
            bHasChanged = true;
        }

        private void btnSavePic_Click(object sender, EventArgs e)
        {
            if (pbAuthor.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                pbAuthor.Image.Save(ms, ImageFormat.Jpeg);
                byte[] photo_array = new byte[ms.Length];
                int id = cbLName.SelectedIndex;


                ms.Position = 0;
                ms.Read(photo_array, 0, photo_array.Length);
                _authors.InsertPic("AUTHORS", Convert.ToInt32(cbLName.SelectedValue.ToString()), photo_array);

                /*_authors = new daoAuthors();
                SetAuthors();
                cbLName.SelectedIndex = id;*/
                bHasChanged = true;
            }
            else
                MessageBox.Show("The image you are trying to save is null", "Null Image", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void SetAuthors()
        {
            dsAuthor = _authors.getAuthors();
            dtAuthor = dsAuthor.Tables[0];

            cbLName.DataSource = dtAuthor;
            cbLName.ValueMember = "AUTHOR_ID";
            cbLName.DisplayMember = "AUTHOR_LNAME";

            btnNew.Enabled = true;
            btnEdit.Enabled = true;
            btnDel.Enabled = true;
            btnTakePic.Enabled = true;
            btnDelPic.Enabled = true;
            btnSave.Enabled = false;
            btnTakePic.Enabled = false;
            btnSavePic.Enabled = false;
            btnDelPic.Enabled = false;

            bIsEdit = false;

            if (intAuthor > 0)
            {
                cbLName.SelectedValue = intAuthor;
                this.btnEdit_Click(this, new EventArgs());
            }

        }

        private void cbLName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //byte[] picBox = dtAuthor.Rows[cbLName.SelectedIndex]["AUTHOR_PIC"] as byte[];
            txtFName.Text = dtAuthor.Rows[cbLName.SelectedIndex]["AUTHOR_FNAME"].ToString();
            txtMI.Text = dtAuthor.Rows[cbLName.SelectedIndex]["AUTHOR_MNAME"].ToString();
            txtEmail.Text = dtAuthor.Rows[cbLName.SelectedIndex]["AUTHOR_EMAIL"].ToString();
            txtAff.Text = dtAuthor.Rows[cbLName.SelectedIndex]["AUTHOR_ASSOC"].ToString();
            txtDept.Text = dtAuthor.Rows[cbLName.SelectedIndex]["AUTHOR_DEPT"].ToString();
            /*if (picBox != null && picBox.Length > 0)
                setPicBox(picBox);
            else*/
                pbAuthor.Image = null;
        }

        private void setPicBox(byte[] imageBytes)
        {
            MemoryStream mStream = new MemoryStream(imageBytes);
            mStream.Position = 0;

            Image img = Image.FromStream(mStream);

            mStream.Close();
            mStream.Dispose();

            pbAuthor.Image = img;
        }

        private void cbRes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Stop cam, change resolution, restart cam.
            videoSource.SignalToStop();
            videoSource.Stop();

            videoSource.VideoResolution = videoSource.VideoCapabilities[cbRes.SelectedIndex];

            videoSource.NewFrame -= videoSource_NewFrame;
            videoSource.NewFrame += new AForge.Video.NewFrameEventHandler(videoSource_NewFrame);

            videoSource.Start();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            cbLName.Text = "";
            txtFName.Text = "";
            txtMI.Text = "";
            txtEmail.Text = "";
            txtAff.Text = "";
            txtDept.Text = "";
            txtFName.Enabled = true;
            txtMI.Enabled = true;
            txtEmail.Enabled = true;
            txtAff.Enabled = true;
            txtDept.Enabled = true;
            cbLName.DropDownStyle = ComboBoxStyle.Simple;
            cbLName.Text = "";

            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;
            btnTakePic.Enabled = false;
            btnDelPic.Enabled = false;
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Author rec = new Author();
            rec.LastName = cbLName.Text;
            rec.FirstName = txtFName.Text;
            rec.MI = txtMI.Text;
            rec.Department = txtDept.Text;
            rec.Email = txtEmail.Text;
            rec.Association = txtAff.Text;

            if (bIsEdit)
            {
                rec.ID = Convert.ToInt32(cbLName.SelectedValue);
                _authors.updateRecord(rec);
            }
            else
                _authors.insertRecord(rec);

            txtFName.Enabled = false;
            txtMI.Enabled = false;
            txtEmail.Enabled = false;
            txtAff.Enabled = false;
            txtDept.Enabled = false;
            cbLName.DropDownStyle = ComboBoxStyle.DropDownList;
            SetAuthors();

            int id = cbLName.Items.Count - 1;
            cbLName.SelectedIndex = id;

            btnNew.Enabled = true;
            btnEdit.Enabled = true;
            btnDel.Enabled = true;
            btnTakePic.Enabled = true;
            btnDelPic.Enabled = true;
            btnSave.Enabled = false;

            bHasChanged = true;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            bIsEdit = true;

            txtFName.Enabled = true;
            txtMI.Enabled = true;
            txtEmail.Enabled = true;
            txtAff.Enabled = true;
            txtDept.Enabled = true;
            cbLName.DropDownStyle = ComboBoxStyle.Simple;

            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;
            btnTakePic.Enabled = true;
            btnDelPic.Enabled = true;
            btnSavePic.Enabled = true;
            btnSave.Enabled = true;


        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;
            btnTakePic.Enabled = false;
            btnDelPic.Enabled = false;
            btnSave.Enabled = false;

            int id = Convert.ToInt32(cbLName.SelectedValue);
            _authors.deleteRecord(id);

            SetAuthors();

            bHasChanged = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtFName.Enabled = false;
            txtMI.Enabled = false;
            txtEmail.Enabled = false;
            txtAff.Enabled = false;
            txtDept.Enabled = false;
            cbLName.DropDownStyle = ComboBoxStyle.DropDownList;
            SetAuthors();
        }

        private void btnAddExp_Click(object sender, EventArgs e)
        {
            Author_Ex rec = new Author_Ex();
            rec.Author_ID = Convert.ToInt32(cbLName.SelectedValue.ToString());
            rec.EX_ID = intExID;
            rec.Rank = 99;

            _authorsEX.insertRecord(rec);
            bHasChanged = true;
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            frmAuthorClosedEvent(new frmAuthorClosedEventArgs(bHasChanged));

            this.Close();
        }

        private void cbDevice_SelectedIndexChanged(object sender, EventArgs e)
        {            
            videoSource = new VideoCaptureDevice(captureDevice[cbDevice.SelectedIndex].MonikerString);

            //Check if the video device provides a list of supported resolutions
            if (videoSource.VideoCapabilities.Length > 0)
            {
                cbRes.Items.Clear();

                for (int i = 0; i < videoSource.VideoCapabilities.Length; i++)
                {
                    if (!(cbRes.Items.Contains(videoSource.VideoCapabilities[i].FrameSize.Width.ToString())))
                    cbRes.Items.Add(videoSource.VideoCapabilities[i].FrameSize.Width.ToString());
                }
                cbRes.SelectedIndex = 0;
            }

            videoSource.NewFrame += new AForge.Video.NewFrameEventHandler(videoSource_NewFrame);
        }

        protected virtual void frmAuthorClosedEvent(frmAuthorClosedEventArgs e)
        {
            EventHandler<frmAuthorClosedEventArgs> handler = RaiseAuthorClosedEvent;

            // Event will be null if there are no subscribers 
            if (handler != null)
            {
                // Use the () operator to raise the event.
                e.IsChange = bHasChanged;
                handler(this, e);
            }
        }
    }

    public class frmAuthorClosedEventArgs : EventArgs
    {
        public frmAuthorClosedEventArgs(bool isChange)
        {
            DataChange = isChange;
        }
        private bool DataChange;
        public bool IsChange
        {
            get { return DataChange; }
            set { DataChange = value; }
        }
    }
    }

