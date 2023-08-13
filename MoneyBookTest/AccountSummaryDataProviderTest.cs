using MoneyBook;
using MoneyBook.DataProviders;
using MoneyBook.Models;

namespace MoneyBookTest
{
    public class AccountSummaryDataProviderTest : BaseDataProviderTest<AccountSummaryModel>
    {
        public AccountSummaryDataProviderTest()
        {
            DataProvider = (IDataProvider<AccountSummaryModel>)MoneyBookServices.ServiceProvider.GetService(typeof(IDataProvider<AccountSummaryModel>));
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
