using System.ComponentModel;

namespace MoneyBook.BusinessModels
{
    public class AccountInfo
    {
        [Browsable(false)]
        public int AcctId { get; set; }

        public string AccountName { get; set; }

        public string Description { get; set; }

        public string AcctType { get; set; }

        [Browsable(false)]
        public decimal StartingBalance { get; set; }

        [Browsable(false)] 
        public decimal ReserveAmount { get; set; }

        [Browsable(false)] 
        public int InstId { get; set; }

        public string InstitutionName { get; set; }
    }
}
