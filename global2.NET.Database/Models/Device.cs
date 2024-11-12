namespace global2.NET.Database.Models
{
    public class Device
    {
        public long Id { get; set; }
        public string DeviceName { get; set; }
        public string DeviceType { get; set; }
        public string DeviceStatus { get; set; }
        public EnergyLecture EnergyLectures { get; set; }
    }
}
