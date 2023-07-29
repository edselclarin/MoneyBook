using Ofx;
using System.Collections.Generic;
using TransactionsTool.Models;

namespace TransactionsTool.Readers
{
    public class SchoolsFirstFileReader : ITransactionFileReader
    {
        public IEnumerable<Transaction> Read(string filePath)
        {
            var ofx = OfxSerializer.Deserialize(filePath);
            
            var transactions = new List<Transaction>();
            foreach (var ofxTran in ofx.GetTransactions())
            {
                var tran = new Transaction()
                {
                    Date = ofxTran.DateAvailable,
                    PostDate = ofxTran.DatePosted,
                    Description = ofxTran.Memo,
                    Type = ofxTran.TransactionType,
                    Amount = ofxTran.TransactionAmount                    
                };
                transactions.Add(tran);
            }

            return transactions;
        }
    }
}
