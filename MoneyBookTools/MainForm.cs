using MoneyBook.BusinessModels;
using MoneyBook.Data;
using MoneyBookTools.Data;
using MoneyBookTools.ViewModels;
using Ofx;

namespace MoneyBookTools
{
    public partial class MainForm : Form
    {
        private MoneyBookDbContext m_db;

        public MainForm()
        {
            InitializeComponent();

            dgvAccountTransactions.SetDataGridViewStyle();
            dgvRecurringTransactions.SetDataGridViewStyle();
            dgvFileTransactions.SetDataGridViewStyle();

            comboFilter.Enabled =
            comboDateOrder.Enabled = false;

            comboFilter.MouseWheel += Combo_MouseWheel;
            comboDateOrder.MouseWheel += Combo_MouseWheel;

            comboFilter.DataSource = new string[]
            {
                "Two Weeks",
                "This Month",
                "This Year"
            };

            comboDateOrder.DataSource = new string[]
            {
                "Newest to Oldest",
                "Oldest to Newest"
            };

            listView1.Dock = DockStyle.Fill;
            listView1.HeaderStyle = ColumnHeaderStyle.None;
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Scrollable = false;
            listView1.Resize += ListView1_Resize;

            var colWidths = new int[] { 100, 80 };
            foreach (int width in colWidths)
            {
                listView1.Columns.Add(String.Empty, width);
            }
            listView1.Columns[1].TextAlign = HorizontalAlignment.Right;
        }

        private void ListView1_Resize(object? sender, EventArgs e)
        {
            if (listView1.Columns.Count == 2)
            {
                listView1.Columns[0].Width = listView1.Width - listView1.Margin.Right - listView1.Columns[1].Width;
            }
        }

        private void Combo_MouseWheel(object? sender, MouseEventArgs e)
        {
            // Disable scrolling the combobox with the mouse wheel.
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                listView1.Items.Add("Loading...");

                using var hg = this.CreateHourglass();

                await Task.Run(() =>
                {
                    m_db = MoneyBookDbContext.Create(MoneyBookToolsDbContextConfig.Instance);
                });

                LoadRecurringTransactionsGrid();

                LoadAccountsList();

                if (listView1.Items.Count > 0)
                {
                    listView1.Items[0].Selected = true;
                }

                comboFilter.Enabled =
                comboDateOrder.Enabled = true;
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

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
                if (tabControl1.SelectedTab == tabOutlook)
                {
                    using var hg = this.CreateHourglass();

                    LoadTransactionsGrid();
                }
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void AccountCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshToolStripMenuItem.PerformClick();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshToolStripMenuItem.PerformClick();
        }

        private void linkOpenFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var ofd = new OpenFileDialog()
                {
                    InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString(),
                    Filter = "OFX/QFX Files|*.ofx;*.qfx|All Files|*.*",
                };

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using var hg = this.CreateHourglass();

                    var context = new OfxContext();
                    context.FromFile(ofd.FileName);

                    dgvFileTransactions.DataSource = context.Transactions;
                    dgvFileTransactions.ResizeAllCells();
                }
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void linkImportTransactions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var accountDataArr = AppSettings.Instance.Accounts.ToArray();

