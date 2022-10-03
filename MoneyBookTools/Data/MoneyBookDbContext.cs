using Microsoft.EntityFrameworkCore;
using MoneyBook.Models;
using System.Configuration;

namespace MoneyBookTools.Data
{
    public class MoneyBookDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string connStr = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            options.UseSqlServer(connStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
