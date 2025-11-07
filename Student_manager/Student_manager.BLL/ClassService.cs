using Student_manager.DAL;
using Student_manager.Models;
using System;
using System.Collections.Generic;

namespace Student_manager.BLL
{
    public class ClassService
    {
        private readonly ClassDAO _dao = new ClassDAO();

        // 🔹 Lấy tất cả lớp học
        public IEnumerable<Class> GetAllClasses()
        {
            return _dao.GetAll();
        }

        // 🔹 Lấy lớp học theo ID
        public Class GetClass(int id)
        {
            if (id <= 0) return null;
            return _dao.GetById(id);
        }

        // 🔹 Lấy danh sách lớp theo CourseId (phục vụ cho cboClass)
        public IEnumerable<Class> GetClassesByCourseId(int courseId)
        {
            if (courseId <= 0) return new List<Class>();
            return _dao.GetByCourseId(courseId);
        }

        // 🔹 Thêm lớp mới
        public int CreateClass(Class c)
        {
            if (c == null) throw new ArgumentNullException(nameof(c));
            if (string.IsNullOrWhiteSpace(c.ClassName))
                throw new ArgumentException("Class name is required");

            // kiểm tra trùng mã lớp
            if (_dao.ExistsClassCode(c.ClassCode))
                throw new ArgumentException("Class code already exists");

            if (string.IsNullOrWhiteSpace(c.ClassCode))
                c.ClassCode = "CLS" + DateTime.Now.Ticks.ToString().Substring(10);

            return _dao.Insert(c);
        }

        // 🔹 Cập nhật lớp học
        public bool UpdateClass(Class c)
        {
            if (c == null) throw new ArgumentNullException(nameof(c));
            if (c.ClassId <= 0) throw new ArgumentException("Invalid ClassId");

            // kiểm tra trùng mã lớp trừ chính nó
            if (_dao.ExistsClassCode(c.ClassCode, c.ClassId))
                throw new ArgumentException("Class code already exists");

            return _dao.Update(c);
        }

        // 🔹 Xóa lớp học
        public bool DeleteClass(int id)
        {
            if (id <= 0) return false;
            return _dao.Delete(id);
        }
    }
}
