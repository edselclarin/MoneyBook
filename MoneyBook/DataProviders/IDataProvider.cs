namespace MoneyBook.DataProviders
{
    public interface IDataProvider<T>
    {
        Task<PagedResponse<T>> GetPagedAsync(int skip, int take);
        Task<T> GetAsync(int id);
        Task UpsertAsync(T item);
        Task DeleteAsync(int id);
    }
}
