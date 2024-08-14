using AwesomePizza.BL.Interfaces;
using AwesomePizza.Common.Models.Dto;
using AwesomePizza.Common.Models.Request;
using AwesomePizza.Common.Models.Response;
using AwesomePizza.DL;
using Microsoft.EntityFrameworkCore;

namespace AwesomePizza.BL.Implementations;

public class FoodBs(AwesomePizzaDbContext dbContext): IFoodBs
{
    public async Task<SearchFoodResponse> Search(SearchFoodRequest request)
    {
        await dbContext.Database.EnsureCreatedAsync();

        try
        {
            var query = dbContext.Food
                .AsNoTracking()
                .AsQueryable();

            var totalItems = await query.CountAsync();

            if (request is { Page: > 0, PageSize: > 0 })
            {
                query = query
                    .Skip(request.PageSize * (request.Page - 1))
                    .Take(request.PageSize);
            }

            var response = new SearchFoodResponse()
            {
                Foods = await query
                    .Select(item => new FoodDto()
                    {
                        Code = item.Code,
                        Type = item.FkTypeNavigation.Code,
                        Name = item.Name,
                        Description = item.Description,
                        Ingredients = item.FoodIngredients
                            .Select(elem => new LookupDto
                            {
                                Code = elem.FkIngredientNavigation.Code,
                                Description = elem.FkIngredientNavigation.Description
                            }).ToList()
                    }).ToListAsync(),
                TotalItems = totalItems,
                Page = request.Page,
                PageSize = request.PageSize
            };

            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}