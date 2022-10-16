using System.ComponentModel;

namespace MoneyBookTools.ViewModels
{
    public class ViewAccount
    {
        [Browsable(false)]
        public int AcctId { get; set; }

        public string Account { get; set; }

        [Browsable(false)]
        public decimal StartingBalance { get; set; }

        [Browsable(false)]
        public decimal ReserveAmount { get; set; }

        public decimal Credits { get; set; }

        public decimal Debits { get; set; }

        public decimal Balance { get; set; }

        public decimal AvailableBalance { get; set; }
    }
}
