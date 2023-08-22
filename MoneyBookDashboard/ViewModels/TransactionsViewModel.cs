using Autofac;
using Caliburn.Micro;
using MoneyBook;
using MoneyBook.Data;
using MoneyBook.DataProviders;
using MoneyBook.Models;
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

            if (MoneyBookContainerBuilder.Container.Resolve<IDataProvider<Transaction>>() is IDataProvider<Transaction> dp)
            {
                if ((await dp.GetPagedAsync(0, 100, dateTimeFrom: DateTime.Now.AddDays(-30))) is PagedResponse<Transaction> res)
                {
                    var items = res.Items.OrderByDescending(x => x.Date);
                    foreach (var item in items)
                    {
                        Transactions.Add(new MoneyBookDashboard.Models.Transaction
                        {
                            TrnsId = item.TrnsId,
                            Date = item.Date,
                            RefNum = item.RefNum,
                            Payee = item.Payee,
                            Memo = item.Memo,
                            State = item.State,
                            Amount = item.GetAmount(),
                            AcctId = item.AcctId,
                            CatId = item.CatId
                        });
                    }
                }
            }
        }
    }
}
