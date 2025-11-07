using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_manager.Models;
using Student_manager.DAL;

namespace Student_manager.BLL
{
    public class CourseService
    {
        private readonly CourseDAO _courseDAO;
        public CourseService(CourseDAO dao)
        {
            _courseDAO = dao;
        }
        // READ: Lấy toàn bộ danh sách khóa học (Phục vụ Load Form/DataGridview)
        public List<Course> GetAllCourses()
        {
            // Trực tiếp gọi hàm GetAll của DAL và trả về.
            return _courseDAO.GetAll();
        }
        // SEARCH: Tìm kiếm khóa học theo tên
        public List<Course> SearchCourses(string name)
        {
            // Kiểm tra nghiệp vụ: Nếu chuỗi tìm kiếm rỗng hoặc quá ngắn, có thể trả về danh sách rỗng
            if (string.IsNullOrWhiteSpace(name) || name.Length < 2)
            {
                // Có thể ném exception hoặc trả về danh sách rỗng, tùy quy tắc.
                return new List<Course>();
            }

            return _courseDAO.SearchByName(name);
        }
        // CREATE: Thêm khóa học (Nơi áp dụng logic nghiệp vụ)
        public string AddCourse(Course course)
        {
            // 1. Kiểm tra Validation (Kiểm tra dữ liệu đầu vào không hợp lệ)
            if (string.IsNullOrWhiteSpace(course.CourseCode) || string.IsNullOrWhiteSpace(course.CourseName))
            {
                return "Mã và Tên khóa học không được để trống.";
            }

            // 2. Kiểm tra quy tắc nghiệp vụ (Business Rules)
            // Kiểm tra xem Mã khóa học có bị trùng không
            if (_courseDAO.IsCourseCodeExists(course.CourseCode))
            {
                return $"Mã khóa học '{course.CourseCode}' đã tồn tại trong hệ thống.";
            }

            // Kiểm tra Học phí
            if (course.TuitionFee < 0)
            {
                return "Học phí không thể là số âm.";
            }

            // 3. Nếu mọi thứ hợp lệ, gọi DAL để thực thi
            if (_courseDAO.Add(course))
            {
                return "Thêm khóa học thành công.";
            }
            else
            {
                // Lỗi từ tầng DAL (lỗi kết nối, lỗi CSDL...)
                return "Thêm thất bại do lỗi hệ thống (DAL).";
            }
        }
        // UPDATE: Cập nhật khóa học
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
                // Lấy bản ghi hiện tại từ DB để debug / so sánh
                var existing = _courseDAO.GetById(course.CourseId);
                if (existing == null)
                    return "Không tìm thấy khóa học cần cập nhật.";

                // Debug logs (xem output window hoặc console)
                Console.WriteLine($"Updating CourseId={course.CourseId}, existingCode='{existing.CourseCode}', newCode='{course.CourseCode}'");

                // Nếu mã thay đổi thì kiểm tra trùng (loại trừ chính CourseId)
                bool codeChanged = !string.Equals(existing.CourseCode?.Trim(), course.CourseCode?.Trim(), StringComparison.OrdinalIgnoreCase);
                if (codeChanged)
                {
                    // Sử dụng overload có excludeCourseId để loại trừ chính bản ghi đang sửa
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
                // Log và trả thông báo chung
                Console.WriteLine("Error in UpdateCourse: " + ex);
                return "Lỗi khi cập nhật khóa học: " + ex.Message;
            }
        }
        // DELETE: Xóa khóa học
        public string DeleteCourse(int courseId)
        {
            // Ví dụ về Business Rule: Không cho xóa khóa học nếu có sinh viên đang đăng ký.
            // if (_studentDAO.CountStudentsInCourse(courseId) > 0)
            // {
            //     return "Không thể xóa khóa học này vì có sinh viên đang theo học.";
            // }

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

