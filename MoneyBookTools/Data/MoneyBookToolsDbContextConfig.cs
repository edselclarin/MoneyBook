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

        public string ConnectionStr => 
            ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
    }
}
