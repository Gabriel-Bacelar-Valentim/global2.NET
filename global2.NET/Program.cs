using global2.NET.Configuration;
using global2.NET.Extensions;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;
APIConfiguration apiConfiguration = new();
configuration.Bind(apiConfiguration);
builder.Services.Configure<APIConfiguration>(configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger(apiConfiguration);
builder.Services.AddContext(apiConfiguration);
builder.Services.AddServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
