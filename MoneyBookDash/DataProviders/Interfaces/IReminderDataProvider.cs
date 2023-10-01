using MoneyBookDash.Models;
using System.Collections.Generic;

namespace MoneyBookDash.DataProviders.Interfaces
{
    public interface IReminderDataProvider
    {
        public IList<ReminderModel> GetOverdue();
        public IList<ReminderModel> GetDueNow();
        public IList<ReminderModel> GetUpcoming();
    }
}
