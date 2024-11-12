namespace global2.NET.Database.Models
{
    public class ContactNumber
    {
        public long PhoneId { get; set; }
        public string CountryCode { get; set; }
        public string DDD { get; set; }
        public string PhoneNumber { get; set; }
        public OptimizationAlert OptimizationAlerts { get; set; }
    }
}
