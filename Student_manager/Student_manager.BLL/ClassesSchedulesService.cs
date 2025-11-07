using Student_manager.DAL;
using Student_manager.Models;
using System.Collections.Generic;

namespace Student_manager.Services
{
    public class ClassSchedulesService
    {
        private readonly ClassSchedulesDAO _scheduleDAO = new ClassSchedulesDAO();

        public List<ClassSchedule> GetSchedulesByClass(int? classId = null)
        {
            return _scheduleDAO.GetSchedulesByClassId(classId);
        }

        public bool AddSchedule(ClassSchedule s)
        {
            if (s.ClassId <= 0 || string.IsNullOrWhiteSpace(s.Weekday))
                return false;
            return _scheduleDAO.AddSchedule(s);
        }

        public bool UpdateSchedule(ClassSchedule s)
        {
            if (s.ScheduleId <= 0) return false;
            return _scheduleDAO.UpdateSchedule(s);
        }

        public bool DeleteSchedule(int scheduleId)
        {
            return _scheduleDAO.DeleteSchedule(scheduleId);
        }
    }
}

