using Student_manager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_manager.DAL
{
    public class ClassDAO
    {
        private DataProcesser _db;
        public ClassDAO() { _db = new DataProcesser(); }

        public Class GetClassByCode(string classCode)
        {
            string safeCode = classCode.Replace("'", "''");
            string sql = "SELECT ClassId, CourseId, ClassCode FROM Classes WHERE ClassCode = '" + safeCode + "'";

            DataTable dt = _db.DocBang(sql);

            if (dt.Rows.Count > 0)
            {
                return new Class
                {
                    ClassId = (int)dt.Rows[0]["ClassId"],
                    CourseId = (int)dt.Rows[0]["CourseId"],
                    ClassCode = (string)dt.Rows[0]["ClassCode"]
                };
            }
            return null;
        }
    }
}
