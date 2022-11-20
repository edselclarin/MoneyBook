using DateTimeExtensions;
using System.ComponentModel;

namespace MoneyBookTools.ViewModels
{
    public class ViewRecurringTransaction
    {
        public enum DueStateTypes
        {
            Past,     // Overdue
            Today,    // Due today
            Soon,     // Due by DueBeforeDay
            Upcoming, // Due in one week
            None      // Not due
        }

        /// <summary>
        /// Used to determine transactions due soon.
        /// </summary>
        public static DayOfWeek DueBeforeDay => DayOfWeek.Thursday;

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
        public DueStateTypes DueState => GetDueState();

        [Browsable(false)]
        public int CatId { get; set; }

        private DueStateTypes GetDueState()
        {
            if (DueDate.Date < DateTime.Now.Date)
            {
                return DueStateTypes.Past;
            }
            else if (DueDate.Date == DateTime.Now.Date)
            {
                return DueStateTypes.Today;
            }
            else if (DueDate.Date < DateTime.Now.GetDateOfTarget(DueBeforeDay).Date)
            {
                return DueStateTypes.Soon;
            }
            else if (DueDate.AddDays(-7).Date <= DateTime.Now.Date)
            {
                return DueStateTypes.Upcoming;
            }
            else
            {
                return DueStateTypes.None;
            }
        }
    }
}
