namespace MoneyBook.Models
{
    public class BackupContext
    {
        public DateTime DateCreated { get; set; }
        public List<Transaction> Transactions { get; set; }
        public List<Reminder> Reminders { get; set; }
        public List<Account> Accounts { get; set; }
        public List<Institution> Institutions { get; set; }
        public List<Category> Categories { get; set; }
    }
}
