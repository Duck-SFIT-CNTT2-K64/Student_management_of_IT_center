using Student_manager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_manager.DAL
{
    public class CourseDAO
    {
        private readonly DataProcesser _dataProcessor = new DataProcesser();

        private Course MapDataRowToCourse(DataRow row)
        {
            return new Course
            {
                CourseId = (int)row["CourseId"],
                CourseCode = row["CourseCode"].ToString(),
                CourseName = row["CourseName"].ToString(),
                Description = row.IsNull("Description") ? null : row["Description"].ToString(),
                Duration = row.IsNull("Duration") ? null : row["Duration"].ToString(),
                TuitionFee = (decimal)row["TuitionFee"]
            };
        }
        public Course GetById(int courseId)
        {
            if (courseId <= 0) return null;
            string sql = "SELECT * FROM Courses WHERE CourseId = @CourseId";
            try
            {
                using (SqlConnection conn = new SqlConnection(_dataProcessor.ConnectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseId", courseId);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        if (dt.Rows.Count == 0) return null;
                        return MapDataRowToCourse(dt.Rows[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi DAL khi GetById: " + ex.Message);
                return null;
            }
        }
        /// <summary>
        /// Lấy toàn bộ danh sách khóa học từ CSDL.
        /// (Vẫn sử dụng DataProcesser.DocBang để giữ tương thích)
        /// </summary>
        public List<Course> GetAll()
        {
            List<Course> courses = new List<Course>();
            string sql = "SELECT * FROM Courses";

            try
            {
                DataTable dt = _dataProcessor.DocBang(sql);

                foreach (DataRow row in dt.Rows)
                {
                    courses.Add(MapDataRowToCourse(row));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi DAL khi đọc danh sách: " + ex.Message);
            }
            return courses;
        }

        /// <summary>
        /// Thêm một khóa học mới.
        /// Dùng SqlHelper + SqlCommand để tránh SQL injection.
        /// </summary>
        public bool Add(Course course)
        {
            const string sql = @"INSERT INTO Courses (CourseCode, CourseName, Description, Duration, TuitionFee)
                                 VALUES (@CourseCode, @CourseName, @Description, @Duration, @TuitionFee)";

            try
            {
                using (var conn = SqlHelper.GetConnection())
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseCode", (object)course.CourseCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CourseName", (object)course.CourseName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Description", (object)course.Description ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Duration", (object)course.Duration ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TuitionFee", course.TuitionFee);

                    conn.Open();
                    int affected = cmd.ExecuteNonQuery();
                    return affected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi DAL khi thêm: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Cập nhật thông tin khóa học hiện có.
        /// Dùng SqlHelper + SqlCommand để tránh SQL injection.
        /// </summary>
        public bool Update(Course course)
        {
            const string sql = @"UPDATE Courses SET
                                    CourseCode = @CourseCode,
                                    CourseName = @CourseName,
                                    Description = @Description,
                                    Duration = @Duration,
                                    TuitionFee = @TuitionFee
                                 WHERE CourseId = @CourseId";

            try
            {
                using (var conn = SqlHelper.GetConnection())
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseCode", (object)course.CourseCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CourseName", (object)course.CourseName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Description", (object)course.Description ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Duration", (object)course.Duration ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TuitionFee", course.TuitionFee);
                    cmd.Parameters.AddWithValue("@CourseId", course.CourseId);

                    conn.Open();
                    int affected = cmd.ExecuteNonQuery();
                    return affected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi DAL khi cập nhật: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Xóa một khóa học dựa trên CourseId.
        /// Dùng SqlHelper + SqlCommand.
        /// </summary>
        public bool Delete(int courseId)
        {
            const string sql = "DELETE FROM Courses WHERE CourseId = @CourseId";

            try
            {
                using (var conn = SqlHelper.GetConnection())
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseId", courseId);
                    conn.Open();
                    int affected = cmd.ExecuteNonQuery();
                    return affected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi DAL khi xóa: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Tìm kiếm khóa học theo tên (dùng DocBang để trả về DataTable rồi Map).
        /// </summary>
        public List<Course> SearchByName(string courseName)
        {
            List<Course> courses = new List<Course>();
            const string sql = "SELECT * FROM Courses WHERE CourseName LIKE N'%' + @CourseName + '%'";
            try
            {
                using (var conn = SqlHelper.GetConnection())
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseName", courseName ?? string.Empty);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Assuming MapDataRowToCourse can be adapted to accept a SqlDataReader
                            // If not, map manually here
                            Course course = new Course
                            {
                                CourseId = reader["CourseId"] != DBNull.Value ? Convert.ToInt32(reader["CourseId"]) : 0,
                                CourseCode = reader["CourseCode"]?.ToString(),
                                CourseName = reader["CourseName"]?.ToString(),
                                Credits = reader["Credits"] != DBNull.Value ? Convert.ToInt32(reader["Credits"]) : 0,
                                Description = reader["Description"]?.ToString()
                            };
                            courses.Add(course);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi DAL khi tìm kiếm: " + ex.Message);
            }
            return courses;
        }

        /// <summary>
        /// Kiểm tra CourseCode đã tồn tại hay chưa.
        /// Sử dụng SqlHelper + parameterized query.
        /// excludeCourseId: nếu >0 sẽ loại trừ bản ghi có id đó (dùng khi update).
        /// </summary>
        public bool IsCourseCodeExists(string courseCode, int excludeCourseId = 0)
        {
            if (string.IsNullOrWhiteSpace(courseCode))
                return false;

            string sql = excludeCourseId > 0
                ? "SELECT COUNT(1) AS Cnt FROM Courses WHERE CourseCode = @CourseCode AND CourseId <> @ExcludeId"
                : "SELECT COUNT(1) AS Cnt FROM Courses WHERE CourseCode = @CourseCode";

            try
            {
                using (var conn = SqlHelper.GetConnection())
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseCode", courseCode);
                    if (excludeCourseId > 0)
                        cmd.Parameters.AddWithValue("@ExcludeId", excludeCourseId);

                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    int count = (result == null || result == DBNull.Value) ? 0 : Convert.ToInt32(result);
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi DAL khi kiểm tra mã khóa học: " + ex.Message);
                return false;
        private DataProcesser _db;
        public CourseDAO() { _db = new DataProcesser(); }

        public Course GetCourseById(int courseId)
        {
            string sql = "SELECT CourseId, TuitionFee FROM Courses WHERE CourseId = " + courseId;
            DataTable dt = _db.DocBang(sql);

            if (dt.Rows.Count > 0)
            {
                return new Course
                {
                    CourseId = (int)dt.Rows[0]["CourseId"],
                    TuitionFee = (decimal)dt.Rows[0]["TuitionFee"]
                };
            }
            return null;
        }
        public IEnumerable<Course> GetAll()
        {
            var list = new List<Course>();
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT CourseId, CourseCode, CourseName, Description, Duration, TuitionFee
                    FROM Courses
                    ORDER BY CourseId";
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new Course
                        {
                            CourseId = rdr.GetInt32(rdr.GetOrdinal("CourseId")),
                            CourseCode = rdr.IsDBNull(rdr.GetOrdinal("CourseCode")) ? null : rdr.GetString(rdr.GetOrdinal("CourseCode")),
                            CourseName = rdr.IsDBNull(rdr.GetOrdinal("CourseName")) ? null : rdr.GetString(rdr.GetOrdinal("CourseName")),
                            Description = rdr.IsDBNull(rdr.GetOrdinal("Description")) ? null : rdr.GetString(rdr.GetOrdinal("Description")),
                            Duration = rdr.IsDBNull(rdr.GetOrdinal("Duration")) ? null : rdr.GetString(rdr.GetOrdinal("Duration")),
                            TuitionFee = rdr.IsDBNull(rdr.GetOrdinal("TuitionFee")) ? 0 : rdr.GetDecimal(rdr.GetOrdinal("TuitionFee"))
                        });
                    }
                }
            }
            return list;
        }

        public Course GetById(int id)
        {
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT CourseId, CourseCode, CourseName, Description, Duration, TuitionFee
                    FROM Courses
                    WHERE CourseId = @id";
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        return new Course
                        {
                            CourseId = rdr.GetInt32(rdr.GetOrdinal("CourseId")),
                            CourseCode = rdr.IsDBNull(rdr.GetOrdinal("CourseCode")) ? null : rdr.GetString(rdr.GetOrdinal("CourseCode")),
                            CourseName = rdr.IsDBNull(rdr.GetOrdinal("CourseName")) ? null : rdr.GetString(rdr.GetOrdinal("CourseName")),
                            Description = rdr.IsDBNull(rdr.GetOrdinal("Description")) ? null : rdr.GetString(rdr.GetOrdinal("Description")),
                            Duration = rdr.IsDBNull(rdr.GetOrdinal("Duration")) ? null : rdr.GetString(rdr.GetOrdinal("Duration")),
                            TuitionFee = rdr.IsDBNull(rdr.GetOrdinal("TuitionFee")) ? 0 : rdr.GetDecimal(rdr.GetOrdinal("TuitionFee"))
                        };
                    }
                }
            }
            return null;
        }

        public int Insert(Course c)
        {
            if (c == null) throw new ArgumentNullException(nameof(c));
            if (string.IsNullOrWhiteSpace(c.CourseName))
                throw new ArgumentException("CourseName required", nameof(c.CourseName));

            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    INSERT INTO Courses (CourseCode, CourseName, Description, Duration, TuitionFee)
                    VALUES (@CourseCode, @CourseName, @Description, @Duration, @TuitionFee);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";
                cmd.Parameters.AddWithValue("@CourseCode", (object)c.CourseCode ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CourseName", (object)c.CourseName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Description", (object)c.Description ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Duration", (object)c.Duration ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TuitionFee", c.TuitionFee);
                conn.Open();
                var id = cmd.ExecuteScalar();
                return (id == null || id == DBNull.Value) ? -1 : Convert.ToInt32(id);
            }
        }

        public bool Update(Course c)
        {
            if (c == null) throw new ArgumentNullException(nameof(c));
            if (c.CourseId <= 0) throw new ArgumentException("Invalid CourseId", nameof(c.CourseId));

            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    UPDATE Courses
                    SET CourseCode = @CourseCode,
                        CourseName = @CourseName,
                        Description = @Description,
                        Duration = @Duration,
                        TuitionFee = @TuitionFee
                    WHERE CourseId = @CourseId";
                cmd.Parameters.AddWithValue("@CourseCode", (object)c.CourseCode ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CourseName", (object)c.CourseName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Description", (object)c.Description ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Duration", (object)c.Duration ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TuitionFee", c.TuitionFee);
                cmd.Parameters.AddWithValue("@CourseId", c.CourseId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int id)
        {
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Courses WHERE CourseId = @id";
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool ExistsCourseCode(string code, int? excludeId = null)
        {
            if (string.IsNullOrWhiteSpace(code)) return false;
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                if (excludeId.HasValue)
                {
                    cmd.CommandText = "SELECT COUNT(1) FROM Courses WHERE CourseCode = @code AND CourseId <> @id";
                    cmd.Parameters.AddWithValue("@id", excludeId.Value);
                }
                else
                {
                    cmd.CommandText = "SELECT COUNT(1) FROM Courses WHERE CourseCode = @code";
                }
                cmd.Parameters.AddWithValue("@code", code);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
    }
}
