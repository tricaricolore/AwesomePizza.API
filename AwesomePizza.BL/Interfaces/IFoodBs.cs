using AwesomePizza.Common.Models.Request;
using AwesomePizza.Common.Models.Response;

namespace AwesomePizza.BL.Interfaces;

public interface IFoodBs
{
    /// <summary>
    /// Search order from request
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<SearchFoodResponse> Search(SearchFoodRequest request);
}