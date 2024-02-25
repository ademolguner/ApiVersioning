using ApiVersioning.Api.MockData;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioning.Api.Controllers.v2;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[Route("api/[controller]")]
[ApiVersion("2.0")]
public class ArticleController : ControllerBase
{
    
    [MapToApiVersion("2.0")]
    [HttpGet]
    [Route("id/{id}")]
    public Task<IResult> GetByIdAsync(string id)
    {
        var allArticles = MockArticle.GetDatabaseExampleModels();
        var response = allArticles.FirstOrDefault(c => c.Id == id);
        return Task.FromResult(Results.Ok(response));
    }
    
    [MapToApiVersion("2.0")]
    [HttpGet]
    [Route("list")]
    public Task<IResult> GetListAsync()
    {
        var allArticles = MockArticle
                                                    .GetDatabaseExampleModels()
                                                    .OrderByDescending(d=>d.OrderValue);
        return Task.FromResult(Results.Ok(allArticles));
    }
}