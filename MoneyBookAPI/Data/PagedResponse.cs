namespace MoneyBookAPI.Data
{
    public class PagedResponse<T>
    {
        public List<T> Data { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
    }

    public static class PagedResponseDefs
    {
        public const int DefaultPage = 1;
        public const int DefaultPageSize = 10;
    }
}
