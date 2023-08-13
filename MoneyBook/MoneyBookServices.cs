using Microsoft.Extensions.DependencyInjection;
using MoneyBook.DataProviders;
using MoneyBook.Models;

namespace MoneyBook
{
    public static class MoneyBookServices
    {
        private static ServiceCollection m_services;
        private static IServiceProvider m_serviceProvider;
        public static IServiceProvider ServiceProvider
        {
            get
            {
                if (m_services == null)
                {
                    m_services = new();

                    // Register dependencies.
                    m_services.AddScoped<IDataProvider<Account>, AccountDataProvider>();
                    m_services.AddScoped<IDataProvider<AccountType>, AccountTypeDataProvider>();
                    m_services.AddScoped<IDataProvider<AccountSummaryModel>, AccountSummaryDataProvider>();
                    m_services.AddScoped<IDataProvider<AccountType>, AccountTypeDataProvider>();
                    m_services.AddScoped<IDataProvider<Institution>, InstitutionDataProvider>();
                    m_services.AddScoped<IDataProvider<Reminder>, ReminderDataProvider>();
                    m_services.AddScoped<IDataProvider<Transaction>, TransactionDataProvider>();

                    m_serviceProvider = m_services.BuildServiceProvider();
                }
                return m_serviceProvider;
            }
        }
    }
}
