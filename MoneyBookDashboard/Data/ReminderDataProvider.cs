using MoneyBookDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBookDashboard.Data
{
    public class ReminderDataProvider : IReminderDataProvider
    {
        public async Task<IEnumerable<Reminder>> GetAllAsync()
        {
            return await Task.Run(() =>
            {
                return new List<Reminder>()
                {
                    new Reminder() {  DueDate = new DateTime(2023, 12, 14), Payee = "Cell Phone", Frequency="Weekly", TrnsType="DEBIT", Amount = -40.0m },
                    new Reminder() {  DueDate = new DateTime(2023, 12, 15), Payee = "Water", Frequency="Weekly", TrnsType="DEBIT", Amount = -40.0m },
                    new Reminder() {  DueDate = new DateTime(2023, 12, 16), Payee = "Electricity", Frequency="Weekly", TrnsType="DEBIT", Amount = -40.0m },
                    new Reminder() {  DueDate = new DateTime(2023, 12, 17), Payee = "Internet", Frequency="Weekly", TrnsType="DEBIT", Amount = -40.0m },
                    new Reminder() {  DueDate = new DateTime(2023, 12, 18), Payee = "Water", Frequency="Weekly", TrnsType="DEBIT", Amount = -40.0m },
                    new Reminder() {  DueDate = new DateTime(2023, 12, 19), Payee = "Mortgage", Frequency="Weekly", TrnsType="DEBIT", Amount = -40.0m },
                    new Reminder() {  DueDate = new DateTime(2023, 12, 20), Payee = "Auto Loan", Frequency="Weekly", TrnsType="DEBIT", Amount = -40.0m },
                    new Reminder() {  DueDate = new DateTime(2023, 12, 21), Payee = "HOA", Frequency="Weekly", TrnsType="DEBIT", Amount = -40.0m },
                    new Reminder() {  DueDate = new DateTime(2023, 12, 22), Payee = "Paycheck", Frequency="Weekly", TrnsType="DEBIT", Amount = -40.0m },
                    new Reminder() {  DueDate = new DateTime(2023, 12, 23), Payee = "Insurance", Frequency="Weekly", TrnsType="DEBIT", Amount = -40.0m },
                    new Reminder() {  DueDate = new DateTime(2023, 12, 24), Payee = "Pset Control", Frequency="Weekly", TrnsType="DEBIT", Amount = -40.0m },
                    new Reminder() {  DueDate = new DateTime(2023, 12, 25), Payee = "Allowance", Frequency="Weekly", TrnsType="DEBIT", Amount = -40.0m }
                };
            });
        }
    }
}
