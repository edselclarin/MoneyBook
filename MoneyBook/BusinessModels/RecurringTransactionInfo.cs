namespace MoneyBook.BusinessModels
{
    public class RecurringTransactionInfo
    {
        public int RecTrnsId { get; set; }
        public DateTime DueDate { get; set; }
        public string TrnsType { get; set; }
        public string Payee { get; set; }
        public string Memo { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }
        public int AcctId { get; set; }
        public int CatId { get; set; }
    }
}
