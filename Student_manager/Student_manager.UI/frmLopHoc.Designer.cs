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
            this.cboCourseName = new System.Windows.Forms.ComboBox();
            this.cboTeacherName = new System.Windows.Forms.ComboBox();
            this.label6 = new AntdUI.Label();
            this.label5 = new AntdUI.Label();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.txtClassCode = new System.Windows.Forms.TextBox();
            this.label4 = new AntdUI.Label();
            this.label3 = new AntdUI.Label();
            this.label2 = new AntdUI.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new AntdUI.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label8 = new AntdUI.Label();
            this.dgvClasses = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new AntdUI.Button();
            this.btnReset = new AntdUI.Button();
            this.gridPanel1 = new AntdUI.GridPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvClassRoutine = new System.Windows.Forms.DataGridView();
            this.AgvClassRoom = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasses)).BeginInit();
            this.panel1.SuspendLayout();
            this.gridPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassRoutine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AgvClassRoom)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(879, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Classes Management";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnSave);
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
            this.groupBox1.Size = new System.Drawing.Size(879, 156);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // cboCourseName
            // 
            this.cboCourseName.FormattingEnabled = true;
            this.cboCourseName.Location = new System.Drawing.Point(507, 66);
            this.cboCourseName.Name = "cboCourseName";
            this.cboCourseName.Size = new System.Drawing.Size(185, 24);
            this.cboCourseName.TabIndex = 9;
            // 
            // cboTeacherName
            // 
            this.cboTeacherName.FormattingEnabled = true;
            this.cboTeacherName.Location = new System.Drawing.Point(507, 22);
            this.cboTeacherName.Name = "cboTeacherName";
            this.cboTeacherName.Size = new System.Drawing.Size(185, 24);
            this.cboTeacherName.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(382, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 23);
            this.label6.TabIndex = 7;
            this.label6.Text = "Course Name :";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(382, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "Teacher Name :";
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(129, 112);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(100, 22);
            this.txtMax.TabIndex = 5;
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(129, 66);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(207, 22);
            this.txtClassName.TabIndex = 4;
            // 
            // txtClassCode
            // 
            this.txtClassCode.Location = new System.Drawing.Point(129, 22);
            this.txtClassCode.Name = "txtClassCode";
            this.txtClassCode.Size = new System.Drawing.Size(207, 22);
            this.txtClassCode.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(29, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "MaxStudents :";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(29, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Class Name :";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(29, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Class Code :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.txtSearch);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 193);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(879, 70);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(205)))), ((int)(((byte)(46)))));
            this.btnSearch.Location = new System.Drawing.Point(331, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(85, 39);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.Type = AntdUI.TTypeMini.Primary;
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
            this.dgvClasses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClasses.Location = new System.Drawing.Point(0, 0);
            this.dgvClasses.Name = "dgvClasses";
            this.dgvClasses.RowHeadersWidth = 51;
            this.dgvClasses.RowTemplate.Height = 24;
            this.dgvClasses.Size = new System.Drawing.Size(879, 208);
            this.dgvClasses.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvClasses);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 263);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(879, 208);
            this.panel1.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(239)))), ((int)(((byte)(14)))));
            this.btnSave.Location = new System.Drawing.Point(444, 112);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 38);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.Type = AntdUI.TTypeMini.Primary;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(30)))), ((int)(((byte)(218)))));
            this.btnReset.Location = new System.Drawing.Point(565, 112);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 38);
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "Reset";
            this.btnReset.Type = AntdUI.TTypeMini.Primary;
            // 
            // gridPanel1
            // 
            this.gridPanel1.Controls.Add(this.groupBox4);
            this.gridPanel1.Controls.Add(this.groupBox3);
            this.gridPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridPanel1.Location = new System.Drawing.Point(0, 471);
            this.gridPanel1.Name = "gridPanel1";
            this.gridPanel1.Size = new System.Drawing.Size(879, 201);
            this.gridPanel1.Span = "50% 50%";
            this.gridPanel1.TabIndex = 6;
            this.gridPanel1.Text = "gridPanel1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvClassRoutine);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(434, 195);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Class Routine";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.AgvClassRoom);
            this.groupBox4.Location = new System.Drawing.Point(443, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(434, 195);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Class Room";
            // 
            // dgvClassRoutine
            // 
            this.dgvClassRoutine.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvClassRoutine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClassRoutine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClassRoutine.Location = new System.Drawing.Point(3, 18);
            this.dgvClassRoutine.Name = "dgvClassRoutine";
            this.dgvClassRoutine.RowHeadersWidth = 51;
            this.dgvClassRoutine.RowTemplate.Height = 24;
            this.dgvClassRoutine.Size = new System.Drawing.Size(428, 174);
            this.dgvClassRoutine.TabIndex = 0;
            // 
            // AgvClassRoom
            // 
            this.AgvClassRoom.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.AgvClassRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AgvClassRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AgvClassRoom.Location = new System.Drawing.Point(3, 18);
            this.AgvClassRoom.Name = "AgvClassRoom";
            this.AgvClassRoom.RowHeadersWidth = 51;
            this.AgvClassRoom.RowTemplate.Height = 24;
            this.AgvClassRoom.Size = new System.Drawing.Size(428, 174);
            this.AgvClassRoom.TabIndex = 0;
            // 
            // frmLopHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 677);
            this.Controls.Add(this.gridPanel1);
            this.Controls.Add(this.panel1);
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
            this.panel1.ResumeLayout(false);
            this.gridPanel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassRoutine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AgvClassRoom)).EndInit();
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
        private System.Windows.Forms.Panel panel1;
        private AntdUI.Button btnReset;
        private AntdUI.Button btnSave;
        private AntdUI.GridPanel gridPanel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView AgvClassRoom;
        private System.Windows.Forms.DataGridView dgvClassRoutine;
    }
}