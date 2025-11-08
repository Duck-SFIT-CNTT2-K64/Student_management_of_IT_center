using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_manager.Models;
using Student_manager.DAL;
// Đã xóa "using System.Collections.Generic;" bị lặp
using System.Collections.Generic;

namespace Student_manager.BLL
{
    public class CourseService
    {
        private readonly CourseDAO _courseDAO;

        // Giữ lại Constructor Injection (từ feature/UI)
        public CourseService(CourseDAO dao)
        {
            _courseDAO = dao;
        }

        // READ: Lấy toàn bộ danh sách khóa học (từ feature/UI)
        public List<Course> GetAllCourses()
        {
            return _courseDAO.GetAll();
        }

        // READ: Lấy 1 khóa học theo ID (Thêm từ nhánh main)
        public Course GetCourseById(int id)
        {
            if (id <= 0) return null;
            // Giả sử DAO của bạn có hàm GetById
            return _courseDAO.GetById(id); 
        }

        // SEARCH: Tìm kiếm khóa học theo tên (từ feature/UI)
        public List<Course> SearchCourses(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 2)
            {
                return new List<Course>();
            }
            return _courseDAO.SearchByName(name);
        }

        // CREATE: Thêm khóa học (Gộp logic từ cả 2 nhánh)
        public string AddCourse(Course course)
        {
            // 1. Kiểm tra Validation
            if (string.IsNullOrWhiteSpace(course.CourseName))
            {
                return "Tên khóa học không được để trống.";
            }

            // 2. Kiểm tra quy tắc nghiệp vụ (Business Rules)
            
            // Logic từ nhánh main: Tự động tạo mã nếu trống
            if (string.IsNullOrWhiteSpace(course.CourseCode))
            {
                course.CourseCode = "CRS" + DateTime.Now.Ticks.ToString().Substring(10);
            }
            else
            {
                // Logic từ nhánh feature/UI: Nếu mã được cung cấp, kiểm tra trùng
                if (_courseDAO.IsCourseCodeExists(course.CourseCode))
                {
                    return $"Mã khóa học '{course.CourseCode}' đã tồn tại trong hệ thống.";
                }
            }

            // Logic từ nhánh feature/UI: Kiểm tra Học phí
            if (course.TuitionFee < 0)
            {
                return "Học phí không thể là số âm.";
            }

            // 3. Nếu mọi thứ hợp lệ, gọi DAL (theo kiểu trả về string của feature/UI)
            if (_courseDAO.Add(course))
            {
                return "Thêm khóa học thành công.";
            }
            else
            {
                return "Thêm thất bại do lỗi hệ thống (DAL).";
            }
        }

        // UPDATE: Cập nhật khóa học (Giữ phiên bản feature/UI vì chi tiết hơn)
        public string UpdateCourse(Course course)
        {
            if (course == null) return "Dữ liệu khóa học không hợp lệ.";

            // Validation
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

                Console.WriteLine($"Updating CourseId={course.CourseId}, existingCode='{existing.CourseCode}', newCode='{course.CourseCode}'");

                // Logic kiểm tra trùng mã (cả hai nhánh đều có)
                bool codeChanged = !string.Equals(existing.CourseCode?.Trim(), course.CourseCode?.Trim(), StringComparison.OrdinalIgnoreCase);
                if (codeChanged)
                {
                    if (_courseDAO.IsCourseCodeExists(course.CourseCode, course.CourseId))
                    {
                        return $"Mã khóa học '{course.CourseCode}' đã bị trùng với khóa học khác.";
                    }
                }

                // Gọi DAL để cập nhật
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

        // DELETE: Xóa khóa học (Giữ phiên bản feature/UI)
        public string DeleteCourse(int courseId)
        {
            // if (_studentDAO.CountStudentsInCourse(courseId) > 0) { ... }

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