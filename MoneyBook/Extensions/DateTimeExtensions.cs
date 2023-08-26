namespace MoneyBook.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Returns the date of the specified day of week after the given date.
        /// <br/>
        /// <br/>
        /// Usage:
        /// <br/>
        /// <br/>
        /// DateTime dtFrom = new DateTime(2022, 11, 19);
        /// <br/>
        /// DateTime dtNext = dtFrom.GetDateOfTarget(DayOfWeek.Thursday);
        /// <br/>
        /// <br/>
        /// Result: 11/24/2022
        /// </summary>
        public static DateTime GetDateOfTarget(this DateTime dateTime, DayOfWeek targetDayOfWeek)
        {
            int iCurr = (int)dateTime.DayOfWeek;
            int iTarg = (int)targetDayOfWeek;
            int nTarg;

            // Use the day of week positions to calculate how many days are needed to jump to target.
            if (iCurr < iTarg)
            {
                nTarg = iTarg - iCurr;
            }
            else
            {
                nTarg = 7 - (iCurr - iTarg);
            }

            // Note: .AddDays() takes leap year into account.
            return dateTime.AddDays(nTarg);
        }
    }
}
