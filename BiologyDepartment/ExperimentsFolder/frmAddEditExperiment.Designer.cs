namespace BiologyDepartment.ExperimentsFolder
{
    partial class FrmAddEditExperiment
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnClear = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnAdd = new Syncfusion.Windows.Forms.ButtonAdv();
            this.label5 = new System.Windows.Forms.Label();
            this.dteEnd = new Syncfusion.Windows.Forms.Tools.DateTimePickerAdv();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dteStart = new Syncfusion.Windows.Forms.Tools.DateTimePickerAdv();
            this.txtShortName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.rtbOfficialName = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtScript = new ScintillaNET.Scintilla();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbParents = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dteEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShortName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbParents)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cmbParents);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.btnClear);
            this.splitContainer1.Panel1.Controls.Add(this.btnAdd);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.dteEnd);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.dteStart);
            this.splitContainer1.Panel1.Controls.Add(this.txtShortName);
            this.splitContainer1.Panel1.Controls.Add(this.rtbOfficialName);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtScript);
            this.splitContainer1.Size = new System.Drawing.Size(691, 575);
            this.splitContainer1.SplitterDistance = 204;
            this.splitContainer1.TabIndex = 3;
            // 
            // btnClear
            // 
            this.btnClear.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2010;
            this.btnClear.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.btnClear.IsBackStageButton = false;
            this.btnClear.Location = new System.Drawing.Point(604, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Cancel";
            this.btnClear.UseVisualStyle = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2010;
            this.btnAdd.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.btnAdd.IsBackStageButton = false;
            this.btnAdd.Location = new System.Drawing.Point(523, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Save";
            this.btnAdd.UseVisualStyle = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Additional Information";
            // 
            // dteEnd
            // 
            this.dteEnd.BorderColor = System.Drawing.Color.Empty;
            this.dteEnd.CalendarSize = new System.Drawing.Size(189, 176);
            this.dteEnd.DropDownImage = null;
            this.dteEnd.DropDownNormalColor = System.Drawing.SystemColors.Control;
            this.dteEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteEnd.Location = new System.Drawing.Point(161, 157);
            this.dteEnd.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.dteEnd.MinValue = new System.DateTime(((long)(0)));
            this.dteEnd.Name = "dteEnd";
            this.dteEnd.Size = new System.Drawing.Size(125, 20);
            this.dteEnd.TabIndex = 9;
            this.dteEnd.Value = new System.DateTime(2016, 8, 28, 15, 44, 37, 124);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "End Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Start Date";
            // 
            // dteStart
            // 
            this.dteStart.BorderColor = System.Drawing.Color.Empty;
            this.dteStart.CalendarSize = new System.Drawing.Size(189, 176);
            this.dteStart.DropDownImage = null;
            this.dteStart.DropDownNormalColor = System.Drawing.SystemColors.Control;
            this.dteStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteStart.Location = new System.Drawing.Point(16, 157);
            this.dteStart.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.dteStart.MinValue = new System.DateTime(((long)(0)));
            this.dteStart.Name = "dteStart";
            this.dteStart.Size = new System.Drawing.Size(125, 20);
            this.dteStart.TabIndex = 5;
            this.dteStart.Value = new System.DateTime(2016, 8, 28, 15, 44, 37, 124);
            // 
            // txtShortName
            // 
            this.txtShortName.BeforeTouchSize = new System.Drawing.Size(645, 20);
            this.txtShortName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtShortName.Location = new System.Drawing.Point(13, 30);
            this.txtShortName.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(645, 20);
            this.txtShortName.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtShortName.TabIndex = 4;
            // 
            // rtbOfficialName
            // 
            this.rtbOfficialName.Location = new System.Drawing.Point(16, 71);
            this.rtbOfficialName.Name = "rtbOfficialName";
            this.rtbOfficialName.Size = new System.Drawing.Size(642, 57);
            this.rtbOfficialName.TabIndex = 3;
            this.rtbOfficialName.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Official Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Short Name";
            // 
            // txtScript
            // 
            this.txtScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScript.Location = new System.Drawing.Point(0, 0);
            this.txtScript.Name = "txtScript";
            this.txtScript.Size = new System.Drawing.Size(691, 367);
            this.txtScript.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(305, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Parent Experiment";
            // 
            // cmbParents
            // 
            this.cmbParents.BeforeTouchSize = new System.Drawing.Size(350, 21);
            this.cmbParents.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbParents.Location = new System.Drawing.Point(308, 155);
            this.cmbParents.Name = "cmbParents";
            this.cmbParents.Size = new System.Drawing.Size(350, 21);
            this.cmbParents.TabIndex = 14;
            // 
            // frmAddEditExperiment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 575);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmAddEditExperiment";
            this.Text = "Add Experiment";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dteEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShortName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbParents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.ButtonAdv btnSave;
        private Syncfusion.Windows.Forms.ButtonAdv btnCancel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtShortName;
        private System.Windows.Forms.RichTextBox rtbOfficialName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ScintillaNET.Scintilla txtScript;
        private Syncfusion.Windows.Forms.Tools.DateTimePickerAdv dteStart;
        private System.Windows.Forms.Label label5;
        private Syncfusion.Windows.Forms.Tools.DateTimePickerAdv dteEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Syncfusion.Windows.Forms.ButtonAdv btnClear;
        private Syncfusion.Windows.Forms.ButtonAdv btnAdd;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbParents;
        private System.Windows.Forms.Label label6;
    }
}