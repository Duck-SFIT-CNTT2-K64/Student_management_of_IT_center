using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_manager.Models
{
    public class NotificationRecipient
    {
        public int NotificationId { get; set; }
        public int RecipientId { get; set; }
        public bool IsRead { get; set; }
    }
}
