using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_manager.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public int EnrollmentId { get; set; }
        public DateTime SessionDate { get; set; }
        public string Status { get; set; }
    }
}
