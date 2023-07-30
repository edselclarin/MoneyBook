using System.Threading.Tasks;

namespace MoneyBookDashboard.ViewModels
{
    public interface IViewModel
    {
        public Task LoadAsync() => Task.CompletedTask;
    }
}
