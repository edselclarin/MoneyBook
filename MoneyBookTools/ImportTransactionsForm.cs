using Dark.Net;
using MoneyBook;
using MoneyBook.Data;
using MoneyBookTools.Data;
using MoneyBookTools.Forms;

namespace MoneyBookTools
{
    public partial class ImportTransactionsForm : Form
    {
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
        }

        private async void ImportTransactionsForm_Load(object sender, EventArgs e)
        {
            ControlBox = false;

            await Task.Run(
                async () =>
                {
                    try
                    {
                        WriteLine("Importing transactions, please wait...");

                        await Task.Run(() => Thread.Sleep(2000));

                        ImportTransactions();

                        Invoke((MethodInvoker)delegate
                        {
                            Close();
                        });
                    }
                    catch (Exception ex)
                    {
                        WriteLine(
                            $"EXCEPTION:" + Environment.NewLine +
                            ex.Message + Environment.NewLine +
                            ex.StackTrace);
                    }
                });

            ControlBox = true;
        }

        private void WriteLine(string line)
        {
            textOutput.Invoke((MethodInvoker)delegate
            {
                textOutput.AppendText(line + Environment.NewLine);
            });
        }

        private void ImportTransactions()
        {
            var accountDataArr = AppSettings.Instance?.Accounts?
                .Where(x => File.Exists(x.ImportFilePath));

            using var db = MoneyBookDbContext.Create(MoneyBookToolsDbContextConfig.Instance);

            db.ImportTransactions(accountDataArr);
        }
    }
}
