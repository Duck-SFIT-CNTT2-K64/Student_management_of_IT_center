using Student_manager.DAL;
using Student_manager.Models;
using System;
using System.Collections.Generic;

namespace Student_manager.BLL
{
    public class HomeNoticeService
    {
        private readonly HomeNoticeDAO _dao = new HomeNoticeDAO();
        private readonly ActionLogService _log = new ActionLogService();

        public IEnumerable<HomeNotice> GetAll() => _dao.GetAll();

        public HomeNotice GetById(int id) => _dao.GetById(id);

        public int Create(HomeNotice n, int performedByUserId = 1)
        {
            if (n == null) throw new ArgumentNullException(nameof(n));
            if (string.IsNullOrWhiteSpace(n.Title)) throw new ArgumentException("Title is required");
            n.Title = n.Title.Trim();
            n.CreatedAt = (n.CreatedAt == default(DateTime)) ? DateTime.Now : n.CreatedAt;
            var id = _dao.Insert(n);
            if (id > 0) _log.Log(performedByUserId, "CreateHomeNotice", $"Created home notice Id={id} Title='{n.Title}'");
            return id;
        }

        public bool Update(HomeNotice n, int performedByUserId = 1)
        {
            if (n == null) throw new ArgumentNullException(nameof(n));
            if (n.NoticeId <= 0) throw new ArgumentException("Invalid NoticeId");
            if (string.IsNullOrWhiteSpace(n.Title)) throw new ArgumentException("Title is required");
            var ok = _dao.Update(n);
            if (ok) _log.Log(performedByUserId, "UpdateHomeNotice", $"Updated home notice Id={n.NoticeId} Title='{n.Title}'");
            return ok;
        }

        public bool Delete(int id, int performedByUserId = 1)
        {
            if (id <= 0) return false;
            var n = _dao.GetById(id);
            var ok = _dao.Delete(id);
            if (ok) _log.Log(performedByUserId, "DeleteHomeNotice", $"Deleted home notice Id={id} Title='{n?.Title}'");
            return ok;
        }
    }
}
