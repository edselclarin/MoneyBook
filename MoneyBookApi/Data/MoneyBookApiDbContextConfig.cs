using MoneyBook.Data;

namespace MoneyBookApi.Data
{
    public class MoneyBookApiDbContextConfig : IDbContextConfig
    {
        private static MoneyBookApiDbContextConfig m_instance;

        protected MoneyBookApiDbContextConfig()
        {
        }

        public static MoneyBookApiDbContextConfig Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = new MoneyBookApiDbContextConfig();
                }
                return m_instance;
            }
        }

        public string ConnectionStr => 
            new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build().GetSection("ConnectionStrings")["Default"];
    }
}
