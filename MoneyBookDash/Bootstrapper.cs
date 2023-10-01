using Caliburn.Micro;
using MoneyBookDash.DataProviders;
using MoneyBookDash.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyBookDash
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer container_ = new SimpleContainer();

        public Bootstrapper()
        {
            Initialize();
        }

        protected override object GetInstance(Type serviceType, string key)
        {
            return container_.GetInstance(serviceType, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return container_.GetAllInstances(serviceType);
        }

        protected override void BuildUp(object instance)
        {
            container_.BuildUp(instance);
        }

        protected override void Configure()
        {
            container_.Instance(container_);
            container_
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>();

            // Register view models.
            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => container_.RegisterPerRequest(viewModelType, viewModelType.ToString(), viewModelType));

            // Register other types.
            container_
                .PerRequest<IReminderDataProvider, TestReminderDataProvider>();
        }

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }
    }
}
