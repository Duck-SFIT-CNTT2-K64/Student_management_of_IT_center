using Student_manager.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace Student_manager.DAL
{
    public class TuitionDAO
    {
        private DataProcesser _db;
        public TuitionDAO() { _db = new DataProcesser(); }

        public bool AddTuition(int enrollmentId, decimal totalFee, DateTime dueDate, SqlConnection conn, SqlTransaction trans)
        {
            string sql = string.Format(
                "INSERT INTO Tuitions (EnrollmentId, TotalFee, AmountPaid, DueDate, Status) " +
                "VALUES ({0}, {1}, 0, '{2}', 'Pending')",
                enrollmentId,
                totalFee,
                dueDate.ToString("yyyy-MM-dd")
            );

            using (SqlCommand cmd = new SqlCommand(sql, conn, trans))
            {
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateTuition(int tuitionId, decimal newAmountPaid, string newStatus, SqlConnection conn, SqlTransaction trans)
        {
            string sql = string.Format(
               "UPDATE Tuitions SET AmountPaid = {0}, Status = '{1}' WHERE TuitionId = {2}",
               newAmountPaid,
               newStatus.Replace("'", "''"), 
               tuitionId
           );

            using (SqlCommand cmd = new SqlCommand(sql, conn, trans))
            {
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public Tuition GetTuitionById(int tuitionId)
        {
            string sql = "SELECT * FROM Tuitions WHERE TuitionId = " + tuitionId;
            DataTable dt = _db.DocBang(sql);
            if (dt.Rows.Count > 0)
            {
                return new Tuition
                {
                    TuitionId = (int)dt.Rows[0]["TuitionId"],
                    EnrollmentId = (int)dt.Rows[0]["EnrollmentId"],
                    TotalFee = (decimal)dt.Rows[0]["TotalFee"],
                    AmountPaid = (decimal)dt.Rows[0]["AmountPaid"],
                    Status = (string)dt.Rows[0]["Status"]
                };
            }
            return null;
        }

        public DataTable SearchTuitions(string studentCode, string classCode)
        {
            string sql = @"SELECT 
                                t.TuitionId, s.StudentCode, s.FullName, c.ClassCode, 
                                t.TotalFee, t.AmountPaid, (t.TotalFee - t.AmountPaid) AS RemainingAmount, 
                                t.Status, t.DueDate
                           FROM Tuitions t
                           JOIN Enrollments e ON t.EnrollmentId = e.EnrollmentId
                           JOIN Students s ON e.StudentId = s.StudentId
                           JOIN Classes c ON e.ClassId = c.ClassId
                           WHERE 1=1";

            if (!string.IsNullOrEmpty(studentCode))
            {
                sql += " AND s.StudentCode LIKE '" + studentCode.Replace("'", "''") + "%'";
            }
            if (!string.IsNullOrEmpty(classCode))
            {
                sql += " AND c.ClassCode LIKE '" + classCode.Replace("'", "''") + "%'";
            }
            sql += " ORDER BY s.StudentCode ASC";

            return _db.DocBang(sql);
        }
    }
}
