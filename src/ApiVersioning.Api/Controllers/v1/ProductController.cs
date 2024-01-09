using ApiVersioning.Api.MockData;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioning.Api.Controllers.v1;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class ProductController : ControllerBase
{
    
    [MapToApiVersion("1.0")]
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
    
    [MapToApiVersion("1.0")]
    [HttpGet]
    [Route("list")]
    public Task<IResult> GetListAsync()
    {
        var allProducts = MockProduct.GetDatabaseExampleModels();
        return Task.FromResult(Results.Ok(allProducts));
    }
}