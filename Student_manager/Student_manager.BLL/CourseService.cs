using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_manager.Models;
using Student_manager.DAL;
using System.Collections.Generic;

namespace Student_manager.BLL
{
    public class CourseService
    {
        private readonly CourseDAO _courseDAO;

        public CourseService(CourseDAO dao)
        {
            _courseDAO = dao;
        }

        public CourseService() : this(new CourseDAO())
        {
        }

        public List<Course> GetAllCourses()
        {
            return _courseDAO.GetAll();
        }

        public Course GetCourseById(int id)
        {
            if (id <= 0) return null;
            return _courseDAO.GetById(id); 
        }

        public List<Course> SearchCourses(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 2)
            {
                return new List<Course>();
            }
            return _courseDAO.SearchByName(name);
        }

        public string AddCourse(Course course)
        {
            if (string.IsNullOrWhiteSpace(course.CourseName))
            {
                return "Tên khóa học không được để trống.";
            }

            
            if (string.IsNullOrWhiteSpace(course.CourseCode))
            {
                course.CourseCode = "CRS" + DateTime.Now.Ticks.ToString().Substring(10);
            }
            else
            {
                if (_courseDAO.IsCourseCodeExists(course.CourseCode))
                {
                    return $"Mã khóa học '{course.CourseCode}' đã tồn tại trong hệ thống.";
                }
            }

            if (course.TuitionFee < 0)
            {
                return "Học phí không thể là số âm.";
            }

            if (_courseDAO.Add(course))
            {
                return "Thêm khóa học thành công.";
            }
            else
            {
                return "Thêm thất bại do lỗi hệ thống (DAL).";
            }
        }

        public string UpdateCourse(Course course)
        {
            if (course == null) return "Dữ liệu khóa học không hợp lệ.";

            if (course.CourseId <= 0)
                return "Không tìm thấy CourseId để cập nhật.";

            if (string.IsNullOrWhiteSpace(course.CourseCode) || string.IsNullOrWhiteSpace(course.CourseName))
                return "Mã và Tên khóa học không được để trống.";

            if (course.TuitionFee < 0)
                return "Học phí không thể là số âm.";

            try
            {
                var existing = _courseDAO.GetById(course.CourseId);
                if (existing == null)
                    return "Không tìm thấy khóa học cần cập nhật.";

                bool codeChanged = !string.Equals(existing.CourseCode?.Trim(), course.CourseCode?.Trim(), StringComparison.OrdinalIgnoreCase);
                if (codeChanged)
                {
                    if (_courseDAO.IsCourseCodeExists(course.CourseCode, course.CourseId))
                    {
                        return $"Mã khóa học '{course.CourseCode}' đã bị trùng với khóa học khác.";
                    }
                }

                if (_courseDAO.Update(course))
                    return "Cập nhật khóa học thành công.";
                else
                    return "Cập nhật thất bại do lỗi hệ thống (DAL).";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in UpdateCourse: " + ex);
                return "Lỗi khi cập nhật khóa học: " + ex.Message;
            }
        }

        public string DeleteCourse(int courseId)
        {
            if (_courseDAO.Delete(courseId))
            {
                return "Xóa khóa học thành công.";
            }
            else
            {
                return "Xóa thất bại do lỗi hệ thống (DAL).";
            }
        }
    }
}