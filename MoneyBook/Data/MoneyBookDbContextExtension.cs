using MoneyBook.BusinessModels;
using MoneyBook.Models;
using Newtonsoft.Json;

namespace MoneyBook.Data
{
    public static class MoneyBookDbContextExtension
    {
        private static int m_minYear = 2022;

        public static int MinimumAccountYear => m_minYear;

        public enum TransactionTypes
        {
            DEBIT,
            CREDIT
        }

        public enum StateTypes
        {
            /// <summary>
            /// Newly added or imported.
            /// </summary>
            New,

            /// <summary>
            /// Projected transaction, not yet registered at institution.
            /// </summary>
            Staged,

            /// <summary>
            /// Matches with transaction at institution.
            /// </summary>
            Reconciled,

            /// <summary>
            /// Exclude from balance calculations.
            /// </summary>
            Ignored
        }
        
        public enum DateFilter : int
        {
            None,
            TwoWeeks,
            ThisMonth,
            ThisYear,
        }

        public enum SortOrder : int
        {
            Descending,
            Ascending
        }

        public enum TransactionFrequency : int
        {
            Once,
            Weekly,
            BiWeekly,
            Monthly,
            Quarterly,
            Yearly,
            Paused
        }

        public static CategoryInfo ToCategoryInfo(this Category cat)
        {
            return new CategoryInfo
            {
                CatId = cat.CatId,
                Name = cat.Name
            };
        }

        public static InstitutionInfo ToInstitutionInfo(this Institution inst)
        {
            return new InstitutionInfo
            {
                InstId = inst.InstId,
                Name = inst.Name,
                InstType = inst.InstType
            };
        }

        public static AccountInfo ToAccountInfo(this Account acct)
        {
            return new AccountInfo
            {
                AcctId = acct.AcctId,
                AccountName = acct.Name,
                Description = acct.Description,
                AcctTypeId = acct.AcctTypeId,
                StartingBalance = acct.StartingBalance,
                ReserveAmount = acct.ReserveAmount,
                DateAdded = acct.DateAdded,
                DateModified = acct.DateModified
            };
        }

        public static TransactionInfo ToTransactionInfo(this TransactionInfo trn)
        {
            return new TransactionInfo
            {
                TrnsId = trn.TrnsId,
                Date = trn.Date,
                TrnsType = trn.TrnsType,
                Payee = trn.Payee,
                Memo = trn.Memo,
                Amount = trn.Amount,
                DateAdded = trn.DateAdded,
                DateModified = trn.DateModified,
                AcctId = trn.AcctId,
                CatId = trn.CatId
            };
        }

        public static IEnumerable<TransactionInfo> Filter(this IEnumerable<TransactionInfo> transactions, DateFilter dateFilter)
        {
            switch (dateFilter)
            {
                case DateFilter.TwoWeeks:
                    return transactions
                        .Where(x => x.Date >= DateTime.Now.AddDays(-14));
                case DateFilter.ThisMonth:
                    return transactions
                        .Where(x => x.Date.Month == DateTime.Now.Month);
                case DateFilter.ThisYear:
                    return transactions
                        .Where(x => x.Date.Year == DateTime.Now.Year);
                case DateFilter.None:
                default:
                    return transactions;
            }
        }

        public static IEnumerable<TransactionInfo> Order(this IEnumerable<TransactionInfo> transactions, SortOrder sortOrder)
        {
            switch (sortOrder)
            {
                case SortOrder.Ascending:
                    return transactions.OrderBy(x => x.Date);
                case SortOrder.Descending:
                    return transactions.OrderByDescending(x => x.Date);
                default:
                    return transactions;
                    break;
            }
        }

        public static IEnumerable<CategoryInfo> GetCategories(this MoneyBookDbContext db)
        {
            var results = db.Categories
                .Where(x => x.IsDeleted == false)
                .Select(x => x.ToCategoryInfo());

            return results.AsEnumerable();
        }

        public static IEnumerable<InstitutionInfo> GetInstitutions(this MoneyBookDbContext db)
        {
            var results = db.Institutions
                .Where(x => x.IsDeleted == false)
                .Select(x => x.ToInstitutionInfo());

            return results.AsEnumerable();
        }

        public static IEnumerable<AccountInfo> GetAccounts(this MoneyBookDbContext db)
        {
            var results = db.Accounts
                .Where(x => x.IsDeleted == false)
                .Select(x => x.ToAccountInfo());

            return results.AsEnumerable();
        }

