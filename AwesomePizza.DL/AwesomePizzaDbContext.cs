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
        modelBuilder.Entity<FoodType>().HasData(SeedData<FoodType>(nameof(FoodType)));
        modelBuilder.Entity<Ingredient>().HasData(SeedData<Ingredient>(nameof(Ingredient)));
        modelBuilder.Entity<Food>().HasData(SeedData<Food>(nameof(Food)));
        modelBuilder.Entity<FoodIngredient>().HasData(SeedData<FoodIngredient>(nameof(FoodIngredient)));
        modelBuilder.Entity<Order>().HasData(SeedData<Order>(nameof(Order)));
        modelBuilder.Entity<OrderFood>().HasData(SeedData<OrderFood>(nameof(OrderFood)));
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
    public virtual DbSet<Food> Food => Set<Food>();
    public virtual DbSet<FoodType> FoodType => Set<FoodType>();
    public virtual DbSet<Ingredient> Ingredient => Set<Ingredient>();
    public virtual DbSet<FoodIngredient> FoodIngredient => Set<FoodIngredient>();
    public virtual DbSet<OrderFood> OrderFood => Set<OrderFood>();
}