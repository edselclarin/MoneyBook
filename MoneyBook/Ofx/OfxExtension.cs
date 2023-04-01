namespace Ofx
{
    public static class OfxExtension
    {
        /// <summary>
        /// Extracts transactions from OFX.
        /// </summary>
        public static List<OfxTransaction> GetTransactions(this OFX ofx)
        {
            List<STMTTRN> trns;
            if (ofx.BANKMSGSRSV1 != null)
            {
                trns = ofx.BANKMSGSRSV1.STMTTRNRS.STMTRS.BANKTRANLIST.STMTTRN;
            }
            else if (ofx.CREDITCARDMSGSRSV1 != null)
            {
                trns = ofx.CREDITCARDMSGSRSV1.CCSTMTTRNRS.CCSTMTRS.BANKTRANLIST.STMTTRN;
            }
            else
            {
                throw new Exception("Invalid transactions list.");
            }

            var transactions = new List<OfxTransaction>();
            
            foreach (var trn in trns)
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
            if (ofx.BANKMSGSRSV1 != null)
            {
                var acctFrom = ofx.BANKMSGSRSV1.STMTTRNRS.STMTRS.BANKACCTFROM;

                return new OfxAccount()
                {
                    BankId = acctFrom.BANKID,
                    AcctId = acctFrom.ACCTID,
                    AcctType = acctFrom.ACCTTYPE
                };
            }
            else if (ofx.CREDITCARDMSGSRSV1 != null)
            {
                var acctFrom = ofx.CREDITCARDMSGSRSV1.CCSTMTTRNRS.CCSTMTRS.CCACCTFROM;

                return new OfxAccount()
                {
                    BankId = String.Empty,
                    AcctId = acctFrom.ACCTID,
                    AcctType = "CREDIT"
                };
            }
            else
            {
                throw new Exception("Unrecognized OFX format.");
            }
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

            context.OfxAccount = ofx.GetAccountFrom();
            context.Transactions = ofx.GetTransactions();
        }
    }
}
