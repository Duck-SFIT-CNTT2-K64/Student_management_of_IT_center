using Student_manager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Student_manager.DAL
{
    public class UserDAO
    {
        public IEnumerable<User> GetAll()
        {
            var list = new List<User>();
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT UserId, RoleId, Username, PasswordHash, FullName, Email, PhoneNumber, Status, DateCreated
                    FROM Users
                    ORDER BY UserId";
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new User
                        {
                            UserId = rdr.GetInt32(rdr.GetOrdinal("UserId")),
                            RoleId = rdr.IsDBNull(rdr.GetOrdinal("RoleId")) ? (int?)null : rdr.GetInt32(rdr.GetOrdinal("RoleId")),
                            Username = rdr.IsDBNull(rdr.GetOrdinal("Username")) ? null : rdr.GetString(rdr.GetOrdinal("Username")),
                            PasswordHash = rdr.IsDBNull(rdr.GetOrdinal("PasswordHash")) ? null : rdr.GetString(rdr.GetOrdinal("PasswordHash")),
                            FullName = rdr.IsDBNull(rdr.GetOrdinal("FullName")) ? null : rdr.GetString(rdr.GetOrdinal("FullName")),
                            Email = rdr.IsDBNull(rdr.GetOrdinal("Email")) ? null : rdr.GetString(rdr.GetOrdinal("Email")),
                            PhoneNumber = rdr.IsDBNull(rdr.GetOrdinal("PhoneNumber")) ? null : rdr.GetString(rdr.GetOrdinal("PhoneNumber")),
                            Status = rdr.IsDBNull(rdr.GetOrdinal("Status")) ? null : rdr.GetString(rdr.GetOrdinal("Status")),
                            DateCreated = rdr.IsDBNull(rdr.GetOrdinal("DateCreated")) ? DateTime.MinValue : rdr.GetDateTime(rdr.GetOrdinal("DateCreated"))
                        });
                    }
                }
            }
            return list;
        }

        public User GetById(int userId)
        {
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT UserId, RoleId, Username, PasswordHash, FullName, Email, PhoneNumber, Status, DateCreated
                    FROM Users WHERE UserId = @id";
                cmd.Parameters.AddWithValue("@id", userId);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        return new User
                        {
                            UserId = rdr.GetInt32(rdr.GetOrdinal("UserId")),
                            RoleId = rdr.IsDBNull(rdr.GetOrdinal("RoleId")) ? (int?)null : rdr.GetInt32(rdr.GetOrdinal("RoleId")),
                            Username = rdr.IsDBNull(rdr.GetOrdinal("Username")) ? null : rdr.GetString(rdr.GetOrdinal("Username")),
                            PasswordHash = rdr.IsDBNull(rdr.GetOrdinal("PasswordHash")) ? null : rdr.GetString(rdr.GetOrdinal("PasswordHash")),
                            FullName = rdr.IsDBNull(rdr.GetOrdinal("FullName")) ? null : rdr.GetString(rdr.GetOrdinal("FullName")),
                            Email = rdr.IsDBNull(rdr.GetOrdinal("Email")) ? null : rdr.GetString(rdr.GetOrdinal("Email")),
                            PhoneNumber = rdr.IsDBNull(rdr.GetOrdinal("PhoneNumber")) ? null : rdr.GetString(rdr.GetOrdinal("PhoneNumber")),
                            Status = rdr.IsDBNull(rdr.GetOrdinal("Status")) ? null : rdr.GetString(rdr.GetOrdinal("Status")),
                            DateCreated = rdr.IsDBNull(rdr.GetOrdinal("DateCreated")) ? DateTime.MinValue : rdr.GetDateTime(rdr.GetOrdinal("DateCreated"))
                        };
                    }
                }
            }
            return null;
        }

        // New: get user by username
        public User GetByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) return null;
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT UserId, RoleId, Username, PasswordHash, FullName, Email, PhoneNumber, Status, DateCreated
                    FROM Users WHERE Username = @u";
                cmd.Parameters.AddWithValue("@u", username);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        return new User
                        {
                            UserId = rdr.GetInt32(rdr.GetOrdinal("UserId")),
                            RoleId = rdr.IsDBNull(rdr.GetOrdinal("RoleId")) ? (int?)null : rdr.GetInt32(rdr.GetOrdinal("RoleId")),
                            Username = rdr.IsDBNull(rdr.GetOrdinal("Username")) ? null : rdr.GetString(rdr.GetOrdinal("Username")),
                            PasswordHash = rdr.IsDBNull(rdr.GetOrdinal("PasswordHash")) ? null : rdr.GetString(rdr.GetOrdinal("PasswordHash")),
                            FullName = rdr.IsDBNull(rdr.GetOrdinal("FullName")) ? null : rdr.GetString(rdr.GetOrdinal("FullName")),
                            Email = rdr.IsDBNull(rdr.GetOrdinal("Email")) ? null : rdr.GetString(rdr.GetOrdinal("Email")),
                            PhoneNumber = rdr.IsDBNull(rdr.GetOrdinal("PhoneNumber")) ? null : rdr.GetString(rdr.GetOrdinal("PhoneNumber")),
                            Status = rdr.IsDBNull(rdr.GetOrdinal("Status")) ? null : rdr.GetString(rdr.GetOrdinal("Status")),
                            DateCreated = rdr.IsDBNull(rdr.GetOrdinal("DateCreated")) ? DateTime.MinValue : rdr.GetDateTime(rdr.GetOrdinal("DateCreated"))
                        };
                    }
                }
            }
            return null;
        }

        // existence checks used by BLL for uniqueness validation
        public bool ExistsUsername(string username, int? excludeUserId = null)
        {
            if (string.IsNullOrWhiteSpace(username)) return false;
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                if (excludeUserId.HasValue)
                {
                    cmd.CommandText = "SELECT COUNT(1) FROM Users WHERE Username = @u AND UserId <> @id";
                    cmd.Parameters.AddWithValue("@id", excludeUserId.Value);
                }
                else
                {
                    cmd.CommandText = "SELECT COUNT(1) FROM Users WHERE Username = @u";
                }
                cmd.Parameters.AddWithValue("@u", username);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        public bool ExistsEmail(string email, int? excludeUserId = null)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                if (excludeUserId.HasValue)
                {
                    cmd.CommandText = "SELECT COUNT(1) FROM Users WHERE Email = @e AND UserId <> @id";
                    cmd.Parameters.AddWithValue("@id", excludeUserId.Value);
                }
                else
                {
                    cmd.CommandText = "SELECT COUNT(1) FROM Users WHERE Email = @e";
                }
                cmd.Parameters.AddWithValue("@e", email);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        public int Insert(User u)
        {
            if (u == null) throw new ArgumentNullException(nameof(u));
            if (string.IsNullOrWhiteSpace(u.Username)) throw new ArgumentException("Username required", nameof(u.Username));

            // Defensive defaults so we don't pass explicit NULL to NOT NULL columns.
            // Higher layers (BLL/UI) should supply proper values; this prevents DB exceptions and gives predictable behavior.
            var statusValue = string.IsNullOrWhiteSpace(u.Status) ? "Active" : u.Status;
            var emailValue = string.IsNullOrWhiteSpace(u.Email) ? ( (u.Username ?? "user") + "@local" ) : u.Email;
            var pwdValue = u.PasswordHash ?? string.Empty; // BLL is expected to set a hashed password; empty avoids NULL insert.

            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    INSERT INTO Users (RoleId, Username, PasswordHash, FullName, Email, PhoneNumber, Status, DateCreated)
                    VALUES (@RoleId, @Username, @PasswordHash, @FullName, @Email, @PhoneNumber, @Status, @DateCreated);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";
                cmd.Parameters.AddWithValue("@RoleId", (object)u.RoleId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Username", u.Username ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@PasswordHash", pwdValue);
                cmd.Parameters.AddWithValue("@FullName", u.FullName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", emailValue);
                cmd.Parameters.AddWithValue("@PhoneNumber", u.PhoneNumber ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Status", statusValue);
                cmd.Parameters.AddWithValue("@DateCreated", u.DateCreated == default(DateTime) ? DateTime.Now : u.DateCreated);
                conn.Open();
                var id = cmd.ExecuteScalar();
                return (id == null || id == DBNull.Value) ? -1 : Convert.ToInt32(id);
            }
        }

        public bool Update(User u)
        {
            if (u == null) throw new ArgumentNullException(nameof(u));
            if (u.UserId <= 0) throw new ArgumentException("Invalid UserId", nameof(u.UserId));

            // keep same defensive handling for required columns
            var statusValue = string.IsNullOrWhiteSpace(u.Status) ? "Active" : u.Status;
            var emailValue = string.IsNullOrWhiteSpace(u.Email) ? ( (u.Username ?? "user") + "@local" ) : u.Email;
            var pwdValue = u.PasswordHash ?? string.Empty; // preserve empty if not provided (BLL should normally set)

            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    UPDATE Users
                    SET RoleId = @RoleId,
                        Username = @Username,
                        PasswordHash = @PasswordHash,
                        FullName = @FullName,
                        Email = @Email,
                        PhoneNumber = @PhoneNumber,
                        Status = @Status
                    WHERE UserId = @UserId";
                cmd.Parameters.AddWithValue("@RoleId", (object)u.RoleId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Username", u.Username ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@PasswordHash", pwdValue);
                cmd.Parameters.AddWithValue("@FullName", u.FullName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", emailValue);
                cmd.Parameters.AddWithValue("@PhoneNumber", u.PhoneNumber ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Status", statusValue);
                cmd.Parameters.AddWithValue("@UserId", u.UserId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int userId)
        {
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Users WHERE UserId = @id";
                cmd.Parameters.AddWithValue("@id", userId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
