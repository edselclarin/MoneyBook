using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MoneyBook2023
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			// Set window icon.
			Uri iconUri = new Uri("pack://application:,,,/bank-2-256.ico", UriKind.RelativeOrAbsolute);
			this.Icon = BitmapFrame.Create(iconUri);
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			try
			{
			}
			catch (Exception ex) 
			{
				this.ShowExceptionMessage(ex);
			}
		}
	}
}
