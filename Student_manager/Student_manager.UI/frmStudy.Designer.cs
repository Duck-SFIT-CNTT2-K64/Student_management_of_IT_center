namespace Student_manager.UI
{
    partial class frmStudy
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblStudentID = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblBirth = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.dgvBangDiem = new System.Windows.Forms.DataGridView();
            this.lblTitle = new AntdUI.Label();
            this.lblTotal10 = new System.Windows.Forms.Label();
            this.lblTotal4 = new System.Windows.Forms.Label();
            this.btnClose = new AntdUI.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangDiem)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.lblStudentID);
            this.groupBox1.Controls.Add(this.lblFullName);
            this.groupBox1.Controls.Add(this.lblBirth);
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Controls.Add(this.lblGender);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 614);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Location = new System.Drawing.Point(0, 0);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(69, 13);
            this.lblStudentID.TabIndex = 0;
            this.lblStudentID.Text = "Student ID: x";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(0, 0);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(62, 13);
            this.lblFullName.TabIndex = 1;
            this.lblFullName.Text = "FullName: x";
            // 
            // lblBirth
            // 
            this.lblBirth.AutoSize = true;
            this.lblBirth.Location = new System.Drawing.Point(0, 0);
            this.lblBirth.Name = "lblBirth";
            this.lblBirth.Size = new System.Drawing.Size(39, 13);
            this.lblBirth.TabIndex = 2;
            this.lblBirth.Text = "Birth: x";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(0, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(48, 13);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Status: x";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(0, 0);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(36, 13);
            this.lblGender.TabIndex = 4;
            this.lblGender.Text = "Sex: x";
            // 
            // dgvBangDiem
            // 
            this.dgvBangDiem.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvBangDiem.Location = new System.Drawing.Point(356, 122);
            this.dgvBangDiem.Name = "dgvBangDiem";
            this.dgvBangDiem.Size = new System.Drawing.Size(918, 314);
            this.dgvBangDiem.TabIndex = 4;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Silver;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(337, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(989, 52);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Scores Table";
            // 
            // lblTotal10
            // 
            this.lblTotal10.AutoSize = true;
            this.lblTotal10.Location = new System.Drawing.Point(500, 460);
            this.lblTotal10.Name = "lblTotal10";
            this.lblTotal10.Size = new System.Drawing.Size(91, 13);
            this.lblTotal10.TabIndex = 2;
            this.lblTotal10.Text = "Total (10-scale): x";
            // 
            // lblTotal4
            // 
            this.lblTotal4.AutoSize = true;
            this.lblTotal4.Location = new System.Drawing.Point(800, 460);
            this.lblTotal4.Name = "lblTotal4";
            this.lblTotal4.Size = new System.Drawing.Size(85, 13);
            this.lblTotal4.TabIndex = 1;
            this.lblTotal4.Text = "Total (4-scale): x";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(700, 500);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 40);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.Type = AntdUI.TTypeMini.Error;
            // 
            // frmStudy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1326, 614);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTotal4);
            this.Controls.Add(this.lblTotal10);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvBangDiem);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmStudy";
            this.Text = "Study Management";
            this.Load += new System.EventHandler(this.frmStudy_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangDiem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblBirth;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.DataGridView dgvBangDiem;
        private AntdUI.Label lblTitle;
        private System.Windows.Forms.Label lblTotal10;
        private System.Windows.Forms.Label lblTotal4;
        private AntdUI.Button btnClose;
    }
}