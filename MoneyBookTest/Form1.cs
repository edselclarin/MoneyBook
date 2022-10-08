using MoneyBookApi;
using MoneyBookApi.Models;
using Newtonsoft.Json;
using RestSharp;

namespace MoneyBookTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string baseurl = "https://localhost:7183/Accounts";

            var options = new RestClientOptions(baseurl)
            {
                ThrowOnAnyError = true,
                Timeout = 10000
            };

            using (var client = new RestClient(options))
            {
                var request = new RestRequest()
                    .AddQueryParameter("PageNumber", "1")
                    .AddQueryParameter("PageSize", "10");

                var response = client.Get(request);

                var pagedResponse = JsonConvert.DeserializeObject<PagedResponse<IEnumerable<AccountInfo>>>(response.Content);

                dataGridView1.DataSource = pagedResponse.Data;
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }

        private int pageNumber = 1;
        private const int pageSize = 50;

        private void buttonGetTransactions_Click(object sender, EventArgs e)
        {
            string baseurl = "https://localhost:7183/Transactions";

            var options = new RestClientOptions(baseurl)
            {
                ThrowOnAnyError = true,
                Timeout = 10000
            };

            using (var client = new RestClient(options))
            {
                pageNumber = 1;

                var request = new RestRequest()
                    .AddQueryParameter("PageNumber", pageNumber.ToString())
                    .AddQueryParameter("PageSize", pageSize.ToString())
                    .AddQueryParameter("acctId", "1");

                var response = client.Get(request);

                var pagedResponse = JsonConvert.DeserializeObject<PagedResponse<IEnumerable<TransactionInfo>>>(response.Content);

                dataGridView1.DataSource = pagedResponse.Data;
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }

        private void buttonNextTransactions_Click(object sender, EventArgs e)
        {
            string baseurl = "https://localhost:7183/Transactions";

            var options = new RestClientOptions(baseurl)
            {
                ThrowOnAnyError = true,
                Timeout = 10000
            };

            using (var client = new RestClient(options))
            {
                ++pageNumber;

                var request = new RestRequest()
                    .AddQueryParameter("PageNumber", pageNumber.ToString())
                    .AddQueryParameter("PageSize", pageSize.ToString())
                    .AddQueryParameter("acctId", "1");

                var response = client.Get(request);

                var pagedResponse = JsonConvert.DeserializeObject<PagedResponse<IEnumerable<TransactionInfo>>>(response.Content);

                dataGridView1.DataSource = pagedResponse.Data;
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }
    }
}