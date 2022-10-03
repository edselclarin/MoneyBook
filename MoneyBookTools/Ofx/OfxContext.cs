namespace MoneyBookTools.Ofx
{
    public class OfxContext
    {
        public OfxAccount AcctFrom { get; set; }
        public IList<OfxTransaction> Transactions { get; set; }
    }

    public class OfxAccount
    {
        public string BankId { get; set; }
        public string AcctId { get; set; }
        public string AcctType { get; set; }
    }

    public class OfxTransaction
    {
        public string TransactionType { get; set; }
        public DateTime DatePosted { get; set; }
        public DateTime DateAvailable { get; set; }
        public decimal TransactionAmount { get; set; }
        public string TransactionId { get; set; }
        public string Memo { get; set; }
    }
}
