using Microsoft.EntityFrameworkCore;
using Modelos.Models;
using PruebaDigitalWare.Models;

namespace PruebaDigitalWare.Data
{
    public class PruebaDbContext : DbContext
    {
        public PruebaDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
    }
}
