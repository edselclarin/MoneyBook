using MoneyBookDash.Models;
using System.Collections.Generic;

namespace MoneyBookDash.DataProviders
{
    public interface IReminderDataProvider
    {
        public IList<ReminderModel> GetOverdue();
        public IList<ReminderModel> GetDueNow();
        public IList<ReminderModel> GetUpcoming();
        public IList<ReminderModel> GetStaged();
    }
}
