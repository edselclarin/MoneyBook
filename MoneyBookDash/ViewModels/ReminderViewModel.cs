using Caliburn.Micro;
using MoneyBookDash.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MoneyBookDash.ViewModels
{
    public class ReminderViewModel : Screen
    {
        private string title_;

        public string Title
        {
            get => title_;
            set 
            {
                title_ = value; 
                NotifyOfPropertyChange();
            }
        }

        private ObservableCollection<ReminderModel> reminders_;
        public ObservableCollection<ReminderModel> Reminders
        {
            get => reminders_;
            set
            {
                reminders_ = value;
                NotifyOfPropertyChange();
            }
        }

        public static ReminderViewModel Create(string title, IEnumerable<ReminderModel> reminders)
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
