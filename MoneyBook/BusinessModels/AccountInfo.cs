using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MoneyBook.BusinessModels
{
    public class AccountInfo
    {
        [Browsable(false)]
        public int AcctId { get; set; }

        public string AccountName { get; set; }

        public string Description { get; set; }

        public string AcctType { get; set; }

        public decimal StartingBalance { get; set; }

        public decimal ReserveAmount { get; set; }

        public decimal Credits { get; set; }

        public decimal Debits { get; set; }

        public decimal Balance { get; set; }

        public decimal AvailableBalance { get; set; }

        [Browsable(false)]
        public DateTime DateAdded { get; set; }

        [Browsable(false)]
        public DateTime DateModified { get; set; }
        
        [Browsable(false)] 
        public int InstId { get; set; }

        public string InstitutionName { get; set; }
    }
}
