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
            this.lblHeader = new AntdUI.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.dgvLecturers = new System.Windows.Forms.DataGridView();
            this.groupDetails = new System.Windows.Forms.GroupBox();
            this.txtTeacherCode = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblFirst = new System.Windows.Forms.Label();
            this.lblLast = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.groupActions = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new AntdUI.Button();
            this.btnNew = new AntdUI.Button();
            this.btnEdit = new AntdUI.Button();
            this.btnDelete = new AntdUI.Button();
            this.btnSave = new AntdUI.Button();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLecturers)).BeginInit();
            this.groupDetails.SuspendLayout();
            this.groupActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.Silver;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(920, 48);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "Lecturers Management";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.Silver;
            this.panelMain.Controls.Add(this.dgvLecturers);
            this.panelMain.Controls.Add(this.groupDetails);
            this.panelMain.Controls.Add(this.groupActions);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 48);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(12);
            this.panelMain.Size = new System.Drawing.Size(920, 552);
            this.panelMain.TabIndex = 0;
            // 
            // dgvLecturers
            // 
            this.dgvLecturers.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvLecturers.Location = new System.Drawing.Point(12, 12);
            this.dgvLecturers.Name = "dgvLecturers";
            this.dgvLecturers.ReadOnly = true;
            this.dgvLecturers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLecturers.Size = new System.Drawing.Size(896, 260);
            this.dgvLecturers.TabIndex = 0;
            this.dgvLecturers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLecturers_CellDoubleClick);
            // 
            // groupDetails
            // 
            this.groupDetails.Controls.Add(this.txtTeacherCode);
            this.groupDetails.Controls.Add(this.txtFirstName);
            this.groupDetails.Controls.Add(this.txtLastName);
            this.groupDetails.Controls.Add(this.txtEmail);
            this.groupDetails.Controls.Add(this.lblCode);
            this.groupDetails.Controls.Add(this.lblFirst);
            this.groupDetails.Controls.Add(this.lblLast);
            this.groupDetails.Controls.Add(this.lblEmail);
            this.groupDetails.Location = new System.Drawing.Point(12, 280);
            this.groupDetails.Name = "groupDetails";
            this.groupDetails.Size = new System.Drawing.Size(896, 150);
            this.groupDetails.TabIndex = 1;
            this.groupDetails.TabStop = false;
            this.groupDetails.Text = "Lecturer details";
            // 
            // txtTeacherCode
            // 
            this.txtTeacherCode.Location = new System.Drawing.Point(120, 24);
            this.txtTeacherCode.Name = "txtTeacherCode";
            this.txtTeacherCode.Size = new System.Drawing.Size(200, 23);
            this.txtTeacherCode.TabIndex = 0;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(120, 60);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(200, 23);
            this.txtFirstName.TabIndex = 1;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(440, 24);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(200, 23);
            this.txtLastName.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(440, 60);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(300, 23);
            this.txtEmail.TabIndex = 3;
            // 
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(12, 28);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(100, 23);
            this.lblCode.TabIndex = 4;
            this.lblCode.Text = "Teacher Code:";
            // 
            // lblFirst
            // 
            this.lblFirst.Location = new System.Drawing.Point(12, 64);
            this.lblFirst.Name = "lblFirst";
            this.lblFirst.Size = new System.Drawing.Size(100, 23);
            this.lblFirst.TabIndex = 5;
            this.lblFirst.Text = "First name:";
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
            // groupActions
            // 
            this.groupActions.Controls.Add(this.btnRefresh);
            this.groupActions.Controls.Add(this.btnNew);
            this.groupActions.Controls.Add(this.btnEdit);
            this.groupActions.Controls.Add(this.btnDelete);
            this.groupActions.Controls.Add(this.btnSave);
            this.groupActions.Location = new System.Drawing.Point(12, 436);
            this.groupActions.Name = "groupActions";
            this.groupActions.Size = new System.Drawing.Size(896, 100);
            this.groupActions.TabIndex = 2;
            this.groupActions.TabStop = false;
            this.groupActions.Text = "Actions";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(450, 28);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(0, 0);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Type = AntdUI.TTypeMini.Primary;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(18, 28);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(0, 0);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "New";
            this.btnNew.Type = AntdUI.TTypeMini.Primary;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(126, 28);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(0, 0);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.Type = AntdUI.TTypeMini.Primary;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(234, 28);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(0, 0);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Type = AntdUI.TTypeMini.Error;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(342, 28);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(0, 0);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.Type = AntdUI.TTypeMini.Success;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmLectures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 600);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmLectures";
            this.Text = "Lecturers Management";
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLecturers)).EndInit();
            this.groupDetails.ResumeLayout(false);
            this.groupDetails.PerformLayout();
            this.groupActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.Label lblHeader;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.DataGridView dgvLecturers;
        private System.Windows.Forms.GroupBox groupDetails;
        private System.Windows.Forms.TextBox txtTeacherCode;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblFirst;
        private System.Windows.Forms.Label lblLast;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.GroupBox groupActions;
        private AntdUI.Button btnNew;
        private AntdUI.Button btnEdit;
        private AntdUI.Button btnDelete;
        private AntdUI.Button btnSave;
        private AntdUI.Button btnRefresh;
    }
}