using Student_manager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Student_manager.DAL
{
    public class ScoreDAO
    {
        // 🔹 Lấy toàn bộ danh sách điểm
        public IEnumerable<Score> GetAll()
        {
            var list = new List<Score>();
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT ScoreId, EnrollmentId, ScoreTypeId, ScoreValue
                    FROM Scores
                    ORDER BY ScoreId";
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new Score
                        {
                            ScoreId = rdr.GetInt32(rdr.GetOrdinal("ScoreId")),
                            EnrollmentId = rdr.GetInt32(rdr.GetOrdinal("EnrollmentId")),
                            ScoreTypeId = rdr.GetInt32(rdr.GetOrdinal("ScoreTypeId")),
                            ScoreValue = rdr.IsDBNull(rdr.GetOrdinal("ScoreValue")) ? 0 : rdr.GetDecimal(rdr.GetOrdinal("ScoreValue"))
                        });
                    }
                }
            }
            return list;
        }

        // 🔹 Lấy điểm theo ID
        public Score GetById(int scoreId)
        {
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT ScoreId, EnrollmentId, ScoreTypeId, ScoreValue
                    FROM Scores WHERE ScoreId = @id";
                cmd.Parameters.AddWithValue("@id", scoreId);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        return new Score
                        {
                            ScoreId = rdr.GetInt32(rdr.GetOrdinal("ScoreId")),
                            EnrollmentId = rdr.GetInt32(rdr.GetOrdinal("EnrollmentId")),
                            ScoreTypeId = rdr.GetInt32(rdr.GetOrdinal("ScoreTypeId")),
                            ScoreValue = rdr.IsDBNull(rdr.GetOrdinal("ScoreValue")) ? 0 : rdr.GetDecimal(rdr.GetOrdinal("ScoreValue"))
                        };
                    }
                }
            }
            return null;
        }

        // 🔹 Lấy danh sách điểm theo EnrollmentId
        public IEnumerable<Score> GetByEnrollmentId(int enrollmentId)
        {
            var list = new List<Score>();
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT s.ScoreId, s.EnrollmentId, s.ScoreTypeId, s.ScoreValue,
                           st.ScoreTypeName, st.Weight
                    FROM Scores s
                    LEFT JOIN ScoreTypes st ON s.ScoreTypeId = st.ScoreTypeId
                    WHERE s.EnrollmentId = @enrollmentId
                    ORDER BY st.ScoreTypeName";
                cmd.Parameters.AddWithValue("@enrollmentId", enrollmentId);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new Score
                        {
                            ScoreId = rdr.GetInt32(rdr.GetOrdinal("ScoreId")),
                            EnrollmentId = rdr.GetInt32(rdr.GetOrdinal("EnrollmentId")),
                            ScoreTypeId = rdr.GetInt32(rdr.GetOrdinal("ScoreTypeId")),
                            ScoreValue = rdr.IsDBNull(rdr.GetOrdinal("ScoreValue")) ? 0 : rdr.GetDecimal(rdr.GetOrdinal("ScoreValue"))
                        });
                    }
                }
            }
            return list;
        }

        // 🔹 Kiểm tra loại điểm đã tồn tại cho EnrollmentId
        public bool ExistsScoreTypeForEnrollment(int enrollmentId, int scoreTypeId)
        {
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT COUNT(1) FROM Scores WHERE EnrollmentId = @eid AND ScoreTypeId = @tid";
                cmd.Parameters.AddWithValue("@eid", enrollmentId);
                cmd.Parameters.AddWithValue("@tid", scoreTypeId);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        // 🔹 Lấy trọng số của loại điểm
        public decimal GetScoreTypeWeight(int scoreTypeId)
        {
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT ISNULL(Weight, 1) FROM ScoreTypes WHERE ScoreTypeId = @id";
                cmd.Parameters.AddWithValue("@id", scoreTypeId);
                conn.Open();
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }

        // 🔹 Thêm điểm mới
        public int Insert(Score s)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));

            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    INSERT INTO Scores (EnrollmentId, ScoreTypeId, ScoreValue)
                    VALUES (@EnrollmentId, @ScoreTypeId, @ScoreValue);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";
                cmd.Parameters.AddWithValue("@EnrollmentId", s.EnrollmentId);
                cmd.Parameters.AddWithValue("@ScoreTypeId", s.ScoreTypeId);
                cmd.Parameters.AddWithValue("@ScoreValue", s.ScoreValue);
                conn.Open();
                var id = cmd.ExecuteScalar();
                return (id == null || id == DBNull.Value) ? -1 : Convert.ToInt32(id);
            }
        }

        // 🔹 Cập nhật điểm
        public bool Update(Score s)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));
            if (s.ScoreId <= 0) throw new ArgumentException("Invalid ScoreId", nameof(s.ScoreId));

            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    UPDATE Scores
                    SET EnrollmentId = @EnrollmentId,
                        ScoreTypeId = @ScoreTypeId,
                        ScoreValue = @ScoreValue
                    WHERE ScoreId = @ScoreId";
                cmd.Parameters.AddWithValue("@EnrollmentId", s.EnrollmentId);
                cmd.Parameters.AddWithValue("@ScoreTypeId", s.ScoreTypeId);
                cmd.Parameters.AddWithValue("@ScoreValue", s.ScoreValue);
                cmd.Parameters.AddWithValue("@ScoreId", s.ScoreId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool UpdateScoreValue(int scoreId, decimal newValue)
        {
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "UPDATE Scores SET ScoreValue = @val WHERE ScoreId = @id";
                cmd.Parameters.AddWithValue("@val", newValue);
                cmd.Parameters.AddWithValue("@id", scoreId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 🔹 Xóa điểm
        public bool Delete(int scoreId)
        {
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Scores WHERE ScoreId = @id";
                cmd.Parameters.AddWithValue("@id", scoreId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
