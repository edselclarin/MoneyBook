using MoneyBook.DataProviders;
using MoneyBook.Models;

namespace MoneyBookTest
{
    public class AccountSummaryDataProviderTest : BaseDataProviderTest<AccountSummaryModel>
    {
        public AccountSummaryDataProviderTest()
        {
            DataProvider = (AccountSummaryDataProvider)DataProviderFactory.Create(typeof(AccountSummaryModel));
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
