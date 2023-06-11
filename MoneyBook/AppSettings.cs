using Newtonsoft.Json;

namespace MoneyBook
{
    public class AppSettings
    {
        private static string m_filename = @"C:\ProgramData\MoneyBook\appSettings.json";
        private static AppSettings? m_instance;

        public static AppSettings? Instance
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
                        m_instance = new AppSettings();
                    }
                }

                return m_instance;
            }
        }

        public string? ConnectionMode { get; set; }
        public IEnumerable<ConnectionMode>? ConnectionModes { get; set; }
        public DayOfWeek DueBeforeDay { get; set; }

        public string? ConnectionString => 
            ConnectionModes?
                .SingleOrDefault(x => x.Name == ConnectionMode)?.ConnectionString;
    }

    public class ConnectionMode
    {
        public string? Name { get; set; }
        public string? ConnectionString { get; set; }
    }
}
