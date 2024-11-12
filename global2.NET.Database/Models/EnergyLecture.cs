namespace global2.NET.Database.Models
{
    public class EnergyLecture
    {
        public long Id { get; set; }
        public string Consumption { get; set; }
        public string EnergyProduction { get; set; }
        public DateTime? LectureDate { get; set; }
        public Device Devices { get; set; }
    }
}
