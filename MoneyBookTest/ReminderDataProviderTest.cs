using MoneyBook.Data;
using MoneyBook.DataProviders;

namespace MoneyBookTest
{
    public class ReminderDataProviderTest
    {
        private MoneyBookDbContext db_;
        private ReminderDataProvider dp_;

        [SetUp]
        public void Setup()
        {
            db_ = MoneyBookDbContext.Create(MoneyBookToolsDbContextConfig.Instance);
            Assert.IsNotNull(db_, "db_ is null");

            dp_ = ReminderDataProvider.Create(db_);
            Assert.IsNotNull(db_, "dp_ is null");
        }

        [Test]
        public void GetAll()
        {
            var res = dp_.GetPagedAsync(0, 100).Result;
            Assert.IsNotNull(res, "res is null");
            Assert.IsNotNull(res.Items, "res.Items is null");
            Assert.IsTrue(
                (res.Count >= 0 || res.Count <= 50) &&
                res.Total > 0 &&
                (res.Take >= 0 || res.Take <= 50));
        }

        [Test]
        public void Get()
        {
            var res = dp_.GetPagedAsync(0, 1).Result;
            Assert.IsNotNull(res, "res is null");
            Assert.IsNotNull(res.Items, "res.Items is null");
            Assert.IsTrue(
                res.Count == 1 &&
                res.Total > 0 &&
                (res.Take >= 0 || res.Take <= 50));

            var firstItem = res.Items.FirstOrDefault();

            var item = dp_.GetAsync(firstItem.RmdrId).Result;
            Assert.IsNotNull(item, "item is null");
            Assert.True(item.RmdrId == firstItem.RmdrId, "id mismatch");
        }

        [Test]
        public void UpsertAndDelete()
        {
            //TODO
        }
    }
}
