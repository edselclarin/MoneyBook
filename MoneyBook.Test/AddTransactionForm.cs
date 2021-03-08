using MoneyBook.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoneyBook.Test
{
    public partial class AddTransactionForm : Form
    {
        public List<Account> Accounts { get; set; }
        public List<CategoryType> Categories { get; set; }

        public Transaction Transaction { get; internal set; }

        public AddTransactionForm()
        {
            InitializeComponent();
        }

        private void AddTransactionForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (var db = new MoneyBookEntities())
                {
                    Transaction = db.NewTransaction();
                }

                dateTimePicker1.DataBindings.Add(new Binding("Value", Transaction, "Date"));
                textPayee.DataBindings.Add(new Binding("Text", Transaction, "Payee"));
                textAmount.DataBindings.Add(new Binding("Text", Transaction, "Amount"));

                accountList.DisplayMember = "Name";
                accountList.DataSource = Accounts;

                categoryList.DisplayMember = "Name";
                categoryList.DataSource = Categories;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message + Environment.NewLine + ex.StackTrace,
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var acct = accountList.SelectedItem as Account;            
                Transaction.AID = acct.AID;

                var cat = categoryList.SelectedItem as CategoryType;
                Transaction.CTID = cat.CTID;

                if (String.IsNullOrEmpty(textPayee.Text))
                {
                    MessageBox.Show(this, "Specify payee.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message + Environment.NewLine + ex.StackTrace,
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
