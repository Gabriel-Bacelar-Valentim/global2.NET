using Microsoft.ML.Data;

namespace global2.NET.Database.Models
{
    public class EnergyLectureData
    {
        [LoadColumn(0)]
        public float Consumo { get; set; }

        [LoadColumn(1)]
        public float ProducaoEnergia { get; set; }

        [LoadColumn(2)]
        public int DataLeitura { get; set; }
    }
}
