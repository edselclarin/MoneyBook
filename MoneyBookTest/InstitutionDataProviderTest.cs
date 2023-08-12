using MoneyBook.DataProviders;
using MoneyBook.Models;

namespace MoneyBookTest
{
    public class InstitutionDataProviderTest : BaseDataProviderTest<Institution>
    {
        public InstitutionDataProviderTest()
        {
            DataProvider = (InstitutionDataProvider)DataProviderFactory.Create(typeof(Institution));
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
