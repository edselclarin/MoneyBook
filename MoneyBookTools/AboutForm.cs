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
            return new AboutForm()
            {
                StartPosition = FormStartPosition.CenterScreen
            };
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
