using Student_manager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_manager.DAL
{
    public class StudentDAO
    {
        private DataProcesser _db;
        public StudentDAO() { _db = new DataProcesser(); }

        public Student GetStudentByCode(string studentCode)
        {
            string safeCode = studentCode.Replace("'", "''");
            string sql = "SELECT StudentId, StudentCode FROM Students WHERE StudentCode = '" + safeCode + "'";

            DataTable dt = _db.DocBang(sql);

            if (dt.Rows.Count > 0)
            {
                return new Student
                {
                    StudentId = (int)dt.Rows[0]["StudentId"],
                    StudentCode = (string)dt.Rows[0]["StudentCode"]
                };
            }
            return null;
        }
    }
}
