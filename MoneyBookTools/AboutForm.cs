using System.Configuration;

namespace MoneyBookTools
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        public static void Show()
        {
            var dlg = new AboutForm()
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            dlg.ShowDialog();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            try
            {
                Text = $"About {Application.ProductName}";

                var vals = ConfigurationManager.AppSettings.GetValues("DbMode");
                if (vals != null || vals.Length > 0)
                {
                    textBox1.AppendText($"DbMode: {vals[0]}");
                }
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }
    }
}
