namespace MoneyBookTools.Ofx
{
    public class OfxTransaction
    {
        public string TransactionType { get; set; }
        public DateTime DatePosted { get; set; }
        public DateTime DateAvailable { get; set; }
        public decimal TransactionAmount { get; set; }
        public Guid TransactionId { get; set; }
        public string Memo { get; set; }
    }
}
