using Student_manager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Student_manager.DAL
{
    public class FeaturedTeacherDAO
    {
        public IEnumerable<FeaturedTeacher> GetActive()
        {
            var list = new List<FeaturedTeacher>();
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT FeaturedId, TeacherId, Title, Summary, ImagePath, SortOrder, IsActive, CreatedAt
                    FROM FeaturedTeachers
                    WHERE IsActive = 1
                    ORDER BY SortOrder, FeaturedId";
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        var ft = new FeaturedTeacher
                        {
                            FeaturedId = rdr.GetInt32(rdr.GetOrdinal("FeaturedId")),
                            TeacherId = rdr.IsDBNull(rdr.GetOrdinal("TeacherId")) ? (int?)null : rdr.GetInt32(rdr.GetOrdinal("TeacherId")),
                            Title = rdr.IsDBNull(rdr.GetOrdinal("Title")) ? null : rdr.GetString(rdr.GetOrdinal("Title")),
                            Summary = rdr.IsDBNull(rdr.GetOrdinal("Summary")) ? null : rdr.GetString(rdr.GetOrdinal("Summary")),
                            ImagePath = rdr.IsDBNull(rdr.GetOrdinal("ImagePath")) ? null : rdr.GetString(rdr.GetOrdinal("ImagePath")),
                            SortOrder = rdr.IsDBNull(rdr.GetOrdinal("SortOrder")) ? 0 : rdr.GetInt32(rdr.GetOrdinal("SortOrder")),
                            IsActive = !rdr.IsDBNull(rdr.GetOrdinal("IsActive")) && rdr.GetBoolean(rdr.GetOrdinal("IsActive")),
                            CreatedAt = rdr.IsDBNull(rdr.GetOrdinal("CreatedAt")) ? DateTime.MinValue : rdr.GetDateTime(rdr.GetOrdinal("CreatedAt"))
                        };
                        list.Add(ft);
                    }
                }
            }
            return list;
        }
    }
}
