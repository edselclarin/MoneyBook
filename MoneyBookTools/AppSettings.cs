using Newtonsoft.Json;

namespace MoneyBookTools
{
    public class AppSettings
    {
        private static string m_filename = "appSettings.json";
        private static AppSettings m_instance;

        public static AppSettings Instance
        {
            get
            {
                if (m_instance == null)
                {
                    if (File.Exists(m_filename))
                    {
                        string json = File.ReadAllText(m_filename);
                        m_instance = JsonConvert.DeserializeObject<AppSettings>(json);
                    }
                    else
                    {
                        m_instance = new AppSettings()
                        {
                            Accounts = new List<AccountData>()
                        };
                    }
                }

                return m_instance;
            }
        }

        public IEnumerable<AccountData> Accounts { get; set; }
        public IList<RepeatingTransaction> RepeatingTransactions { get; set; }
    }

    public class AccountData
    {
        public string Name { get; set; }
        public decimal StartingBalance { get; set; }
        public decimal ReserveAmount { get; set; }
        public string ImportFilePath { get; set; }
    }

    public class RepeatingTransaction
    {
        public DateTime DueDate { get; set; }
        public string Account { get; set; }
        public string TrnsType { get; set; }
        public string Payee { get; set; }
        public string Memo { get; set; }
        public decimal Amount { get; set; }
        public string Frequency { get; set; }
    }
}
