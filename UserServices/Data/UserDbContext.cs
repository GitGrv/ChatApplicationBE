using Microsoft.EntityFrameworkCore;
using UserServices.Models;

namespace UserServices.Data
{
    public class UserDbContext:DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
