using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MoneyBookService.WebApi.Controllers
{
    [Route("api/")]
    public class AboutController : Controller
    {
        [HttpGet("v1/about")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(string))]
        public ActionResult<string> About()
        {
            return Startup.FullServiceName;
        }
    }
}
