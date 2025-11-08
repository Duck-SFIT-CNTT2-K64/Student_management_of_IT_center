using Student_manager.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Student_manager.DAL
{
    public class NotificationDAO
    {
        public int Insert(Notification n)
        {
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    INSERT INTO Notifications (CreatorId, Title, Content, CreatedDate)
                    VALUES (@CreatorId, @Title, @Content, @CreatedDate);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                cmd.Parameters.AddWithValue("@CreatorId", n.CreatorId);
                cmd.Parameters.AddWithValue("@Title", n.Title);
                cmd.Parameters.AddWithValue("@Content", n.Content);
                cmd.Parameters.AddWithValue("@CreatedDate", n.CreatedDate);

                conn.Open();
                var id = cmd.ExecuteScalar();
                return (id == null || id == DBNull.Value) ? -1 : Convert.ToInt32(id);
            }
        }

        public bool InsertRecipient(int notificationId, int recipientId)
        {
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    INSERT INTO NotificationRecipients (NotificationId, RecipientId, IsRead)
                    VALUES (@NotificationId, @RecipientId, 0)";
                cmd.Parameters.AddWithValue("@NotificationId", notificationId);
                cmd.Parameters.AddWithValue("@RecipientId", recipientId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        //// 🗑️ Xóa một thông báo (và các người nhận)
        //public bool DeleteNotification(int notificationId)
        //{
        //    using (var conn = SqlHelper.GetConnection())
        //    using (var cmd = conn.CreateCommand())
        //    {
        //        conn.Open();
        //        var tran = conn.BeginTransaction();
        //        cmd.Transaction = tran;

        //        try
        //        {
        //            // Xóa các người nhận trước
        //            cmd.CommandText = "DELETE FROM NotificationRecipients WHERE NotificationId = @id";
        //            cmd.Parameters.AddWithValue("@id", notificationId);
        //            cmd.ExecuteNonQuery();

        //            // Xóa thông báo chính
        //            cmd.CommandText = "DELETE FROM Notifications WHERE NotificationId = @id";
        //            cmd.ExecuteNonQuery();

        //            tran.Commit();
        //            return true;
        //        }
        //        catch
        //        {
        //            tran.Rollback();
        //            throw;
        //        }
        //    }
        //}
    }
}
