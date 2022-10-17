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

            treeView1.ShowRootLines = true;
            treeView1.HideSelection = false;
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
                treeView1.Nodes.Add("Loading");

                using var hg = this.CreateHourglass();

                await Task.Run(() =>
                {
                    m_db = MoneyBookDbContext.Create(MoneyBookToolsDbContextConfig.Instance);
                });

                var accounts = await GetAccounts();
                LoadAccountTree(accounts);

                var recTrans = await GetRecurringTransactions();
                LoadRecurringTransactionsGrid(recTrans);

                treeView1.SelectedNode = treeView1.TopNode.FirstNode;

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

        private async void refreshToolStripMenuItem_Click(object sender, EventArgs e)
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

        private async void AccountCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using var hg = this.CreateHourglass();

                LoadTransactionsGrid();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                using var hg = this.CreateHourglass();

                LoadTransactionsGrid();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
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

        private async void linkImportTransactions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

                        await Task.Run(() =>
                        {
                            using var tr = m_db.Database.BeginTransaction();

                            foreach (var ad in accountDataArr)
                            {
                                m_db.ImportTransactions(ad.ImportFilePath, ad.Name);
                            }

                            tr.Commit();
                        });

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

        private async void linkDeleteAllTransactions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var answer = MessageBox.Show(this,
                    $"Are you sure you delete transactions across all accounts?  NOTE: This cannot be undone.",
                    this.Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (answer == DialogResult.Yes)
                {
                    await Task.Run(() =>
                    {
                        using var tr = m_db.Database.BeginTransaction();

                        m_db.DeleteAllTransactions();

                        tr.Commit();
                    });

                    MessageBox.Show(this, "Delete complete.", this.Text, MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private async void linkImportRepeatingTransactions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

                        await Task.Run(() =>
                        {
                            using var tr = m_db.Database.BeginTransaction();

                            m_db.ImportRecurringTransactions(repeatingTransactions);

                            tr.Commit();
                        });

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

        private async void linkDeleteRepeatingTransactions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var answer = MessageBox.Show(this,
                    $"Are you sure you delete recurring transactions across all accounts?  NOTE: This cannot be undone.",
                    this.Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (answer == DialogResult.Yes)
                {
                    await Task.Run(() =>
                    {
                        using var tr = m_db.Database.BeginTransaction();

                        m_db.DeleteAllRecurringTransactions();

                        tr.Commit();
                    });

                    MessageBox.Show(this, "Delete complete.", this.Text, MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private async void linkUpdateStartingBalances_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var accountDataArr = AppSettings.Instance.Accounts.ToArray();

                if (accountDataArr.Length > 0)
                {
                    var answer = MessageBox.Show(this,
                        $"Are you sure you want update the starting balances of these accounts?" +
                        Environment.NewLine +
                        Environment.NewLine +
                        String.Join(Environment.NewLine, accountDataArr.Select(x => $"{x.Name} --> {x.StartingBalance}")),
                        this.Text,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (answer == DialogResult.Yes)
                    {
                        await Task.Run(() =>
                        {
                            using var tr = m_db.Database.BeginTransaction();

                            foreach (var ad in accountDataArr)
                            {
                                m_db.UpdateStartingBalance(ad.Name, ad.StartingBalance);
                            }

                            tr.Commit();
                        });

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

        private async void linkResetStartingBalances_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var answer = MessageBox.Show(this,
                    $"Are you sure you reset the starting balances of all accounts?",
                    this.Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (answer == DialogResult.Yes)
                {
                    await Task.Run(() =>
                    {
                        using var tr = m_db.Database.BeginTransaction();

                        m_db.ResetStartingBalances();

                        tr.Commit();
                    });

                    MessageBox.Show(this, "Reset complete.", this.Text, MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private async Task<List<ViewAccount>> GetAccounts()
        {
            var task = await m_db.GetAccountsAsync();
            return task.AsViewAccounts().ToList();
        }

        private async Task<List<ViewRecurringTransaction>> GetRecurringTransactions()
        {
            var task = await m_db.GetRecurringTransactionsAsync(MoneyBookDbContextExtension.SortOrder.Ascending);
            return task.AsViewRecurringTransactions().ToList();
        }

        private void LoadAccountTree(IList<ViewAccount> accounts)
        {
            treeView1.Nodes.Clear();

            treeView1.Nodes.Add("Accounts");

            foreach (var acct in accounts)
            {
                var node = new TreeNode(acct.Account)
                {
                    Tag = acct
                };
                treeView1.TopNode.Nodes.Add(node);
            }

            treeView1.ExpandAll();
        }

        private async void LoadTransactionsGrid()
        {
            if (treeView1.SelectedNode != null &&
                treeView1.SelectedNode.Level > 0 &&
                comboFilter.SelectedIndex > -1 && 
                comboDateOrder.SelectedIndex > -1)
            {
                var acct = treeView1.SelectedNode.Tag as ViewAccount;

                labelAvailableBalance.Text = $"Available: {acct?.AvailableBalance}";

                var dateFilter = (MoneyBookDbContextExtension.DateFilter)comboFilter.SelectedIndex;
                var sortOrder = (MoneyBookDbContextExtension.SortOrder)comboDateOrder.SelectedIndex;
                var transactions = await m_db.GetTransactionsAsync(acct.AcctId, dateFilter, sortOrder);

                dgvAccountTransactions.DataSource = transactions.AsViewTransactions().ToList();

                // Resize the columns.
                var widths = new int[] { 70, 70, 50, 80, 275 };
                int i = 0;
                dgvAccountTransactions.Columns["Date"].Width = widths[i++];
                dgvAccountTransactions.Columns["RefNum"].Width = widths[i++];
                dgvAccountTransactions.Columns["State"].Width = widths[i++];
                dgvAccountTransactions.Columns["Amount"].Width = widths[i++];
                dgvAccountTransactions.Columns["Memo"].Width = widths[i++];
                dgvAccountTransactions.Columns["Payee"].Width = 
                    dgvAccountTransactions.Width - widths.Sum() - SystemInformation.VerticalScrollBarWidth - dgvAccountTransactions.Margin.Right;
            }
        }

        private async void LoadRecurringTransactionsGrid(IList<ViewRecurringTransaction> recTrans)
        {
            dgvRecurringTransactions.DataSource = recTrans;

            // Resize the columns.
            var widths = new int[] { 70, 275, 80, 80 };
            int i = 0;
            dgvRecurringTransactions.Columns["DueDate"].Width = widths[i++];
            dgvRecurringTransactions.Columns["Memo"].Width = widths[i++];
            dgvRecurringTransactions.Columns["Amount"].Width = widths[i++];
            dgvRecurringTransactions.Columns["Frequency"].Width = widths[i++];
            dgvRecurringTransactions.Columns["Payee"].Width =
                dgvRecurringTransactions.Width - widths.Sum() - SystemInformation.VerticalScrollBarWidth - dgvRecurringTransactions.Margin.Right;

            foreach (DataGridViewRow row in dgvRecurringTransactions.Rows)
            {
                var rt = recTrans[row.Index];

                if (rt.Overdue)
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }
    }
}
