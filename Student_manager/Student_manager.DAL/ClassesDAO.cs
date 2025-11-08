using Student_manager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Student_manager.DAL
{
    public class ClassesDAO
    {
        private readonly DataProcesser _dataProcessor = new DataProcesser();

        public List<Class> GetAllClasses()
        {
            var result = new List<Class>();
            string query = "SELECT * FROM Classes";

            DataTable dt = _dataProcessor.DocBang(query);
            foreach (DataRow row in dt.Rows)
            {
                result.Add(MapDataRowToClass(row));
            }

            return result;
        }

        public Class GetClassById(int classId)
        {
            string query = "SELECT * FROM Classes WHERE ClassId = @ClassId";
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ClassId", classId);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Class
                        {
                            ClassId = (int)reader["ClassId"],
                            CourseId = (int)reader["CourseId"],
                            TeacherId = reader["TeacherId"] as int?,
                            ClassCode = reader["ClassCode"].ToString(),
                            ClassName = reader["ClassName"].ToString(),
                            MaxStudents = reader["MaxStudents"] as int?
                        };
                    }
                }
            }
            return null;
        }

        public int AddClass(Class c)
        {
            // Dùng SCOPE_IDENTITY() để lấy ID vừa được chèn thành công
            string query = @"INSERT INTO Classes (CourseId, TeacherId, ClassCode, ClassName, MaxStudents)
                     VALUES (@CourseId, @TeacherId, @ClassCode, @ClassName, @MaxStudents);
                     SELECT SCOPE_IDENTITY();";

            using (var conn = SqlHelper.GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@CourseId", c.CourseId);
                cmd.Parameters.AddWithValue("@TeacherId", (object)c.TeacherId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ClassCode", c.ClassCode);
                cmd.Parameters.AddWithValue("@ClassName", c.ClassName);
                cmd.Parameters.AddWithValue("@MaxStudents", (object)c.MaxStudents ?? DBNull.Value);

                conn.Open();

                // Dùng ExecuteScalar để lấy giá trị ID vừa chèn
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    // Ép kiểu sang int và trả về ID
                    return Convert.ToInt32(result);
                }
                return 0; // Trả về 0 nếu thêm thất bại hoặc không lấy được ID
            }
        }

        public bool UpdateClass(Class c)
        {
            string query = @"UPDATE Classes 
                             SET CourseId=@CourseId, TeacherId=@TeacherId, ClassCode=@ClassCode,
                                 ClassName=@ClassName, MaxStudents=@MaxStudents
                             WHERE ClassId=@ClassId";
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@CourseId", c.CourseId);
                cmd.Parameters.AddWithValue("@TeacherId", (object)c.TeacherId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ClassCode", c.ClassCode);
                cmd.Parameters.AddWithValue("@ClassName", c.ClassName);
                cmd.Parameters.AddWithValue("@MaxStudents", (object)c.MaxStudents ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ClassId", c.ClassId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteClass(int classId)
        {
            string query = "DELETE FROM Classes WHERE ClassId=@ClassId";
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ClassId", classId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private Class MapDataRowToClass(DataRow row)
        {
            return new Class
            {
                ClassId = (int)row["ClassId"],
                CourseId = (int)row["CourseId"],
                TeacherId = row["TeacherId"] == DBNull.Value ? null : (int?)row["TeacherId"],
                ClassCode = row["ClassCode"].ToString(),
                ClassName = row["ClassName"].ToString(),
                MaxStudents = row["MaxStudents"] == DBNull.Value ? null : (int?)row["MaxStudents"]
            };
        }
        public bool ClassCodeExists(string classCode)
        {
            string query = "SELECT COUNT(*) FROM Classes WHERE ClassCode = @ClassCode";

            using (var conn = SqlHelper.GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ClassCode", classCode);
                conn.Open();

                // ExecuteScalar trả về giá trị đầu tiên của hàng đầu tiên (COUNT(*))
                object result = cmd.ExecuteScalar();

                // Nếu COUNT(*) > 0, nghĩa là mã lớp đã tồn tại
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result) > 0;
                }
                return false;
            }
        }
    }
}

