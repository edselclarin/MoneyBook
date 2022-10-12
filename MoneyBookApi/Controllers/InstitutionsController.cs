using Microsoft.AspNetCore.Mvc;
using MoneyBook.BusinessModels;
using MoneyBook.Data;
using MoneyBookApi.Data;

namespace MoneyBookApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstitutionsController : ControllerBase
    {
        private readonly ILogger<InstitutionsController> _logger;
        private MoneyBookDbContext m_db;

        public InstitutionsController(ILogger<InstitutionsController> logger)
        {
            _logger = logger;

            m_db = MoneyBookDbContext.Create(MoneyBookApiDbContextConfig.Instance);
        }

        [HttpGet(Name = "GetInstitutions")]
        public async Task<IActionResult> Get([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var results = await m_db.GetInstitutionsAsync();

            var pagedData = results
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);

            var response = new PagedResponse<IEnumerable<InstitutionInfo>>(pagedData, validFilter.PageNumber, validFilter.PageSize)
            {
                TotalRecords = results.Count(),
                TotalPages = results.Count() / validFilter.PageSize
            };

            return Ok(response);
        }
    }
}
