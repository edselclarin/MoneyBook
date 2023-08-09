using MoneyBook.DataProviders;

namespace MoneyBookTest
{
    public abstract class BaseDataProviderTest<T>
    {
        protected IDataProvider<T> DataProvider { get; set; }

        public (int totalCount, int totalRetrieved) GetAll()
        {
            int take = 100;
            int skip = 0;
            int count = 0;

            var res = DataProvider.GetPagedAsync(skip, take).Result;
            Assert.IsNotNull(res, "res is null");

            while (res.Items != null && res.Count > 0)
            {
                skip += take;
                count += res.Count;

                res = DataProvider.GetPagedAsync(skip, take).Result;
                Assert.IsNotNull(res, "res is null");
            }

            Assert.IsTrue(count == res.Total);
            return (res.Total, count);
        }

        public T GetFirstItem()
        {
            var res = DataProvider.GetPagedAsync(0, 1).Result;
            Assert.IsNotNull(res, "res is null");
            Assert.IsTrue(res.Count == 1);

            return res.Items.FirstOrDefault();
        }

        public T Get(int id)
        {
            var item = DataProvider.GetAsync(id).Result;
            Assert.IsNotNull(item, "item is null");
            return item;
        }
    }
}
