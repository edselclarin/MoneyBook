using MoneyBookDash.Models;
using System.Collections.Generic;

namespace MoneyBookDash.DataProviders
{
    public interface IAccountDataProvider
    {
        public IList<AccountModel> GetAll();
    }
}
