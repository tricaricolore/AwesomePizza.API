using AwesomePizza.BL.Interfaces;
using AwesomePizza.Common.Models.Dto;
using AwesomePizza.Common.Models.Request;
using AwesomePizza.DL;
using AwesomePizza.DL.Models;
using Microsoft.EntityFrameworkCore;

namespace AwesomePizza.BL.Implementations;

public class OrdersBs(AwesomePizzaDbContext dbContext) : IOrdersBs
{
    public async Task<ResponseDto> Upsert(UpsertOrderRequest request)
    {
        await dbContext.Database.EnsureCreatedAsync();

        try
        {
            var entity = new TbOrders()
            {
                Code = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                CreationUser = string.Empty,
                Deleted = false
            };
            
            if (request.Id != null)
            {
                entity = await dbContext.TbOrders
                    .Where(item => item.Code == request.Id && item.Deleted != true)
                    .SingleOrDefaultAsync();

                if (entity is null)
                {
                    throw new Exception();
                }
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

    /// <inheritdoc cref="IOrdersBs.Get(Guid)"/>
    public async Task<OrderDto> Get(Guid id)
    {
        try
        {
            await dbContext.Database.EnsureCreatedAsync();

            var entity = await dbContext.TbOrders
                .Where(item => item.Code == id && item.Deleted != true)
                .Select(item => new OrderDto
                {
                    Code = item.Code,
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

    /// <inheritdoc cref="IOrdersBs.Delete(Guid)"/>
    public async Task<ResponseDto> Delete(Guid id)
    {
        try
        {
            await dbContext.Database.EnsureCreatedAsync();

            var entity = await dbContext.TbOrders
                .Where(item => item.Code == id && item.Deleted != true)
                .FirstOrDefaultAsync();

            if (entity is null)
            {
                return new ResponseDto { Status = false };
            }

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