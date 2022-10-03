using MoneyBookTools.Data;
using MoneyBookTools.Ofx;

namespace MoneyBookTools
{
    public partial class MainForm : Form
    {
        private OfxContext m_context;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Maximized;

                buttonImport.Enabled = false;

                dateTimeEnd.Enabled = dateTimeStart.Enabled = false;
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
            Cursor = Cursors.WaitCursor;

            try
            {
                var answer = MessageBox.Show(this, 
                    $"Are you sure you want to import these transactions into {m_context.AcctFrom.AcctType} ACCOUNT {m_context.AcctFrom.AcctId}?", 
                    this.Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (answer == DialogResult.Yes)
                {
                    TransactionImporter.Import(m_context);

                    MessageBox.Show(this, "Done", this.Text);
                }
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }

            Cursor = Cursors.Default;
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                var ofd = new OpenFileDialog()
                {
                    InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString(),
                    Filter = "OFX Files|*.ofx|All Files|*.*",
                };
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    m_context = new OfxContext();
                    m_context.FromFile(ofd.FileName);

                    dataGridView1.ReadOnly = true;
                    dataGridView1.DataSource = m_context.Transactions;
                    foreach (DataGridViewColumn col in dataGridView1.Columns)
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
    }
}
