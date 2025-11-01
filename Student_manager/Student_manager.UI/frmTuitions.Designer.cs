namespace Student_manager.UI
{
    partial class frmTuitions
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvTuition = new System.Windows.Forms.DataGridView();
            this.dgvReceipt = new System.Windows.Forms.DataGridView();
            this.label2 = new AntdUI.Label();
            this.label3 = new AntdUI.Label();
            this.label4 = new AntdUI.Label();
            this.label5 = new AntdUI.Label();
            this.label6 = new AntdUI.Label();
            this.txtStudenId = new System.Windows.Forms.TextBox();
            this.txtClassId = new System.Windows.Forms.TextBox();
            this.txtTotalFee = new System.Windows.Forms.TextBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.btnEnroll = new AntdUI.Button();
            this.btnAddReceipt = new AntdUI.Button();
            this.btnRefresh = new AntdUI.Button();
            this.datePaymentDate = new AntdUI.DatePicker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTuition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceipt)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(990, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tuition Management";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvTuition);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 221);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tuition Fee List";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvReceipt);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(506, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(480, 221);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Receipt List";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.datePaymentDate);
            this.groupBox3.Controls.Add(this.btnRefresh);
            this.groupBox3.Controls.Add(this.btnAddReceipt);
            this.groupBox3.Controls.Add(this.btnEnroll);
            this.groupBox3.Controls.Add(this.txtNote);
            this.groupBox3.Controls.Add(this.txtTotalFee);
            this.groupBox3.Controls.Add(this.txtClassId);
            this.groupBox3.Controls.Add(this.txtStudenId);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(0, 276);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(990, 216);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Searching";
            // 
            // dgvTuition
            // 
            this.dgvTuition.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvTuition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTuition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTuition.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvTuition.Location = new System.Drawing.Point(3, 23);
            this.dgvTuition.Name = "dgvTuition";
            this.dgvTuition.RowHeadersWidth = 51;
            this.dgvTuition.RowTemplate.Height = 24;
            this.dgvTuition.Size = new System.Drawing.Size(494, 195);
            this.dgvTuition.TabIndex = 0;
            // 
            // dgvReceipt
            // 
            this.dgvReceipt.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvReceipt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReceipt.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvReceipt.Location = new System.Drawing.Point(3, 23);
            this.dgvReceipt.Name = "dgvReceipt";
            this.dgvReceipt.RowHeadersWidth = 51;
            this.dgvReceipt.RowTemplate.Height = 24;
            this.dgvReceipt.Size = new System.Drawing.Size(474, 195);
            this.dgvReceipt.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Student ID";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Class ID";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Total Fee";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(497, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 23);
            this.label5.TabIndex = 3;
            this.label5.Text = "Payment Date";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(497, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 23);
            this.label6.TabIndex = 4;
            this.label6.Text = "Note";
            // 
            // txtStudenId
            // 
            this.txtStudenId.Location = new System.Drawing.Point(127, 30);
            this.txtStudenId.Name = "txtStudenId";
            this.txtStudenId.Size = new System.Drawing.Size(231, 27);
            this.txtStudenId.TabIndex = 5;
            // 
            // txtClassId
            // 
            this.txtClassId.Location = new System.Drawing.Point(127, 76);
            this.txtClassId.Name = "txtClassId";
            this.txtClassId.Size = new System.Drawing.Size(231, 27);
            this.txtClassId.TabIndex = 6;
            // 
            // txtTotalFee
            // 
            this.txtTotalFee.Location = new System.Drawing.Point(127, 125);
            this.txtTotalFee.Name = "txtTotalFee";
            this.txtTotalFee.Size = new System.Drawing.Size(231, 27);
            this.txtTotalFee.TabIndex = 7;
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(623, 78);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(192, 69);
            this.txtNote.TabIndex = 9;
            // 
            // btnEnroll
            // 
            this.btnEnroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnEnroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnroll.Location = new System.Drawing.Point(497, 162);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Size = new System.Drawing.Size(131, 42);
            this.btnEnroll.TabIndex = 10;
            this.btnEnroll.Text = "Enroll";
            this.btnEnroll.Type = AntdUI.TTypeMini.Primary;
            // 
            // btnAddReceipt
            // 
            this.btnAddReceipt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.btnAddReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddReceipt.Location = new System.Drawing.Point(664, 162);
            this.btnAddReceipt.Name = "btnAddReceipt";
            this.btnAddReceipt.Size = new System.Drawing.Size(136, 42);
            this.btnAddReceipt.TabIndex = 11;
            this.btnAddReceipt.Text = "Add Receipt";
            this.btnAddReceipt.Type = AntdUI.TTypeMini.Primary;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(833, 162);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 42);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Type = AntdUI.TTypeMini.Primary;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // datePaymentDate
            // 
            this.datePaymentDate.Location = new System.Drawing.Point(623, 21);
            this.datePaymentDate.Name = "datePaymentDate";
            this.datePaymentDate.Size = new System.Drawing.Size(192, 41);
            this.datePaymentDate.TabIndex = 14;
            // 
            // frmTuitions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 492);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmTuitions";
            this.Text = "frmTuitions";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTuition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceipt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvTuition;
        private System.Windows.Forms.DataGridView dgvReceipt;
        private System.Windows.Forms.TextBox txtTotalFee;
        private System.Windows.Forms.TextBox txtClassId;
        private System.Windows.Forms.TextBox txtStudenId;
        private AntdUI.Label label6;
        private AntdUI.Label label5;
        private AntdUI.Label label4;
        private AntdUI.Label label3;
        private AntdUI.Label label2;
        private AntdUI.Button btnRefresh;
        private AntdUI.Button btnAddReceipt;
        private AntdUI.Button btnEnroll;
        private System.Windows.Forms.TextBox txtNote;
        private AntdUI.DatePicker datePaymentDate;
    }
}