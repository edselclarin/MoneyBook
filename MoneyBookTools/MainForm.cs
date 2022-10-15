using MoneyBook.BusinessModels;
using MoneyBook.Data;
using MoneyBookTools.Data;
using MoneyBookTools.ViewModels;
using Ofx;

namespace MoneyBookTools
{
    public partial class MainForm : Form
    {
        private MoneyBookDbContext m_db = null;
        private string[] m_filtersNames = new string[]
        {
            "Two Weeks",
            "This Month",
            "This Year"
        };

        public MainForm()
        {
            InitializeComponent();

            dgvAccounts.ReadOnly = true;
            dgvLedger.ReadOnly = true;
            dgvFileTransactions.ReadOnly = true;

            comboAccounts.MouseWheel += Combo_MouseWheel;

            comboFilter.MouseWheel += Combo_MouseWheel;
            comboFilter.DataSource = m_filtersNames;

            tabAccounts.Enter += TabAccounts_Enter;
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
            Cursor = Cursors.WaitCursor;

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

            Cursor = Cursors.Default;
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                var dlg = new FileImportDlg()
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                dlg.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }

            Cursor = Cursors.Default;
        }

        private async void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                if (tabControl1.SelectedTab == tabLedger)
                {
                    var accounts = await m_db.GetAccountsAsync();

                    comboAccounts.DisplayMember = "AccountName";
                    comboAccounts.DataSource = accounts.ToList();
                }
                else if (tabControl1.SelectedTab == tabAccounts)
                {
                    var accounts = await m_db.GetAccountsAsync();

                    dgvAccounts.DataSource = accounts.ToList();
                    foreach (DataGridViewColumn col in dgvAccounts.Columns)
                    {
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }

            Cursor = Cursors.Default;
        }

        private void comboAccounts_SelectedIndexChanged(object sender, EventArgs e)
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

        private void comboFilter_SelectedIndexChanged(object sender, EventArgs e)
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

        private void Combo_MouseWheel(object? sender, MouseEventArgs e)
        {
            // Disable scrolling the combobox with the mouse wheel.
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private async void TabAccounts_Enter(object? sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabAccounts && dgvAccounts.DataSource == null)
            {
                var accounts = await m_db.GetAccountsAsync();

                dgvAccounts.DataSource = accounts.ToList();
                foreach (DataGridViewColumn col in dgvAccounts.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
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
