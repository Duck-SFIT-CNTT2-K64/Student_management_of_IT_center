using Student_manager.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_manager.BLL
{
    public class RoleService
    {
        private readonly RoleSystemDAO _roleDAO;
        private readonly PermissionDAO _permissionDAO;
        private readonly RolePermissionDAO _rolePermissionDAO;

        public RoleService()
        {
            _roleDAO = new RoleSystemDAO();
            _permissionDAO = new PermissionDAO();
            _rolePermissionDAO = new RolePermissionDAO();
        }
        public DataTable GetRoles() { return _roleDAO.GetRoles(); }
        public DataTable GetPermissions() { return _permissionDAO.GetPermissions(); }
        public List<int> GetPermissionIdsForRole(int roleId)
        {
            return _rolePermissionDAO.GetPermissionIdsForRole(roleId);
        }
        public bool SavePermissionsForRole(int roleId, List<int> permissionIds, out string errorMessage)
        {
            using (SqlConnection conn = SqlHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    _rolePermissionDAO.UpdatePermissionsForRole(roleId, permissionIds, conn, trans);
                    trans.Commit();
                    errorMessage = string.Empty;
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    errorMessage = "Database error: " + ex.Message;
                    return false;
                }
            }
        }

    }
}
