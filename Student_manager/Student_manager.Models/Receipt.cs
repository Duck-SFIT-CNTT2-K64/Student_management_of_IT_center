using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_manager.Models
{
    public class Receipt
    {
        public int ReceiptId { get; set; }
        public int TuitionId { get; set; }
        public int CashierId { get; set; }
        public string ReceiptCode { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Note { get; set; }
    }
}
