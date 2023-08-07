using Caliburn.Micro;
using MoneyBook.DataProviders;
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

            if (DataProviderFactory.Create(typeof(MoneyBook.Models.AccountSummaryModel)) is MoneyBook.DataProviders.AccountSummaryDataProvider dp)
            {
                if ((await dp.GetPagedAsync(0, 100)) is PagedResponse<MoneyBook.Models.AccountSummaryModel> res)
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
