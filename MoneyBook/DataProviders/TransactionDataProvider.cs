using MoneyBook.Data;
using MoneyBook.Models;
using System.Runtime.Intrinsics.Arm;

namespace MoneyBook.DataProviders
{
    public class TransactionDataProvider : BaseDataProvider, IDataProvider<Transaction>
    {
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

        public Task<Transaction> FindAsync(Transaction item)
        {
            return Task.Run(() =>
            {
                return db_.Transactions.SingleOrDefault(x =>
                    x.IsDeleted == false &&
                    x.Date == item.Date &&
                    x.TrnsType == item.TrnsType &&
                    x.State == item.State &&
                    x.Amount == item.Amount &&
                    x.ExtTrnsId == item.ExtTrnsId &&
                    x.AcctId == item.AcctId &&
                    x.CatId == item.CatId) is Transaction tran ? tran : null;
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

        public async Task<Transaction> UpsertAsync(Transaction item)
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

            return FindAsync(item).Result;
        }

        public async Task DeleteAsync(int id)
        {
            if (db_.Transactions.SingleOrDefault(x => x.IsDeleted == false && x.TrnsId == id) is Transaction tran)
            {
                db_.Transactions.Remove(tran);
                await db_.SaveChangesAsync();
            }
        }

        public MoneyBookDbTransaction CreateDbTransaction()
        {
            return base.CreateDbTransaction();
        }
    }
}
