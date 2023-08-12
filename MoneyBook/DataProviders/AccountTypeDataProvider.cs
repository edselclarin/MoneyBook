using MoneyBook.Data;
using MoneyBook.Models;

namespace MoneyBook.DataProviders
{
    public class AccountTypeDataProvider : BaseDataProvider, IDataProvider<AccountType>
    {
        public Task<PagedResponse<AccountType>> GetPagedAsync(int skip, int take, int? fkId = null, DateTime? dateTimeFrom = null)
        {
            return Task.Run(() =>
            {
                int adjustedTake = Math.Min(take, 100);

                var items = db_.AccountTypes
                    .ToList();
                int total = items.Count;

                var pagedItems = items
                    .Skip(skip)
                    .Take(adjustedTake)
                    .ToList();

                return new PagedResponse<AccountType>()
                {
                    Skip = skip,
                    Take = adjustedTake,
                    FKId = fkId,
                    DateTimeFrom = dateTimeFrom,
                    Items = pagedItems,
                    Count = pagedItems.Count(),
                    Total = total
                };
            });
        }

        public Task<AccountType> GetAsync(int id)
        {
            return Task.Run(() =>
            {
                return db_.AccountTypes
                    .SingleOrDefault(x => x.AcctTypeId == id);
            });
        }

        public Task<AccountType> FindAsync(AccountType item)
        {
            return Task.Run(() =>
            {
                return db_.AccountTypes.SingleOrDefault(x =>
                    x.TypeName == item.TypeName) is AccountType acctType ? acctType : null;
            });
        }

        public Task<AccountType> UpsertAsync(AccountType item) { throw new NotSupportedException(); }

        public Task DeleteAsync(int id) { throw new NotSupportedException(); }

        public MoneyBookDbTransaction CreateDbTransaction()
        {
            return base.CreateDbTransaction();
        }
    }
}
