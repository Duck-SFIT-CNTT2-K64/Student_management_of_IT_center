using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_manager.DAL
{
    public class UserRoleDAO
    {
        private DataProcesser _db;
        public UserRoleDAO() { _db = new DataProcesser(); }

        public DataTable GetUsersWithRoles()
        {
            string sql = @"SELECT u.UserId, u.Username, u.FullName, u.Email, u.PhoneNumber, u.Status, r.RoleName
                           FROM Users u
                           LEFT JOIN Roles r ON u.RoleId = r.RoleId
                           ORDER BY u.UserId";
            return _db.DocBang(sql);
        }
        public DataRow GetUserByUsername(string username)
        {
            // Use parameterized query to prevent SQL injection
            string sql = "SELECT * FROM Users WHERE Username = @username";
            using (SqlConnection conn = new SqlConnection(DataProcesser.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return (dt.Rows.Count > 0) ? dt.Rows[0] : null;
                }
            }
        }
        public bool AddUser(string username, string passwordHash, string fullName, string email,string phoneNumber, int roleId, SqlConnection conn, SqlTransaction trans)
        {
            string sql = string.Format(
                "INSERT INTO Users (RoleId, Username, PasswordHash, FullName, Email, PhoneNumber, Status) " +
                "VALUES ({0}, N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'Active')", // Mặc định là Active
                roleId,
                username.Replace("'", "''"),
                passwordHash, // Dùng hash mới
                fullName.Replace("'", "''"),
                email.Replace("'", "''"),
                phoneNumber.Replace("'", "''")
            );
            using (SqlCommand cmd = new SqlCommand(sql, conn, trans))
            {
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateUser(int userId, string fullName, string email, string phoneNumber, int roleId, SqlConnection conn, SqlTransaction trans)
        {
            string sql = string.Format(
               "UPDATE Users SET FullName = N'{0}', Email = N'{1}',PhoneNumber = N'{2}', RoleId = {3} WHERE UserId = {3}",
               fullName.Replace("'", "''"), 
               email.Replace("'", "''"),
               phoneNumber.Replace("'", "''"),
               roleId,
               userId
           );
            using (SqlCommand cmd = new SqlCommand(sql, conn, trans))
            {
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteUser(int userId, SqlConnection conn, SqlTransaction trans)
        {
            // Cảnh báo: Cần cẩn thận khi xóa User.
            // Tốt hơn là nên set Status = 'Inactive'
            // Nhưng nếu bạn muốn xóa:
            string sql = "DELETE FROM Users WHERE UserId = " + userId;

            // Cấm xóa Admin (UserId = 1)
            if (userId == 1) return false;

            using (SqlCommand cmd = new SqlCommand(sql, conn, trans))
            {
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public DataTable SearchUsers(string username, string email, string phoneNumber, int? roleId)
        {
            string sql = @"SELECT u.UserId, u.Username, u.FullName, u.Email, u.PhoneNumber, u.Status, r.RoleName
                           FROM Users u
                           LEFT JOIN Roles r ON u.RoleId = r.RoleId
                           WHERE 1=1";
            if (!string.IsNullOrEmpty(username))
                sql += " AND u.Username LIKE N'%" + username.Replace("'", "''") + "%'";
            if (!string.IsNullOrEmpty(email))
                sql += " AND u.Email LIKE N'%" + email.Replace("'", "''") + "%'";
            if (!string.IsNullOrEmpty(phoneNumber)) // <-- THÊM MỚI
                sql += " AND u.PhoneNumber LIKE N'%" + phoneNumber.Replace("'", "''") + "%'";
            if (roleId.HasValue)
                sql += " AND u.RoleId = " + roleId.Value;

            return _db.DocBang(sql);
        }
    }
}
