namespace Student_manager.UI
{
    partial class frmStudent
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvQLSV = new System.Windows.Forms.DataGridView();
            this.groupBoxSearch = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new AntdUI.Button();
            this.groupBoxActions = new System.Windows.Forms.GroupBox();
            this.btnAdd = new AntdUI.Button();
            this.btnEdit = new AntdUI.Button();
            this.btnDelete = new AntdUI.Button();
            this.btnReset = new AntdUI.Button();
            this.btnCancel = new AntdUI.Button();
            this.btnClose = new AntdUI.Button();
            this.btnPrint = new AntdUI.Button();
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.txtPhoneNum = new System.Windows.Forms.TextBox();
            this.txtGender = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtDateOfBirth = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblBirth = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblStudentID = new System.Windows.Forms.Label();
            this.gbdgv = new System.Windows.Forms.GroupBox();
            this.lblTitle = new AntdUI.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQLSV)).BeginInit();
            this.groupBoxSearch.SuspendLayout();
            this.groupBoxActions.SuspendLayout();
            this.groupBoxDetails.SuspendLayout();
            this.gbdgv.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvQLSV
            // 
            this.dgvQLSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQLSV.Location = new System.Drawing.Point(7, 36);
            this.dgvQLSV.Name = "dgvQLSV";
            this.dgvQLSV.RowHeadersWidth = 51;
            this.dgvQLSV.RowTemplate.Height = 24;
            this.dgvQLSV.Size = new System.Drawing.Size(1127, 135);
            this.dgvQLSV.TabIndex = 4;
            this.dgvQLSV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQLSV_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnTimKiem);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1140, 82);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Bar";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTimKiem.Location = new System.Drawing.Point(484, 18);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(101, 61);
            this.btnTimKiem.TabIndex = 1;
            this.btnTimKiem.Text = "Search";
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBox1.Location = new System.Drawing.Point(3, 18);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(481, 61);
            this.textBox1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnIn);
            this.groupBox3.Controls.Add(this.btnHuy);
            this.groupBox3.Controls.Add(this.btnThoat);
            this.groupBox3.Controls.Add(this.btnReset);
            this.groupBox3.Controls.Add(this.btnXoa);
            this.groupBox3.Controls.Add(this.btnSua);
            this.groupBox3.Controls.Add(this.btnThem);
            this.groupBox3.Location = new System.Drawing.Point(12, 191);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1140, 89);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Operation";
            // 
            // btnIn
            // 
            this.btnIn.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnIn.Location = new System.Drawing.Point(609, 18);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(101, 68);
            this.btnIn.TabIndex = 6;
            this.btnIn.Text = "Print";
            this.btnIn.Type = AntdUI.TTypeMini.Success;
            // 
            // btnHuy
            // 
            this.btnHuy.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnHuy.Icon = ((System.Drawing.Image)(resources.GetObject("btnHuy.Icon")));
            this.btnHuy.Location = new System.Drawing.Point(508, 18);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(101, 68);
            this.btnHuy.TabIndex = 3;
            this.btnHuy.Text = "Cancel";
            this.btnHuy.Type = AntdUI.TTypeMini.Primary;
            // 
            // btnThoat
            // 
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnThoat.Icon = ((System.Drawing.Image)(resources.GetObject("btnThoat.Icon")));
            this.btnThoat.Location = new System.Drawing.Point(407, 18);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(101, 68);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Exit";
            this.btnThoat.Type = AntdUI.TTypeMini.Error;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(342, 28);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 48);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.Type = AntdUI.TTypeMini.Warn;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(452, 28);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 48);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1116, 28);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 48);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.Type = AntdUI.TTypeMini.Error;
            this.btnClose.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(562, 28);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 48);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "Print";
            this.btnPrint.Type = AntdUI.TTypeMini.Primary;
            // 
            // groupBoxDetails
            // 
            this.groupBoxDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.txtPhoneNum);
            this.groupBox4.Controls.Add(this.txtGender);
            this.groupBox4.Controls.Add(this.txtAddress);
            this.groupBox4.Controls.Add(this.txtEmail);
            this.groupBox4.Controls.Add(this.txtDateOfBirth);
            this.groupBox4.Controls.Add(this.txtFullName);
            this.groupBox4.Controls.Add(this.txtStatus);
            this.groupBox4.Controls.Add(this.txtUserID);
            this.groupBox4.Controls.Add(this.txtStudentID);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(12, 493);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1140, 151);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Student Information";
            // 
            // txtPhoneNum
            // 
            this.txtPhoneNum.Location = new System.Drawing.Point(0, 0);
            this.txtPhoneNum.Name = "txtPhoneNum";
            this.txtPhoneNum.Size = new System.Drawing.Size(100, 20);
            this.txtPhoneNum.TabIndex = 0;
            // 
            // txtGender
            // 
            this.txtGender.Location = new System.Drawing.Point(0, 0);
            this.txtGender.Name = "txtGender";
            this.txtGender.Size = new System.Drawing.Size(100, 20);
            this.txtGender.TabIndex = 1;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(0, 0);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(100, 20);
            this.txtAddress.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(0, 0);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 3;
            // 
            // txtDateOfBirth
            // 
            this.txtDateOfBirth.Location = new System.Drawing.Point(0, 0);
            this.txtDateOfBirth.Name = "txtDateOfBirth";
            this.txtDateOfBirth.Size = new System.Drawing.Size(100, 20);
            this.txtDateOfBirth.TabIndex = 4;
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(0, 0);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(100, 20);
            this.txtFullName.TabIndex = 5;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 0);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(100, 20);
            this.txtStatus.TabIndex = 6;
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(0, 0);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(100, 20);
            this.txtUserID.TabIndex = 7;
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(0, 0);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(100, 20);
            this.txtStudentID.TabIndex = 8;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(740, 110);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(78, 13);
            this.lblPhone.TabIndex = 8;
            this.lblPhone.Text = "PhoneNumber:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(740, 73);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 7;
            this.lblEmail.Text = "Email:";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(740, 36);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(28, 13);
            this.lblGender.TabIndex = 6;
            this.lblGender.Text = "Sex:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(404, 110);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(48, 13);
            this.lblAddress.TabIndex = 5;
            this.lblAddress.Text = "Address:";
            // 
            // lblBirth
            // 
            this.lblBirth.AutoSize = true;
            this.lblBirth.Location = new System.Drawing.Point(404, 73);
            this.lblBirth.Name = "lblBirth";
            this.lblBirth.Size = new System.Drawing.Size(31, 13);
            this.lblBirth.TabIndex = 4;
            this.lblBirth.Text = "Birth:";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(404, 36);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(57, 13);
            this.lblFullName.TabIndex = 3;
            this.lblFullName.Text = "Full Name:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(79, 113);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(43, 13);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status: ";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(79, 67);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(46, 13);
            this.lblUserID.TabIndex = 1;
            this.lblUserID.Text = "User ID:";
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Location = new System.Drawing.Point(79, 32);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(61, 13);
            this.lblStudentID.TabIndex = 0;
            this.lblStudentID.Text = "Student ID:";
            // 
            // gbdgv
            // 
            this.gbdgv.Controls.Add(this.dgvQLSV);
            this.gbdgv.Location = new System.Drawing.Point(12, 286);
            this.gbdgv.Name = "gbdgv";
            this.gbdgv.Size = new System.Drawing.Size(1140, 201);
            this.gbdgv.TabIndex = 7;
            this.gbdgv.TabStop = false;
            this.gbdgv.Text = "Students";
            // 
            // lblTitle
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(343, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(552, 71);
            this.label1.TabIndex = 8;
            this.label1.Text = "Student Management";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // frmStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1164, 644);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbdgv);
            this.Controls.Add(this.groupBoxDetails);
            this.Controls.Add(this.groupBoxActions);
            this.Controls.Add(this.groupBoxSearch);
            this.Name = "frmStudent";
            this.Text = "Student Management";
            this.Load += new System.EventHandler(this.frmStudent_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQLSV)).EndInit();
            this.groupBoxSearch.ResumeLayout(false);
            this.groupBoxSearch.PerformLayout();
            this.groupBoxActions.ResumeLayout(false);
            this.groupBoxDetails.ResumeLayout(false);
            this.groupBoxDetails.PerformLayout();
            this.gbdgv.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvQLSV;
        private System.Windows.Forms.GroupBox groupBoxSearch;
        private AntdUI.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.GroupBox groupBoxActions;
        private AntdUI.Button btnAdd;
        private AntdUI.Button btnEdit;
        private AntdUI.Button btnDelete;
        private AntdUI.Button btnReset;
        private AntdUI.Button btnCancel;
        private AntdUI.Button btnPrint;
        private AntdUI.Button btnClose;
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.TextBox txtPhoneNum;
        private System.Windows.Forms.TextBox txtGender;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtDateOfBirth;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblBirth;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.GroupBox gbdgv;
        private AntdUI.Label lblTitle;
    }
}