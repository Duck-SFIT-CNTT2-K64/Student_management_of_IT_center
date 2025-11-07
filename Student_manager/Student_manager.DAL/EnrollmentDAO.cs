using Student_manager.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Student_manager.DAL
{
    public class EnrollmentDAO
    {
        // 🔹 Lấy toàn bộ danh sách ghi danh
        public IEnumerable<Enrollment> GetAll()
        {
            var list = new List<Enrollment>();
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT EnrollmentId, StudentId, ClassId, EnrollmentDate, Status 
                                    FROM Enrollments
                                    ORDER BY EnrollmentId";
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

        // 🔹 Lấy ghi danh theo ID
        public Enrollment GetById(int enrollmentId)
        {
            Enrollment e = null;
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT EnrollmentId, StudentId, ClassId, EnrollmentDate, Status 
                                    FROM Enrollments
                                    WHERE EnrollmentId = @id";
                cmd.Parameters.AddWithValue("@id", enrollmentId);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                        e = MapEnrollment(rdr);
                }
            }
            return e;
        }

        // 🔹 Lấy danh sách ghi danh theo lớp
        public IEnumerable<Enrollment> GetByClassId(int classId)
        {
            var list = new List<Enrollment>();
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT EnrollmentId, StudentId, ClassId, EnrollmentDate, Status 
                                    FROM Enrollments
                                    WHERE ClassId = @cid";
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

        // 🔹 Lấy danh sách ghi danh theo sinh viên
        public IEnumerable<Enrollment> GetByStudentId(int studentId)
        {
            var list = new List<Enrollment>();
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT EnrollmentId, StudentId, ClassId, EnrollmentDate, Status 
                                    FROM Enrollments
                                    WHERE StudentId = @sid";
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
                cmd.Parameters.AddWithValue("@edate", e.EnrollmentDate);
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

        // 🧩 Hàm dùng chung để map DataReader → đối tượng
        private Enrollment MapEnrollment(SqlDataReader rdr)
        {
            return new Enrollment
            {
                EnrollmentId = rdr.GetInt32(rdr.GetOrdinal("EnrollmentId")),
                StudentId = rdr.GetInt32(rdr.GetOrdinal("StudentId")),
                ClassId = rdr.GetInt32(rdr.GetOrdinal("ClassId")),
                EnrollmentDate = rdr.IsDBNull(rdr.GetOrdinal("EnrollmentDate"))
                    ? DateTime.MinValue
                    : rdr.GetDateTime(rdr.GetOrdinal("EnrollmentDate")),
                Status = rdr.IsDBNull(rdr.GetOrdinal("Status"))
                    ? null
                    : rdr.GetString(rdr.GetOrdinal("Status"))
            };
        }
    }
}
