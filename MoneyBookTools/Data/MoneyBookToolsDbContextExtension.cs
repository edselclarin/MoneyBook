using MoneyBook;
using MoneyBook.Data;
using MoneyBook.Models;
using MoneyBookTools.ViewModels;
using Newtonsoft.Json;

namespace MoneyBookTools.Data
{
    public static class MoneyBookToolsDbContextExtension
    {
        public static void ImportTransactions(this MoneyBookDbContext db)
        {
            var importer = new OfxTransactionImporter(db);
            importer.Import();
        }

        public static void DeleteAllTransactions(this MoneyBookDbContext db)
        {
            using var dbtran = db.Database.BeginTransaction();

            db.Transactions.RemoveRange(db.Transactions);

            db.SaveChanges();

            dbtran.Commit();
        }

        public static void ImportReminders(this MoneyBookDbContext db, string filename)
        {
            using var dbtran = db.Database.BeginTransaction();

            string json = File.ReadAllText(filename);

            var reminders = JsonConvert
                .DeserializeObject<IEnumerable<Reminder>>(json)
                .ToList();

            foreach (var rt in reminders)
            {
                rt.RmdrId = 0;

            }

            db.Reminders.RemoveRange(db.Reminders);

            db.SaveChanges();

            db.AddRange(reminders);

            db.SaveChanges();

            dbtran.Commit();
        }

        public static void ExportReminders(this MoneyBookDbContext db, string filename)
        {
            string json = JsonConvert.SerializeObject(db.Reminders, Formatting.Indented);

            File.WriteAllText(filename, json);
        }

        public static void DeleteAllReminders(this MoneyBookDbContext db)
        {
            using var dbtran = db.Database.BeginTransaction();
            
            db.Reminders.RemoveRange(db.Reminders);

            db.SaveChanges();

            dbtran.Commit();
        }

        public static void StageReminders(this MoneyBookDbContext db, IEnumerable<ViewReminder> reminders)
        {
            using var dbtran = db.Database.BeginTransaction();

            foreach (var rem in reminders)
            {
                var trNew = new Transaction()
                {
                    Date = rem.DueDate,
                    TrnsType = rem.TrnsType,
                    Payee = rem.Payee,
                    Memo= rem.Memo,
                    State = MoneyBookDbContextExtension.StateTypes.Staged.ToString(),
                    Amount = Math.Abs(rem.NewAmount),
                    ExtTrnsId = String.Empty,
                    AcctId = rem.AcctId,
                    CatId = rem.CatId
                };

                db.Transactions.Add(trNew);

                var rmdr = db.Reminders
                    .FirstOrDefault(x => x.RmdrId == rem.RmdrId);

                rmdr?.Skip();
            }

            db.SaveChanges();

            dbtran.Commit();
        }

        public static void SkipReminders(this MoneyBookDbContext db, IEnumerable<ViewReminder> reminders)
        {
            using var dbtran = db.Database.BeginTransaction();
            
            foreach (var rem in reminders)
            {
                var rmdr = db.Reminders
                    .FirstOrDefault(x => x.RmdrId == rem.RmdrId);

                rmdr?.Skip();
            }

            db.SaveChanges();

            dbtran.Commit();
        }

        public static void CopyReminders(this MoneyBookDbContext db, IEnumerable<ViewReminder> reminders)
        {
            using var dbtran = db.Database.BeginTransaction();
            
            foreach (var rem in reminders)
            {
                var trNew = new Transaction()
                {
                    Date = rem.DueDate,
                    TrnsType = rem.TrnsType,
                    Payee = rem.Payee,
                    Memo = rem.Memo,
                    State = MoneyBookDbContextExtension.StateTypes.Staged.ToString(),
                    Amount = rem.TrnsAmount,
                    ExtTrnsId = String.Empty,
                    AcctId = rem.AcctId,
                    CatId = rem.CatId
                };

                db.Transactions.Add(trNew);
            }

            db.SaveChanges();

            dbtran.Commit();
        }

        public static void DeleteReminders(this MoneyBookDbContext db, IEnumerable<ViewReminder> reminders)
        {
            using var dbtran = db.Database.BeginTransaction();
            
            foreach (var rem in reminders)
            {
                var rmdr = db.Reminders
                    .FirstOrDefault(x => x.RmdrId == rem.RmdrId);

                rmdr?.Delete();
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

        public static void AddReminder(this MoneyBookDbContext db, ViewReminder reminder)
        {
            using var dbtran = db.Database.BeginTransaction();
            
            var rem = db.Reminders
                .FirstOrDefault(x => 
                x.DueDate == reminder.DueDate &&
                x.AcctId == reminder.AcctId &&
                x.CatId == reminder.CatId &&
                x.TrnsType == reminder.TrnsType &&
                x.Amount == reminder.Amount &&
                x.Frequency == reminder.Frequency &&
                x.Payee == reminder.Payee &&
                x.Memo == reminder.Memo &&
                x.Website == reminder.Website);

            if (rem != null)
            {
                throw new Exception("Remidner already exists.");
            }

            var newRem = new Reminder()
            {
                DueDate = reminder.DueDate,
                AcctId = reminder.AcctId,
                CatId = reminder.CatId,
                TrnsType = reminder.TrnsType,
                Amount = reminder.TrnsAmount,
                Frequency = reminder.Frequency,
                Payee = reminder.Payee,
                Memo = reminder.Memo,
                Website = reminder.Website,
                DateAdded = DateTime.Now,
                DateModified = DateTime.Now
            };

            db.Reminders.Add(newRem);

            db.SaveChanges();

            dbtran.Commit();
        }

        public static void UpdateReminder(this MoneyBookDbContext db, ViewReminder reminder)
        {
            var rem = db.Reminders
                .FirstOrDefault(x => x.RmdrId == reminder.RmdrId);

            if (rem != null)
            {
                using var dbtran = db.Database.BeginTransaction();

                rem.DueDate = reminder.DueDate;
                rem.Payee = reminder.Payee;
                rem.Memo = reminder.Memo;
                rem.Website = reminder.Website;
                if (reminder.NewAmount < 0)
                {
                    rem.TrnsType = MoneyBookDbContextExtension.TransactionTypes.DEBIT.ToString();
                    rem.Amount = Math.Abs(reminder.NewAmount);
                }
                else
                {
                    rem.TrnsType = MoneyBookDbContextExtension.TransactionTypes.CREDIT.ToString();
                    rem.Amount = reminder.NewAmount;
                }
                rem.Frequency = reminder.Frequency;
                rem.DateModified = DateTime.Now.Date;

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

        public static void SetStateNewToReconciled(this MoneyBookDbContext db, int acctId)
        {
            var newTrans = db.GetTransactionsByState(acctId, MoneyBookDbContextExtension.StateTypes.New).ToList();
            var trans = from ntr in newTrans
                        join tr in db.Transactions on ntr.TrnsId equals tr.TrnsId
                        select tr;
            if (trans.Count() > 0)
            {
                foreach (var tr in trans)
                {
                    tr.State = MoneyBookDbContextExtension.StateTypes.Reconciled.ToString();
                }

                db.Transactions.UpdateRange(trans);

                db.SaveChanges();
            }
        }
    }
}
