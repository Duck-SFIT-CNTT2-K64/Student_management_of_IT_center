using Student_manager.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Student_manager.DAL
{
    public class ReportDAO
    {
        public IEnumerable<Report> GetAll()
        {
            var list = new List<Report>();
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT ReportId, Title, Description, CreatedAt FROM Reports ORDER BY ReportId";
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new Report
                        {
                            ReportId = rdr.GetInt32(rdr.GetOrdinal("ReportId")),
                            Title = rdr.IsDBNull(rdr.GetOrdinal("Title")) ? "" : rdr.GetString(rdr.GetOrdinal("Title")),
                            Description = rdr.IsDBNull(rdr.GetOrdinal("Description")) ? "" : rdr.GetString(rdr.GetOrdinal("Description")),
                            CreatedAt = rdr.IsDBNull(rdr.GetOrdinal("CreatedAt")) ? DateTime.MinValue : rdr.GetDateTime(rdr.GetOrdinal("CreatedAt"))
                        });
                    }
                }
            }
            return list;
        }

        public Report GetById(int id)
        {
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT ReportId, Title, Description, CreatedAt FROM Reports WHERE ReportId = @id";
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        return new Report
                        {
                            ReportId = rdr.GetInt32(rdr.GetOrdinal("ReportId")),
                            Title = rdr.IsDBNull(rdr.GetOrdinal("Title")) ? "" : rdr.GetString(rdr.GetOrdinal("Title")),
                            Description = rdr.IsDBNull(rdr.GetOrdinal("Description")) ? "" : rdr.GetString(rdr.GetOrdinal("Description")),
                            CreatedAt = rdr.IsDBNull(rdr.GetOrdinal("CreatedAt")) ? DateTime.MinValue : rdr.GetDateTime(rdr.GetOrdinal("CreatedAt"))
                        };
                    }
                }
            }
            return null;
        }

        public int Insert(Report r)
        {
            if (r == null) throw new ArgumentNullException(nameof(r));
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    INSERT INTO Reports (Title, Description, CreatedAt)
                    VALUES (@Title, @Description, @CreatedAt);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";
                cmd.Parameters.AddWithValue("@Title", r.Title ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Description", r.Description ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@CreatedAt", r.CreatedAt == default(DateTime) ? DateTime.Now : r.CreatedAt);
                conn.Open();
                var id = cmd.ExecuteScalar();
                return (id == null || id == DBNull.Value) ? -1 : Convert.ToInt32(id);
            }
        }

        public bool Update(Report r)
        {
            if (r == null) throw new ArgumentNullException(nameof(r));
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    UPDATE Reports
                    SET Title = @Title,
                        Description = @Description
                    WHERE ReportId = @ReportId";
                cmd.Parameters.AddWithValue("@Title", r.Title ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Description", r.Description ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ReportId", r.ReportId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int id)
        {
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Reports WHERE ReportId = @id";
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
