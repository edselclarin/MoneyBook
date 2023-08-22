using Autofac;
using Caliburn.Micro;
using MoneyBook;
using MoneyBook.DataProviders;
using MoneyBook.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBookDashboard.ViewModels
{
    public class AccountsViewModel : Screen, IViewModel
    {
        private ObservableCollection<MoneyBookDashboard.Models.Account> accounts_; 
        public ObservableCollection<MoneyBookDashboard.Models.Account> Accounts 
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
            Accounts = new();

            if (MoneyBookContainerBuilder.Container.Resolve<IDataProvider<AccountSummary>>() is IDataProvider<AccountSummary> dp)
            {
                if ((await dp.GetPagedAsync(0, 100)) is PagedResponse<MoneyBook.Models.AccountSummary> res)
                {
                    var items = res.Items.OrderBy(x => x.AcctId);
                    foreach (var item in items)
                    {
                        Accounts.Add(new Models.Account
                        {
                            AcctId = item.AcctId,
                            Name = item.Name,
                            AvailableBalance = item.AvailableBalance
                        });
                    }
                }
            }
        }
    }
}
