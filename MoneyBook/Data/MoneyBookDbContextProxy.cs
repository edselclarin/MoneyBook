﻿using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MoneyBook.DataProviders;
using MoneyBook.Models;
using Newtonsoft.Json;
using static MoneyBook.Data.MoneyBookDbContextExtension;

namespace MoneyBook.Data
{
    public class MoneyBookDbContextProxy : IDbContextProxy
    {
        private MoneyBookDbContext m_db;

        public MoneyBookDbContextProxy() 
        {
            m_db = (MoneyBookDbContext)MoneyBookContainerBuilder.Container.Resolve<DbContext>();
        }

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

        public IDbContextTransaction CreateContextTransaction()
        {
            return m_db.Database.BeginTransaction();
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
                    State = MoneyBookDbContextExtension.StateTypes.Staged.ToString(),
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

        public void DeleteAllTransactions()
        {
            using var dbtran = m_db.Database.BeginTransaction();

            m_db.Transactions.RemoveRange(m_db.Transactions);

            m_db.SaveChanges();

            dbtran.Commit();
        }

        public void DeleteReminders(IEnumerable<Reminder> reminders)
        {
            using var dbtran = m_db.Database.BeginTransaction();

            foreach (var rem in reminders)
            {
                var rmdr = m_db.Reminders
                    .FirstOrDefault(x => x.RmdrId == rem.RmdrId);

                rmdr?.Delete();
            }

            m_db.SaveChanges();

            dbtran.Commit();
        }

        public void DeleteTransactions(IEnumerable<Transaction> transactions)
        {
            using var dbtran = m_db.Database.BeginTransaction();

            foreach (var tr in transactions)
            {
                var trn = m_db.Transactions
                    .FirstOrDefault(x => x.TrnsId == tr.TrnsId);

                trn?.Delete();
            }

            m_db.SaveChanges();

            dbtran.Commit();
        }

        public void ExportReminders(string filename)
        {
            string json = JsonConvert.SerializeObject(m_db.Reminders, Formatting.Indented);

            File.WriteAllText(filename, json);
        }

        public async Task<IEnumerable<Account>> GetAccountsAsync(int skip = 0, int take = 100)
        {
            var dp = MoneyBookContainerBuilder.Container.Resolve<IDataProvider<Account>>();
            var task = await dp.GetPagedAsync(skip, take);
            return task.Items;
        }

        public List<AccountSummary> GetAccountSummariesNew()
        {
            return m_db.AccountSummaries
                .OrderBy(x => x.AcctId)
                .Select(x => x.ToAccountSummary())
                .ToList();
        }

        public AccountSummary GetAccountSummaryNew(int acctId)
        {
            return m_db.AccountSummaries
                ?.SingleOrDefault(x => x.AcctId == acctId)
                ?.ToAccountSummary();
        }

        public IEnumerable<Category> GetCategories()
        {
            return m_db.Categories;
        }

        public IEnumerable<Reminder> GetReminders(MoneyBookDbContextExtension.SortOrder sortOrder)
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
                case SortOrder.Ascending:
                    sortedTransactions = results.OrderBy(x => x.DueDate);
                    break;
                case SortOrder.Descending:
                default:
                    sortedTransactions = results.OrderByDescending(x => x.DueDate);
                    break;
            }

            return sortedTransactions.AsEnumerable();
        }

        public IEnumerable<Transaction> GetTransactionInfos(int acctId)
        {
            var results = m_db.Transactions
                .Where(x => x.IsDeleted == false && x.AcctId == acctId && x.Date.Year >= MinimumAccountYear)
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

        public void ImportReminders(string filename)
        {
            using var dbtran = m_db.Database.BeginTransaction();

            string json = File.ReadAllText(filename);

            var reminders = JsonConvert
                .DeserializeObject<IEnumerable<Reminder>>(json)
                .ToList();

            foreach (var rt in reminders)
            {
                rt.RmdrId = 0;

            }

            m_db.Reminders.RemoveRange(m_db.Reminders);

            m_db.SaveChanges();

            m_db.AddRange(reminders);

            m_db.SaveChanges();

            dbtran.Commit();
        }

        public void RestoreDatabase(string filename)
        {
            if (File.Exists(filename))
            {
                string json = File.ReadAllText(filename);

                var backup = JsonConvert.DeserializeObject<DatabaseBackup>(json);

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

        public void SetStateNewToReconciled(int acctId)
        {
            var newTrans = m_db.GetTransactionsByState(acctId, MoneyBookDbContextExtension.StateTypes.New).ToList();
            var trans = from ntr in newTrans
                        join tr in m_db.Transactions on ntr.TrnsId equals tr.TrnsId
                        select tr;
            if (trans.Count() > 0)
            {
                foreach (var tr in trans)
                {
                    tr.State = MoneyBookDbContextExtension.StateTypes.Reconciled.ToString();
                }

                m_db.Transactions.UpdateRange(trans);

                m_db.SaveChanges();
            }
        }

        public void SetTransactionStates(IEnumerable<Transaction> transactions, MoneyBookDbContextExtension.StateTypes state)
        {
            using var dbtran = m_db.Database.BeginTransaction();

            foreach (var tr in transactions)
            {
                var trn = m_db.Transactions
                    .FirstOrDefault(x => x.TrnsId == tr.TrnsId);

                trn?.SetState(state);
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

        public IEnumerable<Transaction> GetTransactions()
        {
            return m_db.Transactions;
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
            var importer = new OfxTransactionImporter();
            importer.Import();
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
                    State = MoneyBookDbContextExtension.StateTypes.Staged.ToString(),
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
    }
}
