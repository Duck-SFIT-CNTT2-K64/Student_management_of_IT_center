using Student_manager.DAL;
using Student_manager.Models;
using System;

namespace Student_manager.BLL
{
    public class ActionLogService
    {
        private readonly ActionLogDAO _dao = new ActionLogDAO();

        /// <summary>
        /// </summary>
        public int Log(int userId, string action, string details = null)
        {
            var log = new ActionLog
            {
                UserId = userId,
                Action = action,
                Details = details,
                LogDate = DateTime.Now
            };

            return _dao.Insert(log);
        }
    }
}
