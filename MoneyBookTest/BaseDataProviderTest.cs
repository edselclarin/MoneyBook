using MoneyBook.Data;
using MoneyBook.DataProviders;

namespace MoneyBookTest
{
    public abstract class BaseDataProviderTest<T>
    {
        protected IDataProvider<T> DataProvider { get; set; }

        public MoneyBookDbTransaction CreateDbTransaction()
        {
            return DataProvider.CreateDbTransaction();
        }

        public List<T> GetAllItems()
        {
            return GetAllItemsPaged().items;
        }

        public (int totalCount, int totalRetrieved, List<T> items) GetAllItemsPaged()
        {
            var items = new List<T>();
            int take = 100;
            int skip = 0;
            int count = 0;

            var res = DataProvider.GetPagedAsync(skip, take).Result;
            Assert.IsNotNull(res, "res is null");

            while (res.Items != null && res.Count > 0)
            {
                skip += take;
                count += res.Count;
                items.AddRange(res.Items);

                res = DataProvider.GetPagedAsync(skip, take).Result;
                Assert.IsNotNull(res, "res is null");
            }

            Assert.IsTrue(count == res.Total);
            return (res.Total, count, items);
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

        public T Find(T item)
        {
            return DataProvider.FindAsync(item).Result;
        }

        public T Insert(T item)
        {
            var existingItem = DataProvider.FindAsync(item).Result;
            Assert.IsNull(existingItem, "item already exists");
            return DataProvider.UpsertAsync(item).Result;
        }

        public T Update(int id, T item)
        {
            var existingItem = DataProvider.GetAsync(id).Result;
            Assert.IsNotNull(existingItem, $"item not found, id={id}");
            return DataProvider.UpsertAsync(item).Result;
        }

        public void Delete(int id)
        {
            var item = DataProvider.GetAsync(id).Result;
            Assert.IsNotNull(item, $"item not found, id={id}");
            DataProvider.DeleteAsync(id);
        }
    }
}
