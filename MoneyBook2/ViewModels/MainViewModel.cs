using Autofac;
using Caliburn.Micro;
using MoneyBook;
using MoneyBook.Data;
using MoneyBook.Models;
using System.Collections.ObjectModel;

namespace MoneyBook2.ViewModels
{
    public class MainViewModel : Screen
    {
        private IDbContextProxy _dbProxy;

        private ReadOnlyCollection<AccountSummary> _accountSummaries;

        public ReadOnlyCollection<AccountSummary> AccountSummaries
        {
            get { return _accountSummaries; }
            set { _accountSummaries = value; }
        }

        public MainViewModel()
        {
            _dbProxy = MoneyBookContainerBuilder.Container.Resolve<IDbContextProxy>();
            AccountSummaries = new ReadOnlyCollection<AccountSummary>(_dbProxy.GetAccountSummaries().ToList());
        }
    }
}
