using System.Threading.Tasks;
using AwesomePizza.BL.Interfaces;
using AwesomePizza.Common.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AwesomePizza.Controllers;

public class CustomerController(ILogger<CustomerController> logger, ICustomerBs customerBs) : CommonControllerBase(logger)
{
    [HttpPut]
    [ProducesResponseType(typeof(ResponseDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<ResponseDto>> Upsert()
    {
        return Ok(new ResponseDto());
    }
}