using Account1.Data;
using Account1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Account1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = await _context.Users.FirstOrDefaultAsync();
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUPdate(User user)
        {
            var existing = await _context.Users.FirstOrDefaultAsync();
            if (existing == null)
            {
                _context.Users.Add(user);
            }
            else
            {
                existing.Name = user.Name;
                existing.Type = user.Type;
                existing.BusinessName = user.BusinessName;
                existing.Country = user.Country;
                existing.Phone = user.Phone;
                existing.Email = user.Email;
                existing.TaxId = user.TaxId;
            }
            await _context.SaveChangesAsync();
            return Ok(existing ?? user);
        }
    }
}