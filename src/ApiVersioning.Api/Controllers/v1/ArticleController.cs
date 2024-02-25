using ApiVersioning.Api.MockData;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioning.Api.Controllers.v1;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[Route("api/[controller]")]
[ApiVersion("1.0")]
public class ArticleController : ControllerBase
{
    
    [MapToApiVersion("1.0")]
    [HttpGet]
    [Route("id/{id}")]
    public Task<IResult> GetByIdAsync(string id)
    {
        var allProducts = MockArticle.GetDatabaseExampleModels();
        var response = allProducts.FirstOrDefault(c => c.Id == id);
        return Task.FromResult(Results.Ok(response));
    }
    
    [MapToApiVersion("1.0")]
    [HttpGet]
    [Route("list")]
    public Task<IResult> GetListAsync()
    {
        var allProducts = MockArticle.GetDatabaseExampleModels().OrderBy(d=>d.OrderValue);
        return Task.FromResult(Results.Ok(allProducts));
    }
}