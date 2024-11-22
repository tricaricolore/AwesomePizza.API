using System.Net;
using AwesomePizza.BL.Implementations;
using AwesomePizza.BL.Interfaces;
using AwesomePizza.DL;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

//services to the container
builder.Services.AddTransient<IFoodBs, FoodBs>();
builder.Services.AddTransient<IOrderBs, OrderBs>();
builder.Services.AddTransient<ILookupBs, LookupBs>();

// Register DbContext and provide ConnectionString
builder.Services.AddDbContext<AwesomePizzaDbContext>(optionsAction =>
    optionsAction.UseInMemoryDatabase(builder.Configuration.GetConnectionString("AwesomePizzaDb")!)
);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddScoped<IFoodBs, FoodBs>();
builder.Services.AddScoped<IOrderBs, OrderBs>();
builder.Services.AddScoped<ILookupBs, LookupBs>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AnyOrigin", policyBuilder =>
    {
        policyBuilder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

app.UseCors("AnyOrigin");

app.Run();