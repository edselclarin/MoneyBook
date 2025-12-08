using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MoneyBook.DataProviders;
using MoneyBook.Extensions;
using MoneyBook.Models;
using Newtonsoft.Json;

namespace MoneyBook.Data
{
    public class MoneyBookDbContextProxy : IDbContextProxy
    {
        #region Fields

        private MoneyBookDbContext m_db;

        #endregion

        #region Construction

        public MoneyBookDbContextProxy() 
        {
            m_db = (MoneyBookDbContext)MoneyBookContainerBuilder.Container.Resolve<DbContext>();
        }

        #endregion

        #region Account

        public async Task<IEnumerable<Account>> GetAccountsAsync(int skip = 0, int take = 100)
        {
            var dp = MoneyBookContainerBuilder.Container.Resolve<IDataProvider<Account>>();
            var task = await dp.GetPagedAsync(skip, take);
            return task.Items;
        }

        public IEnumerable<AccountSummary> GetAccountSummaries()
        {
            return m_db.AccountSummaries
                .OrderBy(x => x.AcctId);
        }

        public AccountSummary GetAccountSummary(int acctId)
        {
            return m_db.AccountSummaries
                ?.SingleOrDefault(x => x.AcctId == acctId);
        }

        #endregion

        #region Transaction

        public IEnumerable<Transaction> GetAllTransactions()
        {
            return m_db.Transactions;
        }

        public IEnumerable<Transaction> GetAccountTransactions(int acctId)
        {
            var results = m_db.Transactions
                .Where(x => x.IsDeleted == false && x.AcctId == acctId && x.Date.Year >= MoneyBookGlobals.MinimumAccountYear)
                .Select(x => new Transaction
                {
                    TrnsId = x.TrnsId,
                    Date = x.Date,
                    TrnsType = x.TrnsType,
                    RefNum = x.RefNum,
                    Payee = x.Payee,
                    Memo = x.Memo,
                    State = x.State,
                    Amount = x.Amount,
                    DateAdded = x.DateAdded,
                    DateModified = x.DateModified,
                    AcctId = x.AcctId,
                    CatId = x.CatId
                });

            return results.AsEnumerable();
        }

        public IEnumerable<Transaction> GetTransactionsByState(int acctId, StateTypes state)
        {
            return m_db.Transactions
                .Where(x => x.IsDeleted == false &&
                            x.AcctId == acctId &&
                            x.Date.Year >= MoneyBookGlobals.MinimumAccountYear &&
                            x.State == state.ToString());
        }

        public void SetTransactionStates(IEnumerable<Transaction> transactions, StateTypes state)
        {
            using var dbtran = m_db.Database.BeginTransaction();

            foreach (var tr in transactions)
            {
                var trn = m_db.Transactions
                    .FirstOrDefault(x => x.TrnsId == tr.TrnsId);

                trn.State = state.ToString();
            }

            m_db.SaveChanges();

            dbtran.Commit();
        }

        public void SetStateNewToReconciled(int acctId)
        {
            var newTrans = GetTransactionsByState(acctId, StateTypes.New).ToList();
            var trans = from ntr in newTrans
                        join tr in m_db.Transactions on ntr.TrnsId equals tr.TrnsId
                        select tr;
            if (trans.Count() > 0)
            {
                foreach (var tr in trans)
                {
                    tr.State = StateTypes.Reconciled.ToString();
                }

                m_db.Transactions.UpdateRange(trans);

                m_db.SaveChanges();
            }
        }

        public void DeleteTransactions(IEnumerable<Transaction> transactions)
        {
            using var dbtran = m_db.Database.BeginTransaction();

            foreach (var tr in transactions)
            {
                var trn = m_db.Transactions
                    .FirstOrDefault(x => x.TrnsId == tr.TrnsId);

                // Soft delete.
                trn.IsDeleted = true;
            }

            m_db.SaveChanges();

            dbtran.Commit();
        }

        public void DeleteAllTransactions()
        {
            using var dbtran = m_db.Database.BeginTransaction();

            m_db.Transactions.RemoveRange(m_db.Transactions);

            m_db.SaveChanges();

            dbtran.Commit();
        }

