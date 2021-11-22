using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BootApp.Code;

public class BootAppDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    
    public BootAppDbContext(DbContextOptions options) : base(options){}
}