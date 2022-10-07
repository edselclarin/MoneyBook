using Microsoft.AspNetCore.Mvc;
using MoneyBook.Models;
using MoneyBookApi.Data;

namespace MoneyBookApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly ILogger<AccountsController> _logger;

        public AccountsController(ILogger<AccountsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAccounts")]
        public IEnumerable<Account> Get()
        {
            using (var db = new MoneyBookApiDbContext())
            {
                return db.Accounts.ToArray();
            }
        }
    }
}
