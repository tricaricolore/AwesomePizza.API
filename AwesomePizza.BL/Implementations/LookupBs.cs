using AwesomePizza.BL.Interfaces;
using AwesomePizza.Common.Models.Dto;
using AwesomePizza.DL;
using Microsoft.EntityFrameworkCore;

namespace AwesomePizza.BL.Implementations;

public class LookupBs(AwesomePizzaDbContext dbContext) : ILookupBs
{
    public async Task<List<LookupDto>> Status()
    {
        await dbContext.Database.EnsureCreatedAsync();

        try
        {
            var entities = await dbContext.Status
                .AsNoTracking()
                .Select(item => new LookupDto
                {
                    Code = item.Code,
                    Description = item.Description
                })
                .ToListAsync();

            return entities;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}