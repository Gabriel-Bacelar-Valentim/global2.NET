using global2.NET.Database.Models;
using Microsoft.ML;

namespace global2.NET.Extensions
{
    public class EnergyPredictionService
    {
        private readonly PredictionEngine<EnergyLectureData, EnergyPrediction> _predictionEngine;

        public EnergyPredictionService(string modelPath)
        {
            var mlContext = new MLContext();

            ITransformer trainedModel = mlContext.Model.Load(modelPath, out var modelInputSchema);
            _predictionEngine = mlContext.Model.CreatePredictionEngine<EnergyLectureData, EnergyPrediction>(trainedModel);
        }

        public float PredictConsumption(float producaoEnergia)
        {
            var input = new EnergyLectureData { ProducaoEnergia = producaoEnergia };
            var prediction = _predictionEngine.Predict(input);
            return prediction.PredictedConsumption;
        }
    }
}