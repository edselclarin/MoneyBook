using Autofac;
using Microsoft.EntityFrameworkCore;
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
            db_ = (MoneyBookDbContext)MoneyBookContainerBuilder.Container.Resolve<DbContext>();
        }

        public IDbContextTransaction CreateDbTransaction()
        {
            return db_.Database.BeginTransaction();
        }
    }
}
