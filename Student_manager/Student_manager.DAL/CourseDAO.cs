using Student_manager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Student_manager.DAL
{
    public class CourseDAO
    {
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
