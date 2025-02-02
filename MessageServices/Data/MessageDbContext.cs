using Microsoft.EntityFrameworkCore;
using MessageServices.Models;

namespace MessageServices.Data
{
    public class MessageDbContext : DbContext
    {
        public MessageDbContext(DbContextOptions<MessageDbContext> options) : base(options) { }

        public DbSet<Message> Messages { get; set; }
    }
}
