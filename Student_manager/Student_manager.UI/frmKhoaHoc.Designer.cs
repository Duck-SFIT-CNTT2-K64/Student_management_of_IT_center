namespace Student_manager.UI
{
    partial class frmKhoaHoc
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
            this.dgvKhoaHoc = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new AntdUI.Button();
            this.btnSave = new AntdUI.Button();
            this.btnDelete = new AntdUI.Button();
            this.btnModify = new AntdUI.Button();
            this.btnAdd = new AntdUI.Button();
            this.txtCourseCode = new System.Windows.Forms.TextBox();
            this.txtFee = new System.Windows.Forms.TextBox();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtCourseName = new System.Windows.Forms.TextBox();
            this.label6 = new AntdUI.Label();
            this.label5 = new AntdUI.Label();
            this.label4 = new AntdUI.Label();
            this.label3 = new AntdUI.Label();
            this.label2 = new AntdUI.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new AntdUI.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label8 = new AntdUI.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoaHoc)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(815, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Courses Management";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvKhoaHoc
            // 
            this.dgvKhoaHoc.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvKhoaHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhoaHoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvKhoaHoc.Location = new System.Drawing.Point(0, 39);
            this.dgvKhoaHoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvKhoaHoc.Name = "dgvKhoaHoc";
            this.dgvKhoaHoc.RowHeadersWidth = 51;
            this.dgvKhoaHoc.RowTemplate.Height = 24;
            this.dgvKhoaHoc.Size = new System.Drawing.Size(815, 203);
            this.dgvKhoaHoc.TabIndex = 1;
            this.dgvKhoaHoc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhoaHoc_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnModify);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.txtCourseCode);
            this.groupBox1.Controls.Add(this.txtFee);
            this.groupBox1.Controls.Add(this.txtDuration);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.txtCourseName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 242);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(815, 225);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(13)))), ((int)(((byte)(85)))));
            this.btnCancel.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(162)))), ((int)(((byte)(171)))));
            this.btnCancel.Location = new System.Drawing.Point(595, 89);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 44);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Type = AntdUI.TTypeMini.Primary;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(239)))), ((int)(((byte)(111)))));
            this.btnSave.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(162)))), ((int)(((byte)(171)))));
            this.btnSave.Location = new System.Drawing.Point(595, 22);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 43);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.Type = AntdUI.TTypeMini.Primary;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(10)))), ((int)(((byte)(26)))));
            this.btnDelete.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(162)))), ((int)(((byte)(171)))));
            this.btnDelete.Location = new System.Drawing.Point(452, 162);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(103, 43);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Type = AntdUI.TTypeMini.Primary;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(211)))), ((int)(((byte)(233)))));
            this.btnModify.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(162)))), ((int)(((byte)(171)))));
            this.btnModify.Location = new System.Drawing.Point(452, 89);
            this.btnModify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(103, 44);
            this.btnModify.TabIndex = 11;
            this.btnModify.Text = "Modify";
            this.btnModify.Type = AntdUI.TTypeMini.Primary;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(235)))), ((int)(((byte)(66)))));
            this.btnAdd.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(162)))), ((int)(((byte)(171)))));
            this.btnAdd.Location = new System.Drawing.Point(452, 22);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(103, 43);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add";
            this.btnAdd.Type = AntdUI.TTypeMini.Primary;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtCourseCode
            // 
            this.txtCourseCode.Location = new System.Drawing.Point(147, 22);
            this.txtCourseCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCourseCode.Name = "txtCourseCode";
            this.txtCourseCode.Size = new System.Drawing.Size(225, 22);
            this.txtCourseCode.TabIndex = 9;
            // 
            // txtFee
            // 
            this.txtFee.Location = new System.Drawing.Point(147, 185);
            this.txtFee.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFee.Name = "txtFee";
            this.txtFee.Size = new System.Drawing.Size(225, 22);
            this.txtFee.TabIndex = 8;
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(147, 139);
            this.txtDuration.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(225, 22);
            this.txtDuration.TabIndex = 7;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(147, 101);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(225, 22);
            this.txtDescription.TabIndex = 6;
            // 
            // txtCourseName
            // 
            this.txtCourseName.Location = new System.Drawing.Point(147, 62);
            this.txtCourseName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCourseName.Name = "txtCourseName";
            this.txtCourseName.Size = new System.Drawing.Size(225, 22);
            this.txtCourseName.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(47, 138);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 23);
            this.label6.TabIndex = 4;
            this.label6.Text = "Duration :";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(47, 183);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 23);
            this.label5.TabIndex = 3;
            this.label5.Text = "Tuition Fee :";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(47, 100);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Description :";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(47, 60);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Course Name :";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(47, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Course Code :";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Silver;
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.txtSearch);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 467);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(815, 70);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(232)))), ((int)(((byte)(22)))));
            this.btnSearch.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(162)))), ((int)(((byte)(171)))));
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(337, 14);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(96, 52);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Search";
            this.btnSearch.Type = AntdUI.TTypeMini.Primary;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(131, 22);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(179, 22);
            this.txtSearch.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(35, 21);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 23);
            this.label8.TabIndex = 9;
            this.label8.Text = "CourseName :";
            // 
            // frmKhoaHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 542);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvKhoaHoc);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmKhoaHoc";
            this.Text = "frmKhoaHoc";
            this.Load += new System.EventHandler(this.frmKhoaHoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoaHoc)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.Label label1;
        private System.Windows.Forms.DataGridView dgvKhoaHoc;
        private System.Windows.Forms.GroupBox groupBox1;
        private AntdUI.Label label6;
        private AntdUI.Label label5;
        private AntdUI.Label label4;
        private AntdUI.Label label3;
        private AntdUI.Label label2;
        private System.Windows.Forms.TextBox txtCourseCode;
        private System.Windows.Forms.TextBox txtFee;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtCourseName;
        private AntdUI.Button btnCancel;
        private AntdUI.Button btnSave;
        private AntdUI.Button btnDelete;
        private AntdUI.Button btnModify;
        private AntdUI.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox2;
        private AntdUI.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private AntdUI.Label label8;
    }
}