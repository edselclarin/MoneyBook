using MoneyBook.Data;
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
            dgvTransactions.ReadOnly = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                m_db = new MoneyBookDbContext();

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

                    dgvTransactions.DataSource = context.Transactions;
                    foreach (DataGridViewColumn col in dgvTransactions.Columns)
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
                if (tabControl1.SelectedTab == tabOverview)
                {
                    dgvOverview.DataSource = null;

                    var summaries = await Task.Run(() =>
                    {
                        return GetAccountSummaries();
                    });

                    dgvOverview.RowHeadersVisible = false;
                    dgvOverview.DataSource = summaries.ToList();
                    foreach (DataGridViewColumn col in dgvOverview.Columns)
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

        private List<AccountSummary> GetAccountSummaries()
        {
            var summaries = new List<AccountSummary>();

            var details = m_db.GetAccountDetails();

            foreach (var detail in details)
            {
                var summary = new AccountSummary()
                {
                    AccountName = detail.Account.Name,
                    AvailableBalance = detail.AvailableBalance
                };

                summaries.Add(summary);
            }

            return summaries;
        }
    }
}
