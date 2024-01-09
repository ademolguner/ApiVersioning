using Microsoft.AspNetCore.Mvc;

namespace ApiVersioning.Api.Controllers.v2;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
//[Route("api/[controller]")]
[ApiVersion("2.0")]
public class ProductController : ControllerBase
{
    
    //[MapToApiVersion("1.0")]
    [HttpGet]
    [Route("id/{id}")]
    public Task<IResult> GetByIdAsync(string id)
    {
       
        return Task.FromResult(Results.Ok("GetByIdAsync"));
    }
    
    [HttpGet]
    [Route("list")]
    public Task<IResult> GetListAsync()
    {
       
        return Task.FromResult(Results.Ok("GetListAsync"));
    }
}