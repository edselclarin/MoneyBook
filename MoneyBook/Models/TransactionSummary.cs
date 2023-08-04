using System.ComponentModel.DataAnnotations;

namespace MoneyBook.Models
{
    public class TransactionSummary
    {
        [Key]
        public int AcctId { get; set; }
        public decimal Credits { get; set; }
        public decimal Debits { get; set; }
        public decimal Total { get; set; }
        public decimal StagedCredits { get; set; }
        public decimal StagedDebits { get; set; }
        public decimal StagedTotal { get; set; }
    }
}
