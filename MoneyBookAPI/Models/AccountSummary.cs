using MoneyBookAPI.Data;
using MoneyBookAPI.Helpers;

namespace MoneyBookAPI
{
    public class AccountSummary
    {
        public Account Account { get; set; }
        public decimal Credits { get; set; }
        public decimal Debits { get; set; }
        public decimal StagedBalance { get; set; }

        public decimal Balance => Account.StartingBalance + Credits - Debits - StagedBalance;
        public decimal AvailableBalance => Balance - Account.ReserveAmount;
        public decimal FinalBalance => AvailableBalance + StagedBalance;

        protected AccountSummary() { }

        public static AccountSummary Create(Account acct, IEnumerable<Transaction> trans)
        {
            return new AccountSummary()
            {
                Account = acct,
                Credits = trans.GetCredits(),
                Debits = trans.GetDebits(),
                StagedBalance = trans.GetStagedBalance()
            };
        }
    }
}
