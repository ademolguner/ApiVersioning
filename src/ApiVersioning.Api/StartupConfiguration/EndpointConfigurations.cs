// using ApiVersioning.Api.EndPoints.v1;
// using ApiVersioning.Api.EndPoints.v2;

namespace ApiVersioning.Api.StartupConfiguration;

public static class EndpointConfigurations
{
    public static IEndpointRouteBuilder RegistrationEndpoints(this IEndpointRouteBuilder app)
    {
        //EndPoints.v1.ArticleController.MapProductApiEndpoints(app);
        //EndPoints.v2.ArticleController.MapProductApiEndpoints(app);
        return app;
    }
}