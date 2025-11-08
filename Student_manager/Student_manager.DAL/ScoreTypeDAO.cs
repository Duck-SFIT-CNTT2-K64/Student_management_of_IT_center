using Student_manager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Student_manager.DAL
{
    public class ScoreTypeDAO
    {
        // 🔹 Lấy danh sách tất cả loại điểm
        public IEnumerable<ScoreType> GetAll()
        {
            var list = new List<ScoreType>();
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT ScoreTypeId, ScoreTypeName, Weight
                    FROM ScoreTypes
                    ORDER BY ScoreTypeId";
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new ScoreType
                        {
                            ScoreTypeId = rdr.GetInt32(rdr.GetOrdinal("ScoreTypeId")),
                            ScoreTypeName = rdr.IsDBNull(rdr.GetOrdinal("ScoreTypeName")) ? null : rdr.GetString(rdr.GetOrdinal("ScoreTypeName")),
                            Weight = rdr.IsDBNull(rdr.GetOrdinal("Weight")) ? (decimal?)null : rdr.GetDecimal(rdr.GetOrdinal("Weight"))
                        });
                    }
                }
            }
            return list;
        }

        // 🔹 Lấy thông tin loại điểm theo ID
        public ScoreType GetById(int id)
        {
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT ScoreTypeId, ScoreTypeName, Weight
                    FROM ScoreTypes
                    WHERE ScoreTypeId = @id";
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        return new ScoreType
                        {
                            ScoreTypeId = rdr.GetInt32(rdr.GetOrdinal("ScoreTypeId")),
                            ScoreTypeName = rdr.IsDBNull(rdr.GetOrdinal("ScoreTypeName")) ? null : rdr.GetString(rdr.GetOrdinal("ScoreTypeName")),
                            Weight = rdr.IsDBNull(rdr.GetOrdinal("Weight")) ? (decimal?)null : rdr.GetDecimal(rdr.GetOrdinal("Weight"))
                        };
                    }
                }
            }
            return null;
        }

        // 🔹 Thêm loại điểm mới
        public int Insert(ScoreType s)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));
            if (string.IsNullOrWhiteSpace(s.ScoreTypeName))
                throw new ArgumentException("ScoreTypeName is required", nameof(s.ScoreTypeName));

            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    INSERT INTO ScoreTypes (ScoreTypeName, Weight)
                    VALUES (@ScoreTypeName, @Weight);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";
                cmd.Parameters.AddWithValue("@ScoreTypeName", s.ScoreTypeName);
                cmd.Parameters.AddWithValue("@Weight", (object)s.Weight ?? DBNull.Value);

                conn.Open();
                var id = cmd.ExecuteScalar();
                return (id == null || id == DBNull.Value) ? -1 : Convert.ToInt32(id);
            }
        }

        // 🔹 Cập nhật loại điểm
        public bool Update(ScoreType s)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));
            if (s.ScoreTypeId <= 0) throw new ArgumentException("Invalid ScoreTypeId", nameof(s.ScoreTypeId));

            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    UPDATE ScoreTypes
                    SET ScoreTypeName = @ScoreTypeName,
                        Weight = @Weight
                    WHERE ScoreTypeId = @ScoreTypeId";
                cmd.Parameters.AddWithValue("@ScoreTypeName", (object)s.ScoreTypeName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Weight", (object)s.Weight ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ScoreTypeId", s.ScoreTypeId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 🔹 Xóa loại điểm
        public bool Delete(int id)
        {
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM ScoreTypes WHERE ScoreTypeId = @id";
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool ExistsScoreTypeName(string name, int? excludeId = null)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                if (excludeId.HasValue)
                {
                    cmd.CommandText = "SELECT COUNT(1) FROM ScoreTypes WHERE ScoreTypeName = @name AND ScoreTypeId <> @id";
                    cmd.Parameters.AddWithValue("@id", excludeId.Value);
                }
                else
                {
                    cmd.CommandText = "SELECT COUNT(1) FROM ScoreTypes WHERE ScoreTypeName = @name";
                }
                cmd.Parameters.AddWithValue("@name", name);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
    }
}
