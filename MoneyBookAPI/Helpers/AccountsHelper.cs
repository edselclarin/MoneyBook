using MoneyBookAPI.Data;

namespace MoneyBookAPI.Helpers
{
    public static class AccountsHelper
    {
        public static IEnumerable<Account> GetAccounts(this MoneyBookDbContext db)
        {
            return db.Accounts
                .Where(x => x.IsDeleted == false)
                .AsEnumerable();
        }

        public static PagedResponse<Account> GetAccounts(this MoneyBookDbContext db, int page, int pageSize)
        {
            var accts = db.GetAccounts();

            var totalItems = accts.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            var pagedData = accts
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedResponse<Account>
            {
                Data = pagedData,
                Page = page,
                PageSize = pageSize,
                TotalPages = totalPages,
                TotalItems = totalItems
            };
        }
        
        public static Account? GetAccount(this MoneyBookDbContext db, int acctId)
        {
            return db.GetAccounts()
                .SingleOrDefault(x => x.AcctId == acctId);
        }

        public static AccountSummary? GetAccountSummary(this MoneyBookDbContext db, int acctId)
        {
            if (db.GetAccount(acctId) is not Account acct ||
                db.GetTransactions(acctId) is not IEnumerable<Transaction> trans)
            {
                return null;
            }

            return AccountSummary.Create(acct, trans);
        }
    }
}
