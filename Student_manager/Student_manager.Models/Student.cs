using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_manager.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        // Liên kết 1-1 với Users
        public int UserId { get; set; }

        public int? StatusId { get; set; } // có thể null nếu chưa có trạng thái

        public string StudentCode { get; set; }

        public string FullName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

    }
}
