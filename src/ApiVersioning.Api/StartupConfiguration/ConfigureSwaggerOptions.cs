using System.Reflection;
using ApiVersioning.Api.Filters;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ApiVersioning.Api.StartupConfiguration;

public class ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider,IConfiguration configuration) : IConfigureNamedOptions<SwaggerGenOptions>
{
    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
        }
    }
    
    public void Configure(string? name, SwaggerGenOptions options)
    {
        options.OperationFilter<SwaggerJsonIgnoreFilter>();
        string folder = Environment.CurrentDirectory.Replace(Assembly.GetExecutingAssembly().GetName().Name, "");
        if (!string.IsNullOrEmpty(folder))
            foreach (var nm in Directory.GetFiles(folder, "*.xml", SearchOption.AllDirectories))
                options.IncludeXmlComments(filePath: nm);

        options.ExampleFilters();

        Configure(options);
    }
    
    private OpenApiInfo CreateVersionInfo(ApiVersionDescription desc)
    {
        var section = configuration.GetSection("SwaggerSettings");
        var apiName = section.GetValue<string>("Name");
        var apiDesc = section.GetValue<string>("Description");
        var teamName = section.GetValue<string>("TeamName");
        var teamEmail = section.GetValue<string>("TeamEmail");
        //var termsOfService = section.GetValue<string>("TermsOfService");
        
        var info = new OpenApiInfo
        {
            Title = apiName,
            Version = desc.ApiVersion.ToString(),
            Description = apiDesc,
            Contact = new OpenApiContact
            {
                Name = teamName,
                Email = teamEmail
            }
        };

        if (desc.IsDeprecated)
        {
            info.Description += " This API version has been deprecated. Please use one of the new APIs available from the explorer.";
        }

        return info;
    }
}