namespace global2.NET.Database.Models
{
    public class EnergyLecture
    {
        public long Id { get; set; }
        public string Consumo { get; set; }
        public string ProducaoEnergia { get; set; }
        public DateTime? DataLeitura { get; set; }
        public ICollection<Device> Devices { get; set; } = new List<Device>();
    }
}
