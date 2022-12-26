using Dark.Net;
using MoneyBook.BusinessModels;
using MoneyBook.Data;
using MoneyBookTools.Data;
using MoneyBookTools.Forms;
using MoneyBookTools.ViewModels;
using System.Diagnostics;

namespace MoneyBookTools
{
    public partial class MainForm : Form
    {
        #region Fields

        private MoneyBookDbContext m_db;
        private List<AccountSummary> m_summaries;
        private MoneyBookDbContextExtension.DateFilter m_dateFilter = MoneyBookDbContextExtension.DateFilter.TwoWeeks;
        private MoneyBookDbContextExtension.SortOrder m_sortOrder = MoneyBookDbContextExtension.SortOrder.Descending;
        private List<ViewTransaction> m_selectedTransactions;
        private List<ViewRecurringTransaction> m_selectedRecurringTransactions;

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
            dgvRecurringTransactions.SetDataGridViewStyle();

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

            vSplit1.Dock =
            hSplit1.Dock = 
            groupAccounts.Dock =
            listViewAccounts.Dock =
            groupLedger.Dock =
            dgvAccountTransactions.Dock =
            groupUpcoming.Dock =
            dgvRecurringTransactions.Dock = 
            statusStrip1.Dock = 
            tableLayoutLedger.Dock = DockStyle.Fill;
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

                await Task.Run(() =>
                {
                    m_db = MoneyBookDbContext.Create(MoneyBookToolsDbContextConfig.Instance);
                });

                LoadRecurringTransactionsGrid();

                LoadAccountsList();

