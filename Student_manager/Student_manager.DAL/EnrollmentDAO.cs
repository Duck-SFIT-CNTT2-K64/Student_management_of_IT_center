using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Student_manager.Models;

namespace Student_manager.DAL
{
    public class EnrollmentDAO
    {
        private readonly DataProcesser _db = new DataProcesser();

        // Adds enrollment within an existing connection/transaction and returns new identity (int)
        public int AddEnrollment(int studentId, int classId, SqlConnection conn, SqlTransaction trans)
        {
            const string sql = @"
                INSERT INTO Enrollments (StudentId, ClassId, Status, EnrollmentDate)
                VALUES (@studentId, @classId, @status, @enrollmentDate);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (var cmd = new SqlCommand(sql, conn, trans))
            {
                cmd.Parameters.AddWithValue("@studentId", studentId);
                cmd.Parameters.AddWithValue("@classId", classId);
                cmd.Parameters.AddWithValue("@status", "Enrolled");
                cmd.Parameters.AddWithValue("@enrollmentDate", DateTime.Now);

                var result = cmd.ExecuteScalar();
                return (result == null || result == DBNull.Value) ? -1 : Convert.ToInt32(result);
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

        // 🔹 Lấy toàn bộ danh sách ghi danh (Student populated)
        public IEnumerable<Enrollment> GetAll()
        {
            var list = new List<Enrollment>();
            const string sql = @"
                SELECT e.EnrollmentId, e.StudentId, e.ClassId, e.EnrollmentDate, e.Status,
                       s.StudentId AS S_StudentId, s.StudentCode, s.FullName, s.DateOfBirth, s.Gender, s.Address, s.PhoneNumber, s.Email
                FROM Enrollments e
                LEFT JOIN Students s ON e.StudentId = s.StudentId
                ORDER BY e.EnrollmentId";

            using (var conn = SqlHelper.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(MapEnrollment(rdr));
                    }
                }
            }
            return list;
        }

        // 🔹 Lấy ghi danh theo ID (Student populated)
        public Enrollment GetById(int enrollmentId)
        {
            const string sql = @"
                SELECT e.EnrollmentId, e.StudentId, e.ClassId, e.EnrollmentDate, e.Status,
                       s.StudentId AS S_StudentId, s.StudentCode, s.FullName, s.DateOfBirth, s.Gender, s.Address, s.PhoneNumber, s.Email
                FROM Enrollments e
                LEFT JOIN Students s ON e.StudentId = s.StudentId
                WHERE e.EnrollmentId = @id";

            using (var conn = SqlHelper.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", enrollmentId);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                        return MapEnrollment(rdr);
                }
            }
            return null;
        }

