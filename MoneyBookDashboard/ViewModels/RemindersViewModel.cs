using Caliburn.Micro;
using MoneyBook.Data;
using MoneyBook.DataProviders;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBookDashboard.ViewModels
{
    public class RemindersViewModel : Screen, IViewModel
    {
        private ObservableCollection<Models.Reminder> reminders_;
        public ObservableCollection<Models.Reminder> Reminders
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
            Reminders = new();

            if (DataProviderFactory.Create(typeof(MoneyBook.Models.Reminder)) is MoneyBook.DataProviders.ReminderDataProvider dp)
            {
                var res = await dp.GetPagedAsync(0, 100);
                if (res is not null)
                {
                    foreach (var rem in res.Items.OrderBy(x => x.DueDate))
                    {
                        Reminders.Add(new MoneyBookDashboard.Models.Reminder
                        {
                            RmdrId = rem.RmdrId,
                            DueDate = rem.DueDate,
                            Payee = rem.Payee,
                            Memo = rem.Memo,
                            Website = rem.Website,
                            Amount = rem.GetAmount(),
                            Frequency = rem.Frequency
                        });
                    }
                }
            }
        }
    }
}
