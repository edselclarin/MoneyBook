using System.Collections.Generic;
using TransactionsTool.Models;

namespace TransactionsTool.Readers
{
    public interface ITransactionFileReader
    {
        IEnumerable<Transaction> Read(string filePath);
    }
}
