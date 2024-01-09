using ApiVersioning.Api.MockData;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioning.Api.EndPoints.v2;

public static class ProductApiController
{
    public static void MapProductApiEndpoints(this IEndpointRouteBuilder app)
    {
        var appProductGroupV2 = app.MapGroup("api/v{version:apiVersion}/product");
        appProductGroupV2.MapPost("/id/{id}", GetByIdAsync).WithName(nameof(GetByIdAsync));
        appProductGroupV2.MapPost("/list", GetListAsync).WithName(nameof(GetListAsync));
    }
    
    [HttpGet("id/{id}")]
    private static Task<IResult> GetByIdAsync([FromRoute] string id)
    {
        var allProducts = MockProduct.GetDatabaseExampleModels();
        var response = allProducts.FirstOrDefault(c => c.Id == id);
        if(response!=null)
            return Task.FromResult(Results.Ok(response));;
        return Task.FromResult(Results.Ok(response));
    }
    
    [HttpGet("list")]
    private static async Task<IResult> GetListAsync()
    {
        var allProducts = MockProduct.GetDatabaseExampleModels();
        return Results.Ok(allProducts);
    }
}