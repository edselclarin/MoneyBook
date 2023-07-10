using MoneyBookAPI.Data;

namespace MoneyBookAPI.Helpers
{
    public static class MoneyBookDbHelper
    {
        public static IEnumerable<TransactionInfo> GetTransactions(this MoneyBookDbContext db, int acctId)
        {
            var results = db.Transactions
                .Where(x => x.IsDeleted == false && x.AcctId == acctId && x.Date.Year >= MoneyBook.MinimumAccountYear)
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
    }
}
