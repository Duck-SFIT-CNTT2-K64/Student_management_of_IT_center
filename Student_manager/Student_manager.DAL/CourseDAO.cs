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
            // Nếu muốn an toàn hơn, có thể chuyển sang SqlHelper và parameter; hiện giữ DocBang với escape
            string searchNameEscaped = courseName?.Replace("'", "''") ?? "";
            string sql = $"SELECT * FROM Courses WHERE CourseName LIKE N'%{searchNameEscaped}%'";
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
            }
        }
    }
}
