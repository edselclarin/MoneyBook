using MoneyBook.Monads;

namespace MoneyBook.Data
{
    public interface IDbBackup
    {
        Result<string, string> Save();
    }
}
