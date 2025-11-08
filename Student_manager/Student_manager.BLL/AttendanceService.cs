using Student_manager.DAL;
using Student_manager.Models;
using System;
using System.Collections.Generic;

namespace Student_manager.BLL
{
    public class AttendanceService
    {
        private readonly AttendanceDAO _dao = new AttendanceDAO();

        // 🔹 Lấy tất cả bản ghi
        public IEnumerable<Attendance> GetAllAttendances()
        {
            return _dao.GetAll();
        }

        // 🔹 Lấy theo EnrollmentId
        public IEnumerable<Attendance> GetByEnrollmentId(int enrollmentId)
        {
            if (enrollmentId <= 0) return new List<Attendance>();
            return _dao.GetByEnrollmentId(enrollmentId);
        }

        // 🔹 Lấy chi tiết theo ID
        public Attendance GetAttendance(int id)
        {
            if (id <= 0) return null;
            return _dao.GetById(id);
        }

        // 🔹 Thêm điểm danh
        public int CreateAttendance(Attendance a)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));
            if (a.EnrollmentId <= 0) throw new ArgumentException("EnrollmentId không hợp lệ.");
            if (string.IsNullOrWhiteSpace(a.Status)) a.Status = "Có mặt";

            // tránh trùng ngày học trong cùng lớp
            if (_dao.ExistsByDate(a.EnrollmentId, a.SessionDate))
                throw new ArgumentException("Ngày học này đã được điểm danh.");

            return _dao.Insert(a);
        }

        // 🔹 Cập nhật điểm danh
        public bool UpdateAttendance(Attendance a)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));
            if (a.AttendanceId <= 0) throw new ArgumentException("AttendanceId không hợp lệ.");
            if (string.IsNullOrWhiteSpace(a.Status)) a.Status = "Có mặt";

            return _dao.Update(a);
        }

        // 🔹 Xóa bản ghi điểm danh
        public bool DeleteAttendance(int id)
        {
            if (id <= 0) return false;
            return _dao.Delete(id);
        }

        // 🔹 Lấy EnrollmentId đầu tiên theo ClassId (hỗ trợ frmStudy demo)
        public int GetFirstEnrollmentIdByClass(int classId)
        {
            return _dao.GetFirstEnrollmentIdByClass(classId);
        }
        public bool UpdateAttendance(int attendanceId, DateTime newDate, string newStatus)
        {
            return _dao.UpdateAttendance(attendanceId, newDate, newStatus);
        }
        
    }
}
