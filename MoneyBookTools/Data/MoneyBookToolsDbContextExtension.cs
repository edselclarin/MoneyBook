using MoneyBook.Data;
using MoneyBook.Models;
using MoneyBookTools.ViewModels;
using Newtonsoft.Json;
using Ofx;

namespace MoneyBookTools.Data
{
    public static class MoneyBookToolsDbContextExtension
    {
        public static void ImportTransactions(this MoneyBookDbContext db, IEnumerable<AccountData> accountDataArr)
        {
            using var dbtran = db.Database.BeginTransaction();

            foreach (var ad in accountDataArr)
            {
                var context = new OfxContext()
                {
                    ImportFilePath = ad.ImportFilePath,
                    AccountTo = ad.Name
                };

                context.FromFile(ad.ImportFilePath);

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
                            State = MoneyBookDbContextExtension.StateTypes.New.ToString(),
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

            dbtran.Commit();
        }

        public static void UpdateAccountData(this MoneyBookDbContext db, AccountData[] accountDataArr)
        {
            using var dbtran = db.Database.BeginTransaction();

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

            dbtran.Commit();
        }

        public static void ResetAccountData(this MoneyBookDbContext db)
        {
            using var dbtran = db.Database.BeginTransaction();

            var accounts = db.Accounts.ToList();

            foreach (var acct in accounts)
            {
                acct.StartingBalance = 0m;
                acct.ReserveAmount = 0m;
            }

            db.SaveChanges();

            dbtran.Commit();
        }

        public static void DeleteAllTransactions(this MoneyBookDbContext db)
        {
            using var dbtran = db.Database.BeginTransaction();

            db.Transactions.RemoveRange(db.Transactions);

            db.SaveChanges();

            dbtran.Commit();
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

        public static void ImportRecurringTransactions(this MoneyBookDbContext db, string filename)
        {
            using var dbtran = db.Database.BeginTransaction();

            string json = File.ReadAllText(filename);

            var recTrans = JsonConvert
                .DeserializeObject<IEnumerable<RecurringTransaction>>(json)
                .ToList();

            foreach (var rt in recTrans)
            {
                rt.RecTrnsId = 0;

            }

            db.RecurringTransactions.RemoveRange(db.RecurringTransactions);

            db.SaveChanges();

            db.AddRange(recTrans);

            db.SaveChanges();

            dbtran.Commit();
        }

        public static void ExportRecurringTransactions(this MoneyBookDbContext db, string filename)
        {
            string json = JsonConvert.SerializeObject(db.RecurringTransactions, Formatting.Indented);

            File.WriteAllText(filename, json);
        }

        public static void DeleteAllRecurringTransactions(this MoneyBookDbContext db)
        {
            using var dbtran = db.Database.BeginTransaction();
            
            db.RecurringTransactions.RemoveRange(db.RecurringTransactions);

            db.SaveChanges();

            dbtran.Commit();
        }

        public static void StageRecurringTransactions(this MoneyBookDbContext db, IEnumerable<ViewRecurringTransaction> recTrans)
        {
            using var dbtran = db.Database.BeginTransaction();

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

            dbtran.Commit();
        }

        public static void SkipRecurringTransactions(this MoneyBookDbContext db, IEnumerable<ViewRecurringTransaction> transactions)
        {
            using var dbtran = db.Database.BeginTransaction();
            
            foreach (var tr in transactions)
            {
                var trn = db.RecurringTransactions
                    .FirstOrDefault(x => x.RecTrnsId == tr.RecTrnsId);

                trn?.Skip();
            }

            db.SaveChanges();

            dbtran.Commit();
        }

        public static void CopyRecurringTransactions(this MoneyBookDbContext db, IEnumerable<ViewRecurringTransaction> recTrans)
        {
            using var dbtran = db.Database.BeginTransaction();
            
            foreach (var rtr in recTrans)
            {
                var trNew = new Transaction()
                {
                    Date = rtr.DueDate,
                    TrnsType = rtr.TrnsType,
                    Payee = rtr.Payee,
                    Memo = rtr.Memo,
                    State = MoneyBookDbContextExtension.StateTypes.Staged.ToString(),
                    Amount = rtr.TrnsAmount,
                    ExtTrnsId = String.Empty,
                    AcctId = rtr.AcctId,
                    CatId = rtr.CatId
                };

                db.Transactions.Add(trNew);
            }

            db.SaveChanges();

            dbtran.Commit();
        }

        public static void DeleteRecurringTransactions(this MoneyBookDbContext db, IEnumerable<ViewRecurringTransaction> transactions)
        {
            using var dbtran = db.Database.BeginTransaction();
            
            foreach (var tr in transactions)
            {
                var trn = db.RecurringTransactions
                    .FirstOrDefault(x => x.RecTrnsId == tr.RecTrnsId);

                trn?.Delete();
            }

            db.SaveChanges();

            dbtran.Commit();
        }

        public static void SetTransactionStates(this MoneyBookDbContext db, IEnumerable<ViewTransaction> transactions, MoneyBookDbContextExtension.StateTypes state)
        {
            using var dbtran = db.Database.BeginTransaction();

            foreach (var tr in transactions)
            {
                var trn = db.Transactions
                    .FirstOrDefault(x => x.TrnsId == tr.TrnsId);

                trn?.SetState(state);
            }

            db.SaveChanges();

            dbtran.Commit();
        }

        public static void AddTransaction(this MoneyBookDbContext db, ViewTransaction transaction)
        {
            using var dbtran = db.Database.BeginTransaction();

            var cat = db.Categories.FirstOrDefault();

            if (cat == null)
            {
                throw new Exception("There must be at least one category.");
            }

            var trn = new Transaction();
            trn.AcctId = transaction.AcctId;
            trn.TrnsType = transaction.TrnsType;
            trn.CatId = cat.CatId;
            trn.Date = transaction.Date;
            trn.Payee = transaction.Payee;
            trn.RefNum = transaction.RefNum;
            trn.Payee = transaction.Payee;
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
            trn.DateModified = DateTime.Now.Date;

            db.Transactions.Add(trn);

            db.SaveChanges();

            dbtran.Commit();
        }

        public static void UpdateTransaction(this MoneyBookDbContext db, ViewTransaction transaction)
        {
            var trn = db.Transactions
                .FirstOrDefault(x => x.TrnsId == transaction.TrnsId);

            if (trn != null)
            {
                using var dbtran = db.Database.BeginTransaction();

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

                dbtran.Commit();
            }
        }

        public static void AddRecurringTransaction(this MoneyBookDbContext db, ViewRecurringTransaction recTrans)
        {
            using var dbtran = db.Database.BeginTransaction();
            
            var rt = db.RecurringTransactions
                .FirstOrDefault(x => 
                x.DueDate == recTrans.DueDate &&
                x.AcctId == recTrans.AcctId &&
                x.CatId == recTrans.CatId &&
                x.TrnsType == recTrans.TrnsType &&
                x.Amount == recTrans.Amount &&
                x.Frequency == recTrans.Frequency &&
                x.Payee == recTrans.Payee &&
                x.Memo == recTrans.Memo &&
                x.Website == recTrans.Website);

            if (rt != null)
            {
                throw new Exception("Recurring transaction already exists.");
            }

            var newRt = new RecurringTransaction()
            {
                DueDate = recTrans.DueDate,
                AcctId = recTrans.AcctId,
                CatId = recTrans.CatId,
                TrnsType = recTrans.TrnsType,
                Amount = recTrans.TrnsAmount,
                Frequency = recTrans.Frequency,
                Payee = recTrans.Payee,
                Memo = recTrans.Memo,
                Website = recTrans.Website,
                DateAdded = DateTime.Now,
                DateModified = DateTime.Now
            };

            db.RecurringTransactions.Add(newRt);

            db.SaveChanges();

            dbtran.Commit();
        }

        public static void UpdateRecurringTransaction(this MoneyBookDbContext db, ViewRecurringTransaction recTrans)
        {
            var rt = db.RecurringTransactions
                .FirstOrDefault(x => x.RecTrnsId == recTrans.RecTrnsId);

            if (rt != null)
            {
                using var dbtran = db.Database.BeginTransaction();

                rt.DueDate = recTrans.DueDate;
                rt.Payee = recTrans.Payee;
                rt.Memo = recTrans.Memo;
                rt.Website = recTrans.Website;
                if (recTrans.NewAmount < 0)
                {
                    rt.TrnsType = MoneyBookDbContextExtension.TransactionTypes.DEBIT.ToString();
                    rt.Amount = Math.Abs(recTrans.NewAmount);
                }
                else
                {
                    rt.TrnsType = MoneyBookDbContextExtension.TransactionTypes.CREDIT.ToString();
                    rt.Amount = recTrans.NewAmount;
                }
                rt.Frequency = recTrans.Frequency;
                rt.DateModified = DateTime.Now.Date;

                db.SaveChanges();

                dbtran.Commit();
            }
        }

        public static void DeleteTransactions(this MoneyBookDbContext db, IEnumerable<ViewTransaction> transactions)
        {
            using var dbtran = db.Database.BeginTransaction();

            foreach (var tr in transactions)
            {
                var trn = db.Transactions
                    .FirstOrDefault(x => x.TrnsId == tr.TrnsId);

                trn?.Delete();
            }

            db.SaveChanges();

            dbtran.Commit();
        }
    }
}
