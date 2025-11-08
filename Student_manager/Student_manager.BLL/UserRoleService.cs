using Student_manager.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Student_manager.BLL
{
    public class UserRoleService
    {
        private readonly UserRoleDAO _userDAO;
        public UserRoleService() { _userDAO = new UserRoleDAO(); }

        public DataTable GetUserList()
        {
            return _userDAO.GetUsersWithRoles();
        }

        private static string HashPasswordSHA256(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Tính toán hash - trả về 1 mảng byte
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Chuyển mảng byte thành chuỗi hex
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); // "x2" là định dạng hex
                }
                return builder.ToString();
            }
        }

        public bool CreateUser(string username, string password, string fullName, string email, string phoneNumber, int roleId, out string errorMessage)
        {
            // 1. Validate
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(fullName))
            {
                errorMessage = "Username, Password, and FullName are required.";
                return false;
            }
            if (_userDAO.GetUserByUsername(username) != null)
            {
                errorMessage = "Username already exists.";
                return false;
            }

            // 2. Hash mật khẩu (Dùng SHA256)
            string passwordHash = HashPasswordSHA256(password);

            // 3. Transaction
            using (SqlConnection conn = SqlHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    _userDAO.AddUser(username, passwordHash, fullName, email, phoneNumber, roleId, conn, trans);
                    trans.Commit();
                    errorMessage = string.Empty;
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    errorMessage = "Database error: " + ex.Message;
                }
            }
            return false;
        }

        public bool UpdateUser(int userId, string fullName, string email, string phoneNumber, int roleId, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                errorMessage = "Full Name is required.";
                return false;
            }

            using (SqlConnection conn = SqlHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    _userDAO.UpdateUser(userId, fullName, email, phoneNumber, roleId, conn, trans);
                    trans.Commit();
                    errorMessage = string.Empty;
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    errorMessage = "Database error: " + ex.Message;
                }
            }
            return false;
        }
        public bool DeleteUser(int userId, out string errorMessage)
        {
            if (userId == 1)
            {
                errorMessage = "Cannot delete the default Admin user.";
                return false;
            }

            using (SqlConnection conn = SqlHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    _userDAO.DeleteUser(userId, conn, trans);
                    trans.Commit();
                    errorMessage = string.Empty;
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    errorMessage = "Database error: " + ex.Message;
                }
            }
            return false;
        }
        public DataTable SearchUsers(string username, string email, string phoneNumber, int? roleId)
        {
            return _userDAO.SearchUsers(username, email, phoneNumber, roleId);
        }
    }
}
