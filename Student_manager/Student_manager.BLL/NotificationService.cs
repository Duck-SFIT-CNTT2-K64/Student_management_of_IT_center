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

        // Gửi thông báo + tạo bản ghi người nhận
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

        // Lấy danh sách người nhận theo Role (theo RoleId)
        public List<int> GetRecipientsByRole(string roleName)
        {
            int roleId = 0;
            switch (roleName.ToLower())
            {
                case "user": roleId = 2; break; // Giáo vụ
                case "teacher": roleId = 3; break; // Giảng viên
                case "student": roleId = 5; break; // Sinh viên
                default: return new List<int>();
            }

            var users = _userDao.GetAll();
            return users.Where(u => u.RoleId == roleId)
                        .Select(u => u.UserId)
                        .ToList();
        }

        //// Xóa thông báo và các người nhận liên quan
        //public bool DeleteNotification(int notificationId)
        //{
        //    if (notificationId <= 0)
        //        throw new ArgumentException("NotificationId không hợp lệ");

        //    return _dao.DeleteNotification(notificationId);
        //}
    }
}
