using Microsoft.EntityFrameworkCore;
using RetailApi.Models;

namespace RetailApi.Data
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions<ProductsContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}