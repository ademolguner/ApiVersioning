using ApiVersioning.Api.MockData;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioning.Api.Controllers.v2;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("2.0")]
public class ProductController : ControllerBase
{
    
    //[MapToApiVersion("2.0")]
    [HttpGet]
    [Route("id/{id}")]
    public Task<IResult> GetByIdAsync(string id)
    {
        var allProducts = MockProduct.GetDatabaseExampleModels();
        var response = allProducts.FirstOrDefault(c => c.Id == id);
        if(response!=null)
            return Task.FromResult(Results.Ok(response));
        return Task.FromResult(Results.Ok(response));
    }
    
    //[MapToApiVersion("2.0")]
    [HttpGet]
    [Route("list")]
    public Task<IResult> GetListAsync()
    {
        var allProducts = MockProduct.GetDatabaseExampleModels();
        return Task.FromResult(Results.Ok(allProducts));
    }
}