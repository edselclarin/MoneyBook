using MoneyBookDashboard.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyBookDashboard.Data
{
    public interface IReminderDataProvider
    {
        Task<IEnumerable<Reminder>> GetAllAsync();
    }
}
