using Autofac;
using Dark.Net;
using MoneyBook;
using MoneyBook.Data;
using MoneyBook.Extensions;
using MoneyBook.Models;
using MoneyBookTools.Extensions;
using MoneyBookTools.Forms;
using MoneyBookTools.ViewModels;
using System.Diagnostics;

namespace MoneyBookTools
{
    public partial class MainForm : Form
    {
        #region Fields

        private IDbContextProxy m_dbProxy;
        private List<AccountSummary> m_summaries;
        private DateFilter m_dateFilter = DateFilter.TwoWeeks;
        private SortMode m_sortOrder = SortMode.Descending;
        private StateTypes? m_stateFilter = null;
        private List<ViewTransaction> m_selectedTransactions;
        private List<ViewReminder> m_selectedReminders;

        #endregion

        #region Construction

        public static MainForm Create()
        {
            var form = new MainForm()
            {
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Maximized
            };

            DarkNet.Instance.SetWindowThemeForms(form, Theme.Dark);
            form.ChangeTheme(DarkColorScheme.Create());

            return form;
        }

        protected MainForm()
        {
            InitializeComponent();

            dgvAccountTransactions.SetDataGridViewStyle();
            dgvStagedAccountTransactions.SetDataGridViewStyle();
            dgvReminders.SetDataGridViewStyle();

            listViewAccounts.Dock = DockStyle.Fill;
            listViewAccounts.HeaderStyle = ColumnHeaderStyle.None;
            listViewAccounts.View = View.Details;
            listViewAccounts.FullRowSelect = true;
            listViewAccounts.MultiSelect = false;
            listViewAccounts.Scrollable = false;
            listViewAccounts.Resize += ListView1_Resize;
            listViewAccounts.OwnerDraw = true;

            var colWidths = new int[] { 100, 80 };
            foreach (int width in colWidths)
            {
                listViewAccounts.Columns.Add(String.Empty, width);
            }
            listViewAccounts.Columns[1].TextAlign = HorizontalAlignment.Right;

            twoWeeksToolStripMenuItem.Checked = true;
            dateDescendingToolStripMenuItem.Checked = true;
            anyStatusMenuItem.Checked = true;

            vSplit1.Dock =
            hSplit1.Dock =
            ledgerSplit.Dock =
            groupAccounts.Dock =
            listViewAccounts.Dock =
            groupLedger.Dock =
            groupStaged.Dock =
            dgvAccountTransactions.Dock =
            dgvStagedAccountTransactions.Dock =
            groupReminders.Dock =
            dgvReminders.Dock =
            mainStatusStrip1.Dock =
            tableLayoutLedger.Dock = DockStyle.Fill;

            InitializeEnvironment();
        }

        private void InitializeEnvironment()
        {
            ViewSettings.Instance.DueBeforeDay = AppSettings.Instance.DueBeforeDay;
        }

        #endregion

        #region Control Handlers

        private async void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                sumToolStripStatusLabel.Text = String.Empty;

                listViewAccounts.Items.Add("Loading...");

                using var hg = this.CreateHourglass();

                m_dbProxy = MoneyBookContainerBuilder.Container.Resolve<IDbContextProxy>();

                LoadRemindersGrid();

                LoadAccountsList();

                if (listViewAccounts.Items.Count > 0)
                {
                    listViewAccounts.Items[0].Selected = true;
                }

