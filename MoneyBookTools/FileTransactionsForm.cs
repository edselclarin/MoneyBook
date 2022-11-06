using Ofx;

namespace MoneyBookTools
{
    public partial class FileTransactionsForm : Form
    {
        protected FileTransactionsForm()
        {
            InitializeComponent();

            groupFileTransactions.Dock =
            dgvFileTransactions.Dock = DockStyle.Fill;
        }

        public static FileTransactionsForm Create()
        {
            return new FileTransactionsForm()
            {
                StartPosition = FormStartPosition.CenterScreen
            };
        }

        private void FileTransactionsForm_Load(object sender, EventArgs e)
        {
            this.Shown += FileTransactionsForm_Shown;
        }

        private void FileTransactionsForm_Shown(object? sender, EventArgs e)
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
    }
}
