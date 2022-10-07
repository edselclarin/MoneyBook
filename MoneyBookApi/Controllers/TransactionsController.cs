using Microsoft.AspNetCore.Mvc;
using MoneyBook.Models;
using MoneyBookApi.Data;

namespace MoneyBookApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ILogger<TransactionsController> _logger;

        public TransactionsController(ILogger<TransactionsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTransactions")]
        public IEnumerable<Transaction> Get()
        {
            using (var db = new MoneyBookApiDbContext())
            {
                return db.Transactions.Take(50).ToArray();
            }
        }
    }
}
