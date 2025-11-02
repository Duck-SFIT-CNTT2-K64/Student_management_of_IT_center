namespace Student_manager.UI
{
    partial class frmLopHoc
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
            this.label1 = new AntdUI.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new AntdUI.Label();
            this.label3 = new AntdUI.Label();
            this.label4 = new AntdUI.Label();
            this.txtClassCode = new System.Windows.Forms.TextBox();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.label5 = new AntdUI.Label();
            this.label6 = new AntdUI.Label();
            this.cboTeacherName = new System.Windows.Forms.ComboBox();
            this.cboCourseName = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new AntdUI.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label8 = new AntdUI.Label();
            this.dgvClasses = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnExit = new AntdUI.Button();
            this.btnCancel = new AntdUI.Button();
            this.btnDelete = new AntdUI.Button();
            this.btnSave = new AntdUI.Button();
            this.btnModify = new AntdUI.Button();
            this.btnAdd = new AntdUI.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasses)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(800, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Classes Management";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboCourseName);
            this.groupBox1.Controls.Add(this.cboTeacherName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtMax);
            this.groupBox1.Controls.Add(this.txtClassName);
            this.groupBox1.Controls.Add(this.txtClassCode);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 156);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(29, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Class Code :";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(29, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Class Name :";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(29, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "MaxStudents :";
            // 
            // txtClassCode
            // 
            this.txtClassCode.Location = new System.Drawing.Point(129, 22);
            this.txtClassCode.Name = "txtClassCode";
            this.txtClassCode.Size = new System.Drawing.Size(207, 22);
            this.txtClassCode.TabIndex = 3;
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(129, 66);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(207, 22);
            this.txtClassName.TabIndex = 4;
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(129, 112);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(100, 22);
            this.txtMax.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(382, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "Teacher Name :";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(382, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 23);
            this.label6.TabIndex = 7;
            this.label6.Text = "Course Name :";
            // 
            // cboTeacherName
            // 
            this.cboTeacherName.FormattingEnabled = true;
            this.cboTeacherName.Location = new System.Drawing.Point(507, 22);
            this.cboTeacherName.Name = "cboTeacherName";
            this.cboTeacherName.Size = new System.Drawing.Size(185, 24);
            this.cboTeacherName.TabIndex = 8;
            // 
            // cboCourseName
            // 
            this.cboCourseName.FormattingEnabled = true;
            this.cboCourseName.Location = new System.Drawing.Point(507, 66);
            this.cboCourseName.Name = "cboCourseName";
            this.cboCourseName.Size = new System.Drawing.Size(185, 24);
            this.cboCourseName.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.txtSearch);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 193);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(800, 70);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(331, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(85, 39);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(125, 22);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(179, 22);
            this.txtSearch.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(29, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 23);
            this.label8.TabIndex = 6;
            this.label8.Text = "Class Name :";
            // 
            // dgvClasses
            // 
            this.dgvClasses.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvClasses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClasses.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvClasses.Location = new System.Drawing.Point(0, 263);
            this.dgvClasses.Name = "dgvClasses";
            this.dgvClasses.RowHeadersWidth = 51;
            this.dgvClasses.RowTemplate.Height = 24;
            this.dgvClasses.Size = new System.Drawing.Size(800, 196);
            this.dgvClasses.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnExit);
            this.groupBox3.Controls.Add(this.btnCancel);
            this.groupBox3.Controls.Add(this.btnDelete);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.btnModify);
            this.groupBox3.Controls.Add(this.btnAdd);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 459);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(800, 68);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(611, 18);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 32);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Exit";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(506, 18);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 32);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(293, 18);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 32);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(401, 18);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 32);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(184, 18);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(80, 32);
            this.btnModify.TabIndex = 7;
            this.btnModify.Text = "Modify";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(83, 18);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 32);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            // 
            // frmLopHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 533);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dgvClasses);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmLopHoc";
            this.Text = "frmLopHoc";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasses)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.TextBox txtClassCode;
        private AntdUI.Label label4;
        private AntdUI.Label label3;
        private AntdUI.Label label2;
        private AntdUI.Label label6;
        private AntdUI.Label label5;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.ComboBox cboCourseName;
        private System.Windows.Forms.ComboBox cboTeacherName;
        private System.Windows.Forms.GroupBox groupBox2;
        private AntdUI.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private AntdUI.Label label8;
        private System.Windows.Forms.DataGridView dgvClasses;
        private System.Windows.Forms.GroupBox groupBox3;
        private AntdUI.Button btnExit;
        private AntdUI.Button btnCancel;
        private AntdUI.Button btnDelete;
        private AntdUI.Button btnSave;
        private AntdUI.Button btnModify;
        private AntdUI.Button btnAdd;
    }
}