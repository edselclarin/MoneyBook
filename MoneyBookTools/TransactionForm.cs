using MoneyBook.Data;
using MoneyBookTools.Data;
using MoneyBookTools.ViewModels;

namespace MoneyBookTools
{
    public partial class TransactionForm : Form
    {
        private bool m_bNew;
        private ViewTransaction m_transaction;
        private string m_originalHash;

        public static TransactionForm Create(int acctId)
        {
            return new TransactionForm(acctId)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
        }

        public static TransactionForm Create(ViewTransaction transaction)
        {
            return new TransactionForm(transaction)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
        }

        protected TransactionForm(int acctId)
        {
            InitializeComponent();

            Initialize(new ViewTransaction()
            {
                AcctId = acctId,
                Date = DateTime.Now.Date,
                Payee = DateTime.Now.ToString(),
                TrnsType = MoneyBookDbContextExtension.TransactionTypes.DEBIT.ToString(),
                State = MoneyBookDbContextExtension.StateTypes.New.ToString()
            });

            Text = "Add Transaction";
            buttonSave.Text = "Add";

            m_bNew = true;
        }

        protected TransactionForm(ViewTransaction transaction)
        {
            InitializeComponent();

            Initialize(transaction);

            Text = "Edit Transaction";
            buttonSave.Text = "Save";

            m_bNew = false;
        }

        private void Initialize(ViewTransaction transaction)
        {
            m_transaction = transaction;

            m_transaction.NewAmount = m_transaction.Amount;

            m_originalHash = m_transaction.GetHash();
        }

        private void TransactionForm_Load(object sender, EventArgs e)
        {
            try
            {
                comboState.DataSource = Enum.GetNames(typeof(MoneyBook.Data.MoneyBookDbContextExtension.StateTypes));

                FillForm();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            bool isModified = m_transaction.GetHash().CompareTo(m_originalHash) != 0;

            if (isModified)
            {
                var answer = MessageBox.Show(this,
                    m_bNew ? "Add transaction?" : "Save changes?",
                    this.Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (answer == DialogResult.Yes)
                {
                    using var hg = new Hourglass(this);

                    var db = MoneyBookDbContext.Create(MoneyBookToolsDbContextConfig.Instance);

                    using var tr = db.Database.BeginTransaction();

                    if (m_bNew)
                    {
                        db.AddTransaction(m_transaction);
                    }
                    else
                    {
                        db.UpdateTransaction(m_transaction);
                    }

                    tr.Commit();

                    DialogResult = DialogResult.OK;
                }
            }

            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FillForm()
        {
            dateTime.DataBindings.Add("Value", m_transaction, "Date", false, DataSourceUpdateMode.OnPropertyChanged);

            textRefNum.DataBindings.Add("Text", m_transaction, "RefNum", false, DataSourceUpdateMode.OnPropertyChanged);

            textPayee.DataBindings.Add("Text", m_transaction, "Payee", false, DataSourceUpdateMode.OnPropertyChanged);

            textMemo.DataBindings.Add("Text", m_transaction, "Memo", false, DataSourceUpdateMode.OnPropertyChanged);

            comboState.DataBindings.Add("Text", m_transaction, "State", false, DataSourceUpdateMode.OnPropertyChanged);

            textAmount.DataBindings.Add("Text", m_transaction, "NewAmount", true, DataSourceUpdateMode.OnPropertyChanged);
            textAmount.DataBindings[0].FormatString = "0.00";
        }
    }
}
