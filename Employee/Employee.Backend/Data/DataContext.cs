using Employee.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employee.Backend.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Clerk> Clerks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Clerk>().HasIndex(x => x.FirstName).IsUnique();
        modelBuilder.Entity<Clerk>().HasIndex(x => x.LastName).IsUnique();
    }
}