using Student_manager.DAL;
using Student_manager.Models;
using System;
using System.Collections.Generic;

namespace Student_manager.BLL
{
    public class ReportService
    {
        private readonly ReportDAO _dao = new ReportDAO();

        public IEnumerable<Report> GetAllReports()
        {
            return _dao.GetAll();
        }

        public Report GetReport(int id)
        {
            if (id <= 0) return null;
            return _dao.GetById(id);
        }

        public int CreateReport(Report r)
        {
            if (r == null) throw new ArgumentNullException(nameof(r));
            if (string.IsNullOrWhiteSpace(r.Title)) throw new ArgumentException("Title is required", nameof(r.Title));
            r.CreatedAt = (r.CreatedAt == default(DateTime)) ? DateTime.Now : r.CreatedAt;
            return _dao.Insert(r);
        }

        public bool UpdateReport(Report r)
        {
            if (r == null) throw new ArgumentNullException(nameof(r));
            if (r.ReportId <= 0) throw new ArgumentException("Invalid ReportId", nameof(r.ReportId));
            if (string.IsNullOrWhiteSpace(r.Title)) throw new ArgumentException("Title is required", nameof(r.Title));
            return _dao.Update(r);
        }

        public bool DeleteReport(int id)
        {
            if (id <= 0) return false;
            return _dao.Delete(id);
        }
    }
}
