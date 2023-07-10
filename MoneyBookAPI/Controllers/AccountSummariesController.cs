using Microsoft.AspNetCore.Mvc;
using MoneyBookAPI.Data;
using MoneyBookAPI.Helpers;

namespace MoneyBookAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountSummariesController : Controller
    {
        private readonly ILogger<AccountSummariesController> _logger;
        private readonly MoneyBookDbContext _db = MoneyBookDbContext.Create(MoneyBookToolsDbContextConfig.Instance);

        public AccountSummariesController(ILogger<AccountSummariesController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAccountSummary")]
        public IActionResult Get(int acctId)
        {
            return Ok(_db.GetAccountSummary(acctId));
        }
    }
}
