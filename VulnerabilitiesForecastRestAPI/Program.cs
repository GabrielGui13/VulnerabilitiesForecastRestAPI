using Microsoft.ML.Data;
using Microsoft.Extensions.ML;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddPredictionEnginePool<ModelInput, ModelOutput>()
	.FromFile(modelName: "SentimentAnalysisModel", filePath: "sentiment_model.zip", watchForChanges: true);

var app = builder.Build();

var predictionHandler =
	async (PredictionEnginePool<ModelInput, ModelOutput> predictionEnginePool, ModelInput input) =>
		await Task.FromResult(predictionEnginePool.Predict(modelName: "SentimentAnalysisModel", input));

app.MapPost("/predict", predictionHandler);

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public class ModelInput {
	public string SentimentText;
}

public class ModelOutput {
	[ColumnName("PredictedLabel")]
	public bool Sentiment { get; set; }

	public float Probability { get; set; }

	public float Score { get; set; }
}