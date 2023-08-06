namespace MoneyBook.DataProviders
{
    public interface IDataProvider<T>
    {
        PagedResponse<T> GetAsync(int skip, int take);
        T? GetAsync(int id);
        void UpsertAsync(T item);
        void DeleteAsync(int id);
    }
}
