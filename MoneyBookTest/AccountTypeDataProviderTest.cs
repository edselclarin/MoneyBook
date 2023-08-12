using MoneyBook.DataProviders;
using MoneyBook.Models;

namespace MoneyBookTest
{
    public class AccountTypeDataProviderTest : BaseDataProviderTest<AccountType>
    {
        public AccountTypeDataProviderTest()
        {
            DataProvider = (AccountTypeDataProvider)DataProviderFactory.Create(typeof(AccountType));
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
            var item = Get(firstItem.AcctTypeId);
            Assert.IsTrue(firstItem.AcctTypeId == item.AcctTypeId);
        }
    }
}
