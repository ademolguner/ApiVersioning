// using ApiVersioning.Api.EndPoints.v1;
// using ApiVersioning.Api.EndPoints.v2;

namespace ApiVersioning.Api.StartupConfiguration;

public static class EndpointConfigurations
{
    public static IEndpointRouteBuilder RegistrationEndpoints(this IEndpointRouteBuilder app)
    {
        //EndPoints.v1.ProductController.MapProductApiEndpoints(app);
        //EndPoints.v2.ProductController.MapProductApiEndpoints(app);
        return app;
    }
}