using System;
using System.Threading.Tasks;
using CivMoney.Services.Contracts;
using CivMoney.Services.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CivMoney.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TransactionDto transaction)
        {
            await _transactionService.AddTransaction(transaction);

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Date([FromQuery] DateTime date)
        {
            var transactions = await _transactionService.GetTransactionsForDate(date);

            return Ok(transactions);
        }
    }
}