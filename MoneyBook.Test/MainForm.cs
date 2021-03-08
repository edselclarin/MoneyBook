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
    public partial class MainForm : Form
    {
        private MoneyBookEntities db;

        public MainForm()
        {
            InitializeComponent();

            this.FormClosing += MainForm_FormClosing;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                db = new MoneyBookEntities();

                LoadTables();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message + Environment.NewLine + ex.StackTrace,
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            db.Dispose();
        }

        private void menuSeedDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, "Seeding will delete existing data in the tables.  Continue?",
                    this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    db.Seed();

                    LoadTables();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message + Environment.NewLine + ex.StackTrace,
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuAddTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                var dlg = new AddTransactionForm()
                {
                    Accounts = db.Accounts.ToList(),
                    Categories = db.CategoryTypes.ToList(),
                };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    using (var tr = db.Database.BeginTransaction())
                    {
                        db.Transactions.Add(dlg.Transaction);
                        db.SaveChanges();

                        tr.Commit();
                    }

                    tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
                    dataGridView6.DataSource = db.Transactions.ToList();
                    SetColumnWidths(dataGridView6);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message + Environment.NewLine + ex.StackTrace,
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuDeleteTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                using (var tr = db.Database.BeginTransaction())
                {
                    var account = db.Accounts.First();
                    foreach (var transaction in account.Transactions.ToList())
                    {
                        db.Transactions.Remove(transaction);
                    }
                    db.Accounts.Remove(account);
                    db.SaveChanges();

                    tr.Commit();
                }

                dataGridView6.DataSource = db.Transactions.ToList();
                SetColumnWidths(dataGridView6);
                dataGridView5.DataSource = db.Accounts.ToList();
                SetColumnWidths(dataGridView5);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message + Environment.NewLine + ex.StackTrace,
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Dgv_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Delete)
                {
                    var dgv = sender as DataGridView;

                    if (dgv.Name == nameof(dataGridView1))
                    {
                        var list = dataGridView1.DataSource as List<AccountType>;
                        var element = list.ElementAt(dgv.CurrentRow.Index);
                        db.AccountTypes.Remove(element);
                        db.SaveChanges();

                        dataGridView1.DataSource = db.AccountTypes.ToList();
                        SetColumnWidths(dataGridView1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message + Environment.NewLine + ex.StackTrace,
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTables()
        {
            db.VerifyDatabase();

            dataGridView1.DataSource = db.AccountTypes.ToList();
            dataGridView2.DataSource = db.FlowTypes.ToList();
            dataGridView3.DataSource = db.StateTypes.ToList();
            dataGridView4.DataSource = db.CategoryTypes.ToList();
            dataGridView5.DataSource = db.Accounts.ToList();
            dataGridView6.DataSource = db.Transactions.ToList();

            string[] tabNames = new string[]
            {
                nameof(db.AccountTypes),
                nameof(db.FlowTypes),
                nameof(db.StateTypes),
                nameof(db.CategoryTypes),
                nameof(db.Accounts),
                nameof(db.Transactions),
            };
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                tabControl1.TabPages[i].Text = tabNames[i];

                foreach (Control ctrl in tabControl1.TabPages[i].Controls)
                {
                    if (ctrl.GetType() == typeof(DataGridView))
                    {
                        ctrl.Dock = DockStyle.Fill;

                        var dgv = ctrl as DataGridView;
                        dgv.ReadOnly = false;
                        dgv.AllowUserToAddRows = true;
                        dgv.AllowUserToDeleteRows = true;
                        dgv.AllowUserToResizeRows = true;
                        dgv.AllowUserToResizeColumns = true;
                        dgv.RowHeadersVisible = true;
                        dgv.ColumnHeadersVisible = true;
                        dgv.PreviewKeyDown += Dgv_PreviewKeyDown;

                        SetColumnWidths(dgv);
                    }
                }
            }
            tabControl1.Dock = DockStyle.Fill;
        }

        private void SetColumnWidths(DataGridView dgv)
        {
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.Name.ToLower().EndsWith("id"))
                {
                    col.Width = 40;
                    continue;
                }

                switch (col.Name.ToLower())
                {
                    case "alias":
                        col.Width = 60;
                        break;
                    case "name":
                    case "payee":
                        col.Width = 160;
                        break;
                    default:
                        col.Width = 100;
                        break;
                }
            }
        }
    }
}
