using MoneyBookDash.Models;
using System;
using System.Collections.Generic;

namespace MoneyBookDash.DataProviders
{
    public static class ReminderDataProvider
    {
        public static IList<ReminderModel> GetOverdue()
        {
            return new List<ReminderModel>()
            {
                new ReminderModel() { RmdrId = 2, DueDate = DateTime.Now.AddDays(-1), 
                    Payee = "SCE", Amount = -200.00m, AcctId = 1, AcctName = "CHECKING" }
            };
        }

        public static IList<ReminderModel> GetDueNow()
        {
            return new List<ReminderModel>()
            {
                new ReminderModel() { RmdrId = 3, DueDate = DateTime.Now.AddDays(-3),
                    Payee = "Verizon", Amount = -50.00m, AcctId = 1, AcctName = "CHECKING"  },
                new ReminderModel() { RmdrId = 4, DueDate = DateTime.Now.AddDays(-3),
                    Payee = "SoCalGas", Amount = -18.00m, AcctId = 1, AcctName = "CHECKING"  },
                new ReminderModel() { RmdrId = 5, DueDate = DateTime.Now.AddDays(-6),
                    Payee = "PeacockTV", Amount = -5.00m, AcctId = 1, AcctName = "CHECKING"  }
            };
        }

        public static IList<ReminderModel> GetUpcoming()
        {
            return new List<ReminderModel>()
            {
                new ReminderModel() { RmdrId = 6, DueDate = DateTime.Now.AddDays(-10),
                    Payee = "Water and Trash", Amount = -25.00m, AcctId = 1, AcctName = "CHECKING"  },
                new ReminderModel() { RmdrId = 7, DueDate = DateTime.Now.AddDays(-12),
                    Payee = "Allowance", Amount = -10.00m, AcctId = 1, AcctName = "CHECKING"  }
            };
        }

        public static IList<ReminderModel> GetStaged()
        {
            return new List<ReminderModel>();
        }
    }
}
