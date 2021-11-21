using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BootApp.Code;

public class BootAppDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();

        optionsBuilder.UseSqlServer(
            @"Server=localhost;Database=BootApp;Integrated Security=True");
    }
}