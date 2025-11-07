using System;

namespace Student_manager.Models
{
    public class FeaturedTeacher
    {
        public int FeaturedId { get; set; }
        public int? TeacherId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string ImagePath { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
