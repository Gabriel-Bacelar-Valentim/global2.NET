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
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();