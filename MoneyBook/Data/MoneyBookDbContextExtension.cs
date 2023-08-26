using Autofac;
using MoneyBook.Extensions;
using MoneyBook.Models;

namespace MoneyBook.Data
{
    public static class MoneyBookDbContextExtension
    {
        private static int m_minYear = 2022;

        public static int MinimumAccountYear => 2022;

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
            /// Newly imported but pending
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

        public enum DueStateTypes
        {
            Past,     // Overdue
            Today,    // Due today
            Soon,     // Due by DueBeforeDay
            Upcoming, // Due in one week
            None      // Not due
        }

        public static DayOfWeek DueBeforeDay { get; set; } = DayOfWeek.Wednesday;

        public static AccountSummary ToAccountSummary(this Models.AccountSummary acctSummary)
        {
            return new AccountSummary
            {
                AcctId = acctSummary.AcctId,
                Name = acctSummary.Name,
                Description = acctSummary.Description,
                AcctTypeId = acctSummary.AcctTypeId,
                StartingBalance = acctSummary.StartingBalance,
                ReserveAmount = acctSummary.ReserveAmount,
                DateAdded = acctSummary.DateAdded,
                DateModified = acctSummary.DateModified,
                ExtAcctId = acctSummary.ExtAcctId,
                InstId = acctSummary.InstId,
                ImportFilePath = acctSummary.ImportFilePath,
                IsDeleted = acctSummary.IsDeleted,
                Credits = acctSummary.Credits,
                Debits = acctSummary.Debits,
                Total = acctSummary.Total,
                StagedCredits = acctSummary.StagedCredits,
                StagedDebits = acctSummary.StagedDebits,
                StagedTotal = acctSummary.StagedTotal,
                Balance = acctSummary.Balance,
                AvailableBalance = acctSummary.AvailableBalance,
                FinalBalance = acctSummary.FinalBalance
            };
        }

        public static IEnumerable<Transaction> Filter(this IEnumerable<Transaction> transactions, DateFilter dateFilter)
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

        public static IEnumerable<Transaction> Order(this IEnumerable<Transaction> transactions, SortOrder sortOrder)
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

        public static IEnumerable<Transaction> GetTransactionsByState(this MoneyBookDbContext db, int acctId, StateTypes state)
        {
            var results = db.Transactions
                .Where(x => x.IsDeleted == false && x.AcctId == acctId && x.Date.Year >= m_minYear && x.State == state.ToString())
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

        public static void Skip(this Reminder rem)
        {
            if (rem.Frequency == TransactionFrequency.Weekly.ToString())
            {
                rem.DueDate = rem.DueDate.AddDays(7);
            }
            else if (rem.Frequency == TransactionFrequency.BiWeekly.ToString())
            {
                rem.DueDate = rem.DueDate.AddDays(14);
            }
            else if (rem.Frequency == TransactionFrequency.Monthly.ToString())
            {
                rem.DueDate = rem.DueDate.AddMonths(1);
            }
            else if (rem.Frequency == TransactionFrequency.Quarterly.ToString())
            {
                rem.DueDate = rem.DueDate.AddMonths(3);
            }
            else if (rem.Frequency == TransactionFrequency.Yearly.ToString())
            {
                rem.DueDate = rem.DueDate.AddYears(1);
            }

            rem.DateModified = DateTime.Now.Date;
        }

        public static void Delete(this Reminder rem)
        {
            // Soft delete.
            rem.IsDeleted = true;
        }

        public static void SetState(this Transaction tran, StateTypes state)
        {
            tran.State = state.ToString();
        }

        public static decimal GetAmount(this Reminder rem)
        {
            return rem.TrnsType.Equals(TransactionTypes.DEBIT.ToString(), StringComparison.InvariantCultureIgnoreCase)
                ? -rem.Amount : rem.Amount;
        }

        public static decimal GetAmount(this Transaction tran)
        {
            return tran.TrnsType.Equals(TransactionTypes.DEBIT.ToString(), StringComparison.InvariantCultureIgnoreCase)
                ? -tran.Amount : tran.Amount;
        }

        public static void Delete(this Transaction tran)
        {
            // Soft delete.
            tran.IsDeleted = true;
        }

        public static DueStateTypes GetDueState(this DateTime dueDate)
        {
            if (dueDate.Date < DateTime.Now.Date)
            {
                return DueStateTypes.Past;
            }
            else if (dueDate.Date == DateTime.Now.Date)
            {
                return DueStateTypes.Today;
            }
            else if (dueDate.Date <= DateTime.Now.GetDateOfTarget(DueBeforeDay).Date)
            {
                return DueStateTypes.Soon;
            }
            else if (dueDate.AddDays(-7).Date <= DateTime.Now.Date)
            {
                return DueStateTypes.Upcoming;
            }
            else
            {
                return DueStateTypes.None;
            }
        }
    }
}
