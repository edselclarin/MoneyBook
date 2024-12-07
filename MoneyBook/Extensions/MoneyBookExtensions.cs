using Autofac;
using MoneyBook.Data;
using MoneyBook.Models;

namespace MoneyBook.Extensions
{
    public static class MoneyBookExtensions
    {
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
                case DateFilter.ThreeMonthsAgo:
                    return transactions
                        .Where(x => x.Date >= DateTime.Now.AddDays(-DateTime.Now.Date.Day).AddMonths(-2).Date);
                case DateFilter.ThisYear:
                    return transactions
                        .Where(x => x.Date.Year == DateTime.Now.Year);
                case DateFilter.None:
                default:
                    return transactions;
            }
        }

        public static IEnumerable<Transaction> Order(this IEnumerable<Transaction> transactions, SortMode sortOrder)
        {
            switch (sortOrder)
            {
                case SortMode.Ascending:
                    return transactions.OrderBy(x => x.Date);
                case SortMode.Descending:
                    return transactions.OrderByDescending(x => x.Date);
                default:
                    return transactions;
                    break;
            }
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
            else if (dueDate.Date <= DateTime.Now.GetDateOfTarget(MoneyBookGlobals.DueBeforeDay).Date)
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
