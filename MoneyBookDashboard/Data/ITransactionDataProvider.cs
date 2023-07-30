using MoneyBookDashboard.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyBookDashboard.Data
{
    public interface ITransactionDataProvider
    {
        Task<IEnumerable<Transaction>> GetAllAsync();
    }
}
