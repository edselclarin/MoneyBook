using MoneyBook;
using MoneyBook.DataProviders;
using MoneyBook.Models;

namespace MoneyBookTest
{
    public class TransactionDataProviderTest : BaseDataProviderTest<Transaction>
    {
        public TransactionDataProviderTest()
        {
            DataProvider = (IDataProvider<Transaction>)MoneyBookServices.ServiceProvider.GetService(typeof(IDataProvider<Transaction>));
            Assert.IsNotNull(DataProvider, "dp_ is null");
        }

        [Test]
        public void GetAll()
        {
            var result = base.GetAllItemsPaged();
            Assert.True(result.totalRetrieved == result.totalCount);
        }

        [Test]
        public void Get()
        {
            var firstItem = GetFirstItem();
            var item = Get(firstItem.TrnsId);
            Assert.IsTrue(firstItem.TrnsId == item.TrnsId);
        }

#if false
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
            Console.WriteLine($"### GetAllSinceLastWeek() ###");
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
            Assert.IsTrue(count < res.Total);
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
            int id = res.Items.First().TrnsId;
            var item = dp_.GetAsync(id).Result;
            Assert.IsNotNull(item, "item is null");
            Assert.True(item.TrnsId == id, "id mismatch");
            Console.WriteLine($"Transaction: {id}, {item.Date}, {item.Payee}, {item.State}, {item.TrnsType}, {item.Amount}");
        }

        [Test]
        public void UpsertAndDelete()
        {
            //TODO
        }
#endif
    }
}
