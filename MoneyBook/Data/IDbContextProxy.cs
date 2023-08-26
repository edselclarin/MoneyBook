using Microsoft.EntityFrameworkCore.Storage;
using MoneyBook.BusinessModels;
using MoneyBook.Models;

namespace MoneyBook.Data
{
    public interface IDbContextProxy
    {
        void DeleteAllTransactions();
        void ImportReminders(string filename);
        void ExportReminders(string filename);
        void SetStateNewToReconciled(int acctId);
        List<AccountSummary> GetAccountSummariesNew();
        AccountSummary? GetAccountSummaryNew(int acctId);
        IEnumerable<TransactionInfo> GetTransactionInfos(int acctId);
        IEnumerable<Transaction> GetTransactions();
        void SetTransactionStates(IEnumerable<TransactionInfo> transactions, MoneyBookDbContextExtension.StateTypes state);
        void DeleteTransactions(IEnumerable<TransactionInfo> transactions);
        void BackupDatabase(string backupDir);
        void RestoreDatabase(string filename);
        IEnumerable<ReminderInfo> GetReminders(MoneyBookDbContextExtension.SortOrder sortOrder);
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