                if (listViewAccounts.Items.Count > 0)
                {
                    listViewAccounts.Items[0].Selected = true;
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
                CalculateSum();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void ListViewAccounts_RetrieveVirtualItem(object? sender, RetrieveVirtualItemEventArgs e)
        {
            var summary = m_summaries[e.ItemIndex];

            e.Item = new ListViewItem(summary.Account.AccountName);
            e.Item.Tag = summary.Account;
            e.Item.SubItems.Add(summary.AvailableBalance.ToString());
        }

        private void ListView1_Resize(object? sender, EventArgs e)
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

        private void dgvRecurringTransactions_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                using var hg = this.CreateHourglass();

                ShowEditRecTransactionDialog();
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
                using var hg = this.CreateHourglass();

                ShowEditTransactionDialog();
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
                if (m_db != null)
                {
                    using var hg = this.CreateHourglass();

                    LoadTransactionsGrid();

                    LoadAccountsList();
                }
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FileTransactionsForm.Create().ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void importTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var accountDataArr = AppSettings.Instance.Accounts
                    .Where(x => File.Exists(x.ImportFilePath));

                if (accountDataArr.Count() > 0)                {

                    var answer = MessageBox.Show(this,
                        $"Are you sure you want to import the transactions from these files into these accounts?" +
                        Environment.NewLine +
                        Environment.NewLine +
                        String.Join(Environment.NewLine, accountDataArr.Select(x => $"{x.ImportFilePath} --> {x.Name}")),
                        this.Text,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (answer == DialogResult.Yes)
                    {
                        using var hg = this.CreateHourglass();

                        m_db.ImportTransactions(accountDataArr);

                        MessageBox.Show(this, "Import complete.", this.Text, MessageBoxButtons.OK);

                        refreshToolStripMenuItem.PerformClick();
                    }
                }
                else
                {
                    MessageBox.Show(this, "No files found.  Make sure files exists and paths are correct in appSettings.json.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

                    m_db.DeleteAllTransactions();

                    MessageBox.Show(this, "Delete complete.", this.Text, MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void importRecurringTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var answer = MessageBox.Show(this,
                    "Importing data from file will delete all existing recurring transactions from the database. " +
                    "This cannot be undone. Continue?",
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
                        m_db.ImportRecurringTransactions(ofd.FileName);

                        LoadRecurringTransactionsGrid();

                        MessageBox.Show(this, "Import complete.", this.Text, MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void exportRecurringTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var sfd = new SaveFileDialog()
                {
                    InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString(),
                    FileName = $"MoneyTools-RecurringTransactions-{DateTime.Now.ToString("yyyy-MMdd-HHmmss")}.json",
                    Filter = "Data Files|*.json;*.json|All Files|*.*",
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    m_db.ExportRecurringTransactions(sfd.FileName);

                    MessageBox.Show(this, "Export complete.", this.Text, MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }

        }

        private void deleteRecurringTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var answer = MessageBox.Show(this,
                    $"Are you sure you delete recurring transactions across all accounts?  NOTE: This cannot be undone.",
                    this.Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (answer == DialogResult.Yes)
                {
                    using var hg = this.CreateHourglass();

                    m_db.DeleteAllRecurringTransactions();

                    MessageBox.Show(this, "Delete complete.", this.Text, MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void updateAccountDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var accountDataArr = AppSettings.Instance.Accounts.ToArray();

                if (accountDataArr.Length > 0)
                {
                    var answer = MessageBox.Show(this,
                        $"Are you sure you want the data of all accounts?" +
                        Environment.NewLine +
                        Environment.NewLine +
                        String.Join(Environment.NewLine, accountDataArr.Select(x => $"{x.Name} --> {x.StartingBalance}")),
                        this.Text,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (answer == DialogResult.Yes)
                    {
                        using var hg = this.CreateHourglass();

                        m_db.UpdateAccountData(accountDataArr);

                        MessageBox.Show(this, "Update complete.", this.Text, MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show(this, "No accounts found.  Check imports in appSettings.json.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void resetAccountDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var answer = MessageBox.Show(this,
                    $"Are you sure you reset the account data of all accounts?",
                    this.Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (answer == DialogResult.Yes)
                {
                    using var hg = this.CreateHourglass();

                    m_db.ResetAccountData();

                    MessageBox.Show(this, "Reset complete.", this.Text, MessageBoxButtons.OK);
                }
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
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }
      
        private void transContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                var count = dgvAccountTransactions.SelectedCells
                    .Cast<DataGridViewCell>()
                    .GroupBy(x => x.RowIndex)
                    .Count();

                setTransStateToolStripMenuItem.Enabled =
                deleteTransToolStripMenuItem.Enabled = count > 0;

                makeRecTransToolStripMenuItem.Enabled =
                editTransToolStripMenuItem.Enabled = count == 1;
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
                using var hg = this.CreateHourglass();

                ShowEditTransactionDialog();
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
                var dlg = StateForm.Create();

                var result = dlg.ShowDialog();

                if (result == DialogResult.OK)
                {
                    using var hg = this.CreateHourglass();

                    UpdateTransactionStates(dlg.TransactionState);
                }
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void recTransContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var count = dgvRecurringTransactions.SelectedCells
                .Cast<DataGridViewCell>()
                .GroupBy(x => x.RowIndex)
                .Count();

            stageRecTransToolStripMenuItem.Enabled =
            skipRecTransToolStripMenuItem.Enabled = 
            deleteRecTransToolStripMenuItem.Enabled = count > 0;

            editRecTransToolStripMenuItem.Enabled = 
            copyRecTransToolStripMenuItem.Enabled =
            openWebsiteToolStripMenuItem.Enabled = count == 1;
        }

        private void stageRecTransToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using var hg = this.CreateHourglass();

                StageRecurringTransactions();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void skipRecTransToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using var hg = this.CreateHourglass();

                SkipRecurringTransactions();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void copyRecTransToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using var hg = this.CreateHourglass();

                CopyRecurringTransactions();
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

        private void deleteRecTransToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using var hg = this.CreateHourglass();

                DeleteRecurringTransactions();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void editRecTranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using var hg = this.CreateHourglass();

                ShowAddRecTransactionDialog();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void editRecTransToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using var hg = this.CreateHourglass();

                ShowEditRecTransactionDialog();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void makeRecTransToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using var hg = this.CreateHourglass();

                MakeTransactionRecurring();
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
                using var hg = this.CreateHourglass();

                DeleteTransactions();
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
                        $"Are you sure you want to reconcile all new items on account {summary.Account.AccountName}?",
                        this.Text,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (answer == DialogResult.Yes)
                    {
                        using var hg = this.CreateHourglass();

                        m_db.SetStateNewToReconciled(summary.Account.AcctId);

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

            m_dateFilter = MoneyBookDbContextExtension.DateFilter.TwoWeeks;

            refreshToolStripMenuItem.PerformClick();
        }

        private void thisMonthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            twoWeeksToolStripMenuItem.Checked = false;
            thisMonthToolStripMenuItem.Checked = true;
            thisYearToolStripMenuItem.Checked = false;

            m_dateFilter = MoneyBookDbContextExtension.DateFilter.ThisMonth;

            refreshToolStripMenuItem.PerformClick();
        }

        private void thisYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            twoWeeksToolStripMenuItem.Checked = false;
            thisMonthToolStripMenuItem.Checked = false;
            thisYearToolStripMenuItem.Checked = true;

            m_dateFilter = MoneyBookDbContextExtension.DateFilter.ThisYear;

            refreshToolStripMenuItem.PerformClick();
        }

        private void dateDescendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dateDescendingToolStripMenuItem.Checked = true;
            dateAscendingToolStripMenuItem.Checked = false;

            m_sortOrder = MoneyBookDbContextExtension.SortOrder.Descending;

            refreshToolStripMenuItem.PerformClick();
        }

        private void dateAscendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dateDescendingToolStripMenuItem.Checked = false;
            dateAscendingToolStripMenuItem.Checked = true;

            m_sortOrder = MoneyBookDbContextExtension.SortOrder.Ascending;

            refreshToolStripMenuItem.PerformClick();
        }
        #endregion

        #region Child Form Handlers

        private void transactionForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            try
            {
                var form = sender as TransactionForm;
                if (form.DialogResult == DialogResult.OK)
                {
                    using var hg = this.CreateHourglass();

                    LoadTransactionsGrid();

                    LoadAccountsList();
                }
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
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

            m_summaries = m_db.GetAccountSummaries();

            listViewAccounts.VirtualListSize = m_summaries.Count;
            listViewAccounts.Invalidate();
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
                summary = m_db.GetAccountSummary(summary.Account.AcctId);

                accountToolStripStatusLabel.Text = summary?.Account.AccountName;
                currentToolStripStatusLabel.Text = $"Current: {summary?.Balance:0.00}";
                availableToolStripStatusLabel.Text = $"Available: {summary?.AvailableBalance:0.00}";
                stagedToolStripStatusLabel.Text = $"Staged: {summary?.StagedBalance:0.00}";
                finalToolStripStatusLabel.Text = $"Final: {summary?.FinalBalance:0.00}";

                var viewTransactions = summary.Transactions
                    .Filter(m_dateFilter)
                    .Order(m_sortOrder)
                    .AsViewTransactions()
                    .ToList();

                SaveSelectedTransactions();

                dgvAccountTransactions.DataSource = viewTransactions;

                // Resize the columns.
                var widths = new int[] { 90, 70, 80, 80, 275 };
                int i = 0;
                dgvAccountTransactions.Columns["Date"].Width = widths[i++];
                dgvAccountTransactions.Columns["RefNum"].Width = widths[i++];
                dgvAccountTransactions.Columns["State"].Width = widths[i++];
                dgvAccountTransactions.Columns["Amount"].Width = widths[i++];
                dgvAccountTransactions.Columns["Memo"].Width = widths[i++];
                dgvAccountTransactions.Columns["Payee"].Width =
                    dgvAccountTransactions.Width - widths.Sum() - SystemInformation.VerticalScrollBarWidth - dgvAccountTransactions.Margin.Right;

                foreach (DataGridViewRow row in dgvAccountTransactions.Rows)
                {
                    var vt = viewTransactions[row.Index];

                    if (vt.State != MoneyBookDbContextExtension.StateTypes.Reconciled.ToString())
                    {
                        row.DefaultCellStyle.Font = new Font(dgvAccountTransactions.Font, FontStyle.Italic);
                    }

                    row.DefaultCellStyle.ForeColor = TransactionStateColorScheme.Instance.ForeColor(vt.State);

                    row.Cells["Amount"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                RestoreSelectedTransactions();
            }
        }

        private void UpdateTransactionStates(MoneyBookDbContextExtension.StateTypes state)
        {
            var transactions = dgvAccountTransactions.DataSource as List<ViewTransaction>;
            var selectedTransactions = dgvAccountTransactions.SelectedCells
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
                    m_db.SetTransactionStates(selectedTransactions, state);

                    LoadTransactionsGrid();

                    LoadAccountsList();
                }
            }
        }

        private void MakeTransactionRecurring()
        {
            var transactions = dgvAccountTransactions.DataSource as List<ViewTransaction>;
            var selectedTransaction = dgvAccountTransactions.SelectedCells
                .Cast<DataGridViewCell>()
                .GroupBy(x => x.RowIndex)
                .Select(g => transactions[g.Key])
                .FirstOrDefault();

            if (selectedTransaction != null)
            {
                var dlg = RecurringTransactionForm.Create(selectedTransaction);

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    LoadRecurringTransactionsGrid();
                }
            }
        }

        private void DeleteTransactions()
        {
            var transactions = dgvAccountTransactions.DataSource as List<ViewTransaction>;
            var selectedTransactions = dgvAccountTransactions.SelectedCells
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
                    m_db.DeleteTransactions(selectedTransactions);

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

                var dlg = TransactionForm.Create(summary.Account.AcctId);

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    LoadTransactionsGrid();

                    LoadAccountsList();
                }
            }
        }

        private void ShowEditTransactionDialog()
        {
            var transactions = dgvAccountTransactions.DataSource as List<ViewTransaction>;
            var selectedTransaction = dgvAccountTransactions.SelectedCells
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

        private void CalculateSum()
        {
            var transactions = dgvAccountTransactions.DataSource as List<ViewTransaction>;
            var selectedTransactions = dgvAccountTransactions.SelectedCells
                .Cast<DataGridViewCell>()
                .GroupBy(x => x.RowIndex)
                .Select(g => transactions[g.Key])
                .ToList();

            if (selectedTransactions.Count() > 1)
            {
                sumToolStripStatusLabel.Text = $"Sum: {selectedTransactions.Sum(x => x.Amount):0.00}";
            }
            else
            {
                sumToolStripStatusLabel.Text = String.Empty;
            }
        }
        #endregion

        #region Recurring Transactions

        private void SaveSelectedRecurringTransactions()
        {
            var transactions = dgvRecurringTransactions.DataSource as List<ViewRecurringTransaction>;
            m_selectedRecurringTransactions = dgvRecurringTransactions.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(dgvr => transactions[dgvr.Index])
                .ToList();
        }

        private void RestoreSelectedRecurringTransactions()
        {
            var transactions = dgvRecurringTransactions.DataSource as List<ViewRecurringTransaction>;
            for (int i = 0; i < dgvRecurringTransactions.Rows.Count; i++)
            {
                if (m_selectedRecurringTransactions.Find(x => x.RecTrnsId == transactions[i].RecTrnsId) != null)
                {
                    dgvRecurringTransactions.Rows[i].Selected = true;
                }
                else
                {
                    dgvRecurringTransactions.Rows[i].Selected = false;
                }
            }
        }

        private void LoadRecurringTransactionsGrid()
        {
            var recTrans = m_db.GetRecurringTransactions(MoneyBookDbContextExtension.SortOrder.Ascending)
                .AsViewRecurringTransactions()
                .ToList();

            var accts = m_db.GetAccounts()
                .ToList();

            foreach (var rt in recTrans)
            {
                var acct = m_db.GetAccounts().SingleOrDefault(x => x.AcctId == rt.AcctId);

                if (acct != null)
                {
                    rt.Account = acct.AccountName;
                }
            }

            SaveSelectedRecurringTransactions();

            dgvRecurringTransactions.DataSource = recTrans;

            // Resize the columns.
            var widths = new int[] { 90, 90, 275, 275, 80, 80 };
            int i = 0;
            dgvRecurringTransactions.Columns["DueDate"].Width = widths[i++];
            dgvRecurringTransactions.Columns["Account"].Width = widths[i++];
            dgvRecurringTransactions.Columns["Memo"].Width = widths[i++];
            dgvRecurringTransactions.Columns["Website"].Width = widths[i++];
            dgvRecurringTransactions.Columns["Amount"].Width = widths[i++];
            dgvRecurringTransactions.Columns["Frequency"].Width = widths[i++];
            dgvRecurringTransactions.Columns["Payee"].Width =
                dgvRecurringTransactions.Width - widths.Sum() - SystemInformation.VerticalScrollBarWidth - dgvRecurringTransactions.Margin.Right;

            foreach (DataGridViewRow row in dgvRecurringTransactions.Rows)
            {
                var rt = recTrans[row.Index];

                if (rt.Frequency == MoneyBookDbContextExtension.TransactionFrequency.Paused.ToString())
                {
                    row.DefaultCellStyle.ForeColor = RecurringTransactionsFrequencyColorScheme.Instance.ForeColor(rt.Frequency.ToString());
                }
                else
                {
                    if (rt.DueState != ViewRecurringTransaction.DueStateTypes.None)
                    {
                        row.DefaultCellStyle.Font = new Font(dgvAccountTransactions.Font, FontStyle.Italic);
                    }

                    row.DefaultCellStyle.ForeColor = RecurringTransactionStateColorScheme.Instance.ForeColor(rt.DueState.ToString());
                }

                row.Cells["Amount"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            RestoreSelectedRecurringTransactions();
        }

        private void StageRecurringTransactions()
        {
            var recTrans = dgvRecurringTransactions.DataSource as List<ViewRecurringTransaction>;
            var selectedRecTrans = dgvRecurringTransactions.SelectedCells
                .Cast<DataGridViewCell>()
                .GroupBy(x => x.RowIndex)
                .Select(g => recTrans[g.Key])
                .ToList();

            if (selectedRecTrans.Count() > 0)
            {
                var answer = MessageBox.Show(this,
                    $"Are you sure you want to stage these {selectedRecTrans.Count()} recurring transactions?",
                    this.Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (answer == DialogResult.Yes)
                {
                    m_db.StageRecurringTransactions(selectedRecTrans);

                    LoadRecurringTransactionsGrid();

                    LoadTransactionsGrid();
                }
            }
        }

        private void SkipRecurringTransactions()
        {
            var recTrans = dgvRecurringTransactions.DataSource as List<ViewRecurringTransaction>;
            var selectedRecTrans = dgvRecurringTransactions.SelectedCells
                .Cast<DataGridViewCell>()
                .GroupBy(x => x.RowIndex)
                .Select(g => recTrans[g.Key])
                .ToList();

            if (selectedRecTrans.Count() > 0)
            {
                var answer = MessageBox.Show(this,
                    $"Are you sure you want to skip these {selectedRecTrans.Count()} recurring transactions?",
                    this.Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (answer == DialogResult.Yes)
                {
                    m_db.SkipRecurringTransactions(selectedRecTrans);

                    LoadRecurringTransactionsGrid();
                }
            }
        }

        private void CopyRecurringTransactions()
        {
            var recTrans = dgvRecurringTransactions.DataSource as List<ViewRecurringTransaction>;
            var selectedRecTrans = dgvRecurringTransactions.SelectedCells
                .Cast<DataGridViewCell>()
                .GroupBy(x => x.RowIndex)
                .Select(g => recTrans[g.Key])
                .ToList();

            if (selectedRecTrans.Count() > 0)
            {
                var answer = MessageBox.Show(this,
                    $"Are you sure you want to copy these {selectedRecTrans.Count()} recurring transactions?",
                    this.Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (answer == DialogResult.Yes)
                {
                    m_db.CopyRecurringTransactions(selectedRecTrans);

                    LoadRecurringTransactionsGrid();

                    LoadTransactionsGrid();

                    LoadAccountsList();
                }
            }
        }

        private void OpenWebsite()
        {
            var recTrans = dgvRecurringTransactions.DataSource as List<ViewRecurringTransaction>;
            var selectedRecTrans = dgvRecurringTransactions.SelectedCells
                .Cast<DataGridViewCell>()
                .GroupBy(x => x.RowIndex)
                .Select(g => recTrans[g.Key])
                .FirstOrDefault();

            if (selectedRecTrans != null && !String.IsNullOrEmpty(selectedRecTrans.Website))
            {
                Process.Start(new ProcessStartInfo(selectedRecTrans.Website) { UseShellExecute = true });
            }
        }

        private void DeleteRecurringTransactions()
        {
            var recTrans = dgvRecurringTransactions.DataSource as List<ViewRecurringTransaction>;
            var selectedRecTrans = dgvRecurringTransactions.SelectedCells
                .Cast<DataGridViewCell>()
                .GroupBy(x => x.RowIndex)
                .Select(g => recTrans[g.Key])
                .ToList();

            if (selectedRecTrans.Count() > 0)
            {
                var answer = MessageBox.Show(this,
                    $"Are you sure you want to delete these {selectedRecTrans.Count()} recurring transactions?",
                    this.Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (answer == DialogResult.Yes)
                {
                    m_db.DeleteRecurringTransactions(selectedRecTrans);

                    LoadRecurringTransactionsGrid();
                }
            }
        }

        private void ShowAddRecTransactionDialog()
        {
            var dlg = RecurringTransactionForm.Create();

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                LoadRecurringTransactionsGrid();
            }
        }

        private void ShowEditRecTransactionDialog()
        {
            var recTrans = dgvRecurringTransactions.DataSource as List<ViewRecurringTransaction>;
            var selectedRecTrans = dgvRecurringTransactions.SelectedCells
                .Cast<DataGridViewCell>()
                .Select(x => new
                {
                    RowIndex = x.RowIndex,
                    Transaction = recTrans[x.RowIndex]
                })
                .FirstOrDefault();

            if (selectedRecTrans != null)
            {
                var dlg = RecurringTransactionForm.Create(selectedRecTrans.Transaction);

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    LoadRecurringTransactionsGrid();
                }
            }
        }

        #endregion

        #region Database Operations

        private void BackupDatabase()
        {
            var sfd = new SaveFileDialog()
            {
                InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString(),
                FileName = $"MoneyTools-{DateTime.Now.ToString("yyyy-MMdd-HHmmss")}.json",
                Filter = "Data Files|*.json;*.json|All Files|*.*",
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                m_db.BackupDatabase(sfd.FileName);

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
                    m_db.RestoreDatabase(ofd.FileName);

                    MessageBox.Show(this, "Restore complete.", this.Text, MessageBoxButtons.OK);
                }
            }
        }

        #endregion
    }
}