        // 🔹 Lấy danh sách ghi danh theo lớp (Student populated)
        public IEnumerable<Enrollment> GetByClassId(int classId)
        {
            var list = new List<Enrollment>();
            const string sql = @"
                SELECT e.EnrollmentId, e.StudentId, e.ClassId, e.EnrollmentDate, e.Status,
                       s.StudentId AS S_StudentId, s.StudentCode, s.FullName, s.DateOfBirth, s.Gender, s.Address, s.PhoneNumber, s.Email
                FROM Enrollments e
                LEFT JOIN Students s ON e.StudentId = s.StudentId
                WHERE e.ClassId = @cid
                ORDER BY s.FullName";

            using (var conn = SqlHelper.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@cid", classId);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                        list.Add(MapEnrollment(rdr));
                }
            }
            return list;
        }

        // 🔹 Lấy danh sách ghi danh theo sinh viên (Student populated)
        public IEnumerable<Enrollment> GetByStudentId(int studentId)
        {
            var list = new List<Enrollment>();
            const string sql = @"
                SELECT e.EnrollmentId, e.StudentId, e.ClassId, e.EnrollmentDate, e.Status,
                       s.StudentId AS S_StudentId, s.StudentCode, s.FullName, s.DateOfBirth, s.Gender, s.Address, s.PhoneNumber, s.Email
                FROM Enrollments e
                LEFT JOIN Students s ON e.StudentId = s.StudentId
                WHERE e.StudentId = @sid
                ORDER BY e.EnrollmentDate DESC";

            using (var conn = SqlHelper.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@sid", studentId);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                        list.Add(MapEnrollment(rdr));
                }
            }
            return list;
        }

        // 🔹 Thêm mới ghi danh
        public int Insert(Enrollment e)
        {
            if (e == null) throw new ArgumentNullException(nameof(e));
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    INSERT INTO Enrollments (StudentId, ClassId, EnrollmentDate, Status)
                    VALUES (@sid, @cid, @edate, @status);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";
                cmd.Parameters.AddWithValue("@sid", e.StudentId);
                cmd.Parameters.AddWithValue("@cid", e.ClassId);
                cmd.Parameters.AddWithValue("@edate", e.EnrollmentDate == default(DateTime) ? DateTime.Now : e.EnrollmentDate);
                cmd.Parameters.AddWithValue("@status", (object)e.Status ?? DBNull.Value);
                conn.Open();
                var id = cmd.ExecuteScalar();
                return (id == null || id == DBNull.Value) ? -1 : Convert.ToInt32(id);
            }
        }

        // 🔹 Cập nhật ghi danh
        public bool Update(Enrollment e)
        {
            if (e == null) throw new ArgumentNullException(nameof(e));
            if (e.EnrollmentId <= 0) throw new ArgumentException("Invalid EnrollmentId", nameof(e.EnrollmentId));

            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    UPDATE Enrollments
                    SET StudentId = @sid,
                        ClassId = @cid,
                        EnrollmentDate = @edate,
                        Status = @status
                    WHERE EnrollmentId = @id";
                cmd.Parameters.AddWithValue("@sid", e.StudentId);
                cmd.Parameters.AddWithValue("@cid", e.ClassId);
                cmd.Parameters.AddWithValue("@edate", e.EnrollmentDate ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@status", (object)e.Status ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@id", e.EnrollmentId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 🔹 Xóa ghi danh
        public bool Delete(int enrollmentId)
        {
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Enrollments WHERE EnrollmentId = @id";
                cmd.Parameters.AddWithValue("@id", enrollmentId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 🧩 Hàm dùng chung để map DataReader → đối tượng (đã bao gồm Student mapping)
        private Enrollment MapEnrollment(SqlDataReader rdr)
        {
            var enrollment = new Enrollment
            {
                EnrollmentId = rdr.GetInt32(rdr.GetOrdinal("EnrollmentId")),
                StudentId = rdr.GetInt32(rdr.GetOrdinal("StudentId")),
                ClassId = rdr.GetInt32(rdr.GetOrdinal("ClassId")),
                EnrollmentDate = rdr.IsDBNull(rdr.GetOrdinal("EnrollmentDate")) ? (DateTime?)null : rdr.GetDateTime(rdr.GetOrdinal("EnrollmentDate")),
                Status = rdr.IsDBNull(rdr.GetOrdinal("Status")) ? null : rdr.GetString(rdr.GetOrdinal("Status"))
            };

            // Map student info if present
            if (rdr.GetOrdinal("S_StudentId") >= 0 && !rdr.IsDBNull(rdr.GetOrdinal("S_StudentId")))
            {
                enrollment.Student = new Student
                {
                    StudentId = rdr.GetInt32(rdr.GetOrdinal("S_StudentId")),
                    StudentCode = rdr.IsDBNull(rdr.GetOrdinal("StudentCode")) ? null : rdr.GetString(rdr.GetOrdinal("StudentCode")),
                    FullName = rdr.IsDBNull(rdr.GetOrdinal("FullName")) ? null : rdr.GetString(rdr.GetOrdinal("FullName")),
                    DateOfBirth = rdr.IsDBNull(rdr.GetOrdinal("DateOfBirth")) ? (DateTime?)null : rdr.GetDateTime(rdr.GetOrdinal("DateOfBirth")),
                    Gender = rdr.IsDBNull(rdr.GetOrdinal("Gender")) ? null : rdr.GetString(rdr.GetOrdinal("Gender")),
                    Address = rdr.IsDBNull(rdr.GetOrdinal("Address")) ? null : rdr.GetString(rdr.GetOrdinal("Address")),
                    PhoneNumber = rdr.IsDBNull(rdr.GetOrdinal("PhoneNumber")) ? null : rdr.GetString(rdr.GetOrdinal("PhoneNumber")),
                    Email = rdr.IsDBNull(rdr.GetOrdinal("Email")) ? null : rdr.GetString(rdr.GetOrdinal("Email"))
                };
            }
            else
            {
                enrollment.Student = null;
            }

            return enrollment;
        }
    }
}
