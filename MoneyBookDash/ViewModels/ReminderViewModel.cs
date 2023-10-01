using Caliburn.Micro;
using MoneyBookDash.Models;
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
    }
}
