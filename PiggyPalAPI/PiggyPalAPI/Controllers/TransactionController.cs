using Microsoft.AspNetCore.Mvc;
using PiggyPalAPI.Interfaces;
using PiggyPalAPI.Models;

namespace PiggyPalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : Controller
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionModel>>> GetAll()
        {
            return Ok(await _transactionRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TransactionModel>>> GetById(int id)
        {
            var transaction = await _transactionRepository.GetById(id);
            return transaction == null ? NotFound() : Ok(transaction);
        }

        [HttpGet("byDate/{date}")]
        public async Task<ActionResult<IEnumerable<TransactionModel>>> GetByDate(DateOnly date)
        {
            var transactions = await _transactionRepository.GetByDate(date);
            return transactions == null || !transactions.Any() ? NotFound() : Ok(transactions);
        }

        [HttpGet("byAmount/{amount}")]
        public async Task<ActionResult<IEnumerable<TransactionModel>>> GetByAmount(decimal amount)
        {
            var transactions = await _transactionRepository.GetByAmount(amount);
            return transactions == null || !transactions.Any() ? NotFound() : Ok(transactions);
        }

        [HttpGet("byCategory/{categoryId}")]
        public async Task<ActionResult<IEnumerable<TransactionModel>>> GetByCategory(int categoryId)
        {
            var transactions = await _transactionRepository.GetByCategory(categoryId);
            return transactions == null || !transactions.Any() ? NotFound() : Ok(transactions);
        }

        [HttpGet("byCategory/{categoryName}")]
        public async Task<ActionResult<IEnumerable<TransactionModel>>> GetByCategoryName(int categoryId)
        {
            var transactions = await _transactionRepository.GetByCategory(categoryId);
            return transactions == null || !transactions.Any() ? NotFound() : Ok(transactions);
        }

        [HttpGet("byDescription/{description}")]
        public async Task<ActionResult<IEnumerable<TransactionModel>>> GetByDescription(string description)
        {
            var transactions = await _transactionRepository.GetByDescription(description);
            return transactions == null || !transactions.Any() ? NotFound() : Ok(transactions);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TransactionModel transaction)
        {
            if (id != transaction.TransactionId)
            {
                return BadRequest();
            }

            var transactionToUpdate = await _transactionRepository.GetById(id);
            if (transactionToUpdate == null)
            {
                return NotFound();
            }

            await _transactionRepository.Update(transaction);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var transactionToDelete = await _transactionRepository.GetById(id);
            if (transactionToDelete == null)
            {
                return NotFound();
            }

            await _transactionRepository.Delete(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> Add(TransactionModel transaction)
        {
            await _transactionRepository.Add(transaction);
            return CreatedAtAction(nameof(GetById), new { id = transaction.TransactionId }, transaction);
        }

    }
}
