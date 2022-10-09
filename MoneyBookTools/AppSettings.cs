using Newtonsoft.Json;

namespace MoneyBookTools
{
    internal class ImportContext
    {
        public string Account { get; set; }
        public string Path { get; set; }
    }

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
                            Imports = new List<ImportContext>()
                        };
                    }
                }

                return m_instance;
            }
        }

        public IEnumerable<ImportContext> Imports { get; set; }
    }
}
