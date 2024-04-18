using Microsoft.ML.Data;

namespace VulnerabilitiesForecastRestAPI.Models {
	public class ModelInput {
		public string SentimentText { get; set; }
	}

	public class ModelOutput {
		[ColumnName("PredictedLabel")]
		public bool Sentiment { get; set; }

		public float Probability { get; set; }

		public float Score { get; set; }
	}
}
