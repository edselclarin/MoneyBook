namespace MoneyBook.BusinessModels
{
    public class AccountInfo
    {
        public int AcctId { get; set; }
        public string AccountName { get; set; }
        public string Description { get; set; }
        public string AcctType { get; set; }
        public decimal StartingBalance { get; set; }
        public decimal ReserveAmount { get; set; }
        public int InstId { get; set; }
        public string InstitutionName { get; set; }
    }
}