        public void AddTransactions(IEnumerable<Transaction> transactions)
        {
            using var tr = m_db.Database.BeginTransaction();

            m_db.Transactions.AddRange(transactions);

            m_db.SaveChanges();

            tr.Commit();
        }

        public void ImportTransactions()
        {
            var importer = new OfxTransactionImporter(this);
            importer.Import();
        }

        public async Task ImportTransactionsAsync()
        {
            var importer = new OfxTransactionImporter(this);
            await importer.ImportAsync();
        }

        public void AddTransaction(Transaction transaction)
        {
            using var dbtran = m_db.Database.BeginTransaction();

            var cat = m_db.Categories.FirstOrDefault();

            var trn = new Transaction();
            trn.AcctId = transaction.AcctId;
            trn.TrnsType = transaction.TrnsType;
            trn.CatId = cat == null ? 0 : cat.CatId;
            trn.Date = transaction.Date;
            trn.Payee = transaction.Payee;
            trn.RefNum = transaction.RefNum;
            trn.Memo = transaction.Memo;
            trn.State = transaction.State;
            trn.ExtTrnsId = String.Empty;
            trn.Amount = Math.Abs(transaction.Amount);
            trn.DateAdded =
            trn.DateModified = DateTime.Now.Date;

            m_db.Transactions.Add(trn);

            m_db.SaveChanges();

            dbtran.Commit();
        }

        public void UpdateTransaction(Transaction transaction)
        {
            var trn = m_db.Transactions
                .FirstOrDefault(x => x.TrnsId == transaction.TrnsId);

            if (trn != null)
            {
                using var dbtran = m_db.Database.BeginTransaction();

                trn.Date = transaction.Date;
                trn.TrnsType = transaction.TrnsType;
                trn.Payee = transaction.Payee;
                trn.RefNum = transaction.RefNum;
                trn.Payee = transaction.Payee;
                trn.Memo = transaction.Memo;
                trn.State = transaction.State;
                trn.Amount = Math.Abs(transaction.Amount);
                trn.DateModified = DateTime.Now.Date;

                m_db.SaveChanges();

                dbtran.Commit();
            }
        }

        #endregion

        #region Reminder

        public IEnumerable<Reminder> GetReminders(SortMode sortOrder)
        {
            var accts = m_db.Accounts
                .ToList();

            var results = m_db.Reminders
                .Where(x => x.IsDeleted == false)
                .Select(rem => new Reminder
                {
                    RmdrId = rem.RmdrId,
                    DueDate = rem.DueDate,
                    TrnsType = rem.TrnsType,
                    Payee = rem.Payee,
                    Memo = rem.Memo,
                    Website = rem.Website,
                    Amount = rem.Amount,
                    Frequency = rem.Frequency,
                    DateAdded = rem.DateAdded,
                    DateModified = rem.DateModified,
                    AcctId = rem.AcctId,
                    CatId = rem.CatId
                });

            IOrderedQueryable<Reminder> sortedTransactions;
            switch (sortOrder)
            {
                case SortMode.Ascending:
                    sortedTransactions = results.OrderBy(x => x.DueDate);
                    break;
                case SortMode.Descending:
                default:
                    sortedTransactions = results.OrderByDescending(x => x.DueDate);
                    break;
            }

            return sortedTransactions.AsEnumerable();
        }

        public void AddReminder(Reminder reminder)
        {
            using var dbtran = m_db.Database.BeginTransaction();

            var rem = m_db.Reminders
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

            if (rem == null)
            {
                var newRem = new Reminder()
                {
                    DueDate = reminder.DueDate,
                    AcctId = reminder.AcctId,
                    CatId = reminder.CatId,
                    TrnsType = reminder.TrnsType,
                    Amount = reminder.Amount,
                    Frequency = reminder.Frequency,
                    Payee = reminder.Payee,
                    Memo = reminder.Memo,
                    Website = reminder.Website,
                    DateAdded = DateTime.Now,
                    DateModified = DateTime.Now
                };

                m_db.Reminders.Add(newRem);

                m_db.SaveChanges();

                dbtran.Commit();
            }
        }

