using MoneyBook.Data;
using MoneyBook.Extensions;
using MoneyBook.Models;

namespace MoneyBook2.DataModels
{
    public class Due : Reminder
    {
        public bool IsChecked { get; set; }

        public string AccountName { get; set; }

        public DueStateTypes DueState => MoneyBookExtensions.GetDueState(DueDate);

        public static Due FromReminder(Reminder r)
        {
            return new Due()
            {
                RmdrId = r.RmdrId,
                DueDate = r.DueDate,
                TrnsType = r.TrnsType,
                Payee = r.Payee,
                Memo = r.Memo,
                Website = r.Website,
                Amount = r.TrnsType == TransactionTypes.DEBIT.ToString()
                    ? -r.Amount
                    : r.Amount,
                Frequency = r.Frequency,
                DateAdded = r.DateAdded,
                DateModified = r.DateModified,
                AcctId = r.AcctId,
                CatId = r.CatId,
                IsDeleted = r.IsDeleted,
            };
        }

        /// <summary>
        /// Determines whether the current reminder has the same values as the specified <see cref="Reminder"/>
        /// instance.
        /// </summary>
        /// <param name="reminder">The <see cref="Reminder"/> to compare with the current reminder. Cannot be <c>null</c>.</param>
        /// <returns><see langword="true"/> if all properties of the current reminder, except RmdrId, AcctId and CatId, match those of the specified <paramref
        /// name="reminder"/>; otherwise, <see langword="false"/>. NOTE: RmdrId, AcctId and CatId are excluded because 
        /// they change during restoring database.</returns>
        public bool Matches(Reminder reminder)
        {
            return DueDate == reminder.DueDate
                && TrnsType == reminder.TrnsType
                && Payee == reminder.Payee
                && Memo == reminder.Memo
                && Website == reminder.Website
                && Amount == (reminder.TrnsType == TransactionTypes.DEBIT.ToString() ? -reminder.Amount : reminder.Amount)
                && Frequency == reminder.Frequency
                && DateAdded == reminder.DateAdded
                && DateModified == reminder.DateModified
                && IsDeleted == reminder.IsDeleted;
        }
    }
}
