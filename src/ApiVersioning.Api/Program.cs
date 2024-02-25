using System.Text.Json.Serialization;
using ApiVersioning.Api.StartupConfiguration;

var builder = WebApplication.CreateBuilder(args); 
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerWithVersion();
builder.Services.AddCors();
builder.Services
    .AddControllers()
    .AddJsonOptions(j => {j.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull; });




var app = builder.Build();
app.UseSwaggerWithVersion();
app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();