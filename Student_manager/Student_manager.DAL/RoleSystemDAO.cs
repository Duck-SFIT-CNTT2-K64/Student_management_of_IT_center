using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_manager.DAL
{
    public class RoleSystemDAO
    {
        private DataProcesser _db;
        public RoleSystemDAO() { _db = new DataProcesser(); }

        public DataTable GetRoles()
        {
            return _db.DocBang("SELECT RoleId, RoleName FROM Roles");
        }

    }
}
