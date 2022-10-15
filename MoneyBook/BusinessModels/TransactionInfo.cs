using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MoneyBook.BusinessModels
{
    public class TransactionInfo
    {
        [Browsable(false)]
        public int TrnsId { get; set; }

        public DateTime Date { get; set; }

        public string TrnsType { get; set; }

        public string? RefNum { get; set; }

        public string Payee { get; set; }

        public string? Memo { get; set; }

        public string State { get; set; }

        public decimal Amount { get; set; }

        [Browsable(false)]
        public DateTime DateAdded { get; set; }

        [Browsable(false)]
        public DateTime DateModified { get; set; }
        
        [Browsable(false)] 
        public int InstId { get; set; }

        [Browsable(false)] 
        public int AcctId { get; set; }

        [Browsable(false)] 
        public int CatId { get; set; }
    }
}
