using MoneyBook.Models;

namespace MoneyBook.BusinessModels
{
    public class DatabaseBackup
    {
        public DateTime DateCreated { get; set; }
        public List<Transaction> Transactions { get; set; }
        public List<RecurringTransaction> RecurringTransactions { get; set; }
        public List<Account> Accounts { get; set; }
        public List<Institution> Institutions { get; set; }
        public List<Category> Categories { get; set; }
    }
}
