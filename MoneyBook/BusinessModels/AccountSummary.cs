namespace MoneyBook.BusinessModels
{
    public class AccountSummary
    {
        public AccountInfo Account { get; set; }

        public List<TransactionInfo> Transactions { get; set; }

        public decimal Credits => 
            Transactions.Where(x => x.TrnsType.ToUpper() == "CREDIT").Sum(x => x.Amount);

        public decimal Debits => 
            Transactions.Where(x => x.TrnsType.ToUpper() == "DEBIT").Sum(x => x.Amount);

        public decimal PendingBalance => 
            Transactions.Where(x => x.State == Data.MoneyBookDbContextExtension.StateTypes.Pending.ToString())
            .Sum(x => x.Amount);

        public decimal Balance => Account.StartingBalance + Credits - Debits + PendingBalance;

        public decimal AvailableBalance => Balance - Account.ReserveAmount;
    }
}
