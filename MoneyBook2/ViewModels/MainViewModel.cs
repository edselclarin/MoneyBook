using Autofac;
using Caliburn.Micro;
using MoneyBook;
using MoneyBook.Data;
using MoneyBook2.DataModels;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Account = MoneyBook2.DataModels.Account;

namespace MoneyBook2.ViewModels
{
    public class MainViewModel : Screen
    {
        private IDbContextProxy _dbProxy;

        private ObservableCollection<Account> _accounts;
        public ObservableCollection<Account> Accounts
        {
            get { return _accounts; }
            set 
            { 
                _accounts = value; 
                NotifyOfPropertyChange(() => Accounts);
            }
        }

        private ObservableCollection<Due> _dues;
        public ObservableCollection<Due> Dues
        {
            get { return _dues; }
            set 
            {
                _dues = value;
                NotifyOfPropertyChange(() => Dues);
            }
        }

        public ICommand RefreshViewCommand { get; }
        public ICommand ToggleSelectedDueCommand { get; }

        public MainViewModel()
        {
            _dbProxy = MoneyBookContainerBuilder.Container.Resolve<IDbContextProxy>();

            RefreshViewCommand = new RelayCommand<object>(RefreshView);
            ToggleSelectedDueCommand = new RelayCommand<Due>(ToggleSelectedDue);

            this.Activated += OnActivated;
        }

        private async Task OnActivated(object sender, ActivationEventArgs e)
        {
            RefreshView(null);
        }

        private void RefreshView(object obj)
        {
            var accountSummaries = _dbProxy.GetAccountSummaries().ToList();
            var accounts = accountSummaries
                .Select(summary => new Account(summary)
                {
                    TotalDues = 0m
                })
                .ToList();
            Accounts = new ObservableCollection<Account>(accounts);

            var reminders = _dbProxy.GetReminders(SortMode.Ascending).ToList();
            var dues = reminders
                .Select(reminder => new Due(reminder)
                {
                    IsSelected = false
                })
                .ToList();
            Dues = new ObservableCollection<Due>(dues);
        }

        private void ToggleSelectedDue(Due due)
        {            
        }
    }
}
