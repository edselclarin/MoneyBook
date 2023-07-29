using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MoneyBook.Data
{
    public class MoneyBookDbTapeBackup : IDbBackup
    {
        private readonly MoneyBookDbContext _dbContext;
        private readonly string _backupDir;

        private MoneyBookDbTapeBackup(MoneyBookDbContext dbContext, string backupDir)
        {
            _dbContext = dbContext;
            _backupDir = backupDir;
        }

        public static MoneyBookDbTapeBackup Create(MoneyBookDbContext dbContext, string backupDir)
        {
            if (String.IsNullOrWhiteSpace(backupDir))
            {
                throw new Exception("Backup directory cannot be null or empty.");
            }

            return new(dbContext, backupDir);
        }
        
        public void Save()
        {
            using SqlConnection conn = new SqlConnection(_dbContext.Database.GetConnectionString());
            
            conn.Open();

            string databaseName = new SqlConnectionStringBuilder(conn.ConnectionString).InitialCatalog;
            string filePath = Path.Combine(_backupDir, $"MoneyBook-v2-{DateTime.Now.ToString("yyyy-MMdd-HHmmss")}.bak");

            using var cmd = new SqlCommand()
            {
                Connection = conn,
                CommandText = $"BACKUP DATABASE {databaseName} TO DISK='{filePath}'"
            };

            cmd.ExecuteNonQuery();
        }
    }
}
