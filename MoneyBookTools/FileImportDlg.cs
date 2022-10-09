using MoneyBook.Data;
using System.Data;

namespace MoneyBookTools
{
    public partial class FileImportDlg : Form
    {
        public FileImportDlg()
        {
            InitializeComponent();
        }

        private async void FileImportDlg_Load(object sender, EventArgs e)
        {
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
                            foreach (var file in files)
                            {
                                var importer = TransactionImporter.Create();
                                importer.OnLog += OnLog;
                                importer.Import(file.Path, file.Account);
                            }

                            var updater = AccountDetailsUpdater.Create();
                            updater.OnLog += OnLog;
                            updater.UpdateAll();
                        });

                        WriteLine("Import complete.");
                    }
                }
                else
                {
                    WriteLine($"No files to import.  Check imports in appSettings.json.");
                }
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void OnLog(string str)
        {
            if (InvokeRequired)
            {
                Invoke(OnLog, str);
            }
            else
            {
                textOutput.AppendText(str + Environment.NewLine);
            }
        }

        private void WriteLine(string str)
        {
            if (InvokeRequired)
            {
                Invoke(WriteLine, str);
            }
            else
            {
                textOutput.AppendText(str + Environment.NewLine);
            }
        }
    }
}
