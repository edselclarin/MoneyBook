using MoneyBook.Models;

namespace MoneyBook.DataProviders
{
    public class InstitutionDataProvider : BaseDataProvider, IDataProvider<Institution>
    {
        public Task<PagedResponse<Institution>> GetPagedAsync(int skip, int take, int? fkId = null, DateTime? dateTimeFrom = null)
        {
            return Task.Run(() =>
            {
                int adjustedTake = Math.Min(take, 100);

                var items = db_.Institutions
                    .ToList();
                int total = items.Count;

                var pagedItems = items
                    .Skip(skip)
                    .Take(adjustedTake)
                    .ToList();

                return new PagedResponse<Institution>()
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

        public Task<Institution> GetAsync(int id)
        {
            return Task.Run(() =>
            {
                return db_.Institutions
                    .SingleOrDefault(x => x.InstId == id);
            });
        }

        public Task<Institution> FindAsync(Institution item)
        {
            return Task.Run(() =>
            {
                return db_.Institutions.SingleOrDefault(x =>
                    x.Name == item.Name) is Institution inst ? inst : null;
            });
        }

        public Task<Institution> UpsertAsync(Institution item) { throw new NotSupportedException(); }

        public Task DeleteAsync(int id) { throw new NotSupportedException(); }
    }
}
