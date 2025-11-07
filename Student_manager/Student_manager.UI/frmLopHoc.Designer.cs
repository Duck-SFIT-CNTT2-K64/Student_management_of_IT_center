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
            this.cboCourseId = new System.Windows.Forms.ComboBox();
            this.cboTeacherId = new System.Windows.Forms.ComboBox();
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
            this.gridPanel1 = new AntdUI.GridPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtCapacity = new System.Windows.Forms.TextBox();
            this.txtRoomName = new System.Windows.Forms.TextBox();
            this.txtRoomId = new System.Windows.Forms.TextBox();
            this.label10 = new AntdUI.Label();
            this.label9 = new AntdUI.Label();
            this.label7 = new AntdUI.Label();
            this.dgvRooms = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtWeekday = new System.Windows.Forms.TextBox();
            this.label12 = new AntdUI.Label();
            this.txtStartTime = new System.Windows.Forms.TextBox();
            this.txtEndTime = new System.Windows.Forms.TextBox();
            this.txtClassId = new System.Windows.Forms.TextBox();
            this.txtScheduleId = new System.Windows.Forms.TextBox();
            this.label15 = new AntdUI.Label();
            this.label14 = new AntdUI.Label();
            this.label13 = new AntdUI.Label();
            this.label11 = new AntdUI.Label();
            this.dgvSchedules = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new AntdUI.Button();
            this.btnSave = new AntdUI.Button();
            this.btnDelete = new AntdUI.Button();
            this.btnModify = new AntdUI.Button();
            this.btnAdd = new AntdUI.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasses)).BeginInit();
            this.gridPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedules)).BeginInit();
            this.groupBox5.SuspendLayout();
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
            this.label1.Size = new System.Drawing.Size(1149, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Classes Management";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.cboCourseId);
            this.groupBox1.Controls.Add(this.cboTeacherId);
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
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1149, 156);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // cboCourseId
            // 
            this.cboCourseId.FormattingEnabled = true;
            this.cboCourseId.Location = new System.Drawing.Point(507, 66);
            this.cboCourseId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboCourseId.Name = "cboCourseId";
            this.cboCourseId.Size = new System.Drawing.Size(185, 24);
            this.cboCourseId.TabIndex = 9;
            // 
            // cboTeacherId
            // 
            this.cboTeacherId.FormattingEnabled = true;
            this.cboTeacherId.Location = new System.Drawing.Point(507, 22);
            this.cboTeacherId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboTeacherId.Name = "cboTeacherId";
            this.cboTeacherId.Size = new System.Drawing.Size(185, 24);
            this.cboTeacherId.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(381, 64);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 23);
            this.label6.TabIndex = 7;
            this.label6.Text = "CourseId :";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(381, 22);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "TeacherId :";
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(129, 112);
            this.txtMax.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(100, 22);
            this.txtMax.TabIndex = 5;
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(129, 66);
            this.txtClassName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(207, 22);
            this.txtClassName.TabIndex = 4;
            // 
            // txtClassCode
            // 
            this.txtClassCode.Location = new System.Drawing.Point(129, 22);
            this.txtClassCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtClassCode.Name = "txtClassCode";
            this.txtClassCode.Size = new System.Drawing.Size(207, 22);
            this.txtClassCode.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(29, 112);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "MaxStudents :";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(29, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "ClassName :";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(29, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "ClassCode :";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Silver;
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.txtSearch);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 193);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(1149, 70);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(205)))), ((int)(((byte)(46)))));
            this.btnSearch.Location = new System.Drawing.Point(331, 14);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(104, 52);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.Type = AntdUI.TTypeMini.Primary;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(125, 22);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(179, 22);
            this.txtSearch.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(29, 21);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 23);
            this.label8.TabIndex = 6;
            this.label8.Text = "Class Name :";
            // 
            // dgvClasses
            // 
            this.dgvClasses.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvClasses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClasses.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvClasses.Location = new System.Drawing.Point(0, 263);
            this.dgvClasses.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvClasses.Name = "dgvClasses";
            this.dgvClasses.RowHeadersWidth = 51;
            this.dgvClasses.RowTemplate.Height = 24;
            this.dgvClasses.Size = new System.Drawing.Size(1149, 208);
            this.dgvClasses.TabIndex = 11;
            this.dgvClasses.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClasses_CellClick);
            // 
            // gridPanel1
            // 
            this.gridPanel1.Controls.Add(this.groupBox4);
            this.gridPanel1.Controls.Add(this.groupBox3);
            this.gridPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridPanel1.Location = new System.Drawing.Point(0, 471);
            this.gridPanel1.Name = "gridPanel1";
            this.gridPanel1.Size = new System.Drawing.Size(1149, 375);
            this.gridPanel1.Span = "50% 50%";
            this.gridPanel1.TabIndex = 12;
            this.gridPanel1.Text = "gridPanel1";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtCapacity);
            this.groupBox4.Controls.Add(this.txtRoomName);
            this.groupBox4.Controls.Add(this.txtRoomId);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.dgvRooms);
            this.groupBox4.Location = new System.Drawing.Point(577, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(568, 369);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ClassRoom";
            // 
            // txtCapacity
            // 
            this.txtCapacity.Location = new System.Drawing.Point(115, 284);
            this.txtCapacity.Name = "txtCapacity";
            this.txtCapacity.Size = new System.Drawing.Size(100, 22);
            this.txtCapacity.TabIndex = 6;
            // 
            // txtRoomName
            // 
            this.txtRoomName.Location = new System.Drawing.Point(328, 236);
            this.txtRoomName.Name = "txtRoomName";
            this.txtRoomName.Size = new System.Drawing.Size(131, 22);
            this.txtRoomName.TabIndex = 5;
            // 
            // txtRoomId
            // 
            this.txtRoomId.Location = new System.Drawing.Point(115, 236);
            this.txtRoomId.Name = "txtRoomId";
            this.txtRoomId.Size = new System.Drawing.Size(100, 22);
            this.txtRoomId.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(240, 236);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 23);
            this.label10.TabIndex = 3;
            this.label10.Text = "RoomName :";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(34, 284);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 23);
            this.label9.TabIndex = 2;
            this.label9.Text = "Capacity :";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(34, 236);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 23);
            this.label7.TabIndex = 1;
            this.label7.Text = "RoomId :";
            // 
            // dgvRooms
            // 
            this.dgvRooms.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRooms.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvRooms.Location = new System.Drawing.Point(3, 18);
            this.dgvRooms.Name = "dgvRooms";
            this.dgvRooms.RowHeadersWidth = 51;
            this.dgvRooms.RowTemplate.Height = 24;
            this.dgvRooms.Size = new System.Drawing.Size(562, 184);
            this.dgvRooms.TabIndex = 0;
            this.dgvRooms.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRooms_CellClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtWeekday);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtStartTime);
            this.groupBox3.Controls.Add(this.txtEndTime);
            this.groupBox3.Controls.Add(this.txtClassId);
            this.groupBox3.Controls.Add(this.txtScheduleId);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.dgvSchedules);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(568, 369);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ClassRoutine";
            // 
            // txtWeekday
            // 
            this.txtWeekday.Location = new System.Drawing.Point(95, 331);
            this.txtWeekday.Name = "txtWeekday";
            this.txtWeekday.Size = new System.Drawing.Size(131, 22);
            this.txtWeekday.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(14, 330);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 23);
            this.label12.TabIndex = 10;
            this.label12.Text = "Weekday :";
            // 
            // txtStartTime
            // 
            this.txtStartTime.Location = new System.Drawing.Point(307, 237);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.Size = new System.Drawing.Size(100, 22);
            this.txtStartTime.TabIndex = 9;
            // 
            // txtEndTime
            // 
            this.txtEndTime.Location = new System.Drawing.Point(307, 284);
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.Size = new System.Drawing.Size(100, 22);
            this.txtEndTime.TabIndex = 8;
            // 
            // txtClassId
            // 
            this.txtClassId.Location = new System.Drawing.Point(95, 284);
            this.txtClassId.Name = "txtClassId";
            this.txtClassId.Size = new System.Drawing.Size(100, 22);
            this.txtClassId.TabIndex = 7;
            // 
            // txtScheduleId
            // 
            this.txtScheduleId.Location = new System.Drawing.Point(95, 237);
            this.txtScheduleId.Name = "txtScheduleId";
            this.txtScheduleId.Size = new System.Drawing.Size(100, 22);
            this.txtScheduleId.TabIndex = 6;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(226, 236);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 23);
            this.label15.TabIndex = 5;
            this.label15.Text = "StartTime :";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(14, 284);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 23);
            this.label14.TabIndex = 4;
            this.label14.Text = "ClassId :";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(226, 284);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 23);
            this.label13.TabIndex = 3;
            this.label13.Text = "EndTime :";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(14, 236);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 23);
            this.label11.TabIndex = 1;
            this.label11.Text = "ScheduleId :";
            // 
            // dgvSchedules
            // 
            this.dgvSchedules.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvSchedules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedules.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvSchedules.Location = new System.Drawing.Point(3, 18);
            this.dgvSchedules.Name = "dgvSchedules";
            this.dgvSchedules.RowHeadersWidth = 51;
            this.dgvSchedules.RowTemplate.Height = 24;
            this.dgvSchedules.Size = new System.Drawing.Size(562, 184);
            this.dgvSchedules.TabIndex = 0;
            this.dgvSchedules.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSchedules_CellClick);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnCancel);
            this.groupBox5.Controls.Add(this.btnSave);
            this.groupBox5.Controls.Add(this.btnDelete);
            this.groupBox5.Controls.Add(this.btnModify);
            this.groupBox5.Controls.Add(this.btnAdd);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(0, 846);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1149, 86);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Actions";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(13)))), ((int)(((byte)(85)))));
            this.btnCancel.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(162)))), ((int)(((byte)(171)))));
            this.btnCancel.Location = new System.Drawing.Point(641, 22);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 44);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Type = AntdUI.TTypeMini.Primary;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(239)))), ((int)(((byte)(111)))));
            this.btnSave.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(162)))), ((int)(((byte)(171)))));
            this.btnSave.Location = new System.Drawing.Point(358, 22);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 43);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "Save";
            this.btnSave.Type = AntdUI.TTypeMini.Primary;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(10)))), ((int)(((byte)(26)))));
            this.btnDelete.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(162)))), ((int)(((byte)(171)))));
            this.btnDelete.Location = new System.Drawing.Point(494, 22);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(103, 43);
            this.btnDelete.TabIndex = 24;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Type = AntdUI.TTypeMini.Primary;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(211)))), ((int)(((byte)(233)))));
            this.btnModify.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(162)))), ((int)(((byte)(171)))));
            this.btnModify.Location = new System.Drawing.Point(216, 21);
            this.btnModify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(103, 44);
            this.btnModify.TabIndex = 23;
            this.btnModify.Text = "Modify";
            this.btnModify.Type = AntdUI.TTypeMini.Primary;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(235)))), ((int)(((byte)(66)))));
            this.btnAdd.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(162)))), ((int)(((byte)(171)))));
            this.btnAdd.Location = new System.Drawing.Point(74, 21);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(103, 43);
            this.btnAdd.TabIndex = 22;
            this.btnAdd.Text = "Add";
            this.btnAdd.Type = AntdUI.TTypeMini.Primary;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmLopHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 936);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.gridPanel1);
            this.Controls.Add(this.dgvClasses);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmLopHoc";
            this.Text = "frmLopHoc";
            this.Load += new System.EventHandler(this.frmLopHoc_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasses)).EndInit();
            this.gridPanel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedules)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboCourseId;
        private System.Windows.Forms.ComboBox cboTeacherId;
        private AntdUI.Label label6;
        private AntdUI.Label label5;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.TextBox txtClassCode;
        private AntdUI.Label label4;
        private AntdUI.Label label3;
        private AntdUI.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private AntdUI.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private AntdUI.Label label8;
        private System.Windows.Forms.DataGridView dgvClasses;
        private AntdUI.GridPanel gridPanel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtCapacity;
        private System.Windows.Forms.TextBox txtRoomName;
        private System.Windows.Forms.TextBox txtRoomId;
        private AntdUI.Label label10;
        private AntdUI.Label label9;
        private AntdUI.Label label7;
        private System.Windows.Forms.DataGridView dgvRooms;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtWeekday;
        private AntdUI.Label label12;
        private System.Windows.Forms.TextBox txtStartTime;
        private System.Windows.Forms.TextBox txtEndTime;
        private System.Windows.Forms.TextBox txtClassId;
        private System.Windows.Forms.TextBox txtScheduleId;
        private AntdUI.Label label15;
        private AntdUI.Label label14;
        private AntdUI.Label label13;
        private AntdUI.Label label11;
        private System.Windows.Forms.DataGridView dgvSchedules;
        private System.Windows.Forms.GroupBox groupBox5;
        private AntdUI.Button btnCancel;
        private AntdUI.Button btnSave;
        private AntdUI.Button btnDelete;
        private AntdUI.Button btnModify;
        private AntdUI.Button btnAdd;
    }
}