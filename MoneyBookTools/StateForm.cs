using MoneyBook.Data;

namespace MoneyBookTools
{
    public partial class StateForm : Form
    {
        public MoneyBookDbContextExtension.StateTypes TransactionState { get; set; }

        protected StateForm()
        {
            InitializeComponent();
        }

        public static StateForm Create()
        {
            return new StateForm()
            {
                StartPosition = FormStartPosition.CenterScreen
            };
        }

        private void StateForm_Load(object sender, EventArgs e)
        {
            var stateToControlMap = new (MoneyBookDbContextExtension.StateTypes State, RadioButton Radio)[]
            {
                (MoneyBookDbContextExtension.StateTypes.New, radioButton1),
                (MoneyBookDbContextExtension.StateTypes.Staged, radioButton2),
                (MoneyBookDbContextExtension.StateTypes.Reconciled, radioButton4)
            };

            foreach (var item in stateToControlMap)
            {
                item.Radio.Checked = false;
                item.Radio.TabStop = false;
                item.Radio.Tag = item.State;
                item.Radio.Text = item.State.ToString();
                item.Radio.Click += RadioButton_Click;
            }
        }

        private void RadioButton_Click(object? sender, EventArgs e)
        {
            var radioButton = sender as RadioButton;
            TransactionState = (MoneyBookDbContextExtension.StateTypes)radioButton.Tag;
            DialogResult = DialogResult.OK;
        }
    }
}