        public void UpdateReminder(Reminder reminder)
        {
            var rem = m_db.Reminders
                .FirstOrDefault(x => x.RmdrId == reminder.RmdrId);

            if (rem != null)
            {
                using var dbtran = m_db.Database.BeginTransaction();

                rem.AcctId = reminder.AcctId;
                rem.TrnsType = reminder.TrnsType;
                rem.DueDate = reminder.DueDate;
                rem.Payee = reminder.Payee;
                rem.Memo = reminder.Memo;
                rem.Website = reminder.Website;
                rem.Amount = reminder.Amount;
                rem.Frequency = reminder.Frequency;
                rem.DateModified = DateTime.Now.Date;

                m_db.SaveChanges();

                dbtran.Commit();
            }
        }

        public void DeleteReminders(IEnumerable<Reminder> reminders)
        {
            using var dbtran = m_db.Database.BeginTransaction();

            foreach (var rem in reminders)
            {
                var rmdr = m_db.Reminders
                    .FirstOrDefault(x => x.RmdrId == rem.RmdrId);

                // Soft delete.
                rmdr.IsDeleted = true;
            }

            m_db.SaveChanges();

            dbtran.Commit();
        }

        public void CopyReminders(IEnumerable<Reminder> reminders)
        {
            using var dbtran = m_db.Database.BeginTransaction();

            foreach (var rem in reminders)
            {
                var trNew = new Transaction()
                {
                    Date = rem.DueDate,
                    TrnsType = rem.TrnsType,
                    Payee = rem.Payee,
                    Memo = rem.Memo,
                    State = StateTypes.Staged.ToString(),
                    Amount = rem.Amount,
                    ExtTrnsId = String.Empty,
                    AcctId = rem.AcctId,
                    CatId = rem.CatId
                };

                m_db.Transactions.Add(trNew);
            }

            m_db.SaveChanges();

            dbtran.Commit();
        }

        public void SkipReminders(IEnumerable<Reminder> reminders)
        {
            using var dbtran = m_db.Database.BeginTransaction();

            foreach (var rem in reminders)
            {
                var rmdr = m_db.Reminders
                    .FirstOrDefault(x => x.RmdrId == rem.RmdrId);

                rmdr?.Skip();
            }

            m_db.SaveChanges();

            dbtran.Commit();
        }


        public void StageReminders(IEnumerable<Reminder> reminders)
        {
            using var dbtran = m_db.Database.BeginTransaction();

            foreach (var rem in reminders)
            {
                var trNew = new Transaction()
                {
                    Date = rem.DueDate,
                    TrnsType = rem.TrnsType,
                    Payee = rem.Payee,
                    Memo = rem.Memo,
                    State = StateTypes.Staged.ToString(),
                    Amount = rem.Amount,
                    ExtTrnsId = String.Empty,
                    AcctId = rem.AcctId,
                    CatId = rem.CatId
                };

                m_db.Transactions.Add(trNew);

                var rmdr = m_db.Reminders
                    .FirstOrDefault(x => x.RmdrId == rem.RmdrId);

                rmdr?.Skip();
            }

            m_db.SaveChanges();

            dbtran.Commit();
        }

        #endregion

        #region Category

        public IEnumerable<Category> GetCategories()
        {
            return m_db.Categories
                .Where(x => x.IsDeleted == false)
                .OrderBy(x => x.CatId);
        }

        #endregion 

        #region ContextTransaction

        public IDbContextTransaction CreateContextTransaction()
        {
            return m_db.Database.BeginTransaction();
        }

        #endregion

        #region DatabaseManagement

        public void BackupDatabase(string backupDir)
        {
            Directory.CreateDirectory(backupDir);

            var dbBackups = new IDbBackup[]
            {
                MoneyBookDbTextBackup.Create(m_db, backupDir),
                MoneyBookDbTapeBackup.Create(m_db, backupDir)
            };

            foreach (var backup in dbBackups)
            {
                backup.Save();
            }
        }

        public Task BackupDatabaseAsync(string filename)
        {
            return Task.Run(() => BackupDatabase(filename));
        }

