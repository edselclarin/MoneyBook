using Dark.Net;
using MoneyBook.Data;
using MoneyBookTools.Data;
using MoneyBookTools.Forms;
using MoneyBookTools.ViewModels;

namespace MoneyBookTools
{
    public partial class RecurringTransactionForm : Form
    {
        private Mode m_mode;
        private MoneyBookDbContext m_db;
        private string m_originalHash;

        public enum Mode
        {
            Add,
            Edit,
            Stage
        }

        public ViewRecurringTransaction RecurringTransaction { get; set; }

        protected RecurringTransactionForm(Mode mode)
        {
            InitializeComponent();

            m_mode = mode;

            Text = $"{mode} Recurring Transaction";

            buttonSave.Text = mode.ToString();
        }

        public static RecurringTransactionForm CreateAddForm()
        {
            var form = new RecurringTransactionForm(Mode.Add)
            {
                StartPosition = FormStartPosition.CenterScreen,
                RecurringTransaction = null
            };

            DarkNet.Instance.SetWindowThemeForms(form, Theme.Dark);
            form.ChangeTheme(DarkColorScheme.Create());

            return form;
        }

        public static RecurringTransactionForm CreateAddForm(ViewTransaction trans)
        {
            var form = new RecurringTransactionForm(Mode.Add)
            {
                StartPosition = FormStartPosition.CenterScreen,
                RecurringTransaction = new ViewRecurringTransaction()
                {
                    DueDate = trans.Date,
                    AcctId = trans.AcctId,
                    CatId = 0,
                    TrnsType = trans.TrnsType,
                    TrnsAmount = trans.TrnsAmount,
                    Frequency = MoneyBookDbContextExtension.TransactionFrequency.Monthly.ToString(),
                    Payee = trans.Payee,
                    Memo = !String.IsNullOrEmpty(trans.Memo) ? trans.Memo : String.Empty,
                    Website = String.Empty,
                    NewAmount = trans.Amount
                }
            };

            DarkNet.Instance.SetWindowThemeForms(form, Theme.Dark);
            form.ChangeTheme(DarkColorScheme.Create());

            return form;
        }

        public static RecurringTransactionForm CreateEditForm(ViewRecurringTransaction recTrans)
        {
            var form = new RecurringTransactionForm(Mode.Edit)
            {
                StartPosition = FormStartPosition.CenterScreen,
                RecurringTransaction = recTrans
            };

            DarkNet.Instance.SetWindowThemeForms(form, Theme.Dark);
            form.ChangeTheme(DarkColorScheme.Create());

            return form;
        }

        public static RecurringTransactionForm CreateStageForm(ViewRecurringTransaction recTrans)
        {
            var form = new RecurringTransactionForm(Mode.Stage)
            {
                StartPosition = FormStartPosition.CenterScreen,
                RecurringTransaction = recTrans
            };

            DarkNet.Instance.SetWindowThemeForms(form, Theme.Dark);
            form.ChangeTheme(DarkColorScheme.Create());

            return form;
        }

        private void RecurringTransactionForm_Load(object sender, EventArgs e)
        {
            try
            {
                m_db = MoneyBookDbContext.Create(MoneyBookToolsDbContextConfig.Instance);

                var cats = m_db.Categories.ToList();

                var accts = m_db.GetAccounts().ToList();
                comboAccounts.DataSource = accts;
                comboAccounts.DisplayMember = "AccountName";
                comboAccounts.SelectedIndex = 0;
                
                comboFrequency.DataSource = Enum.GetNames(typeof(MoneyBook.Data.MoneyBookDbContextExtension.TransactionFrequency));

                if (m_mode == Mode.Add)
                {
                    if (RecurringTransaction == null)
                    {
                        RecurringTransaction = new ViewRecurringTransaction()
                        {
                            DueDate = DateTime.Now,
                            AcctId = accts[comboAccounts.SelectedIndex].AcctId,
                            Account = accts[comboAccounts.SelectedIndex].AccountName,
                            CatId = cats.First().CatId,
                            Payee = DateTime.Now.ToString(),
                            Memo = String.Empty,
                            Website = String.Empty,
                            NewAmount = 0m,
                            TrnsType = MoneyBookDbContextExtension.TransactionTypes.DEBIT.ToString(),
                            Frequency = MoneyBookDbContextExtension.TransactionFrequency.Once.ToString(),
                            TrnsAmount = 0m
                        };
                    }
                }
                else if (m_mode == Mode.Edit || m_mode == Mode.Stage)
                {
                    RecurringTransaction.NewAmount = RecurringTransaction.Amount;

                    if (m_mode == Mode.Stage)
                    {
                        label1.ForeColor =
                        label4.ForeColor =
                        label6.ForeColor = Color.Yellow;

                        comboAccounts.Enabled =
                        textPayee.Enabled =
                        textWebsite.Enabled =
                        comboFrequency.Enabled = false;
                    }
                }

                m_originalHash = RecurringTransaction.GetHash();

                FillForm();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void RecurringTransactionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_mode == Mode.Add)
            {
                var answer = MessageBox.Show(this,
                    "Add recurring transaction?",
                    this.Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (answer == DialogResult.Yes)
                {
                    using var hg = new Hourglass(this);

                    var db = MoneyBookDbContext.Create(MoneyBookToolsDbContextConfig.Instance);

                    db.AddRecurringTransaction(RecurringTransaction);

                    DialogResult = DialogResult.OK;
                }
            }
            else if (m_mode == Mode.Edit)
            {
                bool isModified = RecurringTransaction.GetHash().CompareTo(m_originalHash) != 0;

                if (isModified)
                {
                    var answer = MessageBox.Show(this,
                        "Save changes?",
                        this.Text,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (answer == DialogResult.Yes)
                    {
                        using var hg = new Hourglass(this);

                        var db = MoneyBookDbContext.Create(MoneyBookToolsDbContextConfig.Instance);

                        db.UpdateRecurringTransaction(RecurringTransaction);

                        DialogResult = DialogResult.OK;
                    }
                }
            }
            else if (m_mode == Mode.Stage)
            {
                var answer = MessageBox.Show(this,
                    "Stage recurring transaction?",
                    this.Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (answer == DialogResult.Yes)
                {
                    using var hg = new Hourglass(this);

                    var db = MoneyBookDbContext.Create(MoneyBookToolsDbContextConfig.Instance);

                    var transactions = new ViewRecurringTransaction[]
                    {
                        RecurringTransaction
                    };
                    db.StageRecurringTransactions(transactions);

                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FillForm()
        {
            dateTime.DataBindings.Add("Value", RecurringTransaction, "DueDate", false, DataSourceUpdateMode.OnPropertyChanged);

            textPayee.DataBindings.Add("Text", RecurringTransaction, "Payee", false, DataSourceUpdateMode.OnPropertyChanged);

            textMemo.DataBindings.Add("Text", RecurringTransaction, "Memo", false, DataSourceUpdateMode.OnPropertyChanged);

            textWebsite.DataBindings.Add("Text", RecurringTransaction, "Website", false, DataSourceUpdateMode.OnPropertyChanged);

            comboAccounts.DataBindings.Add("Text", RecurringTransaction, "Account", false, DataSourceUpdateMode.OnPropertyChanged);

            comboFrequency.DataBindings.Add("Text", RecurringTransaction, "Frequency", false, DataSourceUpdateMode.OnPropertyChanged);

            textAmount.DataBindings.Add("Text", RecurringTransaction, "NewAmount", true, DataSourceUpdateMode.OnPropertyChanged);
            textAmount.DataBindings[0].FormatString = "0.00";
        }
    }
}
