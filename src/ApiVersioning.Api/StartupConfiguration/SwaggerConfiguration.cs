using System.Reflection;
using ApiVersioning.Api.MockData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Swashbuckle.AspNetCore.Filters;

namespace ApiVersioning.Api.StartupConfiguration;

public static class SwaggerConfiguration
{
    public static IServiceCollection AddSwaggerWithVersion(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddSwaggerGen();
        services.AddApiVersioning(opt =>
        {
            opt.DefaultApiVersion = new ApiVersion(1, 0);
            opt.AssumeDefaultVersionWhenUnspecified = true;
            opt.ReportApiVersions = true;
            opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                new HeaderApiVersionReader("x-api-version"),
                new MediaTypeApiVersionReader("x-api-version"));
        });

        services.ConfigureOptions<ConfigureSwaggerOptions>();
        
        services.AddVersionedApiExplorer(setup =>
        {
            setup.GroupNameFormat = "'v'VVV";
            setup.SubstituteApiVersionInUrl = true;
        });
        
        services.AddSwaggerExamplesFromAssemblies(typeof(MockProduct).GetTypeInfo().Assembly);
        
        return services;
    }

    public static IApplicationBuilder UseSwaggerWithVersion(this IApplicationBuilder app)
    {
        var apiVersionDescriptionProvider = app.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>();

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName.ToUpperInvariant());
            }
            
            
        });

        return app;
    }
}