        public void RestoreDatabase(string filename)
        {
            if (File.Exists(filename))
            {
                string json = File.ReadAllText(filename);

                var backup = JsonConvert.DeserializeObject<BackupContext>(json);

                var tr = m_db.Database.BeginTransaction();

                // Delete records in all tables.
                m_db.Transactions.RemoveRange(m_db.Transactions);
                m_db.Reminders.RemoveRange(m_db.Reminders);
                m_db.Accounts.RemoveRange(m_db.Accounts);
                m_db.Institutions.RemoveRange(m_db.Institutions);
                m_db.Categories.RemoveRange(m_db.Categories);

                m_db.SaveChanges();

                // Save old identifiers.
                var oldCategories = backup.Categories
                    .Select(x => new Category
                    {
                        CatId = x.CatId,
                        Name = x.Name
                    })
                    .ToList();
                var oldInstitutions = backup.Institutions
                    .Select(x => new Institution
                    {
                        InstId = x.InstId,
                        Name = x.Name
                    })
                    .ToList();
                var oldAccounts = backup.Accounts
                    .Select(x => new Account
                    {
                        AcctId = x.AcctId,
                        Name = x.Name
                    })
                    .ToList();

                // Add categories.
                foreach (var cat in backup.Categories)
                {
                    cat.CatId = 0;
                    m_db.Categories.Add(cat);
                }

                // Add institutions.
                foreach (var inst in backup.Institutions)
                {
                    inst.InstId = 0;
                    m_db.Institutions.Add(inst);
                }

                m_db.SaveChanges();

                // Add accounts - skip those with bad references.
                foreach (var acct in backup.Accounts)
                {
                    var oldInst = oldInstitutions.FirstOrDefault(x => x.InstId == acct.InstId);
                    if (oldInst == null)
                    {
                        continue;
                    }
                    var newInst = m_db.Institutions.FirstOrDefault(x => x.Name == oldInst.Name);
                    if (newInst == null)
                    {
                        continue;
                    }

                    acct.AcctId = 0;
                    acct.InstId = newInst.InstId;
                    acct.DateAdded =
                    acct.DateModified = DateTime.Now;

                    m_db.Accounts.Add(acct);
                }

                m_db.SaveChanges();

                // Add reminders - skip those with bad references.
                foreach (var reminder in backup.Reminders)
                {
                    var oldCat = oldCategories.FirstOrDefault(x => x.CatId == reminder.CatId);
                    if (oldCat == null)
                    {
                        reminder.CatId = m_db.Categories.First().CatId;
                    }
                    else
                    {
                        var newCat = m_db.Categories.FirstOrDefault(x => x.Name == oldCat.Name);
                        if (newCat == null)
                        {
                            continue;
                        }
                        reminder.CatId = newCat.CatId;
                    }

                    var oldAcct = oldAccounts.FirstOrDefault(x => x.AcctId == reminder.AcctId);
                    if (oldAcct == null)
                    {
                        continue;
                    }
                    var newAcct = m_db.Accounts.FirstOrDefault(x => x.Name == oldAcct.Name);
                    if (newAcct == null)
                    {
                        continue;
                    }

                    reminder.RmdrId = 0;
                    reminder.AcctId = newAcct.AcctId;
                    reminder.DateAdded =
                    reminder.DateModified = DateTime.Now;

                    m_db.Reminders.Add(reminder);
                }

                m_db.SaveChanges();

                // Add transactions - skip those with bad references.
                foreach (var trans in backup.Transactions)
                {
                    var oldCat = oldCategories.FirstOrDefault(x => x.CatId == trans.CatId);
                    if (oldCat == null)
                    {
                        trans.CatId = m_db.Categories.First().CatId;
                    }
                    else
                    {
                        var newCat = m_db.Categories.FirstOrDefault(x => x.Name == oldCat.Name);
                        if (newCat == null)
                        {
                            continue;
                        }
                        trans.CatId = newCat.CatId;
                    }

                    var oldAcct = oldAccounts.FirstOrDefault(x => x.AcctId == trans.AcctId);
                    if (oldAcct == null)
                    {
                        continue;
                    }
                    var newAcct = m_db.Accounts.FirstOrDefault(x => x.Name == oldAcct.Name);
                    if (newAcct == null)
                    {
                        continue;
                    }

                    trans.TrnsId = 0;
                    trans.AcctId = newAcct.AcctId;
                    trans.DateAdded =
                    trans.DateModified = DateTime.Now;

                    m_db.Transactions.Add(trans);
                }

                m_db.SaveChanges();

                tr.Commit();
            }
        }

        public Task RestoreDatabaseAsync(string filename)
        {
            return Task.Run(() => RestoreDatabase(filename));
        }

        #endregion
    }
}
