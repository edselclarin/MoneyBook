using MoneyBook.Data;
using MoneyBook.Models;

namespace MoneyBook.DataProviders
{
    public class ReminderDataProvider : IDataProvider<Reminder>
    {
        private MoneyBookDbContext db_;

        public static ReminderDataProvider Create(MoneyBookDbContext db)
        {
            return new ReminderDataProvider()
            {
                db_ = db
            };
        }

        public Task<PagedResponse<Reminder>> GetPagedAsync(int skip, int take)
        {
           return Task.Run(() =>
           {
               int adjustedTake = Math.Min(take, 100);
               var items = db_.Reminders
                   .Skip(skip)
                   .Take(adjustedTake)
                   .ToList();
               return new PagedResponse<Reminder>()
               {
                   Items = items,
                   Count = items.Count(),
                   Total = db_.Reminders.Count(),
                   Skip = skip,
                   Take = adjustedTake
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
            if (db_.Reminders.SingleOrDefault(x => x.RmdrId == item.RmdrId) is not null)
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
            if (db_.Reminders.SingleOrDefault(x => x.RmdrId == id) is Reminder rem)
            {
                db_.Reminders.Remove(rem);
                await db_.SaveChangesAsync();
            }
        }
    }
}
