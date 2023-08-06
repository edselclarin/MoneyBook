namespace MoneyBook.DataProviders
{
    public class PagedResponse<T>
    {
        public IEnumerable<T>? Items { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public int? FKId { get; set; }
        public DateTime? DateTimeFrom { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }
    }
}
