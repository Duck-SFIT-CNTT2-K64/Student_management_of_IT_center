using Student_manager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Student_manager.DAL
{
    public class CourseDAO
    {
        // Map a data reader to Course
        private Course MapReaderToCourse(SqlDataReader rdr)
        {
            return new Course
            {
                CourseId = rdr.GetInt32(rdr.GetOrdinal("CourseId")),
                CourseCode = rdr.IsDBNull(rdr.GetOrdinal("CourseCode")) ? null : rdr.GetString(rdr.GetOrdinal("CourseCode")),
                CourseName = rdr.IsDBNull(rdr.GetOrdinal("CourseName")) ? null : rdr.GetString(rdr.GetOrdinal("CourseName")),
                Description = rdr.IsDBNull(rdr.GetOrdinal("Description")) ? null : rdr.GetString(rdr.GetOrdinal("Description")),
                Duration = rdr.IsDBNull(rdr.GetOrdinal("Duration")) ? null : rdr.GetString(rdr.GetOrdinal("Duration")),
                TuitionFee = rdr.IsDBNull(rdr.GetOrdinal("TuitionFee")) ? 0 : rdr.GetDecimal(rdr.GetOrdinal("TuitionFee")),
                Credits = rdr.GetOrdinal("Credits") >= 0 && !rdr.IsDBNull(rdr.GetOrdinal("Credits")) ? (int?)rdr.GetInt32(rdr.GetOrdinal("Credits")) : null
            };
        }

        // Compatibility wrapper expected by BLL
        public Course GetCourseById(int courseId)
        {
            return GetById(courseId);
        }

        public Course GetById(int courseId)
        {
            if (courseId <= 0) return null;
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT CourseId, CourseCode, CourseName, Description, Duration, TuitionFee, 
                           CASE WHEN COL_LENGTH('Courses','Credits') IS NOT NULL THEN Credits ELSE NULL END AS Credits
                    FROM Courses
                    WHERE CourseId = @id";
                cmd.Parameters.AddWithValue("@id", courseId);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read()) return MapReaderToCourse(rdr);
                }
            }
            return null;
        }

        public List<Course> GetAll()
        {
            var list = new List<Course>();
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT CourseId, CourseCode, CourseName, Description, Duration, TuitionFee,
                           CASE WHEN COL_LENGTH('Courses','Credits') IS NOT NULL THEN Credits ELSE NULL END AS Credits
                    FROM Courses
                    ORDER BY CourseId";
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(MapReaderToCourse(rdr));
                    }
                }
            }
            return list;
        }

        public bool Add(Course course)
        {
            if (course == null) throw new ArgumentNullException(nameof(course));
            const string sql = @"
                INSERT INTO Courses (CourseCode, CourseName, Description, Duration, TuitionFee, Credits)
                VALUES (@CourseCode, @CourseName, @Description, @Duration, @TuitionFee, @Credits)";
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@CourseCode", (object)course.CourseCode ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CourseName", (object)course.CourseName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Description", (object)course.Description ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Duration", (object)course.Duration ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TuitionFee", course.TuitionFee);
                cmd.Parameters.AddWithValue("@Credits", (object)course.Credits ?? DBNull.Value);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(Course course)
        {
            if (course == null) throw new ArgumentNullException(nameof(course));
            if (course.CourseId <= 0) throw new ArgumentException(nameof(course.CourseId));
            const string sql = @"
                UPDATE Courses
                SET CourseCode = @CourseCode,
                    CourseName = @CourseName,
                    Description = @Description,
                    Duration = @Duration,
                    TuitionFee = @TuitionFee,
                    Credits = @Credits
                WHERE CourseId = @CourseId";
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@CourseCode", (object)course.CourseCode ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CourseName", (object)course.CourseName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Description", (object)course.Description ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Duration", (object)course.Duration ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TuitionFee", course.TuitionFee);
                cmd.Parameters.AddWithValue("@Credits", (object)course.Credits ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CourseId", course.CourseId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int courseId)
        {
            if (courseId <= 0) return false;
            const string sql = "DELETE FROM Courses WHERE CourseId = @id";
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", courseId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<Course> SearchByName(string courseName)
        {
            var result = new List<Course>();
            const string sql = @"
                SELECT CourseId, CourseCode, CourseName, Description, Duration, TuitionFee,
                       CASE WHEN COL_LENGTH('Courses','Credits') IS NOT NULL THEN Credits ELSE NULL END AS Credits
                FROM Courses
                WHERE CourseName LIKE @q
                ORDER BY CourseName";
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@q", "%" + (courseName ?? string.Empty) + "%");
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        result.Add(MapReaderToCourse(rdr));
                    }
                }
            }
            return result;
        }

        public bool IsCourseCodeExists(string courseCode, int excludeCourseId = 0)
        {
            if (string.IsNullOrWhiteSpace(courseCode)) return false;
            string sql = excludeCourseId > 0
                ? "SELECT COUNT(1) FROM Courses WHERE CourseCode = @code AND CourseId <> @id"
                : "SELECT COUNT(1) FROM Courses WHERE CourseCode = @code";
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@code", courseCode);
                if (excludeCourseId > 0) cmd.Parameters.AddWithValue("@id", excludeCourseId);
                conn.Open();
                var res = cmd.ExecuteScalar();
                return (res != null && res != DBNull.Value) && Convert.ToInt32(res) > 0;
            }
        }
    }
}