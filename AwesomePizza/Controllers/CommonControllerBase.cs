using Microsoft.AspNetCore.Mvc;

namespace AwesomePizza.Controllers;

[ApiController]
[Route("[controller]")]
[Consumes("application/json")]
[Produces("application/json")]
public abstract class CommonControllerBase: ControllerBase
{
    /// <summary>
    /// Logger utility
    /// </summary>
    protected readonly ILogger<CommonControllerBase> Logger;
    
    /// <summary>
    /// Common class controller constructor
    /// </summary>
    /// <param name="logger"></param>
    protected CommonControllerBase(ILogger<CommonControllerBase> logger)
    {
        Logger = logger;
    }
}