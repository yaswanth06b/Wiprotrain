using Microsoft.EntityFrameworkCore;

namespace PrepTest3.Models
{
    public class PrepDbContext : DbContext
    {
            public PrepDbContext(DbContextOptions<PrepDbContext> options) : base(options) { }

            public DbSet<Admin> Admins { get; set; }
            public DbSet<User> Users { get; set; }
        }
}
