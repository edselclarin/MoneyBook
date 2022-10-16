using System.ComponentModel;

namespace MoneyBookTools.ViewModels
{
    public class ViewRecurringTransaction
    {
        [Browsable(false)]
        public int RecTrnsId { get; set; }

        public DateTime DueDate { get; set; }
        
        [Browsable(false)]
        public string TrnsType { get; set; }

        public string Payee { get; set; }

        public decimal Amount { get; set; }

        [Browsable(false)]
        public int AcctId { get; set; }
    }
}
