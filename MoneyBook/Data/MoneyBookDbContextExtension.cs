using MoneyBook.Models;

namespace MoneyBook.Data
{
    public static class MoneyBookDbContextExtension
    {
        public static IList<AccountDetail> GetAccountDetails(this MoneyBookDbContext db)
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
