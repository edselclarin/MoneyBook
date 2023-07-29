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

        [Browsable(false)]
        public int AcctId { get; set; }

        public string Account { get; set; }

        public string Payee { get; set; }

        public string Memo { get; set; }

        public string Website { get; set; }

        [Browsable(false)]
        public decimal TrnsAmount { get; set; }

        public string Frequency { get; set; }

        public decimal Amount => TrnsType == "DEBIT" ? 0 - TrnsAmount : TrnsAmount;

        [Browsable(false)]
        public decimal NewAmount { get; set; }

        [Browsable(false)]
        public int CatId { get; set; }
    }
}
