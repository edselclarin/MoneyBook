﻿using MoneyBook.Models;
using Newtonsoft.Json;

namespace MoneyBook.Data
{
    public class MoneyBookDbTextBackup : IDbBackup
    {
        private readonly MoneyBookDbContext _dbContext;
        private readonly string _backupDir;

        private MoneyBookDbTextBackup(MoneyBookDbContext dbContext, string backupDir)
        {
            _dbContext = dbContext;
            _backupDir = backupDir;
        }

        public static MoneyBookDbTextBackup Create(MoneyBookDbContext dbContext, string backupDir)
        {
            if (String.IsNullOrWhiteSpace(backupDir))
            {
                throw new Exception("Backup directory cannot be null or empty.");
            }

            return new(dbContext, backupDir);
        }

        public void Save()
        {
            var backup = new BackupContext()
            {
                DateCreated = DateTime.Now,
                Transactions = _dbContext.Transactions.OrderByDescending(x => x.Date).ToList(),
                Reminders = _dbContext.Reminders.OrderByDescending(x => x.DueDate).ToList(),
                Accounts = _dbContext.Accounts.OrderByDescending(x => x.DateAdded).ToList(),
                Institutions = _dbContext.Institutions.OrderByDescending(x => x.InstId).ToList(),
                Categories = _dbContext.Categories.OrderByDescending(x => x.CatId).ToList(),
            };

            string filePath = Path.Combine(_backupDir, $"MoneyBook-v2-{DateTime.Now.ToString("yyyy-MMdd-HHmmss")}.json");
            string json = JsonConvert.SerializeObject(backup, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }
}
