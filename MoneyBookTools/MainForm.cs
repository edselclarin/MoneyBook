using MoneyBook.Data;
using MoneyBookTools.Data;
using MoneyBookTools.ViewModels;
using Ofx;

namespace MoneyBookTools
{
    public partial class MainForm : Form
    {
        private MoneyBookDbContext m_db = null;

        public MainForm()
        {
            InitializeComponent();

            dgvOverview.ReadOnly = true;
            dgvFileTransactions.ReadOnly = true;
            dgvAccountTransactions.ReadOnly = true;

            comboAccounts.MouseWheel += ComboAccounts_MouseWheel;
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
                if (tabControl1.SelectedTab == tabAccounts)
                {
                    var accounts = m_db.AccountDetails
                        .Join(m_db.Accounts, ad => ad.AcctId, a => a.AcctId, (ad, a) => new AccountSummary()
                        {
                            AccountName = a.Name,
                            AvailableBalance = ad.AvailableBalance,
                        })
                        .ToList();

                    comboAccounts.DisplayMember = "AccountName";
                    comboAccounts.DataSource = accounts;
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
                var acct = comboAccounts.SelectedItem as AccountSummary;

                labelAvailableBalance.Text = $"{acct?.AvailableBalance}";

                LoadTransactions();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void ComboAccounts_MouseWheel(object? sender, MouseEventArgs e)
        {
            // Disable scrolling the combobox with the mouse wheel.
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void LoadTransactions()
        {
        }
    }
}
