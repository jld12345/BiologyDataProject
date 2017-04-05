using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BiologyDepartment
{
    public partial class ctlAuthors : UserControl
    {
        private daoAuthors _daoAuthor = new daoAuthors();
        private daoAuthorEX _daoAuthorEX = new daoAuthorEX();
        private DataSet dsAuthors = new DataSet();
        private DataSet dsAuthorEx = new DataSet();
        private DataTable dtAuthor = new DataTable();
        private DataTable dtAuthorEx = new DataTable();
        private bool bIsEmpty = false;
        private int auth_id = 0;

        public ctlAuthors()
        {
            InitializeComponent();
        }

        private void CloseFRMAuthorEvent(object sender, frmAuthorClosedEventArgs e)
        {
            if(e.IsChange)
            {
                dgAuthorEx.DataSource = "";
                //dsAuthors = _daoAuthor.getAuthors(Convert.ToInt32(cbExperiments.SelectedValue.ToString()));
                dtAuthor = dsAuthors.Tables[0];
                setAuthorList();
            }
        }

        public void frmRefresh(int EX_ID)
        {
            this.dgAuthorEx.SelectionChanged -= this.dgAuthorEx_SelectionChanged_1;
            dsAuthors = _daoAuthor.getAuthors(EX_ID);
            if (dsAuthors == null || dsAuthors.Tables.Count == 0 || dsAuthors.Tables[0] == null)
                return;
            dtAuthor = dsAuthors.Tables[0];
            if (dtAuthor.Rows.Count > 0)
            {
                dgAuthorEx.DataSource = dtAuthor;
                dgAuthorEx.Columns["AUTHOR_PICTURE"].Visible = false;
                this.dgAuthorEx.SelectionChanged += new System.EventHandler(this.dgAuthorEx_SelectionChanged_1);
                dgAuthorEx.Rows[0].Selected = true;
                
                setAuthorList();
            }      
        }

        private void setAuthorList()
        {            
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

         private void setAuthor()
        {
            if (!bIsEmpty)
            {
                foreach (DataGridViewRow newRow in dgAuthorEx.SelectedRows)
                {
                    txtLName.Text = newRow.Cells["AUTHOR_LNAME"].Value.ToString();
                    txtFName.Text = newRow.Cells["AUTHOR_FNAME"].Value.ToString();
                    txtMI.Text = newRow.Cells["AUTHOR_MNAME"].Value.ToString();
                    txtEmail.Text = newRow.Cells["AUTHOR_EMAIL"].Value.ToString();
                    txtAffliation.Text = newRow.Cells["AUTHOR_ASSOC"].Value.ToString();
                    txtDepartment.Text = newRow.Cells["AUTHOR_DEPT"].Value.ToString();
                    
                    byte[] picBox = newRow.Cells["AUTHOR_PICTURE"].Value as byte[];

                    if (picBox != null && picBox.Length > 0)
                    {
                        MemoryStream mStream = new MemoryStream(picBox)
                        {
                            Position = 0
                        };
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

        private void btnAddAuthor_Click(object sender, EventArgs e)
        {
            frmAuthor _frmAuthor = frmAuthor.CreateInstance();
            _frmAuthor.RaiseAuthorClosedEvent -= CloseFRMAuthorEvent;
            _frmAuthor.StartPosition = FormStartPosition.CenterScreen;
            _frmAuthor.Show();
            _frmAuthor.BringToFront();
            _frmAuthor.Initialize();
            _frmAuthor.RaiseAuthorClosedEvent += CloseFRMAuthorEvent;
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
            
            frmAuthor _frmAuthor = frmAuthor.CreateInstance();
            _frmAuthor.RaiseAuthorClosedEvent -= CloseFRMAuthorEvent;
            _frmAuthor.StartPosition = FormStartPosition.CenterScreen;
            _frmAuthor.Show();
            _frmAuthor.BringToFront();
            _frmAuthor.Initialize();
            _frmAuthor.RaiseAuthorClosedEvent += CloseFRMAuthorEvent;
        }

        private void dgAuthorEx_SelectionChanged_1(object sender, EventArgs e)
        {
            setAuthor();
        }

        private void gbAuthors_Enter(object sender, EventArgs e)
        {

        }
    }

    
}
