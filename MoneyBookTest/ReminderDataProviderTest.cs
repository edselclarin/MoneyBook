using MoneyBook.DataProviders;
using MoneyBook.Models;

namespace MoneyBookTest
{
    public class ReminderDataProviderTest : BaseDataProviderTest<Reminder>
    {
        [SetUp]
        public void Setup()
        {
            DataProvider = (ReminderDataProvider)DataProviderFactory.Create(typeof(Reminder));
            Assert.IsNotNull(DataProvider, "DataProvider is null");
        }

        [Test]
        public void GetAll()
        {
            var result = base.GetAll();
            Assert.True(result.totalRetrieved == result.totalCount);
        }

        [Test]
        public void Get()
        {
            var firstItem = GetFirstItem();
            var item = Get(firstItem.RmdrId);
            Assert.IsTrue(firstItem.RmdrId == item.RmdrId);
        }

#if false // TODO refactor
        [Test]
        public void GetAllByInvalidFkId()
        {
            Console.WriteLine($"### GetAllByInvalidFkId() ###");
            int take = 100;
            int skip = 0;
            var res = dp_.GetPagedAsync(skip, take, -1).Result;
            Assert.IsNotNull(res, "res is null");
            Console.WriteLine($"{res.Total} item(s) total");
            Console.WriteLine($"{res.Count} item(s) retrieved");
            Assert.IsTrue(res.Count == 0);
        }

        [Test]
        public void GetAllByFkId()
        {
            Console.WriteLine($"### GetAllByFkId() ###");
            var res = dp_.GetPagedAsync(0, 1).Result;
            Assert.IsNotNull(res, "res is null");
            Assert.IsTrue(res.Count == 1);
            int acctId = res.Items.First().AcctId;

            int take = 100;
            int skip = 0;
            int count = 0;
            res = dp_.GetPagedAsync(skip, take, fkId: acctId).Result;
            Assert.IsNotNull(res, "res is null");
            Console.WriteLine($"{res.Total} item(s) total");
            while (res.Items != null && res.Count > 0)
            {
                skip += take;
                count += res.Count;

                res = dp_.GetPagedAsync(skip, take, fkId: acctId).Result;
                Assert.IsNotNull(res, "res is null");
            }
            Console.WriteLine($"{count} item(s) retrieved");
            Assert.IsTrue(count < res.Total);
        }

        [Test]
        public void GetAllSinceLastMonth()
        {
            Console.WriteLine($"### GetAllSinceLastMonth() ###");
            var dt = DateTime.Now.AddMonths(-1);
            int take = 100;
            int skip = 0;
            int count = 0;
            var res = dp_.GetPagedAsync(skip, take, dateTimeFrom: dt).Result;
            Assert.IsNotNull(res, "res is null");
            Console.WriteLine($"{res.Total} item(s) total");
            while (res.Items != null && res.Count > 0)
            {
                skip += take;
                count += res.Count;

                res = dp_.GetPagedAsync(skip, take, dateTimeFrom: dt).Result;
                Assert.IsNotNull(res, "res is null");
            }
            Console.WriteLine($"{count} item(s) retrieved");
            Assert.IsTrue(count <= res.Total);
        }

        [Test]
        public void GetAllNextYear()
        {
            Console.WriteLine($"### GetAllNextYear() ###");
            var dt = DateTime.Now.AddYears(1);
            int take = 100;
            int skip = 0;
            int count = 0;
            var res = dp_.GetPagedAsync(skip, take, dateTimeFrom: dt).Result;
            Assert.IsNotNull(res, "res is null");
            Console.WriteLine($"{res.Total} item(s) total");
            while (res.Items != null && res.Count > 0)
            {
                skip += take;
                count += res.Count;

                res = dp_.GetPagedAsync(skip, take, dateTimeFrom: dt).Result;
                Assert.IsNotNull(res, "res is null");
            }
            Console.WriteLine($"{count} item(s) retrieved");
            Assert.IsTrue(count < res.Total);
        }

        [Test]
        public void Get()
        {
            Console.WriteLine($"### Get() ###");
            var res = dp_.GetPagedAsync(0, 1).Result;
            Assert.IsNotNull(res, "res is null");
            Assert.IsTrue(res.Count == 1);
            int id = res.Items.First().RmdrId;
            var item = dp_.GetAsync(id).Result;
            Assert.IsNotNull(item, "item is null");
            Assert.True(item.RmdrId == id, "id mismatch");
            Console.WriteLine($"Transaction: {id}, {item.DueDate}, {item.Payee}, {item.Frequency}, {item.TrnsType}, {item.Amount}");
        }

        [Test]
        public void UpsertAndDelete()
        {
            //TODO
        }
#endif
    }
}
