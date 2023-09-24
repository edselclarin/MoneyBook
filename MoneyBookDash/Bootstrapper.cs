using Caliburn.Micro;
using MoneyBookDash.ViewModels;

namespace MoneyBookDash
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override async void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            await DisplayRootViewFor<MainViewModel>();
        }
    }
}
