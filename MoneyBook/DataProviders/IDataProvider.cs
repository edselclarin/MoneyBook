using Microsoft.EntityFrameworkCore.Storage;
using MoneyBook.Data;

namespace MoneyBook.DataProviders
{
    public interface IDataProvider<T>
    {
        Task<PagedResponse<T>> GetPagedAsync(int skip, int take, int? fkId = null, DateTime? dateTimeFrom = null);
        Task<T> GetAsync(int id);
        Task<T> FindAsync(T item);
        Task<T> UpsertAsync(T item);
        Task DeleteAsync(int id);
        IDbContextTransaction CreateDbTransaction();
    }
}
