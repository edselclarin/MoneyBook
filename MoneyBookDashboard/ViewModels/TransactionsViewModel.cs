using Caliburn.Micro;
using MoneyBook.Data;
using MoneyBook.DataProviders;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBookDashboard.ViewModels
{
    public class TransactionsViewModel : Screen, IViewModel
    {
        private ObservableCollection<MoneyBookDashboard.Models.Transaction> transactions_;
        public ObservableCollection<MoneyBookDashboard.Models.Transaction> Transactions
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
            Transactions = new();

            if (DataProviderFactory.Create(typeof(MoneyBook.Models.Transaction)) is MoneyBook.DataProviders.TransactionDataProvider dp)
            {
                var res = await dp.GetPagedAsync(0, 100, dateTimeFrom: DateTime.Now.AddDays(-30));
                if (res is not null)
                {
                    foreach (var tran in res.Items.OrderByDescending(x => x.Date))
                    {
                        Transactions.Add(new MoneyBookDashboard.Models.Transaction
                        {
                            TrnsId = tran.TrnsId,
                            Date = tran.Date,
                            RefNum = tran.RefNum,
                            Payee = tran.Payee,
                            Memo = tran.Memo,
                            State = tran.State,
                            Amount = tran.GetAmount(),
                            AcctId = tran.AcctId,
                            CatId = tran.CatId
                        });
                    }
                }
            }
        }
    }
}
