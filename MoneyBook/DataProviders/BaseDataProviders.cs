using Microsoft.EntityFrameworkCore.Storage;
using MoneyBook.Data;

namespace MoneyBook.DataProviders
{
    public abstract class BaseDataProvider
    {
        protected MoneyBookDbContext db_;
        public MoneyBookDbContext Db => db_;

        protected BaseDataProvider()
        {
            db_ = new MoneyBookDbContext();
        }

        public IDbContextTransaction CreateDbTransaction()
        {
            return db_.Database.BeginTransaction();
        }
    }
}
