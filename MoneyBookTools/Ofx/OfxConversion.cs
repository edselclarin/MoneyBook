using Ofx;

namespace MoneyBookTools.Ofx
{
    public static class OfxConversion
    {
        public static List<OfxTransaction> ToTransactions(this IList<STMTTRN> stmttrnList)
        {
            var transactions = new List<OfxTransaction>();
            foreach (var trn in stmttrnList)
            {
                var dtAvailable = new DateTime(
                    Convert.ToInt32(trn.DTAVAIL[0..4]),
                    Convert.ToInt32(trn.DTAVAIL[4..6]),
                    Convert.ToInt32(trn.DTAVAIL[6..8]));

                var dtPosted = new DateTime(
                    Convert.ToInt32(trn.DTPOSTED[0..4]),
                    Convert.ToInt32(trn.DTPOSTED[4..6]),
                    Convert.ToInt32(trn.DTPOSTED[6..8]));

                var amt = Convert.ToDecimal(trn.TRNAMT);

                var guid = new Guid(trn.FITID);

                var otr = new OfxTransaction
                {
                    TransactionType = trn.TRNTYPE.Trim(),
                    DateAvailable = dtAvailable,
                    DatePosted = dtPosted,
                    TransactionAmount = amt,
                    TransactionId = guid,
                    Memo = trn.MEMO.Trim()
                };

                transactions.Add(otr);
            }
            return transactions;
        }
    }
}
