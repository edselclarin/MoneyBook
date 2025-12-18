using MoneyBook.Data;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace MoneyBook2.Views
{
    public class InverseBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                return !boolValue;
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                return !boolValue;
            }

            return false;
        }
    }

    public class BooleanToVisibilityConverter : IValueConverter
    {
        // Converts bool to Visibility
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool boolValue))
                return Visibility.Collapsed;

            // If parameter is "collapse", invert behavior: false -> Collapsed, true -> Visible
            if (parameter is string param && param.Equals("collapse", StringComparison.OrdinalIgnoreCase))
            {
                return boolValue ? Visibility.Collapsed : Visibility.Visible;
            }

            // Default behavior: true -> Visible, false -> Collapsed
            return boolValue ? Visibility.Visible : Visibility.Collapsed;
        }

        // Converts back Visibility to bool
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Visibility visibility))
                return false;

            bool result = visibility == Visibility.Visible;

            if (parameter is string param && param.Equals("collapse", StringComparison.OrdinalIgnoreCase))
            {
                return !result;
            }

            return result;
        }
    }

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

    public class TextWithCountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int count = value as int? ?? 0;
            string text = parameter as string ?? string.Empty;
            return count > 0 ? $"{text} ({count})" : $"{text}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
