using MoneyBook.Data;
using MoneyBook.Models;

namespace MoneyBook.DataProviders
{
    public class TransactionDataProvider : IDataProvider<Transaction>
    {
        private MoneyBookDbContext db_;

        public static TransactionDataProvider Create(MoneyBookDbContext db)
        {
            return new TransactionDataProvider()
            {
                db_ = db
            };
        }
        
        public Task<PagedResponse<Transaction>> GetPagedAsync(int skip, int take, int? fkId = null, DateTime? dateTimeFrom = null)
        {
            return Task.Run(() =>
            {
                int adjustedTake = Math.Min(take, 100);

                var items = db_.Transactions
                    .Where(x => x.IsDeleted == false)
                    .ToList();
                int total = items.Count;

                IEnumerable<Transaction> qry;
                if (fkId != null && dateTimeFrom != null)
                {
                    qry = items.Where(x => x.AcctId == fkId && x.Date >= dateTimeFrom);
                }
                else if (fkId != null && dateTimeFrom == null)
                {
                    qry = items.Where(x => x.AcctId == fkId);
                }
                else if (fkId == null && dateTimeFrom != null)
                {
                    qry = items.Where(x => x.Date >= dateTimeFrom);
                }
                else
                {
                    qry = items;
                }
                var pagedItems = qry
                    .Skip(skip)
                    .Take(adjustedTake)
                    .ToList();

                return new PagedResponse<Transaction>()
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

        public Task<Transaction> GetAsync(int id)
        {
            return Task.Run(() =>
            {
                return db_.Transactions
                    .SingleOrDefault(x => x.IsDeleted == false && x.TrnsId == id);
            });
        }

        public async Task UpsertAsync(Transaction item)
        {
            if (db_.Transactions.SingleOrDefault(x => x.IsDeleted == false &&  x.TrnsId == item.TrnsId) is not null)
            {
                db_.Transactions.Update(item);
            }
            else
            {
                db_.Transactions.Add(item);
            }
            await db_.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (db_.Transactions.SingleOrDefault(x => x.IsDeleted == false && x.TrnsId == id) is Transaction tran)
            {
                db_.Transactions.Remove(tran);
                await db_.SaveChangesAsync();
            }
        }
    }
}
