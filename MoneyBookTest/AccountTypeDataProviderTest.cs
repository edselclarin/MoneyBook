using MoneyBook.DataProviders;
using MoneyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBookTest
{
    public class AccountTypeDataProviderTest : BaseDataProviderTest<AccountType>
    {
        [SetUp]
        public void Setup()
        {
            DataProvider = (AccountTypeDataProvider)DataProviderFactory.Create(typeof(AccountType));
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
            var item = Get(firstItem.AcctTypeId);
            Assert.IsTrue(firstItem.AcctTypeId == item.AcctTypeId);
        }
    }
}
