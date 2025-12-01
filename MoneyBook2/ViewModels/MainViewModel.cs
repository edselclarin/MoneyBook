using Autofac;
using Caliburn.Micro;
using MoneyBook;
using MoneyBook.Data;
using MoneyBook2.DataModels;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Account = MoneyBook2.DataModels.Account;

namespace MoneyBook2.ViewModels
{
    public class MainViewModel : Screen
    {
        private IDbContextProxy _dbProxy;

        private ObservableCollection<Account> _accounts;
        public ObservableCollection<Account> Accounts
        {
            get { return _accounts; }
            set
            {
                _accounts = value;

                NotifyOfPropertyChange(() => Accounts);
            }
        }

        private ObservableCollection<Due> _dues;
        public ObservableCollection<Due> Dues
        {
            get { return _dues; }
            set
            {
                _dues = value;

                NotifyOfPropertyChange(() => Dues);
            }
        }

        private bool _areDuesSelected;
        public bool AreDuesSelected
        {
            get { return _areDuesSelected; }
            set
            {
                _areDuesSelected = value;
                NotifyOfPropertyChange(() => AreDuesSelected);
            }
        }

        public ICommand RefreshViewCommand { get; }
        public ICommand ToggleSelectedDueCommand { get; }
        public ICommand ClearSelectionCommand { get; }

        public MainViewModel()
        {
            _dbProxy = MoneyBookContainerBuilder.Container.Resolve<IDbContextProxy>();

            RefreshViewCommand = new RelayCommand<object>(RefreshView);
            ToggleSelectedDueCommand = new RelayCommand<Due>(ToggleSelectedDue);
            ClearSelectionCommand = new RelayCommand<Due>(ClearSelection);

            this.Activated += OnActivated;
        }

        private async Task OnActivated(object sender, ActivationEventArgs e)
        {
            RefreshView(null);
        }

        private void RefreshView(object obj)
        {
            // Get accounts.
            var accountSummaries = _dbProxy.GetAccountSummaries().ToList();
            var accounts = accountSummaries
                .Select(summary => 
                {
                    var account = Account.FromAccountSummary(summary);
                    account.TotalDues = 0.00m;
                    return account;
                })
                .ToList();

            // Generate dues from reminders, and restore reminders previously selected.
            var savedDues = GetDuesFromFile();
            var reminders = _dbProxy.GetReminders(SortMode.Ascending).ToList();
            var dues = reminders
                .Select(reminder => 
                {
                    var due = Due.FromReminder(reminder);

                    due.AccountName = accounts
                        .SingleOrDefault(a => a.AcctId == reminder.AcctId)?.Name ?? string.Empty;

                    due.IsSelected = savedDues
                        ?.SingleOrDefault(d => d.RmdrId == reminder.RmdrId)?.IsSelected ?? false;

                    if (due.IsSelected)
                    {
                        var account = accounts.FirstOrDefault(a => a.AcctId == due.AcctId);
                        if (account is not null)
                        {
                            if (due.IsSelected)
                            {
                                account.TotalDues += due.Amount;
                            }
                            else
                            {
                                account.TotalDues -= due.Amount;
                            }
                        }
                    }
                    return due;
                })
                .ToList();

            Accounts = new ObservableCollection<Account>(accounts);
            Dues = new ObservableCollection<Due>(dues);
            AreDuesSelected = Dues.Any(d => d.IsSelected);
        }

        private void ToggleSelectedDue(Due due)
        {
            var accounts = Accounts.ToList();
            var account = accounts.FirstOrDefault(a => a.AcctId == due.AcctId);
            if (account is null)
            {
                return;
            }

            // Update account.
            if (due.IsSelected)
            {
                account.TotalDues += due.Amount;
            }
            else
            {
                account.TotalDues -= due.Amount;
            }
            Accounts = new ObservableCollection<Account>(accounts);

            AreDuesSelected = Dues.Any(d => d.IsSelected);

            SaveDuesToFile();
        }

        private void ClearSelection(Due due)
        {
            var accounts = Accounts.ToList();
            var dues = Dues.ToList();
            dues.ForEach(due =>
            {
                var account = accounts.FirstOrDefault(a => a.AcctId == due.AcctId);
                if (account is not null)
                {
                    if (due.IsSelected)
                    {
                        due.IsSelected = false;
                        account.TotalDues -= due.Amount;
                    }
                }
            });

            Accounts = new ObservableCollection<Account>(accounts);
            Dues = new ObservableCollection<Due>(dues);
            AreDuesSelected = Dues.Any(d => d.IsSelected);

            SaveDuesToFile();

        }

        #region File Operations

        private string _duesFilesname = @"C:\ProgramData\MoneyBook\dues.json";

        private List<Due>? GetDuesFromFile()
        {
            try
            {
                if (!File.Exists(_duesFilesname))
                {
                    return null;
                }

                string json = File.ReadAllText(_duesFilesname);
                return JsonConvert.DeserializeObject<List<Due>>(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception while getting dues. {ex.Message}");
            }

            return null;
        }

        private void SaveDuesToFile()
        {
            try
            {
                var dues = Dues.ToList();
                string json = JsonConvert.SerializeObject(dues, Formatting.Indented);
                File.WriteAllText(_duesFilesname, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception while saving dues. {ex.Message}");
            }
        }

        #endregion
    }
}
