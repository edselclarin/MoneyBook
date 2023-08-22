using Autofac;
using Dark.Net;
using Microsoft.EntityFrameworkCore;
using MoneyBook;
using MoneyBook.Data;
using MoneyBookTools.Data;
using MoneyBookTools.Forms;
using System.Text;

namespace MoneyBookTools
{
    public partial class ImportTransactionsForm : Form
    {
        private MoneyBookDbContext m_db;

        public static ImportTransactionsForm Create()
        {
            var form = new ImportTransactionsForm()
            {
                StartPosition = FormStartPosition.CenterParent,

            };

            DarkNet.Instance.SetWindowThemeForms(form, Theme.Dark);
            form.ChangeTheme(DarkColorScheme.Create());

            return form;
        }

        public static List<string> GetImportFilePaths()
        {
            using var db = (MoneyBookDbContext)MoneyBookContainerBuilder.Container.Resolve<DbContext>();
            var filepaths = new List<string>();
            foreach (string filepath in db.Accounts.Select(x => x.ImportFilePath))
            {
                if (File.Exists(filepath))
                {
                    filepaths.Add(filepath);
                }
            }
            return filepaths;
        }

        protected ImportTransactionsForm()
        {
            InitializeComponent();

            ControlBox = false;
        }

        private void ImportTransactionsForm_Load(object sender, EventArgs e)
        {
            m_db = (MoneyBookDbContext)MoneyBookContainerBuilder.Container.Resolve<DbContext>();

            var sb = new StringBuilder();
            sb.AppendLine("Import transactions from these files into their respective accounts?");
            sb.AppendLine();
            foreach (var acct in m_db.Accounts)
            {
                sb.AppendLine($"{acct.ImportFilePath} -> {acct.Name}");
            }
            label1.Text = sb.ToString();
        }

        private async void btnYes_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;

            await Task.Run(() =>
            {
                try
                {
                    m_db.ImportTransactions();

                    MessageBox.Show("Import complete.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"EXCEPTION:" + Environment.NewLine +
                        ex.Message + Environment.NewLine +
                        ex.StackTrace);
                }
            });

            UseWaitCursor = false;

            Close();
        }
    }
}
