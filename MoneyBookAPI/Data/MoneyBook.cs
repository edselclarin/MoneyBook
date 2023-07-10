namespace MoneyBookAPI.Data
{
    public static class MoneyBook
    {
        private static int m_minYear = 2022;

        public static int MinimumAccountYear => m_minYear;

        public enum TransactionTypes
        {
            DEBIT,
            CREDIT
        }

        public enum StateTypes
        {
            /// <summary>
            /// Newly added or imported.
            /// </summary>
            New,

            /// <summary>
            /// Projected transaction, not yet registered at institution.
            /// </summary>
            Staged,

            /// <summary>
            /// Matches with transaction at institution.
            /// </summary>
            Reconciled,

            /// <summary>
            /// Exclude from balance calculations.
            /// </summary>
            Ignored
        }

        public enum DateFilter : int
        {
            None,
            TwoWeeks,
            ThisMonth,
            ThisYear,
        }

        public enum SortOrder : int
        {
            Descending,
            Ascending
        }

        public enum TransactionFrequency : int
        {
            Once,
            Weekly,
            BiWeekly,
            Monthly,
            Quarterly,
            Yearly,
            Paused
        }
    }
}
