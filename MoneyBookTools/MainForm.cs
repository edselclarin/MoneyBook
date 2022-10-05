using MoneyBookTools.Data;
using MoneyBookTools.Ofx;

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
                    Filter = "OFX Files|*.ofx|All Files|*.*",
                };
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var context = new OfxContext();
                    context.FromFile(ofd.FileName);

                    dataGridView1.ReadOnly = true;
                    dataGridView1.DataSource = context.Transactions;
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

        private void buttonImport_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                var dlg = new FolderBrowserDialog()
                {
                    Description = "Select path to OFX files:",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                };

                var answer = dlg.ShowDialog();

                if (answer == DialogResult.OK)
                {
                    var filenames = Directory.EnumerateFiles(dlg.SelectedPath, "*.ofx");

                    if (filenames.Count() > 0)
                    {
                        answer = MessageBox.Show(this,
                            $"Are you sure you want to import the transactions from these files into the database?" +
                            Environment.NewLine +
                            Environment.NewLine +
                            String.Join(Environment.NewLine, filenames),
                            this.Text,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                        if (answer == DialogResult.Yes)
                        {
                            foreach (var filename in filenames)
                            {
                                try
                                {
                                    TransactionImporter.Import(filename);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(this, $"Import failed on {filename}. Reason: {ex.Message}", this.Text, 
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }

                            MessageBox.Show(this, "Import complete.", this.Text);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, $"No OFX files found in {dlg.SelectedPath}.", this.Text,
                            MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
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
