namespace MoneyBook.BusinessModels
{
    public class AccountInfo
    {
        public int AcctId { get; set; }
        public string AccountName { get; set; }
        public string Description { get; set; }
        public int AcctTypeId { get; set; }
        public decimal StartingBalance { get; set; }
        public decimal ReserveAmount { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }
    }
}
