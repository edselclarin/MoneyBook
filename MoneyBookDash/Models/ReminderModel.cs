using System;

namespace MoneyBookDash.Models
{
    public class ReminderModel
    {
        public int RmdrId { get; set; }
        public DateTime DueDate { get; set; }
        public string Payee { get; set; }
        public decimal Amount { get; set; }
        public int AcctId { get; set; }
        public string AcctName { get; set; }
    }
}
