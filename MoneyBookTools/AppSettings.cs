using Newtonsoft.Json;

namespace MoneyBookTools
{
    internal class AppSettings
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
    }

    internal class AccountData
    {
        public string Name { get; set; }
        public decimal StartingBalance { get; set; }
        public string ImportFilePath { get; set; }
    }

}
