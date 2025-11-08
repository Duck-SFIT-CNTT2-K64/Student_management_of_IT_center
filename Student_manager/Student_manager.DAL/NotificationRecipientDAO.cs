using Student_manager.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Student_manager.DAL
{
    public class NotificationRecipientDAO
    {
        public void InsertRecipients(int notificationId, IEnumerable<int> recipientIds)
        {
            using (var conn = SqlHelper.GetConnection())
            {
                conn.Open();
                foreach (var id in recipientIds)
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"
                            INSERT INTO NotificationRecipients (NotificationId, RecipientId, IsRead)
                            VALUES (@NotificationId, @RecipientId, 0)";
                        cmd.Parameters.AddWithValue("@NotificationId", notificationId);
                        cmd.Parameters.AddWithValue("@RecipientId", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public bool DeleteByNotificationId(int notificationId)
        {
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM NotificationRecipients WHERE NotificationId = @id";
                cmd.Parameters.AddWithValue("@id", notificationId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
