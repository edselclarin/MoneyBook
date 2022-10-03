namespace MoneyBook.Models
{
    public class Account
    {
        public int AcctId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int InstId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
