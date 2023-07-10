using MoneyBookAPI.Data;

namespace MoneyBookAPI
{
    public class AccountSummary
    {
        public AccountInfo Account { get; set; }

        public List<TransactionInfo> Transactions { get; set; }

        public decimal Credits => 
            Transactions.Where(x => x.TrnsType.ToUpper() == "CREDIT" &&
                x.State != MoneyBook.StateTypes.Ignored.ToString()).Sum(x => x.Amount);

        public decimal Debits => 
            Transactions.Where(x => x.TrnsType.ToUpper() == "DEBIT" &&
                x.State != MoneyBook.StateTypes.Ignored.ToString()).Sum(x => x.Amount);

        public decimal StagedBalance =>
            Transactions.Where(x => x.TrnsType.ToUpper() == "CREDIT" &&
                x.State == MoneyBook.StateTypes.Staged.ToString()).Sum(x => x.Amount) -
            Transactions.Where(x => x.TrnsType.ToUpper() == "DEBIT" &&
                x.State == MoneyBook.StateTypes.Staged.ToString()).Sum(x => x.Amount);

        public decimal Balance => Account.StartingBalance + Credits - Debits - StagedBalance;

        public decimal AvailableBalance => Balance - Account.ReserveAmount;

        public decimal FinalBalance => AvailableBalance + StagedBalance;
    }
}
