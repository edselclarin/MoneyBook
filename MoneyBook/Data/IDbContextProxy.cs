using Microsoft.EntityFrameworkCore.Storage;
using MoneyBook.Models;

namespace MoneyBook.Data
{
    public interface IDbContextProxy
    {
        void DeleteAllTransactions();
        void ImportReminders(string filename);
        void ExportReminders(string filename);
        void SetStateNewToReconciled(int acctId);
        IEnumerable<AccountSummary> GetAccountSummaries();
        AccountSummary? GetAccountSummary(int acctId);
        IEnumerable<Transaction> GetAllTransactions();
        IEnumerable<Transaction> GetAccountTransactions(int acctId);
        IEnumerable<Transaction> GetTransactionsByState(int acctId, StateTypes state);
        void SetTransactionStates(IEnumerable<Transaction> transactions, StateTypes state);
        void DeleteTransactions(IEnumerable<Transaction> transactions);
        void BackupDatabase(string backupDir);
        void RestoreDatabase(string filename);
        IEnumerable<Reminder> GetReminders(SortMode sortOrder);
        Task<IEnumerable<Account>> GetAccountsAsync(int skip = 0, int take = 100);
        void SkipReminders(IEnumerable<Reminder> reminders);
        void CopyReminders(IEnumerable<Reminder> reminders);
        void DeleteReminders(IEnumerable<Reminder> reminders);
        IEnumerable<Category> GetCategories();
        IDbContextTransaction CreateContextTransaction();
        void AddTransactions(IEnumerable<Transaction> transactions);
        void ImportTransactions();
        void AddTransaction(Transaction transaction);
        void UpdateTransaction(Transaction transaction);
        void AddReminder(Reminder reminder);
        void UpdateReminder(Reminder reminder);
        void StageReminders(IEnumerable<Reminder> reminders);
    }
}
