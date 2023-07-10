using MoneyBookAPI.Data;

namespace MoneyBookAPI.Helpers
{
    public static class TransactionsHelper
    {
        public static decimal GetCredits(this IEnumerable<Transaction> transactions)
        {
            return transactions
                .Where(x => x.TrnsType.ToUpper() == "CREDIT" && x.State != MoneyBook.StateTypes.Ignored.ToString())
                .Sum(x => x.Amount);
        }

        public static decimal GetDebits(this IEnumerable<Transaction> transactions)
        {
            return transactions
                .Where(x => x.TrnsType.ToUpper() == "DEBIT" && x.State != MoneyBook.StateTypes.Ignored.ToString())
                .Sum(x => x.Amount);
        }

        public static decimal GetStagedBalance(this IEnumerable<Transaction> transactions)
        {
            return
                transactions.Where(x => x.TrnsType.ToUpper() == "CREDIT" &&
                    x.State == MoneyBook.StateTypes.Staged.ToString()).Sum(x => x.Amount) -
                transactions.Where(x => x.TrnsType.ToUpper() == "DEBIT" &&
                    x.State == MoneyBook.StateTypes.Staged.ToString()).Sum(x => x.Amount);
        }
    }
}
