using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_manager.DAL
{
    public class EnrollmentDAO
    {
        private DataProcesser _db = new DataProcesser();
        public int AddEnrollment(int studentId, int classId, SqlConnection conn, SqlTransaction trans)
        {
            string sql = string.Format(
                "INSERT INTO Enrollments (StudentId, ClassId, Status) VALUES ({0}, {1}, 'Enrolled');" +
                "SELECT SCOPE_IDENTITY();",
                studentId,
                classId
            );

            using (SqlCommand cmd = new SqlCommand(sql, conn, trans))
            {

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public DataTable SearchEnrollments(string studentCode, string classCode)
        {
            string sql = @"SELECT 
                                e.EnrollmentId, 
                                s.StudentCode AS StudentID, 
                                s.FullName AS StudentName, 
                                c.ClassCode AS ClassID, 
                                c.ClassName, 
                                e.EnrollmentDate, 
                                e.Status
                           FROM Enrollments e
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
