using MoneyBook.Models;
using MoneyBookTools.Ofx;

namespace MoneyBookTools.Data
{
    public static class TransactionImporter
    {
        public static void Import(string filename)
        {
            var context = new OfxContext();
            context.FromFile(filename);
            Import(context);
        }

        public static void Import(OfxContext context)
        {
            using var db = new MoneyBookDbContext();
            using var tc = db.Database.BeginTransaction();
                
            // Work with the first institution for now.
            var inst = db.Institutions.First();

            // Detect account from.
            var acct = db.Accounts.First(x => x.ExtAcctId == context.AcctFrom.AcctId);

            var transactions = db.Set<Transaction>();
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
                        CatId = 0
                    };

                    db.Transactions.Add(trNew);
                }
            }

            db.SaveChanges();

            tc.Commit();
        }
    }
}
