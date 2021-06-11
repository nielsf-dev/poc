using Microsoft.EntityFrameworkCore;

namespace EntityFramework.MyModel
{
    public class MyModelContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=localhost;Database=MyModel;Integrated Security=True");
        }
    }
}