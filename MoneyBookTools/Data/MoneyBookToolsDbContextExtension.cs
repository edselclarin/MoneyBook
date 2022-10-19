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

            // Update account data.
            var transactions = db.Transactions
                .Where(x => x.IsDeleted == false && x.AcctId == acct.AcctId)
                .ToList();
            acct.RecalculateAccountData(transactions);

            db.SaveChanges();
        }

        public static void UpdateStartingBalance(this MoneyBookDbContext db, string acctName, decimal startingBalance)
        {
            var acct = db.Accounts.FirstOrDefault(x => x.Name == acctName);
            if (acct != null)
            {
                acct.StartingBalance = startingBalance;

                var transactions = db.Transactions
                    .Where(x => x.IsDeleted == false && x.AcctId == acct.AcctId)
                    .ToList();
                acct.RecalculateAccountData(transactions);

                db.SaveChanges();
            }
        }

        public static void ResetStartingBalances(this MoneyBookDbContext db)
        {
            var accounts = db.Accounts.ToList();

            foreach (var acct in accounts)
            {
                acct.StartingBalance = 0m;

                var transactions = db.Transactions
                    .Where(x => x.IsDeleted == false && x.AcctId == acct.AcctId)
                    .ToList();
                acct.RecalculateAccountData(transactions);
            }

            db.SaveChanges();
        }

        public static void DeleteAllTransactions(this MoneyBookDbContext db)
        {
            db.Transactions.RemoveRange(db.Transactions);

            db.SaveChanges();

            var accounts = db.Accounts.ToList();
            
            foreach (var acct in accounts)
            {
                var transactions = db.Transactions
                    .Where(x => x.IsDeleted == false && x.AcctId == acct.AcctId)
                    .ToList();
                acct.RecalculateAccountData(transactions);
            }

            db.SaveChanges();
        }

        public static void ImportRecurringTransactions(this MoneyBookDbContext db, IEnumerable<RepeatingTransaction> repeatingTransactions)
        {
            var accounts = db.Accounts.ToList();

            // Get account to import into.
            // Set all imported transactions to first category.
            var cat = db.Categories.First();

            foreach (var tr in repeatingTransactions)
            {
                var acct = accounts.SingleOrDefault(x => x.Name == tr.Account);

                if (acct != null)
                {

                    bool exists = db.RecurringTransactions
                        .Where(x => x.DueDate == tr.DueDate &&
                                    x.TrnsType == tr.TrnsType &&
                                    x.Payee == tr.Payee &&
                                    x.Memo == tr.Memo &&
                                    x.Amount == tr.Amount &&
                                    x.Frequency == tr.Frequency)
                        .Count() > 0;

                    // Add only new transactions.
                    if (!exists)
                    {
                        var trNew = new RecurringTransaction()
                        {
                            DueDate = tr.DueDate,
                            TrnsType = tr.TrnsType,
                            Payee = tr.Payee,
                            Memo = tr.Memo,
                            Amount = tr.Amount,
                            Frequency = tr.Frequency,
                            AcctId = acct.AcctId,
                            CatId = cat.CatId
                        };

                        db.RecurringTransactions.Add(trNew);
                    }
                }
            }

            db.SaveChanges();
        }

        public static void DeleteAllRecurringTransactions(this MoneyBookDbContext db)
        {
            db.RecurringTransactions.RemoveRange(db.RecurringTransactions);

            db.SaveChanges();
        }
    }
}
