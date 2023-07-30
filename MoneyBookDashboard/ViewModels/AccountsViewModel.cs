using Caliburn.Micro;
using MoneyBookDashboard.Data;
using MoneyBookDashboard.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MoneyBookDashboard.ViewModels
{
    public class AccountsViewModel : Screen, IViewModel
    {
        private IAccountDataProvider dataProvider_;

        public AccountsViewModel(IAccountDataProvider dataProvider)
        {
            dataProvider_ = dataProvider;
        }

        private ObservableCollection<Account> accounts_; 
        public ObservableCollection<Account> Accounts 
        {
            get => accounts_;
            set
            {
                accounts_ = value;
                NotifyOfPropertyChange();
            }
        }

        public async Task LoadAsync()
        {
            if (await dataProvider_.GetAllAsync() is IEnumerable<Account> accounts)
            {
                Accounts = new();

                foreach (var account in accounts)
                {
                    Accounts.Add(account);
                }
            }
        }
    }
}
