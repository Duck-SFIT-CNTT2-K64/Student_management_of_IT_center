using Student_manager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Student_manager.DAL
{
    public class StudentDAO
    {
        // 🟢 Lấy tất cả sinh viên (kèm trạng thái)
        public IEnumerable<Student> GetAll()
        {
            var list = new List<Student>();
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
            SELECT s.StudentId, s.UserId, s.StatusId, s.StudentCode, s.FullName,
                   s.DateOfBirth, s.Gender, s.Address, s.PhoneNumber, s.Email,
                   ss.StatusName
            FROM Students s
            LEFT JOIN StudentStatuses ss ON s.StatusId = ss.StatusId
            ORDER BY s.StudentId";

                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new Student
                        {
                            StudentId = rdr.GetInt32(rdr.GetOrdinal("StudentId")),
                            UserId = rdr.GetInt32(rdr.GetOrdinal("UserId")),
                            StatusId = rdr.IsDBNull(rdr.GetOrdinal("StatusId")) ? (int?)null : rdr.GetInt32(rdr.GetOrdinal("StatusId")),
                            StudentCode = rdr["StudentCode"].ToString(),
                            FullName = rdr["FullName"].ToString(),
                            Gender = rdr["Gender"].ToString(),
                            DateOfBirth = rdr.IsDBNull(rdr.GetOrdinal("DateOfBirth")) ? (DateTime?)null : rdr.GetDateTime(rdr.GetOrdinal("DateOfBirth")),
                            Address = rdr["Address"].ToString(),
                            PhoneNumber = rdr["PhoneNumber"].ToString(),
                            Email = rdr["Email"].ToString(),
                            StatusName = rdr.IsDBNull(rdr.GetOrdinal("StatusName")) ? "Empty" : rdr["StatusName"].ToString()
                        });
                    }
                }
            }
            return list;
        }
        

        // 🟢 Lấy sinh viên theo ID
        public Student GetById(int studentId)
        {
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT StudentId, UserId, StatusId, StudentCode, FullName, 
                           DateOfBirth, Gender, Address, PhoneNumber, Email
                    FROM Students
                    WHERE StudentId = @id";
                cmd.Parameters.AddWithValue("@id", studentId);

                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        return new Student
                        {
                            StudentId = rdr.GetInt32(rdr.GetOrdinal("StudentId")),
                            UserId = rdr.GetInt32(rdr.GetOrdinal("UserId")),
                            StatusId = rdr.IsDBNull(rdr.GetOrdinal("StatusId")) ? (int?)null : rdr.GetInt32(rdr.GetOrdinal("StatusId")),
                            StudentCode = rdr.IsDBNull(rdr.GetOrdinal("StudentCode")) ? null : rdr.GetString(rdr.GetOrdinal("StudentCode")),
                            FullName = rdr.IsDBNull(rdr.GetOrdinal("FullName")) ? null : rdr.GetString(rdr.GetOrdinal("FullName")),
                            DateOfBirth = rdr.IsDBNull(rdr.GetOrdinal("DateOfBirth")) ? (DateTime?)null : rdr.GetDateTime(rdr.GetOrdinal("DateOfBirth")),
                            Gender = rdr.IsDBNull(rdr.GetOrdinal("Gender")) ? null : rdr.GetString(rdr.GetOrdinal("Gender")),
                            Address = rdr.IsDBNull(rdr.GetOrdinal("Address")) ? null : rdr.GetString(rdr.GetOrdinal("Address")),
                            PhoneNumber = rdr.IsDBNull(rdr.GetOrdinal("PhoneNumber")) ? null : rdr.GetString(rdr.GetOrdinal("PhoneNumber")),
                            Email = rdr.IsDBNull(rdr.GetOrdinal("Email")) ? null : rdr.GetString(rdr.GetOrdinal("Email"))
                        };
                    }
                }
            }
            return null;
        }

        // 🟡 Kiểm tra trùng mã sinh viên
        public bool ExistsStudentCode(string studentCode, int? excludeStudentId = null)
        {
            if (string.IsNullOrWhiteSpace(studentCode)) return false;
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                if (excludeStudentId.HasValue)
                {
                    cmd.CommandText = "SELECT COUNT(1) FROM Students WHERE StudentCode = @code AND StudentId <> @id";
                    cmd.Parameters.AddWithValue("@id", excludeStudentId.Value);
                }
                else
                {
                    cmd.CommandText = "SELECT COUNT(1) FROM Students WHERE StudentCode = @code";
                }
                cmd.Parameters.AddWithValue("@code", studentCode);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        // 🟡 Kiểm tra trùng Email
        public bool ExistsEmail(string email, int? excludeStudentId = null)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                if (excludeStudentId.HasValue)
                {
                    cmd.CommandText = "SELECT COUNT(1) FROM Students WHERE Email = @e AND StudentId <> @id";
                    cmd.Parameters.AddWithValue("@id", excludeStudentId.Value);
                }
                else
                {
                    cmd.CommandText = "SELECT COUNT(1) FROM Students WHERE Email = @e";
                }
                cmd.Parameters.AddWithValue("@e", email);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        // 🟡 Kiểm tra UserId đã gán cho sinh viên khác chưa (1-1 với Users)
        public bool ExistsUserId(int userId, int? excludeStudentId = null)
        {
            if (userId <= 0) return false;
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                if (excludeStudentId.HasValue)
                {
                    cmd.CommandText = "SELECT COUNT(1) FROM Students WHERE UserId = @uid AND StudentId <> @id";
                    cmd.Parameters.AddWithValue("@id", excludeStudentId.Value);
                }
                else
                {
                    cmd.CommandText = "SELECT COUNT(1) FROM Students WHERE UserId = @uid";
                }
                cmd.Parameters.AddWithValue("@uid", userId);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        // 🟢 Thêm mới sinh viên
        public int Insert(Student s)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));
            if (s.UserId <= 0) throw new ArgumentException("UserId required", nameof(s.UserId));

            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    INSERT INTO Students (UserId, StatusId, StudentCode, FullName, DateOfBirth, Gender, Address, PhoneNumber, Email)
                    VALUES (@UserId, @StatusId, @StudentCode, @FullName, @DateOfBirth, @Gender, @Address, @PhoneNumber, @Email);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                cmd.Parameters.AddWithValue("@UserId", s.UserId);
                cmd.Parameters.AddWithValue("@StatusId", (object)s.StatusId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@StudentCode", s.StudentCode ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@FullName", s.FullName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DateOfBirth", (object)s.DateOfBirth ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Gender", s.Gender ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Address", s.Address ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@PhoneNumber", s.PhoneNumber ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", s.Email ?? (object)DBNull.Value);

                conn.Open();
                var id = cmd.ExecuteScalar();
                return (id == null || id == DBNull.Value) ? -1 : Convert.ToInt32(id);
            }
        }

        // 🟢 Cập nhật sinh viên
        public bool Update(Student s)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));
            if (s.StudentId <= 0) throw new ArgumentException("Invalid StudentId", nameof(s.StudentId));

            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    UPDATE Students
                    SET UserId = @UserId,
                        StatusId = @StatusId,
                        StudentCode = @StudentCode,
                        FullName = @FullName,
                        DateOfBirth = @DateOfBirth,
                        Gender = @Gender,
                        Address = @Address,
                        PhoneNumber = @PhoneNumber,
                        Email = @Email
                    WHERE StudentId = @StudentId";

                cmd.Parameters.AddWithValue("@UserId", s.UserId);
                cmd.Parameters.AddWithValue("@StatusId", (object)s.StatusId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@StudentCode", s.StudentCode ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@FullName", s.FullName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DateOfBirth", (object)s.DateOfBirth ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Gender", s.Gender ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Address", s.Address ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@PhoneNumber", s.PhoneNumber ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", s.Email ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@StudentId", s.StudentId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 🟢 Xóa sinh viên
        public bool Delete(int studentId)
        {
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Students WHERE StudentId = @id";
                cmd.Parameters.AddWithValue("@id", studentId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        // Tìm kiếm
        public IEnumerable<Student> Search(string keyword)
        {
            var list = new List<Student>();
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
            SELECT s.StudentId, s.UserId, s.StudentCode, s.FullName, s.DateOfBirth, 
                   s.Gender, s.Address, s.PhoneNumber, s.Email, ss.StatusName
            FROM Students s
            LEFT JOIN StudentStatuses ss ON s.StatusId = ss.StatusId
            WHERE s.FullName LIKE @kw OR s.StudentCode LIKE @kw OR s.Email LIKE @kw
            ORDER BY s.StudentId";
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new Student
                        {
                            StudentId = rdr.GetInt32(rdr.GetOrdinal("StudentId")),
                            UserId = rdr.GetInt32(rdr.GetOrdinal("UserId")),
                            StudentCode = rdr["StudentCode"] as string,
                            FullName = rdr["FullName"] as string,
                            DateOfBirth = rdr["DateOfBirth"] as DateTime?,
                            Gender = rdr["Gender"] as string,
                            Address = rdr["Address"] as string,
                            PhoneNumber = rdr["PhoneNumber"] as string,
                            Email = rdr["Email"] as string,
                        });
                    }
                }
            }
            return list;
        }
    }
}
