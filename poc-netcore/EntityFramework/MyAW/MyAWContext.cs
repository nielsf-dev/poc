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
            optionsBuilder
                .UseLazyLoadingProxies();

            optionsBuilder.UseSqlServer(
                @"Server=localhost;Database=AdventureWorks2019;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product", "Production");
            //    .Property("Id").HasColumnName("ProductId");

             // modelBuilder.Entity<Product>()
             //     .HasOne(p => p.ProductSubCategory)
             //     .WithMany(ps => ps.Products)
             //     .HasForeignKey(p => p.ProductSubCategoryId);

            // modelBuilder.Entity<Product>()
            //     .Navigation(p => p.ProductSubCategory)
            //     .UsePropertyAccessMode(PropertyAccessMode.Property);

            //modelBuilder.Entity<ProductSubCategory>()
            //   .HasOne(p => p.ProductSubCategory);


            // modelBuilder.Entity<ProductCategory>().ToTable("ProductCategory", "Production");
            //
            // modelBuilder.Entity<ProductSubCategory>()
            //     .Property(p => p.Id).HasColumnName("ProductSubcategoryID");
            //
            modelBuilder.Entity<ProductSubCategory>().ToTable("ProductSubCategory", "Production");
            //   .Property("Id").HasColumnName("ProductSubCategoryId");


        }
    }
}