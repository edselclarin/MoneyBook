using MoneyBook.Data;
using MoneyBook.Models;

namespace MoneyBook.DataProviders
{
    public class AccountSummaryDataProvider : BaseDataProvider, IDataProvider<AccountSummaryModel>
    {
        public Task<PagedResponse<AccountSummaryModel>> GetPagedAsync(int skip, int take, int? fkId = null, DateTime? dateTimeFrom = null)
        {
            return Task.Run(() => 
            { 
                IQueryable<AccountSummaryModel> qry = db_.AccountSummaries;
                qry = fkId switch
                {
                    null => qry,
                    _ => qry.Where(x => x.InstId == fkId)
                };
                qry = dateTimeFrom switch
                {
                    null => qry,
                    _ => qry.Where(x => x.DateAdded >= dateTimeFrom)
                };

                int adjustedTake = Math.Min(take, 100);
                var items = qry
                    .Skip(skip)
                    .Take(adjustedTake)
                    .ToList();

                return new PagedResponse<AccountSummaryModel>()
                {
                    Skip = skip,
                    Take = adjustedTake,
                    FKId = fkId,
                    DateTimeFrom = dateTimeFrom,
                    Items = items,
                    Count = items.Count(),
                    Total = db_.AccountSummaries.Count()
                };
            });
        }

        public Task<AccountSummaryModel> GetAsync(int id)
        {
            return Task.Run(() =>
            {
                return db_.AccountSummaries
                    .SingleOrDefault(x => x.AcctId == id && x.IsDeleted == false);
            });
        }

        public Task UpsertAsync(AccountSummaryModel item) { throw new NotSupportedException();  }

        public Task DeleteAsync(int id) { throw new NotSupportedException(); }
    }
}
