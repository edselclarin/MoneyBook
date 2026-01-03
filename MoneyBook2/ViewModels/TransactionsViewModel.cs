using Caliburn.Micro;
using MoneyBook.Data;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Account = MoneyBook2.DataModels.Account;
using Transaction = MoneyBook.Models.Transaction;

namespace MoneyBook2.ViewModels
{
    public class TransactionsViewModel : Screen
    {
        private Account _account;
        private IDbContextProxy _dbProxy;

        public string Title { get; private set; }

        public ICommand ReconcileNewTransactionsCommand { get; private set; }

        private ObservableCollection<Transaction> _transactions = new();
        public ObservableCollection<Transaction> Transactions
        {
            get => _transactions;
            set
            {
                _transactions = value;

                NotifyOfPropertyChange(() => Transactions);
            }
        }

        public TransactionsViewModel()
        {
            ReconcileNewTransactionsCommand = new RelayCommand<object>(
                async (_) => await ReconcileNewTransactions(null), 
                (_) => Transactions.Any(t => t.State == StateTypes.New.ToString()));
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);

            await RefreshViewAsync();
        }

        public async Task RefreshViewAsync()
        {
            try
            {
                Transactions = new ObservableCollection<Transaction>(_dbProxy.GetAccountTransactions(_account.AcctId));

                (ReconcileNewTransactionsCommand as RelayCommand<object>).RaiseCanExecuteChanged();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading transactions: {ex.Message}",
                    Resources.AppTitle, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Initialize(Account account, ref IDbContextProxy dbProxy)
        {
            _account = account;
            _dbProxy = dbProxy;

            Title = $"Transactions - [{account.Name}]";
        }

        private async Task ReconcileNewTransactions(object obj)
        {
            var answer = MessageBox.Show("Are you sure you want to reconcile new transactions?", 
                Resources.AppTitle, MessageBoxButton.YesNo);
            if (answer != MessageBoxResult.Yes)
            {
                return;
            }

            _dbProxy.SetStateNewToReconciled(_account.AcctId);

            await RefreshViewAsync();
        }
    }
}
