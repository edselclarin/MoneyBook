using System;

namespace TransactionsTool.Models
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public DateTime PostDate { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? Type { get; set; }
        public decimal Amount { get; set; }
        public string? Memo { get; set; }
    }
}
