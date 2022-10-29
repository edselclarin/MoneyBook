using MoneyBook.Data;
using MoneyBook.Models;
using MoneyBookTools.ViewModels;
using Ofx;

namespace MoneyBookTools.Data
{
    public static class MoneyBookToolsDbContextExtension
    {
        public static void ImportTransactions(this MoneyBookDbContext db, string filename, string accountName)
        {
            var context = new OfxContext()
            {
                ImportFilePath = filename,
                AccountTo = accountName
            };

            context.FromFile(filename);

            // Get account to import into.
            var acct = db.Accounts.FirstOrDefault(x => x.Name.ToUpper() == context.AccountTo.ToUpper());
            if (acct == null)
            {
                throw new Exception($"Could not find account named '{context.AccountTo.ToUpper()}'.");
            }

            // Set all imported transactions to first category.
            var cat = db.Categories.First();

            // Process transactions from only this year.
            var transactions = context.Transactions
                .Where(x => x.DatePosted.Year == MoneyBookDbContextExtension.AccountYear)
                .ToList();

            foreach (var tr in transactions)
            {
                bool exists = db.Transactions
                    .Where(x => x.ExtTrnsId == tr.TransactionId)
                    .Count() > 0;

                // Add only new transactions.
                if (!exists)
                {
                    var trNew = new Transaction()
                    {
                        Date = tr.DatePosted,
                        TrnsType = tr.TransactionType,
                        Payee = tr.Memo,
                        State = MoneyBookDbContextExtension.StateTypes.Uncleared.ToString(),
                        Amount = tr.TransactionAmount,
                        ExtTrnsId = tr.TransactionId,
                        AcctId = acct.AcctId,
                        CatId = cat.CatId
                    };

                    db.Transactions.Add(trNew);
                }
            }

            db.SaveChanges();
        }

        public static void UpdateAccountData(this MoneyBookDbContext db, AccountData[] accountDataArr)
        {
            foreach (var ad in accountDataArr)
            {
                var acct = db.Accounts.FirstOrDefault(x => x.Name == ad.Name);
                if (acct != null)
                {
                    acct.StartingBalance = ad.StartingBalance;
                    acct.ReserveAmount = ad.ReserveAmount;
                }
            }

            db.SaveChanges();
        }

        public static void ResetAccountData(this MoneyBookDbContext db)
        {
            var accounts = db.Accounts.ToList();

            foreach (var acct in accounts)
            {
                acct.StartingBalance = 0m;
                acct.ReserveAmount = 0m;
            }

            db.SaveChanges();
        }

        public static void DeleteAllTransactions(this MoneyBookDbContext db)
        {
            db.Transactions.RemoveRange(db.Transactions);

            db.SaveChanges();
        }

        public static void ImportRecurringTransactions(this MoneyBookDbContext db, IEnumerable<RepeatingTransaction> repeatingTransactions)
        {
            var accounts = db.Accounts.ToList();

            // Get account to import into.
            // Set all imported transactions to first category.
            var cat = db.Categories.First();

            foreach (var tr in repeatingTransactions)
            {
                var acct = accounts.SingleOrDefault(x => x.Name == tr.Account);

                if (acct != null)
                {

                    bool exists = db.RecurringTransactions
                        .Where(x => x.DueDate == tr.DueDate &&
                                    x.TrnsType == tr.TrnsType &&
                                    x.Payee == tr.Payee &&
                                    x.Memo == tr.Memo &&
                                    x.Amount == tr.Amount &&
                                    x.Frequency == tr.Frequency)
                        .Count() > 0;

                    // Add only new transactions.
                    if (!exists)
                    {
                        var trNew = new RecurringTransaction()
                        {
                            DueDate = tr.DueDate,
                            TrnsType = tr.TrnsType,
                            Payee = tr.Payee,
                            Memo = tr.Memo,
                            Amount = tr.Amount,
                            Frequency = tr.Frequency,
                            AcctId = acct.AcctId,
                            CatId = cat.CatId
                        };

                        db.RecurringTransactions.Add(trNew);
                    }
                }
            }

            db.SaveChanges();
        }

        public static void DeleteAllRecurringTransactions(this MoneyBookDbContext db)
        {
            db.RecurringTransactions.RemoveRange(db.RecurringTransactions);

            db.SaveChanges();
        }

        public static void StageRecurringTransactions(this MoneyBookDbContext db, IEnumerable<ViewRecurringTransaction> recTrans)
        {
            foreach (var rtr in recTrans)
            {
                var trNew = new Transaction()
                {
                    Date = rtr.DueDate,
                    TrnsType = rtr.TrnsType,
                    Payee = rtr.Payee,
                    Memo= rtr.Memo,
                    State = MoneyBookDbContextExtension.StateTypes.Staged.ToString(),
                    Amount = rtr.TrnsAmount,
                    ExtTrnsId = String.Empty,
                    AcctId = rtr.AcctId,
                    CatId = rtr.CatId
                };

                db.Transactions.Add(trNew);

                var trn = db.RecurringTransactions
                    .FirstOrDefault(x => x.RecTrnsId == rtr.RecTrnsId);

                trn?.Skip();
            }

            db.SaveChanges();
        }

        public static void SkipRecurringTransactions(this MoneyBookDbContext db, IEnumerable<ViewRecurringTransaction> transactions)
        {
            foreach (var tr in transactions)
            {
                var trn = db.RecurringTransactions
                    .FirstOrDefault(x => x.RecTrnsId == tr.RecTrnsId);

                trn?.Skip();
            }

            db.SaveChanges();
        }

        public static void SetTransactionStates(this MoneyBookDbContext db, IEnumerable<ViewTransaction> transactions, MoneyBookDbContextExtension.StateTypes state)
        {
            foreach (var tr in transactions)
            {
                var trn = db.Transactions
                    .FirstOrDefault(x => x.TrnsId == tr.TrnsId);

                trn?.SetState(state);
            }
            db.SaveChanges();
        }

        public static void UpdateTransaction(this MoneyBookDbContext db, ViewTransaction transaction)
        {
            var trn = db.Transactions
                .FirstOrDefault(x => x.TrnsId == transaction.TrnsId);

            if (trn != null)
            {
                trn.Date = transaction.Date;
                trn.Payee = transaction.Payee;
                trn.RefNum = transaction.RefNum;
                trn.Payee = transaction.Payee;
                trn.Memo = transaction.Memo;
                trn.State = transaction.State;
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
                trn.DateModified = DateTime.Now.Date;

                db.SaveChanges();
            }
        }

        public static void DeleteTransactions(this MoneyBookDbContext db, IEnumerable<ViewTransaction> transactions)
        {
            foreach (var tr in transactions)
            {
                var trn = db.Transactions
                    .FirstOrDefault(x => x.TrnsId == tr.TrnsId);

                trn?.Delete();
            }
            db.SaveChanges();
        }
    }
}
