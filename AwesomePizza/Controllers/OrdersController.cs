using Microsoft.AspNetCore.Mvc;

namespace AwesomePizza.Controllers;

public class OrdersController(ILogger<OrdersController> logger) : CommonControllerBase(logger)
{
    
    [HttpDelete]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [Route("[action]/{id:guid}")]
    public IActionResult Delete([FromRoute] Guid id)
    {
        logger.Log(LogLevel.Debug, "{@Method} started with request: {@Request}", System.Reflection.MethodBase.GetCurrentMethod()?.ReflectedType?.FullName, id);
        //BL
        logger.Log(LogLevel.Debug, "{@Method} ended", System.Reflection.MethodBase.GetCurrentMethod()?.ReflectedType?.FullName);
        return Ok(true);
    }
}