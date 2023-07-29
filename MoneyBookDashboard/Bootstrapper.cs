using Caliburn.Micro;
using MoneyBookDashboard.ViewModels;

namespace MoneyBookDashboard
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
