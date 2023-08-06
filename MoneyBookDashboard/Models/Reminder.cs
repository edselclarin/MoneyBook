using System;

namespace MoneyBookDashboard.Models
{
    public class Reminder
    {
        public int RmdrId { get; set; }
        public DateTime DueDate { get; set; }
        public string Payee { get; set; }
        public string Memo { get; set; }
        public string Website { get; set; }
        public decimal Amount { get; set; }
        public string Frequency { get; set; }   
    }
}
