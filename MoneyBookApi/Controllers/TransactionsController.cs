using Microsoft.AspNetCore.Mvc;
using MoneyBook.BusinessModels;
using MoneyBook.Data;
using MoneyBookApi.Data;

namespace MoneyBookApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ILogger<TransactionsController> _logger;
        private MoneyBookDbContext m_db;

        public TransactionsController(ILogger<TransactionsController> logger)
        {
            _logger = logger;

            m_db = MoneyBookDbContext.Create(MoneyBookApiDbContextConfig.Instance);
        }

        [HttpGet(Name = "GetTransactions")]
        public IActionResult Get([FromQuery] PaginationFilter filter, int acctId)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var results = m_db.GetTransactions(acctId);

            var pagedData = results
                           .Skip((filter.PageNumber - 1) * filter.PageSize)
                           .Take(filter.PageSize);

            var response = new PagedResponse<IEnumerable<TransactionInfo>>(pagedData, validFilter.PageNumber, validFilter.PageSize)
            {
                TotalRecords = results.Count(),
                TotalPages = results.Count() / validFilter.PageSize
            };

            return Ok(response);
        }
    }
}
