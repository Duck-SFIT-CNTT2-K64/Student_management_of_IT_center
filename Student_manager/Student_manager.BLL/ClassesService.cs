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
            if (string.IsNullOrWhiteSpace(c.ClassCode) || string.IsNullOrWhiteSpace(c.ClassName))
                return 0;

            if (_classesDAO.ClassCodeExists(c.ClassCode))
            {
                throw new Exception($"Mã lớp '{c.ClassCode}' đã tồn tại trong hệ thống.");
            }

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

