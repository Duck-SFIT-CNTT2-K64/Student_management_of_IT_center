using System;
using System.Data;
using Student_manager.DAL;

namespace Student_manager.DAL
{
    public class TuitionDAO
    {
        private readonly DataProcesser _dp = new DataProcesser();

        // returns total fees and total collected (AmountPaid) across all tuitions
        public (decimal TotalFee, decimal AmountPaid) GetTotals()
        {
            try
            {
                var dt = _dp.DocBang("SELECT ISNULL(SUM(TotalFee),0) AS TotalFee, ISNULL(SUM(AmountPaid),0) AS AmountPaid FROM Tuitions");
                if (dt == null || dt.Rows.Count == 0) return (0m, 0m);
                var r = dt.Rows[0];
                decimal totalFee = 0m;
                decimal amountPaid = 0m;
                try { totalFee = Convert.ToDecimal(r["TotalFee"]); } catch { totalFee = 0m; }
                try { amountPaid = Convert.ToDecimal(r["AmountPaid"]); } catch { amountPaid = 0m; }
                return (totalFee, amountPaid);
            }
            catch
            {
                return (0m, 0m);
            }
        }
    }
}
