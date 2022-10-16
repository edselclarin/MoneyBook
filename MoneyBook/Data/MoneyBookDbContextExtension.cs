using Microsoft.EntityFrameworkCore;
using MoneyBook.BusinessModels;
using MoneyBook.Models;

namespace MoneyBook.Data
{
    public static class MoneyBookDbContextExtension
    {
        public static async Task<IEnumerable<AccountInfo>> GetAccountsAsync(this MoneyBookDbContext db)
        {
            var results = await db.Accounts
                .Where(x => x.IsDeleted == false)
                .Join(db.Institutions, acct => acct.InstId, inst => inst.InstId, (acct, inst) => new AccountInfo
                {
                    AcctId = acct.AcctId,
                    AccountName = acct.Name,
                    Description = acct.Description,
                    AcctType = acct.AcctType,
                    StartingBalance = acct.StartingBalance,
                    ReserveAmount = acct.ReserveAmount,
                    Credits = acct.Credits,
                    Debits = acct.Debits,
                    Balance = acct.Balance,
                    AvailableBalance = acct.AvailableBalance,
                    DateAdded = acct.DateAdded,
                    DateModified = acct.DateModified
                })
                .ToListAsync();

            return results;
        }

        public static async Task<IEnumerable<InstitutionInfo>> GetInstitutionsAsync(this MoneyBookDbContext db)
        {
            var results = await db.Institutions
                .Where(x => x.IsDeleted == false)
                .Select(inst => new InstitutionInfo
                {
                    InstId = inst.InstId,
                    Name = inst.Name,
                    InstType = inst.InstType
                })
                .ToListAsync();

            return results;
        }

        public static async Task<IEnumerable<CategoryInfo>> GetCategoriesAsync(this MoneyBookDbContext db)
        {
            var results = await db.Categories
                .Where(x => x.IsDeleted == false)
                .Select(cat => new CategoryInfo
                {
                    CatId = cat.CatId,
                    Name = cat.Name
                })
                .ToListAsync();

            return results;
        }

        public enum DateFilter : int
        {
            TwoWeeks,
            ThisMonth,
            ThisYear
        }

        public enum SortOrder : int
        {
            Descending,
            Ascending
        }

        public static async Task<IEnumerable<TransactionInfo>> GetTransactionsAsync(this MoneyBookDbContext db, int acctId, DateFilter dateFilter, SortOrder sortOrder)
        {
            List<Transaction> results;

            switch (dateFilter)
            {
                case DateFilter.TwoWeeks:
                default:
                    results = await db.Transactions
                        .Where(x => x.IsDeleted == false && x.AcctId == acctId && x.Date >= DateTime.Now.AddDays(-14))
                        .ToListAsync();
                    break;
                case DateFilter.ThisMonth:
                    results = await db.Transactions
                        .Where(x => x.IsDeleted == false && x.AcctId == acctId && x.Date.Month == DateTime.Now.Month)
                        .ToListAsync();
                    break;
                case DateFilter.ThisYear:
                    results = await db.Transactions
                        .Where(x => x.IsDeleted == false && x.AcctId == acctId && x.Date.Year == DateTime.Now.Year)
                        .ToListAsync();
                    break;
            }

            IOrderedEnumerable<Transaction> sortedTransactions;

            switch (sortOrder)
            {
                case SortOrder.Ascending:
                    sortedTransactions = results.OrderBy(x => x.Date);
                    break;
                case SortOrder.Descending:
                default:
                    sortedTransactions = results.OrderByDescending(x => x.Date);
                    break;
            }

            return sortedTransactions
                .Select(trn => new TransactionInfo
                {
                    TrnsId = trn.TrnsId,
                    Date = trn.Date,
                    TrnsType = trn.TrnsType,
                    RefNum = trn.RefNum,
                    Payee = trn.Payee,
                    Memo = trn.Memo,
                    State = trn.State,
                    Amount = trn.Amount,
                    DateAdded = trn.DateAdded,
                    DateModified = trn.DateModified,
                    AcctId = trn.AcctId,
                    CatId = trn.CatId
                });
        }

        public static async Task<IEnumerable<RecurringTransactionInfo>> GetRecurringTransactionsAsync(this MoneyBookDbContext db, int acctId, DateFilter dateFilter, SortOrder sortOrder)
        {
            List<RecurringTransaction> results;

            switch (dateFilter)
            {
                case DateFilter.TwoWeeks:
                default:
                    results = await db.RecurringTransactions
                        .Where(x => x.IsDeleted == false && x.AcctId == acctId && x.Date >= DateTime.Now.AddDays(-14))
                        .ToListAsync();
                    break;
                case DateFilter.ThisMonth:
                    results = await db.RecurringTransactions
                        .Where(x => x.IsDeleted == false && x.AcctId == acctId && x.Date.Month == DateTime.Now.Month)
                        .ToListAsync();
                    break;
                case DateFilter.ThisYear:
                    results = await db.RecurringTransactions
                        .Where(x => x.IsDeleted == false && x.AcctId == acctId && x.Date.Year == DateTime.Now.Year)
                        .ToListAsync();
                    break;
            }

            IOrderedEnumerable<RecurringTransaction> sortedTransactions;

            switch (sortOrder)
            {
                case SortOrder.Ascending:
                    sortedTransactions = results.OrderBy(x => x.Date);
                    break;
                case SortOrder.Descending:
                default:
                    sortedTransactions = results.OrderByDescending(x => x.Date);
                    break;
            }

            return sortedTransactions
                .Select(trn => new RecurringTransactionInfo
                {
                    RecTrnsId = trn.RecTrnsId,
                    Date = trn.Date,
                    TrnsType = trn.TrnsType,
                    Payee = trn.Payee,
                    State = trn.State,
                    Amount = trn.Amount,
                    DateAdded = trn.DateAdded,
                    DateModified = trn.DateModified,
                    AcctId = trn.AcctId,
                    CatId = trn.CatId
                });
        }
    }
}
