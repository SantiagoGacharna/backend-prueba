using Microsoft.EntityFrameworkCore;
using PruebaDigitalWare.Models;

namespace PruebaDigitalWare.Data
{
    public class PruebaDbContext : DbContext
    {
        public PruebaDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
    }
}
