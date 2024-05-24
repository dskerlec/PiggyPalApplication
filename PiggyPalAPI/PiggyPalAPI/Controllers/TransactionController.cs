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
