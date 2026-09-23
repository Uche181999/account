using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Account1.Data;
using Account1.Models;

namespace Account1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TransactionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/transactions
        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _context.Transactions.ToListAsync());

        // GET: api/transactions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            return transaction == null ? NotFound() : Ok(transaction);
        }

        // GET: api/transactions/user/3
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUser(int userId)
        {
            var transactions = await _context.Transactions
                .Where(t => t.UserId == userId)
                .ToListAsync();
            return Ok(transactions);
        }

        // POST: api/transactions
        [HttpPost]
        public async Task<IActionResult> Create(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = transaction.Id }, transaction);
        }

        // PUT: api/transactions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Transaction updated)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null) return NotFound();

            transaction.Date = updated.Date;
            transaction.Description = updated.Description;
            transaction.Amount = updated.Amount;
            transaction.Type = updated.Type;
            transaction.Category = updated.Category;
            transaction.FundSource = updated.FundSource;
            transaction.InvoiceId = updated.InvoiceId;

            await _context.SaveChangesAsync();
            return Ok(transaction);
        }

        // DELETE: api/transactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null) return NotFound();

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}