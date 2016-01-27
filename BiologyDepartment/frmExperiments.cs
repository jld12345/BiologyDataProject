using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BiologyDepartment
{
    public partial class frmExperiments : Form
    {
        //private static frmExperiments inst;
        private static frmExperiments inst;
        private daoExperiments _daoExperiments = null; 
        private daoAuthors _daoAuthor = null;
        //private daoAuthorEX _daoAuthorEx = new daoAuthorEX();
        private DataSet dsExperiments = new DataSet();
        private DataSet dsAuthors = new DataSet();
        private DataSet dsAuthorEx = new DataSet();
        private DataTable dtExperiments = new DataTable();
        private DataTable dtAuthor = new DataTable();
        private DataTable dtAuthorEx = new DataTable();
        private List<string> txtBoxList = new List<string>();
        private bool bEdit = false;
        private bool bDelete = false;
        private bool bIsEmpty = false;
        private Experiment exp = new Experiment();
        private int auth_id = 0;
        private bool bLoad = true;

        public frmExperiments()
        {
            InitializeComponent();
        }

        public static frmExperiments CreateInstance()
        {
            
            if(inst == null || inst.IsDisposed)
            {
                inst = new frmExperiments();
            }
            else
            {
                MessageBox.Show("An Instance of the Experiments Form is already open.", "Form Open", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return inst;
            
        }

        public void Intialize()
        {
            bLoad = true;
            _daoExperiments = new daoExperiments();
            _daoAuthor = new daoAuthors();
            dsExperiments = _daoExperiments.getExperiments();
            dtExperiments = dsExperiments.Tables["EX_TABLE"];
            dtAuthor = dsAuthors.Tables["AUTHOR_TABLE"];
            setComboBox();
            setExp();
            setGrid();
            bLoad = false;
            setAuthorList();
        }

        private void setExp()
        {
            exp.Alias = txtSName.Text;
            exp.Title = txtOfficialName.Text;
            exp.SDate = sDatePicker.Text;
            exp.EDate = eDatePicker.Text;
            exp.Hypo = rtxtHypo.Text;
            exp.ID = Convert.ToInt32(cbExperiments.SelectedValue.ToString());
        }

        private void enableListBox()
        {
            txtBoxList.Clear();
            txtBoxList.Add(sDatePicker.Text);
            txtBoxList.Add(eDatePicker.Text);
            txtBoxList.Add(txtOfficialName.Text);
            txtBoxList.Add(txtSName.Text);

        }

        private void setComboBox()
        {
            cbExperiments.DataSource = dtExperiments;
            cbExperiments.ValueMember = "EX_ID";
            cbExperiments.DisplayMember = "EX_ALIAS";
        }

        private void setRecord()
        {
            if(cbExperiments.SelectedValue != null || cbExperiments.Text != "")
            {  
                foreach(DataGridViewRow row in dgExperiments.SelectedRows)
                {
                    txtSName.Text = row.Cells[1].Value.ToString();
                    txtOfficialName.Text = row.Cells[2].Value.ToString();
                    sDatePicker.Value = (Convert.ToDateTime(row.Cells[3].Value.ToString()));
                    eDatePicker.Value = (Convert.ToDateTime(row.Cells[4].Value.ToString()));
                    rtxtHypo.Text = row.Cells[5].Value.ToString();    
                }
            }
            else
                return;
        }

        private void setAuthorList()
        {
            if (bLoad)
                return;

            if (dsAuthors != null && dsAuthors.Tables.Count > 0 && dsAuthors.Tables[0].Rows.Count > 0)
            {
                dtAuthorEx = dsAuthors.Tables[0];
                DataRow drRec = dtAuthorEx.Rows[0];

                if (dtAuthorEx.Rows.Count == 0)
                    bIsEmpty = true;
                else
                {
                    bIsEmpty = false;
                    auth_id = Convert.ToInt32(drRec["Author_ID"].ToString());
                }
                dgAuthorEx.DataSource = dtAuthorEx;
                dgAuthorEx.Rows[0].Selected = true;
                dgAuthorEx.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            else
            {
                dgAuthorEx.DataSource = null;
                txtLName.Text = "";
                txtFName.Text = "";
                txtMI.Text = "";
                txtEmail.Text = "";
                txtAffliation.Text = "";
                txtDepartment.Text = "";
                picAuthors.Image = null;
                }
        }

        private void setGrid()
        {
            dgExperiments.DataSource = dtExperiments;
            dgExperiments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgExperiments.Rows[0].Selected = true;
        }

        private void setAuthor()
        {
            if (!bIsEmpty)
            {
                foreach (DataGridViewRow newRow in dgAuthorEx.SelectedRows)
                {
                    txtLName.Text = newRow.Cells[1].Value.ToString();
                    txtFName.Text = newRow.Cells[2].Value.ToString();
                    txtMI.Text = newRow.Cells[3].Value.ToString();
                    txtEmail.Text = newRow.Cells[4].Value.ToString();
                    txtAffliation.Text = newRow.Cells[5].Value.ToString();
                    txtDepartment.Text = newRow.Cells[6].Value.ToString();
                    byte[] picBox = newRow.Cells[7].Value as byte[];

                    if (picBox != null && picBox.Length > 0)
                    {
                        MemoryStream mStream = new MemoryStream(picBox);
                        mStream.Position = 0;

                        Image img = Image.FromStream(mStream);

                        mStream.Close();
                        mStream.Dispose();

                        picAuthors.Image = img;
                    }
                    else
                        picAuthors.Image = null;
                }
            }
        }

        private void enableControls(bool b)
        {
            sDatePicker.Enabled = b;
            txtOfficialName.Enabled = b;
            txtSName.Enabled = b;
            eDatePicker.Enabled = b;
            rtxtHypo.Enabled = b;
            btnSave.Enabled = b;
            dgExperiments.ReadOnly = b;
            if (b == true)
            {
                cbExperiments.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnView.Enabled = false;
                btnRefresh.Enabled = false;
            }
            else
            {
                cbExperiments.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnView.Enabled = true;
                btnRefresh.Enabled = true;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (btnNew.Text.Equals("New Experiment"))
            {
                enableControls(true);
                sDatePicker.Value = DateTime.Now;
                txtOfficialName.Text = "";
                txtSName.Text = "";
                eDatePicker.Value = DateTime.Now;
                rtxtHypo.Text = "";
                btnNew.Text = "Cancel";
                enableListBox();
                cbExperiments.Text = "Adding New Row";
            }
            else
            {
                frmRefresh();
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            enableListBox();

            foreach(string txtBox in txtBoxList)
            {
                switch (txtBox)
                {
                    case "":                
                    case null:
                        {
                            MessageBox.Show("Please fill in all fields.", "Null Value Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;

                        }
                    default:
                        break;
                }
            }

            setExp();
            if(bEdit)
            {
                _daoExperiments.updateRecord(exp);
                bEdit = false;
            }
            else if(bDelete)
            {
                _daoExperiments.deleteRecord(cbExperiments.SelectedValue.ToString());
                bDelete = false;
            }
            else
            {
                _daoExperiments.insertRecord(exp);
            }

            frmRefresh();

        }

        public void frmRefresh()
        {
            dsExperiments = _daoExperiments.getExperiments();
            dsAuthors = _daoAuthor.getAuthors(Convert.ToInt32(cbExperiments.SelectedValue.ToString()));
            dtExperiments = dsExperiments.Tables["EX_TABLE"];
            dtAuthor = dsAuthors.Tables["AUTHOR_TABLE"];
            btnNew.Text = "New Experiment";
            btnDelete.Text = "Delete";
            setComboBox();
            setAuthorList();
            setRecord();
            setGrid();
            setAuthor();
            enableControls(false);
            enableListBox();
            bEdit = false;
            bDelete = false;
            setExp();
    
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            enableControls(true);
            btnNew.Text = "Cancel";
            bEdit = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(btnDelete.Text == "Verify Delete")
            {
                setExp();
                btnSave_Click(this, e);
                frmRefresh();
            }
            else
            {
                btnNew.Text = "Cancel";
                bDelete = true;
                btnDelete.Text = "Verify Delete";
                enableControls(false);
            }
        }

        private void btnAddAuthor_Click(object sender, EventArgs e)
        {
            frmAuthor _frmAuthor = frmAuthor.CreateInstance(Convert.ToInt32(cbExperiments.SelectedValue.ToString())); 
            _frmAuthor.StartPosition = FormStartPosition.CenterScreen;
            _frmAuthor.Show();
            _frmAuthor.BringToFront();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            frmRefresh();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            frmData _frmData = frmData.CreateInstance(Convert.ToInt32(cbExperiments.SelectedValue.ToString()));
            _frmData.StartPosition = FormStartPosition.WindowsDefaultLocation;
            _frmData.Show();
            _frmData.BringToFront();
        }

        private void dgExperiments_SelectionChanged(object sender, EventArgs e)
        {
            setRecord();
            dsAuthors = _daoAuthor.getAuthors(Convert.ToInt32(cbExperiments.SelectedValue.ToString()));
            setAuthorList();
        }

        private void dgAuthorEx_SelectionChanged(object sender, EventArgs e)
        {
            setAuthor();
        }

        private void btnEditAuthor_Click(object sender, EventArgs e)
        {
            string nAuthor ="";
            foreach (DataGridViewRow row in dgAuthorEx.SelectedRows)
            {
               nAuthor =  row.Cells["AUTHOR_ID"].Value.ToString();
            }
            if(String.IsNullOrEmpty(nAuthor))
            {
                MessageBox.Show("Please select an Author.", "Author not selected.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmAuthor _frmAuthor = frmAuthor.CreateInstance(Convert.ToInt32(cbExperiments.SelectedValue.ToString()), Convert.ToInt32(nAuthor));
            _frmAuthor.StartPosition = FormStartPosition.CenterScreen;
            _frmAuthor.Show();
            _frmAuthor.BringToFront();
        }

    }
}
