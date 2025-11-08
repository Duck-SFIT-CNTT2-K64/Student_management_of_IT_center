using System;

namespace Student_manager.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public string Status { get; set; }
        public Student Student { get; set; }
    }
}
