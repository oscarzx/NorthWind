using NorthWind.Entities;
using NorthWind.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace NorthWind.DAL;

public class NorthWindContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Log> Logs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = HelperConfiguration.GetAppConfiguration()
            .ConnectionString;

        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .Property(c => c.CategoryName)
            .HasMaxLength(15)
            .IsRequired();

        modelBuilder.Entity<Product>()
            .Property(p => p.ProductName)
            .HasMaxLength(40)
            .IsRequired();

        modelBuilder.Entity<Log>
            (
                l =>
                {
                    l.Property(p => p.DateTime)
                    .HasDefaultValueSql("getDate()");
                    l.Property(p => p.Type)
                    .HasConversion(new EnumToStringConverter<LogType>())
                    .HasMaxLength(20);
                }
            );
    }
}
