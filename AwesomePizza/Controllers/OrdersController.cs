using System;
using System.Threading.Tasks;
using AwesomePizza.BL.Interfaces;
using AwesomePizza.Common.Models.Dto;
using AwesomePizza.Common.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AwesomePizza.Controllers;

public class OrdersController(ILogger<OrdersController> logger, IOrdersBs ordersBs) : CommonControllerBase(logger)
{
    [HttpPut]
    [ProducesResponseType(typeof(ResponseDto), StatusCodes.Status200OK)]
    [Route("")]
    public async Task<IActionResult> Upsert([FromBody] UpsertOrderRequest request)
    {
        logger.Log(LogLevel.Debug, "{@Method} started with request: {@Request}", System.Reflection.MethodBase.GetCurrentMethod()?.ReflectedType?.FullName, request);
        var response = await ordersBs.Upsert(request);
        logger.Log(LogLevel.Debug, "{@Method} ended", System.Reflection.MethodBase.GetCurrentMethod()?.ReflectedType?.FullName);
        return Ok(response);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
    [Route("{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        logger.Log(LogLevel.Debug, "{@Method} started with request: {@Request}", System.Reflection.MethodBase.GetCurrentMethod()?.ReflectedType?.FullName, id);
        var response = await ordersBs.Get(id);
        logger.Log(LogLevel.Debug, "{@Method} ended", System.Reflection.MethodBase.GetCurrentMethod()?.ReflectedType?.FullName);
        return Ok(response);
    }
    
    [HttpDelete]
    [ProducesResponseType(typeof(ResponseDto), StatusCodes.Status200OK)]
    [Route("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        logger.Log(LogLevel.Debug, "{@Method} started with request: {@Request}", System.Reflection.MethodBase.GetCurrentMethod()?.ReflectedType?.FullName, id);
        var response = await ordersBs.Delete(id);
        logger.Log(LogLevel.Debug, "{@Method} ended", System.Reflection.MethodBase.GetCurrentMethod()?.ReflectedType?.FullName);
        return Ok(response);
    }
}