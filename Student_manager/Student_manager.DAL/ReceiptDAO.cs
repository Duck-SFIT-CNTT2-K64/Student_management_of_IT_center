using Student_manager.DAL;
using Student_manager.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_manager.DAL
{
    public class ReceiptDAO
    {
        private DataProcesser _db;
        public ReceiptDAO() { _db = new DataProcesser(); }

        public bool AddReceipt(int tuitionId, int cashierId, decimal amount, DateTime date, string note, SqlConnection conn, SqlTransaction trans)
        {
            string receiptCode = $"R{DateTime.Now:yyyyMMddHHmmss}";
            string safeNote = note.Replace("'", "''");

            string sql = string.Format(
                "INSERT INTO Receipts (TuitionId, CashierId, ReceiptCode, Amount, PaymentDate, Note) " +
                "VALUES ({0}, {1}, '{2}', {3}, '{4}', N'{5}')",
                tuitionId, cashierId, receiptCode, amount, date.ToString("yyyy-MM-dd HH:mm:ss"), safeNote
            );

            using (SqlCommand cmd = new SqlCommand(sql, conn, trans))
            {
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public DataTable GetReceiptsByTuition(int tuitionId)
        {
            string sql = "SELECT * FROM Receipts WHERE TuitionId = " + tuitionId + " ORDER BY PaymentDate DESC";
            return _db.DocBang(sql);
        }
    }
}


    

        

