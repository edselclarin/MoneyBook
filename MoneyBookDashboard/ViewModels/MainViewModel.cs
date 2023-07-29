using Caliburn.Micro;
using System.Collections.ObjectModel;

namespace MoneyBookDashboard.ViewModels
{
    public class MainViewModel : Conductor<Screen>.Collection.AllActive
    {
        public ObservableCollection<Screen> Items { get; } = new ObservableCollection<Screen>();

        public MainViewModel() 
        {
            Items.Add(new AccountsViewModel());
            Items.Add(new TransactionsViewModel());
            Items.Add(new RemindersViewModel());
        }
    }
}
