using Microsoft.EntityFrameworkCore.Storage;
using MoneyBook.Models;

namespace MoneyBook.Data
{
    public interface IDbContextProxy : 
        IAccountProxy, 
        ITransactionProxy, 
        IReminderProxy, 
        ICategoryProxy, 
        IContextTransactionProxy, 
        IDatabaseManagementProxy
    {
    }

    public interface IAccountProxy
    {
        Task<IEnumerable<Account>> GetAccountsAsync(int skip = 0, int take = 100);
        IEnumerable<AccountSummary> GetAccountSummaries();
        AccountSummary? GetAccountSummary(int acctId);
    }

    public interface ITransactionProxy
    {
        IEnumerable<Transaction> GetAllTransactions();
        IEnumerable<Transaction> GetAccountTransactions(int acctId);
        IEnumerable<Transaction> GetTransactionsByState(int acctId, StateTypes state);
        void SetTransactionStates(IEnumerable<Transaction> transactions, StateTypes state);
        void SetStateNewToReconciled(int acctId);
        void DeleteTransactions(IEnumerable<Transaction> transactions);
        void DeleteAllTransactions();
        void AddTransactions(IEnumerable<Transaction> transactions);
        void ImportTransactions();
        void AddTransaction(Transaction transaction);
        void UpdateTransaction(Transaction transaction);
    }

    public interface IReminderProxy
    {
        IEnumerable<Reminder> GetReminders(SortMode sortOrder);
        void AddReminder(Reminder reminder);
        void UpdateReminder(Reminder reminder);
        void DeleteReminders(IEnumerable<Reminder> reminders);
        void CopyReminders(IEnumerable<Reminder> reminders);
        void SkipReminders(IEnumerable<Reminder> reminders);
        void StageReminders(IEnumerable<Reminder> reminders);
    }

    public interface ICategoryProxy
    {
        IEnumerable<Category> GetCategories();
    }

    public interface IContextTransactionProxy
    {
        IDbContextTransaction CreateContextTransaction();
    }

    public interface IDatabaseManagementProxy
    {
        void BackupDatabase(string backupDir);
        void RestoreDatabase(string filename);
    }
}
