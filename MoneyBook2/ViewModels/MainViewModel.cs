using Autofac;
using Caliburn.Micro;
using Microsoft.Win32;
using MoneyBook;
using MoneyBook.Data;
using MoneyBook.DataProviders;
using MoneyBook2.DataModels;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
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

        private Cursor _currentCursor;
        public Cursor CurrentCursor
        {
            get => _currentCursor;
            set
            {
                _currentCursor = value;

                NotifyOfPropertyChange(() => CurrentCursor);
            }
        }

        public ICommand RefreshViewCommand { get; }
        public ICommand ToggleSelectedDueCommand { get; }
        public ICommand ClearSelectionCommand { get; }
        public ICommand ImportTransactionsCommand { get; }
        public ICommand BackupDatabaseCommand { get; }
        public ICommand RestoreDatabaseCommand { get; }

        public MainViewModel()
        {
            _dbProxy = MoneyBookContainerBuilder.Container.Resolve<IDbContextProxy>();

            RefreshViewCommand = new RelayCommand<object>(RefreshView);
            ToggleSelectedDueCommand = new RelayCommand<Due>(ToggleSelectedDue);
            ClearSelectionCommand = new RelayCommand<Due>(ClearSelection);
            ImportTransactionsCommand = new RelayCommand<object>(async (_) => await ImportTransactionsAsync(_));
            BackupDatabaseCommand = new RelayCommand<object>(async (_) => await BackupDatabaseAsync(_));
            RestoreDatabaseCommand = new RelayCommand<object>(async (_) => await RestoreDatabaseAsync(_));

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

        private async Task ImportTransactionsAsync(object obj)
        {
            CurrentCursor = Cursors.Wait;

            await _dbProxy.ImportTransactionsAsync();

            RefreshView(null);

            CurrentCursor = Cursors.Arrow;

            MessageBox.Show("Import complete.", Resources.AppTitle);
        }

        private async Task BackupDatabaseAsync(object obj)
        {
            var ofd = new OpenFolderDialog()
            {
                InitialDirectory = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Backup", "MoneyBook"),
            };

            var result = ofd.ShowDialog();
            if (result.Equals(false))
            {
                return;
            }

            CurrentCursor = Cursors.Wait;

            await _dbProxy.BackupDatabaseAsync(ofd.FolderName);

            RefreshView(null);

            CurrentCursor = Cursors.Arrow;

            MessageBox.Show("Backup complete.", Resources.AppTitle);
        }

        private async Task RestoreDatabaseAsync(object obj)
        {
            var ofd = new OpenFileDialog()
            {
                InitialDirectory = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Backup", "MoneyBook"),
                Filter = "Data Files|*.json;*.json|All Files|*.*",
                Multiselect = false
            };

            var result = ofd.ShowDialog();
            if (result.Equals(false))
            {
                return;
            }

            CurrentCursor = Cursors.Wait;

            await _dbProxy.RestoreDatabaseAsync(ofd.FileName);

            RefreshView(null);

            CurrentCursor = Cursors.Arrow;

            MessageBox.Show("Restore complete.", Resources.AppTitle);
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
