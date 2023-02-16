using Microsoft.EntityFrameworkCore;
using Razor.WebPages.Models;

namespace Razor.WebPages.Sevices
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
