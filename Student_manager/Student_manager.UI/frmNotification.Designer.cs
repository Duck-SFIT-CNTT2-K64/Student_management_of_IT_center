namespace Student_manager.UI
{
    partial class frmNotification
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
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.groupBoxRecipients = new System.Windows.Forms.GroupBox();
            this.lblRecipients = new AntdUI.Label();
            this.radTeachers = new AntdUI.Radio();
            this.radUsers = new AntdUI.Radio();
            this.radStudents = new AntdUI.Radio();
            this.btnSend = new AntdUI.Button();
            this.btnDelete = new AntdUI.Button();
            this.btnExit = new AntdUI.Button();
            this.lblTitle = new AntdUI.Label();
            this.lblSubject = new AntdUI.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.btnReset = new AntdUI.Button();
            this.groupBoxRecipients.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(265, 164);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(1015, 368);
            this.txtMessage.TabIndex = 8;
            // 
            // groupBoxRecipients
            // 
            this.groupBoxRecipients.BackColor = System.Drawing.Color.Silver;
            this.groupBoxRecipients.Controls.Add(this.lblRecipients);
            this.groupBoxRecipients.Controls.Add(this.radTeachers);
            this.groupBoxRecipients.Controls.Add(this.radUsers);
            this.groupBoxRecipients.Controls.Add(this.radStudents);
            this.groupBoxRecipients.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxRecipients.Location = new System.Drawing.Point(0, 0);
            this.groupBoxRecipients.Name = "groupBoxRecipients";
            this.groupBoxRecipients.Size = new System.Drawing.Size(220, 691);
            this.groupBoxRecipients.TabIndex = 7;
            this.groupBoxRecipients.TabStop = false;
            // 
            // lblRecipients
            // 
            this.lblRecipients.Location = new System.Drawing.Point(0, 0);
            this.lblRecipients.Name = "lblRecipients";
            this.lblRecipients.Size = new System.Drawing.Size(0, 0);
            this.lblRecipients.TabIndex = 0;
            this.lblRecipients.Text = "Recipients";
            // 
            // radTeachers
            // 
            this.radTeachers.Location = new System.Drawing.Point(0, 0);
            this.radTeachers.Name = "radTeachers";
            this.radTeachers.Size = new System.Drawing.Size(0, 0);
            this.radTeachers.TabIndex = 1;
            this.radTeachers.Text = "Teachers";
            // 
            // radUsers
            // 
            this.radUsers.Location = new System.Drawing.Point(0, 0);
            this.radUsers.Name = "radUsers";
            this.radUsers.Size = new System.Drawing.Size(0, 0);
            this.radUsers.TabIndex = 2;
            this.radUsers.Text = "Users";
            // 
            // radStudents
            // 
            this.radStudents.Location = new System.Drawing.Point(0, 0);
            this.radStudents.Name = "radStudents";
            this.radStudents.Size = new System.Drawing.Size(0, 0);
            this.radStudents.TabIndex = 3;
            this.radStudents.Text = "Students";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(300, 560);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(120, 50);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.Type = AntdUI.TTypeMini.Success;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(600, 560);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 50);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Type = AntdUI.TTypeMini.Warn;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(760, 560);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(120, 50);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Close";
            this.btnExit.Type = AntdUI.TTypeMini.Error;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(617, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(391, 82);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Notification";
            // 
            // lblSubject
            // 
            this.lblSubject.Location = new System.Drawing.Point(244, 96);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(130, 48);
            this.lblSubject.TabIndex = 5;
            this.lblSubject.Text = "Subject:";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(381, 96);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(456, 20);
            this.txtSubject.TabIndex = 4;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(450, 560);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(120, 50);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.Type = AntdUI.TTypeMini.Primary;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // frmNotification
            // 
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1328, 691);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.groupBoxRecipients);
            this.Controls.Add(this.txtMessage);
            this.Name = "frmNotification";
            this.Text = "Notification";
            this.groupBoxRecipients.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.GroupBox groupBoxRecipients;
        private AntdUI.Radio radStudents;
        private AntdUI.Label lblRecipients;
        private AntdUI.Radio radTeachers;
        private AntdUI.Radio radUsers;
        private AntdUI.Button btnSend;
        private AntdUI.Button btnDelete;
        private AntdUI.Button btnExit;
        private AntdUI.Label lblTitle;
        private AntdUI.Label lblSubject;
        private System.Windows.Forms.TextBox txtSubject;
        private AntdUI.Button btnReset;
    }
}