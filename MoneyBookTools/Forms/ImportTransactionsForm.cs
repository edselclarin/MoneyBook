using Autofac;
using Dark.Net;
using MoneyBook;
using MoneyBook.Data;
using MoneyBook.DataProviders;
using MoneyBook.Models;
using MoneyBookTools.Forms;
using System.Text;

namespace MoneyBookTools
{
    public partial class ImportTransactionsForm : Form
    {
        private IDbContextProxy m_dbProxy;

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

        public async static Task<List<string>> GetImportFilePaths()
        {
            var adp = MoneyBookContainerBuilder.Container.Resolve<IDataProvider<Account>>();
            var accts = await adp.GetPagedAsync(0, 100);
            var filepaths = new List<string>();
            foreach (string filepath in accts.Items.Select(x => x.ImportFilePath))
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

        private async void ImportTransactionsForm_Load(object sender, EventArgs e)
        {
            m_dbProxy = MoneyBookContainerBuilder.Container.Resolve<IDbContextProxy>();

            var accts = await m_dbProxy.GetAccountsAsync();

            var sb = new StringBuilder();
            sb.AppendLine("Import transactions from these files into their respective accounts?");
            sb.AppendLine();
            foreach (var acct in accts)
            {
                sb.AppendLine($"{acct.ImportFilePath} -> {acct.Name}");
            }
            label1.Text = sb.ToString();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;

            try
            {
                m_dbProxy.ImportTransactions();

                MessageBox.Show("Import complete.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"EXCEPTION:" + Environment.NewLine +
                    ex.Message + Environment.NewLine +
                    ex.StackTrace);
            }

            UseWaitCursor = false;

            Close();
        }
    }
}