                if (accountDataArr.Length > 0)
                {
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

                        using var tr = m_db.Database.BeginTransaction();

                        foreach (var ad in accountDataArr)
                        {
                            m_db.ImportTransactions(ad.ImportFilePath, ad.Name);
                        }

                        tr.Commit();

                        MessageBox.Show(this, "Import complete.", this.Text, MessageBoxButtons.OK);
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

        private void linkDeleteAllTransactions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

                    using var tr = m_db.Database.BeginTransaction();

                    m_db.DeleteAllTransactions();

                    tr.Commit();

                    MessageBox.Show(this, "Delete complete.", this.Text, MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void linkImportRepeatingTransactions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var repeatingTransactions = AppSettings.Instance.RepeatingTransactions;

                if (repeatingTransactions.Count > 0)
                {
                    var answer = MessageBox.Show(this,
                        $"Are you sure you want to import repeating transactions?",
                        this.Text,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (answer == DialogResult.Yes)
                    {
                        using var hg = this.CreateHourglass();

                        using var tr = m_db.Database.BeginTransaction();

                        m_db.ImportRecurringTransactions(repeatingTransactions);

                        tr.Commit();

                        MessageBox.Show(this, "Import complete.", this.Text, MessageBoxButtons.OK);
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

        private void linkDeleteRepeatingTransactions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

                    using var tr = m_db.Database.BeginTransaction();

                    m_db.DeleteAllRecurringTransactions();

                    tr.Commit();

                    MessageBox.Show(this, "Delete complete.", this.Text, MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void linkUpdateAccountData_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

                        using var tr = m_db.Database.BeginTransaction();

                        m_db.UpdateAccountData(accountDataArr);

                        tr.Commit();

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

        private void linkResetAccountData_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

                    using var tr = m_db.Database.BeginTransaction();

                    m_db.ResetAccountData();

                    tr.Commit();

                    MessageBox.Show(this, "Reset complete.", this.Text, MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            e.Cancel = true;
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

                editTransToolStripMenuItem.Enabled = count == 1;
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

                ShowTransactionDialog();
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
                var dlg = new StateForm()
                {
                    StartPosition = FormStartPosition.CenterScreen
                };

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
            skipRecTransToolStripMenuItem.Enabled = count > 0;

            editRecTransToolStripMenuItem.Enabled = 
            copyRecTransToolStripMenuItem.Enabled = count == 1;
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

        private void dgvRecurringTransactions_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                using var hg = this.CreateHourglass();

                ShowRecTransactionDialog();
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

                ShowRecTransactionDialog();
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

                ShowTransactionDialog();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void transactionForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            try
            {
                var form = sender as TransactionForm;
                if (form.DialogResult == DialogResult.OK)
                {
                    using var hg = this.CreateHourglass();

                    LoadTransactionsGrid();
                }
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

        private void linkBackupDatabase_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void linkRestoreDatabase_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void LoadAccountsList()
        {
            listView1.Items.Clear();

            var summaries = m_db.GetAccountSummaries();

            foreach (var summary in summaries)
            {
                var item = listView1.Items.Add(summary.Account.AccountName);
                item.Tag = summary;
                item.SubItems.Add(summary.AvailableBalance.ToString());
            }
        }

        private void LoadTransactionsGrid()
        {
            if (listView1.SelectedItems.Count > 0 &&
                comboFilter.SelectedIndex > -1 && 
                comboDateOrder.SelectedIndex > -1)
            {
                var summary = listView1.SelectedItems[0].Tag as AccountSummary;
                summary = m_db.GetAccountSummary(summary.Account.AcctId);

                labelAvailableBalance.Text = $"Available: {summary?.AvailableBalance:0.00}";
                labelPendingBalance.Text = $"Pending: {summary?.PendingBalance:0.00}";
                labelActualBalance.Text = $"Actual: {summary?.Balance:0.00}";

                var dateFilter = (MoneyBookDbContextExtension.DateFilter)comboFilter.SelectedIndex;
                var sortOrder = (MoneyBookDbContextExtension.SortOrder)comboDateOrder.SelectedIndex;
                var viewTransactions = summary.Transactions
                    .Filter(dateFilter)
                    .Order(sortOrder)
                    .AsViewTransactions()
                    .ToList();

                dgvAccountTransactions.DataSource = viewTransactions;

                // Resize the columns.
                var widths = new int[] { 70, 70, 80, 80, 275 };
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

                    if (vt.State == MoneyBookDbContextExtension.StateTypes.Uncleared.ToString())
                    {
                        row.DefaultCellStyle.Font = new Font(dgvAccountTransactions.Font, FontStyle.Italic);

                        row.DefaultCellStyle.ForeColor = Color.DarkGoldenrod;
                    }
                    else if (vt.State == MoneyBookDbContextExtension.StateTypes.Pending.ToString())
                    {
                        row.DefaultCellStyle.Font = new Font(dgvAccountTransactions.Font, FontStyle.Italic);

                        row.DefaultCellStyle.ForeColor = Color.DarkOrchid;
                    }
                    else if (vt.State == MoneyBookDbContextExtension.StateTypes.Staged.ToString())
                    {
                        row.DefaultCellStyle.Font = new Font(dgvAccountTransactions.Font, FontStyle.Italic);

                        row.DefaultCellStyle.ForeColor = Color.DodgerBlue;
                    }
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

            dgvRecurringTransactions.DataSource = recTrans;

            // Resize the columns.
            var widths = new int[] { 70, 70, 275, 80, 80 };
            int i = 0;
            dgvRecurringTransactions.Columns["DueDate"].Width = widths[i++];
            dgvRecurringTransactions.Columns["Account"].Width = widths[i++];
            dgvRecurringTransactions.Columns["Memo"].Width = widths[i++];
            dgvRecurringTransactions.Columns["Amount"].Width = widths[i++];
            dgvRecurringTransactions.Columns["Frequency"].Width = widths[i++];
            dgvRecurringTransactions.Columns["Payee"].Width =
                dgvRecurringTransactions.Width - widths.Sum() - SystemInformation.VerticalScrollBarWidth - dgvRecurringTransactions.Margin.Right;

            foreach (DataGridViewRow row in dgvRecurringTransactions.Rows)
            {
                var rt = recTrans[row.Index];

                if (rt.IsOverdue || rt.IsDueToday)
                {
                    row.DefaultCellStyle.Font = new Font(dgvAccountTransactions.Font, FontStyle.Italic);

                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
                else if (rt.IsDueSoon)
                {
                    row.DefaultCellStyle.Font = new Font(dgvAccountTransactions.Font, FontStyle.Italic);

                    row.DefaultCellStyle.ForeColor = Color.DarkGoldenrod;
                }
            }
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
                    using var tr = m_db.Database.BeginTransaction();

                    m_db.StageRecurringTransactions(selectedRecTrans);

                    tr.Commit();

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
                    using var tr = m_db.Database.BeginTransaction();

                    m_db.SkipRecurringTransactions(selectedRecTrans);

                    tr.Commit();

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
                    using var tr = m_db.Database.BeginTransaction();

                    m_db.CopyRecurringTransactions(selectedRecTrans);

                    tr.Commit();

                    LoadRecurringTransactionsGrid();

                    LoadTransactionsGrid();
                }
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
                    using var tr = m_db.Database.BeginTransaction();

                    m_db.SetTransactionStates(selectedTransactions, state);

                    tr.Commit();

                    LoadTransactionsGrid();
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
                    using var tr = m_db.Database.BeginTransaction();
                    
                    m_db.DeleteTransactions(selectedTransactions);

                    tr.Commit();

                    LoadTransactionsGrid();
                }
            }
        }

        private void ShowTransactionDialog()
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
                var dlg = new TransactionForm()
                {
                    StartPosition = FormStartPosition.CenterScreen,
                    Transaction = selectedTransaction.Transaction
                };

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    dlg.ShowDialog(this);
                }
            }
        }

        private void ShowRecTransactionDialog()
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
                var dlg = new RecurringTransactionForm()
                {
                    StartPosition = FormStartPosition.CenterScreen,
                    RecurringTransaction = selectedRecTrans.Transaction
                };

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    LoadRecurringTransactionsGrid();
                }
            }
        }

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
    }
}
