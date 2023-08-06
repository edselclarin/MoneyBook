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
                    new Account() { AcctId = 1, Name = "CHECKING",  FinalBalance = 10000.0m },
                    new Account() { AcctId = 2, Name = "SAVINGS-1", FinalBalance = 10000.0m },
                    new Account() { AcctId = 3, Name = "SAVINGS-2", FinalBalance = 10000.0m },
                    new Account() { AcctId = 4, Name = "SAVINGS-3", FinalBalance = 10000.0m },
                    new Account() { AcctId = 5, Name = "OTHER",     FinalBalance = 10000.0m }
                };
            });
        }
    }
}
