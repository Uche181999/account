using Account1.Data;
using Account1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Account1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UsersController(AppDbContext context)
        {
            _context = context;
        }
        // GET all users (admin/dev view)
        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _context.Users.ToListAsync());

        // GET one specific user
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user == null ? NotFound() : Ok(user);
        }

        // POST — always creates a new user now
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        // PUT — update a specific user by id
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, User updated)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            user.Name = updated.Name;
            user.Type = updated.Type;
            user.BusinessName = updated.BusinessName;
            user.Country = updated.Country;
            user.Phone = updated.Phone;
            user.Email = updated.Email;
            user.TaxId = updated.TaxId;

            await _context.SaveChangesAsync();
            return Ok(user);
        }

        // DELETE a specific user by id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}