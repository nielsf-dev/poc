using Microsoft.EntityFrameworkCore;

namespace EntityFramework.MyAW
{
    // Word dus elke keer aangemaakt per request. Elke keer een controller construction
    public class MyAWContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }
        public DbSet<ProductSubCategory> SubCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=localhost;Database=AdventureWorks2019;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product", "Production");
            modelBuilder.Entity<ProductCategory>().ToTable("ProductCategory", "Production");
            modelBuilder.Entity<ProductSubCategory>().ToTable("ProductSubCategory", "Production");
        }
    }
}