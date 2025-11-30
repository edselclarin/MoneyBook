using Caliburn.Micro;

namespace MoneyBook2.ViewModels
{
    public class MainViewModel : Screen
    {
        private string _message = "Welcome to MoneyBook2!";
        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                NotifyOfPropertyChange(() => Message);
            }
        }

        public void SayHello()
        {
            Message = "You clicked the button!";
        }
    }
}
