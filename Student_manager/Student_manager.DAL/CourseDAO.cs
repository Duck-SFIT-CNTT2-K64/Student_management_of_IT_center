using Student_manager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_manager.DAL
{
    public class CourseDAO
    {
        private DataProcesser _db;
        public CourseDAO() { _db = new DataProcesser(); }

        public Course GetCourseById(int courseId)
        {
            string sql = "SELECT CourseId, TuitionFee FROM Courses WHERE CourseId = " + courseId;
            DataTable dt = _db.DocBang(sql);

            if (dt.Rows.Count > 0)
            {
                return new Course
                {
                    CourseId = (int)dt.Rows[0]["CourseId"],
                    TuitionFee = (decimal)dt.Rows[0]["TuitionFee"]
                };
            }
            return null;
        }
    }
}
