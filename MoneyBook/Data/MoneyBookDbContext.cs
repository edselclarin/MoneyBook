using Microsoft.EntityFrameworkCore;
using MoneyBook.Models;

namespace MoneyBook.Data
{
    public class MoneyBookDbContext : DbContext
    {
        private readonly string m_connStr;

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<TransactionSummary> TransactionSummaries { get; set; }
        public DbSet<AccountSummaryModel> AccountSummaries { get; set; }

        public static MoneyBookDbContext Create(IDbContextConfig config)
        {
            return new MoneyBookDbContext(config.ConnectionStr);
        }

        protected MoneyBookDbContext(string connStr)
        {
            m_connStr = connStr;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(m_connStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
