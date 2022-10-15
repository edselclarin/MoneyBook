using MoneyBook.BusinessModels;
using MoneyBook.Data;
using MoneyBookTools.Data;
using Ofx;

namespace MoneyBookTools
{
    public partial class MainForm : Form
    {
        private MoneyBookDbContext m_db;

        public MainForm()
        {
            InitializeComponent();

            dgvAccounts.ReadOnly = true;
            dgvLedger.ReadOnly = true;
            dgvFileTransactions.ReadOnly = true;

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

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                m_db = MoneyBookDbContext.Create(MoneyBookToolsDbContextConfig.Instance);

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

                    dgvFileTransactions.DataSource = context.Transactions;
                    foreach (DataGridViewColumn col in dgvFileTransactions.Columns)
                    {
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }

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
            using var hg = this.CreateHourglass();

            try
            {
                if (tabControl1.SelectedTab == tabLedger)
                {
                    LoadAccounts();
                }
                else if (tabControl1.SelectedTab == tabAccounts)
                {
                    LoadAccountDetails();
                }
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void comboAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            using var hg = this.CreateHourglass();

            try
            {
                LoadTransactions();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void comboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            using var hg = this.CreateHourglass();

            try
            {
                LoadTransactions();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void Combo_MouseWheel(object? sender, MouseEventArgs e)
        {
            // Disable scrolling the combobox with the mouse wheel.
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private async void TabControl1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            using var hg = this.CreateHourglass();
            
            if (tabControl1.SelectedTab == tabLedger)
            {
                if (comboAccounts.DataSource == null)
                {
                    LoadAccounts();
                }
            }
        }

        private async void LoadAccounts()
        {
            var accounts = await m_db.GetAccountsAsync();

            // NOTE: This will trigger comboAccounts_SelectedIndexChanged().
            comboAccounts.DisplayMember = "AccountName";
            comboAccounts.DataSource = accounts.ToList();
        }

        private async void LoadAccountDetails()
        {
            var accounts = await m_db.GetAccountsAsync();

            dgvAccounts.DataSource = accounts.ToList();
            foreach (DataGridViewColumn col in dgvAccounts.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private async void LoadTransactions()
        {
            if (comboAccounts.SelectedItem != null && comboFilter.SelectedIndex > -1)
            {
                var acct = comboAccounts.SelectedItem as AccountInfo;
                var dateFilter = (MoneyBookDbContextExtension.DateFilter)comboFilter.SelectedIndex;

                var transactions = await m_db.GetTransactionsAsync(acct.AcctId, dateFilter);

                dgvLedger.DataSource = transactions.ToList();
                dgvLedger.RowHeadersDefaultCellStyle.BackColor = Color.LightBlue;
                foreach (DataGridViewColumn col in dgvLedger.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

                labelAvailableBalance.Text = $"Available: {acct?.AvailableBalance}";
            }
        }
    }
}
