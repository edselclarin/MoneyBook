using MoneyBook.BusinessModels;
using MoneyBookTools.Forms;
using System.Reflection;
using System.Text;

namespace MoneyBookTools.ViewModels
{
    public enum DueStateTypes
    {
        Past,     // Overdue
        Today,    // Due today
        Soon,     // Due by DueBeforeDay
        Upcoming, // Due in one week
        None      // Not due
    }

    public static class ViewModelsExtension
    {
        public static string GetHash<T>(this T obj)
        {
            var sb = new StringBuilder();
            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                var val = prop.GetValue(obj);
                sb.Append(val != null ? val.ToString() : "(null)");
            }
            return sb.ToString();
        }

        public static IEnumerable<ViewAccount> AsViewAccounts(this IEnumerable<AccountInfo> accounts)
        {
            return accounts.Select(acct => new ViewAccount
            {
                AcctId = acct.AcctId,
                Account = acct.AccountName,
            });
        }

        public static IEnumerable<ViewTransaction> AsViewTransactions(this IEnumerable<TransactionInfo> transactions)
        {
            return transactions.Select(tran => new ViewTransaction
            {
                TrnsId = tran.TrnsId,
                Date = tran.Date,
                TrnsType = tran.TrnsType,
                RefNum = tran.RefNum,
                Payee = tran.Payee,
                Memo = tran.Memo,
                State = tran.State,
                TrnsAmount = tran.Amount,
                AcctId = tran.AcctId,
            });
        }

        public static IEnumerable<ViewRecurringTransaction> AsViewRecurringTransactions(this IEnumerable<RecurringTransactionInfo> transactions)
        {
            return transactions.Select(tran => new ViewRecurringTransaction
            {
                RecTrnsId = tran.RecTrnsId,
                DueDate = tran.DueDate,
                TrnsType = tran.TrnsType,
                Payee = tran.Payee,
                Memo = tran.Memo,
                Website = tran.Website,
                TrnsAmount = tran.Amount,
                Frequency = tran.Frequency,
                AcctId = tran.AcctId,
                CatId = tran.CatId
            });
        }

        public static DueStateTypes GetDueState(this ViewRecurringTransaction recTrans)
        {
            if (recTrans.DueDate.Date < DateTime.Now.Date)
            {
                return DueStateTypes.Past;
            }
            else if (recTrans.DueDate.Date == DateTime.Now.Date)
            {
                return DueStateTypes.Today;
            }
            else if (recTrans.DueDate.Date < DateTime.Now.GetDateOfTarget(ViewSettings.Instance.DueBeforeDay).Date)
            {
                return DueStateTypes.Soon;
            }
            else if (recTrans.DueDate.AddDays(-7).Date <= DateTime.Now.Date)
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
