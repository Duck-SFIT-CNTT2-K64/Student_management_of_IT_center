using Student_manager.DAL;
using Student_manager.Models;
using System;
using System.Collections.Generic;

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

        // new helper for UI validation
        public bool EmailExists(string email, int? excludeUserId = null)
        {
            return _dao.ExistsEmail(email, excludeUserId);
        }

        public int CreateUser(User u, int performedByUserId = 1)
        {
            if (u == null) throw new ArgumentNullException(nameof(u));
            if (string.IsNullOrWhiteSpace(u.Username)) throw new ArgumentException("Username required");

            // auto-generate fallback email if missing (prevents runtime "Email required" when UI omits email)
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
    }
}
