namespace Student_manager.UI
{
    partial class frmTeacher
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
            this.lblTeacher = new AntdUI.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExit = new AntdUI.Button();
            this.btnCancel = new AntdUI.Button();
            this.btnDelete = new AntdUI.Button();
            this.btnSave = new AntdUI.Button();
            this.btnModify = new AntdUI.Button();
            this.btnAdd = new AntdUI.Button();
            this.dgvTeacher = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSpec = new System.Windows.Forms.TextBox();
            this.cboSex = new System.Windows.Forms.ComboBox();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label7 = new AntdUI.Label();
            this.label6 = new AntdUI.Label();
            this.label5 = new AntdUI.Label();
            this.label4 = new AntdUI.Label();
            this.label3 = new AntdUI.Label();
            this.label2 = new AntdUI.Label();
            this.label1 = new AntdUI.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtSearch = new AntdUI.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new AntdUI.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeacher)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTeacher
            // 
            this.lblTeacher.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeacher.Location = new System.Drawing.Point(0, 0);
            this.lblTeacher.Name = "lblTeacher";
            this.lblTeacher.Size = new System.Drawing.Size(945, 37);
            this.lblTeacher.TabIndex = 0;
            this.lblTeacher.Text = "Teacher Management";
            this.lblTeacher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnModify);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(945, 72);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actor";
            // 
            // btnExit
            // 
            this.btnExit.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(162)))), ((int)(((byte)(171)))));
            this.btnExit.Location = new System.Drawing.Point(557, 21);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 32);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(13)))), ((int)(((byte)(85)))));
            this.btnCancel.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(162)))), ((int)(((byte)(171)))));
            this.btnCancel.Location = new System.Drawing.Point(452, 21);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 32);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Type = AntdUI.TTypeMini.Primary;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(10)))), ((int)(((byte)(26)))));
            this.btnDelete.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(162)))), ((int)(((byte)(171)))));
            this.btnDelete.Location = new System.Drawing.Point(239, 21);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 32);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Type = AntdUI.TTypeMini.Primary;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(239)))), ((int)(((byte)(111)))));
            this.btnSave.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(162)))), ((int)(((byte)(171)))));
            this.btnSave.Location = new System.Drawing.Point(347, 21);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 32);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.Type = AntdUI.TTypeMini.Primary;
            // 
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(211)))), ((int)(((byte)(233)))));
            this.btnModify.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(162)))), ((int)(((byte)(171)))));
            this.btnModify.Location = new System.Drawing.Point(130, 21);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(80, 32);
            this.btnModify.TabIndex = 1;
            this.btnModify.Text = "Modify";
            this.btnModify.Type = AntdUI.TTypeMini.Primary;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(235)))), ((int)(((byte)(66)))));
            this.btnAdd.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(162)))), ((int)(((byte)(171)))));
            this.btnAdd.Location = new System.Drawing.Point(29, 21);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 32);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.Type = AntdUI.TTypeMini.Primary;
            // 
            // dgvTeacher
            // 
            this.dgvTeacher.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvTeacher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeacher.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvTeacher.Location = new System.Drawing.Point(0, 109);
            this.dgvTeacher.Name = "dgvTeacher";
            this.dgvTeacher.RowHeadersWidth = 51;
            this.dgvTeacher.RowTemplate.Height = 24;
            this.dgvTeacher.Size = new System.Drawing.Size(945, 217);
            this.dgvTeacher.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSpec);
            this.groupBox2.Controls.Add(this.cboSex);
            this.groupBox2.Controls.Add(this.txtPosition);
            this.groupBox2.Controls.Add(this.txtEmail);
            this.groupBox2.Controls.Add(this.txtNumber);
            this.groupBox2.Controls.Add(this.txtCode);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 326);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(945, 139);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Information";
            // 
            // txtSpec
            // 
            this.txtSpec.Location = new System.Drawing.Point(731, 23);
            this.txtSpec.Multiline = true;
            this.txtSpec.Name = "txtSpec";
            this.txtSpec.Size = new System.Drawing.Size(202, 63);
            this.txtSpec.TabIndex = 13;
            // 
            // cboSex
            // 
            this.cboSex.FormattingEnabled = true;
            this.cboSex.Location = new System.Drawing.Point(87, 103);
            this.cboSex.Name = "cboSex";
            this.cboSex.Size = new System.Drawing.Size(121, 24);
            this.cboSex.TabIndex = 12;
            // 
            // txtPosition
            // 
            this.txtPosition.Location = new System.Drawing.Point(386, 105);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(108, 22);
            this.txtPosition.TabIndex = 11;
            this.txtPosition.Text = "Teacher";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(386, 23);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(215, 22);
            this.txtEmail.TabIndex = 10;
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(386, 63);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(108, 22);
            this.txtNumber.TabIndex = 9;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(87, 23);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(179, 22);
            this.txtCode.TabIndex = 8;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(87, 63);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(179, 22);
            this.txtName.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(626, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 23);
            this.label7.TabIndex = 6;
            this.label7.Text = "Specialization :";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(290, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "Position :";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(290, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Phone Number :";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(290, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Email :";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(29, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sex :";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(29, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name :";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(29, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Code :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtSearch);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 465);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(945, 64);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(314, 18);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(85, 31);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.Text = "Search";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(87, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(179, 22);
            this.textBox1.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(19, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 23);
            this.label8.TabIndex = 0;
            this.label8.Text = "Name :";
            // 
            // frmTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 525);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvTeacher);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTeacher);
            this.Name = "frmTeacher";
            this.Text = "frmTeacher";
            this.Load += new System.EventHandler(this.frmTeacher_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeacher)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.Label lblTeacher;
        private System.Windows.Forms.GroupBox groupBox1;
        private AntdUI.Button btnExit;
        private AntdUI.Button btnCancel;
        private AntdUI.Button btnDelete;
        private AntdUI.Button btnSave;
        private AntdUI.Button btnModify;
        private AntdUI.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvTeacher;
        private System.Windows.Forms.GroupBox groupBox2;
        private AntdUI.Label label7;
        private AntdUI.Label label6;
        private AntdUI.Label label5;
        private AntdUI.Label label4;
        private AntdUI.Label label3;
        private AntdUI.Label label2;
        private AntdUI.Label label1;
        private System.Windows.Forms.ComboBox cboSex;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSpec;
        private System.Windows.Forms.GroupBox groupBox3;
        private AntdUI.Button txtSearch;
        private System.Windows.Forms.TextBox textBox1;
        private AntdUI.Label label8;
    }
}