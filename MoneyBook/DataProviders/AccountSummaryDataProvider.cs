using MoneyBook.Data;
using MoneyBook.Models;

namespace MoneyBook.DataProviders
{
    public class AccountSummaryDataProvider : IDataProvider<AccountSummaryModel>
    {
        private MoneyBookDbContext db_;

        public static AccountSummaryDataProvider Create(MoneyBookDbContext db)
        {
            return new AccountSummaryDataProvider()
            { 
                db_ = db 
            };
        }

        public Task<PagedResponse<AccountSummaryModel>> GetPagedAsync(int skip, int take)
        {
            return Task.Run(() => 
            { 
                int adjustedTake = Math.Min(take, 100);
                var items = db_.AccountSummaries
                    .Skip(skip)
                    .Take(adjustedTake)
                    .ToList();
                return new PagedResponse<AccountSummaryModel>()
                {
                    Items = items,
                    Count = items.Count(),
                    Total = db_.AccountSummaries.Count(),
                    Skip = skip,
                    Take = adjustedTake
                };
            });
        }

        public Task<AccountSummaryModel> GetAsync(int id)
        {
            return Task.Run(() =>
            {
                return db_.AccountSummaries
                    .SingleOrDefault(x => x.AcctId == id);
            });
        }

        public Task UpsertAsync(AccountSummaryModel item)
        {
            throw new NotSupportedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotSupportedException();
        }
    }
}
