using System.ComponentModel;

namespace MoneyBookTools.ViewModels
{
    public class AccountSummary
    {
        [Browsable(false)]
        public int AcctId { get; set; }

        public string Account { get; set; }

        public decimal Balance { get; set; }
    }
}
