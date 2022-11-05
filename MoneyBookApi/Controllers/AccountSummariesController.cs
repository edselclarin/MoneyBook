using Microsoft.AspNetCore.Mvc;
using MoneyBook.BusinessModels;
using MoneyBook.Data;
using MoneyBookApi.Data;

namespace MoneyBookApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountSummariesController : ControllerBase
    {
        private readonly ILogger<AccountSummariesController> _logger;
        private MoneyBookDbContext m_db;

        public AccountSummariesController(ILogger<AccountSummariesController> logger)
        {
            _logger = logger;

            m_db = MoneyBookDbContext.Create(MoneyBookApiDbContextConfig.Instance);
        }

        [HttpGet(Name = "GetAccountSummary")]
        public IActionResult Get(int acctId)
        {
            var summary = m_db.GetAccountSummary(acctId);
    
            return Ok(summary);
        }
    }
}
