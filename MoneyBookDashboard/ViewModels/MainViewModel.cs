using Caliburn.Micro;
using MoneyBookDashboard.Data;

namespace MoneyBookDashboard.ViewModels
{
    public class MainViewModel : Conductor<Screen>.Collection.AllActive
    {   
        public MainViewModel() 
        {
            Items.Add(new AccountsViewModel(new AccountDataProvider()));
            Items.Add(new TransactionsViewModel());
            Items.Add(new RemindersViewModel());

            Items.Apply(item => (item as ScreenViewModelBase).LoadAsync());
        }
    }
}
