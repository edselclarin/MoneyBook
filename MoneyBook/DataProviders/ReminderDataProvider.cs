using MoneyBook.Data;
using MoneyBook.Models;

namespace MoneyBook.DataProviders
{
    public class ReminderDataProvider : BaseDataProvider, IDataProvider<Reminder>
    {
        public Task<PagedResponse<Reminder>> GetPagedAsync(int skip, int take, int? fkId = null, DateTime? dateTimeFrom = null)
        {
            return Task.Run(() =>
            {
                int adjustedTake = Math.Min(take, 100);

                var items = db_.Reminders
                    .Where(x => x.IsDeleted == false)
                    .ToList();
                int total = items.Count;

                IEnumerable<Reminder> qry;
                if (fkId != null && dateTimeFrom != null)
                {
                    qry = items.Where(x => x.AcctId == fkId && x.DueDate >= dateTimeFrom);
                }
                else if (fkId != null && dateTimeFrom == null)
                {
                    qry = items.Where(x => x.AcctId == fkId);
                }
                else if (fkId == null && dateTimeFrom != null)
                {
                    qry = items.Where(x => x.DueDate >= dateTimeFrom);
                }
                else
                {
                    qry = items;
                }
                var pagedItems = qry
                    .Skip(skip)
                    .Take(adjustedTake)
                    .ToList();

                return new PagedResponse<Reminder>()
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

        public Task<Reminder> GetAsync(int id)
        {
            return Task.Run(() =>
            {
                return db_.Reminders
                    .SingleOrDefault(x => x.RmdrId == id);
            });
        }

        public async Task UpsertAsync(Reminder item)
        {
            if (db_.Reminders.SingleOrDefault(x => x.IsDeleted == false && x.RmdrId == item.RmdrId) is not null)
            {
                db_.Reminders.Update(item);
            }
            else
            {
                db_.Reminders.Add(item);
            }
            await db_.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (db_.Reminders.SingleOrDefault(x => x.IsDeleted == false && x.RmdrId == id) is Reminder rem)
            {
                db_.Reminders.Remove(rem);
                await db_.SaveChangesAsync();
            }
        }
    }
}
