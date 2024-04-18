using Microsoft.Extensions.ML;
using VulnerabilitiesForecastRestAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder
	.Services
	.AddPredictionEnginePool<ModelInput, ModelOutput>()
	.FromFile(modelName: "SentimentAnalysisModel", filePath: "Models/ML/sentiment_model.zip", watchForChanges: true);

builder
	.Services
	.AddPredictionEnginePool<ModelInput, ModelOutput>()
	.FromUri(
	  modelName: "SentimentAnalysisModelURL",
	  uri: "https://github.com/dotnet/samples/raw/main/machine-learning/models/sentimentanalysis/sentiment_model.zip",
	  period: TimeSpan.FromMinutes(1));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();