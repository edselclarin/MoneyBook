using MoneyBook.BusinessModels;
using MoneyBook.Models;

namespace MoneyBook.Data
{
    public static class MoneyBookDbContextExtension
    {
        private static int m_year = 2022;

        public static int AccountYear => m_year;

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
            Uncleared,

            /// <summary>
            /// Registered but uncleared transaction at institution.
            /// </summary>
            Pending,

            /// <summary>
            /// Projected transaction, not yet registered at institution.
            /// </summary>
            Staged,

            /// <summary>
            /// Matches with transaction at institution.
            /// </summary>
            Reconciled,
        }
        
        public enum DateFilter : int
        {
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
            Yearly
        }

        public static AccountInfo ToAccountInfo(this Account acct)
        {
            return new AccountInfo
            {
                AcctId = acct.AcctId,
                AccountName = acct.Name,
                Description = acct.Description,
                AcctType = acct.AcctType,
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

        public static IEnumerable<AccountInfo> GetAccounts(this MoneyBookDbContext db)
        {
            var results = db.Accounts
                .Where(x => x.IsDeleted == false)
                .Select(x => x.ToAccountInfo());

            return results.AsEnumerable();
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
                .Where(x => x.IsDeleted == false && x.AcctId == acctId && x.Date.Year == m_year)
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
            // TODO
        }

        public static void RestoreDatabase(this MoneyBookDbContext db, string filename)
        {
            // TODO
        }
    }
}
