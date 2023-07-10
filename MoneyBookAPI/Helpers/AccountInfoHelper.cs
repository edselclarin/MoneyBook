using MoneyBookAPI.Data;

namespace MoneyBookAPI.Helpers
{
    public static class AccountInfoHelper
    {
        public static AccountInfo ToAccountInfo(this Account acct)
        {
            return new AccountInfo
            {
                AcctId = acct.AcctId,
                AccountName = acct.Name,
                Description = acct.Description,
                AcctTypeId = acct.AcctTypeId,
                StartingBalance = acct.StartingBalance,
                ReserveAmount = acct.ReserveAmount,
                DateAdded = acct.DateAdded,
                DateModified = acct.DateModified
            };
        }
    }
}
