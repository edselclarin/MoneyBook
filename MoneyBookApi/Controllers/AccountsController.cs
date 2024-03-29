﻿using Microsoft.AspNetCore.Mvc;
using MoneyBook.BusinessModels;
using MoneyBook.Data;
using MoneyBookApi.Data;

namespace MoneyBookApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly ILogger<AccountsController> _logger;
        private MoneyBookDbContext m_db;

        public AccountsController(ILogger<AccountsController> logger)
        {
            _logger = logger;

            m_db = MoneyBookDbContext.Create(MoneyBookApiDbContextConfig.Instance);
        }

        [HttpGet(Name = "GetAccountBrief")]
        public IActionResult Get(int acctId)
        {
            var brief = m_db.GetAccountBrief(acctId);

            return Ok(brief);
        }
    }
}
