using Caliburn.Micro;
using MoneyBook.Data;
using MoneyBook2.DataModels;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Account = MoneyBook2.DataModels.Account;

namespace MoneyBook2.ViewModels
{
    public class DueFormViewModel : Screen
    {
        public string Title { get; set; } = "Due";

        private Due _due = new Due();
        public Due Due
        {
            get => _due;
            set
            {
                _due = value;

                NotifyOfPropertyChange(() => Due);
            }
        }

        public ReadOnlyCollection<Account> Accounts { get; set; }

        private Account _selectedAccount;
        public Account SelectedAccount
        {
            get => _selectedAccount;
            set
            {
                _selectedAccount = value;

                Due.AcctId = _selectedAccount.AcctId;
                Due.AccountName = _selectedAccount.Name;

                NotifyOfPropertyChange(() => SelectedAccount);
            }
        }

        private TransactionFrequency _selectedTransactionFrequency;
        public TransactionFrequency SelectedTransactionFrequency
        {
            get => _selectedTransactionFrequency;
            set
            {
                _selectedTransactionFrequency = value;

                Due.Frequency = _selectedTransactionFrequency.ToString();

                NotifyOfPropertyChange(() => SelectedTransactionFrequency);
            }
        }

        public static Array TransactionFrequencyValues => Enum.GetValues(typeof(TransactionFrequency));

        public ICommand OkCommand { get; }
        public ICommand CancelCommand { get; }

        public DueFormViewModel()
        {
            SelectedTransactionFrequency = TransactionFrequency.Weekly;

            Due = new Due()
            {
                DueDate = System.DateTime.Now,
                Frequency = SelectedTransactionFrequency.ToString()
            };

            OkCommand = new RelayCommand<object>(async (_) => await OkAsync());
            CancelCommand = new RelayCommand<object>(async (_) => await CancelAsync());
        }

        private async Task OkAsync()
        {
            Due.TrnsType = Due.Amount >= 0 
                ? TransactionTypes.CREDIT.ToString() 
                : TransactionTypes.DEBIT.ToString();

            Due.Amount = Math.Abs(Due.Amount);

            await TryCloseAsync(true);
        }

        private async Task CancelAsync()
        {
            await TryCloseAsync(false);
        }
    }
}
