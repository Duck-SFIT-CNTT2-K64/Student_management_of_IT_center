using Student_manager.DAL;
using Student_manager.Models;
using System;
using System.Collections.Generic;

namespace Student_manager.BLL
{
    public class CourseService
    {
        private readonly CourseDAO _dao = new CourseDAO();

        // 🔹 Lấy tất cả khóa học
        public IEnumerable<Course> GetAllCourses()
        {
            return _dao.GetAll();
        }

        // 🔹 Lấy 1 khóa học theo ID
        public Course GetCourse(int id)
        {
            if (id <= 0) return null;
            return _dao.GetById(id);
        }

        // 🔹 Thêm khóa học mới
        public int CreateCourse(Course c)
        {
            if (c == null) throw new ArgumentNullException(nameof(c));
            if (string.IsNullOrWhiteSpace(c.CourseName))
                throw new ArgumentException("Course name is required");

            // đảm bảo không trùng mã khóa học
            if (_dao.ExistsCourseCode(c.CourseCode))
                throw new ArgumentException("Course code already exists");

            if (string.IsNullOrWhiteSpace(c.CourseCode))
                c.CourseCode = "CRS" + DateTime.Now.Ticks.ToString().Substring(10);

            var newId = _dao.Insert(c);
            return newId;
        }

        // 🔹 Cập nhật khóa học
        public bool UpdateCourse(Course c)
        {
            if (c == null) throw new ArgumentNullException(nameof(c));
            if (c.CourseId <= 0) throw new ArgumentException("Invalid CourseId");

            // kiểm tra trùng mã (ngoại trừ chính nó)
            if (_dao.ExistsCourseCode(c.CourseCode, c.CourseId))
                throw new ArgumentException("Course code already exists");

            return _dao.Update(c);
        }

        // 🔹 Xóa khóa học
        public bool DeleteCourse(int id)
        {
            if (id <= 0) return false;
            return _dao.Delete(id);
        }
    }
}
