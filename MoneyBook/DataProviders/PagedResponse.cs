namespace MoneyBook.DataProviders
{
    public class PagedResponse<T>
    {
        public IEnumerable<T>? Items { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