        public static List<AccountSummary> GetAccountSummaries(this MoneyBookDbContext db)
        {
            var summaries = new List<AccountSummary>();

            var accts = db.Accounts
                .Where(x => x.IsDeleted == false)
                .Select(x => x.ToAccountInfo())
                .ToList();

            foreach (var acct in accts)
            {
                var transactions = db.GetTransactions(acct.AcctId);

                var summary = new AccountSummary()
                {
                    Account = acct,
                    Transactions = transactions.ToList()
                };

                summaries.Add(summary);
            }

            return summaries;
        }

        public static AccountSummary? GetAccountSummary(this MoneyBookDbContext db, int acctId)
        {
            var accts = db.Accounts
                .Where(x => x.IsDeleted == false && x.AcctId == acctId)
                .Select(x => x.ToAccountInfo());

            if (accts != null && accts.Count() > 0)
            {
                var transactions = db.GetTransactions(accts.First().AcctId);

                var summary = new AccountSummary()
                {
                    Account = accts.First(),
                    Transactions = transactions.ToList()
                };

                return summary;
            }
            else
            {
                return null;
            }
        }

        public static AccountBrief? GetAccountBrief(this MoneyBookDbContext db, int acctId)
        {
            var accts = db.Accounts
                .Where(x => x.IsDeleted == false && x.AcctId == acctId)
                .Select(x => x.ToAccountInfo());

            if (accts != null && accts.Count() > 0)
            {
                var acct = accts.First();

                var transactions = db.GetTransactions(acct.AcctId);

                var summary = new AccountSummary()
                {
                    Account = acct,
                    Transactions = transactions.ToList()
                };

                var brief = new AccountBrief()
                {
                    Account = acct,
                    Credits = summary.Credits,
                    Debits = summary.Debits,
                    StagedBalance = summary.StagedBalance,
                    Balance = summary.Balance,
                    AvailableBalance = summary.AvailableBalance,
                    ProjectedBalance = summary.FinalBalance
                };

                return brief;
            }
            else
            {
                return null;
            }
        }

