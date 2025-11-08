using Student_manager.DAL;
using Student_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Student_manager.BLL
{
    public class UserService
    {
        private readonly UserDAO _dao = new UserDAO();
        private readonly ActionLogService _actionLog = new ActionLogService();

        public IEnumerable<User> GetAllUsers()
        {
            return _dao.GetAll();
        }

        public User GetUser(int id)
        {
            if (id <= 0) return null;
            return _dao.GetById(id);
        }

        public bool EmailExists(string email, int? excludeUserId = null)
        {
            return _dao.ExistsEmail(email, excludeUserId);
        }

        public int CreateUser(User u, int performedByUserId = 1)
        {
            if (u == null) throw new ArgumentNullException(nameof(u));
            if (string.IsNullOrWhiteSpace(u.Username)) throw new ArgumentException("Username required");

            if (string.IsNullOrWhiteSpace(u.Email))
            {
                u.Email = (u.Username ?? "user") + "@local";
            }

            if (_dao.ExistsUsername(u.Username)) throw new ArgumentException("Username already exists");
            if (_dao.ExistsEmail(u.Email)) throw new ArgumentException("Email already exists");

            u.DateCreated = (u.DateCreated == default(DateTime)) ? DateTime.Now : u.DateCreated;
            if (string.IsNullOrEmpty(u.PasswordHash))
            {
                u.PasswordHash = PasswordHelper.HashSha256("P@ssw0rd");
            }

            var newId = _dao.Insert(u);
            if (newId > 0)
            {
                _actionLog.Log(performedByUserId, "CreateUser", $"Created user {u.Username} (Id={newId})");
            }
            return newId;
        }

        public bool UpdateUser(User u, int performedByUserId = 1)
        {
            if (u == null) throw new ArgumentNullException(nameof(u));
            if (u.UserId <= 0) throw new ArgumentException("Invalid UserId");
            if (string.IsNullOrWhiteSpace(u.Username)) throw new ArgumentException("Username required");
            if (string.IsNullOrWhiteSpace(u.Email)) throw new ArgumentException("Email required");

            if (_dao.ExistsUsername(u.Username, u.UserId)) throw new ArgumentException("Username already exists");
            if (_dao.ExistsEmail(u.Email, u.UserId)) throw new ArgumentException("Email already exists");

            var current = _dao.GetById(u.UserId);
            if (current == null) throw new ArgumentException("User not found");

            if (string.IsNullOrEmpty(u.PasswordHash))
            {
                u.PasswordHash = current.PasswordHash;
            }

            var ok = _dao.Update(u);
            if (ok)
            {
                _actionLog.Log(performedByUserId, "UpdateUser", $"Updated user {u.Username} (Id={u.UserId})");
            }
            return ok;
        }

        public bool DeleteUser(int id, int performedByUserId = 1)
        {
            if (id <= 0) return false;
            var u = _dao.GetById(id);
            if (u == null) return false;
            var ok = _dao.Delete(id);
            if (ok)
            {
                _actionLog.Log(performedByUserId, "DeleteUser", $"Deleted user {u.Username} (Id={id})");
            }
            return ok;
        }

        public User Authenticate(string username, string plainPassword)
        {
            if (string.IsNullOrWhiteSpace(username) || plainPassword == null) return null;

            var user = _dao.GetByUsername(username);
            if (user == null) return null;

            var stored = user.PasswordHash ?? string.Empty;
            if (string.IsNullOrWhiteSpace(stored)) return null;

            if (stored.StartsWith("$2a$") || stored.StartsWith("$2y$") || stored.StartsWith("$2b$"))
            {
                if (BcryptReflectionVerify(plainPassword, stored))
                {
                    return user;
                }
                return null;
            }
            else
            {
                var hashed = PasswordHelper.HashSha256(plainPassword);
                if (string.Equals(hashed, stored, StringComparison.OrdinalIgnoreCase))
                    return user;
            }

            return null;
        }

        private static bool BcryptReflectionVerify(string password, string hash)
        {
            try
            {
                var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (var asm in assemblies)
                {
                    Type bcryptType = null;
                    try { bcryptType = asm.GetType("BCrypt.Net.BCrypt") ?? asm.GetType("BCrypt.BCrypt"); } catch { bcryptType = null; }
                    if (bcryptType == null) continue;
                    var method = bcryptType.GetMethod("Verify", new Type[] { typeof(string), typeof(string) });
                    if (method == null) continue;
                    var res = method.Invoke(null, new object[] { password, hash });
                    if (res is bool b) return b;
                }
            }
            catch
            {
                // ignore
            }
            return false;
        }

        public static string BcryptReflectionHash(string password)
        {
            try
            {
                var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (var asm in assemblies)
                {
                    Type bcryptType = null;
                    try { bcryptType = asm.GetType("BCrypt.Net.BCrypt") ?? asm.GetType("BCrypt.BCrypt"); } catch { bcryptType = null; }
                    if (bcryptType == null) continue;
                    var method = bcryptType.GetMethod("HashPassword", new Type[] { typeof(string) });
                    if (method == null) continue;
                    var res = method.Invoke(null, new object[] { password });
                    if (res is string s) return s;
                }
            }
            catch
            {
            }
            return null;
        }

        public static bool IsBcryptAvailable()
        {
            try
            {
                var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (var asm in assemblies)
                {
                    var t = asm.GetType("BCrypt.Net.BCrypt") ?? asm.GetType("BCrypt.BCrypt");
                    if (t != null) return true;
                }
            }
            catch { }
            return false;
        }
    }
}
