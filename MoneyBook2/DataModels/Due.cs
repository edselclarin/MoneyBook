using MoneyBook.Data;
using MoneyBook.Extensions;
using MoneyBook.Models;

namespace MoneyBook2.DataModels
{
    public class Due : Reminder
    {
        public bool IsSelected { get; set; }

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
    }
}
