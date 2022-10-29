using MoneyBook.Data;
using MoneyBookTools.Data;
using MoneyBookTools.ViewModels;

namespace MoneyBookTools
{
    public partial class RecurringTransactionForm : Form
    {
        private string m_originalHash;

        public ViewRecurringTransaction RecurringTransaction { get; set; }

        public RecurringTransactionForm()
        {
            InitializeComponent();
        }

        private void RecurringTransactionForm_Load(object sender, EventArgs e)
        {
            try
            {
                comboFrequency.DataSource = Enum.GetNames(typeof(MoneyBook.Data.MoneyBookDbContextExtension.TransactionFrequency));

                RecurringTransaction.NewAmount = RecurringTransaction.Amount;

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
            bool isModified = RecurringTransaction.GetHash().CompareTo(m_originalHash) != 0;

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

                    //db.UpdateRecurringTransaction(RecurringTransaction);

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
            dateTime.DataBindings.Add("Value", RecurringTransaction, "DueDate", false, DataSourceUpdateMode.OnPropertyChanged);

            textPayee.DataBindings.Add("Text", RecurringTransaction, "Payee", false, DataSourceUpdateMode.OnPropertyChanged);

            textMemo.DataBindings.Add("Text", RecurringTransaction, "Memo", false, DataSourceUpdateMode.OnPropertyChanged);

            comboFrequency.DataBindings.Add("Text", RecurringTransaction, "Frequency", false, DataSourceUpdateMode.OnPropertyChanged);

            textAmount.DataBindings.Add("Text", RecurringTransaction, "NewAmount", true, DataSourceUpdateMode.OnPropertyChanged);
            textAmount.DataBindings[0].FormatString = "0.00";
        }
    }
}
