using MoneyBook.BusinessModels;
using System.Reflection;
using System.Text;

namespace MoneyBookTools.ViewModels
{
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
                TrnsAmount = tran.Amount,
                Frequency = tran.Frequency,
                AcctId = tran.AcctId,
                CatId = tran.CatId
            });
        }
    }
}
