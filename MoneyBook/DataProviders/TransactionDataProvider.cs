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
        
        public Task<PagedResponse<Transaction>> GetPagedAsync(int skip, int take)
        {
            return Task.Run(() =>
            {
                int adjustedTake = Math.Min(take, 100);
                var items = db_.Transactions
                    .Skip(skip)
                    .Take(adjustedTake)
                    .ToList();
                return new PagedResponse<Transaction>()
                {
                    Items = items,
                    Count = items.Count(),
                    Total = db_.Transactions.Count(),
                    Skip = skip,
                    Take = adjustedTake
                };
            });
        }

        public Task<Transaction> GetAsync(int id)
        {
            return Task.Run(() =>
            {
                return db_.Transactions
                    .SingleOrDefault(x => x.TrnsId == id);
            });
        }

        public async Task UpsertAsync(Transaction item)
        {
            if (db_.Transactions.SingleOrDefault(x => x.TrnsId == item.TrnsId) is not null)
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
            if (db_.Transactions.SingleOrDefault(x => x.TrnsId == id) is Transaction tran)
            {
                db_.Transactions.Remove(tran);
                await db_.SaveChangesAsync();
            }
        }
    }
}
