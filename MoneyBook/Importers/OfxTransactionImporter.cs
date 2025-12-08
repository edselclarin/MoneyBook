using Autofac;
using MoneyBook.Data;
using MoneyBook.Models;
using Ofx;

namespace MoneyBook
{
    public class OfxTransactionImporter : ITransactionImporter
    {
        private readonly IDbContextProxy m_dbProxy;

        public OfxTransactionImporter(IDbContextProxy dbProxy)
        {
            m_dbProxy = dbProxy;
        }

        public async void Import()
        {
            var accts = await m_dbProxy.GetAccountsAsync(0, 100);

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
                var cat = m_dbProxy.GetCategories().First();

                // Process transactions from only this year.
                var transactions = context.Transactions
                    .Where(x => x.DatePosted.Year >= MoneyBookGlobals.MinimumAccountYear)
                    .ToList();

                var newTransactions = new List<Transaction>();

                foreach (var tr in transactions)
                {
                    bool exists = m_dbProxy.GetAllTransactions()
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
                            State = StateTypes.New.ToString(),
                            Amount = tr.TransactionAmount,
                            ExtTrnsId = tr.TransactionId,
                            AcctId = acct.AcctId,
                            CatId = cat.CatId
                        };

                        newTransactions.Add(trNew);
                    }
                }

                m_dbProxy.AddTransactions(newTransactions);
            }
        }

        public async Task ImportAsync()
        {
            var accts = await m_dbProxy.GetAccountsAsync(0, 100);

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
                var cat = m_dbProxy.GetCategories().First();

                // Process transactions from only this year.
                var transactions = context.Transactions
                    .Where(x => x.DatePosted.Year >= MoneyBookGlobals.MinimumAccountYear)
                    .ToList();

                var newTransactions = new List<Transaction>();

                foreach (var tr in transactions)
                {
                    bool exists = m_dbProxy.GetAllTransactions()
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
                            State = StateTypes.New.ToString(),
                            Amount = tr.TransactionAmount,
                            ExtTrnsId = tr.TransactionId,
                            AcctId = acct.AcctId,
                            CatId = cat.CatId
                        };

                        newTransactions.Add(trNew);
                    }
                }

                m_dbProxy.AddTransactions(newTransactions);
            }
        }
    }
}
