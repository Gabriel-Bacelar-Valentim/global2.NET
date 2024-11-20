using global2.NET.Configuration;
using global2.NET.Database;
using global2.NET.Extensions;
using global2.NET.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;
APIConfiguration apiConfiguration = new();
configuration.Bind(apiConfiguration);
builder.Services.Configure<APIConfiguration>(configuration);

var oracleConfig = builder.Configuration.GetSection("OracleFIAP");

string connectionString =
    $"User Id={oracleConfig["UserID"]};Password={oracleConfig["Password"]};" +
    $"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={oracleConfig["Host"]})(PORT={oracleConfig["Port"]}))" +
    $"(CONNECT_DATA=(SID={oracleConfig["SID"]})))";

builder.Services.AddDbContext<FIAPDbContext>(options =>
    options.UseOracle(connectionString));

builder.Services.AddScoped<ProcedureDataService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger(apiConfiguration);
builder.Services.AddContext(apiConfiguration);
builder.Services.AddServices();

string csvFilePath = configuration["ModelConfig:CsvFilePath"];
string modelPath = configuration["ModelConfig:ModelPath"];
builder.Services.AddScoped<EnergyModelTrainingService>();
builder.Services.AddSingleton<EnergyPredictionService>(provider => new EnergyPredictionService(modelPath));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var trainingService = scope.ServiceProvider.GetRequiredService<EnergyModelTrainingService>();
    trainingService.TrainAndSaveModel(csvFilePath, modelPath);
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();