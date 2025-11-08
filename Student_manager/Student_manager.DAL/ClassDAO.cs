using Student_manager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Student_manager.DAL
{
    public class ClassDAO
    {
        // 🔹 Lấy toàn bộ danh sách lớp
        public IEnumerable<Class> GetAll()
        {
            var list = new List<Class>();
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT ClassId, CourseId, TeacherId, ClassCode, ClassName, MaxStudents
                    FROM Classes
                    ORDER BY ClassId";
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new Class
                        {
                            ClassId = rdr.GetInt32(rdr.GetOrdinal("ClassId")),
                            CourseId = rdr.GetInt32(rdr.GetOrdinal("CourseId")),
                            TeacherId = rdr.IsDBNull(rdr.GetOrdinal("TeacherId")) ? (int?)null : rdr.GetInt32(rdr.GetOrdinal("TeacherId")),
                            ClassCode = rdr.IsDBNull(rdr.GetOrdinal("ClassCode")) ? null : rdr.GetString(rdr.GetOrdinal("ClassCode")),
                            ClassName = rdr.IsDBNull(rdr.GetOrdinal("ClassName")) ? null : rdr.GetString(rdr.GetOrdinal("ClassName")),
                            MaxStudents = rdr.IsDBNull(rdr.GetOrdinal("MaxStudents")) ? (int?)null : rdr.GetInt32(rdr.GetOrdinal("MaxStudents"))
                        });
                    }
                }
            }
            return list;
        }

        // 🔹 Lấy danh sách lớp theo CourseId
        public IEnumerable<Class> GetByCourseId(int courseId)
        {
            var list = new List<Class>();
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT ClassId, CourseId, TeacherId, ClassCode, ClassName, MaxStudents
                    FROM Classes
                    WHERE CourseId = @courseId
                    ORDER BY ClassName";
                cmd.Parameters.AddWithValue("@courseId", courseId);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new Class
                        {
                            ClassId = rdr.GetInt32(rdr.GetOrdinal("ClassId")),
                            CourseId = rdr.GetInt32(rdr.GetOrdinal("CourseId")),
                            TeacherId = rdr.IsDBNull(rdr.GetOrdinal("TeacherId")) ? (int?)null : rdr.GetInt32(rdr.GetOrdinal("TeacherId")),
                            ClassCode = rdr.IsDBNull(rdr.GetOrdinal("ClassCode")) ? null : rdr.GetString(rdr.GetOrdinal("ClassCode")),
                            ClassName = rdr.IsDBNull(rdr.GetOrdinal("ClassName")) ? null : rdr.GetString(rdr.GetOrdinal("ClassName")),
                            MaxStudents = rdr.IsDBNull(rdr.GetOrdinal("MaxStudents")) ? (int?)null : rdr.GetInt32(rdr.GetOrdinal("MaxStudents"))
                        });
                    }
                }
            }
            return list;
        }

        // 🔹 Lấy thông tin lớp theo ID
        public Class GetById(int classId)
        {
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT ClassId, CourseId, TeacherId, ClassCode, ClassName, MaxStudents
                    FROM Classes
                    WHERE ClassId = @id";
                cmd.Parameters.AddWithValue("@id", classId);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        return new Class
                        {
                            ClassId = rdr.GetInt32(rdr.GetOrdinal("ClassId")),
                            CourseId = rdr.GetInt32(rdr.GetOrdinal("CourseId")),
                            TeacherId = rdr.IsDBNull(rdr.GetOrdinal("TeacherId")) ? (int?)null : rdr.GetInt32(rdr.GetOrdinal("TeacherId")),
                            ClassCode = rdr.IsDBNull(rdr.GetOrdinal("ClassCode")) ? null : rdr.GetString(rdr.GetOrdinal("ClassCode")),
                            ClassName = rdr.IsDBNull(rdr.GetOrdinal("ClassName")) ? null : rdr.GetString(rdr.GetOrdinal("ClassName")),
                            MaxStudents = rdr.IsDBNull(rdr.GetOrdinal("MaxStudents")) ? (int?)null : rdr.GetInt32(rdr.GetOrdinal("MaxStudents"))
                        };
                    }
                }
            }
            return null;
        }

        // 🔹 Thêm lớp mới
        public int Insert(Class c)
        {
            if (c == null) throw new ArgumentNullException(nameof(c));
            if (string.IsNullOrWhiteSpace(c.ClassName))
                throw new ArgumentException("ClassName required", nameof(c.ClassName));

            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    INSERT INTO Classes (CourseId, TeacherId, ClassCode, ClassName, MaxStudents)
                    VALUES (@CourseId, @TeacherId, @ClassCode, @ClassName, @MaxStudents);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";
                cmd.Parameters.AddWithValue("@CourseId", c.CourseId);
                cmd.Parameters.AddWithValue("@TeacherId", (object)c.TeacherId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ClassCode", (object)c.ClassCode ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ClassName", (object)c.ClassName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MaxStudents", (object)c.MaxStudents ?? DBNull.Value);

                conn.Open();
                var id = cmd.ExecuteScalar();
                return (id == null || id == DBNull.Value) ? -1 : Convert.ToInt32(id);
            }
        }

        // 🔹 Cập nhật thông tin lớp
        public bool Update(Class c)
        {
            if (c == null) throw new ArgumentNullException(nameof(c));
            if (c.ClassId <= 0) throw new ArgumentException("Invalid ClassId", nameof(c.ClassId));

            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    UPDATE Classes
                    SET CourseId = @CourseId,
                        TeacherId = @TeacherId,
                        ClassCode = @ClassCode,
                        ClassName = @ClassName,
                        MaxStudents = @MaxStudents
                    WHERE ClassId = @ClassId";
                cmd.Parameters.AddWithValue("@CourseId", c.CourseId);
                cmd.Parameters.AddWithValue("@TeacherId", (object)c.TeacherId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ClassCode", (object)c.ClassCode ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ClassName", (object)c.ClassName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MaxStudents", (object)c.MaxStudents ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ClassId", c.ClassId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 🔹 Xóa lớp
        public bool Delete(int classId)
        {
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Classes WHERE ClassId = @id";
                cmd.Parameters.AddWithValue("@id", classId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        

        public bool ExistsClassCode(string code, int? excludeId = null)
        {
            if (string.IsNullOrWhiteSpace(code)) return false;
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                if (excludeId.HasValue)
                {
                    cmd.CommandText = "SELECT COUNT(1) FROM Classes WHERE ClassCode = @code AND ClassId <> @id";
                    cmd.Parameters.AddWithValue("@id", excludeId.Value);
                }
                else
                {
                    cmd.CommandText = "SELECT COUNT(1) FROM Classes WHERE ClassCode = @code";
                }
                cmd.Parameters.AddWithValue("@code", code);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
    }
}
