using Microsoft.ML.Data;

namespace global2.NET.Database.Models
{
    public class EnergyPrediction
    {
        [ColumnName("Score")]
        public float PredictedConsumption { get; set; }
    }
}
