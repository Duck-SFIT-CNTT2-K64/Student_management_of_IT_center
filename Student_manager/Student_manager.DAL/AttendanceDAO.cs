using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Student_manager.Models;

namespace Student_manager.DAL
{
    public class AttendanceDAO
    {
        // 🔹 Lấy toàn bộ danh sách điểm danh
        public IEnumerable<Attendance> GetAll()
        {
            var list = new List<Attendance>();
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT AttendanceId, EnrollmentId, SessionDate, Status
                    FROM Attendances
                    ORDER BY SessionDate DESC";
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new Attendance
                        {
                            AttendanceId = rdr.GetInt32(rdr.GetOrdinal("AttendanceId")),
                            EnrollmentId = rdr.GetInt32(rdr.GetOrdinal("EnrollmentId")),
                            SessionDate = rdr.GetDateTime(rdr.GetOrdinal("SessionDate")),
                            Status = rdr.IsDBNull(rdr.GetOrdinal("Status")) ? null : rdr.GetString(rdr.GetOrdinal("Status"))
                        });
                    }
                }
            }
            return list;
        }

        // 🔹 Lấy danh sách điểm danh theo EnrollmentId
        public IEnumerable<Attendance> GetByEnrollmentId(int enrollmentId)
        {
            var list = new List<Attendance>();
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT AttendanceId, EnrollmentId, SessionDate, Status
                    FROM Attendances
                    WHERE EnrollmentId = @eid
                    ORDER BY SessionDate DESC";
                cmd.Parameters.AddWithValue("@eid", enrollmentId);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new Attendance
                        {
                            AttendanceId = rdr.GetInt32(rdr.GetOrdinal("AttendanceId")),
                            EnrollmentId = rdr.GetInt32(rdr.GetOrdinal("EnrollmentId")),
                            SessionDate = rdr.GetDateTime(rdr.GetOrdinal("SessionDate")),
                            Status = rdr.IsDBNull(rdr.GetOrdinal("Status")) ? null : rdr.GetString(rdr.GetOrdinal("Status"))
                        });
                    }
                }
            }
            return list;
        }

        // 🔹 Lấy chi tiết theo ID
        public Attendance GetById(int attendanceId)
        {
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT AttendanceId, EnrollmentId, SessionDate, Status
                    FROM Attendances
                    WHERE AttendanceId = @id";
                cmd.Parameters.AddWithValue("@id", attendanceId);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        return new Attendance
                        {
                            AttendanceId = rdr.GetInt32(rdr.GetOrdinal("AttendanceId")),
                            EnrollmentId = rdr.GetInt32(rdr.GetOrdinal("EnrollmentId")),
                            SessionDate = rdr.GetDateTime(rdr.GetOrdinal("SessionDate")),
                            Status = rdr.IsDBNull(rdr.GetOrdinal("Status")) ? null : rdr.GetString(rdr.GetOrdinal("Status"))
                        };
                    }
                }
            }
            return null;
        }

        // 🔹 Thêm bản ghi điểm danh mới
        public int Insert(Attendance a)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));

            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    INSERT INTO Attendances (EnrollmentId, SessionDate, Status)
                    VALUES (@EnrollmentId, @SessionDate, @Status);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";
                cmd.Parameters.AddWithValue("@EnrollmentId", a.EnrollmentId);
                cmd.Parameters.AddWithValue("@SessionDate", a.SessionDate);
                cmd.Parameters.AddWithValue("@Status", (object)a.Status ?? DBNull.Value);
                conn.Open();
                var id = cmd.ExecuteScalar();
                return (id == null || id == DBNull.Value) ? -1 : Convert.ToInt32(id);
            }
        }

        // 🔹 Cập nhật điểm danh
        public bool Update(Attendance a)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));
            if (a.AttendanceId <= 0) throw new ArgumentException("Invalid AttendanceId", nameof(a.AttendanceId));

            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    UPDATE Attendances
                    SET EnrollmentId = @EnrollmentId,
                        SessionDate = @SessionDate,
                        Status = @Status
                    WHERE AttendanceId = @id";
                cmd.Parameters.AddWithValue("@EnrollmentId", a.EnrollmentId);
                cmd.Parameters.AddWithValue("@SessionDate", a.SessionDate);
                cmd.Parameters.AddWithValue("@Status", (object)a.Status ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@id", a.AttendanceId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 🔹 Xóa bản ghi điểm danh
        public bool Delete(int attendanceId)
        {
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Attendances WHERE AttendanceId = @id";
                cmd.Parameters.AddWithValue("@id", attendanceId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 🔹 Kiểm tra trùng ngày học cho cùng Enrollment
        public bool ExistsByDate(int enrollmentId, DateTime sessionDate)
        {
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT COUNT(1) FROM Attendances WHERE EnrollmentId = @eid AND SessionDate = @date";
                cmd.Parameters.AddWithValue("@eid", enrollmentId);
                cmd.Parameters.AddWithValue("@date", sessionDate.Date);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        // 🔹 Lấy EnrollmentId đầu tiên trong lớp (phục vụ demo frmStudy)
        public int GetFirstEnrollmentIdByClass(int classId)
        {
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT TOP 1 EnrollmentId FROM Enrollments WHERE ClassId = @cid ORDER BY EnrollmentId";
                cmd.Parameters.AddWithValue("@cid", classId);
                conn.Open();
                var id = cmd.ExecuteScalar();
                return (id == null || id == DBNull.Value) ? -1 : Convert.ToInt32(id);
            }
        }
        public bool UpdateAttendance(int attendanceId, DateTime sessionDate, string status)
        {
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
            UPDATE [Attendances]
            SET [SessionDate] = @date,
                [Status] = @status
            WHERE [AttendanceId] = @id";

                cmd.Parameters.AddWithValue("@date", sessionDate);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@id", attendanceId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        
        


    }
}
