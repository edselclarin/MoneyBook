using System.ComponentModel;

namespace MoneyBookTools.ViewModels
{
    public class ViewTransaction
    {
        [Browsable(false)]
        public int TrnsId { get; set; }

        public DateTime Date { get; set; }

        [Browsable(false)]
        public string TrnsType { get; set; }

        public string RefNum { get; set; }
        
        public string Payee { get; set; }
        
        public string Memo { get; set; }
        
        public string State { get; set; }

        [Browsable(false)]
        public decimal TrnsAmount { get; set; }

        [Browsable(false)]
        public int AcctId { get; set; }

        public decimal Amount => TrnsType == "DEBIT" ? 0 - TrnsAmount : TrnsAmount;

        [Browsable(false)]
        public decimal NewAmount { get; set; }

        [Browsable(false)]
        public bool Modified { get; set; }
    }
}
