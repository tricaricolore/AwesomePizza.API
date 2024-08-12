using AwesomePizza.Common.Models.Dto;
using AwesomePizza.Common.Models.Request;
using AwesomePizza.Common.Models.Response;

namespace AwesomePizza.BL.Interfaces;

public interface IOrderBs
{
    /// <summary>
    /// Upsert order from request
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<ResponseDto> Upsert(UpsertOrderRequest request);
    
    /// <summary>
    /// Search order from request
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<SearchOrderResponse> Search(SearchOrderRequest request);
    
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