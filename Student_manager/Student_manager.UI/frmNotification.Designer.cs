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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radStudents = new AntdUI.Radio();
            this.radUsers = new AntdUI.Radio();
            this.radTeachers = new AntdUI.Radio();
            this.label1 = new AntdUI.Label();
            this.btnSend = new AntdUI.Button();
            this.btnDelete = new AntdUI.Button();
            this.btnExit = new AntdUI.Button();
            this.label2 = new AntdUI.Label();
            this.label3 = new AntdUI.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.btnReset = new AntdUI.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(265, 164);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(1015, 368);
            this.txtMessage.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.radTeachers);
            this.groupBox1.Controls.Add(this.radUsers);
            this.groupBox1.Controls.Add(this.radStudents);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 691);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // radStudents
            // 
            this.radStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radStudents.Location = new System.Drawing.Point(44, 403);
            this.radStudents.Name = "radStudents";
            this.radStudents.Size = new System.Drawing.Size(124, 73);
            this.radStudents.TabIndex = 0;
            this.radStudents.Text = "Students";
            // 
            // radUsers
            // 
            this.radUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radUsers.Location = new System.Drawing.Point(44, 306);
            this.radUsers.Name = "radUsers";
            this.radUsers.Size = new System.Drawing.Size(124, 73);
            this.radUsers.TabIndex = 1;
            this.radUsers.Text = "Users";
            // 
            // radTeachers
            // 
            this.radTeachers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTeachers.Location = new System.Drawing.Point(44, 215);
            this.radTeachers.Name = "radTeachers";
            this.radTeachers.Size = new System.Drawing.Size(124, 69);
            this.radTeachers.TabIndex = 2;
            this.radTeachers.Text = "Teachers";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 45);
            this.label1.TabIndex = 3;
            this.label1.Text = "Recipients";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(367, 562);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(157, 91);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.Type = AntdUI.TTypeMini.Success;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(804, 562);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(155, 91);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Type = AntdUI.TTypeMini.Warn;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1010, 562);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(151, 91);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.Type = AntdUI.TTypeMini.Error;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(617, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(391, 82);
            this.label2.TabIndex = 6;
            this.label2.Text = "Notification";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(244, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 48);
            this.label3.TabIndex = 7;
            this.label3.Text = "Subject:";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(381, 96);
            this.txtSubject.Multiline = true;
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(456, 48);
            this.txtSubject.TabIndex = 8;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(583, 562);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(157, 91);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "Reset";
            this.btnReset.Type = AntdUI.TTypeMini.Primary;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // frmNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1328, 691);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtMessage);
            this.Name = "frmNotification";
            this.Text = "frmNotification";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.GroupBox groupBox1;
        private AntdUI.Radio radStudents;
        private AntdUI.Label label1;
        private AntdUI.Radio radTeachers;
        private AntdUI.Radio radUsers;
        private AntdUI.Button btnSend;
        private AntdUI.Button btnDelete;
        private AntdUI.Button btnExit;
        private AntdUI.Label label2;
        private AntdUI.Label label3;
        private System.Windows.Forms.TextBox txtSubject;
        private AntdUI.Button btnReset;
    }
}