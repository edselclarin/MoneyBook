using MoneyBook.Data;
using MoneyBook.Models;

namespace MoneyBook.DataProviders
{
    public class AccountDataProvider : BaseDataProvider, IDataProvider<Account>
    {
        public Task<PagedResponse<Account>> GetPagedAsync(int skip, int take, int? fkId = null, DateTime? dateTimeFrom = null)
        {
            return Task.Run(() =>
            {
                int adjustedTake = Math.Min(take, 100);

                var items = db_.Accounts
                    .Where(x => x.IsDeleted == false)
                    .ToList();
                int total = items.Count;

                IEnumerable<Account> qry;
                if (fkId != null && dateTimeFrom != null)
                {
                    qry = items.Where(x => x.AcctId == fkId && x.DateModified >= dateTimeFrom);
                }
                else if (fkId != null && dateTimeFrom == null)
                {
                    qry = items.Where(x => x.AcctId == fkId);
                }
                else if (fkId == null && dateTimeFrom != null)
                {
                    qry = items.Where(x => x.DateModified >= dateTimeFrom);
                }
                else
                {
                    qry = items;
                }
                var pagedItems = qry
                    .Skip(skip)
                    .Take(adjustedTake)
                    .ToList();

                return new PagedResponse<Account>()
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

        public Task<Account> GetAsync(int id)
        {
            return Task.Run(() =>
            {
                return db_.Accounts
                    .SingleOrDefault(x => x.IsDeleted == false && x.AcctId == id);
            });
        }

        public Task<Account> FindAsync(Account item)
        {
            return Task.Run(() =>
            {
                return db_.Accounts.SingleOrDefault(x =>
                    x.IsDeleted == false &&
                    x.Name == item.Name &&
                    x.AcctTypeId == item.AcctTypeId &&
                    x.ExtAcctId == item.ExtAcctId &&
                    x.InstId == item.InstId ) is Account acct ? acct : null;
            });
        }

        public async Task<Account> UpsertAsync(Account item)
        {
            if (db_.Accounts.SingleOrDefault(x => x.IsDeleted == false && x.AcctId == item.AcctId) is not null)
            {
                db_.Accounts.Update(item);
            }
            else
            {
                db_.Accounts.Add(item);
            }
            await db_.SaveChangesAsync();

            return FindAsync(item).Result;
        }

        public async Task DeleteAsync(int id)
        {
            if (db_.Accounts.SingleOrDefault(x => x.IsDeleted == false && x.AcctId == id) is Account acct)
            {
                db_.Accounts.Remove(acct);
                await db_.SaveChangesAsync();
            }
        }
    }
}
