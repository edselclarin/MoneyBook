using Caliburn.Micro;
using MoneyBookDashboard.Data;
using MoneyBookDashboard.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MoneyBookDashboard.ViewModels
{
    public class TransactionsViewModel : Screen, IViewModel
    {
        private ITransactionDataProvider dataProvider_;

        public TransactionsViewModel(ITransactionDataProvider dataProvider)
        {
            dataProvider_ = dataProvider;
        }

        private ObservableCollection<Transaction> transactions_;
        public ObservableCollection<Transaction> Transactions
        {
            get => transactions_;
            set
            {
                transactions_ = value;
                NotifyOfPropertyChange();
            }
        }
        
        public async Task LoadAsync()
        {
            if (await dataProvider_.GetAllAsync() is IEnumerable<Transaction> transactions)
            {
                Transactions = new();

                foreach (var transaction in transactions)
                {
                    Transactions.Add(transaction);
                }
            }
        }
    }
}
