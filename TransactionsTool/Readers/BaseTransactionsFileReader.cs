using System.Collections.Generic;
using TransactionsTool.Models;

namespace TransactionsTool.Readers
{
    public abstract class BaseTransactionsFileReader
    {
        public IEnumerable<Transaction>? Transactions { get; set; }
    }
}
