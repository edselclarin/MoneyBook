using DateTimeExtensions;
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
        public bool IsOverdue => DueDate.Date < DateTime.Now.Date;

        [Browsable(false)]
        public bool IsDueToday => DueDate.Date == DateTime.Now.Date;

        [Browsable(false)]
        public bool IsDueInOneWeek => DueDate.AddDays(-7).Date <= DateTime.Now.Date;

        [Browsable(false)]
        public bool IsDueBefore(DayOfWeek dow) => DueDate.Date < DateTime.Now.GetDateOfTarget(dow).Date;

        [Browsable(false)]
        public int CatId { get; set; }
    }
}
