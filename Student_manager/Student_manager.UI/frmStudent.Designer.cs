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
            this.btnSearch = new AntdUI.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.groupBoxActions = new System.Windows.Forms.GroupBox();
            this.btnClose = new AntdUI.Button();
            this.btnPrint = new AntdUI.Button();
            this.btnReset = new AntdUI.Button();
            this.btnDelete = new AntdUI.Button();
            this.btnEdit = new AntdUI.Button();
            this.btnAdd = new AntdUI.Button();
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.txtStudentCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSex = new System.Windows.Forms.ComboBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.dtpBirth = new System.Windows.Forms.DateTimePicker();
            this.txtPhoneNum = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
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
            this.dgvQLSV.Location = new System.Drawing.Point(9, 23);
            this.dgvQLSV.Margin = new System.Windows.Forms.Padding(4);
            this.dgvQLSV.Name = "dgvQLSV";
            this.dgvQLSV.RowHeadersWidth = 51;
            this.dgvQLSV.RowTemplate.Height = 24;
            this.dgvQLSV.Size = new System.Drawing.Size(1503, 187);
            this.dgvQLSV.TabIndex = 4;
            this.dgvQLSV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQLSV_CellContentClick);
            this.dgvQLSV.SelectionChanged += new System.EventHandler(this.dgvQLSV_SelectionChanged);
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSearch.Controls.Add(this.btnSearch);
            this.groupBoxSearch.Controls.Add(this.txtSearch);
            this.groupBoxSearch.Location = new System.Drawing.Point(16, 108);
            this.groupBoxSearch.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxSearch.Size = new System.Drawing.Size(1520, 100);
            this.groupBoxSearch.TabIndex = 5;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "Search Bar";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(652, 13);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(135, 60);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.Type = AntdUI.TTypeMini.Success;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(4, 22);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(640, 39);
            this.txtSearch.TabIndex = 0;
            // 
            // groupBoxActions
            // 
            this.groupBoxActions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxActions.Controls.Add(this.btnClose);
            this.groupBoxActions.Controls.Add(this.btnPrint);
            this.groupBoxActions.Controls.Add(this.btnReset);
            this.groupBoxActions.Controls.Add(this.btnDelete);
            this.groupBoxActions.Controls.Add(this.btnEdit);
            this.groupBoxActions.Controls.Add(this.btnAdd);
            this.groupBoxActions.Location = new System.Drawing.Point(16, 216);
            this.groupBoxActions.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxActions.Name = "groupBoxActions";
            this.groupBoxActions.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxActions.Size = new System.Drawing.Size(1520, 128);
            this.groupBoxActions.TabIndex = 6;
            this.groupBoxActions.TabStop = false;
            this.groupBoxActions.Text = "Operation";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(778, 23);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(156, 79);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Exit";
            this.btnClose.Type = AntdUI.TTypeMini.Error;
            this.btnClose.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(627, 23);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(143, 79);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "Print";
            this.btnPrint.Type = AntdUI.TTypeMini.Success;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(463, 23);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(156, 79);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.Type = AntdUI.TTypeMini.Warn;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(312, 23);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(143, 79);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Type = AntdUI.TTypeMini.Error;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(163, 23);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(141, 79);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "Edit";
            this.btnEdit.Type = AntdUI.TTypeMini.Success;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(9, 23);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(146, 79);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.Type = AntdUI.TTypeMini.Primary;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBoxDetails
            // 
            this.groupBoxDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDetails.Controls.Add(this.txtStudentCode);
            this.groupBoxDetails.Controls.Add(this.label1);
            this.groupBoxDetails.Controls.Add(this.cboSex);
            this.groupBoxDetails.Controls.Add(this.cboStatus);
            this.groupBoxDetails.Controls.Add(this.dtpBirth);
            this.groupBoxDetails.Controls.Add(this.txtPhoneNum);
            this.groupBoxDetails.Controls.Add(this.txtAddress);
            this.groupBoxDetails.Controls.Add(this.txtEmail);
            this.groupBoxDetails.Controls.Add(this.txtFullName);
            this.groupBoxDetails.Controls.Add(this.txtUserID);
            this.groupBoxDetails.Controls.Add(this.txtStudentID);
            this.groupBoxDetails.Controls.Add(this.lblPhone);
            this.groupBoxDetails.Controls.Add(this.lblEmail);
            this.groupBoxDetails.Controls.Add(this.lblGender);
            this.groupBoxDetails.Controls.Add(this.lblAddress);
            this.groupBoxDetails.Controls.Add(this.lblBirth);
            this.groupBoxDetails.Controls.Add(this.lblFullName);
            this.groupBoxDetails.Controls.Add(this.lblStatus);
            this.groupBoxDetails.Controls.Add(this.lblUserID);
            this.groupBoxDetails.Controls.Add(this.lblStudentID);
            this.groupBoxDetails.Location = new System.Drawing.Point(16, 607);
            this.groupBoxDetails.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxDetails.Name = "groupBoxDetails";
            this.groupBoxDetails.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxDetails.Size = new System.Drawing.Size(1520, 220);
            this.groupBoxDetails.TabIndex = 6;
            this.groupBoxDetails.TabStop = false;
            this.groupBoxDetails.Text = "Student Information";
            // 
            // txtStudentCode
            // 
            this.txtStudentCode.Location = new System.Drawing.Point(332, 39);
            this.txtStudentCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtStudentCode.Name = "txtStudentCode";
            this.txtStudentCode.Size = new System.Drawing.Size(199, 22);
            this.txtStudentCode.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(329, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "StudentCode:";
            // 
            // cboSex
            // 
            this.cboSex.FormattingEnabled = true;
            this.cboSex.Location = new System.Drawing.Point(987, 44);
            this.cboSex.Name = "cboSex";
            this.cboSex.Size = new System.Drawing.Size(265, 24);
            this.cboSex.TabIndex = 8;
            // 
            // cboStatus
            // 
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(332, 82);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(199, 24);
            this.cboStatus.TabIndex = 4;
            // 
            // dtpBirth
            // 
            this.dtpBirth.Location = new System.Drawing.Point(630, 88);
            this.dtpBirth.Name = "dtpBirth";
            this.dtpBirth.Size = new System.Drawing.Size(265, 22);
            this.dtpBirth.TabIndex = 6;
            // 
            // txtPhoneNum
            // 
            this.txtPhoneNum.Location = new System.Drawing.Point(987, 135);
            this.txtPhoneNum.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhoneNum.Name = "txtPhoneNum";
            this.txtPhoneNum.Size = new System.Drawing.Size(265, 22);
            this.txtPhoneNum.TabIndex = 10;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(630, 132);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(265, 22);
            this.txtAddress.TabIndex = 7;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(987, 90);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(265, 22);
            this.txtEmail.TabIndex = 9;
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(630, 38);
            this.txtFullName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(265, 22);
            this.txtFullName.TabIndex = 5;
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(105, 82);
            this.txtUserID.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(199, 22);
            this.txtUserID.TabIndex = 2;
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(105, 39);
            this.txtStudentID.Margin = new System.Windows.Forms.Padding(4);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(199, 22);
            this.txtStudentID.TabIndex = 1;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(987, 113);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(97, 16);
            this.lblPhone.TabIndex = 8;
            this.lblPhone.Text = "PhoneNumber:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(987, 70);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(44, 16);
            this.lblEmail.TabIndex = 7;
            this.lblEmail.Text = "Email:";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(987, 25);
            this.lblGender.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(33, 16);
            this.lblGender.TabIndex = 6;
            this.lblGender.Text = "Sex:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(627, 116);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(61, 16);
            this.lblAddress.TabIndex = 5;
            this.lblAddress.Text = "Address:";
            // 
            // lblBirth
            // 
            this.lblBirth.AutoSize = true;
            this.lblBirth.Location = new System.Drawing.Point(627, 69);
            this.lblBirth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBirth.Name = "lblBirth";
            this.lblBirth.Size = new System.Drawing.Size(36, 16);
            this.lblBirth.TabIndex = 4;
            this.lblBirth.Text = "Birth:";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(627, 18);
            this.lblFullName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(71, 16);
            this.lblFullName.TabIndex = 3;
            this.lblFullName.Text = "Full Name:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(334, 63);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(50, 16);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status: ";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(105, 62);
            this.lblUserID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(55, 16);
            this.lblUserID.TabIndex = 1;
            this.lblUserID.Text = "User ID:";
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Location = new System.Drawing.Point(105, 18);
            this.lblStudentID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(71, 16);
            this.lblStudentID.TabIndex = 0;
            this.lblStudentID.Text = "Student ID:";
            // 
            // gbdgv
            // 
            this.gbdgv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.gbdgv.Controls.Add(this.dgvQLSV);
            this.gbdgv.Location = new System.Drawing.Point(16, 352);
            this.gbdgv.Margin = new System.Windows.Forms.Padding(4);
            this.gbdgv.Name = "gbdgv";
            this.gbdgv.Padding = new System.Windows.Forms.Padding(4);
            this.gbdgv.Size = new System.Drawing.Size(1520, 247);
            this.gbdgv.TabIndex = 7;
            this.gbdgv.TabStop = false;
            this.gbdgv.Text = "Students";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(479, 13);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(736, 87);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Student Management";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Click += new System.EventHandler(this.label1_Click);
            // 
            // frmStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1552, 793);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.gbdgv);
            this.Controls.Add(this.groupBoxDetails);
            this.Controls.Add(this.groupBoxActions);
            this.Controls.Add(this.groupBoxSearch);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmStudent";
            this.Text = "Student Management";
            this.Load += new System.EventHandler(this.frmStudent_Load);
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
        private AntdUI.Button btnPrint;
        private AntdUI.Button btnClose;
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.TextBox txtPhoneNum;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtFullName;
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
        private System.Windows.Forms.ComboBox cboSex;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.DateTimePicker dtpBirth;
        private System.Windows.Forms.TextBox txtStudentCode;
        private System.Windows.Forms.Label label1;
    }
}