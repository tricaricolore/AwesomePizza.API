using System;
using System.Threading.Tasks;
using AwesomePizza.BL.Interfaces;
using AwesomePizza.Common.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AwesomePizza.Controllers;

public class OrdersController(ILogger<OrdersController> logger, IOrdersBs ordersBs) : CommonControllerBase(logger)
{
    
    [HttpDelete]
    [ProducesResponseType(typeof(ResponseDto), StatusCodes.Status200OK)]
    [Route("[action]/{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        logger.Log(LogLevel.Debug, "{@Method} started with request: {@Request}", System.Reflection.MethodBase.GetCurrentMethod()?.ReflectedType?.FullName, id);
        var response = await ordersBs.Delete(id);
        logger.Log(LogLevel.Debug, "{@Method} ended", System.Reflection.MethodBase.GetCurrentMethod()?.ReflectedType?.FullName);
        return Ok(response);
    }
}