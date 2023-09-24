using System;
using System.Globalization;
using System.Windows.Data;

namespace MoneyBookDash.Converters
{
    public class TitleToBorderColorConverter : IValueConverter
    {
        public enum Titles
        {
            Overdue,
            Due,
            Upcoming,
            Staged
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string title)
            {
                return
                    title.Equals(Titles.Overdue.ToString()) ? "#ff9081" :
                    title.Equals(Titles.Due.ToString()) ? "#ffeb55" :
                    title.Equals(Titles.Upcoming.ToString()) ? "#ffb655" :
                    title.Equals(Titles.Staged.ToString()) ? "#b0c2ff" :
                    "#000000";
            }
            return "#000000";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
