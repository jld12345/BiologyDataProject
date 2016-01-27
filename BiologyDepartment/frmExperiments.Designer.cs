using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiologyDepartment
{
    partial class frmExperiments
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgExperiments = new System.Windows.Forms.DataGridView();
            this.cbExperiments = new System.Windows.Forms.ComboBox();
            this.gbExperiment = new System.Windows.Forms.GroupBox();
            this.lblSName = new System.Windows.Forms.Label();
            this.lblOfficalName = new System.Windows.Forms.Label();
            this.lblSDate = new System.Windows.Forms.Label();
            this.lblEDate = new System.Windows.Forms.Label();
            this.lblHypo = new System.Windows.Forms.Label();
            this.txtSName = new System.Windows.Forms.TextBox();
            this.txtOfficialName = new System.Windows.Forms.TextBox();
            this.rtxtHypo = new System.Windows.Forms.RichTextBox();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.eDatePicker = new System.Windows.Forms.DateTimePicker();
            this.sDatePicker = new System.Windows.Forms.DateTimePicker();
            this.gbButtons = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.gbAuthors = new System.Windows.Forms.GroupBox();
            this.btnEditAuthor = new System.Windows.Forms.Button();
            this.btnAddAuthor = new System.Windows.Forms.Button();
            this.lblDept = new System.Windows.Forms.Label();
            this.lblAff = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblMI = new System.Windows.Forms.Label();
            this.lblFName = new System.Windows.Forms.Label();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.lblLName = new System.Windows.Forms.Label();
            this.txtAffliation = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtMI = new System.Windows.Forms.TextBox();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.picAuthors = new System.Windows.Forms.PictureBox();
            this.dgAuthorEx = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgExperiments)).BeginInit();
            this.gbExperiment.SuspendLayout();
            this.gbInfo.SuspendLayout();
            this.gbButtons.SuspendLayout();
            this.gbAuthors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAuthors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAuthorEx)).BeginInit();
            this.SuspendLayout();
            // 
            // dgExperiments
            // 
            this.dgExperiments.AllowUserToAddRows = false;
            this.dgExperiments.AllowUserToDeleteRows = false;
            this.dgExperiments.AllowUserToOrderColumns = true;
            this.dgExperiments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgExperiments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgExperiments.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgExperiments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgExperiments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgExperiments.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgExperiments.Location = new System.Drawing.Point(13, 303);
            this.dgExperiments.MultiSelect = false;
            this.dgExperiments.Name = "dgExperiments";
            this.dgExperiments.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgExperiments.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgExperiments.Size = new System.Drawing.Size(936, 332);
            this.dgExperiments.TabIndex = 0;
            this.dgExperiments.SelectionChanged += new System.EventHandler(this.dgExperiments_SelectionChanged);
            // 
            // cbExperiments
            // 
            this.cbExperiments.FormattingEnabled = true;
            this.cbExperiments.Location = new System.Drawing.Point(6, 19);
            this.cbExperiments.Name = "cbExperiments";
            this.cbExperiments.Size = new System.Drawing.Size(329, 21);
            this.cbExperiments.TabIndex = 1;
            // 
            // gbExperiment
            // 
            this.gbExperiment.Controls.Add(this.cbExperiments);
            this.gbExperiment.Location = new System.Drawing.Point(13, 13);
            this.gbExperiment.Name = "gbExperiment";
            this.gbExperiment.Size = new System.Drawing.Size(341, 52);
            this.gbExperiment.TabIndex = 2;
            this.gbExperiment.TabStop = false;
            this.gbExperiment.Text = "Experiment";
            // 
            // lblSName
            // 
            this.lblSName.AutoSize = true;
            this.lblSName.Location = new System.Drawing.Point(403, 27);
            this.lblSName.Name = "lblSName";
            this.lblSName.Size = new System.Drawing.Size(63, 13);
            this.lblSName.TabIndex = 3;
            this.lblSName.Text = "Short Name";
            // 
            // lblOfficalName
            // 
            this.lblOfficalName.AutoSize = true;
            this.lblOfficalName.Location = new System.Drawing.Point(396, 59);
            this.lblOfficalName.Name = "lblOfficalName";
            this.lblOfficalName.Size = new System.Drawing.Size(70, 13);
            this.lblOfficalName.TabIndex = 4;
            this.lblOfficalName.Text = "Official Name";
            // 
            // lblSDate
            // 
            this.lblSDate.AutoSize = true;
            this.lblSDate.Location = new System.Drawing.Point(411, 91);
            this.lblSDate.Name = "lblSDate";
            this.lblSDate.Size = new System.Drawing.Size(55, 13);
            this.lblSDate.TabIndex = 5;
            this.lblSDate.Text = "Start Date";
            // 
            // lblEDate
            // 
            this.lblEDate.AutoSize = true;
            this.lblEDate.Location = new System.Drawing.Point(414, 123);
            this.lblEDate.Name = "lblEDate";
            this.lblEDate.Size = new System.Drawing.Size(52, 13);
            this.lblEDate.TabIndex = 6;
            this.lblEDate.Text = "End Date";
            // 
            // lblHypo
            // 
            this.lblHypo.AutoSize = true;
            this.lblHypo.Location = new System.Drawing.Point(407, 155);
            this.lblHypo.Name = "lblHypo";
            this.lblHypo.Size = new System.Drawing.Size(59, 13);
            this.lblHypo.TabIndex = 7;
            this.lblHypo.Text = "Hypothesis";
            // 
            // txtSName
            // 
            this.txtSName.Location = new System.Drawing.Point(472, 24);
            this.txtSName.Name = "txtSName";
            this.txtSName.Size = new System.Drawing.Size(273, 20);
            this.txtSName.TabIndex = 8;
            // 
            // txtOfficialName
            // 
            this.txtOfficialName.Location = new System.Drawing.Point(472, 56);
            this.txtOfficialName.Name = "txtOfficialName";
            this.txtOfficialName.Size = new System.Drawing.Size(455, 20);
            this.txtOfficialName.TabIndex = 9;
            // 
            // rtxtHypo
            // 
            this.rtxtHypo.Location = new System.Drawing.Point(472, 155);
            this.rtxtHypo.Name = "rtxtHypo";
            this.rtxtHypo.Size = new System.Drawing.Size(455, 120);
            this.rtxtHypo.TabIndex = 12;
            this.rtxtHypo.Text = "";
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.eDatePicker);
            this.gbInfo.Controls.Add(this.sDatePicker);
            this.gbInfo.Location = new System.Drawing.Point(360, 13);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(589, 284);
            this.gbInfo.TabIndex = 13;
            this.gbInfo.TabStop = false;
            // 
            // eDatePicker
            // 
            this.eDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.eDatePicker.Location = new System.Drawing.Point(113, 110);
            this.eDatePicker.Name = "eDatePicker";
            this.eDatePicker.Size = new System.Drawing.Size(103, 20);
            this.eDatePicker.TabIndex = 1;
            // 
            // sDatePicker
            // 
            this.sDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.sDatePicker.Location = new System.Drawing.Point(112, 78);
            this.sDatePicker.Name = "sDatePicker";
            this.sDatePicker.Size = new System.Drawing.Size(104, 20);
            this.sDatePicker.TabIndex = 0;
            // 
            // gbButtons
            // 
            this.gbButtons.BackColor = System.Drawing.Color.AntiqueWhite;
            this.gbButtons.Controls.Add(this.btnRefresh);
            this.gbButtons.Controls.Add(this.btnDelete);
            this.gbButtons.Controls.Add(this.btnEdit);
            this.gbButtons.Controls.Add(this.btnSave);
            this.gbButtons.Controls.Add(this.btnView);
            this.gbButtons.Controls.Add(this.btnNew);
            this.gbButtons.Location = new System.Drawing.Point(13, 72);
            this.gbButtons.Name = "gbButtons";
            this.gbButtons.Size = new System.Drawing.Size(341, 225);
            this.gbButtons.TabIndex = 14;
            this.gbButtons.TabStop = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(7, 119);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(148, 44);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Refresh Data";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(187, 69);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(148, 44);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(187, 20);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(148, 44);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(187, 119);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(148, 44);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Location = new System.Drawing.Point(7, 69);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(148, 44);
            this.btnView.TabIndex = 1;
            this.btnView.Text = "View Data";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(7, 20);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(148, 44);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "New Experiment";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // gbAuthors
            // 
            this.gbAuthors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAuthors.Controls.Add(this.btnEditAuthor);
            this.gbAuthors.Controls.Add(this.btnAddAuthor);
            this.gbAuthors.Controls.Add(this.lblDept);
            this.gbAuthors.Controls.Add(this.lblAff);
            this.gbAuthors.Controls.Add(this.lblEmail);
            this.gbAuthors.Controls.Add(this.lblMI);
            this.gbAuthors.Controls.Add(this.lblFName);
            this.gbAuthors.Controls.Add(this.txtDepartment);
            this.gbAuthors.Controls.Add(this.lblLName);
            this.gbAuthors.Controls.Add(this.txtAffliation);
            this.gbAuthors.Controls.Add(this.txtEmail);
            this.gbAuthors.Controls.Add(this.txtMI);
            this.gbAuthors.Controls.Add(this.txtFName);
            this.gbAuthors.Controls.Add(this.txtLName);
            this.gbAuthors.Controls.Add(this.picAuthors);
            this.gbAuthors.Location = new System.Drawing.Point(955, 13);
            this.gbAuthors.Name = "gbAuthors";
            this.gbAuthors.Size = new System.Drawing.Size(524, 284);
            this.gbAuthors.TabIndex = 15;
            this.gbAuthors.TabStop = false;
            // 
            // btnEditAuthor
            // 
            this.btnEditAuthor.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnEditAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditAuthor.Location = new System.Drawing.Point(124, 218);
            this.btnEditAuthor.Name = "btnEditAuthor";
            this.btnEditAuthor.Size = new System.Drawing.Size(105, 55);
            this.btnEditAuthor.TabIndex = 19;
            this.btnEditAuthor.Text = "Edit Author";
            this.btnEditAuthor.UseVisualStyleBackColor = false;
            this.btnEditAuthor.Click += new System.EventHandler(this.btnEditAuthor_Click);
            // 
            // btnAddAuthor
            // 
            this.btnAddAuthor.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnAddAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAuthor.Location = new System.Drawing.Point(6, 218);
            this.btnAddAuthor.Name = "btnAddAuthor";
            this.btnAddAuthor.Size = new System.Drawing.Size(105, 55);
            this.btnAddAuthor.TabIndex = 14;
            this.btnAddAuthor.Text = "Add Author";
            this.btnAddAuthor.UseVisualStyleBackColor = false;
            this.btnAddAuthor.Click += new System.EventHandler(this.btnAddAuthor_Click);
            // 
            // lblDept
            // 
            this.lblDept.AutoSize = true;
            this.lblDept.Location = new System.Drawing.Point(240, 188);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(62, 13);
            this.lblDept.TabIndex = 12;
            this.lblDept.Text = "Department";
            this.lblDept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAff
            // 
            this.lblAff.AutoSize = true;
            this.lblAff.Location = new System.Drawing.Point(253, 155);
            this.lblAff.Name = "lblAff";
            this.lblAff.Size = new System.Drawing.Size(49, 13);
            this.lblAff.TabIndex = 11;
            this.lblAff.Text = "Affiliation";
            this.lblAff.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(270, 122);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "Email";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMI
            // 
            this.lblMI.AutoSize = true;
            this.lblMI.Location = new System.Drawing.Point(283, 89);
            this.lblMI.Name = "lblMI";
            this.lblMI.Size = new System.Drawing.Size(19, 13);
            this.lblMI.TabIndex = 9;
            this.lblMI.Text = "MI";
            this.lblMI.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFName
            // 
            this.lblFName.AutoSize = true;
            this.lblFName.Location = new System.Drawing.Point(245, 56);
            this.lblFName.Name = "lblFName";
            this.lblFName.Size = new System.Drawing.Size(57, 13);
            this.lblFName.TabIndex = 8;
            this.lblFName.Text = "First Name";
            this.lblFName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDepartment
            // 
            this.txtDepartment.Enabled = false;
            this.txtDepartment.Location = new System.Drawing.Point(308, 185);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(210, 20);
            this.txtDepartment.TabIndex = 7;
            // 
            // lblLName
            // 
            this.lblLName.AutoSize = true;
            this.lblLName.Location = new System.Drawing.Point(244, 23);
            this.lblLName.Name = "lblLName";
            this.lblLName.Size = new System.Drawing.Size(58, 13);
            this.lblLName.TabIndex = 6;
            this.lblLName.Text = "Last Name";
            this.lblLName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAffliation
            // 
            this.txtAffliation.Enabled = false;
            this.txtAffliation.Location = new System.Drawing.Point(308, 152);
            this.txtAffliation.Name = "txtAffliation";
            this.txtAffliation.Size = new System.Drawing.Size(210, 20);
            this.txtAffliation.TabIndex = 5;
            // 
            // txtEmail
            // 
            this.txtEmail.Enabled = false;
            this.txtEmail.Location = new System.Drawing.Point(308, 119);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(210, 20);
            this.txtEmail.TabIndex = 4;
            // 
            // txtMI
            // 
            this.txtMI.Enabled = false;
            this.txtMI.Location = new System.Drawing.Point(308, 86);
            this.txtMI.Name = "txtMI";
            this.txtMI.Size = new System.Drawing.Size(56, 20);
            this.txtMI.TabIndex = 3;
            // 
            // txtFName
            // 
            this.txtFName.Enabled = false;
            this.txtFName.Location = new System.Drawing.Point(308, 53);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(176, 20);
            this.txtFName.TabIndex = 2;
            // 
            // txtLName
            // 
            this.txtLName.Enabled = false;
            this.txtLName.Location = new System.Drawing.Point(308, 20);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(176, 20);
            this.txtLName.TabIndex = 1;
            // 
            // picAuthors
            // 
            this.picAuthors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAuthors.Location = new System.Drawing.Point(6, 11);
            this.picAuthors.Name = "picAuthors";
            this.picAuthors.Size = new System.Drawing.Size(223, 189);
            this.picAuthors.TabIndex = 0;
            this.picAuthors.TabStop = false;
            // 
            // dgAuthorEx
            // 
            this.dgAuthorEx.AllowUserToAddRows = false;
            this.dgAuthorEx.AllowUserToDeleteRows = false;
            this.dgAuthorEx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgAuthorEx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAuthorEx.Location = new System.Drawing.Point(956, 304);
            this.dgAuthorEx.Name = "dgAuthorEx";
            this.dgAuthorEx.ReadOnly = true;
            this.dgAuthorEx.Size = new System.Drawing.Size(523, 331);
            this.dgAuthorEx.TabIndex = 16;
            this.dgAuthorEx.SelectionChanged += new System.EventHandler(this.dgAuthorEx_SelectionChanged);
            // 
            // frmExperiments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(1491, 647);
            this.Controls.Add(this.dgAuthorEx);
            this.Controls.Add(this.gbAuthors);
            this.Controls.Add(this.gbButtons);
            this.Controls.Add(this.rtxtHypo);
            this.Controls.Add(this.txtOfficialName);
            this.Controls.Add(this.txtSName);
            this.Controls.Add(this.lblHypo);
            this.Controls.Add(this.lblEDate);
            this.Controls.Add(this.lblSDate);
            this.Controls.Add(this.lblOfficalName);
            this.Controls.Add(this.lblSName);
            this.Controls.Add(this.gbExperiment);
            this.Controls.Add(this.dgExperiments);
            this.Controls.Add(this.gbInfo);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "frmExperiments";
            this.Text = "Experiments and Authors";
            ((System.ComponentModel.ISupportInitialize)(this.dgExperiments)).EndInit();
            this.gbExperiment.ResumeLayout(false);
            this.gbInfo.ResumeLayout(false);
            this.gbButtons.ResumeLayout(false);
            this.gbAuthors.ResumeLayout(false);
            this.gbAuthors.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAuthors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAuthorEx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgExperiments;
        private System.Windows.Forms.ComboBox cbExperiments;
        private System.Windows.Forms.GroupBox gbExperiment;
        private System.Windows.Forms.Label lblSName;
        private System.Windows.Forms.Label lblOfficalName;
        private System.Windows.Forms.Label lblSDate;
        private System.Windows.Forms.Label lblEDate;
        private System.Windows.Forms.Label lblHypo;
        private System.Windows.Forms.TextBox txtSName;
        private System.Windows.Forms.TextBox txtOfficialName;
        private System.Windows.Forms.RichTextBox rtxtHypo;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.GroupBox gbButtons;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnNew;
        private DateTimePicker eDatePicker;
        private DateTimePicker sDatePicker;
        private GroupBox gbAuthors;
        private Label lblLName;
        private TextBox txtAffliation;
        private TextBox txtEmail;
        private TextBox txtMI;
        private TextBox txtFName;
        private TextBox txtLName;
        private PictureBox picAuthors;
        private Button btnAddAuthor;
        private Label lblDept;
        private Label lblAff;
        private Label lblEmail;
        private Label lblMI;
        private Label lblFName;
        private TextBox txtDepartment;
        private DataGridView dgAuthorEx;
        private Button btnEditAuthor;
    }
}