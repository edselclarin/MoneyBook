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
            dgvStagedTransactions.SetDataGridViewStyle();
            dgvFileTransactions.SetDataGridViewStyle();

            comboAccounts.MouseWheel += Combo_MouseWheel;
            comboFilter.MouseWheel += Combo_MouseWheel;

            comboFilter.DataSource = new string[]
            {
                "Two Weeks",
                "This Month",
                "This Year"
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

                    dgvFileTransactions.ResizeAllCells(context.Transactions);

                    buttonImport.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private async void buttonImport_Click(object sender, EventArgs e)
        {
            using var hg = this.CreateHourglass();

            try
            {
                var files = AppSettings.Instance.Imports.ToArray();

                if (files.Length > 0)
                {
                    var answer = MessageBox.Show(this,
                        $"Are you sure you want to import the transactions from these files into these accounts?" +
                        Environment.NewLine +
                        Environment.NewLine +
                        String.Join(Environment.NewLine, files.Select(x => $"{x.Path} --> {x.Account}")),
                        this.Text,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (answer == DialogResult.Yes)
                    {
                        await Task.Run(() =>
                        {
                            using var db = MoneyBookDbContext.Create(MoneyBookToolsDbContextConfig.Instance);
                            using var tr = db.Database.BeginTransaction();

                            foreach (var file in files)
                            {
                                db.ImportTransactions(file.Path, file.Account);
                            }

                            db.UpdateAccountDetails();

                            tr.Commit();
                        });

                        MessageBox.Show(this, "Import complete.", this.Text, MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show(this, "No files to import.  Check imports in appSettings.json.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
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
                if (tabControl1.SelectedTab == tabLedger)
                {
                    using var hg = this.CreateHourglass();

                    var accounts = await m_db.GetAccountsAsync();

                    // NOTE: This will trigger comboAccounts_SelectedIndexChanged().
                    comboAccounts.DisplayMember = "Account";
                    comboAccounts.DataSource = accounts.AsViewAccounts().ToList();
                }
                else if (tabControl1.SelectedTab == tabAccounts)
                {
                    using var hg = this.CreateHourglass();

                    var accounts = await m_db.GetAccountsAsync();

                    dgvAccounts.ResizeAllCells(accounts.AsViewAccounts().ToList());
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
                if (comboAccounts.SelectedItem != null && comboFilter.SelectedIndex > -1)
                {
                    using var hg = this.CreateHourglass();

                    var acct = comboAccounts.SelectedItem as ViewAccount;

                    labelAvailableBalance.Text = $"Available: {acct?.AvailableBalance}";

                    var dateFilter = (MoneyBookDbContextExtension.DateFilter)comboFilter.SelectedIndex;
                    var transactions = await m_db.GetTransactionsAsync(acct.AcctId, dateFilter);

                    dgvAccountTransactions.ResizeAllCells(transactions.AsViewTransactions().ToList());
                }
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
    }
}
