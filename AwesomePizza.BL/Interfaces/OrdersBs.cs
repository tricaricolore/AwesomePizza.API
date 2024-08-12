using AwesomePizza.Common.Models.Dto;
using AwesomePizza.Common.Models.Request;

namespace AwesomePizza.BL.Interfaces;

public interface IOrdersBs
{
    /// <summary>
    /// Upsert order from request
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<ResponseDto> Upsert(UpsertOrderRequest request);
    
    /// <summary>
    /// Get order from ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<OrderDto> Get(Guid id);
    
    /// <summary>
    /// Delete orders from ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<ResponseDto> Delete(Guid id);
}