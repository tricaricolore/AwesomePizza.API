using AwesomePizza.DL.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AwesomePizza.DL;

public class AwesomePizzaDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Status>().HasData(SeedData<Status>(nameof(Status)));
        modelBuilder.Entity<Order>().HasData(SeedData<Order>(nameof(Order)));
    }

    private static List<T> SeedData<T>(string tableName)
    {
        using var streamReader = new StreamReader($"../AwesomePizza.DL/Data/{tableName}Data.json");
        var json = streamReader.ReadToEnd();
        var data = JsonConvert.DeserializeObject<List<T>>(json);
        return data ?? [];
    }
    
    public virtual DbSet<Order> Order => Set<Order>();
    public virtual DbSet<Status> Status => Set<Status>();
}