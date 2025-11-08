using Student_manager.DAL;
using Student_manager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_manager.BLL
{
    public class TuitionService
    {
        private readonly TuitionDAO _tuitionDAO;
        private readonly ReceiptDAO _receiptDAO;

        public TuitionService()
        {
            _tuitionDAO = new TuitionDAO();
            _receiptDAO = new ReceiptDAO();
        }

       
        public DataTable GetTuitionList(string studentCode, string classCode)
        {
            return _tuitionDAO.SearchTuitions(studentCode, classCode);
        }

        
        public DataTable GetReceiptList(int tuitionId)
        {
            return _receiptDAO.GetReceiptsByTuition(tuitionId);
        }

        public bool CreateNewReceipt(int tuitionId, decimal amountToPay, DateTime paymentDate, string note, int cashierId, out string errorMessage)
        {
           
            if (amountToPay <= 0)
            {
                errorMessage = "Amount must be greater than zero.";
                return false;
            }

          
            var tuition = _tuitionDAO.GetTuitionById(tuitionId);
            if (tuition == null) { errorMessage = "Tuition record not found."; return false; }

            
            if (tuition.Status == "Paid") { errorMessage = "This tuition is already paid."; return false; }

            decimal remaining = tuition.TotalFee - tuition.AmountPaid;
            if (amountToPay > remaining)
            {
                errorMessage = "Payment amount exceeds remaining balance.";
                return false;
            }

   
            using (SqlConnection conn = SqlHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
              
                    _receiptDAO.AddReceipt(tuitionId, cashierId, amountToPay, paymentDate, note, conn, trans);

                   
                    decimal newAmountPaid = tuition.AmountPaid + amountToPay;
                    string newStatus = (newAmountPaid >= tuition.TotalFee) ? "Paid" : "Pending";
                    _tuitionDAO.UpdateTuition(tuitionId, newAmountPaid, newStatus, conn, trans);

                    trans.Commit();
                    errorMessage = string.Empty;
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    errorMessage = "Database error: " + ex.Message;
                    return false;
                }
            }
        }
    }
}

