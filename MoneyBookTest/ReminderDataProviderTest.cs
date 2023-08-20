using MoneyBook;
using MoneyBook.DataProviders;
using MoneyBook.Models;

namespace MoneyBookTest
{
    public class ReminderDataProviderTest : BaseDataProviderTest<Reminder>
    {
        public ReminderDataProviderTest()
        {
            DataProvider = (IDataProvider<Reminder>)MoneyBookServices.ServiceProvider.GetService(typeof(IDataProvider<Reminder>));
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
            var item = Get(firstItem.RmdrId);
            Assert.IsTrue(firstItem.RmdrId == item.RmdrId);
        }
    }
}
