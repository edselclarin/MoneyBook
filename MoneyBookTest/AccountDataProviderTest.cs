using MoneyBook.DataProviders;
using MoneyBook.Models;

namespace MoneyBookTest
{
    public class AccountDataProviderTest : BaseDataProviderTest<Account>
    {
        public AccountDataProviderTest()
        {
            DataProvider = (AccountDataProvider)DataProviderFactory.Create(typeof(Account));
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
            var item = Get(firstItem.AcctId);
            Assert.IsTrue(firstItem.AcctId == item.AcctId);
        }


        //[Test]
        //public void InsertUpdateDelete()
        //{
        //    var acctTypesDataProviderTest = new AccountTypeDataProviderTest();
        //    Assert.IsNotNull(acctTypesDataProviderTest, "acctTypesDataProviderTest is null");

        //    var acctType = acctTypesDataProviderTest.GetAllItems()
        //        .SingleOrDefault(x => x.TypeName.Equals("checking", StringComparison.InvariantCultureIgnoreCase));
        //    Assert.IsNotNull(acctType, "acctType is null");

        //    var newAcct = new Account()
        //    {
        //        Name = "TEST ACCOUNT",
        //        AcctTypeId = acctType.AcctTypeId,
        //        StartingBalance = 0m,
        //        DateAdded = DateTime.Now,
        //        DateModified = DateTime.Now,
        //        ExtAcctId = "111",
        //        InstId = 0, //TODO need this
        //    };
        //}
    }
}
