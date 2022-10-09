using MoneyBook.Data;
using MoneyBookTools.ViewModels;
using Ofx;
using System.Configuration;
using System.IO;

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
                var files = AppSettings.Instance.Imports.ToArray();

                if (files.Count() > 0)
                {
                    var answer = MessageBox.Show(this,
                        $"Are you sure you want to import the transactions from these files into the database?" +
                        Environment.NewLine +
                        Environment.NewLine +
                        String.Join(Environment.NewLine, files.Select(x => $"{x.Path} --> {x.Account}")),
                        this.Text,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (answer == DialogResult.Yes)
                    {
                        foreach (var file in files)
                        {
                            try
                            {
                                TransactionImporter.Import(file.Path, file.Account);
                            }
                            catch (Exception ex)
                            {
                                throw new Exception($"Import failed on {file.Path}. Reason: {ex.Message}");
                            }
                        }

                        MessageBox.Show(this, "Import complete.", this.Text);
                    }
                }
                else
                {
                    MessageBox.Show(this, $"No files to import.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.None);
                }
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
