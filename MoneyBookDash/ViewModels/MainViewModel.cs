using Caliburn.Micro;
using MoneyBookDash.DataProviders;

namespace MoneyBookDash.ViewModels
{
    public class MainViewModel : Conductor<Screen>.Collection.AllActive
    {
        private IReminderDataProvider reminderDataProvider_;

        public MainViewModel(IReminderDataProvider reminderDataProvider)
        {
            reminderDataProvider_ = reminderDataProvider;

            Items.Add(ReminderViewModel.Create("Overdue", reminderDataProvider_.GetOverdue()));
            Items.Add(ReminderViewModel.Create("Due", reminderDataProvider_.GetDueNow()));
            Items.Add(ReminderViewModel.Create("Upcoming", reminderDataProvider_.GetUpcoming()));
            Items.Add(ReminderViewModel.Create("Staged", reminderDataProvider_.GetStaged()));
        }
    }
}
