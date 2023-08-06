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
                var res = await dp.GetPagedAsync(0, 100);
                if (res is not null)
                {
                    foreach (var acct in res.Items.OrderBy(x => x. AcctId))
                    {
                        Accounts.Add(new Models.Account
                        {
                            AcctId = acct.AcctId,
                            Name = acct.Name,
                            FinalBalance = acct.FinalBalance
                        });
                    }
                }
            }
        }
    }
}
