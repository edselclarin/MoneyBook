using MoneyBook.Data;
using MoneyBook.Models;

namespace MoneyBook.DataProviders
{
    public class AccountSummaryProvider : IDataProvider<AccountSummaryModel>
    {
        private MoneyBookDbContext db_;

        public static AccountSummaryProvider Create(MoneyBookDbContext db)
        {
            return new AccountSummaryProvider()
            { 
                db_ = db 
            };
        }

        public PagedResponse<AccountSummaryModel>? GetAsync(int skip, int take)
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
        }

        public AccountSummaryModel? GetAsync(int id)
        {
            return db_.AccountSummaries
                .SingleOrDefault(x => x.AcctId == id);
        }

        public void UpsertAsync(AccountSummaryModel item)
        {
            throw new NotSupportedException();
        }

        public void DeleteAsync(int id)
        {
            throw new NotSupportedException();
        }
    }
}
