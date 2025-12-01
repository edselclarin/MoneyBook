using MoneyBook.Data;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace MoneyBook2.Views
{
    public class DueStateTypesToForegroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DueStateTypes state)
            {
                switch (state)
                {
                    case DueStateTypes.Past:
                    case DueStateTypes.Today:
                        return Brushes.LightCoral;
                    case DueStateTypes.Upcoming:
                        return Brushes.Orange;
                    case DueStateTypes.Soon:
                        return Brushes.Yellow;
                    default:
                        return Brushes.White;
                }
            }

            return Brushes.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
