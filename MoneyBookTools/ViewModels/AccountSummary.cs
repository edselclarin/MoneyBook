using System.ComponentModel;

namespace MoneyBookTools.ViewModels
{
    public class AccountSummary
    {
        [DisplayName("Account")]
        public string AccountName { get; set; }

        [DisplayName("Available Balance")]
        public decimal AvailableBalance { get; set; }
    }
}
