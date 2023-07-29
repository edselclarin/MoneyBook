using Caliburn.Micro;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TransactionsTool.ViewModels
{
    public class ScreenViewModelBase : Screen, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
