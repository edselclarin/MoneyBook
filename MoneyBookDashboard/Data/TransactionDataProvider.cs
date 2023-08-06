using MoneyBookDashboard.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyBookDashboard.Data
{
    public class TransactionDataProvider : ITransactionDataProvider
    {
        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            return await Task.Run(() =>
            {
                return new List<Transaction>()
                {
                    new Transaction() { Date = DateTime.Now, Payee = "Withdrawal", TrnsType="DEBIT", Amount = -40.0m },
                    new Transaction() { Date = DateTime.Now, Payee = "Withdrawal", TrnsType="DEBIT", Amount = -40.0m },
                    new Transaction() { Date = DateTime.Now, Payee = "Withdrawal", TrnsType="DEBIT", Amount = -40.0m },
                    new Transaction() { Date = DateTime.Now, Payee = "Withdrawal", TrnsType="DEBIT", Amount = -40.0m },
                    new Transaction() { Date = DateTime.Now, Payee = "Withdrawal", TrnsType="DEBIT", Amount = -40.0m },
                    new Transaction() { Date = DateTime.Now, Payee = "Paycheck", TrnsType="CREDIT", Amount = 1000.0m },
                    new Transaction() { Date = DateTime.Now, Payee = "Withdrawal", TrnsType="DEBIT", Amount = -40.0m },
                    new Transaction() { Date = DateTime.Now, Payee = "Withdrawal", TrnsType="DEBIT", Amount = -40.0m },
                    new Transaction() { Date = DateTime.Now, Payee = "Withdrawal", TrnsType="DEBIT", Amount = -40.0m },
                    new Transaction() { Date = DateTime.Now, Payee = "Withdrawal", TrnsType="DEBIT", Amount = -40.0m },
                    new Transaction() { Date = DateTime.Now, Payee = "Withdrawal", TrnsType="DEBIT", Amount = -40.0m },
                    new Transaction() { Date = DateTime.Now, Payee = "Paycheck", TrnsType="CREDIT", Amount = 1000.0m },
                    new Transaction() { Date = DateTime.Now, Payee = "Withdrawal", TrnsType="DEBIT", Amount = -40.0m },
                    new Transaction() { Date = DateTime.Now, Payee = "Withdrawal", TrnsType="DEBIT", Amount = -40.0m },
                    new Transaction() { Date = DateTime.Now, Payee = "Withdrawal", TrnsType="DEBIT", Amount = -40.0m },
                    new Transaction() { Date = DateTime.Now, Payee = "Withdrawal", TrnsType="DEBIT", Amount = -40.0m },
                    new Transaction() { Date = DateTime.Now, Payee = "Withdrawal", TrnsType="DEBIT", Amount = -40.0m },
                    new Transaction() { Date = DateTime.Now, Payee = "Paycheck", TrnsType="CREDIT", Amount = 1000.0m },
                    new Transaction() { Date = DateTime.Now, Payee = "Withdrawal", TrnsType="DEBIT", Amount = -40.0m },
                    new Transaction() { Date = DateTime.Now, Payee = "Withdrawal", TrnsType="DEBIT", Amount = -40.0m },
                    new Transaction() { Date = DateTime.Now, Payee = "Withdrawal", TrnsType="DEBIT", Amount = -40.0m },
                    new Transaction() { Date = DateTime.Now, Payee = "Withdrawal", TrnsType="DEBIT", Amount = -40.0m },
                    new Transaction() { Date = DateTime.Now, Payee = "Withdrawal", TrnsType="DEBIT", Amount = -40.0m },
                    new Transaction() { Date = DateTime.Now, Payee = "Paycheck", TrnsType="CREDIT", Amount = 1000.0m },
                    new Transaction() { Date = DateTime.Now, Payee = "Withdrawal", TrnsType="DEBIT", Amount = -40.0m },
                    new Transaction() { Date = DateTime.Now, Payee = "Withdrawal", TrnsType="DEBIT", Amount = -40.0m },
                    new Transaction() { Date = DateTime.Now, Payee = "Withdrawal", TrnsType="DEBIT", Amount = -40.0m },
                    new Transaction() { Date = DateTime.Now, Payee = "Withdrawal", TrnsType="DEBIT", Amount = -40.0m },
                    new Transaction() { Date = DateTime.Now, Payee = "Withdrawal", TrnsType="DEBIT", Amount = -40.0m },
                    new Transaction() { Date = DateTime.Now, Payee = "Paycheck", TrnsType="CREDIT", Amount = 1000.0m }
                };
            });
        }
    }
}
