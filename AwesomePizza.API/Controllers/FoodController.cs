using System.Threading.Tasks;
using AwesomePizza.BL.Interfaces;
using AwesomePizza.Common.Models.Request;
using AwesomePizza.Common.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AwesomePizza.Controllers;

public class FoodController(ILogger<OrderController> logger, IFoodBs foodBs) : CommonControllerBase(logger)
{
    [HttpPost]
    [ProducesResponseType(typeof(SearchFoodResponse), StatusCodes.Status200OK)]
    [Route("")]
    public async Task<ActionResult<SearchFoodResponse>> Search([FromBody] SearchFoodRequest request)
    {
        logger.Log(LogLevel.Debug, "{@Method} started with request: {@Request}", System.Reflection.MethodBase.GetCurrentMethod()?.ReflectedType?.FullName, request);
        var response = await foodBs.Search(request);
        logger.Log(LogLevel.Debug, "{@Method} ended", System.Reflection.MethodBase.GetCurrentMethod()?.ReflectedType?.FullName);
        return Ok(response);
    }
}