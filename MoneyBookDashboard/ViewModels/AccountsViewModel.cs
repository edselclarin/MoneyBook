using MoneyBookDashboard.Data;
using MoneyBookDashboard.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MoneyBookDashboard.ViewModels
{
    public class AccountsViewModel : ScreenViewModelBase
    {
        private IAccountDataProvider dataProvider_;

        public AccountsViewModel(IAccountDataProvider dataProvider)
        {
            dataProvider_ = dataProvider;
        }

        public ObservableCollection<Account> Accounts { get; } = new();

        public override async Task LoadAsync()
        {
            if (await dataProvider_.GetAllAsync() is IEnumerable<Account> accounts)
            {
                foreach (var account in accounts)
                {
                    Accounts.Add(account);
                }
            }
        }
    }
}
