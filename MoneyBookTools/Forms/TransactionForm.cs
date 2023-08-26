using Autofac;
using Dark.Net;
using MoneyBook;
using MoneyBook.Data;
using MoneyBook.Extensions;
using MoneyBookTools.Extensions;
using MoneyBookTools.Forms;
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
            var form = new TransactionForm(acctId)
            {
                StartPosition = FormStartPosition.CenterScreen
            };

            DarkNet.Instance.SetWindowThemeForms(form, Theme.Dark);
            form.ChangeTheme(DarkColorScheme.Create());

            return form;
        }

        public static TransactionForm Create(ViewTransaction transaction)
        {
            var form = new TransactionForm(transaction)
            {
                StartPosition = FormStartPosition.CenterScreen
            };

            DarkNet.Instance.SetWindowThemeForms(form, Theme.Dark);
            form.ChangeTheme(DarkColorScheme.Create());

            return form;
        }

        protected TransactionForm(int acctId)
        {
            InitializeComponent();

            Initialize(new ViewTransaction()
            {
                AcctId = acctId,
                Date = DateTime.Now.Date,
                Payee = DateTime.Now.ToString(),
                TrnsType = TransactionTypes.DEBIT.ToString(),
                State = StateTypes.New.ToString()
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
                comboState.DataSource = Enum.GetNames(typeof(StateTypes));

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

                    var dbProxy = MoneyBookContainerBuilder.Container.Resolve<IDbContextProxy>();

                    var trans = m_transaction.ToTransaction();

                    if (m_bNew)
                    {
                        dbProxy.AddTransaction(trans);
                    }
                    else
                    {
                        dbProxy.UpdateTransaction(trans);
                    }

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
