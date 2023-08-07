using Caliburn.Micro;
using System.Windows;
using System.Windows.Input;

namespace MoneyBookDashboard.ViewModels
{
    public class MainViewModel : Conductor<Screen>.Collection.AllActive
    {
        public MainViewModel() 
        {
            Items.Add(new AccountsViewModel());
            Items.Add(new TransactionsViewModel());
            Items.Add(new RemindersViewModel());

            Items.Apply(item => (item as IViewModel).LoadAsync());

            MinimizeCommand = new DelegateCommand(Minimize, CanMinimize);
            MaximizeCommand = new DelegateCommand(Maximize, CanMaximize);
            CloseCommand = new DelegateCommand(Close, CanClose);
        }

        private bool CanMinimize() => true;
        private void Minimize(object parameter)
        {
            Application.Current.MainWindow.WindowState = System.Windows.WindowState.Minimized;
        }
        public ICommand MinimizeCommand { get; private set; }

        private bool CanMaximize() => true;
        private void Maximize(object parameter)
        {
            Application.Current.MainWindow.WindowState = Application.Current.MainWindow.WindowState switch
            {
                WindowState.Normal => WindowState.Maximized,
                WindowState.Maximized => WindowState.Normal,
                _ => Application.Current.MainWindow.WindowState
            };
        }
        public ICommand MaximizeCommand { get; private set; }

        private bool CanClose() => true;
        private void Close(object parameter)
        {
            Application.Current.MainWindow.Close();
        }
        public ICommand CloseCommand { get; private set; }
    }
}
