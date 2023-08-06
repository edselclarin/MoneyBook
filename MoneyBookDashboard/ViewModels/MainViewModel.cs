using Caliburn.Micro;

namespace MoneyBookDashboard.ViewModels
{
    public class MainViewModel : Conductor<Screen>.Collection.AllActive
    {   
        public MainViewModel() 
        {
            Items.Add(new AccountsViewModel());
            Items.Add(new TransactionsViewModel());
            Items.Add(new RemindersViewModel());

            Items.Apply(item => (item as IViewModel).LoadAsync());
        }
    }
}
