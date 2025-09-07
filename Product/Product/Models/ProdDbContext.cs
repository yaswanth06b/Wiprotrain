using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Product.Models
{
    public class ProdDbContext : IdentityDbContext
    {
        public ProdDbContext(DbContextOptions<ProdDbContext> options)
            : base(options) { }

        public DbSet<ProductModel> Products { get; set; }
    }
}

