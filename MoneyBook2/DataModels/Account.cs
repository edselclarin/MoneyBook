using MoneyBook.Models;

namespace MoneyBook2.DataModels
{
    public class Account : AccountSummary
    {
        public decimal TotalDues { get; set; }

        public decimal RemainingBalance => AvailableBalance + TotalDues;

        public static Account FromAccountSummary(AccountSummary summary)
        {
            return new Account()
            {
                AcctId = summary.AcctId,
                Name = summary.Name,
                Description = summary.Description,
                AcctTypeId = summary.AcctTypeId,
                StartingBalance = summary.StartingBalance,
                ReserveAmount = summary.ReserveAmount,
                DateAdded = summary.DateAdded,
                DateModified = summary.DateModified,
                ExtAcctId = summary.ExtAcctId,
                InstId = summary.InstId,
                ImportFilePath = summary.ImportFilePath,
                IsDeleted = summary.IsDeleted,
                Credits = summary.Credits,
                Debits = summary.Debits,
                Total = summary.Total,
                StagedCredits = summary.StagedCredits,
                StagedDebits = summary.StagedDebits,
                StagedTotal = summary.StagedTotal,
                Balance = summary.Balance,
                AvailableBalance = summary.AvailableBalance,
                FinalBalance = summary.FinalBalance,
            };
        }
    }
}
