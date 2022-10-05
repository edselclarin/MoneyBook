using MoneyBook.Models;
using MoneyBookTools.Ofx;
using System.Diagnostics;

namespace MoneyBookTools.Data
{
    public static class TransactionImporter
    {
        public static void Import(string filename)
        {
            Debug.WriteLine($"Importing from {filename}");

            var context = new OfxContext()
            {
                ImportFilePath = filename
            };

            context.FromFile(filename);

            Import(context);
        }

        public static void Import(OfxContext context)
        {
            using var db = new MoneyBookDbContext();
            using var tc = db.Database.BeginTransaction();
                
            // Work with the first institution for now.
            var inst = db.Institutions.First();

            // Detect which account to import into.
            string filename = Path.GetFileName(context.ImportFilePath);
            var acct = db.Accounts.FirstOrDefault(x => x.ImportFilename.ToUpper() == filename.ToUpper());

            if (acct == null)
            {
                throw new Exception($"{context.ImportFilePath} is not associated with an account.");
            }

            // Set all imported transactions to first category.
            var cat = db.Categories.First();

            foreach (var tr in context.Transactions)
            {
                Debug.WriteLine(String.Join(" | ", new string[]
                {
                    tr.DatePosted.ToString("MM-dd-yyyy"),
                    tr.Memo,
                    tr.TransactionAmount.ToString("0.00"),
                    tr.TransactionType
                }));

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
