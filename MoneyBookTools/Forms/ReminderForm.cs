using Autofac;
using Dark.Net;
using MoneyBook;
using MoneyBook.Data;
using MoneyBook.Extensions;
using MoneyBook.Models;
using MoneyBookTools.Extensions;
using MoneyBookTools.Forms;
using MoneyBookTools.ViewModels;

namespace MoneyBookTools
{
    public partial class ReminderForm : Form
    {
        private Mode m_mode;
        private IDbContextProxy m_dbProxy;
        private string m_originalHash;

        public enum Mode
        {
            Add,
            Edit,
            Stage
        }

        public ViewReminder ViewReminder { get; set; }

        protected ReminderForm(Mode mode)
        {
            InitializeComponent();

            m_mode = mode;

            Text = $"{mode} Reminder";

            buttonSave.Text = mode.ToString();
        }

        public static ReminderForm CreateAddForm()
        {
            var form = new ReminderForm(Mode.Add)
            {
                StartPosition = FormStartPosition.CenterScreen,
                ViewReminder = null
            };

            DarkNet.Instance.SetWindowThemeForms(form, Theme.Dark);
            form.ChangeTheme(DarkColorScheme.Create());

            return form;
        }

        public static ReminderForm CreateAddForm(ViewTransaction trans)
        {
            var form = new ReminderForm(Mode.Add)
            {
                StartPosition = FormStartPosition.CenterScreen,
                ViewReminder = new ViewReminder()
                {
                    DueDate = trans.Date,
                    AcctId = trans.AcctId,
                    CatId = 0,
                    TrnsType = trans.TrnsType,
                    TrnsAmount = trans.TrnsAmount,
                    Frequency = TransactionFrequency.Monthly.ToString(),
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

        public static ReminderForm CreateEditForm(ViewReminder reminder)
        {
            var form = new ReminderForm(Mode.Edit)
            {
                StartPosition = FormStartPosition.CenterScreen,
                ViewReminder = reminder
            };

            DarkNet.Instance.SetWindowThemeForms(form, Theme.Dark);
            form.ChangeTheme(DarkColorScheme.Create());

            return form;
        }

        public static ReminderForm CreateStageForm(ViewReminder reminder)
        {
            var form = new ReminderForm(Mode.Stage)
            {
                StartPosition = FormStartPosition.CenterScreen,
                ViewReminder = reminder
            };

            DarkNet.Instance.SetWindowThemeForms(form, Theme.Dark);
            form.ChangeTheme(DarkColorScheme.Create());

            return form;
        }

        private async void ReminderForm_Load(object sender, EventArgs e)
        {
            try
            {
                m_dbProxy = MoneyBookContainerBuilder.Container.Resolve<IDbContextProxy>();

                var cats = m_dbProxy.GetCategories().ToList();

                var accts = (await m_dbProxy.GetAccountsAsync()).ToList();
                comboAccounts.DataSource = accts;
                comboAccounts.DisplayMember = "Name";
                comboAccounts.SelectedIndex = 0;

                comboFrequency.DataSource = Enum.GetNames(typeof(TransactionFrequency));

                if (m_mode == Mode.Add)
                {
                    if (ViewReminder == null)
                    {
                        ViewReminder = new ViewReminder()
                        {
                            DueDate = DateTime.Now,
                            AcctId = accts[comboAccounts.SelectedIndex].AcctId,
                            Account = accts[comboAccounts.SelectedIndex].Name,
                            CatId = cats.First().CatId,
                            Payee = DateTime.Now.ToString(),
                            Memo = String.Empty,
                            Website = String.Empty,
                            NewAmount = 0m,
                            TrnsType = TransactionTypes.DEBIT.ToString(),
                            Frequency = TransactionFrequency.Once.ToString(),
                            TrnsAmount = 0m
                        };
                    }
                }
                else if (m_mode == Mode.Edit || m_mode == Mode.Stage)
                {
                    ViewReminder.NewAmount = ViewReminder.Amount;

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

                m_originalHash = ViewReminder.GetHash();

                FillForm();
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private void ReminderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_mode == Mode.Add)
            {
                var answer = MessageBox.Show(this,
                    "Add reminder?",
                    this.Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (answer == DialogResult.Yes)
                {
                    using var hg = new Hourglass(this);

                    var dbProxy = MoneyBookContainerBuilder.Container.Resolve<IDbContextProxy>();

                    dbProxy.AddReminder(ViewReminder.ToReminder());

                    DialogResult = DialogResult.OK;
                }
            }
            else if (m_mode == Mode.Edit)
            {
                bool isModified = ViewReminder.GetHash().CompareTo(m_originalHash) != 0;

                if (isModified)
                {
                    var answer = MessageBox.Show(this,
                        "Save changes?",
                        this.Text,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (answer == DialogResult.Yes)
                    {
                        using var hg = new Hourglass(this);

                        var dbProxy = MoneyBookContainerBuilder.Container.Resolve<IDbContextProxy>();

                        dbProxy.UpdateReminder(ViewReminder.ToReminder());

                        DialogResult = DialogResult.OK;
                    }
                }
            }
            else if (m_mode == Mode.Stage)
            {
                var answer = MessageBox.Show(this,
                    "Stage reminder?",
                    this.Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (answer == DialogResult.Yes)
                {
                    using var hg = new Hourglass(this);

                    var dbProxy = MoneyBookContainerBuilder.Container.Resolve<IDbContextProxy>();

                    var reminders = new ViewReminder[]
                    {
                        ViewReminder
                    };
                    dbProxy.StageReminders(reminders.ToReminders());

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
            dateTime.DataBindings.Add("Value", ViewReminder, "DueDate", false, DataSourceUpdateMode.OnPropertyChanged);

            textPayee.DataBindings.Add("Text", ViewReminder, "Payee", false, DataSourceUpdateMode.OnPropertyChanged);

            textMemo.DataBindings.Add("Text", ViewReminder, "Memo", false, DataSourceUpdateMode.OnPropertyChanged);

            textWebsite.DataBindings.Add("Text", ViewReminder, "Website", false, DataSourceUpdateMode.OnPropertyChanged);

            comboAccounts.DataBindings.Add("Text", ViewReminder, "Account", false, DataSourceUpdateMode.OnPropertyChanged);

            comboFrequency.DataBindings.Add("Text", ViewReminder, "Frequency", false, DataSourceUpdateMode.OnPropertyChanged);

            textAmount.DataBindings.Add("Text", ViewReminder, "NewAmount", true, DataSourceUpdateMode.OnPropertyChanged);
            textAmount.DataBindings[0].FormatString = "0.00";
        }

        private void comboAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var accts = comboAccounts.DataSource as List<Account>;
            var selectedAcct = accts[comboAccounts.SelectedIndex];
            if (ViewReminder is not null && ViewReminder.AcctId != selectedAcct.AcctId)
            {
                ViewReminder.AcctId = selectedAcct.AcctId;
            }
        }
    }
}
