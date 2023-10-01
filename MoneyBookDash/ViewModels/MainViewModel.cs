using Caliburn.Micro;
using MoneyBookDash.ViewModels.Interfaces;

namespace MoneyBookDash.ViewModels
{
    public class MainViewModel : Conductor<Screen>.Collection.AllActive
    {
        private IReminderViewModelFactory reminderViewModelFactory_;

        public MainViewModel(IReminderViewModelFactory reminderViewModelFactory)
        {
            reminderViewModelFactory_ = reminderViewModelFactory;

            Items.AddRange(reminderViewModelFactory_.GetAll());
        }
    }
}
