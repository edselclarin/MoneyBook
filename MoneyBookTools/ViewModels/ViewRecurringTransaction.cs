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

        public string Memo { get; set; }

        [Browsable(false)]
        public decimal TrnsAmount { get; set; }

        public decimal Amount => TrnsType == "DEBIT" ? 0 - TrnsAmount : TrnsAmount;

        public string Frequency { get; set; }

        [Browsable(false)]
        public bool IsOverdue => DueDate.Date < DateTime.Now.Date;

        [Browsable(false)]
        public bool IsDueToday => DueDate.Date == DateTime.Now.Date;

        /// <summary>
        /// In 5 days.
        /// </summary>
        [Browsable(false)]
        public bool IsDueSoon => DueDate.AddDays(-5).Date <= DateTime.Now.Date;

        [Browsable(false)]
        public int AcctId { get; set; }

        [Browsable(false)]
        public int CatId { get; set; }
    }
}
