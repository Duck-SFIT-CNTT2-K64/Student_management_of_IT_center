using Student_manager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Student_manager.DAL
{
    public class LecturesDAO
    {
        private Teacher MapReaderToTeacher(SqlDataReader r)
        {
            return new Teacher
            {
                TeacherId = r.GetInt32(r.GetOrdinal("TeacherId")),
                UserId = r.IsDBNull(r.GetOrdinal("UserId")) ? 0 : r.GetInt32(r.GetOrdinal("UserId")),
                TeacherCode = r.IsDBNull(r.GetOrdinal("TeacherCode")) ? null : r.GetString(r.GetOrdinal("TeacherCode")),
                FirstName = r.IsDBNull(r.GetOrdinal("FirstName")) ? null : r.GetString(r.GetOrdinal("FirstName")),
                LastName = r.IsDBNull(r.GetOrdinal("LastName")) ? null : r.GetString(r.GetOrdinal("LastName")),
                Specialization = r.GetOrdinal("Specialization") >= 0 && !r.IsDBNull(r.GetOrdinal("Specialization")) ? r.GetString(r.GetOrdinal("Specialization")) : null,
                PhoneNumber = r.GetOrdinal("PhoneNumber") >= 0 && !r.IsDBNull(r.GetOrdinal("PhoneNumber")) ? r.GetString(r.GetOrdinal("PhoneNumber")) : null,
                Email = r.IsDBNull(r.GetOrdinal("Email")) ? null : r.GetString(r.GetOrdinal("Email"))
            };
        }

        public List<Teacher> GetAll()
        {
            var list = new List<Teacher>();
            const string sql = @"SELECT TeacherId, UserId, TeacherCode, FirstName, LastName, Specialization, PhoneNumber, Email FROM Teachers";
            try
            {
                using (var conn = SqlHelper.GetConnection())
                using (var cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            list.Add(MapReaderToTeacher(rdr));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi DAL GetAll Lecturers: " + ex.Message);
            }
            return list;
        }

        public Teacher GetById(int teacherId)
        {
            if (teacherId <= 0) return null;
            const string sql = @"SELECT TeacherId, UserId, TeacherCode, FirstName, LastName, Specialization, PhoneNumber, Email
                                 FROM Teachers WHERE TeacherId = @TeacherId";
            try
            {
                using (var conn = SqlHelper.GetConnection())
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TeacherId", teacherId);
                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read()) return MapReaderToTeacher(rdr);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi DAL GetById Lecturer: " + ex.Message);
            }
            return null;
        }

        public bool Add(Teacher teacher)
        {
            if (teacher == null) return false;

            try
            {
                using (var conn = SqlHelper.GetConnection())
                {
                    conn.Open();

                    int userId = 0;

                    // 1️⃣ Kiểm tra xem User đã tồn tại chưa
                    const string checkUserSql = "SELECT UserId FROM Users WHERE Email = @Email";
                    using (var checkCmd = new SqlCommand(checkUserSql, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Email", teacher.Email);
                        var result = checkCmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            userId = Convert.ToInt32(result);
                        }
                    }

                    // 2️⃣ Nếu chưa có User thì tạo mới
                    if (userId == 0)
                    {
                        const string insertUserSql = @"
                            INSERT INTO Users (RoleId, Username, PasswordHash, FullName, Email, Status)
                            OUTPUT INSERTED.UserId
                            VALUES (2, @Username, @PasswordHash, @FullName, @Email, 1)";
                        using (var insertCmd = new SqlCommand(insertUserSql, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@Username", teacher.Email);
                            insertCmd.Parameters.AddWithValue("@PasswordHash", "default123"); // Có thể mã hóa MD5/SHA
                            insertCmd.Parameters.AddWithValue("@FullName", teacher.FirstName + " " + teacher.LastName);
                            insertCmd.Parameters.AddWithValue("@Email", teacher.Email);
                            userId = Convert.ToInt32(insertCmd.ExecuteScalar());
                        }
                    }

                    // 3️⃣ Thêm mới giảng viên
                    const string insertTeacherSql = @"
                        INSERT INTO Teachers 
                        (UserId, TeacherCode, FirstName, LastName, Specialization, PhoneNumber, Email)
                        VALUES (@UserId, @TeacherCode, @FirstName, @LastName, @Specialization, @PhoneNumber, @Email)";
                    using (var cmd = new SqlCommand(insertTeacherSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@TeacherCode", teacher.TeacherCode);
                        cmd.Parameters.AddWithValue("@FirstName", teacher.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", teacher.LastName);
                        cmd.Parameters.AddWithValue("@Specialization", (object)teacher.Specialization ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@PhoneNumber", (object)teacher.PhoneNumber ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Email", teacher.Email);

                        int affected = cmd.ExecuteNonQuery();
                        return affected > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Lỗi SQL khi thêm giảng viên: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm giảng viên: " + ex.Message);
                return false;
            }
        }

        public bool Update(Teacher teacher)
        {
            if (teacher == null || teacher.TeacherId <= 0) return false;
            const string sql = @"UPDATE Teachers SET
                                    UserId = @UserId,
                                    TeacherCode = @TeacherCode,
                                    FirstName = @FirstName,
                                    LastName = @LastName,
                                    Specialization = @Specialization,
                                    PhoneNumber = @PhoneNumber,
                                    Email = @Email
                                 WHERE TeacherId = @TeacherId";
            try
            {
                using (var conn = SqlHelper.GetConnection())
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", teacher.UserId);
                    cmd.Parameters.AddWithValue("@TeacherCode", (object)teacher.TeacherCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FirstName", (object)teacher.FirstName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@LastName", (object)teacher.LastName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Specialization", (object)teacher.Specialization ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PhoneNumber", (object)teacher.PhoneNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", (object)teacher.Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TeacherId", teacher.TeacherId);

                    conn.Open();
                    int affected = cmd.ExecuteNonQuery();
                    return affected > 0;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Lỗi DAL Update Lecturer (SqlException): " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi DAL Update Lecturer: " + ex.Message);
                return false;
            }
        }

        public bool Delete(int teacherId)
        {
            if (teacherId <= 0) return false;
            const string sql = "DELETE FROM Teachers WHERE TeacherId = @TeacherId";
            try
            {
                using (var conn = SqlHelper.GetConnection())
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TeacherId", teacherId);
                    conn.Open();
                    int affected = cmd.ExecuteNonQuery();
                    return affected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi DAL Delete Lecturer: " + ex.Message);
                return false;
            }
        }

        public List<Teacher> SearchByName(string name)
        {
            var list = new List<Teacher>();
            const string sql = @"SELECT TeacherId, UserId, TeacherCode, FirstName, LastName, Specialization, PhoneNumber, Email
                                 FROM Teachers
                                 WHERE FirstName LIKE @q OR LastName LIKE @q OR TeacherCode LIKE @q";
            try
            {
                using (var conn = SqlHelper.GetConnection())
                using (var cmd = new SqlCommand(sql, conn))
                {
                    string q = "%" + (name ?? "") + "%";
                    cmd.Parameters.AddWithValue("@q", q);
                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            list.Add(MapReaderToTeacher(rdr));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi DAL SearchByName Lecturer: " + ex.Message);
            }
            return list;
        }

        public bool IsTeacherCodeExists(string teacherCode, int excludeTeacherId = 0)
        {
            if (string.IsNullOrWhiteSpace(teacherCode)) return false;
            string sql = excludeTeacherId > 0
                ? "SELECT COUNT(1) FROM Teachers WHERE TeacherCode = @TeacherCode AND TeacherId <> @ExcludeId"
                : "SELECT COUNT(1) FROM Teachers WHERE TeacherCode = @TeacherCode";

            try
            {
                using (var conn = SqlHelper.GetConnection())
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TeacherCode", teacherCode);
                    if (excludeTeacherId > 0) cmd.Parameters.AddWithValue("@ExcludeId", excludeTeacherId);

                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    int count = (result == null || result == DBNull.Value) ? 0 : Convert.ToInt32(result);
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi DAL IsTeacherCodeExists: " + ex.Message);
                return false;
            }
        }
        public bool IsEmailExists(string email, int excludeTeacherId = 0)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string sql = excludeTeacherId > 0
                ? "SELECT COUNT(1) FROM Teachers WHERE Email = @Email AND TeacherId <> @ExcludeId"
                : "SELECT COUNT(1) FROM Teachers WHERE Email = @Email";

            try
            {
                using (var conn = SqlHelper.GetConnection())
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    if (excludeTeacherId > 0)
                        cmd.Parameters.AddWithValue("@ExcludeId", excludeTeacherId);

                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    int count = (result == null || result == DBNull.Value) ? 0 : Convert.ToInt32(result);
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi DAL IsEmailExists: " + ex.Message);
                return false;
            }
        }
    }
}
