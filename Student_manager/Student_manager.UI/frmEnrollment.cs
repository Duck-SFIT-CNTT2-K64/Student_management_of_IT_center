using Student_manager.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_manager.UI
{
    public partial class frmEnrollment : Form
    {
        private readonly EnrollmentService _enrollmentService;
        public frmEnrollment()
        {
            InitializeComponent();
            _enrollmentService = new EnrollmentService();
        }

        private void datePicker1_ValueChanged(object sender, AntdUI.DateTimeNEventArgs e)
        {

        }

        private void datePicker1_ValueChanged_1(object sender, AntdUI.DateTimeNEventArgs e)
        {

        }

        private void frmEnrollment_Load(object sender, EventArgs e)
        { 
            LoadEnrollmentList();

            dgvEnrollment.ReadOnly = true;
            dgvEnrollment.AllowUserToAddRows = false;
            dgvEnrollment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            LoadEnrollmentList();
            txtStudentId.Clear();
            txtClassId.Clear();
            txtStudentId.Focus();
            txtClassId.Focus();
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            string studentCode = txtStudentId.Text.Trim();
            string classCode = txtClassId.Text.Trim();
            if (string.IsNullOrWhiteSpace(studentCode) || string.IsNullOrWhiteSpace(classCode))
            {
                MessageBox.Show("Student ID and Class ID must be filled.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Đưa con trỏ về ô bị trống
                if (string.IsNullOrWhiteSpace(studentCode))
                    txtStudentId.Focus();
                else
                    txtClassId.Focus();

                return; // Dừng lại
            }
            LoadEnrollmentList();
            dgvEnrollment.ReadOnly = false;
        }

        private void LoadEnrollmentList()
        {
            string studentCode = txtStudentId.Text.Trim();
            string classCode = txtClassId.Text.Trim();

            try
            {
                dgvEnrollment.DataSource = _enrollmentService.GetEnrollmentList(studentCode, classCode);

                if (dgvEnrollment.Columns["EnrollmentId"] != null)
                {
                    dgvEnrollment.Columns["EnrollmentId"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading enrollment list: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
