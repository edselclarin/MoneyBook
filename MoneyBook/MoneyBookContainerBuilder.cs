using Autofac;
using Microsoft.EntityFrameworkCore;
using MoneyBook.Data;
using MoneyBook.DataProviders;
using MoneyBook.Models;

namespace MoneyBook
{
    public static class MoneyBookContainerBuilder
    {
        private static ContainerBuilder builder_;
        private static IContainer container_;
        public static IContainer Container
        {
            get
            {
                builder_ ??= new();

                builder_.RegisterType<MoneyBookDbContextConfig>().As<IDbContextConfig>();
                builder_.RegisterType<MoneyBookDbContext>().As<DbContext>();
                builder_.RegisterType<MoneyBookDbContextProxy>().As<IDbContextProxy>();

                builder_.RegisterType<AccountDataProvider>().As<IDataProvider<Account>>();
                builder_.RegisterType<AccountTypeDataProvider>().As<IDataProvider<AccountType>>();
                builder_.RegisterType<AccountSummaryDataProvider>().As<IDataProvider<AccountSummary>>();
                builder_.RegisterType<InstitutionDataProvider>().As<IDataProvider<Institution>>();
                builder_.RegisterType<ReminderDataProvider>().As<IDataProvider<Reminder>>();
                builder_.RegisterType<TransactionDataProvider>().As<IDataProvider<Transaction>>();

                container_ ??= builder_.Build();

                return container_;
            }
        }
    }
}
