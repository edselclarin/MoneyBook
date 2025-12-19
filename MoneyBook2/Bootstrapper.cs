using Caliburn.Micro;
using MoneyBook2.ViewModels;
using System.Windows;

namespace MoneyBook2
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container;

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            _container = new SimpleContainer();

            // Caliburn services
            _container.Singleton<IWindowManager, WindowManager>();
            _container.Singleton<IEventAggregator, EventAggregator>();

            // Register viewmodels
            _container.Singleton<MainViewModel>();
            _container.PerRequest<DueFormViewModel>();
        }

        protected override object GetInstance(Type service, string key)
            => _container.GetInstance(service, key);

        protected override IEnumerable<object> GetAllInstances(Type service)
            => _container.GetAllInstances(service);

        protected override void BuildUp(object instance)
            => _container.BuildUp(instance);

        protected override async void OnStartup(object sender, StartupEventArgs e)
        {
            // Launch main window
            await DisplayRootViewForAsync<MainViewModel>();
        }
    }
}
