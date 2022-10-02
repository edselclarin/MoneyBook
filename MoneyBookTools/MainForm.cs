using MoneyBookTools.Ofx;
using Ofx;

namespace MoneyBookTools
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Maximized;

                dateTimeEnd.Value = DateTime.Now;
                dateTimeStart.Value = dateTimeEnd.Value.AddDays(-14);
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

        private void buttonImport_Click(object sender, EventArgs e)
        {
            try
            {
                var ofd = new OpenFileDialog()
                {
                    InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString(),
                    Filter = "OFX Files|*.ofx|All Files|*.*",
                };
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var transactions = ReadTransactions(ofd.FileName)
                        .Where(x => x.DatePosted >= dateTimeStart.Value && x.DatePosted <= dateTimeEnd.Value)
                        .ToList();

                    LoadTransactions(transactions);
                }
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        #region Implementation
        private void LoadTransactions(IList<OfxTransaction> transactions)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = transactions;
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private IList<OfxTransaction> ReadTransactions(string fileName)
        {
            var ofx = OfxSerializer.Deserialize(fileName);
            return ofx.BANKMSGSRSV1.STMTTRNRS.STMTRS.BANKTRANLIST.STMTTRN
                .ToTransactions();
        }
        #endregion // Implementation
    }
}
