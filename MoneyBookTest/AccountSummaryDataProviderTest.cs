using MoneyBook.DataProviders;
using MoneyBook.Models;

namespace MoneyBookTest
{
    public class AccountSummaryDataProviderTest : BaseDataProviderTest<AccountSummaryModel>
    {
        [SetUp]
        public void Setup()
        {
            DataProvider = (AccountSummaryDataProvider)DataProviderFactory.Create(typeof(AccountSummaryModel));
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
            var item = Get(firstItem.AcctId);
            Assert.IsTrue(firstItem.AcctId == item.AcctId);
        }
    }
}
