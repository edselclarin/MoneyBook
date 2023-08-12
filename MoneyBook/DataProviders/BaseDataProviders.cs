using MoneyBook.Data;
using MoneyBook.Models;

namespace MoneyBook.DataProviders
{
    public abstract class BaseDataProvider
    {
        protected MoneyBookDbContext db_;

        protected BaseDataProvider()
        {
            db_ = MoneyBookDbContext.Create(MoneyBookToolsDbContextConfig.Instance);
        }
    }

    public static class DataProviderFactory
    {
        public static BaseDataProvider Create(Type entityType)
        {
            if (entityType == typeof(AccountSummaryModel))
            {
                return new AccountSummaryDataProvider();
            }
            else if (entityType == typeof(Account))
            {
                return new AccountDataProvider();
            }
            else if (entityType == typeof(Transaction))
            {
                return new TransactionDataProvider();
            }
            else if (entityType == typeof(Reminder))
            {
                return new ReminderDataProvider();
            }
            else
            {
                throw new Exception("No data provider available.");
            }
        }
    }
}
