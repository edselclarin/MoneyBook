using MoneyBook.Data;
using MoneyBook.Models;
using MoneyBookTools.ViewModels;

namespace MoneyBookTools.Extensions
{
    public static class MoneyBookToolsExtensions
    {
        public static Transaction ToTransaction(this ViewTransaction transaction)
        {
            var trn = new Transaction();
            trn.TrnsId = transaction.TrnsId;
            trn.AcctId = transaction.AcctId;
            trn.TrnsType = transaction.TrnsType;
            trn.CatId = 0;
            trn.Date = transaction.Date;
            trn.Payee = transaction.Payee;
            trn.RefNum = transaction.RefNum;
            trn.Memo = transaction.Memo;
            trn.State = transaction.State;
            trn.ExtTrnsId = string.Empty;
            if (transaction.NewAmount < 0)
            {
                trn.TrnsType = TransactionTypes.DEBIT.ToString();
                trn.Amount = Math.Abs(transaction.NewAmount);
            }
            else
            {
                trn.TrnsType = TransactionTypes.CREDIT.ToString();
                trn.Amount = transaction.NewAmount;
            }
            trn.DateAdded =
            trn.DateModified = DateTime.Now.Date;
            return trn;
        }

        public static IList<Transaction> ToTransactionInfos(this IList<ViewTransaction> transactions)
        {
            return transactions
                .Select(tran => new Transaction
                {
                    TrnsId = tran.TrnsId,
                    Date = tran.Date,
                    TrnsType = tran.TrnsType,
                    RefNum = tran.RefNum,
                    Payee = tran.Payee,
                    Memo = tran.Memo,
                    State = tran.State,
                    Amount = tran.Amount,
                    AcctId = tran.AcctId,
                })
                .ToList();
        }

        public static IEnumerable<ViewTransaction> ToViewTransactions(this IEnumerable<Transaction> transactions)
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

        public static IEnumerable<ViewReminder> ToViewReminders(this IEnumerable<Reminder> reminder)
        {
            return reminder.Select(tran => new ViewReminder
            {
                RmdrId = tran.RmdrId,
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

        public static IEnumerable<Reminder> ToReminders(this IEnumerable<ViewReminder> reminder)
        {
            return reminder.Select(rem => new Reminder
            {
                RmdrId = rem.RmdrId,
                DueDate = rem.DueDate,
                TrnsType = rem.TrnsType,
                Payee = rem.Payee,
                Memo = rem.Memo,
                Website = rem.Website,
                Amount = rem.NewAmount,
                Frequency = rem.Frequency,
                AcctId = rem.AcctId,
                CatId = rem.CatId
            });
        }

        public static Reminder ToReminder(this ViewReminder reminder)
        {
            return new Reminder
            {
                RmdrId = reminder.RmdrId,
                DueDate = reminder.DueDate,
                TrnsType = reminder.NewAmount < 0 ? TransactionTypes.DEBIT.ToString() : TransactionTypes.CREDIT.ToString(),
                Payee = reminder.Payee,
                Memo = reminder.Memo,
                Website = reminder.Website,
                Amount = Math.Abs(reminder.NewAmount),
                Frequency = reminder.Frequency,
                AcctId = reminder.AcctId,
                CatId = reminder.CatId
            };
        }
    }
}
