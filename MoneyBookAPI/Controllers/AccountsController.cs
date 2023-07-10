using Microsoft.AspNetCore.Mvc;
using MoneyBookAPI.Data;
using MoneyBookAPI.Helpers;

namespace MoneyBookAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly ILogger<AccountSummariesController> _logger;
        private readonly MoneyBookDbContext _db = MoneyBookDbContext.Create(MoneyBookToolsDbContextConfig.Instance);

        public AccountsController(ILogger<AccountSummariesController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAccounts")]
        public IActionResult Get(int page = PagedResponseDefs.DefaultPage, int pageSize = PagedResponseDefs.DefaultPageSize)
        {
            return Ok(_db.GetAccounts(page, pageSize));
        }
    }
}
