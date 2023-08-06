using MoneyBook.Data;
using MoneyBook.DataProviders;

namespace MoneyBookTest
{
    public class AccountSummaryProviderTest
    {
        private MoneyBookDbContext db_;
        private AccountSummaryProvider dp_;

        [SetUp]
        public void Setup()
        {
            db_ = MoneyBookDbContext.Create(MoneyBookToolsDbContextConfig.Instance);
            Assert.IsNotNull(db_);

            dp_ = AccountSummaryProvider.Create(db_);
            Assert.IsNotNull(dp_);
        }

        [Test]
        public void GetAll()
        {
            var res = dp_.GetAsync(0, 100);
            Assert.IsNotNull(res);
        }

        [Test]
        public void Get()
        {
            var res = dp_.GetAsync(0, 100);
            Assert.IsNotNull(res);

            var firstItem = res.Items.FirstOrDefault();
            Assert.IsNotNull(firstItem);

            var item = dp_.GetAsync(firstItem.AcctId);
            Assert.IsNotNull(item);
            Assert.True(item.AcctId == firstItem.AcctId);
        }
    }
}
