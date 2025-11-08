using System;
using System.Collections.Generic;
using Student_manager.DAL;
using Student_manager.Models;

namespace Student_manager.BLL
{
    public class LecturesService
    {
        private readonly LecturesDAO _dao;

        public LecturesService(LecturesDAO dao)
        {
            _dao = dao ?? throw new ArgumentNullException(nameof(dao));
        }

        public List<Teacher> GetAllLecturers()
        {
            return _dao.GetAll();
        }

        public List<Teacher> SearchLecturers(string q)
        {
            if (string.IsNullOrWhiteSpace(q)) return new List<Teacher>();
            return _dao.SearchByName(q);
        }

        public string AddLecturer(Teacher teacher)
        {
            if (teacher == null) return "Dữ liệu giảng viên không hợp lệ!";

            bool result = _dao.Add(teacher);

            return result ? "Thêm giảng viên thành công!" : "Không thể thêm giảng viên. Vui lòng kiểm tra lại!";
        }

        public string UpdateLecturer(Teacher teacher)
        {
            if (teacher == null || teacher.TeacherId <= 0) return "Dữ liệu không hợp lệ.";
            if (string.IsNullOrWhiteSpace(teacher.TeacherCode) ||
                string.IsNullOrWhiteSpace(teacher.FirstName) ||
                string.IsNullOrWhiteSpace(teacher.LastName) ||
                string.IsNullOrWhiteSpace(teacher.Email))
            {
                return "Mã, Họ/Tên và Email không được để trống.";
            }

            var existing = _dao.GetById(teacher.TeacherId);
            if (existing == null) return "Không tìm thấy giảng viên cần cập nhật.";

            bool codeChanged = !string.Equals(existing.TeacherCode?.Trim(), teacher.TeacherCode?.Trim(), StringComparison.OrdinalIgnoreCase);
            bool emailChanged = !string.Equals(existing.Email?.Trim(), teacher.Email?.Trim(), StringComparison.OrdinalIgnoreCase);

            if (codeChanged && _dao.IsTeacherCodeExists(teacher.TeacherCode, teacher.TeacherId))
            {
                return $"Mã giảng viên '{teacher.TeacherCode}' đã bị trùng.";
            }

            if (emailChanged && _dao.IsEmailExists(teacher.Email, teacher.TeacherId))
            {
                return $"Email '{teacher.Email}' đã bị trùng.";
            }

            var ok = _dao.Update(teacher);
            return ok ? "Cập nhật giảng viên thành công." : "Cập nhật thất bại do lỗi hệ thống.";
        }

        public string DeleteLecturer(int teacherId)
        {
            if (teacherId <= 0) return "Id không hợp lệ.";
            var ok = _dao.Delete(teacherId);
            return ok ? "Xóa giảng viên thành công." : "Xóa thất bại do lỗi hệ thống.";
        }
    }
}
