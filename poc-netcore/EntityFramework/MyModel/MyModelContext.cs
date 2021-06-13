using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Extensions.Logging;

namespace EntityFramework.MyModel
{
    public class MyModelContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Persoon> Personen { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serilogLoggerFactory = new SerilogLoggerFactory(Log.Logger);
            optionsBuilder.UseLoggerFactory(serilogLoggerFactory);

            optionsBuilder.UseLazyLoadingProxies();

            optionsBuilder.UseSqlServer(
                @"Server=localhost;Database=MyModel;Integrated Security=True");
        }
    }
}