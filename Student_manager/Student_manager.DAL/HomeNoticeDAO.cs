using Student_manager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Student_manager.DAL
{
    public class HomeNoticeDAO
    {
        public IEnumerable<HomeNotice> GetAll()
        {
            var results = new List<HomeNotice>();
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT NoticeId, Title, Content, CreatedAt FROM HomeNotices ORDER BY CreatedAt DESC";
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        results.Add(new HomeNotice
                        {
                            NoticeId = rdr.GetInt32(rdr.GetOrdinal("NoticeId")),
                            Title = rdr.IsDBNull(rdr.GetOrdinal("Title")) ? "" : rdr.GetString(rdr.GetOrdinal("Title")),
                            Content = rdr.IsDBNull(rdr.GetOrdinal("Content")) ? "" : rdr.GetString(rdr.GetOrdinal("Content")),
                            CreatedAt = rdr.IsDBNull(rdr.GetOrdinal("CreatedAt")) ? DateTime.MinValue : rdr.GetDateTime(rdr.GetOrdinal("CreatedAt"))
                        });
                    }
                }
            }
            return results;
        }

        public HomeNotice GetById(int id)
        {
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT NoticeId, Title, Content, CreatedAt FROM HomeNotices WHERE NoticeId = @id";
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        return new HomeNotice
                        {
                            NoticeId = rdr.GetInt32(rdr.GetOrdinal("NoticeId")),
                            Title = rdr.IsDBNull(rdr.GetOrdinal("Title")) ? "" : rdr.GetString(rdr.GetOrdinal("Title")),
                            Content = rdr.IsDBNull(rdr.GetOrdinal("Content")) ? "" : rdr.GetString(rdr.GetOrdinal("Content")),
                            CreatedAt = rdr.IsDBNull(rdr.GetOrdinal("CreatedAt")) ? DateTime.MinValue : rdr.GetDateTime(rdr.GetOrdinal("CreatedAt"))
                        };
                    }
                }
            }
            return null;
        }

        public int Insert(HomeNotice n)
        {
            if (n == null) throw new ArgumentNullException(nameof(n));
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    INSERT INTO HomeNotices (Title, Content, CreatedAt)
                    VALUES (@Title, @Content, @CreatedAt);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";
                cmd.Parameters.AddWithValue("@Title", n.Title ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Content", n.Content ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@CreatedAt", n.CreatedAt == default(DateTime) ? DateTime.Now : n.CreatedAt);
                conn.Open();
                var id = cmd.ExecuteScalar();
                return (id == null || id == DBNull.Value) ? -1 : Convert.ToInt32(id);
            }
        }

        public bool Update(HomeNotice n)
        {
            if (n == null) throw new ArgumentNullException(nameof(n));
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    UPDATE HomeNotices
                    SET Title = @Title,
                        Content = @Content
                    WHERE NoticeId = @NoticeId";
                cmd.Parameters.AddWithValue("@Title", n.Title ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Content", n.Content ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@NoticeId", n.NoticeId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int id)
        {
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM HomeNotices WHERE NoticeId = @id";
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
