using AwesomePizza.BL.Interfaces;
using AwesomePizza.Common.Models.Dto;
using AwesomePizza.DL;
using Microsoft.EntityFrameworkCore;

namespace AwesomePizza.BL.Implementations;

public class OrdersBs(AwesomePizzaDbContext dbContext) : IOrdersBs
{
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
            
            return new ResponseDto(entity.IdOrders.ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}