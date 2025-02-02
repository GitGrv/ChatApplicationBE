using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserServices.Data;
using UserServices.Models;

namespace UserServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDbContext _context;
        public UserController(UserDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("GetUserById/{userID}")]
        public async Task<IActionResult> GetUserById([FromRoute] Guid userID)
        {
            var user = await _context.Users.Where(u => u.UserID == userID).FirstOrDefaultAsync();
            if (user == null) return BadRequest("User not found");
            return Ok(user);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userExists= await _context.Users.Where(u=>u.Username == user.Username).FirstOrDefaultAsync();
            if (userExists != null) return BadRequest("Username already exists");
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok("User registered");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userdata = await _context.Users.Where(u => u.Username == login.Username && u.Password == login.Password).FirstOrDefaultAsync();
            if (userdata == null) return BadRequest("User not found");
            return Ok(userdata);
        }
    }
}
