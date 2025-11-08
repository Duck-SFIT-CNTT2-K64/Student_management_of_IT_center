using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_manager.DAL
{
    public class PermissionDAO
    {
        private DataProcesser _db;
        public PermissionDAO() { _db = new DataProcesser(); }
        public DataTable GetPermissions()
        {
            string sql = "SELECT PermissionId, PermissionName FROM Permissions ORDER BY PermissionId ASC";
            return _db.DocBang(sql);
        }
    }
}
