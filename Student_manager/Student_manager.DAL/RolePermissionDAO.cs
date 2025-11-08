using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_manager.DAL
{
    public class RolePermissionDAO
    {
        private DataProcesser _db;
        public RolePermissionDAO() { _db = new DataProcesser(); }
        public List<int> GetPermissionIdsForRole(int roleId)
        {
            List<int> ids = new List<int>();
            string sql = "SELECT PermissionId FROM RolePermissions WHERE RoleId = " + roleId;
            DataTable dt = _db.DocBang(sql);
            foreach (DataRow row in dt.Rows)
            {
                ids.Add((int)row["PermissionId"]);
            }
            return ids;
        }
        public bool UpdatePermissionsForRole(int roleId, List<int> permissionIds, SqlConnection conn, SqlTransaction trans)
        {
            // 1. Xóa hết quyền cũ của vai trò này
            string sqlDelete = "DELETE FROM RolePermissions WHERE RoleId = " + roleId;
            using (SqlCommand cmdDel = new SqlCommand(sqlDelete, conn, trans))
            {
                cmdDel.ExecuteNonQuery();
            }

            // 2. Thêm lại các quyền mới (đã được tick)
            foreach (int permId in permissionIds)
            {
                string sqlInsert = string.Format(
                    "INSERT INTO RolePermissions (RoleId, PermissionId) VALUES ({0}, {1})",
                    roleId, permId
                );
                using (SqlCommand cmdIns = new SqlCommand(sqlInsert, conn, trans))
                {
                    cmdIns.ExecuteNonQuery();
                }
            }
            return true;
        }
    }
}

