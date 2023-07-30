using Caliburn.Micro;
using MoneyBookDashboard.Data;
using MoneyBookDashboard.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MoneyBookDashboard.ViewModels
{
    public class RemindersViewModel : Screen, IViewModel
    {
        private IReminderDataProvider dataProvider_;

        public RemindersViewModel(IReminderDataProvider dataProvider)
        {
            dataProvider_ = dataProvider;
        }

        private ObservableCollection<Reminder> reminders_;
        public ObservableCollection<Reminder> Reminders
        {
            get => reminders_;
            set
            {
                reminders_ = value;
                NotifyOfPropertyChange();
            }
        }
        
        public async Task LoadAsync()
        {
            if (await dataProvider_.GetAllAsync() is IEnumerable<Reminder> reminders)
            {
                Reminders = new();

                foreach (var reminder in reminders)
                {
                    Reminders.Add(reminder);
                }
            }
        }
    }
}
