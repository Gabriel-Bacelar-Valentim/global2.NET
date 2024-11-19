namespace global2.NET.Service.ServiceModel
{
    public class LeituraEnergiaRequest
    {
        public int IdLeitura { get; set; }
        public DateTime DataLeitura { get; set; }
        public float Consumo { get; set; }
        public float ProducaoEnergia { get; set; }
    }
}
