using Dark.Net;
using MoneyBook.BusinessModels;
using MoneyBook.Data;
using MoneyBookTools.Data;
using MoneyBookTools.Forms;
using MoneyBookTools.ViewModels;

namespace MoneyBookTools
{
    public partial class ReminderForm : Form
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

        public ViewReminder Reminder { get; set; }

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
                Reminder = null
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
                Reminder = new ViewReminder()
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

        public static ReminderForm CreateEditForm(ViewReminder reminder)
        {
            var form = new ReminderForm(Mode.Edit)
            {
                StartPosition = FormStartPosition.CenterScreen,
                Reminder = reminder
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
                Reminder = reminder
            };

            DarkNet.Instance.SetWindowThemeForms(form, Theme.Dark);
            form.ChangeTheme(DarkColorScheme.Create());

            return form;
        }

        private void ReminderForm_Load(object sender, EventArgs e)
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
                    if (Reminder == null)
                    {
                        Reminder = new ViewReminder()
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
                    Reminder.NewAmount = Reminder.Amount;

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

                m_originalHash = Reminder.GetHash();

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

                    var db = MoneyBookDbContext.Create(MoneyBookToolsDbContextConfig.Instance);

                    db.AddReminder(Reminder);

                    DialogResult = DialogResult.OK;
                }
            }
            else if (m_mode == Mode.Edit)
            {
                bool isModified = Reminder.GetHash().CompareTo(m_originalHash) != 0;

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

                        db.UpdateReminder(Reminder);

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

                    var db = MoneyBookDbContext.Create(MoneyBookToolsDbContextConfig.Instance);

                    var reminders = new ViewReminder[]
                    {
                        Reminder
                    };
                    db.StageReminders(reminders);

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
            dateTime.DataBindings.Add("Value", Reminder, "DueDate", false, DataSourceUpdateMode.OnPropertyChanged);

            textPayee.DataBindings.Add("Text", Reminder, "Payee", false, DataSourceUpdateMode.OnPropertyChanged);

            textMemo.DataBindings.Add("Text", Reminder, "Memo", false, DataSourceUpdateMode.OnPropertyChanged);

            textWebsite.DataBindings.Add("Text", Reminder, "Website", false, DataSourceUpdateMode.OnPropertyChanged);

            comboAccounts.DataBindings.Add("Text", Reminder, "Account", false, DataSourceUpdateMode.OnPropertyChanged);

            comboFrequency.DataBindings.Add("Text", Reminder, "Frequency", false, DataSourceUpdateMode.OnPropertyChanged);

            textAmount.DataBindings.Add("Text", Reminder, "NewAmount", true, DataSourceUpdateMode.OnPropertyChanged);
            textAmount.DataBindings[0].FormatString = "0.00";
        }

        private void comboAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var accts = comboAccounts.DataSource as List<AccountInfo>;
            var selectedAcct = accts[comboAccounts.SelectedIndex];
            if (Reminder.AcctId != selectedAcct.AcctId)
            {
                Reminder.AcctId = selectedAcct.AcctId;
            }
        }
    }
}
