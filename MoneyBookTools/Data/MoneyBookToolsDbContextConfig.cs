using MoneyBook.Data;
using System.Configuration;

namespace MoneyBookTools.Data
{
    public class MoneyBookToolsDbContextConfig : IDbContextConfig
    {
        private static MoneyBookToolsDbContextConfig m_instance;

        protected MoneyBookToolsDbContextConfig()
        {
        }

        public static MoneyBookToolsDbContextConfig Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = new MoneyBookToolsDbContextConfig();
                }
                return m_instance;
            }
        }

        private string GetConnectionString()
        {
            var vals = ConfigurationManager.AppSettings.GetValues("DbMode");
            if (vals == null || vals.Length == 0)
            {
                throw new Exception("Cannot find connection string. Check App.config.");
            }
            string dbMode = vals[0].ToString();
            return ConfigurationManager.ConnectionStrings[dbMode].ConnectionString;
        }

        public string ConnectionStr => GetConnectionString();
    }
}
