namespace MoneyBookAPI
{
    public class TransactionInfo
    {
        public int TrnsId { get; set; }
        public DateTime Date { get; set; }
        public string TrnsType { get; set; }
        public string? RefNum { get; set; }
        public string Payee { get; set; }
        public string? Memo { get; set; }
        public string State { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }        
        public int AcctId { get; set; }
        public int CatId { get; set; }
    }
}
