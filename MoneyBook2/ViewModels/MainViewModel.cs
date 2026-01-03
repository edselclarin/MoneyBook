using Autofac;
using Caliburn.Micro;
using Microsoft.Win32;
using MoneyBook;
using MoneyBook.Data;
using MoneyBook.Models;
using MoneyBook2.DataModels;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Account = MoneyBook2.DataModels.Account;

namespace MoneyBook2.ViewModels
{
    public record ViewData(List<Account> Accounts, List<Due> Dues);

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

        private bool _hasDuesChecked;
        public bool HasDuesChecked
        {
            get { return _hasDuesChecked; }
            set
            {
                _hasDuesChecked = value;

                NotifyOfPropertyChange(() => HasDuesChecked);
            }
        }

        private ObservableCollection<Due> _selectedDues = new();
        public ObservableCollection<Due> SelectedDues
        {
            get { return _selectedDues; }
            set
            {
                _selectedDues = value;

                NotifyOfPropertyChange(() => SelectedDues);
            }
        }

        private int _selectedCount;
        public int SelectedCount
        {
            get => _selectedCount;
            set
            {
                _selectedCount = value;

                NotifyOfPropertyChange(() => SelectedCount);
            }
        }

        private bool _hasSelectedDues;
        public bool HasSelectedDues
        {
            get { return _hasSelectedDues; }
            set
            {
                _hasSelectedDues = value;

                NotifyOfPropertyChange(() => HasSelectedDues);
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

        public ICommand ImportTransactionsCommand { get; }
        public ICommand BackupDatabaseCommand { get; }
        public ICommand RestoreDatabaseCommand { get; }

        // Hyperlink Commands
        public ICommand ToggleSelectedDueCommand { get; }
        public ICommand UncheckAllDuesCommand { get; }
        public ICommand DeselectDuesCommand { get; }
        public ICommand SkipDueCommand { get; }
        public ICommand DeleteDueCommand { get; }
        public ICommand CreateDueCommand { get; }
        public ICommand EditDueCommand { get; }

        // Context Menu Commands
        public ICommand SkipSelectedDuesCommand { get; }
        public ICommand DeleteSelectedDuesCommand { get; }
        public ICommand EditSelectedDueCommand { get; }
        public ICommand OpenWebsiteCommand { get; }
        public ICommand CreateNewDueCommand { get; }

        public MainViewModel()
        {
            _dbProxy = MoneyBookContainerBuilder.Container.Resolve<IDbContextProxy>();

            _selectedDues.CollectionChanged += SelectedDues_CollectionChanged;

            RefreshViewCommand = new RelayCommand<object>(async (_) => await RefreshViewAsync());

            ImportTransactionsCommand = new RelayCommand<object>(async (_) => await ImportTransactionsAsync(_));
            BackupDatabaseCommand = new RelayCommand<object>(async (_) => await BackupDatabaseAsync(_));
            RestoreDatabaseCommand = new RelayCommand<object>(async (_) => await RestoreDatabaseAsync(_));

            ToggleSelectedDueCommand = new RelayCommand<Due>(ToggleSelectedDue);
            UncheckAllDuesCommand = new RelayCommand<Due>(UncheckAllDues, (_) => HasDuesChecked);
            DeselectDuesCommand = new RelayCommand<object>((_) => DeselectDues(), (_) => SelectedDues.Count > 0);
            SkipDueCommand = new RelayCommand<object>(async (_) => await SkipDueAsync(_), (_) => SelectedDues.Count > 0);
            DeleteDueCommand = new RelayCommand<object>(async (_) => await DeleteDueAsync(_), (_) => SelectedDues.Count > 0);
            CreateDueCommand = new RelayCommand<object>(async (_) => await CreateDueAsync(_), (_) => SelectedDues.Count == 0);
            EditDueCommand = new RelayCommand<object>(async (_) => await EditDueAsync(_), (_) => SelectedDues.Count == 1);

            SkipSelectedDuesCommand = new RelayCommand<IList>(SkipSelectedDues, (_) => SelectedDues.Count > 0);
            DeleteSelectedDuesCommand = new RelayCommand<IList>(DeleteSelectedDues, (_) => SelectedDues.Count > 0);
            EditSelectedDueCommand = new RelayCommand<IList>(EditSelectedDue, (_) => SelectedDues.Count == 1);
            OpenWebsiteCommand = new RelayCommand<IList>(OpenWebsite, (_) => SelectedDues.Count == 1);
            CreateNewDueCommand = new RelayCommand<object>(CreateNewDue);
        }

        #region View Operations

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);

            await RefreshViewAsync();
        }

