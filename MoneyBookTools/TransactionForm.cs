using MoneyBookTools.ViewModels;
using System.Diagnostics;

namespace MoneyBookTools
{
    public partial class TransactionForm : Form
    {
        private int m_iSelected;

        public List<ViewTransaction> Transactions { get; set; }

        public TransactionForm()
        {
            InitializeComponent();
        }

        private void TransactionForm_Load(object sender, EventArgs e)
        {
            comboState.DataSource = Enum.GetNames(typeof(MoneyBook.Data.MoneyBookDbContextExtension.StateTypes));
        }

        private void TransactionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var modifiedTransactions = Transactions.Where(x => x.Modified == true);
            foreach (var trn in modifiedTransactions)
            {
                Debug.WriteLine($"{trn.Payee}");
            }
        }

        public void Init(int iSelected)
        {
            if (InvokeRequired)
            {
                Invoke(Init, iSelected);
            }
            else
            {
                SetCurrentTransaction(iSelected);
            }
        }

        public void SetCurrentTransaction(int index)
        {
            m_iSelected = index;

            if (m_iSelected > -1)
            {
                labelIndex.Text = $"{m_iSelected + 1} of {Transactions.Count()}";

                var transaction = Transactions[m_iSelected];

                dateTime.DataBindings.Clear();
                dateTime.DataBindings.Add("Value", transaction, "Date", false, DataSourceUpdateMode.OnPropertyChanged);

                textRefNum.DataBindings.Clear();
                textRefNum.DataBindings.Add("Text", transaction, "RefNum", false, DataSourceUpdateMode.OnPropertyChanged);

                textPayee.DataBindings.Clear();
                textPayee.DataBindings.Add("Text", transaction, "Payee", false, DataSourceUpdateMode.OnPropertyChanged);

                textMemo.DataBindings.Clear();
                textMemo.DataBindings.Add("Text", transaction, "Memo", false, DataSourceUpdateMode.OnPropertyChanged);

                comboState.DataBindings.Clear();
                comboState.DataBindings.Add("SelectedText", transaction, "State", false, DataSourceUpdateMode.OnPropertyChanged);

                textAmount.DataBindings.Clear();
                textAmount.DataBindings.Add("Text", transaction, "Amount", false, DataSourceUpdateMode.OnPropertyChanged);
            }
            else
            {
                labelIndex.Text = "0 of 0";
            }
        }

        private void buttonFirst_Click(object sender, EventArgs e)
        {
            try
            {
                m_iSelected = 0;

                SetCurrentTransaction(m_iSelected);
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            try
            {
                // Wrap around.
                m_iSelected = m_iSelected == 0 ? Transactions.Count() - 1 : m_iSelected - 1;

                SetCurrentTransaction(m_iSelected);
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            try
            {
                // Wrap around.
                m_iSelected = m_iSelected == Transactions.Count() - 1 ? 0 : m_iSelected + 1;

                SetCurrentTransaction(m_iSelected);
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void buttonLast_Click(object sender, EventArgs e)
        {
            try
            {
                m_iSelected = Transactions.Count() - 1;

                SetCurrentTransaction(m_iSelected);
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }
    }
}
