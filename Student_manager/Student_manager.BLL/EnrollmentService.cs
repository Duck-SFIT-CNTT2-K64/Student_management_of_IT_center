using Student_manager.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_manager.Models;

namespace Student_manager.BLL
{
    public class EnrollmentService
    {


        private readonly StudentDAO _studentDAO;
        private readonly ClassDAO _classDAO;
        private readonly CourseDAO _courseDAO;
        private readonly EnrollmentDAO _enrollmentDAO;
        private readonly TuitionDAO _tuitionDAO;

        public EnrollmentService()
        {
            _studentDAO = new StudentDAO();
            _classDAO = new ClassDAO();
            _courseDAO = new CourseDAO();
            _enrollmentDAO = new EnrollmentDAO();
            _tuitionDAO = new TuitionDAO();
        }

        public bool EnrollStudent(string studentCode, string classCode, out string errorMessage)
        {
            
            if (string.IsNullOrWhiteSpace(studentCode) || string.IsNullOrWhiteSpace(classCode))
            {
                errorMessage = "Student ID and Class ID are required.";
                return false;
            }

            var student = _studentDAO.GetStudentByCode(studentCode);
            if (student == null) { errorMessage = "Student not found."; return false; }

            var cls = _classDAO.GetClassByCode(classCode);
            if (cls == null) { errorMessage = "Class not found."; return false; }

            var course = _courseDAO.GetCourseById(cls.CourseId);
            if (course == null) { errorMessage = "Course fee not found."; return false; }

            
            using (SqlConnection conn = SqlHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    
                    int newEnrollmentId = _enrollmentDAO.AddEnrollment(student.StudentId, cls.ClassId, conn, trans);

                    
                    DateTime dueDate = DateTime.Now.AddDays(15);
                    _tuitionDAO.AddTuition(newEnrollmentId, course.TuitionFee, dueDate, conn, trans);

                    trans.Commit();
                    errorMessage = string.Empty;
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    errorMessage = "Database error: " + ex.Message;
                    return false;
                }
            }
        }
        public DataTable GetEnrollmentList(string studentCode, string classCode)
        {
            
            return _enrollmentDAO.SearchEnrollments(studentCode, classCode);
        }
    }
}

