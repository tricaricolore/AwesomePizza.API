using AwesomePizza.BL.Interfaces;
using AwesomePizza.Common;
using AwesomePizza.Common.Models.Dto;
using AwesomePizza.Common.Models.Request;
using AwesomePizza.Common.Models.Response;
using AwesomePizza.DL;
using AwesomePizza.DL.Models;
using Microsoft.EntityFrameworkCore;

namespace AwesomePizza.BL.Implementations;

public class OrderBs(AwesomePizzaDbContext dbContext) : IOrderBs
{
    /// <inheritdoc cref="IOrderBs.Upsert(UpsertOrderRequest)"/>
    public async Task<ResponseDto> Upsert(UpsertOrderRequest request)
    {
        await dbContext.Database.EnsureCreatedAsync();

        try
        {
            var status = await dbContext.Status
                .Where(item => item.Code == Constants.StatusType.StatusCreated)
                .Select(item => item.IdStatus)
                .SingleAsync();
            
            var entity = new Order()
            {
                Code = Guid.NewGuid(),
                FkStatus = status,
                CreationDate = DateTime.Now,
                CreationUser = string.Empty,
                Deleted = false
            };
            
            if (request.Id != null)
            {
                entity = await dbContext.Order
                    .Where(item => item.Code == request.Id && item.Deleted != true)
                    .SingleOrDefaultAsync();

                if (entity is null)
                {
                    throw new Exception();
                }
            }

            if (request.Status != null)
            {
                var newStatus = await dbContext.Status
                    .Where(item => item.Code == request.Status)
                    .Select(item => item.IdStatus)
                    .SingleAsync();
                
                entity.FkStatus = newStatus;
            }

            dbContext.Update(entity);
            await dbContext.SaveChangesAsync();

            return new ResponseDto(entity.Code.ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<SearchOrderResponse> Search(SearchOrderRequest request)
    {
        await dbContext.Database.EnsureCreatedAsync();

        try
        {
            var query = dbContext.Order
                .AsNoTracking()
                .AsQueryable();

            if (request.Status != null)
            {
                query = query
                    .Where(item => item.FkStatusNavigation != null && item.FkStatusNavigation.Code == request.Status);
            }

            if (request.Deleted != null)
            {
                query = query
                    .Where(item => item.Deleted == request.Deleted);
            }

            var totalItems = await query.CountAsync();

            if (request is { Page: > 0, PageSize: > 0 })
            {
                query = query
                    .Skip(request.PageSize * (request.Page - 1))
                    .Take(request.PageSize);
            }

            var response = new SearchOrderResponse()
            {
                Orders = await query
                    .Select(item => new OrderDto
                    {
                        Code = item.Code,
                        Status = item.FkStatusNavigation.Code,
                        Foods = item.Foods
                            .GroupBy(food => food.FkFoodNavigation.Code)
                            .Select(elem => new OrderFoodDto
                            {
                                Food = elem
                                    .Select(elem => new FoodDto
                                    {
                                        Code = elem.FkFoodNavigation.Code,
                                        Type = elem.FkFoodNavigation.FkTypeNavigation.Code,
                                        Name = elem.FkFoodNavigation.Name,
                                        Description = elem.FkFoodNavigation.Description,
                                        Price = elem.FkFoodNavigation.Price,
                                        Ingredients = elem.FkFoodNavigation.FoodIngredients
                                            .Select(foodIngredient => new LookupDto
                                            {
                                                Code = foodIngredient.FkIngredientNavigation.Code,
                                                Description = foodIngredient.FkIngredientNavigation.Description
                                            }).ToList()
                                    }).First(),
                                Amount = elem.Count()
                            }).ToList(),
                        CreationUser = item.CreationUser,
                        CreationDate = item.CreationDate,
                        ModificationDate = item.ModificationDate,
                        ModificationUser = item.ModificationUser,
                        DeletionDate = item.DeletionDate,
                        DeletionUser = item.DeletionUser,
                        Deleted = item.Deleted
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

    /// <inheritdoc cref="IOrderBs.Get(Guid)"/>
    public async Task<OrderDto> Get(Guid id)
    {
        try
        {
            await dbContext.Database.EnsureCreatedAsync();

            var entity = await dbContext.Order
                .Where(item => item.Code == id)
                .Select(item => new OrderDto
                {
                    Code = item.Code,
                    Status = item.FkStatusNavigation.Code,
                    Foods = item.Foods
                        .GroupBy(food => food.FkFoodNavigation.Code)
                        .Select(elem => new OrderFoodDto
                        {
                            Food = elem
                                .Select(elem => new FoodDto
                                {
                                    Code = elem.FkFoodNavigation.Code,
                                    Type = elem.FkFoodNavigation.FkTypeNavigation.Code,
                                    Name = elem.FkFoodNavigation.Name,
                                    Description = elem.FkFoodNavigation.Description,
                                    Price = elem.FkFoodNavigation.Price,
                                    Ingredients = elem.FkFoodNavigation.FoodIngredients
                                        .Select(foodIngredient => new LookupDto
                                        {
                                            Code = foodIngredient.FkIngredientNavigation.Code,
                                            Description = foodIngredient.FkIngredientNavigation.Description
                                        }).ToList()
                                }).First(),
                            Amount = elem.Count()
                        }).ToList(),
                    CreationUser = item.CreationUser,
                    CreationDate = item.CreationDate,
                    ModificationDate = item.ModificationDate,
                    ModificationUser = item.ModificationUser,
                    DeletionDate = item.DeletionDate,
                    DeletionUser = item.DeletionUser,
                    Deleted = item.Deleted
                })
                .SingleOrDefaultAsync();

            if (entity is null)
            {
                throw new Exception();
            }

            return entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <inheritdoc cref="IOrderBs.Delete(Guid)"/>
    public async Task<ResponseDto> Delete(Guid id)
    {
        try
        {
            await dbContext.Database.EnsureCreatedAsync();

            var entity = await dbContext.Order
                .Where(item => item.Code == id && item.Deleted != true)
                .FirstOrDefaultAsync();

            if (entity is null)
            {
                return new ResponseDto { Status = false };
            }

            var statusDeleted = await dbContext.Status
                .Where(item => item.Code == Constants.StatusType.StatusDeleted)
                .Select(item => item.IdStatus)
                .SingleAsync();

            entity.FkStatus = statusDeleted;
            entity.Deleted = true;
            entity.DeletionDate = DateTime.Now;
            entity.DeletionUser = string.Empty;

            await dbContext.SaveChangesAsync();
            
            return new ResponseDto(entity.Code.ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}