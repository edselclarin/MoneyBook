﻿using MoneyBook.BusinessModels;

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
                Amount = tran.Amount,
                Frequency = tran.Frequency,
                AcctId = tran.AcctId,
                CatId = tran.CatId
            });
        }
    }
}