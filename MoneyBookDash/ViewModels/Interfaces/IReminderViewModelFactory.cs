using System.Collections.Generic;

namespace MoneyBookDash.ViewModels.Interfaces
{
    public interface IReminderViewModelFactory
    {
        public IEnumerable<ReminderViewModel> GetAll();
    }
}
