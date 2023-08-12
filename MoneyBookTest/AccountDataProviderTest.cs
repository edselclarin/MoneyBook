using MoneyBook.DataProviders;
using MoneyBook.Models;

namespace MoneyBookTest
{
    public class AccountDataProviderTest : BaseDataProviderTest<Account>
    {
        [SetUp]
        public void Setup()
        {
            DataProvider = (AccountDataProvider)DataProviderFactory.Create(typeof(Account));
            Assert.IsNotNull(DataProvider, "dp_ is null");
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
            var item = Get(firstItem.AcctId);
            Assert.IsTrue(firstItem.AcctId == item.AcctId);
        }
    }
}
