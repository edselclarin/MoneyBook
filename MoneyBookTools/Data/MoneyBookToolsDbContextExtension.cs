using MoneyBook.Data;
using MoneyBook.Models;
using Ofx;

namespace MoneyBookTools.Data
{
    public static class MoneyBookToolsDbContextExtension
    {
        public static void ImportTransactions(this MoneyBookDbContext db, string filename, string accountName)
        {
            var context = new OfxContext()
            {
                ImportFilePath = filename,
                AccountTo = accountName
            };

            context.FromFile(filename);

            // Get account to import into.
            var acct = db.Accounts.FirstOrDefault(x => x.Name.ToUpper() == context.AccountTo.ToUpper());
            if (acct == null)
            {
                throw new Exception($"Could not find account named '{context.AccountTo.ToUpper()}'.");
            }

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
                        AcctId = acct.AcctId,
                        CatId = cat.CatId
                    };

                    db.Transactions.Add(trNew);
                }
            }

            db.SaveChanges();
        }

        public static void UpdateAccountDetails(this MoneyBookDbContext db)
        {
            foreach (var acct in db.Accounts.ToList())
            {
                var transactions = db.Transactions
                    .Where(x => x.IsDeleted == false &&
                                x.AcctId == acct.AcctId)
                    .ToList();

                acct.Credits = transactions.Where(x => x.TrnsType.ToUpper() == "CREDIT").Sum(x => x.Amount);
                acct.Debits = transactions.Where(x => x.TrnsType.ToUpper() == "DEBIT").Sum(x => x.Amount);
                acct.Balance = acct.StartingBalance + acct.Credits - acct.Debits;
                acct.AvailableBalance = acct.Balance - acct.ReserveAmount;
                acct.DateModified = DateTime.Now;
            }

            db.SaveChanges();
        }
    }
}
