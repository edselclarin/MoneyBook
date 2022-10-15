using MoneyBook.BusinessModels;
using MoneyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBookTools.ViewModels
{
    public static class ViewModelsExtension
    {
        public static IEnumerable<ViewAccount> AsViewAccounts(this IEnumerable<AccountInfo> accounts)
        {
            return accounts.Select(acct => new ViewAccount
            {
                AcctId = acct.AcctId,
                Account = acct.AccountName,
                StartingBalance = acct.StartingBalance,
                ReserveAmount = acct.ReserveAmount,
                Credits = acct.Credits,
                Debits = acct.Debits,
                Balance = acct.Balance,
                AvailableBalance = acct.Balance,
                DateModified = acct.DateModified,
                InstId = acct.InstId
            });
        }

        //public static IEnumerable<ViewTransaction> AsViewTransactions(this IEnumerable<TransactionInfo> transactions)
        //{
        //    return transactions.Select(tran => new ViewTransaction
        //    {

        //    });
        //}
    }
}
