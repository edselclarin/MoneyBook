using MoneyBook.Data;
using MoneyBook.Models;
using Ofx;

namespace MoneyBook
{
    public class OfxTransactionImporter : ITransactionImporter
    {
        private MoneyBookDbContext m_db;
        private IEnumerable<AccountData> m_acctsData;

        public OfxTransactionImporter(MoneyBookDbContext dbContext, IEnumerable<AccountData> acctsData)
        {
            m_db = dbContext;
            m_acctsData = acctsData;
        }

        public void Import()
        {
            using var dbtran = m_db.Database.BeginTransaction();

            foreach (var ad in m_acctsData)
            {
                var context = new OfxContext()
                {
                    ImportFilePath = ad.ImportFilePath,
                    AccountTo = ad.Name
                };

                context.FromFile(ad.ImportFilePath);

                // Get account to import into.
                var acct = m_db.Accounts.FirstOrDefault(x => x.Name.ToUpper() == context.AccountTo.ToUpper());
                if (acct == null)
                {
                    throw new Exception($"Could not find account named '{context.AccountTo.ToUpper()}'.");
                }

                // Set all imported transactions to first category.
                var cat = m_db.Categories.First();

                // Process transactions from only this year.
                var transactions = context.Transactions
                    .Where(x => x.DatePosted.Year >= MoneyBookDbContextExtension.MinimumAccountYear)
                    .ToList();

                foreach (var tr in transactions)
                {
                    bool exists = m_db.Transactions
                        .Where(x => x.ExtTrnsId == tr.TransactionId)
                        .Count() > 0;

                    // Add only new transactions.
                    if (!exists)
                    {
                        var trNew = new Transaction()
                        {
                            Date = tr.DatePosted,
                            TrnsType = tr.TransactionType,
                            Payee = tr.Memo,
                            State = MoneyBookDbContextExtension.StateTypes.New.ToString(),
                            Amount = tr.TransactionAmount,
                            ExtTrnsId = tr.TransactionId,
                            AcctId = acct.AcctId,
                            CatId = cat.CatId
                        };

                        m_db.Transactions.Add(trNew);
                    }
                }

                m_db.SaveChanges();
            }

            dbtran.Commit();
        }
    }
}
