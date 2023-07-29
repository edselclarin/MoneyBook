using MoneyBook.Data;
using MoneyBook.Models;
using Ofx;

namespace MoneyBook
{
    public class OfxTransactionImporter : ITransactionImporter
    {
        private MoneyBookDbContext m_db;

        public OfxTransactionImporter(MoneyBookDbContext dbContext)
        {
            m_db = dbContext;
        }

        public void Import()
        {
            using var dbtran = m_db.Database.BeginTransaction();
            var accts = m_db.Accounts.ToList();

            foreach (var acct in accts)
            {
                if (String.IsNullOrEmpty(acct.ImportFilePath))
                {
                    continue;
                }

                if (!File.Exists(acct.ImportFilePath))
                {
                    continue;
                }

                var context = new OfxContext()
                {
                    ImportFilePath = acct.ImportFilePath,
                    AccountTo = acct.Name
                };

                context.FromFile(acct.ImportFilePath);

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
