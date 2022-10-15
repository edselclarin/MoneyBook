namespace MoneyBook.Models
{
    public enum StateTypes
    {
        Uncleared,
        Cleared,
        Reconciled,
        Staged,
    }

    public static class State
    {
        public static string GetAlias(this StateTypes type)
        {
            return type.ToString()[..1];
        }
    }
}
