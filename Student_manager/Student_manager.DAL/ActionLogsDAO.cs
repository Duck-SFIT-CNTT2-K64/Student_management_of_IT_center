using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_manager.DAL
{
    public class ActionLogsDAO
    {
        private DataProcesser _db;
        public ActionLogsDAO() { _db = new DataProcesser(); }
        public DataTable GetActionLogs()
        {
            string sql = @"SELECT a.LogId, u.Username, a.Action, a.Details, a.LogDate 
                           FROM ActionLogs a
                           JOIN Users u ON a.UserId = u.UserId
                           ORDER BY a.LogId ASC"; // <-- Đã sửa

            return _db.DocBang(sql);
        }
    }
}
