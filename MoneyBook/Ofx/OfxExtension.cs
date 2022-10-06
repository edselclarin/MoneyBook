namespace Ofx
{
    public static class OfxExtension
    {
        /// <summary>
        /// Extracts transactions from OFX.
        /// </summary>
        public static List<OfxTransaction> GetTransactions(this OFX ofx)
        {
            var transactions = new List<OfxTransaction>();

            foreach (var trn in ofx.BANKMSGSRSV1.STMTTRNRS.STMTRS.BANKTRANLIST.STMTTRN)
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

                var otr = new OfxTransaction
                {
                    TransactionType = trn.TRNTYPE.Trim(),
                    DateAvailable = dtAvailable,
                    DatePosted = dtPosted,
                    TransactionAmount = amt,
                    TransactionId = trn.FITID.Trim(),
                    Memo = trn.MEMO.Trim()
                };

                transactions.Add(otr);
            }

            return transactions;
        }

        /// <summary>
        /// Extracts account information from OFX.
        /// </summary>
        public static OfxAccount GetAccountFrom(this OFX ofx)
        {
            var acctFrom = ofx.BANKMSGSRSV1.STMTTRNRS.STMTRS.BANKACCTFROM;

            return new OfxAccount()
            {
                BankId = acctFrom.BANKID,
                AcctId = acctFrom.ACCTID,
                AcctType = acctFrom.ACCTTYPE
            };
        }

        /// <summary>
        /// Parses XML data from file and transforms it into OfxContext.
        /// </summary>
        public static void FromFile(this OfxContext context, string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException($"{filename} not found.");
            }

            var ofx = OfxSerializer.Deserialize(filename);
            if (ofx == null)
            {
                throw new Exception("ofx is null.");
            }

            context.AcctFrom = ofx.GetAccountFrom();
            context.Transactions = ofx.GetTransactions();
        }
    }
}
