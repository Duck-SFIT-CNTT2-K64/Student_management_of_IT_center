using Student_manager.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_manager.BLL
{
    public class ActionLogsService
    {
        private readonly ActionLogsDAO _logDAO = new ActionLogsDAO();
        public DataTable GetActionLogs()
        {
            return _logDAO.GetActionLogs();
        }
    }
}
