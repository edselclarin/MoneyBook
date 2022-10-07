using MoneyBook.Models;

namespace MoneyBookApi.Data
{
    public static class MoneyBookApiDbContextExtension
    {
        public static IList<AccountDetail> GetAccountDetails(this MoneyBookApiDbContext db)
        {
            var list = new List<AccountDetail>();

            foreach (var acct in db.Accounts.ToList())
            {
                var acctDetails = new AccountDetail()
                {
                    Account = acct,
                    Institution = db.Institutions.FirstOrDefault(x => x.InstId == acct.InstId),
                    Transactions = db.Transactions.Where(x => x.AcctId == acct.AcctId).ToList()
                };

                list.Add(acctDetails);
            }

            return list;
        }
    }
}
