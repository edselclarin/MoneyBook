using System.Windows;
using System.Windows.Input;

namespace MoneyBook2.Views
{
    public static class CursorHelper
    {
        public static readonly DependencyProperty CursorProperty =
            DependencyProperty.RegisterAttached(
                "Cursor",
                typeof(Cursor),
                typeof(CursorHelper),
                new PropertyMetadata(null, OnCursorChanged));

        public static void SetCursor(UIElement element, Cursor value)
            => element.SetValue(CursorProperty, value);

        public static Cursor GetCursor(UIElement element)
            => (Cursor)element.GetValue(CursorProperty);

        private static void OnCursorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement element)
            {
                element.Cursor = e.NewValue as Cursor;
            }
        }
    }
}
