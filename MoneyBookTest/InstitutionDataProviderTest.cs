using Autofac;
using MoneyBook;
using MoneyBook.DataProviders;
using MoneyBook.Models;

namespace MoneyBookTest
{
    public class InstitutionDataProviderTest : BaseDataProviderTest<Institution>
    {
        public InstitutionDataProviderTest()
        {
            DataProvider = MoneyBookContainerBuilder.Container.Resolve<IDataProvider<Institution>>();
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
            var item = Get(firstItem.InstId);
            Assert.IsTrue(firstItem.InstId == item.InstId);
        }
    }
}
