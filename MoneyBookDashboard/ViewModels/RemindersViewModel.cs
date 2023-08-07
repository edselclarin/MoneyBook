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
                if ((await dp.GetPagedAsync(0, 100)) is PagedResponse<MoneyBook.Models.Reminder> res)
                {
                    var items = res.Items.OrderBy(x => x.DueDate);
                    foreach (var item in items)
                    {
                        Reminders.Add(new MoneyBookDashboard.Models.Reminder
                        {
                            RmdrId = item.RmdrId,
                            DueDate = item.DueDate,
                            Payee = item.Payee,
                            Memo = item.Memo,
                            Website = item.Website,
                            Amount = item.GetAmount(),
                            Frequency = item.Frequency
                        });
                    }
                }
            }
        }
    }
}
