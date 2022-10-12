using MoneyBook.Data;
using MoneyBookTools.Data;
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
                            using var db = MoneyBookDbContext.Create(MoneyBookToolsDbContextConfig.Instance);
                            using var tr = db.Database.BeginTransaction();

                            foreach (var file in files)
                            {
                                db.ImportTransactions(file.Path, file.Account);
                            }

                            db.UpdateAccountDetails();

                            tr.Commit();
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
