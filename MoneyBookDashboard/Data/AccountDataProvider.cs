using MoneyBookDashboard.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyBookDashboard.Data
{
    public class AccountDataProvider : IAccountDataProvider
    {
        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await Task.Run(() =>
            {
                return new List<Account>()
                {
                    new Account() { Id = 1, Name = "CHECKING",  Balance = 10000.0m },
                    new Account() { Id = 2, Name = "SAVINGS-1", Balance = 10000.0m },
                    new Account() { Id = 3, Name = "SAVINGS-2", Balance = 10000.0m },
                    new Account() { Id = 4, Name = "SAVINGS-3", Balance = 10000.0m },
                    new Account() { Id = 5, Name = "OTHER",     Balance = 10000.0m }
                };
            });
        }
    }
}
