using Caliburn.Micro;
using System.Collections.ObjectModel;
using Account = MoneyBook2.DataModels.Account;
using Transaction = MoneyBook.Models.Transaction;

namespace MoneyBook2.ViewModels
{
    public class TransactionsViewModel : Screen
    {
        public string Title { get; private set; }

        public ObservableCollection<Transaction> Transactions { get; set; }

        public void Initialize(Account account, IEnumerable<Transaction> transactions)
        {
            Title = $"Transactions - [{account.Name}]";
            Transactions = new ObservableCollection<Transaction>(transactions);
        }
    }
}
