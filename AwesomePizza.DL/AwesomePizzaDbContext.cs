using AwesomePizza.DL.Models;
using Microsoft.EntityFrameworkCore;

namespace AwesomePizza.DL;

public class AwesomePizzaDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbOrders>().HasData(
            new TbOrders()
            {
                IdOrders = 1,
                Code = new Guid("3deeb622-82e4-48cb-9e25-2076a4073e2b"),
                CreationDate = DateTime.Now,
                CreationUser = "Test User"
            }
        );
    }
    
    public virtual DbSet<TbOrders> TbOrders => Set<TbOrders>();
}