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
            this.rdoStudent = new AntdUI.Radio();
            this.rdoUser = new AntdUI.Radio();
            this.rdoTeacher = new AntdUI.Radio();
            this.label1 = new AntdUI.Label();
            this.lblRecipients = new AntdUI.Label();
            this.radTeachers = new AntdUI.Radio();
            this.radUsers = new AntdUI.Radio();
            this.radStudents = new AntdUI.Radio();
            this.btnSend = new AntdUI.Button();
            this.btnDelete = new AntdUI.Button();
            this.lblTitle = new AntdUI.Label();
            this.lblSubject = new AntdUI.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.btnReset = new AntdUI.Button();
            this.groupBoxRecipients.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(242, 170);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(1160, 368);
            this.txtMessage.TabIndex = 8;
            // 
            // groupBoxRecipients
            // 
            this.groupBoxRecipients.BackColor = System.Drawing.Color.Silver;
            this.groupBoxRecipients.Controls.Add(this.rdoStudent);
            this.groupBoxRecipients.Controls.Add(this.rdoUser);
            this.groupBoxRecipients.Controls.Add(this.rdoTeacher);
            this.groupBoxRecipients.Controls.Add(this.label1);
            this.groupBoxRecipients.Controls.Add(this.lblRecipients);
            this.groupBoxRecipients.Controls.Add(this.radTeachers);
            this.groupBoxRecipients.Controls.Add(this.radUsers);
            this.groupBoxRecipients.Controls.Add(this.radStudents);
            this.groupBoxRecipients.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxRecipients.Location = new System.Drawing.Point(0, 0);
            this.groupBoxRecipients.Name = "groupBoxRecipients";
            this.groupBoxRecipients.Size = new System.Drawing.Size(236, 691);
            this.groupBoxRecipients.TabIndex = 7;
            this.groupBoxRecipients.TabStop = false;
            this.groupBoxRecipients.Enter += new System.EventHandler(this.groupBoxRecipients_Enter);
            // 
            // rdoStudent
            // 
            this.rdoStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoStudent.Location = new System.Drawing.Point(21, 425);
            this.rdoStudent.Name = "rdoStudent";
            this.rdoStudent.Size = new System.Drawing.Size(210, 81);
            this.rdoStudent.TabIndex = 12;
            this.rdoStudent.Text = "Students";
            // 
            // rdoUser
            // 
            this.rdoUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoUser.Location = new System.Drawing.Point(21, 329);
            this.rdoUser.Name = "rdoUser";
            this.rdoUser.Size = new System.Drawing.Size(210, 81);
            this.rdoUser.TabIndex = 11;
            this.rdoUser.Text = "Users";
            // 
            // rdoTeacher
            // 
            this.rdoTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoTeacher.Location = new System.Drawing.Point(21, 224);
            this.rdoTeacher.Name = "rdoTeacher";
            this.rdoTeacher.Size = new System.Drawing.Size(210, 81);
            this.rdoTeacher.TabIndex = 10;
            this.rdoTeacher.Text = "Teachers";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 48);
            this.label1.TabIndex = 9;
            this.label1.Text = "Send to:";
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
            this.btnSend.Location = new System.Drawing.Point(379, 544);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(145, 66);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.Type = AntdUI.TTypeMini.Success;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1241, 544);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(141, 66);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Type = AntdUI.TTypeMini.Warn;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(633, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(391, 82);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Notification";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubject
            // 
            this.lblSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubject.Location = new System.Drawing.Point(423, 100);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(130, 48);
            this.lblSubject.TabIndex = 5;
            this.lblSubject.Text = "Subject:";
            // 
            // txtSubject
            // 
            this.txtSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubject.Location = new System.Drawing.Point(568, 100);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(456, 45);
            this.txtSubject.TabIndex = 4;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(811, 544);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(153, 66);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.Type = AntdUI.TTypeMini.Primary;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // frmNotification
            // 
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1414, 691);
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
        private AntdUI.Label lblTitle;
        private AntdUI.Label lblSubject;
        private System.Windows.Forms.TextBox txtSubject;
        private AntdUI.Button btnReset;
        private AntdUI.Label label1;
        private AntdUI.Radio rdoStudent;
        private AntdUI.Radio rdoUser;
        private AntdUI.Radio rdoTeacher;
    }
}