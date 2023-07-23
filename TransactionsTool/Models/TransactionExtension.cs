using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TransactionsTool.Models
{
    public static class TransactionExtension
    {
        public static ObservableCollection<Transaction> ToObservableCollection(this IEnumerable<Transaction> transactions) 
        {
            var coll = new ObservableCollection<Transaction>();
            foreach (var tran in transactions)
            {
                coll.Add(tran);
            }
            return coll;
        }
    }
}
