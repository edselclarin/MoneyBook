using MoneyBook.Models;
using Ofx;

namespace MoneyBook.Data
{
    public class TransactionImporter
    {
        public delegate void LogHandler(string str);

        public event LogHandler OnLog;

        public static TransactionImporter Create()
        {
            return new TransactionImporter();
        }

        public void Import(string filename, string account)
        {
            var context = new OfxContext()
            {
                ImportFilePath = filename,
                AccountTo = account
            };

            OnLog?.Invoke($"Reading {filename}.");

            context.FromFile(filename);

            using var db = new MoneyBookDbContext();
            using var tc = db.Database.BeginTransaction();

            // Work with the first institution for now.
            var inst = db.Institutions.First();

            // Get account to import into.
            var acct = db.Accounts.FirstOrDefault(x => x.Name.ToUpper() == context.AccountTo.ToUpper());
            if (acct == null)
            {
                OnLog?.Invoke($"Could not find account named '{context.AccountTo.ToUpper()}'.");
                return;
            }

            OnLog?.Invoke($"Importing {context.Transactions.Count()} transactions to account '{acct.Name}'...");

            // Set all imported transactions to first category.
            var cat = db.Categories.First();

            foreach (var tr in context.Transactions)
            {
                bool exists = db.Transactions
                    .Where(x => x.Date == tr.DatePosted &&
                                x.Payee == tr.Memo &&
                                x.TrnsType == tr.TransactionType &&
                                x.Amount == tr.TransactionAmount)
                    .Count() > 0;

                // Add only new transactions.
                if (!exists)
                {
                    var trNew = new Transaction()
                    {
                        Date = tr.DatePosted,
                        TrnsType = tr.TransactionType,
                        Payee = tr.Memo,
                        State = State.GetAlias(StateTypes.Uncleared),
                        Amount = tr.TransactionAmount,
                        ExtTrnsId = tr.TransactionId,
                        InstId = inst.InstId,
                        AcctId = acct.AcctId,
                        CatId = cat.CatId
                    };

                    db.Transactions.Add(trNew);
                }
            }

            db.SaveChanges();

            tc.Commit();
        }
    }
}
