using MoneyBookDash.Models;
using System.Collections.Generic;

namespace MoneyBookDash.DataProviders
{
    public class TestAccountDataProvider : IAccountDataProvider
    {
        public IList<AccountModel> GetAll()
        {
            return new List<AccountModel>()
            {
                new AccountModel() { AcctId = 1, Name = "CHECKING", AvailableBalance = 1000.00m },
                new AccountModel() { AcctId = 2, Name = "SAVINGS-1", AvailableBalance = 1000.00m },
                new AccountModel() { AcctId = 3, Name = "SAVINGS-2", AvailableBalance = 1000.00m },
                new AccountModel() { AcctId = 4, Name = "SAVINGS-3", AvailableBalance = 1000.00m },
                new AccountModel() { AcctId = 5, Name = "SAVINGS-4", AvailableBalance = 1000.00m },
                new AccountModel() { AcctId = 6, Name = "SAVINGS-5", AvailableBalance = 1000.00m }
            };
        }
    }
}
