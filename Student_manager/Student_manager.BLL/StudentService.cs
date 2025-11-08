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

        public IEnumerable<Student> GetAllStudents()
        {
            return _dao.GetAll();
        }

        public Student GetStudent(int id)
        {
            if (id <= 0) return null;
            return _dao.GetById(id);
        }

        public bool EmailExists(string email, int? excludeStudentId = null)
        {
            return _dao.ExistsEmail(email, excludeStudentId);
        }

        public bool StudentCodeExists(string studentCode, int? excludeStudentId = null)
        {
            return _dao.ExistsStudentCode(studentCode, excludeStudentId);
        }

        public bool UserIdExists(int userId, int? excludeStudentId = null)
        {
            return _dao.ExistsUserId(userId, excludeStudentId);
        }

        public int CreateStudent(Student s, int performedByUserId = 1)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));

            if (s.UserId <= 0)
                throw new ArgumentException("UserId required (liên kết với Users).");
            if (string.IsNullOrWhiteSpace(s.StudentCode))
                throw new ArgumentException("StudentCode required.");
            if (string.IsNullOrWhiteSpace(s.FullName))
                throw new ArgumentException("FullName required.");
            if (string.IsNullOrWhiteSpace(s.Email))
                throw new ArgumentException("Email required.");

            if (_dao.ExistsUserId(s.UserId))
                throw new ArgumentException("UserId already linked to another student.");
            if (_dao.ExistsStudentCode(s.StudentCode))
                throw new ArgumentException("StudentCode already exists.");
            if (_dao.ExistsEmail(s.Email))
                throw new ArgumentException("Email already exists.");

            s.DateOfBirth = s.DateOfBirth ?? DateTime.Now;
            s.Gender = string.IsNullOrEmpty(s.Gender) ? "Unknown" : s.Gender;
            
            s.Address = s.Address ?? "";
            s.PhoneNumber = s.PhoneNumber ?? "";


            int newId = _dao.Insert(s);

            if (newId > 0)
            {
                _actionLog.Log(performedByUserId, "CreateStudent",
                    $"Created student {s.FullName} (Code={s.StudentCode}, Id={newId})");
            }

            return newId;
        }

        public bool UpdateStudent(Student s, int performedByUserId = 1)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));
            if (s.StudentId <= 0) throw new ArgumentException("Invalid StudentId.");
            if (string.IsNullOrWhiteSpace(s.FullName)) throw new ArgumentException("FullName required.");
            if (string.IsNullOrWhiteSpace(s.Email)) throw new ArgumentException("Email required.");
            if (string.IsNullOrWhiteSpace(s.StudentCode)) throw new ArgumentException("StudentCode required.");

            if (_dao.ExistsUserId(s.UserId, s.StudentId))
                throw new ArgumentException("UserId already linked to another student.");
            if (_dao.ExistsStudentCode(s.StudentCode, s.StudentId))
                throw new ArgumentException("StudentCode already exists.");
            if (_dao.ExistsEmail(s.Email, s.StudentId))
                throw new ArgumentException("Email already exists.");

            var current = _dao.GetById(s.StudentId);
            if (current == null)
                throw new ArgumentException("Student not found.");

            bool ok = _dao.Update(s);

            if (ok)
            {
                _actionLog.Log(performedByUserId, "UpdateStudent",
                    $"Updated student {s.FullName} (Id={s.StudentId})");
            }

            return ok;
        }

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
        public IEnumerable<Student> SearchStudents(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return _dao.GetAll();

            return _dao.Search(keyword);
        }


    }
}
