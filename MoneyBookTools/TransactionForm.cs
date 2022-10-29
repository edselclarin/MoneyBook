using MoneyBook.Data;
using MoneyBookTools.Data;
using MoneyBookTools.ViewModels;

namespace MoneyBookTools
{
    public partial class TransactionForm : Form
    {
        private string m_originalHash;

        public ViewTransaction Transaction { get; set; }

        public TransactionForm()
        {
            InitializeComponent();
        }

        private void TransactionForm_Load(object sender, EventArgs e)
        {
            try
            {
                comboState.DataSource = Enum.GetNames(typeof(MoneyBook.Data.MoneyBookDbContextExtension.StateTypes));

                Transaction.NewAmount = Transaction.Amount;

                m_originalHash = Transaction.GetHash();

                FillForm();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void TransactionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool isModified = Transaction.GetHash().CompareTo(m_originalHash) != 0;

            if (isModified)
            {
                var answer = MessageBox.Show(this,
                    $"Save changes?",
                    this.Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (answer == DialogResult.Yes)
                {
                    using var hg = new Hourglass(this);

                    var db = MoneyBookDbContext.Create(MoneyBookToolsDbContextConfig.Instance);

                    using var tr = db.Database.BeginTransaction();

                    db.UpdateTransaction(Transaction);

                    tr.Commit();

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
            dateTime.DataBindings.Add("Value", Transaction, "Date", false, DataSourceUpdateMode.OnPropertyChanged);

            textRefNum.DataBindings.Add("Text", Transaction, "RefNum", false, DataSourceUpdateMode.OnPropertyChanged);

            textPayee.DataBindings.Add("Text", Transaction, "Payee", false, DataSourceUpdateMode.OnPropertyChanged);

            textMemo.DataBindings.Add("Text", Transaction, "Memo", false, DataSourceUpdateMode.OnPropertyChanged);

            comboState.DataBindings.Add("Text", Transaction, "State", false, DataSourceUpdateMode.OnPropertyChanged);

            textAmount.DataBindings.Add("Text", Transaction, "NewAmount", true, DataSourceUpdateMode.OnPropertyChanged);
            textAmount.DataBindings[0].FormatString = "0.00";
        }
    }
}
