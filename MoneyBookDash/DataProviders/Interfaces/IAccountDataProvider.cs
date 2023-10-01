using MoneyBookDash.Models;
using System.Collections.Generic;

namespace MoneyBookDash.DataProviders.Interfaces
{
    public interface IAccountDataProvider
    {
        public IList<AccountModel> GetAll();
    }
}
