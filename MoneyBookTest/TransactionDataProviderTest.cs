using Autofac;
using MoneyBook;
using MoneyBook.DataProviders;
using MoneyBook.Models;

namespace MoneyBookTest
{
    public class TransactionDataProviderTest : BaseDataProviderTest<Transaction>
    {
        public TransactionDataProviderTest()
        {
            DataProvider = MoneyBookContainerBuilder.Container.Resolve<IDataProvider<Transaction>>();
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
            var item = Get(firstItem.TrnsId);
            Assert.IsTrue(firstItem.TrnsId == item.TrnsId);
        }
    }
}
