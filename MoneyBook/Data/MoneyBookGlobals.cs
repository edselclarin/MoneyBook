namespace MoneyBook.Data
{
    public static class MoneyBookGlobals
    {
        public static int MinimumAccountYear => 2022;
        public static DayOfWeek DueBeforeDay { get; set; } = DayOfWeek.Wednesday;
    }

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
        /// Newly imported but pending
        /// </summary>
        Pending,

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

    public enum SortMode : int
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

    public enum DueStateTypes
    {
        Past,     // Overdue
        Today,    // Due today
        Soon,     // Due by DueBeforeDay
        Upcoming, // Due in one week
        None      // Not due
    }
}
