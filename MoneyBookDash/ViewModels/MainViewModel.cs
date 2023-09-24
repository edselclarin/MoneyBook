using Caliburn.Micro;
using MoneyBookDash.DataProviders;
using MoneyBookDash.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace MoneyBookDash.ViewModels
{
    public class MainViewModel : Conductor<Screen>.Collection.AllActive
    {
        //private ObservableCollection<AccountModel> accounts_ = new ObservableCollection<AccountModel>();

        //public ObservableCollection<AccountModel> Accounts
        //{
        //    get { return accounts_; }
        //    set
        //    {
        //        accounts_ = value;
        //        NotifyOfPropertyChange();
        //    }
        //}

        //private ObservableCollection<ReminderModel> overdue_ = new ObservableCollection<ReminderModel>();

        //public ObservableCollection<ReminderModel> Overdue
        //{
        //    get { return overdue_; }
        //    set
        //    {
        //        overdue_ = value;
        //        NotifyOfPropertyChange();
        //    }
        //}

        //private ObservableCollection<ReminderModel> dueNow_ = new ObservableCollection<ReminderModel>();

        //public ObservableCollection<ReminderModel> DueNow
        //{
        //    get { return dueNow_; }
        //    set
        //    {
        //        dueNow_ = value;
        //        NotifyOfPropertyChange();
        //    }
        //}

        //private ObservableCollection<ReminderModel> upcoming_ = new ObservableCollection<ReminderModel>();

        //public ObservableCollection<ReminderModel> Upcoming
        //{
        //    get { return upcoming_; }
        //    set
        //    {
        //        upcoming_ = value;
        //        NotifyOfPropertyChange();
        //    }
        //}

        //public MainViewModel()
        //{
        //    foreach (var acct in AccountDataProvider.GetAll().OrderBy(x => x.AcctId))
        //    {
        //        Accounts.Add(acct);
        //    }

        //    foreach (var rmdr in ReminderDataProvider.GetOverdue().OrderByDescending(x => x.DueDate))
        //    {
        //        Overdue.Add(rmdr);
        //    }

        //    foreach (var rmdr in ReminderDataProvider.GetDueNow().OrderByDescending(x => x.DueDate))
        //    {
        //        DueNow.Add(rmdr);
        //    }

        //    foreach (var rmdr in ReminderDataProvider.GetUpcoming().OrderByDescending(x => x.DueDate))
        //    {
        //        Upcoming.Add(rmdr);
        //    }
        //}

        public MainViewModel()
        {
            Items.Add(ReminderViewModel.Create("Overdue", ReminderDataProvider.GetOverdue()));
            Items.Add(ReminderViewModel.Create("Due", ReminderDataProvider.GetDueNow()));
            Items.Add(ReminderViewModel.Create("Upcoming", ReminderDataProvider.GetUpcoming()));
            Items.Add(ReminderViewModel.Create("Staged", ReminderDataProvider.GetStaged()));
        }
    }
}
