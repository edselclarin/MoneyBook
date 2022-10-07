using Microsoft.AspNetCore.Mvc;
using MoneyBook.Models;
using MoneyBookApi.Data;

namespace MoneyBookApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(ILogger<CategoriesController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCategories")]
        public IEnumerable<Category> Get()
        {
            using (var db = new MoneyBookApiDbContext())
            {
                return db.Categories.ToArray();
            }
        }
    }
}
