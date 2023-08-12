using MoneyBook.Data;
using MoneyBook.Models;

namespace MoneyBook.DataProviders
{
    public abstract class BaseDataProvider
    {
        protected MoneyBookDbContext db_;
        public MoneyBookDbContext Db => db_;

        protected BaseDataProvider()
        {
            db_ = MoneyBookDbContext.Create(MoneyBookToolsDbContextConfig.Instance);
        }

        public MoneyBookDbTransaction CreateDbTransaction()
        {
            return new MoneyBookDbTransaction(Db);
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
            else if (entityType == typeof(AccountType))
            {
                return new AccountTypeDataProvider();
            }
            else if (entityType == typeof(Institution))
            {
                return new InstitutionDataProvider();
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
                throw new Exception($"Could not find a data provider available for {entityType.Name}.");
            }
        }
    }
}
