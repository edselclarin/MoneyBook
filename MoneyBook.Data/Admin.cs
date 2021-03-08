using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBook.Data
{
    public static class Admin
    {
        public enum DefaultAccountTypes
        {
            Cash,
            Checking,
            Savings,
            Credit
        }

        public enum DefaultFlowTypes
        {
            Spending,
            Receivable,
            Payable
        }

        public enum DefaultStateTypes
        {
            Uncleared,
            Cleared,
            Reconciled
        }

        public enum DefaultCategoryTypes
        {
            General
        }

        public static List<(string Name, DefaultAccountTypes AcctType, DefaultFlowTypes FlowType)> DefaultAccounts =
            new List<(string Name, DefaultAccountTypes AcctType, DefaultFlowTypes FlowType)>
            {
                ( "SFCHK", DefaultAccountTypes.Checking, DefaultFlowTypes.Payable ),
                ( "SFSAV 1", DefaultAccountTypes.Savings, DefaultFlowTypes.Receivable ),
                ( "SFSAV 2", DefaultAccountTypes.Savings, DefaultFlowTypes.Receivable ),
                ( "SFSAV ED", DefaultAccountTypes.Savings, DefaultFlowTypes.Receivable ),
                ( "SUMMER SAVER", DefaultAccountTypes.Savings, DefaultFlowTypes.Receivable ),
                ( "AMZV", DefaultAccountTypes.Credit, DefaultFlowTypes.Spending ),
                ( "CAPO", DefaultAccountTypes.Credit, DefaultFlowTypes.Spending )
            };


        public static void VerifyDatabase(this MoneyBookEntities db)
        {
            if (!db.Database.Exists())
                throw new Exception("Database does not exist.");

            try
            {
                db.Transactions.Count();
                db.Accounts.Count();
                db.AccountTypes.Count();
                db.CategoryTypes.Count();
                db.StateTypes.Count();
                db.FlowTypes.Count();
            }
            catch
            {
                throw new Exception("One or more database tables are missing.");
            }
        }

        public static void ClearTables(this MoneyBookEntities db)
        {
            db.VerifyDatabase();

            // Must delete in this order because of foreign-key relationships.
            if (db.Transactions.Count() > 0)
            {
                db.Transactions.RemoveRange(db.Transactions);
            }
            if (db.Accounts.Count() > 0)
            {
                db.Accounts.RemoveRange(db.Accounts);
            }
            if (db.AccountTypes.Count() > 0)
            {
                db.AccountTypes.RemoveRange(db.AccountTypes);
            }
            if (db.CategoryTypes.Count() > 0)
            {
                db.CategoryTypes.RemoveRange(db.CategoryTypes);
            }
            if (db.StateTypes.Count() > 0)
            {
                db.StateTypes.RemoveRange(db.StateTypes); db.SaveChanges();
            }
            if (db.FlowTypes.Count() > 0)
            {
                db.FlowTypes.RemoveRange(db.FlowTypes);
            }
            db.SaveChanges();
        }

        public static void Seed(this MoneyBookEntities db)
        {
            db.VerifyDatabase();

            db.ClearTables();

            foreach (var at in Enum.GetValues(typeof(DefaultAccountTypes)))
            {
                db.AccountTypes.Add(new AccountType
                {
                    Name = at.ToString()
                });
            }

            foreach (var ft in Enum.GetValues(typeof(DefaultFlowTypes)))
            {
                db.FlowTypes.Add(new FlowType
                {
                    Name = ft.ToString()
                });
            }

            foreach (var st in Enum.GetValues(typeof(DefaultStateTypes)))
            {
                db.StateTypes.Add(new StateType
                {
                    Name = st.ToString(),
                    Alias = st.ToString().ElementAt(0).ToString()
                });
            }

            foreach (var ct in Enum.GetValues(typeof(DefaultCategoryTypes)))
            {
                db.CategoryTypes.Add(new CategoryType
                {
                    Name = ct.ToString(),
                });
            }

            db.SaveChanges();

            foreach (var acct in DefaultAccounts)
            {
                db.Accounts.Add(new Account
                {
                    Name = acct.Name,
                    ATID = db.AccountTypes.FirstOrDefault(x => x.Name == acct.AcctType.ToString()).ATID,
                    FTID = db.FlowTypes.FirstOrDefault(x => x.Name == acct.FlowType.ToString()).FTID,
                    Hidden = false
                });
            }

            db.SaveChanges();

            foreach (var acct in DefaultAccounts)
            {
                db.Transactions.Add(new Transaction
                {
                    Date = DateTime.Now,
                    Payee = "Opening Balance",
                    Amount = 0.0M,
                    AID = db.Accounts.FirstOrDefault(x => x.Name == acct.Name).AID,
                    CTID = db.CategoryTypes.FirstOrDefault(x => x.Name == DefaultCategoryTypes.General.ToString()).CTID,
                    STID = db.StateTypes.FirstOrDefault(x => x.Name == DefaultStateTypes.Uncleared.ToString()).STID
                });
            }

            db.SaveChanges();
        }

        public static Transaction NewTransaction(this MoneyBookEntities db)
        {
            return new Transaction
            {
                Date = DateTime.Now,
                Amount = 0.0M,
                CTID = db.CategoryTypes.FirstOrDefault(x => x.Name == DefaultCategoryTypes.General.ToString()).CTID,
                STID = db.StateTypes.FirstOrDefault(x => x.Name == DefaultStateTypes.Uncleared.ToString()).STID
            };
        }

        public static void DropTables(this MoneyBookEntities db)
        {
            db.Database.ExecuteSqlCommand("drop table [dbo].[Transactions]");
            db.Database.ExecuteSqlCommand("drop table [dbo].[Accounts]");
            db.Database.ExecuteSqlCommand("drop table [dbo].[AccountTypes]");
            db.Database.ExecuteSqlCommand("drop table [dbo].[CategoryTypes]");
            db.Database.ExecuteSqlCommand("drop table [dbo].[StateTypes]");
            db.Database.ExecuteSqlCommand("drop table [dbo].[FlowTypes]");
        }

        public static void CreateTables(this MoneyBookEntities db)
        {
            //TODO
        }
    }
}
