using Student_manager.DAL;
using Student_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Student_manager.BLL
{
    public class NotificationService
    {
        private readonly NotificationDAO _dao = new NotificationDAO();
        private readonly UserDAO _userDao = new UserDAO();

        public bool SendNotification(Notification n, List<int> recipientIds)
        {
            if (n == null || recipientIds == null || recipientIds.Count == 0)
                return false;

            int newId = _dao.Insert(n);
            if (newId <= 0) return false;

            foreach (int uid in recipientIds)
            {
                _dao.InsertRecipient(newId, uid);
            }

            return true;
        }

        public List<int> GetRecipientsByRole(string roleName)
        {
            int roleId = 0;
            switch (roleName.ToLower())
            {
                case "user": roleId = 2; break;
                case "teacher": roleId = 3; break; 
                case "student": roleId = 5; break; 
                default: return new List<int>();
            }

            var users = _userDao.GetAll();
            return users.Where(u => u.RoleId == roleId)
                        .Select(u => u.UserId)
                        .ToList();
        }
    }
}
