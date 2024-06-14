// Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using SampleWeb.Models;

namespace SampleWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}