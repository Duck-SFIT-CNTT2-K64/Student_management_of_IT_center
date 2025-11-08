namespace Student_manager.UI
{
    partial class frmAccount
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
            this.dgvAccounts = new System.Windows.Forms.DataGridView();
            this.groupDetails = new System.Windows.Forms.GroupBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.chkShowNewPassword = new System.Windows.Forms.CheckBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.groupActions = new System.Windows.Forms.GroupBox();
            this.btnResetPassword = new AntdUI.Button();
            this.btnAccRefresh = new AntdUI.Button();
            this.btnAccNew = new AntdUI.Button();
            this.btnAccEdit = new AntdUI.Button();
            this.btnAccDelete = new AntdUI.Button();
            this.btnAccSave = new AntdUI.Button();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).BeginInit();
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
            this.lblHeader.Size = new System.Drawing.Size(880, 48);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "Accounts Management";
            //
            // panelMain
            //
            this.panelMain.BackColor = System.Drawing.Color.Silver;
            this.panelMain.Controls.Add(this.dgvAccounts);
            this.panelMain.Controls.Add(this.groupDetails);
            this.panelMain.Controls.Add(this.groupActions);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 48);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(12);
            this.panelMain.Size = new System.Drawing.Size(880, 552);
            this.panelMain.TabIndex = 0;
            //
            // dgvAccounts
            //
            this.dgvAccounts.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvAccounts.Location = new System.Drawing.Point(12, 12);
            this.dgvAccounts.Name = "dgvAccounts";
            this.dgvAccounts.ReadOnly = true;
            this.dgvAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAccounts.Size = new System.Drawing.Size(856, 260);
            this.dgvAccounts.TabIndex = 0;
            this.dgvAccounts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAccounts_CellContentClick);
            this.dgvAccounts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAccounts_CellDoubleClick);
            //
            // groupDetails
            //
            this.groupDetails.Controls.Add(this.txtNewPassword);
            this.groupDetails.Controls.Add(this.chkShowNewPassword);
            this.groupDetails.Controls.Add(this.txtUsername);
            this.groupDetails.Controls.Add(this.txtFullName);
            this.groupDetails.Controls.Add(this.txtEmail);
            this.groupDetails.Controls.Add(this.cboRole);
            this.groupDetails.Controls.Add(this.lblUsername);
            this.groupDetails.Controls.Add(this.lblFullName);
            this.groupDetails.Controls.Add(this.lblEmail);
            this.groupDetails.Controls.Add(this.lblRole);
            this.groupDetails.Location = new System.Drawing.Point(12, 280);
            this.groupDetails.Name = "groupDetails";
            this.groupDetails.Size = new System.Drawing.Size(856, 150);
            this.groupDetails.TabIndex = 1;
            this.groupDetails.TabStop = false;
            this.groupDetails.Text = "Account details";
            //
            // txtNewPassword
            //
            this.txtNewPassword.Location = new System.Drawing.Point(520, 60);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(220, 23);
            this.txtNewPassword.TabIndex = 10;
            this.txtNewPassword.PasswordChar = '•';
            //
            // chkShowNewPassword
            //
            this.chkShowNewPassword.AutoSize = true;
            this.chkShowNewPassword.Location = new System.Drawing.Point(746, 62);
            this.chkShowNewPassword.Name = "chkShowNewPassword";
            this.chkShowNewPassword.Size = new System.Drawing.Size(86, 19);
            this.chkShowNewPassword.TabIndex = 11;
            this.chkShowNewPassword.Text = "Hiện mật khẩu";
            this.chkShowNewPassword.CheckedChanged += (s, e) =>
            {
                this.txtNewPassword.PasswordChar = this.chkShowNewPassword.Checked ? '\0' : '•';
            };
            //
            // txtUsername
            //
            this.txtUsername.Location = new System.Drawing.Point(120, 24);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(300, 23);
            this.txtUsername.TabIndex = 0;
            //
            // txtFullName
            //
            this.txtFullName.Location = new System.Drawing.Point(120, 60);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(300, 23);
            this.txtFullName.TabIndex = 1;
            //
            // txtEmail
            //
            this.txtEmail.Location = new System.Drawing.Point(120, 96);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(300, 23);
            this.txtEmail.TabIndex = 2;
            //
            // cboRole
            //
            this.cboRole.Location = new System.Drawing.Point(520, 24);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(200, 23);
            this.cboRole.TabIndex = 3;
            //
            // lblUsername
            //
            this.lblUsername.Location = new System.Drawing.Point(12, 28);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(100, 23);
            this.lblUsername.TabIndex = 4;
            this.lblUsername.Text = "Username:";
            //
            // lblFullName
            //
            this.lblFullName.Location = new System.Drawing.Point(12, 64);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(100, 23);
            this.lblFullName.TabIndex = 5;
            this.lblFullName.Text = "Full name:";
            //
            // lblEmail
            //
            this.lblEmail.Location = new System.Drawing.Point(12, 100);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(100, 23);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email:";
            //
            // lblRole
            //
            this.lblRole.Location = new System.Drawing.Point(450, 28);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(100, 23);
            this.lblRole.TabIndex = 7;
            this.lblRole.Text = "Role:";
            //
            // groupActions
            //
            this.groupActions.Controls.Add(this.btnResetPassword);
            this.groupActions.Controls.Add(this.btnAccRefresh);
            this.groupActions.Controls.Add(this.btnAccNew);
            this.groupActions.Controls.Add(this.btnAccEdit);
            this.groupActions.Controls.Add(this.btnAccDelete);
            this.groupActions.Controls.Add(this.btnAccSave);
            this.groupActions.Location = new System.Drawing.Point(12, 436);
            this.groupActions.Name = "groupActions";
            this.groupActions.Size = new System.Drawing.Size(856, 100);
            this.groupActions.TabIndex = 2;
            this.groupActions.TabStop = false;
            this.groupActions.Text = "Actions";
            //
            // btnResetPassword
            //
            this.btnResetPassword.Location = new System.Drawing.Point(562, 28);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(120, 46);
            this.btnResetPassword.TabIndex = 11;
            this.btnResetPassword.Text = "Reset Password";
            this.btnResetPassword.Type = AntdUI.TTypeMini.Error;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            //
            // btnAccRefresh
            //
            this.btnAccRefresh.Location = new System.Drawing.Point(450, 28);
            this.btnAccRefresh.Name = "btnAccRefresh";
            this.btnAccRefresh.Size = new System.Drawing.Size(100, 46);
            this.btnAccRefresh.TabIndex = 0;
            this.btnAccRefresh.Text = "Refresh";
            this.btnAccRefresh.Type = AntdUI.TTypeMini.Primary;
            this.btnAccRefresh.Click += new System.EventHandler(this.btnAccRefresh_Click);
            //
            // btnAccNew
            //
            this.btnAccNew.Location = new System.Drawing.Point(18, 28);
            this.btnAccNew.Name = "btnAccNew";
            this.btnAccNew.Size = new System.Drawing.Size(100, 46);
            this.btnAccNew.TabIndex = 1;
            this.btnAccNew.Text = "New";
            this.btnAccNew.Type = AntdUI.TTypeMini.Primary;
            this.btnAccNew.Click += new System.EventHandler(this.btnAccNew_Click);
            //
            // btnAccEdit
            //
            this.btnAccEdit.Location = new System.Drawing.Point(126, 28);
            this.btnAccEdit.Name = "btnAccEdit";
            this.btnAccEdit.Size = new System.Drawing.Size(100, 46);
            this.btnAccEdit.TabIndex = 2;
            this.btnAccEdit.Text = "Edit";
            this.btnAccEdit.Type = AntdUI.TTypeMini.Primary;
            this.btnAccEdit.Click += new System.EventHandler(this.btnAccEdit_Click);
            //
            // btnAccDelete
            //
            this.btnAccDelete.Location = new System.Drawing.Point(234, 28);
            this.btnAccDelete.Name = "btnAccDelete";
            this.btnAccDelete.Size = new System.Drawing.Size(100, 46);
            this.btnAccDelete.TabIndex = 3;
            this.btnAccDelete.Text = "Delete";
            this.btnAccDelete.Type = AntdUI.TTypeMini.Error;
            this.btnAccDelete.Click += new System.EventHandler(this.btnAccDelete_Click);
            //
            // btnAccSave
            //
            this.btnAccSave.Location = new System.Drawing.Point(342, 28);
            this.btnAccSave.Name = "btnAccSave";
            this.btnAccSave.Size = new System.Drawing.Size(100, 46);
            this.btnAccSave.TabIndex = 4;
            this.btnAccSave.Text = "Save";
            this.btnAccSave.Type = AntdUI.TTypeMini.Success;
            this.btnAccSave.Click += new System.EventHandler(this.btnAccSave_Click);
            //
            // frmAccount
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 600);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmAccount";
            this.Text = "Accounts";
            this.Load += new System.EventHandler(this.FrmAccount_Load);
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).EndInit();
            this.groupDetails.ResumeLayout(false);
            this.groupDetails.PerformLayout();
            this.groupActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.Label lblHeader;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.DataGridView dgvAccounts;
        private System.Windows.Forms.GroupBox groupDetails;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.CheckBox chkShowNewPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.GroupBox groupActions;
        private AntdUI.Button btnResetPassword;
        private AntdUI.Button btnAccNew;
        private AntdUI.Button btnAccEdit;
        private AntdUI.Button btnAccDelete;
        private AntdUI.Button btnAccSave;
        private AntdUI.Button btnAccRefresh;
    }
}