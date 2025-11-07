using Student_manager.DAL;
using Student_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Student_manager.BLL
{
    public class EnrollmentService
    {
        private readonly EnrollmentDAO _dao = new EnrollmentDAO();
        private readonly ActionLogService _actionLog = new ActionLogService();

        // 🔹 Lấy toàn bộ danh sách ghi danh
        public IEnumerable<Enrollment> GetAllEnrollments()
        {
            return _dao.GetAll();
        }

        // 🔹 Lấy ghi danh theo ID
        public Enrollment GetEnrollment(int id)
        {
            if (id <= 0) return null;
            return _dao.GetById(id);
        }

        // 🔹 Lấy danh sách ghi danh theo lớp
        public IEnumerable<Enrollment> GetByClassId(int classId)
        {
            if (classId <= 0) return new List<Enrollment>();
            return _dao.GetByClassId(classId);
        }

        // 🔹 Lấy danh sách ghi danh theo sinh viên
        public IEnumerable<Enrollment> GetByStudentId(int studentId)
        {
            if (studentId <= 0) return new List<Enrollment>();
            return _dao.GetByStudentId(studentId);
        }

        // 🔹 Thêm ghi danh mới
        public int CreateEnrollment(Enrollment e, int performedByUserId = 1)
        {
            if (e == null) throw new ArgumentNullException(nameof(e));
            if (e.StudentId <= 0) throw new ArgumentException("StudentId không hợp lệ.");
            if (e.ClassId <= 0) throw new ArgumentException("ClassId không hợp lệ.");

            e.EnrollmentDate = (e.EnrollmentDate == default(DateTime)) ? DateTime.Now : e.EnrollmentDate;
            if (string.IsNullOrWhiteSpace(e.Status))
                e.Status = "Đang học";

            var newId = _dao.Insert(e);
            if (newId > 0)
            {
                _actionLog.Log(performedByUserId, "CreateEnrollment",
                    $"Đã ghi danh sinh viên {e.StudentId} vào lớp {e.ClassId} (Id={newId})");
            }
            return newId;
        }

        // 🔹 Cập nhật ghi danh
        public bool UpdateEnrollment(Enrollment e, int performedByUserId = 1)
        {
            if (e == null) throw new ArgumentNullException(nameof(e));
            if (e.EnrollmentId <= 0) throw new ArgumentException("EnrollmentId không hợp lệ.");
            if (e.StudentId <= 0) throw new ArgumentException("StudentId không hợp lệ.");
            if (e.ClassId <= 0) throw new ArgumentException("ClassId không hợp lệ.");

            var current = _dao.GetById(e.EnrollmentId);
            if (current == null) throw new ArgumentException("Không tìm thấy ghi danh.");

            var ok = _dao.Update(e);
            if (ok)
            {
                _actionLog.Log(performedByUserId, "UpdateEnrollment",
                    $"Cập nhật ghi danh ID={e.EnrollmentId} (SV={e.StudentId}, Lớp={e.ClassId})");
            }
            return ok;
        }

        // 🔹 Xóa ghi danh
        public bool DeleteEnrollment(int enrollmentId, int performedByUserId = 1)
        {
            if (enrollmentId <= 0) return false;
            var e = _dao.GetById(enrollmentId);
            if (e == null) return false;

            var ok = _dao.Delete(enrollmentId);
            if (ok)
            {
                _actionLog.Log(performedByUserId, "DeleteEnrollment",
                    $"Đã xóa ghi danh ID={enrollmentId} (SV={e.StudentId}, Lớp={e.ClassId})");
            }
            return ok;
        }

        // 🔹 Lấy ID ghi danh đầu tiên của lớp (phục vụ frmStudy)
        public int GetFirstEnrollmentIdByClass(int classId)
        {
            if (classId <= 0) return -1;

            var enrollments = _dao.GetByClassId(classId);
            var first = enrollments.FirstOrDefault();
            return first != null ? first.EnrollmentId : -1;
        }
        public Enrollment GetById(int enrollmentId)
        {
            var e = _dao.GetById(enrollmentId);
            if (e != null)
            {
                e.Student = new StudentDAO().GetById(e.StudentId);
            }
            return e;
        }
    }
}
