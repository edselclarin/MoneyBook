using System.Text;

namespace MoneyBook.Data
{
    public class AccountDetailsUpdater
    {
        public delegate void LogHandler(string str);

        public event LogHandler OnLog;

        public static AccountDetailsUpdater Create()
        {
            return new AccountDetailsUpdater();
        }

        public void UpdateAll()
        {
            using var db = new MoneyBookDbContext();
            using var tc = db.Database.BeginTransaction();

            foreach (var acct in db.Accounts.ToList())
            {
                var transactions = db.Transactions
                    .Where(x => x.IsDeleted == false &&
                                x.AcctId == acct.AcctId)
                    .ToList();

                var acctDet = db.AccountDetails.FirstOrDefault(x => x.AcctId == acct.AcctId);
                if (acctDet == null)
                {
                    OnLog?.Invoke($"ERROR: Cannot find details for account '{acct.Name}'.");
                    continue;
                }

                acctDet.Credits = transactions.Where(x => x.TrnsType.ToUpper() == "CREDIT").Sum(x => x.Amount);
                acctDet.Debits = transactions.Where(x => x.TrnsType.ToUpper() == "DEBIT").Sum(x => x.Amount);
                acctDet.ActualBalance = acct.StartingBalance + acctDet.Credits - acctDet.Debits;
                acctDet.AvailableBalance = acctDet.ActualBalance - acct.ReserveAmount;
                acctDet.DateModified = DateTime.Now.Date;

                var sb = new StringBuilder();
                sb.Append($"Updating account details for '{acct.Name}': ");
                sb.Append($"Credits = {acctDet.Credits}, ");
                sb.Append($"Debits = {acctDet.Debits}, ");
                sb.Append($"ActualBalance = {acctDet.ActualBalance}, ");
                sb.Append($"AvailableBalance = {acctDet.AvailableBalance}, ");
                sb.Append($"DateModified = {acctDet.DateModified}.");
                OnLog?.Invoke(sb.ToString());
            }

            db.SaveChanges();

            tc.Commit();
        }
    }
}
