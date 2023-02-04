using System;
using System.Windows;

namespace MoneyBook2023
{
	public static class WindowExtension
	{
		public static string ExceptionWindowTitle { get; set; } = "EXCEPTION";

		public static void ShowExceptionMessage(this Window wnd, Exception ex)
		{
			MessageBox.Show(wnd, ex.InnerException != null ? ex.InnerException.Message : ex.Message,
				ExceptionWindowTitle, MessageBoxButton.OK, MessageBoxImage.Error);
		}
	}
}
