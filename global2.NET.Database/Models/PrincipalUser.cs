namespace global2.NET.Database.Models
{
    public class PrincipalUser
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Address? Address { get; set; }
        public ContactNumber? ContactNumbers { get; set; }
        public Device? Devices { get; set; }
        public IncentiveScore? IncentiveScore { get; set; }
    }
}
