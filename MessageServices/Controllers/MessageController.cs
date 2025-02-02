using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageServices.Data;
using MessageServices.Models;

namespace MessageServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly MessageDbContext _context;

        public MessageController(MessageDbContext context)
        {
            _context = context;
        }

        // 1. Send a new message
        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] Message message)
        {
            if (message == null || string.IsNullOrWhiteSpace(message.MessageContent))
                return BadRequest("Invalid message data.");

            message.MessageID = Guid.NewGuid();
            message.Timestamp = DateTime.UtcNow;

            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Message sent successfully!" });
        }

        // 2. Get messages for a specific user
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetMessagesByUser(Guid userId)
        {
            var messages = await _context.Messages
                .Where(m => m.SenderID == userId || m.ReceiverID == userId)
                .OrderByDescending(m => m.Timestamp)
                .ToListAsync();

            return Ok(messages);
        }
    }
}