        public static IEnumerable<RecurringTransactionInfo> GetRecurringTransactions(this MoneyBookDbContext db, SortOrder sortOrder)
        {
            var accts = db.Accounts
                .ToList();

            var results = db.RecurringTransactions
                .Where(x => x.IsDeleted == false)
                .Select(trn => new RecurringTransactionInfo
                {
                    RecTrnsId = trn.RecTrnsId,
                    DueDate = trn.DueDate,
                    TrnsType = trn.TrnsType,
                    Payee = trn.Payee,
                    Memo = trn.Memo,
                    Website = trn.Website,
                    Amount = trn.Amount,
                    Frequency = trn.Frequency,
                    DateAdded = trn.DateAdded,
                    DateModified = trn.DateModified,
                    AcctId = trn.AcctId,
                    CatId = trn.CatId
                });

            IOrderedQueryable<RecurringTransactionInfo> sortedTransactions;
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

        public static IEnumerable<TransactionInfo> GetTransactions(this MoneyBookDbContext db, int acctId)
        {
            var results = db.Transactions
                .Where(x => x.IsDeleted == false && x.AcctId == acctId && x.Date.Year >= m_minYear)
                .Select(x => new TransactionInfo
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

        public static IEnumerable<TransactionInfo> GetTransactionsByState(this MoneyBookDbContext db, int acctId, StateTypes state)
        {
            var results = db.Transactions
                .Where(x => x.IsDeleted == false && x.AcctId == acctId && x.Date.Year >= m_minYear && x.State == state.ToString())
                .Select(x => new TransactionInfo
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

        public static void Skip(this RecurringTransaction recTran)
        {
            if (recTran.Frequency == TransactionFrequency.Weekly.ToString())
            {
                recTran.DueDate = recTran.DueDate.AddDays(7);
            }
            else if (recTran.Frequency == TransactionFrequency.BiWeekly.ToString())
            {
                recTran.DueDate = recTran.DueDate.AddDays(14);
            }
            else if (recTran.Frequency == TransactionFrequency.Monthly.ToString())
            {
                recTran.DueDate = recTran.DueDate.AddMonths(1);
            }
            else if (recTran.Frequency == TransactionFrequency.Quarterly.ToString())
            {
                recTran.DueDate = recTran.DueDate.AddMonths(3);
            }
            else if (recTran.Frequency == TransactionFrequency.Yearly.ToString())
            {
                recTran.DueDate = recTran.DueDate.AddYears(1);
            }

            recTran.DateModified = DateTime.Now.Date;
        }

        public static void Delete(this RecurringTransaction recTran)
        {
            // Soft delete.
            recTran.IsDeleted = true;
        }

        public static void SetState(this Transaction tran, StateTypes state)
        {
            tran.State = state.ToString();
        }

        public static void Delete(this Transaction tran)
        {
            // Soft delete.
            tran.IsDeleted = true;
        }

        public static void BackupDatabase(this MoneyBookDbContext db, string filename)
        {
            var backup = new DatabaseBackup()
            {
                DateCreated = DateTime.Now,
                Transactions = db.Transactions.ToList(),
                RecurringTransactions = db.RecurringTransactions.ToList(),
                Accounts = db.Accounts.ToList(),
                Institutions = db.Institutions.ToList(),
                Categories = db.Categories.ToList(),
            };

            string json = JsonConvert.SerializeObject(backup, Formatting.Indented);

            File.WriteAllText(filename, json);
        }

        public static void RestoreDatabase(this MoneyBookDbContext db, string filename)
        {
            if (File.Exists(filename))
            {
                string json = File.ReadAllText(filename);

                var backup = JsonConvert.DeserializeObject<DatabaseBackup>(json);

                var tr = db.Database.BeginTransaction();

                // Delete records in all tables.
                db.Transactions.RemoveRange(db.Transactions);
                db.RecurringTransactions.RemoveRange(db.RecurringTransactions);
                db.Accounts.RemoveRange(db.Accounts);
                db.Institutions.RemoveRange(db.Institutions);
                db.Categories.RemoveRange(db.Categories);

                db.SaveChanges();

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
                    db.Categories.Add(cat);
                }

                // Add institutions.
                foreach (var inst in backup.Institutions)
                {
                    inst.InstId = 0;
                    db.Institutions.Add(inst);
                }

                db.SaveChanges();

                // Add accounts - skip those with bad references.
                foreach (var acct in backup.Accounts)
                {
                    var oldInst = oldInstitutions.FirstOrDefault(x => x.InstId == acct.InstId);
                    if (oldInst == null)
                    {
                        continue;
                    }
                    var newInst = db.Institutions.FirstOrDefault(x => x.Name == oldInst.Name);
                    if (newInst == null)
                    {
                        continue;
                    }

                    acct.AcctId = 0;
                    acct.InstId = newInst.InstId;
                    acct.DateAdded =
                    acct.DateModified = DateTime.Now;

                    db.Accounts.Add(acct);
                }

                db.SaveChanges();

                // Add recurring transactions - skip those with bad references.
                foreach (var recTrans in backup.RecurringTransactions)
                {
                    var oldCat = oldCategories.FirstOrDefault(x => x.CatId == recTrans.CatId);
                    if (oldCat == null)
                    {
                        recTrans.CatId = db.Categories.First().CatId;
                    }
                    else
                    {
                        var newCat = db.Categories.FirstOrDefault(x => x.Name == oldCat.Name);
                        if (newCat == null)
                        {
                            continue;
                        }
                        recTrans.CatId = newCat.CatId;
                    }

                    var oldAcct = oldAccounts.FirstOrDefault(x => x.AcctId == recTrans.AcctId);
                    if (oldAcct == null)
                    {
                        continue;
                    }
                    var newAcct = db.Accounts.FirstOrDefault(x => x.Name == oldAcct.Name);
                    if (newAcct == null)
                    {
                        continue;
                    }

                    recTrans.RecTrnsId = 0;
                    recTrans.AcctId = newAcct.AcctId;
                    recTrans.DateAdded =
                    recTrans.DateModified = DateTime.Now;

                    db.RecurringTransactions.Add(recTrans);
                }

                db.SaveChanges();

                // Add transactions - skip those with bad references.
                foreach (var trans in backup.Transactions)
                {
                    var oldCat = oldCategories.FirstOrDefault(x => x.CatId == trans.CatId);
                    if (oldCat == null)
                    {
                        trans.CatId = db.Categories.First().CatId;
                    }
                    else
                    {
                        var newCat = db.Categories.FirstOrDefault(x => x.Name == oldCat.Name);
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
                    var newAcct = db.Accounts.FirstOrDefault(x => x.Name == oldAcct.Name);
                    if (newAcct == null)
                    {
                        continue;
                    }

                    trans.TrnsId = 0;
                    trans.AcctId = newAcct.AcctId;
                    trans.DateAdded =
                    trans.DateModified = DateTime.Now;

                    db.Transactions.Add(trans);
                }

                db.SaveChanges();

                tr.Commit();
            }
        }
    }
}
