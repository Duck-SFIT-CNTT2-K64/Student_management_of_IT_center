using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_manager.Models
{
    public class Score
    {
        public int ScoreId { get; set; }
        public int EnrollmentId { get; set; }
        public int ScoreTypeId { get; set; }
        public decimal ScoreValue { get; set; }
    }
}
