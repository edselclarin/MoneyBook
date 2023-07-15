using Dark.Net;
using MoneyBookTools.Forms;
using System.Configuration;

namespace MoneyBookTools
{
    public partial class AboutForm : Form
    {
        protected AboutForm()
        {
            InitializeComponent();
        }

        public static AboutForm Create()
        {
            var form = new AboutForm()
            {
                StartPosition = FormStartPosition.CenterScreen
            };

            DarkNet.Instance.SetWindowThemeForms(form, Theme.Dark);
            form.ChangeTheme(DarkColorScheme.Create());

            return form;
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            try
            {
                Text = $"About {Application.ProductName}";

                textBox1.AppendText($"DbMode: {MoneyBook.AppSettings.Instance?.ConnectionMode}");
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }
    }
}
