﻿using Microsoft.AspNetCore.Mvc;
using MoneyBookApi.Data;
using MoneyBookApi.Models;

namespace MoneyBookApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ILogger<TransactionsController> _logger;
        private MoneyBookApiDbContext m_db;

        public TransactionsController(ILogger<TransactionsController> logger)
        {
            _logger = logger;

            m_db = new MoneyBookApiDbContext();
        }

        [HttpGet(Name = "GetTransactions")]
        public async Task<IActionResult> Get([FromQuery] PaginationFilter filter, int acctId)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var results = await m_db.GetTransactionsAsync(acctId);

            var pagedData = results
                           .Skip((filter.PageNumber - 1) * filter.PageSize)
                           .Take(filter.PageSize);

            var response = new PagedResponse<IEnumerable<TransactionInfo>>(pagedData, validFilter.PageNumber, validFilter.PageSize)
            {
                TotalRecords = results.Count(),
                TotalPages = results.Count() / validFilter.PageSize
            };

            return Ok(response);
        }
    }
}