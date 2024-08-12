using System.Collections.Generic;
using System.Threading.Tasks;
using AwesomePizza.BL.Interfaces;
using AwesomePizza.Common.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AwesomePizza.Controllers;

public class LookupController(ILogger<LookupController> logger, ILookupBs lookupBs) : CommonControllerBase(logger)
{
    [HttpGet]
    [ProducesResponseType(typeof(List<LookupDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<LookupDto>>> Status()
    {
        logger.Log(LogLevel.Debug, "{@Method} started", System.Reflection.MethodBase.GetCurrentMethod()?.ReflectedType?.FullName);
        var response = await lookupBs.Status();
        logger.Log(LogLevel.Debug, "{@Method} ended", System.Reflection.MethodBase.GetCurrentMethod()?.ReflectedType?.FullName);
        return Ok(response);
    }
}