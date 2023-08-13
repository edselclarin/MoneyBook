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
}
