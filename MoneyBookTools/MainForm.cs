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

            dgvAccounts.SetDataGridViewStyle();
            dgvAccountTransactions.SetDataGridViewStyle();
            dgvRecurringTransactions.SetDataGridViewStyle();
            dgvFileTransactions.SetDataGridViewStyle();

            comboAccounts.MouseWheel += Combo_MouseWheel;
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

            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
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
                await Task.Run(() =>
                {
                    m_db = MoneyBookDbContext.Create(MoneyBookToolsDbContextConfig.Instance);
                });

                refreshToolStripMenuItem.PerformClick();
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

        private void buttonOpen_Click(object sender, EventArgs e)
        {
        }

        private async void buttonImport_Click(object sender, EventArgs e)
        {
        }

        private async void buttonUpdateStartBalances_Click(object sender, EventArgs e)
        {
        }

        private async void buttonReset_Click(object sender, EventArgs e)
        {
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
        }

        private async void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabLedger)
                {
                    using var hg = this.CreateHourglass();

                    if (comboAccounts.DataSource == null)
                    {
                        var accounts = await m_db.GetAccountsAsync();

                        // NOTE: This will trigger comboAccounts_SelectedIndexChanged().
                        comboAccounts.DisplayMember = "Account";
                        comboAccounts.DataSource = accounts.AsViewAccounts().ToList();
                    }
                    else
                    {
                        LoadTransactions();
                    }
                }
                else if (tabControl1.SelectedTab == tabAccounts)
                {
                    using var hg = this.CreateHourglass();

                    var accounts = await m_db.GetAccountsAsync();

                    dgvAccounts.DataSource = accounts.AsViewAccounts().ToList();
                    dgvAccounts.ResizeAllCells();
                }
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private async void AccountsTabCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadTransactions();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private async void TabControl1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabLedger)
            {
                if (comboAccounts.DataSource == null)
                {
                    refreshToolStripMenuItem.PerformClick();
                }
            }
        }

        private async void LoadTransactions()
        {
            if (comboAccounts.SelectedItem != null && comboFilter.SelectedIndex > -1 && comboDateOrder.SelectedIndex > -1)
            {
                using var hg = this.CreateHourglass();

                var acct = comboAccounts.SelectedItem as ViewAccount;

                labelAvailableBalance.Text = $"Available: {acct?.AvailableBalance}";

                var dateFilter = (MoneyBookDbContextExtension.DateFilter)comboFilter.SelectedIndex;
                var sortOrder = (MoneyBookDbContextExtension.SortOrder)comboDateOrder.SelectedIndex;
                var transactions = await m_db.GetTransactionsAsync(acct.AcctId, dateFilter, sortOrder);

                dgvAccountTransactions.DataSource = transactions.AsViewTransactions().ToList();
                dgvAccountTransactions.ResizeAllCells();

                var results = await m_db.GetRecurringTransactionsAsync(acct.AcctId, dateFilter, sortOrder);
                var recTransactions = results.AsViewRecurringTransactions().ToList();

                dgvRecurringTransactions.DataSource = recTransactions;
                dgvRecurringTransactions.ResizeAllCells();

                foreach (DataGridViewRow row in dgvRecurringTransactions.Rows)
                {
                    var rt = recTransactions[row.Index];

                    if (rt.Overdue)
                    {
                        row.DefaultCellStyle.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void linkOpenFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using var hg = this.CreateHourglass();

            try
            {
                var ofd = new OpenFileDialog()
                {
                    InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString(),
                    Filter = "OFX/QFX Files|*.ofx;*.qfx|All Files|*.*",
                };

                if (ofd.ShowDialog() == DialogResult.OK)
                {
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
            using var hg = this.CreateHourglass();

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
            using var hg = this.CreateHourglass();

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
    }
}
