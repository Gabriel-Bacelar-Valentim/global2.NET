using global2.NET.Database.Models;
using Microsoft.ML;
using System.IO;

namespace global2.NET.Extensions
{
    public class EnergyModelTrainingService
    {
        public void TrainAndSaveModel(string dataPath, string modelPath)
        {
            var mlContext = new MLContext();

            IDataView dataView = mlContext.Data.LoadFromTextFile<EnergyLectureInputPrediction>(
                dataPath, separatorChar: ',', hasHeader: true);

            var split = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);

            var pipeline = mlContext.Transforms.Concatenate("Features", nameof(EnergyLectureInputPrediction.ProducaoEnergia))
                .Append(mlContext.Regression.Trainers.Sdca(
                    labelColumnName: nameof(EnergyLectureInputPrediction.Consumo),
                    maximumNumberOfIterations: 100));

            var model = pipeline.Fit(split.TrainSet);

            using (var fileStream = new FileStream(modelPath, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                mlContext.Model.Save(model, dataView.Schema, fileStream);
            }
        }
    }
}