using Microsoft.AspNetCore.Mvc;
using MoneyBook.DataProviders;
using MoneyBook.Models;
using System.Net;

namespace MoneyBookService.WebApi.Controllers
{
    [Route("api/")]
    public class AccountsController : Controller
    {
        private AccountSummaryDataProvider dp_ = new();

        [HttpGet("v1/accounts/summaries")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(string))]
        public async Task<ActionResult<PagedResponse<AccountSummary>>> Summaries(int skip, int take, int? fkId = null, DateTime? dateTimeFrom = null)
        {
            var response = await dp_.GetPagedAsync(skip, take, fkId, dateTimeFrom);
            return response;
        }

        [HttpGet("v1/accounts/summary/{acctId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(string))]
        public async Task<ActionResult<AccountSummary>> Summary(int acctId)
        {
            var response = await dp_.GetAsync(acctId);
            return response;
        }
    }
}
