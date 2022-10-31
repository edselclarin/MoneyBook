using Microsoft.AspNetCore.Mvc;
using MoneyBook.BusinessModels;
using MoneyBook.Data;
using MoneyBookApi.Data;

namespace MoneyBookApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecurringTransactionsController : ControllerBase
    {
        private readonly ILogger<RecurringTransactionsController> _logger;
        private MoneyBookDbContext m_db;

        public RecurringTransactionsController(ILogger<RecurringTransactionsController> logger)
        {
            _logger = logger;

            m_db = MoneyBookDbContext.Create(MoneyBookApiDbContextConfig.Instance);
        }

        [HttpGet(Name = "GetRecurringTransactions")]
        public IActionResult Get([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var results = m_db.GetRecurringTransactions(MoneyBookDbContextExtension.SortOrder.Ascending);

            var pagedData = results
                           .Skip((filter.PageNumber - 1) * filter.PageSize)
                           .Take(filter.PageSize);

            var response = new PagedResponse<IEnumerable<RecurringTransactionInfo>>(pagedData, validFilter.PageNumber, validFilter.PageSize)
            {
                TotalRecords = results.Count(),
                TotalPages = results.Count() / validFilter.PageSize
            };

            return Ok(response);
        }
    }
}
