using Caliburn.Micro;
using System.Windows;

namespace TransactionsTool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            // Activate Caliburn logging.
            LogManager.GetLog = type => new DebugLog(type);

            MainEngine.Instance.Init();
        }
    }
}
