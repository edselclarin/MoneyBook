using Dark.Net;
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

        protected ImportTransactionsForm()
        {
            InitializeComponent();

            ControlBox = false;
        }

        private async void ImportTransactionsForm_Load(object sender, EventArgs e)
        {
            m_db = MoneyBookDbContext.Create(MoneyBookToolsDbContextConfig.Instance);

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

            await Task.Run(
                async () =>
                {
                    try
                    {
                        await Task.Delay(2000);

                        var sb = new StringBuilder();
                        foreach (var acct in m_db.Accounts)
                        {
                            sb.AppendLine($"{acct.ImportFilePath} -> {acct.Name}");
                        }
                        sb.AppendLine();
                        sb.AppendLine("Click Import to import ");

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
