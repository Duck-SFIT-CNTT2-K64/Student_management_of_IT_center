using Student_manager.BLL;
using Student_manager.Models;
using Student_manager.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Student_manager.UI
{
    public partial class frmTuitions : Form
    {
        private readonly EnrollmentService _enrollmentService;
        private readonly TuitionService _tuitionService;
        private int _currentCashierId = 3;
        public frmTuitions()
        {
            InitializeComponent();
            _enrollmentService = new EnrollmentService();
            _tuitionService = new TuitionService();

            txtTotalFee.ReadOnly = true;

        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtStudentID.Clear();
            txtClassID.Clear();
            LoadTuitionList();
            ClearReceiptInputs();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void frmTuitions_Load(object sender, EventArgs e)
        {
            
            
            LoadTuitionList();
            
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            string studentCode = txtStudentID.Text.Trim();
            string classCode = txtClassID.Text.Trim();

            bool success = _enrollmentService.EnrollStudent(studentCode, classCode, out string errorMessage);

            if (success)
            {
                MessageBox.Show("Student enrolled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTuitionList(); 
            }
            else
            {
                MessageBox.Show(errorMessage, "Enrollment Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAddReceipt_Click(object sender, EventArgs e)
        {
            if (dgvTuition.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a tuition record from the left list.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            var selectedRowView = (dgvTuition.SelectedRows[0].DataBoundItem as DataRowView);
            int tuitionId = (int)selectedRowView.Row["TuitionId"];
            decimal remainingAmount = (decimal)selectedRowView.Row["RemainingAmount"]; 

            
            if (remainingAmount <= 0)
            {
                MessageBox.Show("This tuition is already fully paid.", "Already Paid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            
            DateTime paymentDate = (DateTime)datePaymentDate.Value;
            string note = txtNote.Text.Trim() + " (Full payment)";

            if (paymentDate.Date > DateTime.Now.Date)
            {
                MessageBox.Show("Payment date cannot be in the future.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                datePaymentDate.Focus();
                return;
            }
            bool success = _tuitionService.CreateNewReceipt(tuitionId, remainingAmount, paymentDate, note, _currentCashierId, out string errorMessage);

            if (success)
            {
                MessageBox.Show($"Successfully paid the remaining amount: {remainingAmount:N0} VND", "Payment Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                LoadTuitionList();
                LoadReceiptList(tuitionId);
                ClearReceiptInputs();
            }
            else
            {
                MessageBox.Show(errorMessage, "Payment Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtStudentID_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void txtClassID_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void LoadTuitionList()
        {
            string studentCode = txtStudentID.Text.Trim();
            string classCode = txtClassID.Text.Trim();

            try
            {
                dgvTuition.DataSource = _tuitionService.GetTuitionList(studentCode, classCode);
                
                if (dgvTuition.Columns["TuitionId"] != null)
                {
                    dgvTuition.Columns["TuitionId"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tuition list: " + ex.Message, "Error");
            }
        }

        private void LoadReceiptList(int tuitionId)
        {
            try
            {
                
                DataTable dtReceipts = _tuitionService.GetReceiptList(tuitionId);

                
                dgvReceipt.DataSource = dtReceipts;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading receipt list: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearReceiptInputs()
        {
            txtNote.Clear();
            
        }

        private void dgvTuition_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTuition.SelectedRows.Count > 0)
            {
                var selectedRowView = (dgvTuition.SelectedRows[0].DataBoundItem as DataRowView);
                if (selectedRowView == null) return;

                DataRow selectedRow = selectedRowView.Row;

                int tuitionId = (int)selectedRow["TuitionId"];
                decimal totalFee = (decimal)selectedRow["TotalFee"];
                string studentCode = (string)selectedRow["StudentCode"];
                string classCode = (string)selectedRow["ClassCode"];

                
                LoadReceiptList(tuitionId);

                
                txtTotalFee.Text = totalFee.ToString("N0") + " VND";

                txtStudentID.Text = studentCode;
                txtClassID.Text = classCode;
            }
            else
            {
                dgvReceipt.DataSource = null;
                txtTotalFee.Clear();
            }
        }
       
        private void datePaymentDate_ValueChanged(object sender, EventArgs e)
        {
         
        }
    }
}