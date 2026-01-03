using MoneyBook.Data;

namespace MoneyBook2.DataModels
{
    public class Transaction : MoneyBook.Models.Transaction
    {
        public decimal ActualAmount
        {
            get
            {
                return TrnsType == TransactionTypes.DEBIT.ToString()
                    ? -Amount
                    : Amount;
            }
        }

        public static Transaction FromTransaction(MoneyBook.Models.Transaction transaction)
        {
            return new Transaction()
            {
                TrnsId = transaction.TrnsId,
                Date = transaction.Date,
                TrnsType = transaction.TrnsType,
                RefNum = transaction.RefNum,
                Payee = transaction.Payee,
                Memo = transaction.Memo,
                State = transaction.State,
                Amount = transaction.Amount,
                ExtTrnsId = transaction.ExtTrnsId,
                DateAdded = transaction.DateAdded,
                DateModified = transaction.DateModified,
                AcctId = transaction.AcctId,
                CatId = transaction.CatId,
                IsDeleted = transaction.IsDeleted,
            };
        }
    }
}
