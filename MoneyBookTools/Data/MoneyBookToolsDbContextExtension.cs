using MoneyBook.BusinessModels;
using MoneyBook.Data;
using MoneyBook.Models;
using MoneyBookTools.ViewModels;

namespace MoneyBookTools.Data
{
    public static class MoneyBookToolsDbContextExtension
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
            trn.ExtTrnsId = String.Empty;
            if (transaction.NewAmount < 0)
            {
                trn.TrnsType = MoneyBookDbContextExtension.TransactionTypes.DEBIT.ToString();
                trn.Amount = Math.Abs(transaction.NewAmount);
            }
            else
            {
                trn.TrnsType = MoneyBookDbContextExtension.TransactionTypes.CREDIT.ToString();
                trn.Amount = transaction.NewAmount;
            }
            trn.DateAdded =
            trn.DateModified = DateTime.Now.Date;
            return trn;
        }

        public static IList<TransactionInfo> ToTransactionInfos(this IList<ViewTransaction> transactions)
        {
            return transactions
                .Select(tran => new TransactionInfo
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

        public static IEnumerable<ViewTransaction> ToViewTransactions(this IEnumerable<TransactionInfo> transactions)
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

        public static IEnumerable<ViewReminder> ToViewReminders(this IEnumerable<ReminderInfo> reminder)
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
            return reminder.Select(tran => new Reminder
            {
                RmdrId = tran.RmdrId,
                DueDate = tran.DueDate,
                TrnsType = tran.TrnsType,
                Payee = tran.Payee,
                Memo = tran.Memo,
                Website = tran.Website,
                Amount = tran.Amount,
                Frequency = tran.Frequency,
                AcctId = tran.AcctId,
                CatId = tran.CatId
            });
        }

        public static Reminder ToReminder(this ViewReminder reminder)
        {
            return new Reminder
            {
                RmdrId = reminder.RmdrId,
                DueDate = reminder.DueDate,
                TrnsType = reminder.TrnsType,
                Payee = reminder.Payee,
                Memo = reminder.Memo,
                Website = reminder.Website,
                Amount = reminder.Amount,
                Frequency = reminder.Frequency,
                AcctId = reminder.AcctId,
                CatId = reminder.CatId
            };
        }
    }
}
