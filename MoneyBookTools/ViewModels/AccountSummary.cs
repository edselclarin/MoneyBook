using System.ComponentModel;

namespace MoneyBookTools.ViewModels
{
    public class AccountSummary
    {
        [Browsable(false)]
        public int AcctId { get; set; }

        [DisplayName("Account")]
        public string AccountName { get; set; }

        [DisplayName("Available Balance")]
        public decimal AvailableBalance { get; set; }
    }
}
