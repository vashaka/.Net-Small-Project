using Market.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Title = "Macbook 2024", Description = "Check Out Our Brand New Macbook Pro", Price = 3500 },
                new Product { Id = 2, Title = "Macbook 2022", Description = "Check Out Our almost Brand New Macbook Pro", Price = 3000 },
                new Product { Id = 3, Title = "Macbook 2020", Description = "Check Out Our Old Macbook Pro", Price = 2000 }
            );

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }

    }
}