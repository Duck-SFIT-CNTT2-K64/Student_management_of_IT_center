using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_manager.DAL
{
    public static class SqlHelper
    {
        public static SqlConnection GetConnection()
        {
            var cs = ConfigurationManager.ConnectionStrings["StudentDB"].ConnectionString;
            return new SqlConnection(cs);
        }
    }
}
