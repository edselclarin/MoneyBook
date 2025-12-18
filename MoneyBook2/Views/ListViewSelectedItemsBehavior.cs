using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace MoneyBook2.Views
{
    public static class ListViewSelectedItemsBehavior
    {
        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.RegisterAttached(
                "SelectedItems",
                typeof(IList),
                typeof(ListViewSelectedItemsBehavior),
                new PropertyMetadata(null, OnSelectedItemsChanged));

        public static void SetSelectedItems(DependencyObject element, IList value)
            => element.SetValue(SelectedItemsProperty, value);

        public static IList GetSelectedItems(DependencyObject element)
            => (IList)element.GetValue(SelectedItemsProperty);

        private static void OnSelectedItemsChanged(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not ListView listView)
            {
                return;
            }

            listView.SelectionChanged -= ListView_SelectionChanged;

            if (e.NewValue is IList)
            {
                listView.SelectionChanged += ListView_SelectionChanged;
            }
        }

        private static void ListView_SelectionChanged(
            object sender, SelectionChangedEventArgs e)
        {
            if (sender is not ListView listView)
            {
                return;
            }

            var boundCollection = GetSelectedItems(listView);
            if (boundCollection == null)
            {
                return;
            }

            boundCollection.Clear();

            foreach (var item in listView.SelectedItems)
            {
                boundCollection.Add(item);
            }
        }
    }
}
