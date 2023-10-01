using MoneyBookDash.DataProviders.Interfaces;
using MoneyBookDash.Models;
using MoneyBookDash.ViewModels.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MoneyBookDash.ViewModels
{
    public class ReminderViewModelFactory : IReminderViewModelFactory
    {
        private IReminderDataProvider reminderDataProvider_;

        public ReminderViewModelFactory(IReminderDataProvider reminderDataProvider)
        {
            reminderDataProvider_ = reminderDataProvider;                
        }

        public IEnumerable<ReminderViewModel> GetAll()
        {
            return new List<ReminderViewModel>()
            {
                CreateViewModel("Overdue", reminderDataProvider_.GetOverdue()),
                CreateViewModel("Due", reminderDataProvider_.GetDueNow()),
                CreateViewModel("Upcoming", reminderDataProvider_.GetUpcoming())
            };
        }

        private ReminderViewModel CreateViewModel(string title, IList<ReminderModel> reminders)
        {
            var vm = new ReminderViewModel()
            {
                Title = title,
                Reminders = new ObservableCollection<ReminderModel>(),
            };

            foreach (var rem in reminders)
            {
                vm.Reminders.Add(rem);
            }

            return vm;
        }
    }
}
