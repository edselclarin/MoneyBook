using Dark.Net;
using MoneyBook.Data;
using MoneyBook.Extensions;
using MoneyBookTools.Forms;

namespace MoneyBookTools
{
    public partial class StateForm : Form
    {
        public StateTypes TransactionState { get; set; }

        protected StateForm()
        {
            InitializeComponent();
        }

        public static StateForm Create()
        {
            var form = new StateForm()
            {
                StartPosition = FormStartPosition.CenterScreen
            };

            DarkNet.Instance.SetWindowThemeForms(form, Theme.Dark);
            form.ChangeTheme(DarkColorScheme.Create());

            return form;
        }

        private void StateForm_Load(object sender, EventArgs e)
        {
            var stateToControlMap = new (StateTypes State, RadioButton Radio)[]
            {
                (StateTypes.New, radioButton1),
                (StateTypes.Pending, radioButton2),
                (StateTypes.Staged, radioButton3),
                (StateTypes.Reconciled, radioButton4),
                (StateTypes.Ignored, radioButton5)
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

        private void RadioButton_Click(object sender, EventArgs e)
        {
            var radioButton = sender as RadioButton;
            TransactionState = (StateTypes)radioButton.Tag;
            DialogResult = DialogResult.OK;
        }
    }
}
