using System.ComponentModel.DataAnnotations;

namespace MoneyBook.Models
{
    public class AccountSummaryModel
    {
        [Key]
        public int AcctId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AcctTypeId { get; set; }
        public decimal StartingBalance { get; set; }
        public decimal ReserveAmount { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }
        public string ExtAcctId { get; set; }
        public int InstId { get; set; }
        public string ImportFilePath { get; set; }
        public bool IsDeleted { get; set; }
        public decimal Credits { get; set; }
        public decimal Debits { get; set; }
        public decimal Total { get; set; }
        public decimal StagedCredits { get; set; }
        public decimal StagedDebits { get; set; }
        public decimal StagedTotal { get; set; }
        public decimal Balance { get; set; }
        public decimal AvailableBalance { get; set; }
        public decimal FinalBalance { get; set; }
    }
}
