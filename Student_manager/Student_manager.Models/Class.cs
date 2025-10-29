using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_manager.Models
{
    public class Class
    {
        public int ClassId { get; set; }
        public int CourseId { get; set; }
        public int? TeacherId { get; set; }
        public string ClassCode { get; set; }
        public string ClassName { get; set; }
        public int? MaxStudents { get; set; }
    }
}
