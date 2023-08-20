using MoneyBook;
using MoneyBook.DataProviders;
using MoneyBook.Models;

namespace MoneyBookTest
{
    public class AccountSummaryDataProviderTest : BaseDataProviderTest<AccountSummary>
    {
        public AccountSummaryDataProviderTest()
        {
            DataProvider = (IDataProvider<AccountSummary>)MoneyBookServices.ServiceProvider.GetService(typeof(IDataProvider<AccountSummary>));
            Assert.IsNotNull(DataProvider, "DataProvider is null");
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
            var item = Get(firstItem.AcctId);
            Assert.IsTrue(firstItem.AcctId == item.AcctId);
        }
    }
}
