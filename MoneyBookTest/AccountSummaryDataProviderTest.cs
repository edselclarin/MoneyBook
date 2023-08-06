using MoneyBook.DataProviders;
using MoneyBook.Models;

namespace MoneyBookTest
{
    public class AccountSummaryDataProviderTest
    {
        private AccountSummaryDataProvider dp_;

        [SetUp]
        public void Setup()
        {
            dp_ = (AccountSummaryDataProvider)DataProviderFactory.Create(typeof(AccountSummaryModel));
            Assert.IsNotNull(dp_, "dp_ is null");
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

            var item = dp_.GetAsync(firstItem.AcctId).Result;
            Assert.IsNotNull(item, "item is null");
            Assert.True(item.AcctId == firstItem.AcctId, "id mismatch");
        }
    }
}