        public async Task RefreshViewAsync()
        {
            try
            {
                CurrentCursor = Cursors.Wait;

                // Fetch data in the background.
                var data = await Task.Run(() => LoadViewData());

                // Apply data on the UI thread.
                ApplyViewData(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception during refresh. {ex.Message}", Resources.AppTitle);
            }
            finally
            {
                CurrentCursor = Cursors.Arrow;
            }
        }

        private ViewData LoadViewData()
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
            var savedDues = GetDuesFromFile(_duesFilesname);
            var reminders = _dbProxy.GetReminders(SortMode.Ascending)
                .ToList();
            var dues = reminders
                .Select(reminder =>
                {
                    var due = Due.FromReminder(reminder);

                    due.AccountName = accounts
                        .SingleOrDefault(a => a.AcctId == reminder.AcctId)?.Name ?? string.Empty;

                    due.IsChecked = savedDues
                        ?.SingleOrDefault(d => d.Matches(reminder))?.IsChecked ?? false;

                    if (due.IsChecked)
                    {
                        var account = accounts.FirstOrDefault(a => a.AcctId == due.AcctId);
                        if (account is not null)
                        {
                            if (due.IsChecked)
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

            return new ViewData(accounts, dues);
        }

        private void ApplyViewData(ViewData data)
        {
            Accounts = new ObservableCollection<Account>(data.Accounts);
            Dues = new ObservableCollection<Due>(data.Dues);
            HasDuesChecked = Dues.Any(d => d.IsChecked);
        }

        #endregion

        #region Database Operations

        private async Task ImportTransactionsAsync(object obj)
        {
            try
            {
                CurrentCursor = Cursors.Wait;

                await _dbProxy.ImportTransactionsAsync();

                await RefreshViewAsync();

                CurrentCursor = Cursors.Arrow;

                MessageBox.Show("Import complete.", Resources.AppTitle);
            }
            catch (Exception ex)
            {
                CurrentCursor = Cursors.Arrow;

                MessageBox.Show($"Exception during import. {ex.Message}", Resources.AppTitle);
            }
        }

        private static readonly string _backupFolder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Backup", "MoneyBook");
        private static readonly string _dataFolder = @"C:\ProgramData\MoneyBook";
        private static readonly string _duesFilesname = Path.Combine(_dataFolder, "dues.json");

        private async Task BackupDatabaseAsync(object obj)
        {
            try
            {
                var ofd = new OpenFolderDialog()
                {
                    InitialDirectory = _backupFolder,
                };

                var result = ofd.ShowDialog();
                if (result.Equals(false))
                {
                    return;
                }

                CurrentCursor = Cursors.Wait;

                var backupResult = await _dbProxy.BackupDatabaseAsync(ofd.FolderName);
                if (backupResult.IsFailure)
                {
                    MessageBox.Show(backupResult.Error, Resources.AppTitle);
                    return;
                }

                CurrentCursor = Cursors.Arrow;

                var textBackupFilename = backupResult.Value
                    .SingleOrDefault(f => f.Contains("json", StringComparison.OrdinalIgnoreCase));
                if (string.IsNullOrEmpty(textBackupFilename))
                {
                    MessageBox.Show($"Backup failed. No text backup file found.", Resources.AppTitle);
                    return;
                }

                string backupDuesFilename = Path.Combine(
                    _backupFolder, 
                    $"{Path.GetFileNameWithoutExtension(textBackupFilename)}-Dues{Path.GetExtension(textBackupFilename)}");
                SaveDuesToFile(backupDuesFilename);

                await RefreshViewAsync();

                MessageBox.Show("Backup complete.", Resources.AppTitle);
            }
            catch (Exception ex)
            {
                CurrentCursor = Cursors.Arrow;

                MessageBox.Show($"Exception during backup. {ex.Message}", Resources.AppTitle);
            }
        }

        private async Task RestoreDatabaseAsync(object obj)
        {
            try
            {
                var ofd = new OpenFileDialog()
                {
                    InitialDirectory = _backupFolder,
                    Filter = "Data Files|*.json;*.json|All Files|*.*",
                    Multiselect = false
                };

                var result = ofd.ShowDialog();
                if (result.Equals(false))
                {
                    return;
                }

                CurrentCursor = Cursors.Wait;

                var restoreResult = await _dbProxy.RestoreDatabaseAsync(ofd.FileName);
                if (restoreResult.IsFailure)
                {
                    MessageBox.Show(restoreResult.Error, Resources.AppTitle);
                    return;
                }

                CurrentCursor = Cursors.Arrow;

                string backupDuesFilename = Path.Combine(
                    _backupFolder,
                    $"{Path.GetFileNameWithoutExtension(ofd.FileName)}-Dues{Path.GetExtension(ofd.FileName)}");
                if (File.Exists(backupDuesFilename))
                {
                    File.Copy(backupDuesFilename, _duesFilesname, overwrite: true);
                }

                await RefreshViewAsync();

                MessageBox.Show("Restore complete.", Resources.AppTitle);
            }
            catch (Exception ex)
            {
                CurrentCursor = Cursors.Arrow;

                MessageBox.Show($"Exception during restore. {ex.Message}", Resources.AppTitle);
            }
        }

        #endregion

        #region Operations on Dues

        private void ToggleSelectedDue(Due due)
        {
            var accounts = Accounts.ToList();
            var account = accounts.FirstOrDefault(a => a.AcctId == due.AcctId);
            if (account is null)
            {
                return;
            }

            // Update account.
            if (due.IsChecked)
            {
                account.TotalDues += due.Amount;
            }
            else
            {
                account.TotalDues -= due.Amount;
            }
            Accounts = new ObservableCollection<Account>(accounts);

            HasDuesChecked = Dues.Any(d => d.IsChecked);

            SaveDuesToFile(_duesFilesname);
        }

        private void UncheckAllDues(Due due)
        {
            var accounts = Accounts.ToList();
            var dues = Dues.ToList();
            dues.ForEach(due =>
            {
                var account = accounts.FirstOrDefault(a => a.AcctId == due.AcctId);
                if (account is not null)
                {
                    if (due.IsChecked)
                    {
                        due.IsChecked = false;
                        account.TotalDues -= due.Amount;
                    }
                }
            });

            Accounts = new ObservableCollection<Account>(accounts);
            Dues = new ObservableCollection<Due>(dues);
            HasDuesChecked = Dues.Any(d => d.IsChecked);

            SaveDuesToFile(_duesFilesname);
        }

        private void SelectedDues_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            // Raise HasSelectedDues whenever selection changes
            SelectedCount = _selectedDues is not null ? _selectedDues.Count() : 0;
            HasSelectedDues = SelectedCount > 0;
        }

        private void DeselectDues()
        {
            SelectedDues.Clear();
        }

        private async Task SkipDueAsync(object _)
        {
            string question = SelectedDues.Count == 1
                ? "Are you sure you want to skip the selected due?"
                : $"Are you sure you want to skip the {SelectedDues.Count} selected dues?";
            var answer = MessageBox.Show(question, Resources.AppTitle, MessageBoxButton.YesNo);
            if (answer != MessageBoxResult.Yes)
            {
                return;
            }

            try
            {
                var reminders = _selectedDues
                    .Select(due => due as Reminder)
                    .ToList();

                _dbProxy.SkipReminders(reminders);

                SelectedDues.Clear();

                await RefreshViewAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception while skipping dues. {ex.Message}");
            }
        }

        private async Task DeleteDueAsync(object _)
        {
            string question = SelectedDues.Count == 1
                ? "Are you sure you want to delete the selected due?"
                : $"Are you sure you want to delete the {SelectedDues.Count} selected dues?";
            var answer = MessageBox.Show(question, Resources.AppTitle, MessageBoxButton.YesNo);
            if (answer != MessageBoxResult.Yes)
            {
                return;
            }

            try
            {
                var reminders = _selectedDues
                    .Select(due => due as Reminder)
                    .ToList();

                _dbProxy.DeleteReminders(reminders);

                SelectedDues.Clear();

                await RefreshViewAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception while deleting dues. {ex.Message}");
            }
        }

        private async Task CreateDueAsync(object _)
        {
            try
            {
                var vmForm = IoC.Get<DueFormViewModel>();

                vmForm.Title = "Create Due";
                vmForm.Accounts = new ReadOnlyCollection<Account>(Accounts);

                var windowManager = IoC.Get<IWindowManager>();
                var result = await windowManager.ShowDialogAsync(vmForm);
                if (result == false)
                {
                    return;
                }

                var reminder = vmForm.Due as Reminder;

                _dbProxy.AddReminder(reminder);

                SelectedDues.Clear();

                await RefreshViewAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception while creating due. {ex.Message}");
            }
        }

        private async Task EditDueAsync(object _)
        {
            try
            {
                var vmForm = IoC.Get<DueFormViewModel>();

                vmForm.Title = "Edit Due";
                vmForm.Accounts = new ReadOnlyCollection<Account>(Accounts);
                vmForm.SetDue(SelectedDues.FirstOrDefault());

                var windowManager = IoC.Get<IWindowManager>();
                var result = await windowManager.ShowDialogAsync(vmForm);
                if (result == false)
                {
                    return;
                }

                var reminder = vmForm.Due as Reminder;

                _dbProxy.UpdateReminder(reminder);

                SelectedDues.Clear();

                await RefreshViewAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception while updating due. {ex.Message}");
            }
        }

        private async void SkipSelectedDues(IList selectedItems)
        {
            if (selectedItems == null || selectedItems.Count == 0)
            {
                return;
            }

            await SkipDueAsync(null);
        }

        private async void DeleteSelectedDues(IList selectedItems)
        {
            if (selectedItems == null || selectedItems.Count == 0)
            {
                return;
            }

            await DeleteDueAsync(null);
        }

        private async void EditSelectedDue(IList selectedItems)
        {
            if (selectedItems == null || selectedItems.Count != 1)
            {
                return;
            }

            await EditDueAsync(null);
        }

        private void OpenWebsite(IList selectedItems)
        {
            if (selectedItems == null || selectedItems.Count != 1)
            {
                return;
            }

            var due = selectedItems
                .Cast<Due>()
                .FirstOrDefault();

            if (due is null || string.IsNullOrWhiteSpace(due.Website))
            {
                return;
            }

            Process.Start(new ProcessStartInfo(due.Website) { UseShellExecute = true });

        }

        private async void CreateNewDue(object _)
        {
            await CreateDueAsync(_);
        }

        #endregion

        #region File Operations for Dues

        private List<Due>? GetDuesFromFile(string? filepath)
        {
            try
            {
                if (!File.Exists(filepath))
                {
                    return null;
                }

                string json = File.ReadAllText(filepath);
                return JsonConvert.DeserializeObject<List<Due>>(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception while getting dues from{filepath}. {ex.Message}");
            }

            return null;
        }

        private void SaveDuesToFile(string? filepath)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(filepath))
                {
                    return;
                }

                var dues = Dues.ToList();
                string json = JsonConvert.SerializeObject(dues, Formatting.Indented);
                File.WriteAllText(filepath ?? filepath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception while saving dues to {filepath}. {ex.Message}");
            }
        }

        #endregion
    }
}
