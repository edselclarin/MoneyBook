using Microsoft.AspNetCore.Mvc;
using MoneyBook.BusinessModels;
using MoneyBook.Data;
using MoneyBookApi.Data;

namespace MoneyBookApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private MoneyBookDbContext m_db;

        public CategoriesController(ILogger<CategoriesController> logger)
        {
            _logger = logger;

            m_db = MoneyBookDbContext.Create(MoneyBookApiDbContextConfig.Instance);
        }

        [HttpGet(Name = "GetCategories")]
        public IActionResult Get([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var results = m_db.GetCategories();

            var pagedData = results
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);

            var response = new PagedResponse<IEnumerable<CategoryInfo>>(pagedData, validFilter.PageNumber, validFilter.PageSize)
            {
                TotalRecords = results.Count(),
                TotalPages = results.Count() / validFilter.PageSize
            };

            return Ok(response);
        }
    }
}
