using Student_manager.DAL;
using Student_manager.Models;
using System;
using System.Collections.Generic;

namespace Student_manager.BLL
{
    public class StudentService
    {
        private readonly StudentDAO _dao = new StudentDAO();
        private readonly ActionLogService _actionLog = new ActionLogService();

        // 🟢 Lấy tất cả sinh viên
        public IEnumerable<Student> GetAllStudents()
        {
            return _dao.GetAll();
        }

        // 🟢 Lấy sinh viên theo ID
        public Student GetStudent(int id)
        {
            if (id <= 0) return null;
            return _dao.GetById(id);
        }

        // 🟡 Kiểm tra tồn tại Email (phục vụ UI validation)
        public bool EmailExists(string email, int? excludeStudentId = null)
        {
            return _dao.ExistsEmail(email, excludeStudentId);
        }

        // 🟡 Kiểm tra tồn tại mã sinh viên
        public bool StudentCodeExists(string studentCode, int? excludeStudentId = null)
        {
            return _dao.ExistsStudentCode(studentCode, excludeStudentId);
        }

        // 🟡 Kiểm tra trùng UserId (liên kết 1-1 với Users)
        public bool UserIdExists(int userId, int? excludeStudentId = null)
        {
            return _dao.ExistsUserId(userId, excludeStudentId);
        }

        // 🟢 Tạo mới sinh viên
        public int CreateStudent(Student s, int performedByUserId = 1)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));

            // --- Validate bắt buộc ---
            if (s.UserId <= 0)
                throw new ArgumentException("UserId required (liên kết với Users).");
            if (string.IsNullOrWhiteSpace(s.StudentCode))
                throw new ArgumentException("StudentCode required.");
            if (string.IsNullOrWhiteSpace(s.FullName))
                throw new ArgumentException("FullName required.");
            if (string.IsNullOrWhiteSpace(s.Email))
                throw new ArgumentException("Email required.");

            // --- Kiểm tra trùng ---
            if (_dao.ExistsUserId(s.UserId))
                throw new ArgumentException("UserId already linked to another student.");
            if (_dao.ExistsStudentCode(s.StudentCode))
                throw new ArgumentException("StudentCode already exists.");
            if (_dao.ExistsEmail(s.Email))
                throw new ArgumentException("Email already exists.");

            // --- Gán giá trị mặc định ---
            s.DateOfBirth = s.DateOfBirth ?? DateTime.Now;
            s.Gender = string.IsNullOrEmpty(s.Gender) ? "Unknown" : s.Gender;
            
            s.Address = s.Address ?? "";
            s.PhoneNumber = s.PhoneNumber ?? "";


            // --- Ghi vào DB ---
            int newId = _dao.Insert(s);

            // --- Ghi log ---
            if (newId > 0)
            {
                _actionLog.Log(performedByUserId, "CreateStudent",
                    $"Created student {s.FullName} (Code={s.StudentCode}, Id={newId})");
            }

            return newId;
        }

        // 🟢 Cập nhật thông tin sinh viên
        public bool UpdateStudent(Student s, int performedByUserId = 1)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));
            if (s.StudentId <= 0) throw new ArgumentException("Invalid StudentId.");
            if (string.IsNullOrWhiteSpace(s.FullName)) throw new ArgumentException("FullName required.");
            if (string.IsNullOrWhiteSpace(s.Email)) throw new ArgumentException("Email required.");
            if (string.IsNullOrWhiteSpace(s.StudentCode)) throw new ArgumentException("StudentCode required.");

            // --- Kiểm tra trùng dữ liệu ---
            if (_dao.ExistsUserId(s.UserId, s.StudentId))
                throw new ArgumentException("UserId already linked to another student.");
            if (_dao.ExistsStudentCode(s.StudentCode, s.StudentId))
                throw new ArgumentException("StudentCode already exists.");
            if (_dao.ExistsEmail(s.Email, s.StudentId))
                throw new ArgumentException("Email already exists.");

            // --- Kiểm tra sinh viên có tồn tại ---
            var current = _dao.GetById(s.StudentId);
            if (current == null)
                throw new ArgumentException("Student not found.");

            // --- Cập nhật DB ---
            bool ok = _dao.Update(s);

            // --- Ghi log ---
            if (ok)
            {
                _actionLog.Log(performedByUserId, "UpdateStudent",
                    $"Updated student {s.FullName} (Id={s.StudentId})");
            }

            return ok;
        }

        // 🟢 Xoá sinh viên
        public bool DeleteStudent(int id, int performedByUserId = 1)
        {
            if (id <= 0) return false;

            var s = _dao.GetById(id);
            if (s == null) return false;

            bool ok = _dao.Delete(id);

            if (ok)
            {
                _actionLog.Log(performedByUserId, "DeleteStudent",
                    $"Deleted student {s.FullName} (Code={s.StudentCode}, Id={id})");
            }

            return ok;
        }
        // 🟢 Tìm kiếm sinh viên theo từ khoá (mã sinh viên, tên, email, điện thoại)
        public IEnumerable<Student> SearchStudents(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return _dao.GetAll(); // nếu trống thì trả lại toàn bộ danh sách

            return _dao.Search(keyword);
        }


    }
}
