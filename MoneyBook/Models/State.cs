namespace MoneyBook.Models
{
    public enum StateTypes
    {
        Uncleared,
        Cleared,
        Reconciled
    }

    public static class State
    {
        public static string GetAlias(this StateTypes type)
        {
            return type.ToString()[..1];
        }
    }
}
