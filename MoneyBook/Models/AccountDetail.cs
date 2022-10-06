namespace MoneyBook.Models
{
    public class AccountDetail
    {
        public Account Account { get; set; }
        public Institution Institution { get; set; }
        public IList<Transaction> Transactions { get; set; }
        public decimal AvailableBalance
        {
            get
            {
                decimal credits = Transactions.Where(x => x.TrnsType.ToUpper() == "CREDIT").Sum(x => x.Amount);
                decimal debits = Transactions.Where(x => x.TrnsType.ToUpper() == "DEBIT").Sum(x => x.Amount);
                decimal availableBalance = Account.StartingBalance + credits - debits - Account.ReserveAmount;
                return availableBalance;
            }
        }
    }
}
