namespace Student_manager.UI
{
    partial class frmLectures
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Designer generated

        private void InitializeComponent()
        {
            this.groupActions = new System.Windows.Forms.GroupBox();
            this.btnCancel = new AntdUI.Button();
            this.button1 = new AntdUI.Button();
            this.button2 = new AntdUI.Button();
            this.btnModify = new AntdUI.Button();
            this.btnAdd = new AntdUI.Button();
            this.btnRefresh = new AntdUI.Button();
            this.btnNew = new AntdUI.Button();
            this.btnEdit = new AntdUI.Button();
            this.btnDelete = new AntdUI.Button();
            this.btnSave = new AntdUI.Button();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtSpecialization = new System.Windows.Forms.TextBox();
            this.label2 = new AntdUI.Label();
            this.label1 = new AntdUI.Label();
            this.txtTeacherCode = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblLast = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.dgvLecturers = new System.Windows.Forms.DataGridView();
            this.groupDetails = new System.Windows.Forms.GroupBox();
            this.lblFirst = new System.Windows.Forms.Label();
            this.btnSearch = new AntdUI.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.lblHeader = new AntdUI.Label();
            this.groupActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLecturers)).BeginInit();
            this.groupDetails.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupActions
            // 
            this.groupActions.Controls.Add(this.btnCancel);
            this.groupActions.Controls.Add(this.button1);
            this.groupActions.Controls.Add(this.button2);
            this.groupActions.Controls.Add(this.btnModify);
            this.groupActions.Controls.Add(this.btnAdd);
            this.groupActions.Controls.Add(this.btnRefresh);
            this.groupActions.Controls.Add(this.btnNew);
            this.groupActions.Controls.Add(this.btnEdit);
            this.groupActions.Controls.Add(this.btnDelete);
            this.groupActions.Controls.Add(this.btnSave);
            this.groupActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupActions.Location = new System.Drawing.Point(12, 12);
            this.groupActions.Name = "groupActions";
            this.groupActions.Size = new System.Drawing.Size(941, 126);
            this.groupActions.TabIndex = 2;
            this.groupActions.TabStop = false;
            this.groupActions.Text = "Actions";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(13)))), ((int)(((byte)(85)))));
            this.btnCancel.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(162)))), ((int)(((byte)(171)))));
            this.btnCancel.Location = new System.Drawing.Point(616, 44);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 44);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Type = AntdUI.TTypeMini.Primary;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(239)))), ((int)(((byte)(111)))));
            this.button1.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(162)))), ((int)(((byte)(171)))));
            this.button1.Location = new System.Drawing.Point(333, 44);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 43);
            this.button1.TabIndex = 19;
            this.button1.Text = "Save";
            this.button1.Type = AntdUI.TTypeMini.Primary;
            this.button1.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(10)))), ((int)(((byte)(26)))));
            this.button2.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(162)))), ((int)(((byte)(171)))));
            this.button2.Location = new System.Drawing.Point(469, 44);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 43);
            this.button2.TabIndex = 18;
            this.button2.Text = "Delete";
            this.button2.Type = AntdUI.TTypeMini.Primary;
            this.button2.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(211)))), ((int)(((byte)(233)))));
            this.btnModify.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(162)))), ((int)(((byte)(171)))));
            this.btnModify.Location = new System.Drawing.Point(191, 43);
            this.btnModify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(103, 44);
            this.btnModify.TabIndex = 17;
            this.btnModify.Text = "Modify";
            this.btnModify.Type = AntdUI.TTypeMini.Primary;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(235)))), ((int)(((byte)(66)))));
            this.btnAdd.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(162)))), ((int)(((byte)(171)))));
            this.btnAdd.Location = new System.Drawing.Point(49, 43);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(103, 43);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Add";
            this.btnAdd.Type = AntdUI.TTypeMini.Primary;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(450, 28);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(0, 0);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Type = AntdUI.TTypeMini.Primary;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(18, 28);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(0, 0);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "New";
            this.btnNew.Type = AntdUI.TTypeMini.Primary;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(126, 28);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(0, 0);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.Type = AntdUI.TTypeMini.Primary;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(234, 28);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(0, 0);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Type = AntdUI.TTypeMini.Error;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(342, 28);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(0, 0);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.Type = AntdUI.TTypeMini.Success;
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(487, 105);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(201, 27);
            this.txtPhoneNumber.TabIndex = 11;
            // 
            // txtSpecialization
            // 
            this.txtSpecialization.Location = new System.Drawing.Point(132, 105);
            this.txtSpecialization.Name = "txtSpecialization";
            this.txtSpecialization.Size = new System.Drawing.Size(201, 27);
            this.txtSpecialization.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(364, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "PhoneNumber :";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 23);
            this.label1.TabIndex = 8;
            this.label1.Text = "Specialization :";
            // 
            // txtTeacherCode
            // 
            this.txtTeacherCode.Location = new System.Drawing.Point(133, 24);
            this.txtTeacherCode.Name = "txtTeacherCode";
            this.txtTeacherCode.Size = new System.Drawing.Size(200, 27);
            this.txtTeacherCode.TabIndex = 0;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(133, 60);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(200, 27);
            this.txtFirstName.TabIndex = 1;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(487, 24);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(200, 27);
            this.txtLastName.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(487, 61);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(300, 27);
            this.txtEmail.TabIndex = 3;
            // 
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(14, 28);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(113, 23);
            this.lblCode.TabIndex = 4;
            this.lblCode.Text = "Teacher Code:";
            // 
            // lblLast
            // 
            this.lblLast.Location = new System.Drawing.Point(360, 28);
            this.lblLast.Name = "lblLast";
            this.lblLast.Size = new System.Drawing.Size(100, 23);
            this.lblLast.TabIndex = 6;
            this.lblLast.Text = "Last name:";
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(360, 64);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(100, 23);
            this.lblEmail.TabIndex = 7;
            this.lblEmail.Text = "Email:";
            // 
            // dgvLecturers
            // 
            this.dgvLecturers.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvLecturers.ColumnHeadersHeight = 29;
            this.dgvLecturers.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvLecturers.Location = new System.Drawing.Point(12, 288);
            this.dgvLecturers.Name = "dgvLecturers";
            this.dgvLecturers.ReadOnly = true;
            this.dgvLecturers.RowHeadersWidth = 51;
            this.dgvLecturers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLecturers.Size = new System.Drawing.Size(941, 260);
            this.dgvLecturers.TabIndex = 0;
            this.dgvLecturers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLectures_CellClick);
            // 
            // groupDetails
            // 
            this.groupDetails.Controls.Add(this.txtPhoneNumber);
            this.groupDetails.Controls.Add(this.txtSpecialization);
            this.groupDetails.Controls.Add(this.label2);
            this.groupDetails.Controls.Add(this.label1);
            this.groupDetails.Controls.Add(this.txtTeacherCode);
            this.groupDetails.Controls.Add(this.txtFirstName);
            this.groupDetails.Controls.Add(this.txtLastName);
            this.groupDetails.Controls.Add(this.txtEmail);
            this.groupDetails.Controls.Add(this.lblCode);
            this.groupDetails.Controls.Add(this.lblFirst);
            this.groupDetails.Controls.Add(this.lblLast);
            this.groupDetails.Controls.Add(this.lblEmail);
            this.groupDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupDetails.Location = new System.Drawing.Point(12, 138);
            this.groupDetails.Name = "groupDetails";
            this.groupDetails.Size = new System.Drawing.Size(941, 150);
            this.groupDetails.TabIndex = 1;
            this.groupDetails.TabStop = false;
            this.groupDetails.Text = "Lecturer details";
            // 
            // lblFirst
            // 
            this.lblFirst.Location = new System.Drawing.Point(12, 64);
            this.lblFirst.Name = "lblFirst";
            this.lblFirst.Size = new System.Drawing.Size(100, 23);
            this.lblFirst.TabIndex = 5;
            this.lblFirst.Text = "First name:";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(232)))), ((int)(((byte)(22)))));
            this.btnSearch.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(162)))), ((int)(((byte)(171)))));
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(382, 25);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(96, 49);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Search";
            this.btnSearch.Type = AntdUI.TTypeMini.Primary;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(175, 35);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(175, 27);
            this.txtSearch.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Teacher Code :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(12, 548);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(941, 88);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.Silver;
            this.panelMain.Controls.Add(this.groupBox1);
            this.panelMain.Controls.Add(this.dgvLecturers);
            this.panelMain.Controls.Add(this.groupDetails);
            this.panelMain.Controls.Add(this.groupActions);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 48);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(12);
            this.panelMain.Size = new System.Drawing.Size(965, 648);
            this.panelMain.TabIndex = 2;
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.Silver;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(965, 48);
            this.lblHeader.TabIndex = 3;
            this.lblHeader.Text = "Lecturers Management";
            // 
            // frmLectures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 696);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmLectures";
            this.Text = "Lecturers Management";
            this.Load += new System.EventHandler(this.frmLectures_Load);
            this.groupActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLecturers)).EndInit();
            this.groupDetails.ResumeLayout(false);
            this.groupDetails.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupActions;
        private AntdUI.Button btnCancel;
        private AntdUI.Button button1;
        private AntdUI.Button button2;
        private AntdUI.Button btnModify;
        private AntdUI.Button btnAdd;
        private AntdUI.Button btnRefresh;
        private AntdUI.Button btnNew;
        private AntdUI.Button btnEdit;
        private AntdUI.Button btnDelete;
        private AntdUI.Button btnSave;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.TextBox txtSpecialization;
        private AntdUI.Label label2;
        private AntdUI.Label label1;
        private System.Windows.Forms.TextBox txtTeacherCode;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblLast;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.DataGridView dgvLecturers;
        private System.Windows.Forms.GroupBox groupDetails;
        private System.Windows.Forms.Label lblFirst;
        private AntdUI.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panelMain;
        private AntdUI.Label lblHeader;
    }
}