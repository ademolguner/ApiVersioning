using System.Text.Json.Serialization;
using ApiVersioning.Api.StartupConfiguration;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args); 
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerWithVersion(builder.Configuration);
builder.Services.AddCors();
builder.Services
    .AddControllers()
    .AddJsonOptions(j => {
                                      j.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                                    }
                   );
builder.Services.AddHealthChecks();

NewRelic.Api.Agent.NewRelic.SetApplicationName($"{builder.Environment.ApplicationName}.{builder.Environment.EnvironmentName}");


var app = builder.Build();
app.UseSwaggerWithVersion();
app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();