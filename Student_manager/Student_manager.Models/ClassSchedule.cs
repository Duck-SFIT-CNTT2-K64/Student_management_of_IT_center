using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_manager.Models
{
    public class ClassSchedule
    {
        public int ScheduleId { get; set; }
        public int ClassId { get; set; }
        public int? RoomId { get; set; }
        public string Weekday { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
