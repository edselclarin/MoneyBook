namespace MoneyBook.Data
{
    public class MoneyBookDbContextConfig : IDbContextConfig
    {
        public string ConnectionStr => AppSettings.Instance?.ConnectionString;
    }
}
