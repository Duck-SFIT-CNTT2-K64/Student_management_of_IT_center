using System;

namespace Student_manager.Models
{
    public class Report
    {
        public int ReportId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}