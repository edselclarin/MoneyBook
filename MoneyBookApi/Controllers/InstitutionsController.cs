using Microsoft.AspNetCore.Mvc;
using MoneyBook.Models;
using MoneyBookApi.Data;

namespace MoneyBookApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstitutionsController : ControllerBase
    {
        private readonly ILogger<InstitutionsController> _logger;

        public InstitutionsController(ILogger<InstitutionsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetInstitutions")]
        public IEnumerable<Institution> Get()
        {
            using (var db = new MoneyBookApiDbContext())
            {
                return db.Institutions.ToList();
            }
        }
    }
}
