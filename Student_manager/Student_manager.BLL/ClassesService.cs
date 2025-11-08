using Student_manager.DAL;
using Student_manager.Models;
using System;
using System.Collections.Generic;

namespace Student_manager.Services
{
    public class ClassesService
    {
        private readonly ClassesDAO _classesDAO = new ClassesDAO();

        public List<Class> GetAllClasses()
        {
            return _classesDAO.GetAllClasses();
        }

        public Class GetClassById(int id)
        {
            return _classesDAO.GetClassById(id);
        }

        public int AddClass(Class c)
        {
            // 1. Kiểm tra dữ liệu đầu vào cơ bản
            if (string.IsNullOrWhiteSpace(c.ClassCode) || string.IsNullOrWhiteSpace(c.ClassName))
                return 0;

            // 2. ⚠️ KIỂM TRA TRÙNG LẶP CLASS CODE
            if (_classesDAO.ClassCodeExists(c.ClassCode))
            {
                // Ném ra exception với thông báo rõ ràng
                throw new Exception($"Mã lớp '{c.ClassCode}' đã tồn tại trong hệ thống.");
            }

            // 3. Thực hiện thêm vào DB
            // Giả định _classesDAO.AddClass() đã được sửa để trả về ID mới (int)
            return _classesDAO.AddClass(c);
        }

        public bool UpdateClass(Class c)
        {
            if (c.ClassId <= 0) return false;
            return _classesDAO.UpdateClass(c);
        }

        public bool DeleteClass(int id)
        {
            return _classesDAO.DeleteClass(id);
        }
    }
}

