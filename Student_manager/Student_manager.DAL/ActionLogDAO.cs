using Student_manager.Models;
using System;
using System.Data.SqlClient;

namespace Student_manager.DAL
{
    public class ActionLogDAO
    {
        public int Insert(ActionLog log)
        {
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    INSERT INTO ActionLogs (UserId, Action, Details, LogDate)
                    VALUES (@UserId, @Action, @Details, @LogDate);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";
                cmd.Parameters.AddWithValue("@UserId", log.UserId);
                cmd.Parameters.AddWithValue("@Action", log.Action ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Details", log.Details ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@LogDate", log.LogDate == default(DateTime) ? DateTime.Now : log.LogDate);

                conn.Open();
                var id = cmd.ExecuteScalar();
                return (id == null || id == DBNull.Value) ? -1 : Convert.ToInt32(id);
            }
        }
    }
}