                var paths = await ImportTransactionsForm.GetImportFilePaths();
                if (paths.Count() > 0)
                {
                    var dlg = ImportTransactionsForm.Create();
                    dlg.ShowDialog();

                    refreshToolStripMenuItem.PerformClick();
                }
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void dgvAccountTransactions_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender is DataGridView dgv)
                {
                    CalculateSum(dgv);
                }
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void dgvReminders_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender is DataGridView dgv)
                {
                    CalculateSum(dgv);
                }
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void ListViewAccounts_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            var summary = m_summaries[e.ItemIndex];

            e.Item = new ListViewItem(summary.Name);
            e.Item.Tag = summary;
            e.Item.SubItems.Add(summary.AvailableBalance.ToString());
        }

        private void ListView1_Resize(object sender, EventArgs e)
        {
            if (listViewAccounts.Columns.Count == 2)
            {
                listViewAccounts.Columns[0].Width = listViewAccounts.Width - listViewAccounts.Margin.Right - listViewAccounts.Columns[1].Width;
            }
        }

        private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void dgvReminders_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                using var hg = this.CreateHourglass();

                ShowEditReminderDialog();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void dgvAccountTransactions_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (sender is DataGridView dgv)
                {
                    using var hg = this.CreateHourglass();

                    ShowEditTransactionDialog(dgv);
                }
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshToolStripMenuItem.PerformClick();
        }

        #endregion

        #region Menu Handlers

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using var hg = this.CreateHourglass();

                LoadAccountsList();

                LoadTransactionsGrid();

                LoadRemindersGrid();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private async void importTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var paths = await ImportTransactionsForm.GetImportFilePaths();
                if (paths.Count() == 0)
                {
                    MessageBox.Show(this, "No files were found to import.", this.Text, MessageBoxButtons.OK);
                    return;
                }

                var dlg = ImportTransactionsForm.Create();
                if (dlg == null)
                {
                    return;
                }

                dlg.ShowDialog();

                refreshToolStripMenuItem.PerformClick();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void deleteAllTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var answer = MessageBox.Show(this,
                    $"Are you sure you delete transactions across all accounts?  NOTE: This cannot be undone.",
                    this.Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (answer == DialogResult.Yes)
                {
                    using var hg = this.CreateHourglass();

                    m_dbProxy.DeleteAllTransactions();

                    MessageBox.Show(this, "Delete complete.", this.Text, MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void deleteRemindersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using var hg = this.CreateHourglass();

                DeleteReminders();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void backupDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using var hg = this.CreateHourglass();

                BackupDatabase();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void restoreDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using var hg = this.CreateHourglass();

                RestoreDatabase();

                refreshToolStripMenuItem.PerformClick();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void transactionsContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (sender is ContextMenuStrip menuStrip && menuStrip.SourceControl is DataGridView dgv)
                {
                    var count = dgv.SelectedCells
                        .Cast<DataGridViewCell>()
                        .GroupBy(x => x.RowIndex)
                        .Count();

                    setTransStateToolStripMenuItem.Enabled =
                    deleteTransToolStripMenuItem.Enabled = count > 0;

                    editTransToolStripMenuItem.Enabled = count == 1;

                    addReminderToolStripMenuItem.Enabled =
                    reconcileNewToolStripMenuItem.Enabled = dgv == dgvAccountTransactions;
                }
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void addTransToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using var hg = this.CreateHourglass();

                ShowAddTransactionDialog();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void editTransToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender is ToolStripMenuItem menuItem &&
                    menuItem.Owner is ContextMenuStrip menuStrip
                    && menuStrip.SourceControl is DataGridView dgv)
                {
                    using var hg = this.CreateHourglass();

                    ShowEditTransactionDialog(dgv);
                }
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void setTransStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender is ToolStripMenuItem menuItem &&
                    menuItem.Owner is ContextMenuStrip menuStrip
                    && menuStrip.SourceControl is DataGridView dgv)
                {
                    var dlg = StateForm.Create();

                    var result = dlg.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        using var hg = this.CreateHourglass();

                        UpdateTransactionStates(dgv, dlg.TransactionState);
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void remindersContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var count = dgvReminders.SelectedCells
                .Cast<DataGridViewCell>()
                .GroupBy(x => x.RowIndex)
                .Count();

            createReminderToolStripMenuItem.Enabled = count <= 1;

            skipReminderToolStripMenuItem.Enabled =
            deleteReminderToolStripMenuItem.Enabled = count > 0;

            stageReminderToolStripMenuItem.Enabled =
            editReminderToolStripMenuItem.Enabled =
            copyReminderToolStripMenuItem.Enabled =
            openWebsiteToolStripMenuItem.Enabled = count == 1;
        }

        private void stageReminderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using var hg = this.CreateHourglass();

                ShowStageReminderDialog();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void skipReminderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using var hg = this.CreateHourglass();

                SkipReminders();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void copyReminderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using var hg = this.CreateHourglass();

                CopyReminders();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void openWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenWebsite();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void createReminderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using var hg = this.CreateHourglass();

                ShowAddReminderDialog();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void editRemindersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using var hg = this.CreateHourglass();

                ShowEditReminderDialog();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void makeReminderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using var hg = this.CreateHourglass();

                AddTransactionReminder();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void deleteTransToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender is ToolStripMenuItem menuItem &&
                    menuItem.Owner is ContextMenuStrip menuStrip
                    && menuStrip.SourceControl is DataGridView dgv)
                {
                    using var hg = this.CreateHourglass();

                    DeleteTransactions(dgv);
                }
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AboutForm.Create().ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void reconcileNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewAccounts.SelectedIndices.Count > 0)
                {
                    int index = listViewAccounts.SelectedIndices[0];
                    var summary = m_summaries[index] as AccountSummary;

                    var answer = MessageBox.Show(this,
                        $"Are you sure you want to reconcile all new items on account {summary.Name}?",
                        this.Text,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (answer == DialogResult.Yes)
                    {
                        using var hg = this.CreateHourglass();

                        m_dbProxy.SetStateNewToReconciled(summary.AcctId);

                        refreshToolStripMenuItem.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void twoWeeksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            twoWeeksToolStripMenuItem.Checked = true;
            thisMonthToolStripMenuItem.Checked = false;
            thisYearToolStripMenuItem.Checked = false;
            allDatesToolStripMenuItem.Checked = false;

            m_dateFilter = DateFilter.TwoWeeks;

            refreshToolStripMenuItem.PerformClick();
        }

        private void thisMonthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            twoWeeksToolStripMenuItem.Checked = false;
            thisMonthToolStripMenuItem.Checked = true;
            thisYearToolStripMenuItem.Checked = false;
            allDatesToolStripMenuItem.Checked = false;

            m_dateFilter = DateFilter.ThisMonth;

            refreshToolStripMenuItem.PerformClick();
        }

        private void thisYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            twoWeeksToolStripMenuItem.Checked = false;
            thisMonthToolStripMenuItem.Checked = false;
            thisYearToolStripMenuItem.Checked = true;
            allDatesToolStripMenuItem.Checked = false;

            m_dateFilter = DateFilter.ThisYear;

            refreshToolStripMenuItem.PerformClick();
        }

        private void allDatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            twoWeeksToolStripMenuItem.Checked = false;
            thisMonthToolStripMenuItem.Checked = false;
            thisYearToolStripMenuItem.Checked = false;
            allDatesToolStripMenuItem.Checked = true;

            m_dateFilter = DateFilter.None;

            refreshToolStripMenuItem.PerformClick();
        }

        private void dateDescendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dateDescendingToolStripMenuItem.Checked = true;
            dateAscendingToolStripMenuItem.Checked = false;

            m_sortOrder = SortMode.Descending;

            refreshToolStripMenuItem.PerformClick();
        }

        private void dateAscendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dateDescendingToolStripMenuItem.Checked = false;
            dateAscendingToolStripMenuItem.Checked = true;

            m_sortOrder = SortMode.Ascending;

            refreshToolStripMenuItem.PerformClick();
        }

        private void UncheckStatusMenuItems()
        {
            newStatusMenuItem.Checked =
            pendingToolStripMenuItem.Checked =
            reconciledStatusMenuItem.Checked =
            ignoredStatusMenuItem.Checked =
            anyStatusMenuItem.Checked = false;
        }

        private void newStatusMenuItem_Click(object sender, EventArgs e)
        {
            UncheckStatusMenuItems();

            newStatusMenuItem.Checked = true;

            m_stateFilter = StateTypes.New;

            refreshToolStripMenuItem.PerformClick();
        }

        private void pendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UncheckStatusMenuItems();

            pendingToolStripMenuItem.Checked = true;

            m_stateFilter = StateTypes.Pending;

            refreshToolStripMenuItem.PerformClick();
        }

        private void reconciledStatusMenuItem_Click(object sender, EventArgs e)
        {
            UncheckStatusMenuItems();

            reconciledStatusMenuItem.Checked = true;

            m_stateFilter = StateTypes.Reconciled;

            refreshToolStripMenuItem.PerformClick();
        }

        private void ignoredStatusMenuItem_Click(object sender, EventArgs e)
        {
            UncheckStatusMenuItems();

            ignoredStatusMenuItem.Checked = true;

            m_stateFilter = StateTypes.Ignored;

            refreshToolStripMenuItem.PerformClick();
        }

        private void anyStatusMenuItem_Click(object sender, EventArgs e)
        {
            UncheckStatusMenuItems();

            anyStatusMenuItem.Checked = true;

            m_stateFilter = null;

            refreshToolStripMenuItem.PerformClick();
        }

        private void editAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ShowEditAccountDialog();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void listViewAccounts_DoubleClick(object sender, EventArgs e)
        {
            editAccountToolStripMenuItem.PerformClick();
        }

        #endregion

        #region Accounts

        private void LoadAccountsList()
        {
            listViewAccounts.Items.Clear();

            if (listViewAccounts.VirtualMode == false)
            {
                listViewAccounts.VirtualMode = true;
                listViewAccounts.RetrieveVirtualItem += ListViewAccounts_RetrieveVirtualItem;
            }

            m_summaries = m_dbProxy.GetAccountSummaries()
                .ToList();

            listViewAccounts.VirtualListSize = m_summaries.Count;
            listViewAccounts.Invalidate();
        }

        private void ShowEditAccountDialog()
        {
            if (listViewAccounts.SelectedIndices.Count > 0)
            {
                int index = listViewAccounts.SelectedIndices[0];
                var summary = m_summaries[index] as AccountSummary;

                var dlg = AccountForm.Create(summary.AcctId);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    refreshToolStripMenuItem.PerformClick();
                }
            }
        }

        #endregion

        #region Transactions

        private void SaveSelectedTransactions()
        {
            var transactions = dgvAccountTransactions.DataSource as List<ViewTransaction>;
            m_selectedTransactions = dgvAccountTransactions.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(dgvr => transactions[dgvr.Index])
                .ToList();
        }

        private void RestoreSelectedTransactions()
        {
            var transactions = dgvAccountTransactions.DataSource as List<ViewTransaction>;
            for (int i = 0; i < dgvAccountTransactions.Rows.Count; i++)
            {
                if (m_selectedTransactions.Find(x => x.TrnsId == transactions[i].TrnsId) != null)
                {
                    dgvAccountTransactions.Rows[i].Selected = true;
                }
                else
                {
                    dgvAccountTransactions.Rows[i].Selected = false;
                }
            }
        }

        private void LoadTransactionsGrid()
        {
            if (listViewAccounts.SelectedIndices.Count > 0)
            {
                int index = listViewAccounts.SelectedIndices[0];
                var summary = m_summaries[index] as AccountSummary;
                summary = m_dbProxy.GetAccountSummary(summary.AcctId);

                accountToolStripStatusLabel.Text = summary?.Name;
                currentToolStripStatusLabel.Text = $"Current: {summary?.Balance:0.00}";
                availableToolStripStatusLabel.Text = $"Available: {summary?.AvailableBalance:0.00}";
                stagedToolStripStatusLabel.Text = $"Staged: {summary?.StagedTotal:0.00}";
                finalToolStripStatusLabel.Text = $"Final: {summary?.FinalBalance:0.00}";

                IEnumerable<Transaction> transactions = m_dbProxy.GetAccountTransactions(summary.AcctId);
                List<ViewTransaction> accountTransactions;
                if (m_stateFilter != null)
                {
                    // Filter by state and date.
                    accountTransactions = transactions
                        .Where(x => x.State == m_stateFilter.ToString())
                        .Filter(m_dateFilter)
                        .Order(m_sortOrder)
                        .ToViewTransactions()
                        .ToList();
                }
                else
                {
                    // Filter by date only.
                    accountTransactions = transactions
                        .Filter(m_dateFilter)
                        .Order(m_sortOrder)
                        .ToViewTransactions()
                        .ToList();
                }

                SaveSelectedTransactions();

                LoadTransacationsGrid(dgvAccountTransactions, accountTransactions
                    .Where(x => x.State != StateTypes.Staged.ToString())
                    .ToList());

                RestoreSelectedTransactions();

                LoadTransacationsGrid(dgvStagedAccountTransactions, accountTransactions
                    .Where(x => x.State == StateTypes.Staged.ToString())
                    .ToList());
            }
        }

        private void LoadTransacationsGrid(DataGridView dgv, IList<ViewTransaction> transacations)
        {
            dgv.DataSource = transacations;

            // Resize the columns.
            var widths = new int[] { 90, 70, 80, 80, 275 };
            int i = 0;
            dgv.Columns["Date"].Width = widths[i++];
            dgv.Columns["RefNum"].Width = widths[i++];
            dgv.Columns["State"].Width = widths[i++];
            dgv.Columns["Amount"].Width = widths[i++];
            dgv.Columns["Memo"].Width = widths[i++];
            dgv.Columns["Payee"].Width =
                dgv.Width - widths.Sum() - SystemInformation.VerticalScrollBarWidth - dgv.Margin.Right;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                var vt = transacations[row.Index];

                if (vt.State != StateTypes.Reconciled.ToString())
                {
                    row.DefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Italic);
                }

                row.DefaultCellStyle.ForeColor = TransactionStateColorScheme.Instance.ForeColor(vt.State);

                row.Cells["Amount"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void UpdateTransactionStates(DataGridView dgv, StateTypes state)
        {
            var transactions = dgv.DataSource as List<ViewTransaction>;
            var selectedTransactions = dgv.SelectedCells
                .Cast<DataGridViewCell>()
                .GroupBy(x => x.RowIndex)
                .Select(g => transactions[g.Key])
                .ToList();

            if (selectedTransactions.Count() > 0)
            {
                var answer = MessageBox.Show(this,
                    $"Are you sure you want to set these {selectedTransactions.Count()} transactions to {state.ToString()}?",
                    this.Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (answer == DialogResult.Yes)
                {
                    m_dbProxy.SetTransactionStates(selectedTransactions.ToTransactionInfos(), state);

                    LoadTransactionsGrid();

                    LoadAccountsList();
                }
            }
        }

        private void AddTransactionReminder()
        {
            var transactions = dgvAccountTransactions.DataSource as List<ViewTransaction>;
            var selectedTransaction = dgvAccountTransactions.SelectedCells
                .Cast<DataGridViewCell>()
                .GroupBy(x => x.RowIndex)
                .Select(g => transactions[g.Key])
                .FirstOrDefault();

            if (selectedTransaction != null)
            {
                var dlg = ReminderForm.CreateAddForm(selectedTransaction);

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    LoadRemindersGrid();
                }
            }
        }

        private void DeleteTransactions(DataGridView dgv)
        {
            var transactions = dgv.DataSource as List<ViewTransaction>;
            var selectedTransactions = dgv.SelectedCells
                .Cast<DataGridViewCell>()
                .GroupBy(x => x.RowIndex)
                .Select(g => transactions[g.Key])
                .ToList();

            if (selectedTransactions.Count() > 0)
            {
                string msg;

                if (selectedTransactions.Count() > 0)
                {
                    msg = $"Are you sure you want to delete these {selectedTransactions.Count()} transactions?";
                }
                else
                {
                    msg = "Are you sure you want to delete this transaction?";
                }

                var answer = MessageBox.Show(this,
                    msg,
                    this.Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (answer == DialogResult.Yes)
                {
                    m_dbProxy.DeleteTransactions(selectedTransactions.ToTransactionInfos());

                    LoadTransactionsGrid();

                    LoadAccountsList();
                }
            }
        }

        private void ShowAddTransactionDialog()
        {
            if (listViewAccounts.SelectedIndices.Count > 0)
            {
                int index = listViewAccounts.SelectedIndices[0];
                var summary = m_summaries[index] as AccountSummary;

                var dlg = TransactionForm.Create(summary.AcctId);

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    LoadTransactionsGrid();

                    LoadAccountsList();
                }
            }
        }

        private void ShowEditTransactionDialog(DataGridView dgv)
        {
            var transactions = dgv.DataSource as List<ViewTransaction>;
            var selectedTransaction = dgv.SelectedCells
                .Cast<DataGridViewCell>()
                .Select(x => new
                {
                    RowIndex = x.RowIndex,
                    Transaction = transactions[x.RowIndex]
                })
                .FirstOrDefault();

            if (selectedTransaction != null)
            {
                var dlg = TransactionForm.Create(selectedTransaction.Transaction);

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    LoadTransactionsGrid();

                    LoadAccountsList();
                }
            }
        }

        private void CalculateSum(DataGridView dgv)
        {
            decimal sum = 0.0m;

            var selectedCells = dgv.SelectedCells
                .Cast<DataGridViewCell>()
                .GroupBy(x => x.RowIndex)
                .ToList();

            sumToolStripStatusLabel.Text = string.Empty;
            
            if (selectedCells.Count() <= 1)
            {
                return;
            }

            if (dgv.DataSource is List<ViewTransaction> transactions)
            {
                foreach (var textCell in selectedCells.Select(x => x.First()))
                {
                    sum += transactions[textCell.RowIndex].Amount;
                }
            }
            else if (dgv.DataSource is List<ViewReminder> reminders)
            {
                foreach (var textCell in selectedCells.Select(x => x.First()))
                {
                    sum += reminders[textCell.RowIndex].Amount;
                }
            }
            else
            {
                return;
            }

            sumToolStripStatusLabel.Text = $"Sum: {sum:0.00}";
        }
        #endregion

        #region Reminders

        /// <summary>
        /// Remember selected reminder(s).
        /// </summary>
        private void SaveSelectedReminders()
        {
            var reminders = dgvReminders.DataSource as List<ViewReminder>;
            m_selectedReminders = dgvReminders.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(dgvr => reminders[dgvr.Index])
                .ToList();
        }

        /// <summary>
        /// Reselect reminder(s).
        /// </summary>
        private void RestoreSelectedReminders()
        {
            var reminders = dgvReminders.DataSource as List<ViewReminder>;
            for (int i = 0; i < dgvReminders.Rows.Count; i++)
            {
                if (m_selectedReminders.Find(x => x.RmdrId == reminders[i].RmdrId) != null)
                {
                    dgvReminders.Rows[i].Selected = true;
                }
                else
                {
                    dgvReminders.Rows[i].Selected = false;
                }
            }
        }

        private async void LoadRemindersGrid()
        {
            var reminders = m_dbProxy.GetReminders(SortMode.Ascending)
                .ToViewReminders()
                .ToList();

            var accts = (await m_dbProxy.GetAccountsAsync())
                .ToList();

            foreach (var rem in reminders)
            {
                var acct = accts.SingleOrDefault(x => x.AcctId == rem.AcctId);

                if (acct != null)
                {
                    rem.Account = acct.Name;
                }
            }

            SaveSelectedReminders();

            dgvReminders.DataSource = reminders;

            // Resize the columns.
            var widths = new int[] { 90, 90, 275, 275, 80, 80 };
            int i = 0;
            dgvReminders.Columns["DueDate"].Width = widths[i++];
            dgvReminders.Columns["Account"].Width = widths[i++];
            dgvReminders.Columns["Memo"].Width = widths[i++];
            dgvReminders.Columns["Website"].Width = widths[i++];
            dgvReminders.Columns["Amount"].Width = widths[i++];
            dgvReminders.Columns["Frequency"].Width = widths[i++];
            dgvReminders.Columns["Payee"].Width =
                dgvReminders.Width - widths.Sum() - SystemInformation.VerticalScrollBarWidth - dgvReminders.Margin.Right;

            foreach (DataGridViewRow row in dgvReminders.Rows)
            {
                var rem = reminders[row.Index];

                if (rem.Frequency == TransactionFrequency.Paused.ToString())
                {
                    row.DefaultCellStyle.ForeColor = ReminderFrequencyColorScheme.Instance.ForeColor(rem.Frequency.ToString());
                }
                else
                {
                    if (rem.DueDate.GetDueState() != DueStateTypes.None)
                    {
                        row.DefaultCellStyle.Font = new Font(dgvAccountTransactions.Font, FontStyle.Italic);
                    }

                    row.DefaultCellStyle.ForeColor = ReminderStateColorScheme.Instance.ForeColor(rem.DueDate.GetDueState().ToString());
                }

                row.Cells["Amount"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            RestoreSelectedReminders();
        }

        private void SkipReminders()
        {
            var reminders = dgvReminders.DataSource as List<ViewReminder>;
            var selectedReminders = dgvReminders.SelectedCells
                .Cast<DataGridViewCell>()
                .GroupBy(x => x.RowIndex)
                .Select(g => reminders[g.Key])
                .ToList();

            if (selectedReminders.Count() > 0)
            {
                var answer = MessageBox.Show(this,
                    $"Are you sure you want to skip these {selectedReminders.Count()} reminders?",
                    this.Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (answer == DialogResult.Yes)
                {
                    m_dbProxy.SkipReminders(selectedReminders.ToReminders());

                    LoadRemindersGrid();
                }
            }
        }

        private void CopyReminders()
        {
            var reminders = dgvReminders.DataSource as List<ViewReminder>;
            var selectedReminders = dgvReminders.SelectedCells
                .Cast<DataGridViewCell>()
                .GroupBy(x => x.RowIndex)
                .Select(g => reminders[g.Key])
                .ToList();

            if (selectedReminders.Count() > 0)
            {
                var answer = MessageBox.Show(this,
                    $"Are you sure you want to copy these {selectedReminders.Count()} reminders?",
                    this.Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (answer == DialogResult.Yes)
                {
                    m_dbProxy.CopyReminders(selectedReminders.ToReminders());

                    LoadRemindersGrid();

                    LoadTransactionsGrid();

                    LoadAccountsList();
                }
            }
        }

        private void OpenWebsite()
        {
            var reminder = dgvReminders.DataSource as List<ViewReminder>;
            var selectedReminder = dgvReminders.SelectedCells
                .Cast<DataGridViewCell>()
                .GroupBy(x => x.RowIndex)
                .Select(g => reminder[g.Key])
                .FirstOrDefault();

            if (selectedReminder != null && !String.IsNullOrEmpty(selectedReminder.Website))
            {
                Process.Start(new ProcessStartInfo(selectedReminder.Website) { UseShellExecute = true });
            }
        }

        private void DeleteReminders()
        {
            var reminders = dgvReminders.DataSource as List<ViewReminder>;
            var selectedReminders = dgvReminders.SelectedCells
                .Cast<DataGridViewCell>()
                .GroupBy(x => x.RowIndex)
                .Select(g => reminders[g.Key])
                .ToList();

            if (selectedReminders.Count() > 0)
            {
                var answer = MessageBox.Show(this,
                    $"Are you sure you want to delete these {selectedReminders.Count()} reminders?",
                    this.Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (answer == DialogResult.Yes)
                {
                    m_dbProxy.DeleteReminders(selectedReminders.ToReminders());

                    LoadRemindersGrid();
                }
            }
        }

        private void ShowAddReminderDialog()
        {
            var dlg = ReminderForm.CreateAddForm();

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                LoadRemindersGrid();
            }
        }

        private void ShowEditReminderDialog()
        {
            var reminders = dgvReminders.DataSource as List<ViewReminder>;
            var selectedReminder = dgvReminders.SelectedCells
                .Cast<DataGridViewCell>()
                .Select(x => new
                {
                    RowIndex = x.RowIndex,
                    ViewReminder = reminders[x.RowIndex]
                })
                .FirstOrDefault();

            if (selectedReminder != null)
            {
                var dlg = ReminderForm.CreateEditForm(selectedReminder.ViewReminder);

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    LoadRemindersGrid();
                }
            }
        }

        private void ShowStageReminderDialog()
        {
            var reminders = dgvReminders.DataSource as List<ViewReminder>;
            var selectedReminders = dgvReminders.SelectedCells
                .Cast<DataGridViewCell>()
                .Select(x => new
                {
                    RowIndex = x.RowIndex,
                    ViewReminder = reminders[x.RowIndex]
                })
                .FirstOrDefault();

            if (selectedReminders != null)
            {
                var dlg = ReminderForm.CreateStageForm(selectedReminders.ViewReminder);

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    LoadTransactionsGrid();

                    LoadRemindersGrid();
                }
            }
        }
        #endregion

        #region Database Operations

        private void BackupDatabase()
        {
            var fbd = new FolderBrowserDialog()
            {
                ShowNewFolderButton = true,
                UseDescriptionForTitle = true,
                Description = "Select Backup Directory",
                InitialDirectory = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Backup", "MoneyBook")
            };

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                m_dbProxy.BackupDatabase(fbd.SelectedPath);

                MessageBox.Show(this, "Backup complete.", this.Text, MessageBoxButtons.OK);
            }
        }

        private void RestoreDatabase()
        {
            var answer = MessageBox.Show(this,
                "Restore Database will delete all records in all tables and import data from " +
                "file into the tables. Note: This cannot be undone. Continue?",
                this.Text,
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (answer == DialogResult.Yes)
            {
                var ofd = new OpenFileDialog()
                {
                    InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString(),
                    Filter = "Data Files|*.json;*.json|All Files|*.*",
                    Multiselect = false
                };

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    m_dbProxy.RestoreDatabase(ofd.FileName);

                    MessageBox.Show(this, "Restore complete.", this.Text, MessageBoxButtons.OK);
                }
            }
        }

        #endregion
    }
}
