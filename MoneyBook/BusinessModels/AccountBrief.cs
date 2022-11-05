namespace MoneyBook.BusinessModels
{
    public class AccountBrief
    {
        public AccountInfo Account { get; set; }
        public decimal Credits { get; set; }
        public decimal Debits { get; set; }
        public decimal PendingBalance { get; set; }
        public decimal Balance { get; set; }
        public decimal AvailableBalance { get; set; }
    }
}
