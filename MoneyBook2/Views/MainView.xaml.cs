using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MoneyBook2.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void ListViewItem_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && !item.IsSelected)
            {
                item.IsSelected = true;
            }

            item?.Focus();
            e.Handled = true;
        }
    }
}
