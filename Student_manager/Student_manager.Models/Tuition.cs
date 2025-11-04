using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_manager.Models
{
    public class Tuition
    {
        public int TuitionId { get; set; }
        public int EnrollmentId { get; set; }
        public decimal TotalFee { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime? DueDate { get; set; }
        public string Status { get; set; }
    }
}
